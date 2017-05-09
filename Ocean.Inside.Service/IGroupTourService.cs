using System.Collections.Generic;
using Ocean.Inside.Domain.Entities;

namespace Ocean.Inside.BLL
{
    public interface IGroupTourService
    {
        IEnumerable<GroupTour> GetGroupTours();
        GroupTour GetGroupTour(int id);
    }
}
