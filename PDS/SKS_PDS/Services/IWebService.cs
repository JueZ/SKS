using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Web;
using System.Text;

namespace SKS_PDS.Services
{
    [ServiceContract]
    public interface IWebService
    {
        [OperationContract]
        [XmlSerializerFormat]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Xml, ResponseFormat = WebMessageFormat.Xml, BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "saveregions")]
        bool SaveRegions(RegionData regionData);
    }
}