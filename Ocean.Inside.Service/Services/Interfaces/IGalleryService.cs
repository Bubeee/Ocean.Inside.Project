namespace Ocean.Inside.BLL.Services.Interfaces
{
    using System.Collections.Generic;

    using Ocean.Inside.Domain.Entities;

    public interface IGalleryService
    {
        IEnumerable<GalleryItem> GetAll();
        GalleryItem GetById(int id);
        void Add(GalleryItem galleryItem);
        void Update(GalleryItem galleryItem);

        void Remove(GalleryItem galleryItem);

        void SaveChanges();
    }
}