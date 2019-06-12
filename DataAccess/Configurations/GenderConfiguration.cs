using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain;

namespace DataAccess.Configurations
{
    public class GenderConfiguration : IEntityTypeConfiguration<Gender>
    {
        public void Configure(EntityTypeBuilder<Gender> builder)
        {
            builder.Property(g => g.Name).IsRequired().HasMaxLength(40);
            builder.Property(g => g.CreatedAt).HasDefaultValueSql("GETDATE()");
            // builder.HasIndex(g => g.Name).IsUnique();
        }
    }
}
