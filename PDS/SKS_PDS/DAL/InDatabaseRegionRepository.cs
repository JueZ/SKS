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
    public class InDatabaseRegionRepository : IRegionRepository
    {
        private PDSDatabase _context;
        private readonly ILog logger;

        public InDatabaseRegionRepository(PDSDatabase context)
        {
            _context = context;

            logger = LogManager.GetLogger(typeof(InDatabaseRegionRepository));
            logger.Debug("Initialisiert");
        }

        public List<Region> GetRegionByKey(string regionkey)
        {
            logger.Info("Entering GetRegionByKey");

            try
            {
                var query = from d in _context.Regions
                            where d.RegionKey == regionkey
                            select d;

                logger.Info("Exiting GetRegionByKey");

                return query.ToList<Region>();
            }
            catch (Exception ex)
            {
                logger.Error("Error GetRegionByKey", ex);
                throw new RepositoryException("Query failed", ex);
            }
        }

        public void Add(Region item)
        {
            _context.Regions.Add(item);
            _context.SaveChanges();
        }

        public void Update(Region item)
        {
            var query = (from d in _context.Regions
                         where d.RegionID == item.RegionID
                         select d).FirstOrDefault();

            //query.RegionID = item.RegionID;
            query.City = item.City;
            query.DisplayName = item.DisplayName;
            query.PostalCode = item.PostalCode;
            query.RegionKey = item.RegionKey;
            query.Street = item.Street;
            query.Latitude = item.Latitude;
            query.Longitude = item.Longitude;
       
            _context.SaveChanges();
        }

        public void Delete(Region item)
        {
            var query = (from d in _context.Regions
                         where d.RegionID == item.RegionID
                         select d).FirstOrDefault();

            _context.Regions.Remove(query);
            _context.SaveChanges();
        }

        public Region GetById(int id)
        {
            logger.Info("Entering GetById");

            var query = (from d in _context.Regions
                         where d.RegionID == id
                         select d).FirstOrDefault();

            logger.Info("Exiting GetById");

            return (Region)query;
        }

        public IEnumerable<Region> GetAll()
        {
            logger.Info("Entering GetAll");
            logger.Info("Exiting GetAll");

            return _context.Regions.ToList<Region>();
        }
    }
}
