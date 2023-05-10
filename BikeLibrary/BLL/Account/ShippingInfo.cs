using System.ComponentModel.DataAnnotations;

namespace BikeLibrary.BLL
{
    public class ShippingInfo
    {
        private int id;
        private string Name;
        private string LastName;
        private string PostalCode;
        private string Addrress;

        public ShippingInfo(string name, string lastName, string postalCode, string addrress)
        {
            Name = name;
            LastName = lastName;
            PostalCode = postalCode;
            Addrress = addrress;
        }

        public ShippingInfo(int id, string name, string lastName, string postalCode, string addrress)
        {
            this.id = id;
            Name = name;
            LastName = lastName;
            PostalCode = postalCode;
            Addrress = addrress;
        }

        public string GetName()
        {
            return Name;
        }

        public int GetId()
        {
            return id;
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
    }
}
