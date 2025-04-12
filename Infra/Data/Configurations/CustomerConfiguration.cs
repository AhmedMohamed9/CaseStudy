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
	public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
	{
		public void Configure(EntityTypeBuilder<Customer> builder)
		{
			builder.ToTable("Customers");
			builder.HasKey(c => c.Id);
			builder.Property(c => c.Name)
				.IsRequired()
				.HasMaxLength(100);

			builder.Property(c => c.Email)
				.IsRequired()
				.HasMaxLength(100);

			builder.Property(c => c.Address)
				.IsRequired()
				.HasMaxLength(200);

			builder.Property(c => c.Phone)
				.IsRequired()
				.HasMaxLength(20);

			builder.HasIndex(c => c.Email).IsUnique();

			builder.HasMany(c => c.Orders)
				.WithOne(c => c.Customer)
				.HasForeignKey(c=>c.CustomerID)
				.OnDelete(DeleteBehavior.Restrict);

		}
	}
}
