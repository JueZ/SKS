using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKS_PDS.Services
{
    public interface IGeoDataServiceAgent
    {
        double[] EncodeCoordinates(string postalcode, string city, string street);
    }
}
