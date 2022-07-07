using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankingSystemAPI.Models
{
    public class Account
    {
        public Account()
        {
            AccountID = Guid.NewGuid().ToString();
            Balance = 0.00m;
        }
        public Account(decimal amount)
        {
            AccountID = Guid.NewGuid().ToString();
            Balance = amount;
        }
        public string AccountID { get; set; }
        public decimal Balance { get; set; }
    }
}
