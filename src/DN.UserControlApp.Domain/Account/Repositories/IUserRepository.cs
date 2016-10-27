using DN.UserControlApp.Domain.Account.Entities;

namespace DN.UserControlApp.Domain.Account.Repositories
{
    public interface IUserRepository
    {
        void Register(User user);
        void Update(User user);
        User Authenticate(string userName, string password);
    }
}
