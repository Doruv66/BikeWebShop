using BikeClassLibrary;
using BikeLibrary.DBL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeLibrary.BLL
{
    public class Order
    {
        private int Id;

        private string status;

        private int accid;

        private List<Item> items;

        private DateTime date;

        private ShippingInfo shipping;

        public Order(int id, string status, int accid, List<Item> items, DateTime date)
        {
            Id = id;
            this.status = status;
            this.accid = accid;
            this.items = items;
            this.date = date;
        }

        public Order(int id, string status, int accid, List<Item> items, DateTime date, ShippingInfo shipping) : this(id, status, accid, items, date)
        {
            this.shipping = shipping;
        }

        public ShippingInfo GetShipping()
        {
            return shipping;
        }
        public int GetId()
        {
            return Id;
        }

        public DateTime GetOrderDate()
        {
            return date;
        }

        public string GetStatus()
        {
            return status;
        }

        public int GetAccid()
        {
            return accid;
        }

        public List<Item> GetItems()
        {
            return items;
        }

        public void AddItem(Item item)
        {
            items.Add(item);
        }

        public void ChangeStatus(string newstatus)
        {
            status = newstatus;
        }

        public double GetTotalPrice(Inventory inventory)
        {
            return Convert.ToDouble(items.Sum(i => inventory.GetBike(i.bikeid).GetPrice()));
        }
    }
}
