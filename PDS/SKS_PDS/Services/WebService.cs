using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SKS_PDS.DAL;

namespace SKS_PDS.Services
{
    public class WebService : IWebService
    {
        private RegionImportService _regionimportservice = new RegionImportService(new InDatabaseRegionRepository(new PDSDatabase()));

        public string SaveRegions(string s)
        {
            _regionimportservice.ImportRegion(s);

            return s;
        }
    }
}
