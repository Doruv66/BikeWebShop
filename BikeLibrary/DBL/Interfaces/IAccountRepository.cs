using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeLibrary.BLL
{
    public interface IAccountRepository
    {
        void AddAccount(Account account);

        List<Account> GetAll();

        Account GetAccountById(int id);


        Account GetAccountByEmail(string email);


        void SetShippingInformation(int id, ShippingInfo shippingInfo);

        Account GetShippingInformation(Account acc);
    }
}
