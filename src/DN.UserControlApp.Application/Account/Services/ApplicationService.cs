using DN.UserControlApp.Application.Account.Handlers;
using DN.UserControlApp.SharedKernel.Events;
using DN.UserControlApp.SharedKernel.Helpers.Contracts;
using DN.UserControlApp.SharedKernel.Repositories.Contracts;

namespace DN.UserControlApp.Application.Account.Services
{
    public class ApplicationService
    {
        private IUnityOfWork _unitOfWork;
        private IHandler<DomainNotification> _notifications;
        private UserRegisteredHandler _userRegisteredHandler;

        public ApplicationService(IUnityOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _notifications = DomainEvent.Container.GetService<IHandler<DomainNotification>>();
            _userRegisteredHandler = DomainEvent.Container.GetService<UserRegisteredHandler>();
        }

        public bool Commit()
        {
            if (_notifications.HasNotifications())
                return false;

            _unitOfWork.Commit();
            return true;
        }
    }
}
