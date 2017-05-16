using System.Collections.Generic;

namespace Ocean.Inside.Domain.Entities
{
    public class Tour
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Place { get; set; }
        public string FlyFrom { get; set; }
        public decimal Price { get; set; }
        public CurrencyCode CurrencyCode { get; set; }
        public int Duration { get; set; }

        public string Hotel { get; set; }
        public int DurationNights { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Image> GalleryImages { get; set; }
        public virtual ICollection<TourStep> TourSteps { get; set; }
        public virtual ICollection<CheckIn> CheckIns { get; set; }
        public virtual ICollection<Waste> Wastes { get; set; }
    }
}