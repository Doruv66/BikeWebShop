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
            SetAccounts();
        }

        public List<Account> GetAccounts()
        {
            return dbaccounts.GetAll();
        }

        public Account GetAccountByEmail(string email)
        {
            SetAccounts();
            foreach(var account in accounts)
            {
                if(account.email == email)
                    return account;
            }
            return null;
        }

        private void SetAccounts()
        {
            accounts = dbaccounts.GetAll();
        }
    }
}
