using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SKS_PDS.Services;
using SKS_PDS.Entities;

namespace SKS_PDS.DAL
{
    public class SortPackage : ISortPackage
    {
        private IRegionRepository _regionrepository = new InDatabaseRegionRepository(new PDSDatabase());

        public int GetClosestRegionId(string postalcode, string city, string street)
        {
            GeoDataServiceAgent geodataserviceagent = new GeoDataServiceAgent();

            double[] coord = geodataserviceagent.EncodeCoordinates(postalcode, city, street);

            var regionarray = _regionrepository.GetAll();

            int regionid = 0;
            double smallestdistance = 1000000000;

            foreach (Region region in regionarray)
            {
                if (CalculateDistance(region.Latitude, region.Longitude, coord[0], coord[1]) < smallestdistance)
                {
                    smallestdistance = CalculateDistance(region.Latitude, region.Longitude, coord[0], coord[1]);

                    regionid = region.RegionID;
                }
            }

            return regionid;
        }

        public double CalculateDistance(double lat1, double long1, double lat2, double long2)
        {
            var radius = 6371; 

           
            return Math.Acos(Math.Sin(DegreeToRadian(lat1)) * Math.Sin(DegreeToRadian(lat2)) +
                              Math.Cos(DegreeToRadian(lat1)) * Math.Cos(DegreeToRadian(lat2)) *
                              Math.Cos(DegreeToRadian(long2) - DegreeToRadian(long1))) * radius;
        }

        private double DegreeToRadian(double angle)
        {
            return Math.PI * angle / 180.0;
        }
    }
}
