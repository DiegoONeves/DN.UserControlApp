using DN.UserControlApp.SharedKernel.Events;
using System.Collections.Generic;
using System.Linq;

namespace DN.UserControlApp.SharedKernel.Validation
{
    public static class AssertionConcern
    {
        public static bool IsSatisfiedBy(params DomainNotification[] validations)
        {
            var notificationsNotNull = validations.Where(x => x != null);
            NotifyAll(notificationsNotNull);

            return notificationsNotNull.Count().Equals(0);
        }

        public static void NotifyAll(IEnumerable<DomainNotification> notifications)
        {
            notifications.ToList().ForEach(x => 
            {
                DomainEvent.Raise(x);
            });
        }

        public static DomainNotification AssertNotNull(object object1, string message)
        {
            return (object1 == null) ?
                new DomainNotification("AssertArgumentNotNull", message) : null;
        }
        public static DomainNotification AssertNotEmpty(string object1, string message)
        {
            return (string.IsNullOrWhiteSpace(object1)) ?
                new DomainNotification("AssertArgumentNotEmpty", message) : null;
        }
    

    }
}
