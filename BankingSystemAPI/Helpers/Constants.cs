using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankingSystemAPI
{
    public static class Constants
    {
        public static readonly int MinBalance = 100;
        public static readonly int MaxWithdrawPercent = 90;
        public static readonly int PercentCalculation = 100;
        public static readonly int MaxDepositValue = 10000;
        public static readonly int MaxDecimalPlaces = 2;
        public static readonly int UserNotFound = -1;
        public static readonly int AccountNotFound = 0;
    }
}
