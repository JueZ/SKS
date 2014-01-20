using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SKS_PDS.Entities;

namespace SKS_PDS.DAL
{
    public class InMemoryPackageRepository : IPackageRepository
    {
        private List<Package> _packages;

        public InMemoryPackageRepository()
        {
            _packages = new List<Package>();
        }

        public List<Entities.Package> getPackageByWarehouseid(int warehouseid)
        {
            List<Package> packages = new List<Package>();

            foreach (Package package in _packages)
            {
                if (package.Regionid == warehouseid)
                {
                    packages.Add(package);
                }
            }

            return packages;
        }

        public void Add(Entities.Package item)
        {
            _packages.Add(item);
        }

        public void Update(Entities.Package item)
        {
            for (int i = 0; i < _packages.Count; i++)
            {
                if (_packages[i].PackageID == item.PackageID)
                {
                    _packages[i] = item;
                }
            }
        }

        public void Delete(Entities.Package item)
        {
            for (int i = 0; i < _packages.Count; i++)
            {
                if (_packages[i].PackageID == item.PackageID)
                {
                    _packages.RemoveAt(i);
                }
            }
        }

        public Entities.Package GetById(int id)
        {
            foreach (Package package in _packages)
            {
                if (package.PackageID == id)
                {
                    return package;
                }
            }

            return null;
        }

        public IEnumerable<Entities.Package> GetAll()
        {
            return _packages;
        }
    }
}
