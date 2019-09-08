using CityInfo.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API
{
    public static class CityInfoContextExtensions
    {
        public static void EnsureSeedDataForContext(this CityInfoContext context)
        {
            if (context.Cities.Any())
            {
                return;
            }

            var cities = new List<City>()
            {
                new City()
                {
                    Name = "Zagreb",
                    Description = "Capital city",
                    PointsOfInterest = new List<PointOfInterest>()
                    {
                        new PointOfInterest()
                        {
                            Name = "Catedral",
                            Description = "The most visited catedral in the Croatia."
                        },
                        new PointOfInterest()
                        {
                            Name = "HNK",
                            Description = "The most visited theater in Croatia."
                        },
                    }
                },
                new City()
                {
                    Name = "Split",
                    Description = "Desc. for Split"
                },
                new City()
                {
                    Name = "Zadar",
                    Description = "Desc. for Zadar"
                }
            };

            context.Cities.AddRange(cities);
            context.SaveChanges();
        }
    }
}
