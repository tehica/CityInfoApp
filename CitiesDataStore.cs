using CityInfo.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API
{
    public class CitiesDataStore
    {
        public static CitiesDataStore Current { get; } = new CitiesDataStore();

        public List<CityDto> Cities { get; set; }

        public CitiesDataStore()
        {
            Cities = new List<CityDto>()
            {
                new CityDto()
                {
                    Id = 1,
                    Name = "Zagreb",
                    Description = "Capital city",
                    PointsOfInterest = new List<PointOfInterestDto>()
                    {
                        new PointOfInterestDto()
                        {
                            Id = 1,
                            Name = "Catedral",
                            Description = "The most visited catedral in the Croatia."
                        },
                        new PointOfInterestDto()
                        {
                            Id = 2,
                            Name = "HNK",
                            Description = "The most visited theater in Croatia."
                        },
                    }
                },
                new CityDto()
                {
                    Id = 2,
                    Name = "Split",
                    Description = "Desc. for Split"
                },
                new CityDto()
                {
                    Id = 3,
                    Name = "Zadar",
                    Description = "Desc. for Zadar"
                }

            };
        }
    }
}
