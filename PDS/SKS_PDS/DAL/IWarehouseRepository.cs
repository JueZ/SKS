using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SKS_PDS.Entities;

namespace SKS_PDS.DAL
{
    public interface IWarehouseRepository : IRepository<Warehouse>
    {
        List<Warehouse> getWarehousesByCoordinate(float x, float y);
    }
}
