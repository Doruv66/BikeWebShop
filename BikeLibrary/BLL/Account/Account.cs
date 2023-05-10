using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeLibrary.BLL
{
    public class Account
    {
        private int id;

        private byte[] password;

        private byte[] salt;

        private string email;

        private ShippingInfo shipping;


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

        public int GetId()
        {
            return id;
        }
        
        public byte[] GetPassword()
        {
            return password;
        }

        public byte[] GetSalt()
        {
            return salt;
        }

        public string GetEmail()
        {
            return email;
        }
    }
}
