using BankingSystemAPI.Data;
using BankingSystemAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankingSystemAPI.Services
{
    public class BankingSystemService
    {
        private readonly IBankingSystemRepo _repository;
        public BankingSystemService(IBankingSystemRepo repository)
        {
            _repository = repository;
        }

        public void CreateUser()
        {
            _repository.CreateUser();
        }

        public void CreateAccount(int userID, decimal amount)
        {
            ValidateAmount(amount);
            var result =  _repository.CreateAccount(userID, amount);

            if (!result)
                throw new Exception(ErrorMessages.UserNotFound);
        }

        public void DeleteAccount(int userID, string accountID)
        {
            var result = _repository.DeleteAccount(userID, accountID);

            if (result == Constants.UserNotFound)
                throw new Exception(ErrorMessages.UserNotFound);
            if (result == Constants.AccountNotFound)
                throw new Exception(ErrorMessages.AccountNotFound);
        }

        public void Deposit(Transaction transaction)
        {
            ValidateAmount(transaction.Amount);

            if (transaction.Amount > Constants.MaxDepositValue)
                throw new Exception(ErrorMessages.Exceed);

            var result = _repository.Deposit(transaction);

            if (!result)
                throw new Exception(ErrorMessages.AccountNotFound);
        }

        public void Withdraw(Transaction transaction)
        {
            ValidateAmount(transaction.Amount);

            var currentBalance = _repository.GetAccountBalance(transaction.UserID, transaction.AccountID);
            var newBalance = currentBalance - transaction.Amount;

            if (newBalance < Constants.MinBalance)
                throw new Exception(ErrorMessages.Insufficient);

            int withdrawalPercent = (int)Math.Round((double)(Constants.PercentCalculation * Decimal.Divide(transaction.Amount, currentBalance)));

            if (withdrawalPercent > Constants.MaxWithdrawPercent)
                throw new Exception(ErrorMessages.PercentExceed);

            var result = _repository.Withdraw(transaction);

            if (!result)
                throw new Exception(ErrorMessages.AccountNotFound);
        }

        public User GetUserById(int userID)
        {
            return _repository.GetUserById(userID);
        }
        public List<User> GetUsers()
        {
            return _repository.GetUsers().ToList();
        }

        private void ValidateAmount(decimal amount)
        {
            if (decimal.Round(amount, Constants.MaxDecimalPlaces) != amount)
                throw new Exception(ErrorMessages.InvalidCurrency);
        }
    }
}
