using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
	public class Product
	{
		public int Id { get; set; }
		public required string Name { get; set; }
		public required string Description { get; set; }
		public decimal Price { get; set; }
		public int StockQuantity { get; set; }
		public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

	}
}
