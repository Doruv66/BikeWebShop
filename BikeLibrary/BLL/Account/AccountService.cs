using BikeClassLibrary.DBL;
using BikeLibrary.BLL.Interfaces;
using BikeLibrary.DBL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeLibrary.BLL
{
    public class AccountService : IAccountService
    {
        private List<Account> accounts;
        IAccountRepository dbaccounts;

        public AccountService(IAccountRepository _dbaccounts)
        {
            dbaccounts = _dbaccounts;
        }

        public void AddAccount(Account acc)
        {
            dbaccounts.AddAccount(acc);
        }

        public List<Account> GetAccounts()
        {
            return dbaccounts.GetAll();
        }

        public Account GetAccountByEmail(string email)
        {
            return dbaccounts.GetAccountByEmail(email);
        }

        public void SetShippingInformation(Account acc)
        {
            dbaccounts.SetShippingInformation(acc);
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
