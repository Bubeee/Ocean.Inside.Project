using System.Linq;
using System.Web.Mvc;
using Ocean.Inside.BLL;

namespace Ocean.Inside.Project.Controllers
{
    public class ToursController : Controller
    {
        private readonly ITourService _tourService;

        public ToursController(ITourService tourService)
        {
            _tourService = tourService;
        }

        public ActionResult AllTours()
        {
            var tours = _tourService.GetTours().ToList();

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