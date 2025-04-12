using Core.Dtos;
using Core.Responses;
using Infra.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductController(ProductService productService) : ControllerBase
	{
		[HttpPost]
		public async Task<ActionResult<ProductDetailsDto>> Create([FromBody] CreateProductDto dto)
		{
			var product= await productService.AddAsync(dto);
			return Ok(BaseResponse<ProductDetailsDto>.SuccessResponse(product, "Product Created successfully"));

		}
	}
}
