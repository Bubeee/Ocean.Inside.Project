using System.Data.Entity;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

using FluentValidation.Mvc;

namespace Ocean.Inside.Project
{
    using System;
    using System.Web;

    using DAL.DataGeneration;

    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            MvcHandler.DisableMvcResponseHeader = true;
            Database.SetInitializer(new OceanInsideSeedData());
            FluentValidationModelValidatorProvider.Configure();

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            Bootstrapper.Run();
        }
        protected void Application_PreSendRequestHeaders()
        {
            if (HttpContext.Current != null)
            {
                HttpContext.Current.Response.Headers.Remove("Server");
            }
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Exception ex = Server.GetLastError();
            if (ex is HttpException)
            {
                if (((HttpException)(ex)).GetHttpCode() == 404)
                {
                    Response.Redirect("/Error/PageNotFound");
                }
                if (((HttpException)(ex)).GetHttpCode() == 503)
                {

                    Response.Redirect("/Error/InternalServerError");
                }
            }

            Response.Redirect("/Error/Index");
        }
    }
}
