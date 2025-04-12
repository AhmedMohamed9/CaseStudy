using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Data.Configurations
{
	public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
	{
		public void Configure(EntityTypeBuilder<OrderItem> builder)
		{
			builder.ToTable("OrderItems");
			builder.HasKey(oi => oi.Id);

			builder.Property(oi => oi.Quantity)
				   .IsRequired();

			builder.Property(oi => oi.Subtotal)
				.HasColumnType("decimal(18,2)")
				.IsRequired();

			builder.HasOne(oi => oi.Order)
				.WithMany(o => o.OrderItems)
				.HasForeignKey(o => o.OrderId)
				.OnDelete(DeleteBehavior.Cascade);

			builder.HasOne(oi => oi.Product)
			   .WithMany(p => p.OrderItems)
			   .HasForeignKey(oi => oi.ProductId)
			   .OnDelete(DeleteBehavior.Restrict);
		}
	}
}
