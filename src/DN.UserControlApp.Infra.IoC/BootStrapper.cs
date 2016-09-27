using DN.UserControlApp.Application.Account.Handlers;
using DN.UserControlApp.Application.Account.Services.UserServices;
using DN.UserControlApp.Domain.Account.Events.UserEvents;
using DN.UserControlApp.Domain.Account.Repositories;
using DN.UserControlApp.Domain.Account.Services;
using DN.UserControlApp.Infra.Data.ORM.Contexts;
using DN.UserControlApp.Infra.Data.Repositories;
using DN.UserControlApp.Infra.Data.Transaction;
using DN.UserControlApp.Infra.IoC.Events;
using DN.UserControlApp.SharedKernel.Events;
using DN.UserControlApp.SharedKernel.Helpers.Contracts;
using DN.UserControlApp.SharedKernel.Repositories.Contracts;
using SimpleInjector;

namespace DN.UserControlApp.Infra.IoC
{
    public class BootStrapper
    {
        public static void RegisterServices(Container container)
        {

            container.Register<IHandler<DomainNotification>, DomainNotificationHandler>(Lifestyle.Scoped);
            container.Register<IHandler<UserRegistered>, UserRegisteredHandler>();
            container.Register<IUserApplicationService, UserApplicationService>(Lifestyle.Scoped);
            container.Register<IUserRepository, UserRepository>(Lifestyle.Scoped);
            container.Register<UserControlDataContext>(Lifestyle.Scoped);
            container.Register<IUnityOfWork, UnityOfWork>(Lifestyle.Scoped);
        }
    }

}
