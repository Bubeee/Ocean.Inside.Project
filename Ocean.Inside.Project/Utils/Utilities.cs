namespace Ocean.Inside.Project.Utils
{
    using System.Web.Mvc;

    public static class Utilities
    {
        public static string IsActive(this HtmlHelper html,
                                      string controller,
                                      string action)
        {
            var routeData = html.ViewContext.RouteData;

            var routeAction = (string)routeData.Values["action"];
            var routeControl = (string)routeData.Values["controller"];

            // both must match
            var returnActive = controller == routeControl &&
                               action == routeAction;

            return returnActive ? "active" : "";
        }
    }
}