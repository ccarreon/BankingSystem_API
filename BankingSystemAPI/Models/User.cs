using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankingSystemAPI.Models
{
    public class User
    {
        public User(int id)
        {
            UserID = id;
            Accounts = new List<Account>();
        }
        public int UserID { get; set; }
        public List<Account> Accounts { get; set; }

    }
}
