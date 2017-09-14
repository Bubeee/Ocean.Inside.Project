using AutoMapper;
using Ocean.Inside.Domain.Entities;
using Ocean.Inside.Project.Models;

namespace Ocean.Inside.Project.Mapping
{
    using System.Linq;

    public class TourMappingProfile : Profile
    {
        public TourMappingProfile()
        {
            CreateMap<Tour, TourViewModel>().ForMember(model => model.StartDate, expression => expression.MapFrom(tour => tour.CheckIns.FirstOrDefault().Date));

            CreateMap<TourViewModel, Tour>();
        }
    }
}