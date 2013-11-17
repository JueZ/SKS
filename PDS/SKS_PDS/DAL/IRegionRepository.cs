using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SKS_PDS.Entities;

namespace SKS_PDS.DAL
{
    public interface IRegionRepository : IRepository<Region>
    {
        List<Region> GetRegionByKey(string regionkey);
    }
}
