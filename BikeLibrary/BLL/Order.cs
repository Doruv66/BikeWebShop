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

        private string FirstName;

        private string LastName;

        private string Addrress;

        private string PostalCode;

        private string status;

        private int accid;

        private List<Item> items;

        public Order(int id, string firstName, string lastName, string addrress, string postalCode, string status, int accid, List<Item> items)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Addrress = addrress;
            PostalCode = postalCode;
            this.status = status;
            this.accid = accid;
            this.items = items; 
        }

        public int GetId()
        {
            return Id;
        }

        public string GetFirstName()
        {
            return FirstName;
        }

        public string GetLastName()
        {
            return LastName;
        }

        public string GetAddrress()
        {
            return Addrress;
        }

        public string GetPostalCode()
        {
            return PostalCode;
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
