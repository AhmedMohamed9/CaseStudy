﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dtos
{
	public class OrderItemDetailsDto
	{
		public string ProductName { get; set; } = string.Empty;
		public int Quantity { get; set; }
	}
}
