using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
	public class Order
	{
		public int Id { get; set; }
		public int CustomerID { get; set; }
		public DateTime OrderDate { get; set; }
		public OrderStatus Status { get; set; }
		public Customer Customer { get; set; } = null!;
		public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
		public ICollection<OrderStatusHistory> StatusHistory { get; set; } = new List<OrderStatusHistory>();

	}
}
