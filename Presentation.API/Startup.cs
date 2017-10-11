using FVG.FiscalAdapter.Presentation.API.App_Start;
using Microsoft.Owin;
using Owin;
using System.Web.Mvc;
using System.Web.Optimization;

[assembly: OwinStartup(typeof(FVG.FiscalAdapter.Presentation.API.Startup))]

namespace FVG.FiscalAdapter.Presentation.API
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var container = DependenciesConfig.Register(System.Web.Http.GlobalConfiguration.Configuration);

            //global
            AreaRegistration.RegisterAllAreas();
            System.Web.Http.GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}