namespace Ocean.Inside.BLL.Services.Implementations
{
    using System.Collections.Generic;

    using Ocean.Inside.BLL.Services.Interfaces;
    using Ocean.Inside.DAL.Infrastructure;
    using Ocean.Inside.DAL.Repositories.RepositoryInterfaces;
    using Ocean.Inside.Domain.Entities;

    public class GalleryService : IGalleryService
    {
        private readonly IGalleryRepository galleryRepository;
        private readonly IUnitOfWork unitOfWork;

        public GalleryService(IGalleryRepository galleryRepository, IUnitOfWork unitOfWork)
        {
            this.galleryRepository = galleryRepository;
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<GalleryItem> GetAll()
        {
            return this.galleryRepository.GetAll();
        }

        public void Add(GalleryItem galleryItem)
        {
            this.galleryRepository.Add(galleryItem);
            this.CommitChanges();
        }

        public void Remove(GalleryItem galleryItem)
        {
            this.galleryRepository.Delete(galleryItem);
        }

        public void CommitChanges()
        {
            this.unitOfWork.Commit();
        }

        public void Update(GalleryItem galleryItem)
        {
            this.galleryRepository.Update(galleryItem);
            this.CommitChanges();
        }

        public GalleryItem GetById(int id)
        {
            return this.galleryRepository.GetById(id);
        }
    }
}
