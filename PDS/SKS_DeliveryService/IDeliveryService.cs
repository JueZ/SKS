using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SKS_PackageService
{
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace = "http://sksPackage.org/2013/DeliveryService", ConfigurationName = "SKS_PackageService.DeliveryService")]
    public interface IDeliveryService
    {

        [System.ServiceModel.OperationContractAttribute(Action = "http://sksPackage.org/2013/DeliveryService/GetPackagesForRegion", ReplyAction = "http://sksPackage.org/2013/DeliveryService/GetPackagesForRegionResponse")]
        SKS_PackageService.Package[] GetPackagesForRegion(string regionKey);
    }
}
