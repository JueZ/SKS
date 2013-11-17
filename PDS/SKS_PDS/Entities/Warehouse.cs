using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKS_PDS.Entities
{
    public class Warehouse
    {
        private int _warehouseid;
        private float _x;
        private float _y;

        public int Warehouseid
        {
            get { return _warehouseid; }
            set { _warehouseid = value; }
        }

        public float X
        {
            get { return _x; }
            set { _x = value; }
        }

        public float Y
        {
            get { return _y; }
            set { _y = value; }
        }

        public Warehouse(int warehouseid, float x, float y)
        {
            this._warehouseid = warehouseid;
            this._x = x;
            this._y = y;
        }
    }
}
