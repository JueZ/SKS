using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using SKS_PDS.Business;


namespace SKS_PackageService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "DeliveryService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select DeliveryService.svc or DeliveryService.svc.cs at the Solution Explorer and start debugging.
    public class DeliveryService : IDeliveryService
    {
        public Package[] GetPackagesForRegion(string regionKey)
        {
            DataControllLayer datacontrollayer = new DataControllLayer();

            SKS_PDS.Entities.Package[] packagearray = datacontrollayer.GetPackagesForRegion(regionKey);

            List<Package> packagelist = new List<Package>();

            foreach (SKS_PDS.Entities.Package package in packagearray)
            {
                Package tmppackage = new Package();
                tmppackage.Id = package.PackageID;
                tmppackage.Address.City = package.City;
                tmppackage.Address.Country = package.Country;
                tmppackage.Address.PostalCode = package.Postalcode;
                tmppackage.Address.Street = package.Street;

                packagelist.Add(tmppackage);
            }

            return packagelist.ToArray();
        }
    }
}
