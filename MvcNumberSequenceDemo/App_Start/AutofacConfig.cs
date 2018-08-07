using Autofac;
using Autofac.Integration.Mvc;
using SequenceGenerator;
using SequenceGenerator.Interfaces;
using System.Web.Mvc;

namespace MvcNumberSequenceDemo.App_Start
{
    public static class AutofacConfig
    {
        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();

            // Register dependencies in controllers
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            // Register dependencies in filter attributes
            builder.RegisterFilterProvider();

            // Register dependencies in custom views
            builder.RegisterSource(new ViewRegistrationSource());

            // Register our interfaces
            builder.RegisterType<SequenceService>().As<ISequenceService>().InstancePerRequest();
            builder.RegisterType<SequenceStrategyFactory>().As<ISequenceStrategyFactory>().InstancePerRequest();

            var container = builder.Build();

            // Set MVC DI resolver to use our Autofac container
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}