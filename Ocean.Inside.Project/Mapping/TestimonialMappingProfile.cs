namespace Ocean.Inside.Project.Mapping
{
    using AutoMapper;

    using Ocean.Inside.Domain.Entities;
    using Ocean.Inside.Project.Models;

    public class TestimonialMappingProfile : Profile
    {
        public TestimonialMappingProfile()
        {
            CreateMap<Testimonial, TestimonialViewModel>();

            CreateMap<TestimonialViewModel, Testimonial>();
        }
    }
}