namespace Ocean.Inside.BLL
{
    using System.Collections.Generic;

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
    }
}