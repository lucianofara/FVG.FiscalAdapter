using Autofac;
using Autofac.Integration.WebApi;
using FVG.FiscalAdapter.Presentation.API.Helpers;
using System.Web.Mvc;

namespace FVG.FiscalAdapter.Presentation.API.App_Start
{
    public class DependenciesConfig
    {
        public static IContainer Register(System.Web.Http.HttpConfiguration config)
        {
            var builder = new Autofac.ContainerBuilder();

            builder.RegisterModule(new Domain.Core.Modules.CoreModule());
            builder.RegisterModule(new Domain.Core.Modules.LogModule());

            builder.RegisterType<PrintProcessor>().As<IPrintProcessor>();

            builder.RegisterApiControllers(typeof(WebApiApplication).Assembly);

            var container = builder.Build();

            //Mvc & WebApi DependencyResolvers
            DependencyResolver.SetResolver(new Autofac.Integration.Mvc.AutofacDependencyResolver(container));
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            return container;
        }
    }
}