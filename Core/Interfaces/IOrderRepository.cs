using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
	public interface IOrderRepository
	{
		Task<Order?> GetByIdAsync(int id);
		Task<Order> AddAsync(Order order);
		void Update(Order order);
		Task SaveChangesAsync();
	}
}
