using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKS_PDS.Entities
{
    public class Region
    {
        private int _regionid;
        private string _regionkey;
        private string _displayname;
        private string _street;
        private string _postalcode;
        private string _city;
        private double _latitude;
        private double _longitude;

        public int RegionID
        {
            get { return _regionid; }
        }
        public string RegionKey
        {
            get { return _regionkey; }
            set { _regionkey = value; }
        }
        public string DisplayName
        {
            get { return _displayname; }
            set { _displayname = value; }
        }
        public string Street
        {
            get { return _street; }
            set { _street = value; }
        }
        public string PostalCode
        {
            get { return _postalcode; }
            set { _postalcode = value;  }
        }
        public string City
        {
            get { return _city; }
            set { _city = value; }
        }
        public double Latitude
        {
            get { return _latitude; }
            set { _latitude = value; }
        }
        public double Longitude
        {
            get { return _longitude; }
            set { _longitude = value; }
        }

        public Region(int regionid, string regionkey, string displayname, string postalcode, string city, double latitude, double longitude)
        {
            this._regionid = regionid;
            this._regionkey = regionkey;
            this._displayname = displayname;
            this._postalcode = postalcode;
            this._city = city;
            this._latitude = latitude;
            this._longitude = longitude;
        }

    }
}
