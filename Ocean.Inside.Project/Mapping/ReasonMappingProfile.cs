using AutoMapper;
using Ocean.Inside.Domain.Entities;
using Ocean.Inside.Project.Models;

namespace Ocean.Inside.Project.Mapping
{
    public class ReasonMappingProfile : Profile
    {
        public ReasonMappingProfile()
        {
            CreateMap<Reason, ReasonViewModel>().ReverseMap();
        }
    }
}