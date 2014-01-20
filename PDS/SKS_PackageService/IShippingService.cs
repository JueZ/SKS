using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

using SKS_PackageService;

namespace SKS_PackageService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace = "http://sksPackage.org/2013/ShippingService", ConfigurationName = "SKS_PackageService.IShippingService")]
    public interface IShippingService
    {
        [System.ServiceModel.OperationContractAttribute(Action = "http://sksPackage.org/2013/ShippingService/AddPackage", ReplyAction = "http://sksPackage.org/2013/ShippingService/AddPackageResponse")]
        void AddPackage(SKS_PackageService.Package package);


        // TODO: Add your service operations here
    }


   
}
