using System.Collections.Generic;
using Ocean.Inside.Domain.Entities;

namespace Ocean.Inside.BLL
{
    public interface ITourService
    {
        IEnumerable<Tour> GetTours();
        IEnumerable<TourProgram> GetTourPrograms(string tourId);
        Tour GetTour(int id);
        void CreateTour(Tour tour);
        void SaveTour();
    }
}