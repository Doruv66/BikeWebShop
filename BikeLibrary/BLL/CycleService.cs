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

        public CycleService()
        {
            accounts = new List<Account>();
        }

        public void AddAccount(Account acc)
        {
            accounts.Add(acc);
        }

        public void RemoveAccount(Account acc)
        {
            accounts.Remove(acc);
        }

        public List<Account> GetAccounts()
        {
            return accounts;
        }
    }
}
