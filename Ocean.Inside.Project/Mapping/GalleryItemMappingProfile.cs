namespace Ocean.Inside.Project.Mapping
{
    using AutoMapper;

    using Ocean.Inside.Domain.Entities;
    using Ocean.Inside.Project.Models;

    public class GalleryItemMappingProfile : Profile
    {
        public GalleryItemMappingProfile()
        {
            this.CreateMap<GalleryItem, GalleryItemViewModel>();
            this.CreateMap<GalleryItemViewModel, GalleryItem>();
        }
    }
}