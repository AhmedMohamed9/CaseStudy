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
	public class OrderStatusHistoryConfiguration : IEntityTypeConfiguration<OrderStatusHistory>
	{
		public void Configure(EntityTypeBuilder<OrderStatusHistory> builder)
		{
			builder.ToTable("OrderStatusHistories");
			builder.HasKey(h => h.Id);
			builder.Property(h => h.Status)
				.IsRequired();
			builder.Property(o=>o.ChangedAt)
				.HasDefaultValueSql("GETDATE()");

			builder.HasOne(h => h.Order)
				.WithMany(o => o.StatusHistory)
				.HasForeignKey(h => h.OrderId)
				.OnDelete(DeleteBehavior.Cascade);

			builder.HasIndex(h => h.OrderId);

		}
	}
}
