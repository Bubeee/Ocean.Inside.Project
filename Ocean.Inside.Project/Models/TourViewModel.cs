namespace Ocean.Inside.Project.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    using FluentValidation.Attributes;

    using Ocean.Inside.Domain.Entities;
    using Ocean.Inside.Project.Validators;

    [Validator(typeof(TourValidator))]
    public class TourViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public string Hotel { get; set; }
        public string Place { get; set; }
        public string FlyFrom { get; set; }
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
        public CurrencyCode CurrencyCode { get; set; }
        public int Duration { get; set; }
        [DataType(DataType.ImageUrl)]
        public ImageViewModel CoverImage
        {
            get
            {
                var firstImage = this.GalleryImages?.FirstOrDefault();
                if (firstImage == null)
                {
                    return new ImageViewModel
                    {
                        Path = "/images/270x240.jpg"
                    };
                }

                return firstImage;
            }

        }

        public bool IsHot { get; set; }

        public DateTime StartDate { get; set; }

        public IList<CheckIn> CheckIns { get; set; }

        public IEnumerable<ImageViewModel> GalleryImages { get; set; }

        public int DurationNights { get; set; }

        public IEnumerable<TourViewModel> OtherTours { get; set; }
    }
}