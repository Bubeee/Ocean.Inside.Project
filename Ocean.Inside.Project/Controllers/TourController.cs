// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TourController.cs" company="">
//   
// </copyright>
// <summary>
//   The tour controller.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Ocean.Inside.Project.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper;

    using Ocean.Inside.BLL.Services.Interfaces;
    using Ocean.Inside.Domain.Entities;
    using Ocean.Inside.Project.Filters;
    using Ocean.Inside.Project.Models;

    using PagedList;

    /// <summary>
    /// The tour controller.
    /// </summary>
    [Authorize(Roles = "Admin")]
    [Internationalization]
    public class TourController : Controller
    {
        /// <summary>
        /// The check in service.
        /// </summary>
        private readonly ICheckInService checkInService;

        /// <summary>
        /// The image service.
        /// </summary>
        private readonly IImageService imageService;

        /// <summary>
        /// The step service.
        /// </summary>
        private readonly IStepService stepService;

        /// <summary>
        /// The tour service.
        /// </summary>
        private readonly ITourService tourService;

        /// <summary>
        /// The waste service.
        /// </summary>
        private readonly IWasteService wasteService;

        /// <summary>
        /// Initializes a new instance of the <see cref="TourController"/> class.
        /// </summary>
        /// <param name="tourService">
        /// The tour service.
        /// </param>
        /// <param name="imageService">
        /// The image service.
        /// </param>
        /// <param name="wasteService">
        /// The waste service.
        /// </param>
        /// <param name="stepService">
        /// The step service.
        /// </param>
        /// <param name="checkInService">
        /// The check in service.
        /// </param>
        public TourController(
            ITourService tourService,
            IImageService imageService,
            IWasteService wasteService,
            IStepService stepService,
            ICheckInService checkInService)
        {
            this.tourService = tourService;
            this.imageService = imageService;
            this.wasteService = wasteService;
            this.stepService = stepService;
            this.checkInService = checkInService;
        }

        /// <summary>
        /// The add check in.
        /// </summary>
        /// <param name="tourId">
        /// The tour id.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [HttpGet]
        public ActionResult AddCheckIn(int tourId)
        {
            return this.View(new CheckInViewModel { Date = DateTime.Now, TourId = tourId });
        }

        /// <summary>
        /// The add check in.
        /// </summary>
        /// <param name="checkIn">
        /// The check in.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [HttpPost]
        public ActionResult AddCheckIn(CheckInViewModel checkIn)
        {
            if (this.ModelState.IsValid)
            {
                this.checkInService.AddCheckIn(Mapper.Map<CheckInViewModel, CheckIn>(checkIn));
                return this.RedirectToAction("GroupTour", new { id = checkIn.TourId });
            }

            return this.View(checkIn);
        }

        /// <summary>
        /// The add group tour.
        /// </summary>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [HttpGet]
        public ActionResult AddGroupTour()
        {
            return this.View();
        }

        /// <summary>
        /// The add group tour.
        /// </summary>
        /// <param name="model">
        /// The model.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [HttpPost]
        public ActionResult AddGroupTour(GroupTourViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                this.tourService.CreateTour(Mapper.Map<GroupTourViewModel, Tour>(model));

                return this.RedirectToAction("GroupTours", "Tour");
            }

            return this.View("AddGroupTour");
        }

        /// <summary>
        /// The add step.
        /// </summary>
        /// <param name="tourId">
        /// The tour id.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [HttpGet]
        public ActionResult AddStep(int tourId)
        {
            return this.View(new TourStepViewModel() { TourId = tourId });
        }

        /// <summary>
        /// The add step.
        /// </summary>
        /// <param name="model">
        /// The model.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [HttpPost]
        public ActionResult AddStep(TourStepViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                this.stepService.AddStep(Mapper.Map<TourStepViewModel, TourStep>(model));
                return this.RedirectToAction("GroupTour", new { id = model.TourId });
            }

            return this.View(model);
        }

        /// <summary>
        /// The add tour.
        /// </summary>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [HttpGet]
        public ActionResult AddTour()
        {
            return this.View(new TourViewModel { CheckIns = new List<CheckIn>() });
        }

        /// <summary>
        /// The add tour.
        /// </summary>
        /// <param name="tour">
        /// The tour.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [HttpPost]
        public ActionResult AddTour(TourViewModel tour)
        {
            if (this.ModelState.IsValid)
            {
                tour.CheckIns = new List<CheckIn> { new CheckIn { Date = tour.StartDate } };

                this.tourService.CreateTour(Mapper.Map<TourViewModel, Tour>(tour));

                return this.RedirectToAction("HotelTours", "Tour");
            }

            return this.View("AddTour", tour);
        }

        /// <summary>
        /// The add waste.
        /// </summary>
        /// <param name="tourId">
        /// The tour id.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [HttpGet]
        public ActionResult AddWaste(int tourId)
        {
            return this.View(new WasteViewModel { TourId = tourId });
        }

        /// <summary>
        /// The add waste.
        /// </summary>
        /// <param name="model">
        /// The model.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [HttpPost]
        public ActionResult AddWaste(WasteViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                this.wasteService.AddWaste(Mapper.Map<WasteViewModel, Waste>(model));
                return this.RedirectToAction("GroupTour", new { id = model.TourId });
            }

            return this.View(model);
        }

        /// <summary>
        /// The edit group tour.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [HttpGet]
        public ActionResult EditGroupTour(int id)
        {
            var model = this.tourService.GetTour(id);
            return this.View(Mapper.Map<Tour, GroupTourViewModel>(model));
        }

        /// <summary>
        /// The edit group tour.
        /// </summary>
        /// <param name="model">
        /// The model.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [HttpPost]
        public ActionResult EditGroupTour(GroupTourViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                this.tourService.EditTour(Mapper.Map<TourViewModel, Tour>(model));
                return this.RedirectToAction("GroupTours", "Tour");
            }

            return this.RedirectToAction("EditGroupTour", new { tourId = model.Id });
        }

        /// <summary>
        /// The edit step.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [HttpGet]
        public ActionResult EditStep(int id)
        {
            var model = this.stepService.GetStep(id);
            return this.View(Mapper.Map<TourStep, TourStepViewModel>(model));
        }

        /// <summary>
        /// The edit step.
        /// </summary>
        /// <param name="model">
        /// The model.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [HttpPost]
        public ActionResult EditStep(TourStepViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                this.stepService.EditStep(Mapper.Map<TourStepViewModel, TourStep>(model));
                return this.RedirectToAction("GroupTour", new { id = model.TourId });
            }

            return this.RedirectToAction("EditStep", new { tourId = model.Id });
        }

        /// <summary>
        /// The edit tour.
        /// </summary>
        /// <param name="tourId">
        /// The tour id.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [HttpGet]

        // [Authorize]
        public ActionResult EditTour(int tourId)
        {
            var model = this.tourService.GetTour(tourId);
            return this.View(Mapper.Map<Tour, TourViewModel>(model));
        }

        /// <summary>
        /// The edit tour.
        /// </summary>
        /// <param name="tour">
        /// The tour.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [HttpPost]
        public ActionResult EditTour(TourViewModel tour)
        {
            if (this.ModelState.IsValid)
            {
                var tourEntity = Mapper.Map<TourViewModel, Tour>(tour);
                tourEntity.CheckIns.First().Date = tour.StartDate;

                this.tourService.EditTour(tourEntity);
                return this.RedirectToAction("HotelTours", "Tour");
            }

            return this.RedirectToAction("EditTour", new { tourId = tour.Id });
        }

        /// <summary>
        /// The group tour.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [HttpGet]
        [AllowAnonymous]
        public ActionResult GroupTour(int id)
        {
            var model = Mapper.Map<Tour, GroupTourViewModel>(this.tourService.GetTour(id));
            if (model != null)
            {
                model.OtherTours =
                    Mapper.Map<IEnumerable<Tour>, IEnumerable<GroupTourViewModel>>(
                        this.tourService.GetManyTours(tour => tour.Id != id && tour.Description != null).Take(5));

                return this.View(model);
            }

            return this.RedirectToAction("PageNotFound", "Error");
        }

        /// <summary>
        /// The group tours.
        /// </summary>
        /// <param name="page">
        /// The page.
        /// </param>
        /// <param name="take">
        /// The take.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [HttpGet]
        [AllowAnonymous]
        public ActionResult GroupTours(int? page, int take = 10)
        {
            var model = this.tourService.GetManyTours(tour => tour.Hotel == null);
            var mappedModel = Mapper.Map<IEnumerable<Tour>, IEnumerable<GroupTourViewModel>>(model);

            return this.View(mappedModel.ToPagedList(page ?? 1, take));
        }

        /// <summary>
        /// The hotel tour.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
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

                return this.View(model);
            }

            return this.RedirectToAction("PageNotFound", "Error");
        }

        /// <summary>
        /// The hotel tours.
        /// </summary>
        /// <param name="page">
        /// The page.
        /// </param>
        /// <param name="take">
        /// The take.
        /// </param>
        /// <param name="sort">
        /// The sort.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
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

            return this.View(mappedModel.ToPagedList(page ?? 1, take));
        }

        /// <summary>
        /// The remove check in.
        /// </summary>
        /// <param name="checkIn">
        /// The check in.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        public ActionResult RemoveCheckIn(CheckInViewModel checkIn)
        {
            this.checkInService.RemoveCheckIn(Mapper.Map<CheckInViewModel, CheckIn>(checkIn));
            this.checkInService.CommitChanges();
            return this.RedirectToAction("GroupTour", new { id = checkIn.TourId });
        }

        /// <summary>
        /// The remove group tour.
        /// </summary>
        /// <param name="id">
        /// The tour.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        public ActionResult RemoveGroupTour(int id)
        {
            var tour = this.tourService.GetTour(id);
            
            foreach (var tourGalleryImage in tour.GalleryImages.ToList())
            {
                tourGalleryImage.Path = this.Server.MapPath(tourGalleryImage.Path);
                this.imageService.RemoveImage(tourGalleryImage);
            }
            
            foreach (var tourCheckIn in tour.CheckIns.ToList())
            {
                this.checkInService.RemoveCheckIn(tourCheckIn);
            }

            foreach (var tourTourStep in tour.TourSteps.ToList())
            {
                this.stepService.RemoveStep(tourTourStep);
            }

            foreach (var tourWaste in tour.Wastes.ToList())
            {
                this.wasteService.RemoveWaste(tourWaste);
            }

            this.tourService.RemoveTour(tour);
            this.tourService.CommitChanges();
            return this.RedirectToAction("GroupTours", "Tour");
        }

        /// <summary>
        /// The remove group tour image.
        /// </summary>
        /// <param name="image">
        /// The image.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        public ActionResult RemoveGroupTourImage(ImageViewModel image)
        {
            var imageEntity = Mapper.Map<ImageViewModel, Image>(image);
            imageEntity.Path = this.Server.MapPath(image.Path);
            this.imageService.RemoveImage(imageEntity);
            this.imageService.CommitChanges();
            return this.RedirectToAction("GroupTour", new { id = image.TourId });
        }

        /// <summary>
        /// The remove step.
        /// </summary>
        /// <param name="model">
        /// The model.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        public ActionResult RemoveStep(TourStepViewModel model)
        {
            this.stepService.RemoveStep(Mapper.Map<TourStepViewModel, TourStep>(model));
            this.stepService.CommitChanges();
            return this.RedirectToAction("GroupTour", new { id = model.TourId });
        }

        /// <summary>
        /// The remove tour.
        /// </summary>
        /// <param name="id">
        /// The tour.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [HttpGet]

        // [Authorize]
        public ActionResult RemoveTour(int id)
        {
            var tour = this.tourService.GetTour(id);

            foreach (var tourGalleryImage in tour.GalleryImages.ToList())
            {
                tourGalleryImage.Path = this.Server.MapPath(tourGalleryImage.Path);
                this.imageService.RemoveImage(tourGalleryImage);
            }

            foreach (var tourCheckIn in tour.CheckIns.ToList())
            {
                this.checkInService.RemoveCheckIn(tourCheckIn);
            }

            this.tourService.RemoveTour(tour);
            this.tourService.CommitChanges();

            return this.RedirectToAction("HotelTours", "Tour");
        }

        /// <summary>
        /// The remove tour image.
        /// </summary>
        /// <param name="image">
        /// The image.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        public ActionResult RemoveTourImage(ImageViewModel image)
        {
            var imageEntity = Mapper.Map<ImageViewModel, Image>(image);
            imageEntity.Path = this.Server.MapPath(image.Path);
            this.imageService.RemoveImage(imageEntity);
            this.imageService.CommitChanges();
            return this.RedirectToAction("HotelTour", new { id = image.TourId });
        }

        /// <summary>
        /// The remove waste.
        /// </summary>
        /// <param name="waste">
        /// The waste.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        public ActionResult RemoveWaste(WasteViewModel waste)
        {
            this.wasteService.RemoveWaste(Mapper.Map<WasteViewModel, Waste>(waste));
            this.wasteService.CommitChanges();
            return this.RedirectToAction("GroupTour", new { id = waste.TourId });
        }
    }
}