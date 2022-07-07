using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankingSystemAPI.Models
{
    public class Transaction
    {
        public int UserID { get; set; }
        public string AccountID { get; set; }
        public decimal Amount { get; set; }
    }
}
