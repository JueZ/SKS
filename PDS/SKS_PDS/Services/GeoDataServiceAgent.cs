using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;
using System.Xml;

namespace SKS_PDS.Services
{
    public class GeoDataServiceAgent : IGeoDataServiceAgent
    {
        // Durch App.config Eintrag ersetzen.
        private const string BingMapsKey = "AmlwOwKf2YW-Qw6-Nq8AqFvZUaeD7V1KYtcBFXe999kxL8zkmSw0i52RdV62kd6k";

        public double[] EncodeCoordinates(string postalcode, string city, string street)
        {
            string UrlRequest = "http://dev.virtualearth.net/REST/v1/Locations?countryRegion=AT" +
                                           "&locality=" + WebUtility.UrlEncode(city) +
                                           "&postalCode=" + postalcode +
                                           "&addressLine=" + street +
                                           "&includeNeighborhood=0&maxResults=1&o=xml" +
                                           " &key=" + BingMapsKey;

            XmlDocument xmlDoc = null;

            try
            {
                HttpWebRequest request = WebRequest.Create(UrlRequest) as HttpWebRequest;
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;

                xmlDoc = new XmlDocument();
                xmlDoc.Load(response.GetResponseStream());
            }
            catch (Exception ex)
            {
                throw new ServiceException("Coordinate request failed!", ex);
            }

            XmlNamespaceManager nsmgr = new XmlNamespaceManager(xmlDoc.NameTable);
            nsmgr.AddNamespace("rest", "http://schemas.microsoft.com/search/local/ws/rest/v1");

            XmlNode locationElement = xmlDoc.SelectSingleNode("//rest:Point", nsmgr);

            return new double[] { Convert.ToDouble(locationElement.SelectSingleNode(".//rest:Latitude", nsmgr).InnerText.Replace('.', ',')), Convert.ToDouble(locationElement.SelectSingleNode(".//rest:Longitude", nsmgr).InnerText.Replace('.', ',')) };
        }
    }
}
