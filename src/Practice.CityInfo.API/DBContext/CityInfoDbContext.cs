using Microsoft.EntityFrameworkCore;
using Practice.CityInfo.API.Entities;

namespace Practice.CityInfo.API.DBContext
{
    public class CityInfoDbContext: DbContext
    {

        public CityInfoDbContext(DbContextOptions<CityInfoDbContext> options) : base(options)
        {
        }

        public DbSet<CityEntity> Cities { get; set; }

        public DbSet<PointsOfInterestEntity> PointsOfInterests { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("connectionstring");
        //    base.OnConfiguring(optionsBuilder);
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CityEntity>()
                .HasData(new CityEntity("Newyork")
                {
                    Id = 1,
                    Description = "One of big cities in US",
                },
                new CityEntity("Kent")
                {
                    Id = 2,
                    Description = "It has a public university",
                },
                new CityEntity("Cleveland")
                {
                    Id = 3,
                    Description = "It has a public university on Ohio",
                });
            modelBuilder.Entity<PointsOfInterestEntity>()
               .HasData(new PointsOfInterestEntity("Twin Towers")
               {
                   Id = 1,
                   CityId = 1,
                   Description = "Twin Towers Description"
               },
               new PointsOfInterestEntity("Edge Point")
               {
                   Id = 2,
                   CityId = 1,
                   Description = "Edge Point Description"
               },
               new PointsOfInterestEntity("Downtown")
               {
                   Id = 3,
                   CityId = 2,
                   Description = "Downtown Description"
               },
               new PointsOfInterestEntity("University Campus")
               {
                   Id = 4,
                   CityId = 2,
                   Description = "University Campus Description"
               },
               new PointsOfInterestEntity("Heli Towers")
               {
                   Id = 5,
                   CityId = 3,
                   Description = "Heli Towers Description"
               });
            base.OnModelCreating(modelBuilder);
        }
    }
}
