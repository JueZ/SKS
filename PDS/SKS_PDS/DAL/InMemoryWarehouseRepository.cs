using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SKS_PDS.Entities;

namespace SKS_PDS.DAL
{
    public class InMemoryWarehouseRepository : IWarehouseRepository
    {
        private List<Warehouse> _warehouses;

        public InMemoryWarehouseRepository()
        {
            _warehouses = new List<Warehouse>();
        }

        public List<Warehouse> getWarehousesByCoordinate(float x, float y)
        {
            List<Warehouse> warehouses = new List<Warehouse>();

            foreach (Warehouse warehouse in _warehouses)
            {
                if (warehouse.X == x && warehouse.Y == y)
                {
                    warehouses.Add(warehouse);
                }
            }

            return warehouses;
        }

        public void Add(Warehouse item)
        {
            _warehouses.Add(item);
        }

        public void Update(Warehouse item)
        {
            for (int i = 0; i < _warehouses.Count; i++)
            {
                if (_warehouses[i].Warehouseid == item.Warehouseid)
                {
                    _warehouses[i] = item;
                }
            }
        }

        public void Delete(Warehouse item)
        {
            for (int i = 0; i < _warehouses.Count; i++)
            {
                if (_warehouses[i].Warehouseid == item.Warehouseid)
                {
                    _warehouses.RemoveAt(i);
                }
            }
        }

        public Warehouse GetById(int id)
        {
            foreach (Warehouse warehouse in _warehouses)
            {
                if (warehouse.Warehouseid == id)
                {
                    return warehouse;
                }
            }

            return null;
        }

        public List<Warehouse> GetAll()
        {
            return _warehouses;
        }
    }
}
