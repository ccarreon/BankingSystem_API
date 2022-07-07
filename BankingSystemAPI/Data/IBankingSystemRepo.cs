using BankingSystemAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankingSystemAPI.Data
{
    public interface IBankingSystemRepo
    {
        void CreateUser();
        bool CreateAccount(int userID, decimal amount);
        int DeleteAccount(int userID, string accountID);
        decimal GetAccountBalance(int userID, string accountID);
        bool Deposit(Transaction transaction);
        bool Withdraw(Transaction transaction);
        User GetUserById(int id);
        IEnumerable<User> GetUsers();
    }
}
