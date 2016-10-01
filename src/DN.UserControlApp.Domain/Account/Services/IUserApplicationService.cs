using DN.UserControlApp.Domain.Account.Commands;
using DN.UserControlApp.Domain.Account.Entities;
using System.Collections.Generic;

namespace DN.UserControlApp.Domain.Account.Services
{
    public interface IUserApplicationService
    {
        User Register(RegisterUserCommand command);
        IEnumerable<User> GetAll();
        User GetByEmail(string email);

    }
}
