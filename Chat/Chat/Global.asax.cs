using System.Configuration;
using System.Data.SqlClient;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Chat
{
    public class MvcApplication : System.Web.HttpApplication
    {
        string connString = ConfigurationManager.ConnectionStrings
        ["testDB"].ConnectionString;

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            SqlDependency.Start(connString);
        }

        protected void Application_End()
        {
            SqlDependency.Stop(connString);
        }
    }
}
