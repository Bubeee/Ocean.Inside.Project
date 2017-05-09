using AutoMapper;

namespace Ocean.Inside.Project.Mapping
{
    using Ocean.Inside.Domain.Entities;
    using Ocean.Inside.Project.ViewModels;

    public class GroupTourMappingProfile : Profile
    {
        public GroupTourMappingProfile()
        {
            CreateMap<GroupTour, GroupTourViewModel>();
            CreateMap<GroupTourViewModel, GroupTour>();
        }
    }
}