using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurakWcfService.Models
{
    public class AccountModel
    {
        private List<Account> Accounts = new List<Account>();

        public AccountModel()
        {
            Accounts.Add(new Account() { Username = "acc1", Password="123" });
            Accounts.Add(new Account() { Username = "acc2", Password = "123" });
            Accounts.Add(new Account() { Username = "acc3", Password = "123" });
            Accounts.Add(new Account() { Username = "acc4", Password = "123" });

        }

        public bool Login(string Username, string Password)
        {
            return Accounts.Count(x => x.Username.Equals(Username) && x.Password.Equals(Password)) > 0;
        }
    }
}
