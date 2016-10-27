using DN.UserControlApp.Domain.Account.Commands;
using DN.UserControlApp.Domain.Account.Entities;
using System.Collections.Generic;

namespace DN.UserControlApp.Domain.Account.Services
{
    public interface IUserApplicationService
    {
        User Register(RegisterUserCommand command);
        User Update(UpdateUserCommand command);
        void ResetPassword(string email);
        void ChangePassword(ChangePasswordCommand command);
        User GetByEmail(string email);

    }
}
