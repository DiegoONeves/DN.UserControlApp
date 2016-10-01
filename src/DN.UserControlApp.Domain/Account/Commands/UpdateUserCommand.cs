using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DN.UserControlApp.Domain.Account.Commands
{
    public class UpdateUserCommand
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public UpdateUserCommand(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }
    }
}
