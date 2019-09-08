using CityInfo.API.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API.Services
{
    public class CityInfoRepository : ICityInfoRepository
    {

        private CityInfoContext _context;

        public CityInfoRepository(CityInfoContext context)
        {
            _context = context;
        }

        public void AddPointsOfInterestForCity(int cityId, PointOfInterest pointsOfInterest)
        {
            var city = GetCity(cityId, false);
            city.PointsOfInterest.Add(pointsOfInterest);
        }


        public bool CityExists(int cityId)
        {
            return _context.Cities.Any(c => c.Id == cityId);
        }

        public IEnumerable<City> GetCities()
        {
            return _context.Cities.OrderBy(c => c.Name).ToList();
        }

        public City GetCity(int cityId, bool includePointsOfInterest)
        {
            if (includePointsOfInterest)
            {
                return _context.Cities.Include(c => c.PointsOfInterest)
                        .Where(c => c.Id == cityId).FirstOrDefault();
            }

            return _context.Cities.Where(c => c.Id == cityId).FirstOrDefault();
        }

        public PointOfInterest GetPointsOfInterestForCity(int cityId, int pointsOfInterestId)
        {
            return _context.PointsOfInterest
                    .Where(p => p.CityId == cityId && p.Id == pointsOfInterestId).FirstOrDefault();
        }

        public IEnumerable<PointOfInterest> GetPointsOfInterestForCity(int cityId)
        {
            return _context.PointsOfInterest
                    .Where(p => p.CityId == cityId).ToList();
        }

        void DeletePointOfInterest(PointOfInterest pointOfInterest)
        {
            _context.PointsOfInterest.Remove(pointOfInterest);
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
