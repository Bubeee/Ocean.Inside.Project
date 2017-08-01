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
            return View("_404");
        }
        public ActionResult InternalServerError()
        {
            return View("_503");
        }
    }
}