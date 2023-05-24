using BikeLibrary.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestsBikeUniverse.MockData
{
    public class MockAccounts : IAccountRepository
    {
        private List<Account> accounts;

        public MockAccounts()
        {
            accounts = new List<Account>();
        }
        public void AddAccount(Account account)
        {
            accounts.Add(account);
        }

        public Account GetAccountByEmail(string email)
        {
            return accounts.FirstOrDefault(a => a.GetEmail() == email);
        }

        public Account GetAccountById(int id)
        {
            return accounts.FirstOrDefault(a => a.GetId() == id);
        }

        public List<Account> GetAll()
        {
            return accounts;
        }

        public Account GetShippingInformation(Account acc)
        {
            return acc;
        }

        public void SetShippingInformation(int id, ShippingInfo shippingInfo)
        {
            Account account = accounts.Find(account => account.GetId() == id);
            account.SetShippingInfo(shippingInfo);
        }
    }
}
