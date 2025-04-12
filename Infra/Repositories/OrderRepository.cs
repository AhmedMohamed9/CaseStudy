using Core.Interfaces;
using Domain.Entities;
using Infra.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositories
{
	public class OrderRepository(AppDbContext context) : IOrderRepository
	{
		public async Task<Order> AddAsync(Order order)
		{
			await context.AddAsync(order);
			return order;
		}

		public async Task<Order?> GetByIdAsync(int id)
		{
			var order = await context.Orders
				.Include(a=>a.OrderItems)
				.ThenInclude(p=>p.Product)
				.Include(c=>c.Customer)
				.FirstOrDefaultAsync(o => o.Id == id);
			return order;
		}

		public async Task SaveChangesAsync()
		{
			await context.SaveChangesAsync();
		}

		public void Update(Order order)
		{
			context.Entry(order).State = EntityState.Modified;
		}

		
	}
}
