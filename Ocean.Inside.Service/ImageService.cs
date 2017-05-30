namespace Ocean.Inside.BLL
{
    using System.Collections.Generic;
    using System.Configuration;
    using System.IO;

    using Ocean.Inside.DAL.Infrastructure;
    using Ocean.Inside.DAL.Repositories.RepositoryInterfaces;
    using Ocean.Inside.Domain.Entities;

    public class ImageService : IImageService
    {
        private readonly IImageRepository imageRepository;
        private readonly IUnitOfWork unitOfWork;

        public ImageService(IImageRepository imageRepository, IUnitOfWork unitOfWork)
        {
            this.imageRepository = imageRepository;
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<Image> GetImages(int tourId)
        {
            return this.imageRepository.GetMany(image => image.TourId == tourId);
        }

        public void AddImage(Image image)
        {
            this.imageRepository.Add(image);
        }

        public void SaveImage()
        {
            unitOfWork.Commit();
        }


        public void RemoveImage(Image image)
        {
            File.Delete(image.Path);
            this.imageRepository.Delete(image);
            unitOfWork.Commit();
        }

        public void RemoveImages(int tourId)
        {
            foreach (var image in GetImages(tourId))
            {
                this.imageRepository.Delete(image);
            }
            unitOfWork.Commit();

            //var folderPath = ConfigurationManager.AppSettings["toursImageRoot"] + tourId;
            //Directory.Delete(folderPath);
        }
    }
}