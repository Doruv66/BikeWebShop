using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeLibrary.BLL
{
    public class OrderItem
    {
        private int orderid;

        private int bikeid;

        private int quantity;

        public OrderItem(int orderid, int bikeid, int quantity)
        {
            this.orderid = orderid;
            this.bikeid = bikeid;
            this.quantity = quantity;
        }
    }
}
