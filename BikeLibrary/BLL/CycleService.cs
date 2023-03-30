using BikeClassLibrary.DBL;
using BikeLibrary.DBL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeLibrary.BLL
{
    public class CycleService
    {
        private List<Account> accounts;
        ConStr conn;
        DBAccounts dbaccounts;

        public CycleService()
        {
            conn = new ConStr();
            dbaccounts = new DBAccounts(conn.GetConnectionString());
            accounts = dbaccounts.GetAll();
        }

        public void AddAccount(Account acc)
        {
            dbaccounts.AddAccount(acc);
            SetAccounts();
        }

        public List<Account> GetAccounts()
        {
            return accounts;
        }

        public Account GetAccountByEmail(string email)
        {
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
