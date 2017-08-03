using System.Web.Mvc;

namespace Ocean.Inside.Project.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult Index()
        {
            return View("_Error");
        }
        public ActionResult PageNotFound()
        {
            Response.StatusCode = 404;
            return View("_404");
        }
        public ActionResult InternalServerError()
        {
            Response.StatusCode = 503;
            return View("_503");
        }
    }
}