using System.ComponentModel.DataAnnotations;

namespace BikeLibrary.BLL
{
    public class ShippingInfo
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string PostalCode { get; set; }
        public string Address { get; set; }

        public ShippingInfo(string name, string lastName, string postalCode, string address)
        {
            Name = name;
            LastName = lastName;
            PostalCode = postalCode;
            Address = address;
        }
    }
}
