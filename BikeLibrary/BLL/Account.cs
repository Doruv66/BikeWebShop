using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeLibrary.BLL
{
    public class Account
    {
        private string username;

        private string password;

        private string email;

        private string phone;

        private string address;

        private shoppingCart shoppingCart;

        public Account(string username, string password, string email, string phone, string address)
        {
            this.username = username;
            this.password = password;
            this.email = email;
            this.phone = phone;
            this.address = address;
            this.shoppingCart = new shoppingCart();
        }

        public bool login()
        {
            throw new NotImplementedException();
        }

        public bool logout()
        {
            throw new NotImplementedException();
        }

        
    }
}
