using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain;

namespace DataAccess.Configurations
{
    public class StoryConfiguration : IEntityTypeConfiguration<Story>
    {
        public void Configure(EntityTypeBuilder<Story> builder)
        {
            builder.Property(s => s.Name).IsRequired().HasMaxLength(200);
            builder.Property(s => s.Description).IsRequired();
            builder.Property(s => s.CreatedAt).HasDefaultValueSql("GETDATE()");
            
            builder.HasMany(s => s.StoryJournalists)
                   .WithOne(sj => sj.Story)
                   .HasForeignKey(sj => sj.StoryId);
            
        }
    }
}
