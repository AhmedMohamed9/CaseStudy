using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dtos
{
	public class CustomerDto
	{
		[Required]
		[StringLength(100)]
		public required string Name { get; set; }

		[Required]
		[EmailAddress]
		[StringLength(100)]
		public required string Email { get; set; }

		[Required]
		[StringLength(200)]
		public required string Address { get; set; }

		[Required]
		[StringLength(20)]
		public required string Phone { get; set; }
	}
}
