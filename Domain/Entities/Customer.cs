using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
	public class Customer
	{
		public int Id { get; set; }
		public required string Name { get; set; }
		public required string Email { get; set; }
		public required string Address { get; set; }
		public required string Phone { get; set; }
		public ICollection<Order> Orders { get; set; } = new List<Order>();

	}
}
