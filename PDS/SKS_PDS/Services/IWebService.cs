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
        //[OperationContract]
        //[WebGet]
        //string SaveRegions(string s);

        [OperationContract]
        [WebInvoke]
        string SaveRegions(string s);
    }
}