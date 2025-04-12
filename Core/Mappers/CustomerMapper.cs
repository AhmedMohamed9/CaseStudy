using Core.Dtos;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Mappers
{
	public static class CustomerMapper
	{
		public static Customer ToEntity(this CustomerDto dto)
		{
			return new Customer
			{
				Name = dto.Name,
				Email = dto.Email,
				Address = dto.Address,
				Phone = dto.Phone
			};
		}
		public static CustomerDetailsDto ToDto(this Customer entity)
		{
			return new CustomerDetailsDto
			{
				Id = entity.Id,
				Name = entity.Name,
				Email = entity.Email,
				Address = entity.Address,
				Phone = entity.Phone
			};
		}

	}
}
