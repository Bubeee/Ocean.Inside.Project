using System.Web.Mvc;
using System.Web.Routing;

namespace Ocean.Inside.Project
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Sitemap",
                url: "sitemap.xml",
                defaults: new { controller = "Home", action = "Sitemap" });

            routes.MapRoute(
                name: "Robots",
                url: "robots.txt",
                defaults: new { controller = "Home", action = "Robots" });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Tour",
                url: "Tour/HotelTour/{id}"
            );

            routes.MapRoute(
                name: "GroupTour",
                url: "Tour/GroupTour/{id}"
            );

        }
    }
}
