using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankingSystemAPI
{
    public static class ErrorMessages
    {
        public static readonly string Exceed = "Deposit cannot exceed $10,000";
        public static readonly string Insufficient = "Account balance cannot be below $100";
        public static readonly string PercentExceed = "Withdrawal cannot exceed 90% of total account balance";
        public static readonly string AccountNotFound = "Account not found";
        public static readonly string UserNotFound = "User not found";
        public static readonly string InvalidCurrency = "Invalid currencty format";
    }
}
