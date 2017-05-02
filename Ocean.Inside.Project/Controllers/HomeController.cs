using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using Ocean.Inside.BLL;
using Ocean.Inside.Domain.Entities;
using Ocean.Inside.Project.ViewModels;

namespace Ocean.Inside.Project.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITourService _tourService;

        public HomeController(ITourService tourService)
        {
            _tourService = tourService;
        }

        public ActionResult Index()
        {
            var model = new HomeViewModel()
            {
                TourViewModels = new List<TourViewModel>()
            };

            foreach (var tour in _tourService.GetTours())
            {
                model.TourViewModels.Add(Mapper.Map<Tour, TourViewModel>(tour));
            }

            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}