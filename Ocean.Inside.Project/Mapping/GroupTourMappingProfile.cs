using AutoMapper;

namespace Ocean.Inside.Project.Mapping
{
    using System.Linq;

    using Ocean.Inside.Domain.Entities;
    using Ocean.Inside.Project.Models;

    public class GroupTourMappingProfile : Profile
    {
        public GroupTourMappingProfile()
        {
            CreateMap<Tour, GroupTourViewModel>();
            CreateMap<TourStep, TourStepViewModel>();
            CreateMap<TourStepViewModel, TourStep>();

            CreateMap<GroupTourViewModel, Tour>();
        }
    }
}