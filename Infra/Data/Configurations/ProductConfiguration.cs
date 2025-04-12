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
	public class ProductConfiguration : IEntityTypeConfiguration<Product>
	{
		public void Configure(EntityTypeBuilder<Product> builder)
		{
			builder.ToTable("Products");

			builder.HasKey(p => p.Id);

			builder.Property(p => p.Name)
				.IsRequired()
				.HasMaxLength(100);

			builder.Property(p => p.Description)
				.IsRequired()
				.HasMaxLength(500);

			builder.Property(p => p.Price)
				.HasColumnType("decimal(18,2)")
				.IsRequired();

			builder.Property(p => p.StockQuantity)
				.IsRequired()
				.HasDefaultValue(0);

			builder.HasMany(p => p.OrderItems)
				.WithOne(o => o.Product)
				.HasForeignKey(o => o.ProductId)
				.OnDelete(DeleteBehavior.Restrict);
		}
	}
}
