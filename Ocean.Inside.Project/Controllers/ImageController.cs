using System.Web.Mvc;

namespace Ocean.Inside.Project.Controllers
{
    using System.Configuration;
    using System.IO;

    using AutoMapper;

    using Ocean.Inside.BLL.Services.Interfaces;
    using Ocean.Inside.Domain.Entities;
    using Ocean.Inside.Project.Models;

    [Authorize(Roles = "Admin")]
    public class ImageController : Controller
    {
        private readonly IImageService imageService;

        public ImageController(IImageService imageService)
        {
            this.imageService = imageService;
        }

        [HttpGet]
        public ActionResult AddImage(int tourId)
        {
            return View(new ImageViewModel
            {
                TourId = tourId
            });
        }

        [HttpPost]
        public ActionResult AddImage(ImageViewModel imageViewModel)
        {
            var pictureName = Path.GetFileName(imageViewModel.ImageRaw?.FileName);
            if (pictureName != null)
            {
                var folderPath = ConfigurationManager.AppSettings["toursImageRoot"] + imageViewModel.TourId;

                var folderServer = this.Server.MapPath(folderPath);

                if (Directory.Exists(folderServer) == false)
                {
                    Directory.CreateDirectory(folderServer);
                }

                imageViewModel.Path = Path.Combine(folderPath, pictureName);

                var fullPath = Path.Combine(folderServer, pictureName);
                imageViewModel.ImageRaw.SaveAs(fullPath);

                this.imageService.AddImage(Mapper.Map<ImageViewModel, Image>(imageViewModel));
                this.imageService.CommitChanges();
            }

            return View(new ImageViewModel
            {
                TourId = imageViewModel.TourId
            });
        }
    }
}