using DN.UserControlApp.Domain.Account.Events.UserEvents;
using DN.UserControlApp.SharedKernel.Helpers.Contracts;

namespace DN.UserControlApp.Domain.Account.Handlers.Contracts
{
    public interface IUserRegisteredHandler : IHandler<UserRegistered>
    {
    }
}
