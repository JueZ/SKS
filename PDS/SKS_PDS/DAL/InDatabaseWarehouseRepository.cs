using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;

using SKS_PDS.Entities;

namespace SKS_PDS.DAL
{
    public class InDatabaseWarehouseRepository : IWarehouseRepository
    {
        private PDSDatabase _context;

        public InDatabaseWarehouseRepository(PDSDatabase context)
        {
            _context = context;
        }

        public List<Warehouse> getWarehousesByCoordinate(float x, float y)
        {
            var query = from d in _context.Warehouses
                        where d.X == x && d.Y == y
                        select d;

            return query.ToList<Warehouse>();
        }

        public void Add(Warehouse item)
        {
            _context.Warehouses.Add(item);
            _context.SaveChanges();
        }

        public void Update(Warehouse item)
        {
            //Package updateitem = _context.Packages.First(i => i.PackageID == item.PackageID);
            var query = (from d in _context.Warehouses
                         where d.Warehouseid == item.Warehouseid
                         select d).FirstOrDefault();

            query.Warehouseid = item.Warehouseid;
            query.X = item.X;
            query.Y = item.Y;

            //_context.Packages.Attach(item);
            //_context.Entry(item).State = EntityState.Modified;
            //_context.Entry(query).CurrentValues.SetValues(item);
            _context.SaveChanges();
        }

        public void Delete(Warehouse item)
        {
            var query = (from d in _context.Warehouses
                         where d.Warehouseid == item.Warehouseid
                         select d).FirstOrDefault();

            _context.Warehouses.Remove(query);
            _context.SaveChanges();
        }

        public Warehouse GetById(int id)
        {
            var query = (from d in _context.Warehouses
                        where d.Warehouseid == id
                        select d).FirstOrDefault();

            return (Warehouse)query;
        }

        public IEnumerable<Warehouse> GetAll()
        {
            return _context.Warehouses.ToList<Warehouse>();
        }
    }
}
