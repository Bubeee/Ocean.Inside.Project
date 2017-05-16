using AutoMapper;

namespace Ocean.Inside.Project.Mapping
{
    using Ocean.Inside.Domain.Entities;
    using Ocean.Inside.Project.Models;

    public class WasteMappingProfile : Profile
    {
        public WasteMappingProfile()
        {
            CreateMap<Waste, WasteViewModel>();

            CreateMap<WasteViewModel, Waste>();
        }
    }
}