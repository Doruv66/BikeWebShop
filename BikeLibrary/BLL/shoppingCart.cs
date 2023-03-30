using BikeClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeLibrary.BLL
{
    public class shoppingCart
    {
        private List<Item> items;

        private double toatalPrice;

        public shoppingCart()
        {
            items= new List<Item>();
            toatalPrice= 0;
        }

        public void AddItem(Item item)
        {
            items.Add(item);
        }

        public void RemoveItem(Item item)
        {
            items.Remove(item);
        }

        public List<Item> GetAllItems()
        {
            return items;
        }

        public double GetTotalPrice()
        {
            return toatalPrice;
        }
    }
}
