using BikeClassLibrary.DBL;
using BikeLibrary.DBL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeLibrary.BLL
{
    public class AccountService
    {
        private List<Account> accounts;
        private IAccountRepository dbaccounts;

        public AccountService(IAccountRepository _dbaccounts)
        {
            dbaccounts = _dbaccounts;
        }

        public void AddAccount(Account acc)
        {
            if (dbaccounts.GetAccountByEmail(acc.GetEmail()) != null)
            {
                throw new ArgumentException("An account with the same email already exists");
            }
            if (acc.GetPassword().Length < 8)
            {
                throw new ArgumentException("Password must be at least 8 characters long");
            }
            dbaccounts.AddAccount(acc);
        }

        public List<Account> GetAccounts()
        {
            return dbaccounts.GetAll();
        }

        public Account GetAccountByEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                throw new ArgumentException("Invalid email");
            }
            Account account = dbaccounts.GetAccountByEmail(email);
            if (account == null)
            {
                 throw new ArgumentException("Email does not exist");
            }
            return account;
        }

        public void SetShippingInformation(int id, ShippingInfo shippingInfo)
        {
            dbaccounts.SetShippingInformation(id, shippingInfo);
        }

        public Account GetAccountByid(int id)
        {
            return dbaccounts.GetAccountById(id);
        }

        public Account GetShippingInformation(Account acc)
        {
            return dbaccounts.GetShippingInformation(acc);
        }
    }
}
