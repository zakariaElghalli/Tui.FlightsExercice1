using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using AutoMapper;

namespace Tui.Presentation
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            Mapper.Initialize(cfg =>
            {

                cfg.AddProfile<AutoMapperStartup>();
            });
        }
    }
}
