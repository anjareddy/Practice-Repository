
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFBestPractices.Entities.Configuration
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
            builder.Property(p => p.Address) .HasMaxLength(2000).IsRequired();
            builder.HasKey(p => p.Id);
        }
    }
}
