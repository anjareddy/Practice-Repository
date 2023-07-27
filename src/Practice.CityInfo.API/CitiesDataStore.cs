using Practice.CityInfo.API.Models;

namespace Practice.CityInfo.API
{
    public class CitiesDataStore
    {
        public List<CityDto> Cities { get; set; }

        public static CitiesDataStore Current { get; } = new CitiesDataStore();

        public CitiesDataStore() 
        {
            Cities = new List<CityDto>()
            {
                new CityDto()
                {
                    Id = 1,
                    Name = "Newyork",
                    Description = "One of big cities in US",
                    PointsOfInterest = new List<PointsOfInterestDto>()
                    {
                        new PointsOfInterestDto
                        {
                            Id = 1,
                            Name = "Twin Towers",
                            Description = "Twin Towers Description"
                        },
                        new PointsOfInterestDto
                        {
                            Id = 2,
                            Name = "Edge Point",
                            Description = "Edge Point Description"
                        }
                    }
                },
                new CityDto()
                {
                    Id = 2,
                    Name = "Kent",
                    Description = "It has a public university",
                    PointsOfInterest = new List<PointsOfInterestDto>()
                    {
                        new PointsOfInterestDto
                        {
                            Id = 3,
                            Name = "Downtown",
                            Description = "Downtown Description"
                        },
                        new PointsOfInterestDto
                        {
                            Id = 4,
                            Name = "University Campus",
                            Description = "University Campus Description"
                        }
                    }
                },
                new CityDto()
                {
                    Id = 3,
                    Name = "Cleveland",
                    Description = "It has a public university on Ohio",
                    PointsOfInterest = new List<PointsOfInterestDto>()
                    {
                        new PointsOfInterestDto
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
