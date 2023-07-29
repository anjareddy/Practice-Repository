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
    }
}
