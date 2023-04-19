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

        public Order(int id, string status, int accid, List<Item> items)
        {
            Id = id;
            this.status = status;
            this.accid = accid;
            this.items = items; 
        }

        public int GetId()
        {
            return Id;
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
    }
}
