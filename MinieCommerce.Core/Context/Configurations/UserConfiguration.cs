using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MinieCommerce.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MinieCommerce.Core.Context.Configurations
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(u => u.FullName)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasIndex(u => u.Email)
                .IsUnique();
            
            builder.Property(u => u.Role)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
