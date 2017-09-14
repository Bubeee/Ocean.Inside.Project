namespace Ocean.Inside.BLL.Services.Implementations
{
    using System.Collections.Generic;

    using Ocean.Inside.BLL.Services.Interfaces;
    using Ocean.Inside.DAL.Infrastructure;
    using Ocean.Inside.DAL.Repositories.RepositoryInterfaces;
    using Ocean.Inside.Domain.Entities;

    public class TestimonialService : ITestimonialService
    {
        private readonly ITestimonialRepository testimonialRepository;
        private readonly IUnitOfWork unitOfWork;

        public TestimonialService(ITestimonialRepository testimonialRepository, IUnitOfWork unitOfWork)
        {
            this.testimonialRepository = testimonialRepository;
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<Testimonial> GetTestimonials()
        {
            return testimonialRepository.GetAll();
        }

        public void AddTestimonial(Testimonial testimonial)
        {
            testimonialRepository.Add(testimonial);
        }

        public void CommitChanges()
        {
            unitOfWork.Commit();
        }

        public void DeleteAll()
        {
            this.testimonialRepository.Delete(testimonial => true);
            this.unitOfWork.Commit();
        }
    }
}
