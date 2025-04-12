using Core.Dtos;
using Core.Interfaces;
using Core.Mappers;
using Domain.Entities;
using Infra.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Services
{
	public class CustomerService(ICustomerRepository customerRepository)
	{
		public async Task<List<CustomerDetailsDto>> GetAllAsync()
		{
			var customers = await customerRepository.GetAllAsync();
			return customers.Select(c => c.ToDto()).ToList();
		}
		public async Task<CustomerDetailsDto?> GetByIdAsync(int id)
		{
			var customer = await customerRepository.GetByIdAsync(id);
			return customer?.ToDto();
		}
		public async Task<CustomerDetailsDto> AddAsync(CustomerDto dto)
		{
			var customerExist= await customerRepository.IsCustomerExistAsync(dto.Email);

			if (customerExist) throw new Exception("Email Already Exist");

			var entity = dto.ToEntity();
			await customerRepository.AddAsync(entity);
			await customerRepository.SaveChangesAsync();
			return entity.ToDto();
		}
	}
}
