using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IdentityModel.Selectors;
using System.IdentityModel.Tokens;
using BurakWcfService.Models;

namespace BurakWcfService.App_Code.Authentication
{
    class CustomValidator : UserNamePasswordValidator
    {
        public override void Validate(string userName, string password)
        {
            AccountModel acc = new AccountModel();
            if (acc.Login(userName, password))
                return;

            throw new SecurityTokenException("Account is Invalid");
        }
    }
}
