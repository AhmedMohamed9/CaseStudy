using Core.Interfaces;
using Domain.Entities;
using Infra.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositories
{
	public class OrderStatusHistoryRepository(AppDbContext context) : IOrderStatusHistoryRepository
	{
		public async Task AddAsync(OrderStatusHistory orderStatusHistory)
		{
			 await context.AddAsync(orderStatusHistory);

		}
	}
}
