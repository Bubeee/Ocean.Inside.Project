using System.Web.Mvc;

namespace Ocean.Inside.Project.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        public ActionResult Index()
        {
            return View();
        }
    }
}