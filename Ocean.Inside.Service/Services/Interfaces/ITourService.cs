namespace Ocean.Inside.BLL.Services.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    using Ocean.Inside.Domain.Entities;

    public interface ITourService
    {
        IEnumerable<Tour> GetTours();
        IEnumerable<Tour> GetManyTours(Expression<Func<Tour, bool>> where);
        Tour GetTour(int id);
        void CreateTour(Tour tour);
        void EditTour(Tour tour);
        void RemoveTour(Tour tour);
        void SaveTour();
    }
}