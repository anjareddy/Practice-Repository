using Practice.CityInfo.API.Models;

namespace Practice.CityInfo.API
{
    public class CitiesDataStore
    {
        public List<CityEntity> Cities { get; set; }

        public CitiesDataStore() 
        {
            Cities = new List<CityEntity>()
            {
                new CityEntity()
                {
                    Id = 1,
                    Name = "Newyork",
                    Description = "One of big cities in US",
                    PointsOfInterests = new List<PointsOfInterestEntity>()
                    {
                        new PointsOfInterestEntity
                        {
                            Id = 1,
                            Name = "Twin Towers",
                            Description = "Twin Towers Description"
                        },
                        new PointsOfInterestEntity
                        {
                            Id = 2,
                            Name = "Edge Point",
                            Description = "Edge Point Description"
                        }
                    }
                },
                new CityEntity()
                {
                    Id = 2,
                    Name = "Kent",
                    Description = "It has a public university",
                    PointsOfInterests = new List<PointsOfInterestEntity>()
                    {
                        new PointsOfInterestEntity
                        {
                            Id = 3,
                            Name = "Downtown",
                            Description = "Downtown Description"
                        },
                        new PointsOfInterestEntity
                        {
                            Id = 4,
                            Name = "University Campus",
                            Description = "University Campus Description"
                        }
                    }
                },
                new CityEntity()
                {
                    Id = 3,
                    Name = "Cleveland",
                    Description = "It has a public university on Ohio",
                    PointsOfInterests = new List<PointsOfInterestEntity>()
                    {
                        new PointsOfInterestEntity
                        {
                            Id = 5,
                            Name = "Heli Towers",
                            Description = "Heli Towers Description"
                        }
                    }
                }
            };
        }
    }
}
