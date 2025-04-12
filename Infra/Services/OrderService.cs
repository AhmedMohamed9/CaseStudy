using Core.Dtos;
using Core.Interfaces;
using Core.Mappers;
using Domain.Entities;
using Domain.Enums;
using Infra.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Services
{
	public class OrderService(
		IOrderRepository orderRepository,
		IProductRepository productRepository,
		IOrderStatusHistoryRepository orderStatusHistoryRepository,
		ICustomerRepository customerRepository)
	{
		public async Task<OrderDetailsDto?> GetByIdAsync(int id)
		{
			var order = await orderRepository.GetByIdAsync(id);
			return order?.ToDto();
		}
		public async Task<OrderDetailsDto> AddAsync(CreateOrderDto dto)
		{
			var customer = await customerRepository.GetByIdAsync(dto.CustomerID);
			if (customer == null) throw new Exception("Customer Not Exist");

			var order = new Order
			{
				CustomerID = dto.CustomerID,
				Customer= customer,
				OrderDate = DateTime.UtcNow,
				Status = OrderStatus.Pending,
				OrderItems = new List<OrderItem>()
			};
			foreach (var item in dto.OrderItems)
			{
				var product = await productRepository.GetByIdAsync(item.ProductId)
					?? throw new Exception("Product not found");

				if (item.Quantity < 1) throw new Exception($"product {product.Name} Quantity must be at least 1");

				if (product.StockQuantity < item.Quantity)
					throw new Exception("Insufficient stock");

				product.StockQuantity -= item.Quantity;
				productRepository.Update(product);

				order.OrderItems.Add(new OrderItem
				{
					ProductId = product.Id,
					Quantity = item.Quantity,
					Subtotal = product.Price * item.Quantity,
				});
			}

			await orderRepository.AddAsync(order);
			await orderRepository.SaveChangesAsync();
			return order.ToDto();
		}
		public async Task<OrderDetailsDto?> UpdateStatusAsync(int orderId,OrderStatus status)
		{
			var order = await orderRepository.GetByIdAsync(orderId);
			if (order == null)	return null;

			order.Status = status;

			orderRepository.Update(order);
			await AddOrderStatusHistoryAsync(orderId,status);
			await orderRepository.SaveChangesAsync();
			return order.ToDto();

		}
		private async Task AddOrderStatusHistoryAsync(int orderId,OrderStatus status)
		{
			var StatusHistory = new OrderStatusHistory()
			{
				OrderId=orderId,
				Status=status
			};
			await orderStatusHistoryRepository.AddAsync(StatusHistory);
		}
	}
}
