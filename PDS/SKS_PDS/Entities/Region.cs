using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKS_PDS.Entities
{
    public class Region
    {
        [Key]
        public int RegionID
        {
            get;
            set;
        }
        public string RegionKey
        {
            get;
            set;
        }
        public string DisplayName
        {
            get;
            set;
        }
        public string Street
        {
            get;
            set;
        }
        public string PostalCode
        {
            get;
            set;
        }
        public string City
        {
            get;
            set;
        }
        public double Latitude
        {
            get;
            set;
        }
        public double Longitude
        {
            get;
            set;
        }

        public Region()
        {
        }

        public Region(int regionid, string regionkey, string displayname, string postalcode, string city, double latitude, double longitude)
        {
            RegionID = regionid;
            RegionKey = regionkey;
            DisplayName = displayname;
            PostalCode = postalcode;
            City = city;
            Latitude = latitude;
            Longitude = longitude;
        }

    }
}
