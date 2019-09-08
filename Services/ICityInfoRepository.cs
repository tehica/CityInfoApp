using CityInfo.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API.Services
{
    public interface ICityInfoRepository
    {
        bool CityExists(int cityId);

        IEnumerable<City> GetCities();
        City GetCity(int cityId, bool includePointsOfInterest);
        IEnumerable<PointOfInterest> GetPointsOfInterestForCity(int cityId);
        PointOfInterest GetPointsOfInterestForCity(int cityId, int pointOfInterestId);

        void AddPointsOfInterestForCity(int cityId, PointOfInterest pointsOfInterest);
        void DeletePointOfInterest(PointOfInterest pointOfInterest);
        bool Save();
    }
}
