using AutoMapper;

namespace Ocean.Inside.Project.Mapping
{
    using Ocean.Inside.Domain.Entities;
    using Ocean.Inside.Project.Models;

    public class ImageMappingProfile : Profile
    {
        public ImageMappingProfile()
        {
            CreateMap<Image, ImageViewModel>();

            CreateMap<ImageViewModel, Image>();
        }
    }
}