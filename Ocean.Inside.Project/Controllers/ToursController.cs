using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web.Mvc;
using AutoMapper;
using Ocean.Inside.BLL;
using Ocean.Inside.Domain.Entities;
using Ocean.Inside.Project.Filters;
using Ocean.Inside.Project.ViewModels;

namespace Ocean.Inside.Project.Controllers
{
    [Internationalization]
    public class ToursController : Controller
    {
        private readonly ITourService _tourService;

        public ToursController(ITourService tourService)
        {
            _tourService = tourService;
        }

        [HttpGet]
        public ActionResult Tour(int id)
        {
            var model = Mapper.Map<Tour, TourViewModel>(_tourService.GetTour(id));


            return View(model);
        }

        [HttpGet]
        public ActionResult AllTours()
        {
            var model = new List<TourViewModel>();

            foreach (var tour in _tourService.GetTours())
            {
                model.Add(Mapper.Map<Tour, TourViewModel>(tour));
            }

            return View(model);
        }
        
        [HttpGet]
        [Authorize]
        public void AddTour()
        {

        }

        [HttpPost]
        [Authorize]
        public void AddTour(TourViewModel model)
        {

        }
    }
}