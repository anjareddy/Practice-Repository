using EFBestPractices.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFBestPractices.Domain.EntityConfiguration
{
    public class StringConvention : IEntityTypeConfiguration<Venue>
    {
        public void Configure(EntityTypeBuilder<Venue> builder)
        {
            builder.Property(p => p.Name)
                .HasMaxLength(500)
                .IsRequired();
            builder.Property(p => p.Description)
                .HasMaxLength(500)
                .IsRequired();
            builder.Property(p => p.Address)
                .HasMaxLength(2000)
                .IsRequired();
            builder.HasKey(p => p.Id);
        }
    }
}
