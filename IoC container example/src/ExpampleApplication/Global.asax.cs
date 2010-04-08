using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using BusinessLogic.Services;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Domain.MyOrmImplementation;
using ExpampleApplication.Controllers;
using Infrastructure;

namespace ExpampleApplication
{
    public class MvcApplication : HttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new {controller = "Home", action = "Index", id = ""} // Parameter defaults
                );
        }

        protected void Application_Start()
        {
            RegisterRoutes(RouteTable.Routes);

            ControllerBuilder.Current.SetControllerFactory(typeof (ContainerControllerFactory));
        }
    }

    public class ContainerControllerFactory : DefaultControllerFactory
    {
        private readonly WindsorContainer container;

        public ContainerControllerFactory()
        {
            container = new WindsorContainer();

            container.Register(
                AllTypes.Of(typeof (IController))
                    .FromAssembly(typeof (HomeController).Assembly)
                );

            container.Register(
                AllTypes
                    .Pick().FromAssembly(typeof (ProductService).Assembly)
                    .If(s => s.Name.EndsWith("Service"))
                    .WithService.FirstInterface()
                );

            container.Register(
                AllTypes
                    .Pick().FromAssembly(typeof (ProductRepository).Assembly)
                    .If(s => s.Name.EndsWith("Repository"))
                    .WithService.FirstInterface()
                );
            container.Register(Component.For<IDataContext>().ImplementedBy<MyOrmDataContext>());
        }

        protected override IController GetControllerInstance(Type controllerType)
        {
            return container.Resolve(controllerType) as IController;
        }
    }
}