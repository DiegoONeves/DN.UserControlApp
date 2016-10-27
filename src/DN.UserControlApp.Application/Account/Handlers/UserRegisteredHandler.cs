using DN.UserControlApp.Domain.Account.Events.UserEvents;
using DN.UserControlApp.SharedKernel.Helpers.Contracts;
using System.Collections.Generic;

namespace DN.UserControlApp.Application.Account.Handlers
{
    public class UserRegisteredHandler : IHandler<UserRegistered>
    {
        private List<UserRegistered> _notifications;

        
        public void Handle(UserRegistered args)
        {
            //enviar e-mail
        }

        public bool HasNotifications()
        {
            return GetValue().Count > 0;
        }

        public IEnumerable<UserRegistered> Notify()
        {
            return GetValue();
        }

        private List<UserRegistered> GetValue()
        {
            return _notifications;
        }

        public void Dispose()
        {
            _notifications = new List<UserRegistered>();
        }
    }
}
