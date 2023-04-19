using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeLibrary.BLL
{
    public class Account
    {
        public int id { get; private set; }

        public byte[] password { get; private set; }

        public byte[] salt { get; private set; }

        public string email { get; private set; }

        private ShippingInfo shipping { get; set; } 


        public Account(int id, byte[] password, byte[] salt, string email)
        {
            this.id = id;
            this.password = password;
            this.salt = salt;
            this.email = email;
        }


        public void SetShippingInfo(ShippingInfo shipping)
        {
            this.shipping = shipping;
        }

        public ShippingInfo GetShippingInfo()
        {
            return shipping;
        }

        
    }
}
