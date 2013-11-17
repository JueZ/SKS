using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Web;
using System.Text;

namespace SKS_PDS.Services
{
    public class ServiceController
    {
        private WebServiceHost _host;

        public ServiceController()
        {
            _host = new WebServiceHost(typeof(WebService), new Uri("http://localhost:8000/"));
            ServiceEndpoint ep = _host.AddServiceEndpoint(typeof(IWebService), new WebHttpBinding(), "");

            ServiceDebugBehavior sdb = _host.Description.Behaviors.Find<ServiceDebugBehavior>();
            sdb.HttpHelpPageEnabled = false;
        }

        public void StartService()
        {
            _host.Open();
        }

        public void StopService()
        {
            _host.Close();
        }
    }
}
