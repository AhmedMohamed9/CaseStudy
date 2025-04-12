using Core.Dtos;
using Core.Interfaces;
using Core.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Services
{
	public class ProductService(IProductRepository productRepository)
	{
		public async Task<ProductDetailsDto> AddAsync(CreateProductDto dto)
		{
			var product = dto.ToEntity();

			await productRepository.AddAsync(product);
			await productRepository.SaveChangesAsync();
			return product.ToDetailsDto();
		}
	}
}
