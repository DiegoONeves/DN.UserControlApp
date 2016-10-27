using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DN.UserControlApp.Domain.Account.Commands
{
    public class ChangePasswordCommand
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmNewPassword { get; set; }

        public ChangePasswordCommand(string email, string password, string newPassword, string confirmNewPassword)
        {
            Email = email;
            Password = password;
            NewPassword = newPassword;
            ConfirmNewPassword = confirmNewPassword;
        }
    }
}
