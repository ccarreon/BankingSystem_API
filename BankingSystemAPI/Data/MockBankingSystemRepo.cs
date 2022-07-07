using BankingSystemAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankingSystemAPI.Data
{
    public class MockBankingSystemRepo : IBankingSystemRepo
    {
        private readonly DataStore _dataStore = DataStore.GetInstance;
        public MockBankingSystemRepo() { }
        
        public void CreateUser()
        {
            _dataStore.CreateUser();
        }

        public bool CreateAccount(int userID, decimal amount)
        {
            return _dataStore.CreateAccount(userID, amount);
        }
        public int DeleteAccount(int userID, string accountID)
        {
            return _dataStore.DeleteAccount(userID, accountID);
        }

        public decimal GetAccountBalance(int userID, string accountID)
        {
            return _dataStore.GetAccountBalance(userID, accountID);
        }

        public bool Deposit(Transaction transaction)
        {
            return _dataStore.Deposit(transaction);
        }

        public bool Withdraw(Transaction transaction)
        {
            return _dataStore.Withdraw(transaction);
        }

        public User GetUserById(int id)
        {
            return _dataStore.GetUserById(id);
        }

        public IEnumerable<User> GetUsers()
        {
            return _dataStore.GetUsers();
        }
    }
}
