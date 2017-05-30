using System.Collections.Generic;
using Ocean.Inside.Domain.Entities;

namespace Ocean.Inside.BLL
{
    using System;
    using System.Linq.Expressions;

    public interface ITourService
    {
        IEnumerable<Tour> GetTours();
        IEnumerable<Tour> GetManyTours(Expression<Func<Tour, bool>> where);
        Tour GetTour(int id);
        void CreateTour(Tour tour);
        void EditTour(Tour tour);
        void RemoveTour(Tour tour);
        void SaveTour();


        void AddCheckIn(CheckIn checkIn);
        void RemoveCheckIn(CheckIn checkIn);

        void AddWaste(Waste waste);
        void RemoveWaste(Waste waste);

        void AddStep(TourStep tourStep);
        TourStep GetStep(int id);
        void EditStep(TourStep tourStep);
        void RemoveStep(TourStep tourStep);
    }
}