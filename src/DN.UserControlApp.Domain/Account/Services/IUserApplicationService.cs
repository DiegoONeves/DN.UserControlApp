using DN.UserControlApp.Domain.Account.Commands;
using DN.UserControlApp.Domain.Account.Entities;

namespace DN.UserControlApp.Domain.Account.Services
{
    public interface IUserApplicationService
    {
        User Register(RegisterUserCommand command);
        User GetByUserName(string userName);
        bool Authenticate(string username, string password);

    }
}
