using EFBestPractices.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace EFBestPractices.Domain
{
    public class EFBestPracticesDbContext: DbContext
    {
        public EFBestPracticesDbContext(DbContextOptions<EFBestPracticesDbContext> options) : base(options) 
        { 
        }

        public DbSet<Venue> VenueEntities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EFBestPracticesDbContext).Assembly);
        }
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Conventions.Remove(typeof(ForeignKeyIndexConvention));
        }
    }
}
