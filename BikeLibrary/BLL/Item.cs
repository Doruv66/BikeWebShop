using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikeClassLibrary;

namespace BikeLibrary.BLL
{
    public class Item
    {
        public int bikeid { get; set; }

        public int quantity { get; set; }

        public Item(int bikeid, int quantity)
        {
            this.bikeid = bikeid;
            this.quantity = quantity;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
