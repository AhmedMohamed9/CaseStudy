using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
	public interface ICustomerRepository
	{
		Task<Customer?> GetByIdAsync(int id);
		Task<bool> IsCustomerExistAsync(string email);
		Task<List<Customer>> GetAllAsync();
		Task<Customer> AddAsync(Customer customer);
		Task<bool> IsCustomerExistByIdAsync(int id);
		Task SaveChangesAsync();

	}
}
