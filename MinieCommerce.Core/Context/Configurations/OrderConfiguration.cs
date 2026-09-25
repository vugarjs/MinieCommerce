using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MinieCommerce.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MinieCommerce.Core.Context.Configurations
{
    internal class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(o => o.Id);

            builder.Property(o=> o.OrderDate)
                .HasDefaultValueSql("GETDATE()")
                .IsRequired();

            builder.Property(o => o.TotalAmount)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(o => o.Status)
                .HasConversion<string>()
                .IsRequired();
        }
    }
}
