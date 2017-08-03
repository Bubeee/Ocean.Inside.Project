using AutoMapper;
using Ocean.Inside.Project.Mapping;

namespace Ocean.Inside.Project
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(config =>
            {
                config.AddProfile<TourMappingProfile>();
                config.AddProfile<GroupTourMappingProfile>();
                config.AddProfile<ImageMappingProfile>();
                config.AddProfile<CheckInMappingProfile>();
                config.AddProfile<WasteMappingProfile>();
                config.AddProfile<TestimonialMappingProfile>();
            });
        }
    }
}