using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using Ocean.Inside.BLL;
using Ocean.Inside.Domain.Entities;
using Ocean.Inside.Project.Filters;
using Ocean.Inside.Project.Models;

namespace Ocean.Inside.Project.Controllers
{
    using System;
    using System.Linq;

    using Microsoft.Ajax.Utilities;

    [Internationalization]
    public class TourController : Controller
    {
        private readonly ITourService tourService;

        public TourController(ITourService tourService)
        {
            this.tourService = tourService;
        }

        [HttpGet]
        public ActionResult HotelTour(int id)
        {
            var model = Mapper.Map<Tour, TourViewModel>(this.tourService.GetTour(id));
            if (model != null)
            {
                model.OtherTours = Mapper.Map<IEnumerable<Tour>, IEnumerable<GroupTourViewModel>>(this.tourService.GetManyTours(tour => tour.Id != id && tour.TourSteps.Any() == false).Take(5));

                return View(model);
            }

            Response.StatusCode = 404;

            return View("404");
        }

        [HttpGet]
        public ActionResult HotelTours()
        {
            var model = new List<TourViewModel>();

            foreach (var tour in this.tourService.GetManyTours(tour => tour.Hotel != null))
            {
                model.Add(Mapper.Map<Tour, TourViewModel>(tour));
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult GroupTours()
        {
            var model = this.tourService.GetManyTours(tour => tour.Description != null);
            var mappedModel = Mapper.Map<IEnumerable<Tour>, IEnumerable<GroupTourViewModel>>(model);

            return View(mappedModel);
        }

        [HttpGet]
        public ActionResult GroupTour(int id)
        {
            var model = Mapper.Map<Tour, GroupTourViewModel>(this.tourService.GetTour(id));
            if (model != null)
            {
                model.OtherTours = Mapper.Map<IEnumerable<Tour>, IEnumerable<GroupTourViewModel>>(this.tourService.GetManyTours(tour => tour.Id != id && tour.TourSteps.Any()).Take(5));

                return View(model);
            }

            Response.StatusCode = 404;

            return View("404");
        }

        [HttpGet]
        //[Authorize]
        public ActionResult AddTour()
        {
            return View(new TourViewModel
            {
                CheckIns = new List<CheckIn>()
            });
        }

        [HttpPost]
        //[Authorize]
        public ActionResult AddTour(TourViewModel tour)
        {
            if (ModelState.IsValid)
            {
                this.tourService.CreateTour(Mapper.Map<TourViewModel, Tour>(tour));
                this.tourService.SaveTour();

                return RedirectToAction("HotelTours", "Tour");
            }

            return this.View("AddTour");
        }

        [HttpGet]
        //[Authorize]
        public ActionResult EditTour(int tourId)
        {
            var model = this.tourService.GetTour(tourId);
            return this.View(Mapper.Map<Tour, TourViewModel>(model));
        }

        [HttpPost]
        public ActionResult EditTour(TourViewModel tour)
        {
            if (ModelState.IsValid)
            {
                this.tourService.EditTour(Mapper.Map<TourViewModel, Tour>(tour));
                return this.RedirectToAction("HotelTours", "Tour");
            }

            return RedirectToAction("EditTour", new { tourId = tour.Id });
        }

        [HttpGet]
        //[Authorize]
        public ActionResult RemoveTour(TourViewModel tour)
        {
            this.tourService.RemoveTour(Mapper.Map<TourViewModel, Tour>(tour));
            return RedirectToAction("HotelTours", "Tour");
        }

        [HttpGet]
        public ActionResult AddStep()
        {
            return this.View();
        }

        public ActionResult EditStep(int id)
        {
            throw new System.NotImplementedException();
        }

        public ActionResult RemoveStep(int id)
        {
            throw new System.NotImplementedException();
        }


        public ActionResult AddWaste()
        {
            throw new System.NotImplementedException();
        }

        public ActionResult EditWaste(int id)
        {
            throw new System.NotImplementedException();
        }

        public ActionResult RemoveWaste(int id)
        {
            throw new System.NotImplementedException();
        }

        [HttpGet]
        public ActionResult AddGroupTour()
        {
            return this.View();
        }

        [HttpPost]
        public ActionResult AddGroupTour(GroupTourViewModel model)
        {
            if (ModelState.IsValid)
            {
                this.tourService.CreateTour(Mapper.Map<GroupTourViewModel, Tour>(model));
                this.tourService.SaveTour();

                return RedirectToAction("GroupTours", "Tour");
            }

            return this.View("AddGroupTour");
        }

        [HttpGet]
        public ActionResult EditGroupTour(int id)
        {
            var model = this.tourService.GetTour(id);
            return this.View(Mapper.Map<Tour, TourViewModel>(model));
        }

        [HttpPost]
        public ActionResult EditGroupTour(GroupTourViewModel model)
        {
            if (ModelState.IsValid)
            {
                this.tourService.EditTour(Mapper.Map<TourViewModel, Tour>(model));
                return this.RedirectToAction("GroupTours", "Tour");
            }

            return RedirectToAction("EditGroupTour", new { tourId = model.Id });
        }

        public ActionResult RemoveGroupTour(int id)
        {
            throw new System.NotImplementedException();
        }

        [HttpGet]
        public ActionResult AddCheckIn(int tourId)
        {
            return this.View(new CheckInViewModel
            {
                Date = DateTime.Now,
                TourId = tourId
            });
        }

        [HttpPost]
        public ActionResult AddCheckIn(CheckInViewModel checkIn)
        {
            if (ModelState.IsValid)
            {
                this.tourService.AddCheckIn(Mapper.Map<CheckInViewModel, CheckIn>(checkIn));
                return this.RedirectToAction("GroupTour", new { id = checkIn.TourId });
            }

            return this.View(checkIn);
        }

        public ActionResult RemoveCheckIn(CheckInViewModel checkIn)
        {
            this.tourService.RemoveCheckIn(Mapper.Map<CheckInViewModel, CheckIn>(checkIn));
            return this.RedirectToAction("GroupTour", new { id = checkIn.TourId });
        }
    }
}