using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dtos
{
	public class CreateOrderDto
	{
		[Required]
		public int CustomerID { get; set; }

		[Required]
		[MinLength(1, ErrorMessage = "At least one order item is required.")]
		public required List<OrderItemDto> OrderItems { get; set; }

	}
}
