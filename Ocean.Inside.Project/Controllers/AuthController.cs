using System.Web.Mvc;

namespace Ocean.Inside.Project.Controllers
{
    public class AuthController : Controller
    {
        public ActionResult Login()
        {
            ViewBag.IsLogin = true;
            return View("Login", null);
        }
    }
}