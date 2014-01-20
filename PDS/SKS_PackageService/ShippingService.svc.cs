using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

using SKS_PDS.Business;

namespace SKS_PackageService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class ShippingService : IShippingService
    {
        public void AddPackage(Package package)
        {
            SKS_PDS.DAL.SortPackage sortpackage = new SKS_PDS.DAL.SortPackage();

            SKS_PDS.Entities.Package importpackage = new SKS_PDS.Entities.Package(package.Id, " ", " ", " ", " ", sortpackage.GetClosestRegionId(package.Address.PostalCode, package.Address.City, package.Address.Street), package.Address.City, package.Address.Country, package.Address.PostalCode, package.Address.Street);

            DataControllLayer datacontrolllayer = new DataControllLayer();
            datacontrolllayer.AddPackage(importpackage);
            
        }
    }
}
