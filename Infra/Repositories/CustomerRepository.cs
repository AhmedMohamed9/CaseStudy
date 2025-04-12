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
	public class CustomerRepository(AppDbContext context) : ICustomerRepository
	{
		public async Task<Customer> AddAsync(Customer customer)
		{
			await context.AddAsync(customer);
			return customer;
		}

		public async Task<List<Customer>> GetAllAsync()
		{
			return await context.Customers.ToListAsync();
		}

		public async Task<Customer?> GetByIdAsync(int id)
		{
			return await context.Customers.FirstOrDefaultAsync(x => x.Id == id);
		}

	

		public async Task<bool> IsCustomerExistAsync(string email)
		{
			return await context.Customers.AnyAsync(c=>c.Email==email);
		}

		public async Task<bool> IsCustomerExistByIdAsync(int id)
		{
			return await context.Customers.AnyAsync(c => c.Id == id);
		}

		public async Task SaveChangesAsync()
		{
			await context.SaveChangesAsync(); 
		}
	}
}
