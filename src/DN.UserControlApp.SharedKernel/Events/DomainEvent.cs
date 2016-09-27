using DN.UserControlApp.SharedKernel.Events.Contracts;
using DN.UserControlApp.SharedKernel.Helpers.Contracts;

namespace DN.UserControlApp.SharedKernel.Events
{
    public static class DomainEvent
    {
        public static IContainer Container { get; set; }

        public static void Raise<T>(T args) where T : IDomainEvent
        {
            if (Container != null)
            {
                var obj = Container.GetService(typeof(IHandler<T>));
                ((IHandler<T>)obj).Handle(args);
            }
        }
    }
}
