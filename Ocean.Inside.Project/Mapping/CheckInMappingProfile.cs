using AutoMapper;

namespace Ocean.Inside.Project.Mapping
{
    using Ocean.Inside.Domain.Entities;
    using Ocean.Inside.Project.Models;

    public class CheckInMappingProfile : Profile
    {
        public CheckInMappingProfile()
        {
            CreateMap<CheckIn, CheckInViewModel>();

            CreateMap<CheckInViewModel, CheckIn>();
        }
    }
}