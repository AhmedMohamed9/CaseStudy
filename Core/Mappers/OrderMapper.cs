using Core.Dtos;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Mappers
{
	public static class OrderMapper
	{
		public static OrderDetailsDto ToDto(this Order order)
		{
			return new OrderDetailsDto
			{
				Id = order.Id,
				CustomerName = order.Customer.Name,
				OrderDate = order.OrderDate,
				Status = order.Status.ToString(),
				Items = order.OrderItems.Select(i => new OrderItemDetailsDto
				{
					ProductName = i.Product.Name,
					Quantity = i.Quantity
				}).ToList()
			};
		}
	}
}
