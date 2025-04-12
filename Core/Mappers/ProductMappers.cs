using Core.Dtos;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Mappers
{
	public static class ProductMappers
	{
		public static ProductDetailsDto ToDetailsDto(this Product product)
		{
			return new ProductDetailsDto
			{
				Id = product.Id,
				Name = product.Name,
				Description = product.Description,
				Price = product.Price,
				StockQuantity = product.StockQuantity,
			};
		}
		public static Product ToEntity(this CreateProductDto product)
		{
			return new Product
			{
				Name = product.Name,
				Description = product.Description,
				Price = product.Price,
				StockQuantity= product.StockQuantity
			};
		}

	}
}
