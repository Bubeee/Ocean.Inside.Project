namespace Ocean.Inside.BLL.Services.Interfaces
{
    using System.Collections.Generic;

    using Domain.Entities;

    public interface ITestimonialService
    {
        IEnumerable<Testimonial> GetTestimonials();
        
        void AddTestimonial(Testimonial testimonial);

        void Save();
    }
}