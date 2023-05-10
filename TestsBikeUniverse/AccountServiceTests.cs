using BikeLibrary.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestsBikeUniverse.MockData;

namespace TestsBikeUniverse
{
    [TestClass]
    public class AccountServiceTests
    {

        [TestMethod]
        public void AddAccount_ValidAccountData_AddsNewAccount()
        {
            // Arrange
            AccountService accountService = GetMockService();
            var account = new Account(1, new byte[8], new byte[4], "test@example.com");

            // Act
            accountService.AddAccount(account);
            Account result = accountService.GetAccountByid(account.GetId());

            // Assert
            Assert.AreEqual(result, account);
            
        }

        [TestMethod]
        public void AddAccount_DuplicateEmail_ThrowsArgumentException()
        {
            // Arrange
            AccountService accountService = GetMockService();
            var account1 = new Account(1, new byte[8], new byte[4], "test@example.com");
            var account2 = new Account(2, new byte[8], new byte[4], "test@example.com");

            // Act 
            accountService.AddAccount(account1);
            // Assert
            Assert.ThrowsException<ArgumentException>(() => accountService.AddAccount(account2));
        }

        [TestMethod]
        public void AddAccount_WeakPassword_ThrowsArgumentException()
        {
            // Arrange
            AccountService accountService= GetMockService();
            var account = new Account(1, new byte[5], new byte[4], "test@example.com");
            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => accountService.AddAccount(account));
        }

        [TestMethod]
        public void GetAccounts_ReturnsListOfAccounts()
        {
            // Arrange
            AccountService accountService = GetMockService();
            var accounts = new List<Account>() {
            new Account(1, new byte[8], new byte[4], "test1@example.com"),
            new Account(2, new byte[8], new byte[4], "test2@example.com"),
            new Account(3, new byte[8], new byte[4], "test3@example.com")
            };
            // Act
            foreach(var account in accounts)
            {
                accountService.AddAccount(account);
            }
            var result = accountService.GetAccounts();

            // Assert
            CollectionAssert.AreEqual(accounts, result);
        }

        [TestMethod]
        public void GetAccountByEmail_ReturnsAccountWithMatchingEmail()
        {
            // Arrange
            AccountService accountService = GetMockService();
            var account = new Account(1, new byte[8], new byte[4], "test@example.com");

            // Act
            accountService.AddAccount(account);
            var result = accountService.GetAccountByEmail(account.GetEmail());

            // Assert
            Assert.AreEqual(account, result);
        }

        [TestMethod]
        [DataRow("test1@example.com")]
        [DataRow("")]
        public void GetAccountByEmail_NonExistingEmail_ShouldThrowArgumentException(string email)
        {
            //Arrange
            AccountService accountService = GetMockService();
            var account = new Account(1, new byte[8], new byte[4], "test@example.com");

            //Act
            accountService.AddAccount(account);
            
            //Assert
            Assert.ThrowsException<ArgumentException>(() => accountService.GetAccountByEmail(email));


        }

        [TestMethod]
        public void GetAccountById_ReturnsAccountWithMatchingId()
        {
            // Arrange
            AccountService accountService = GetMockService();
            var account = new Account(1, new byte[8], new byte[4], "test@example.com");

            // Act
            accountService.AddAccount(account);
            var result = accountService.GetAccountByid(account.GetId());

            // Assert
            Assert.AreEqual(account, result);
        }

        public AccountService GetMockService()
        {
            return new AccountService(new MockAccounts());
        }
    }
}
