using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain;

namespace DataAccess.Configurations
{
    public class StoryJournalistConfiguration : IEntityTypeConfiguration<StoryJournalist>
    {
        public void Configure(EntityTypeBuilder<StoryJournalist> builder)
        {
            // composite key
            builder.HasKey(sj => new { sj.StoryId, sj.JournalistId });
        }
    }
}
