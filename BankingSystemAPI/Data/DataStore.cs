using BankingSystemAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankingSystemAPI.Data
{
    public sealed class DataStore
    {
        private readonly List<User> _users = null;
        private int _index;
        private static readonly object Instancelock = new object();
        private DataStore()
        {

            var users = new List<User>
            {
                new User(1),
                new User(2)
            };

            _users = users;
            _index = 3;
        }
        private static DataStore instance = null;
        public static DataStore GetInstance
        {
            get
            {
                if (instance == null)
                {
                    lock (Instancelock)
                    {
                        if (instance == null)
                        {
                            instance = new DataStore();
                        }
                    }
                }
                return instance;
            }
        }

        public void CreateUser()
        {
            _users.Add(new User(_index++));
        }

        public bool CreateAccount(int userID, decimal amount)
        {
            var user = GetUserById(userID);

            if (user == null)
                return false;

            user.Accounts.Add(new Account(amount));

            return true;
        }

        public int DeleteAccount(int userID, string accountID)
        {
            var user = GetUserById(userID);

            if (user == null)
                return -1;

            var result = user.Accounts.RemoveAll(a => a.AccountID.Equals(accountID));
            return result;
        }

        public decimal GetAccountBalance(int userID, string accountID)
        {
            var user = GetUserById(userID);

            foreach (var account in user.Accounts)
            {
                if (account.AccountID.Equals(accountID))
                {
                    return account.Balance;
                }
            }
            return 0;
        }

        public bool Deposit(Transaction transaction)
        {
            var user = GetUserById(transaction.UserID);

            foreach (var account in user.Accounts)
            {
                if (account.AccountID.Equals(transaction.AccountID))
                {
                    account.Balance += transaction.Amount;
                    return true;
                }
            }
            return false;
        }

        public bool Withdraw(Transaction transaction)
        {
            var user = GetUserById(transaction.UserID);

            foreach (var account in user.Accounts)
            {
                if (account.AccountID.Equals(transaction.AccountID))
                {
                    var newBalance = account.Balance - transaction.Amount;
                    account.Balance = newBalance;
                    return true;
                }
            }
            return false;
        }

        public User GetUserById(int id)
        {
            foreach (var user in _users)
            {
                if (user.UserID == id)
                    return user;
            }

            return null;
        }
        public IEnumerable<User> GetUsers()
        {
            return _users;
        }
    }
}
