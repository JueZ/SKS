using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SKS_PDS.DAL;

namespace SKS_PDS.Services
{
    public interface IRegionImportService
    {
        private IRegionRepository _regionrepository;
        public IRegionImportService(IRegionRepository regionrepository);
        public void ImportRegion(string s);
    }
}
