namespace Ocean.Inside.BLL
{
    using System.Collections.Generic;

    using Domain.Entities;

    public interface IImageService
    {
        IEnumerable<Image> GetImages(int tourId);
        void AddImage(Image image);

        void SaveImage();
    }
}