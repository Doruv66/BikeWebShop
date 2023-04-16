using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeLibrary.BLL.Interfaces
{
    public interface IAccountService
    {
        void AddAccount(Account acc);

        List<Account> GetAccounts();

        Account GetAccountByEmail(string email);

    }
}
