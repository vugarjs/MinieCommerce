using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MinieCommerce.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MinieCommerce.Core.Context.Configurations
{
    internal class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.ToTable("Payments");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Amount)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(p => p.Method)
                .IsRequired()
                .HasConversion<string>();

            builder.Property(p => p.PaymentDate)
                .HasDefaultValueSql("GETDATE()")
                .IsRequired();

            builder.HasOne(p => p.Order)
                .WithOne()
                .HasForeignKey<Payment>(p => p.OrderId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
