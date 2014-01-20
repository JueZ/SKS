using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SKS_PDS.DAL;
using SKS_PDS.Entities;

namespace SKS_PDS.Business
{
    public class DataControllLayer
    {
        private IRegionRepository regionrepository;
        private IPackageRepository packagerepository;

        public DataControllLayer()
        {
            this.regionrepository = new InDatabaseRegionRepository(new PDSDatabase());
            this.packagerepository = new InDatabasePackageRepository(new PDSDatabase());
        }

        public DataControllLayer(IRegionRepository regionrepository, IPackageRepository packagerepository)
        {
            this.regionrepository = regionrepository;
            this.packagerepository = packagerepository;
        }

        public Package[] GetPackagesForRegion(string region)
        {
            var regionlist = regionrepository.GetRegionByKey(region);

            List<Package> packagelist = new List<Package>();

            foreach (Region reg in regionlist)
            {
                var tmppackagelist = packagerepository.getPackageByWarehouseid(reg.RegionID);

                packagelist.AddRange(tmppackagelist);
            }

            return packagelist.ToArray();
        }

        public void AddPackage(Package package)
        {
            packagerepository.Add(package);
        }
    }
}
