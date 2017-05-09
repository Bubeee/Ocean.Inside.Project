using AutoMapper;
using Ocean.Inside.Domain.Entities;
using Ocean.Inside.Project.ViewModels;

namespace Ocean.Inside.Project.Mapping
{
    public class TourMappingProfile : Profile
    {
        public TourMappingProfile()
        {
            CreateMap<Tour, TourViewModel>();
            CreateMap<TourViewModel, Tour>();
        }
    }
}