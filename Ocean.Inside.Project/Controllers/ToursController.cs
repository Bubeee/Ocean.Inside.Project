using System.Web.Mvc;

namespace Ocean.Inside.Project.Controllers
{
    public class ToursController : Controller
    {
        public ActionResult AllTours()
        {
            return View("ToursGrid");
        }

        public ActionResult GroupTours()
        {
            throw new System.NotImplementedException();
        }

        public void AddTour()
        {
            
        }
    }
}