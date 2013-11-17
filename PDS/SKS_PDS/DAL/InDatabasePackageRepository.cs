using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;

using log4net;
using log4net.Config;
using SKS_PDS.Entities;
using SKS_PDS;


namespace SKS_PDS.DAL
{
    public class InDatabasePackageRepository : IPackageRepository
    {
        private PDSDatabase _context;
        private readonly ILog logger;

        public InDatabasePackageRepository(PDSDatabase context)
        {
            _context = context;

            logger = LogManager.GetLogger(typeof(InDatabasePackageRepository));
            logger.Debug("Initialisiert");
        }

        public List<Package> getPackageByWarehouseid(int warehouseid)
        {
            logger.Info("Entering GetPackageByWareHouseID");

            try
            {

                var query = from d in _context.Packages
                            where d.Warehouseid == warehouseid
                            select d;

                logger.Info("Exiting GetPackageByWareHouseID");

                return query.ToList<Package>();
            }
            catch (Exception ex)
            {

                throw new RepositoryException("Query failed", ex);
            }
        }

        public void Add(Package item)
        {
            logger.Info("Entering Add");

            _context.Packages.Add(item);
            _context.SaveChanges();

            logger.Info("Exiting Add");
        }

        public void Update(Package item)
        {
            logger.Info("Entering Update");

            //Package updateitem = _context.Packages.First(i => i.PackageID == item.PackageID);
            var query = (from d in _context.Packages
                         where d.PackageID == item.PackageID
                         select d).FirstOrDefault();

            query.Warehouseid = item.Warehouseid;

            //_context.Packages.Attach(item);
            //_context.Entry(item).State = EntityState.Modified;
            //_context.Entry(query).CurrentValues.SetValues(item);
            _context.SaveChanges();

            logger.Info("Exiting Update");
        }

        public void Delete(Package item)
        {
            logger.Info("Entering Delete");

            var query = (from d in _context.Packages
                            where d.PackageID == item.PackageID
                            select d).FirstOrDefault();

            _context.Packages.Remove(query);
            _context.SaveChanges();

            logger.Info("Exiting Delete");
        }

        public Package GetById(int id)
        {
            logger.Info("Entering GetById");

            var query = (from d in _context.Packages
                            where d.PackageID == id
                            select d).FirstOrDefault();

            logger.Info("Exiting GetById");

                return (Package)query;
        }

        public IEnumerable<Package> GetAll()
        {
            logger.Info("Entering GetAll");
            logger.Info("Exiting GetAll");

            return _context.Packages.ToList<Package>();
        }
    }
}
