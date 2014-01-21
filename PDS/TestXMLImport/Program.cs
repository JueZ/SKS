using SKS_PDS.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestXMLImport
{
    class Program
    {
        static void Main(string[] args)
        {
            //arrange
            ServiceController servicecontroller = new ServiceController();
            servicecontroller.StartService();

            Console.ReadKey();
            //act

            //assert

        }
    }
}
