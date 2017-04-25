using AutoMapper;
using Ocean.Inside.Domain.Entities;
using Ocean.Inside.Project.ViewModels;

namespace Ocean.Inside.Project.Mapping
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Tour, TourViewModel>();
        }
    }
}