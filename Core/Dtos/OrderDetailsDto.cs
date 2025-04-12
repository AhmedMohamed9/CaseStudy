using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dtos
{
	public class OrderDetailsDto
	{
		public int Id { get; set; }
		public string CustomerName { get; set; } = string.Empty;
		public DateTime OrderDate { get; set; }
		public string Status { get; set; } = string.Empty;
		public List<OrderItemDetailsDto> Items { get; set; } = new();
	}
}
