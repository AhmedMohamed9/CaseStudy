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
	public class ProductRepository(AppDbContext context) : IProductRepository
	{
	

		public async Task<Product?> GetByIdAsync(int id)
		{
			return await context.Products.FirstOrDefaultAsync(p => p.Id == id);
		}
		public async Task<Product?> AddAsync(Product product)
		{
			await context.Products.AddAsync(product);
			return product;
		}
		public async Task SaveChangesAsync()
		{
			await context.SaveChangesAsync();
		}

		public void Update(Product product)
		{
			context.Entry(product).State = EntityState.Modified;
		}
	}
}
