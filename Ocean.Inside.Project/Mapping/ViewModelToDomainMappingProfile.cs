using AutoMapper;
using Ocean.Inside.Domain.Entities;
using Ocean.Inside.Project.ViewModels;

namespace Ocean.Inside.Project.Mapping
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<TourViewModel, Tour>();
        }
    }
}