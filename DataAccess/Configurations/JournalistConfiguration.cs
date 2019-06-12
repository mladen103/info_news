using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain;

namespace DataAccess.Configurations
{
    public class JournalistConfiguration : IEntityTypeConfiguration<Journalist>
    {
        public void Configure(EntityTypeBuilder<Journalist> builder)
        {
            builder.Property(j => j.FirstName).IsRequired().HasMaxLength(40);
            builder.Property(j => j.LastName).IsRequired().HasMaxLength(40);

            builder.Property(j => j.CreatedAt).HasDefaultValueSql("GETDATE()");

            builder
                .HasMany(j => j.JournalistStories)
                .WithOne(js => js.Journalist)
                .HasForeignKey(js => js.JournalistId);
        }
    }
}
