using System.Collections.Generic;
using System.IO;
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
            if (model != null)
            {
                return View(model);
            }

            Response.StatusCode = 404;

            return View("404");
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
        //[Authorize]
        public ActionResult AddTour()
        {
            return View();
        }

        [HttpPost]
        //[Authorize]
        public ActionResult AddTour(TourViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.ImageRaw != null)
                {
                    var pic = Path.GetFileName(model.ImageRaw.FileName);
                    var fileName = model.Title + "_" + model.Location + "_" + "_" + pic;
                    const string folderPath = "/images/Tours/";

                    var path = Path.Combine(Server.MapPath('~' + folderPath), fileName);
                    model.ImageRaw.SaveAs(path);
                    model.ImageUrl = folderPath + fileName;
                }

                _tourService.CreateTour(Mapper.Map<TourViewModel, Tour>(model));
                _tourService.SaveTour();

                return RedirectToAction("AllTours", "Tours");
            }

            return View(model);
        }
    }
}