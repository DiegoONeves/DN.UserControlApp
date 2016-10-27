using DN.UserControlApp.Infra.IoC;
using DN.UserControlApp.Presentation.MVC;
using DN.UserControlApp.SharedKernel.Events;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using System.Reflection;
using System.Web.Mvc;
[assembly: WebActivator.PostApplicationStartMethod(typeof(SimpleInjectorInitializer), "Initialize")]


namespace DN.UserControlApp.Presentation.MVC
{

    public static class SimpleInjectorInitializer
    {
        /// <summary>Initialize the container and register it as MVC3 Dependency Resolver.</summary>
        public static void Initialize()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            InitializeContainer(container);

            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());

            //container.Verify();

            var dr = new SimpleInjectorDependencyResolver(container);
            DependencyResolver.SetResolver(dr);

            DomainEvent.Container = new DomainEventsContainer(dr);
        }

        private static void InitializeContainer(Container container)
        {
            BootStrapper.RegisterServices(container);        
        }
    }
}