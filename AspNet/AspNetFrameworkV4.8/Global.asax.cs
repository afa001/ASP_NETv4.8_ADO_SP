using AspNetFrameworkV4._8.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Unity;
using Unity.Injection;
using Unity.Mvc5;

namespace AspNetFrameworkV4._8
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            // Register dependencies
            var container = new UnityContainer();
            container.RegisterType<IClienteRepository, ClienteRepository>(new InjectionConstructor(connectionString));
            container.RegisterType<ITipoClienteRepository, TipoClienteRepository>(new InjectionConstructor(connectionString));
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}
