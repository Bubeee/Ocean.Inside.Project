using System.Web.Mvc;

namespace Ocean.Inside.Project.Controllers
{
    using System.Collections.Generic;
    using System.Configuration;
    using System.IO;

    using AutoMapper;

    using BLL.Services.Interfaces;
    using Domain.Entities;
    using Models;

    [Authorize]
    public class GalleryController : Controller
    {
        private readonly IGalleryService galleryService;
        private readonly IImageService imageService;

        public GalleryController(IGalleryService galleryService, IImageService imageService)
        {
            this.galleryService = galleryService;
            this.imageService = imageService;
        }

        // GET: Gallery
        [AllowAnonymous]
        public ActionResult Index()
        {
            var galleryItems = this.galleryService.GetAll();
            var galleryModel = Mapper.Map<IEnumerable<GalleryItem>, IEnumerable<GalleryItemViewModel>>(galleryItems);

            return View(galleryModel);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return this.View();
        }

        [HttpPost]
        public ActionResult Add(GalleryItemViewModel item)
        {
            this.galleryService.Add(Mapper.Map<GalleryItemViewModel, GalleryItem>(item));
            return this.RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = Mapper.Map<GalleryItem, GalleryItemViewModel>(this.galleryService.GetById(id));
            return this.View(model);
        }

        [HttpPost]
        public ActionResult Edit(GalleryItemViewModel item)
        {
            this.galleryService.Update(Mapper.Map<GalleryItemViewModel, GalleryItem>(item));

            return this.RedirectToAction("Edit", new { id = item.Id });
        }

        public ActionResult RemoveImage(ImageViewModel imageViewModel)
        {
            var imageEntity = Mapper.Map<ImageViewModel, Image>(imageViewModel);
            imageEntity.Path = this.Server.MapPath(imageViewModel.Path);
            this.imageService.RemoveImage(imageEntity);
            if (imageViewModel.GalleryItemId == null)
            {
                return this.RedirectToAction("Index");
            }

            return this.RedirectToAction("Edit", new { id = imageViewModel.GalleryItemId.Value });
        }

        [HttpGet]
        public ActionResult AddImage(int id)
        {
            return View(new ImageViewModel
            {
                GalleryItemId = id
            });
        }

        [HttpPost]
        public ActionResult AddImage(ImageViewModel imageViewModel)
        {
            imageViewModel.Id = 0;
            var pictureName = Path.GetFileName(imageViewModel.ImageRaw?.FileName);
            if (pictureName != null)
            {
                var folderPath = ConfigurationManager.AppSettings["galleryImagesRoot"] + imageViewModel.GalleryItemId;

                var folderServer = this.Server.MapPath(folderPath);

                if (Directory.Exists(folderServer) == false)
                {
                    Directory.CreateDirectory(folderServer);
                }

                imageViewModel.Path = Path.Combine(folderPath, pictureName);

                var fullPath = Path.Combine(folderServer, pictureName);
                imageViewModel.ImageRaw.SaveAs(fullPath);

                this.imageService.AddImage(Mapper.Map<ImageViewModel, Image>(imageViewModel));
                this.imageService.SaveImage();
            }

            return View(new ImageViewModel
            {
                TourId = imageViewModel.TourId
            });
        }

        public ActionResult Remove(int id)
        {
            var model = this.galleryService.GetById(id);
            this.galleryService.Remove(model);
            return RedirectToAction("Index");
        }
    }
}