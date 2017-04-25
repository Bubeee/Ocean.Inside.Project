using System.Globalization;
using System.Threading;
using System.Web.Mvc;

namespace Ocean.Inside.Project.Filters
{
    public class InternationalizationAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var language = (string)filterContext.RouteData.Values["language"] ?? "ru";
            var culture = (string)filterContext.RouteData.Values["culture"] ?? "RU";

            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo($"{language}-{culture}");
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo($"{language}-{culture}");
        }
    }
}