using System;
using System.Reflection;
using System.Web;
using System.Web.UI;
using BusinessLogic.Services;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Domain.MyOrmImplementation;
using Infrastructure;
using Web.Classic.UI.Presenters;
using Web.Classic.UI.Views;

namespace Web.Classic
{
    public class Global : HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            var container = new WindsorContainer();

            container.Register(
                AllTypes
                    .Pick().FromAssembly(typeof (ProductPresenter).Assembly)
                    .If(s => s.Name.EndsWith("Presenter"))
                    .WithService.FirstInterface()
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
            container.Register(Component.For<IProductView>().ImplementedBy<Default>());

            IoC.Init(container);
        }
    }
}