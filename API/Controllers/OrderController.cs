using Core.Dtos;
using Core.Responses;
using Domain.Enums;
using Infra.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class OrderController(OrderService orderService) : ControllerBase
	{
		[HttpGet("{id}")]
		public async Task<ActionResult<BaseResponse<OrderDetailsDto>>> GetById(int id)
		{
			var order = await orderService.GetByIdAsync(id);

			return order == null
				? NotFound(BaseResponse<OrderDetailsDto>.Fail("Order not found"))
				: Ok(BaseResponse<OrderDetailsDto>.SuccessResponse(order, "Order retrieved successfully"));
		}
		[HttpPost]
		public async Task<ActionResult<BaseResponse<OrderDetailsDto>>> Create([FromBody] CreateOrderDto dto)
		{
			
				var createdOrder = await orderService.AddAsync(dto);
				var response = BaseResponse<OrderDetailsDto>.SuccessResponse(
					createdOrder,
					"Order created successfully");

				return CreatedAtAction(
					nameof(GetById),
					new { id = createdOrder.Id },
					response);
			
			
		}
		[HttpPatch("{orderId}/status")]
		public async Task<ActionResult<BaseResponse<OrderDetailsDto>>> UpdateStatus(int orderId,[FromBody] OrderStatus status)
		{
			var updatedOrder = await orderService.UpdateStatusAsync(orderId, status);

			return updatedOrder == null
				? NotFound(BaseResponse<object>.Fail("Order not found"))
				: Ok(BaseResponse<OrderDetailsDto>.SuccessResponse(updatedOrder));
		}
	}
}

