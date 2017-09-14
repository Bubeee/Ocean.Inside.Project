namespace Ocean.Inside.BLL.Services.Interfaces
{
    using System.Collections.Generic;

    using Ocean.Inside.Domain.Entities;

    public interface IImageService
    {
        IEnumerable<Image> GetImages(int tourId);
        void AddImage(Image image);

        void RemoveImage(Image image);

        void CommitChanges();
    }
}