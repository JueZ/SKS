using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKS_PDS.DAL
{
    public interface ISortPackage
    {
        int GetClosestRegionId(string postalcode, string city, string street);
    }
}
