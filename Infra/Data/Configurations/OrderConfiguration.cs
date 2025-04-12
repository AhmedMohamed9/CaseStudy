using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Data.Configurations
{
	public class OrderConfiguration : IEntityTypeConfiguration<Order>
	{
		public void Configure(EntityTypeBuilder<Order> builder)
		{
			builder.ToTable("Orders");

			builder.HasKey(o => o.Id);

			builder.Property(o => o.OrderDate)
				.IsRequired()
				.HasDefaultValueSql("GETDATE()");

			builder.Property(a => a.Status)
				.IsRequired()
				.HasDefaultValue(OrderStatus.Pending);

			builder.HasMany(o => o.OrderItems)
				.WithOne(o => o.Order)
				.HasForeignKey(o => o.OrderId)
				.OnDelete(DeleteBehavior.Cascade);

			builder.HasOne(o => o.Customer)
	             .WithMany(c => c.Orders)
	             .HasForeignKey(o => o.CustomerID)
	             .OnDelete(DeleteBehavior.Restrict);

			builder.HasIndex(o => o.OrderDate);
			builder.HasIndex(o => o.Status);
			builder.HasIndex(o => o.CustomerID);
		}
	}
}
