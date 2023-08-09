using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.DataAccess.Entities.EntityConfiguration
{
    public class VenueEntityConfiguration : IEntityTypeConfiguration<VenueEntity>
    {
        public void Configure(EntityTypeBuilder<VenueEntity> builder)
        {
            builder.Property(p => p.Id).ValueGeneratedOnAddOrUpdate();
            builder.Property(p => p.Name)
                .HasMaxLength(500)
                .IsRequired();
            builder.Property(p => p.Description) .HasMaxLength(500).IsRequired();
            builder.HasKey(p => p.Id);
        }
    }
}
