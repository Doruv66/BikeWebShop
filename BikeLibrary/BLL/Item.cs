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
        private Bike bike;

        private int quantity;

        public Item(Bike bike, int quantity)
        {
            this.bike = bike;
            this.quantity = quantity;
        }

        public double GetTotalPrice()
        {
            return bike.GetPrice()*quantity;
        }
    }
}
