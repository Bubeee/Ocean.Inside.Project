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

    using PagedList;

    [Authorize(Roles = "Admin")]
    [Internationalization]
    public class TourController : Controller
    {
        private readonly ITourService tourService;
        private readonly IImageService imageService;

        public TourController(ITourService tourService, IImageService imageService)
        {
            this.tourService = tourService;
            this.imageService = imageService;
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult HotelTour(int id)
        {
            var model = Mapper.Map<Tour, TourViewModel>(this.tourService.GetTour(id));
            if (model != null)
            {
                model.OtherTours =
                    Mapper.Map<IEnumerable<Tour>, IEnumerable<TourViewModel>>(
                        this.tourService.GetManyTours(tour => tour.Id != id && tour.TourSteps.Any() == false).Take(5));

                return View(model);
            }

            return this.RedirectToAction("PageNotFound", "Error");
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult HotelTours(int? page, int take = 21, string sort = "date")
        {
            this.ViewBag.Sort = sort;
            var model = this.tourService.GetManyTours(tour => tour.Hotel != null);
            var mappedModel = Mapper.Map<IEnumerable<Tour>, IEnumerable<TourViewModel>>(model);

            if (sort != "date")
            {
                mappedModel = mappedModel.OrderBy(viewModel => viewModel.Title);
            }

            return View(mappedModel.ToPagedList(page ?? 1, take));
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult GroupTours(int? page, int take = 10)
        {
            var model = this.tourService.GetManyTours(tour => tour.Hotel == null);
            var mappedModel = Mapper.Map<IEnumerable<Tour>, IEnumerable<GroupTourViewModel>>(model);

            return View(mappedModel.ToPagedList(page ?? 1, take));
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult GroupTour(int id)
        {
            var model = Mapper.Map<Tour, GroupTourViewModel>(this.tourService.GetTour(id));
            if (model != null)
            {
                model.OtherTours = Mapper.Map<IEnumerable<Tour>, IEnumerable<GroupTourViewModel>>(this.tourService.GetManyTours(tour => tour.Id != id && tour.Description != null).Take(5));

                return this.View(model);
            }

            return this.RedirectToAction("PageNotFound", "Error");
        }

        [HttpGet]
        public ActionResult AddTour()
        {
            return View(new TourViewModel
            {
                CheckIns = new List<CheckIn>()
            });
        }

        [HttpPost]
        public ActionResult AddTour(TourViewModel tour)
        {
            if (ModelState.IsValid)
            {
                tour.CheckIns = new List<CheckIn>
                                    {
                                        new CheckIn
                                            {
                                                Date = tour.StartDate
                                            }
                                    };

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
                var tourEntity = Mapper.Map<TourViewModel, Tour>(tour);
                tourEntity.CheckIns.First().Date = tour.StartDate;

                this.tourService.EditTour(tourEntity);
                return this.RedirectToAction("HotelTours", "Tour");
            }

            return RedirectToAction("EditTour", new { tourId = tour.Id });
        }

        [HttpGet]
        //[Authorize]
        public ActionResult RemoveTour(TourViewModel tour)
        {
            this.tourService.RemoveTour(Mapper.Map<TourViewModel, Tour>(tour));
            this.imageService.RemoveImages(tour.Id);
            return RedirectToAction("HotelTours", "Tour");
        }

        [HttpGet]
        public ActionResult AddStep(int tourId)
        {
            return this.View(new TourStepViewModel() { TourId = tourId });
        }

        [HttpPost]
        public ActionResult AddStep(TourStepViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                this.tourService.AddStep(Mapper.Map<TourStepViewModel, TourStep>(model));
                return this.RedirectToAction("GroupTour", new { id = model.TourId });
            }

            return this.View(model);
        }

        [HttpGet]
        public ActionResult EditStep(int id)
        {
            var model = this.tourService.GetStep(id);
            return this.View(Mapper.Map<TourStep, TourStepViewModel>(model));
        }

        [HttpPost]
        public ActionResult EditStep(TourStepViewModel model)
        {
            if (ModelState.IsValid)
            {
                this.tourService.EditStep(Mapper.Map<TourStepViewModel, TourStep>(model));
                return this.RedirectToAction("GroupTour", new { id = model.TourId });
            }

            return RedirectToAction("EditStep", new { tourId = model.Id });
        }

        public ActionResult RemoveStep(TourStepViewModel model)
        {
            this.tourService.RemoveStep(Mapper.Map<TourStepViewModel, TourStep>(model));
            return this.RedirectToAction("GroupTour", new { id = model.TourId });
        }

        [HttpGet]
        public ActionResult AddWaste(int tourId)
        {
            return this.View(new WasteViewModel { TourId = tourId });
        }

        [HttpPost]
        public ActionResult AddWaste(WasteViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                this.tourService.AddWaste(Mapper.Map<WasteViewModel, Waste>(model));
                return this.RedirectToAction("GroupTour", new { id = model.TourId });
            }

            return this.View(model);
        }

        public ActionResult RemoveWaste(WasteViewModel waste)
        {
            this.tourService.RemoveWaste(Mapper.Map<WasteViewModel, Waste>(waste));
            return this.RedirectToAction("GroupTour", new { id = waste.TourId });
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
            return this.View(Mapper.Map<Tour, GroupTourViewModel>(model));
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

        public ActionResult RemoveGroupTour(GroupTourViewModel tour)
        {
            this.tourService.RemoveTour(Mapper.Map<GroupTourViewModel, Tour>(tour));
            this.imageService.RemoveImages(tour.Id);
            return RedirectToAction("GroupTours", "Tour");
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

        public ActionResult RemoveGroupTourImage(ImageViewModel image)
        {
            var imageEntity = Mapper.Map<ImageViewModel, Image>(image);
            imageEntity.Path = Server.MapPath(image.Path);
            this.imageService.RemoveImage(imageEntity);
            return RedirectToAction("GroupTour", new { id = image.TourId });
        }

        public ActionResult RemoveTourImage(ImageViewModel image)
        {
            var imageEntity = Mapper.Map<ImageViewModel, Image>(image);
            imageEntity.Path = Server.MapPath(image.Path);
            this.imageService.RemoveImage(imageEntity);
            return RedirectToAction("HotelTour", new { id = image.TourId });
        }
    }
}