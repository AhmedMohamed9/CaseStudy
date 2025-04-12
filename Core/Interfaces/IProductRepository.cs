using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
	public interface IProductRepository
	{
		Task<Product?> AddAsync(Product product);
		Task<Product?> GetByIdAsync(int id);
		void Update(Product product);
		Task SaveChangesAsync();
	}
}
