using DN.UserControlApp.SharedKernel.Events;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

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
        public static DomainNotification AssertArgumentFalse(bool boolValue, string message)
        {
            return (boolValue) ?
                new DomainNotification("AssertArgumentFalse", message) : null;
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
        public static DomainNotification AssertArgumentLength(string stringValue, int maximum, string message)
        {
            int length = stringValue.Trim().Length;

            return length > maximum ?
                new DomainNotification("AssertArgumentLength", message) : null;
        }

        public static DomainNotification AssertArgumentLength(string stringValue, int minimum, int maximum, string message)
        {
            if (string.IsNullOrEmpty(stringValue))
                stringValue = string.Empty;

            int length = stringValue.Trim().Length;

            return length < minimum || length > maximum ?
                new DomainNotification("AssertArgumentLength", message) : null;
        }

        public static DomainNotification AssertArgumentMatches(string pattern, string stringValue, string message)
        {
            Regex regex = new Regex(pattern);

            return !regex.IsMatch(stringValue) ?
                new DomainNotification("AssertArgumentMatches", message) : null;
        }


    }
}
