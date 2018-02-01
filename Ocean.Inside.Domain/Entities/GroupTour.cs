namespace Ocean.Inside.Domain.Entities
{
    using System.Collections.Generic;

    public class GroupTour : Tour
    {
        public bool IsHot { get; set; }

        public virtual IList<Image> GalleryImages { get; set; }
        public virtual IList<TourStep> TourSteps { get; set; }
        public virtual IList<CheckIn> CheckIns { get; set; }
        public virtual IList<Waste> Wastes { get; set; }
    }
}