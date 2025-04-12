using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dtos
{
	public class CreateProductDto
	{
		[Required]
		[MaxLength(100)]
		public required string Name { get; set; }
		[Required]
		[MaxLength(250)]
		public required string Description { get; set; }
		public decimal Price { get; set; }
		public int StockQuantity { get; set; }
	}
}
