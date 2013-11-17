using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;

using SKS_PDS.Entities;

namespace SKS_PDS.DAL
{
    public class PDSDatabase : DbContext
    {
        public virtual DbSet<Package> Packages { get; set; }
        public virtual DbSet<Warehouse> Warehouses { get; set; }
        public virtual DbSet<Region> Regions { get; set; }
    }
}
