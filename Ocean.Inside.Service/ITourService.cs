using System.Collections.Generic;
using Ocean.Inside.Domain.Entities;

namespace Ocean.Inside.BLL
{
    public interface ITourService
    {
        IEnumerable<Tour> GetTours();
        Tour GetTour(int id);
        void CreateTour(Tour tour);
        void SaveTour();
    }
}