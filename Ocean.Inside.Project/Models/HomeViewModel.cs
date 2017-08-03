namespace Ocean.Inside.Project.Models
{
    using System.Collections.Generic;

    public class HomeViewModel
    {
        public IList<TourViewModel> TourViewModels { get; set; }

        public IList<TestimonialViewModel> Testimonials { get; set; }
    }
}