using Core.Dtos;
using Core.Responses;
using Infra.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CustomerController(CustomerService customerService) : ControllerBase
	{
		[HttpGet]
		public async Task<ActionResult<List<CustomerDetailsDto>>> GetAll()
		{
			var customers = await customerService.GetAllAsync();
			return Ok(BaseResponse<List<CustomerDetailsDto>>.SuccessResponse(customers, "Customers retrieved successfully"));
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<CustomerDetailsDto>> GetById(int id)
		{
			var customer = await customerService.GetByIdAsync(id);

			if (customer == null)
				return NotFound(BaseResponse<CustomerDetailsDto>.Fail("Customer not found."));

			return Ok(BaseResponse<CustomerDetailsDto>.SuccessResponse(customer));
		}
		[HttpPost]
		public async Task<ActionResult<CustomerDetailsDto>> Create([FromBody] CustomerDto dto)
		{
			var created = await customerService.AddAsync(dto);

			if (created == null)
				return BadRequest(BaseResponse<CustomerDetailsDto>.Fail("Failed to create customer"));

			var response = BaseResponse<CustomerDetailsDto>.SuccessResponse(
				created,
				"Customer created successfully");

			return CreatedAtAction(
							nameof(GetById),
							new { id = created.Id },
							response);
		}
	}
}
