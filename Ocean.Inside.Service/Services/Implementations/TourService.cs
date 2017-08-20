namespace Ocean.Inside.BLL.Services.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    using Ocean.Inside.BLL.Services.Interfaces;
    using Ocean.Inside.DAL.Infrastructure;
    using Ocean.Inside.DAL.Repositories.RepositoryInterfaces;
    using Ocean.Inside.Domain.Entities;

    public class TourService : ITourService
    {
        private readonly ITourRepository tourRepository;
        private readonly ICheckInService checkInService;
        private readonly IUnitOfWork unitOfWork;


        public TourService(
            IUnitOfWork unitOfWork,
            ITourRepository tourRepository, 
            ICheckInService checkInService)
        {
            this.unitOfWork = unitOfWork;
            this.tourRepository = tourRepository;
            this.checkInService = checkInService;
        }

        public IEnumerable<Tour> GetTours()
        {
            var tours = this.tourRepository.GetAll().ToList();

            return tours;
        }

        public IEnumerable<Tour> GetManyTours(Expression<Func<Tour, bool>> @where)
        {
            var tours = this.tourRepository.GetMany(where).ToList();

            return tours;
        }

        public Tour GetTour(int id)
        {
            return this.tourRepository.GetById(id);
        }

        public void CreateTour(Tour tour)
        {
            this.tourRepository.Add(tour);
        }

        public void SaveTour()
        {
            this.unitOfWork.Commit();
        }

        public void RemoveTour(Tour tour)
        {
            this.tourRepository.Delete(tour);
            this.SaveTour();
        }

        public void EditTour(Tour tour)
        {
            this.tourRepository.Update(tour);
            foreach (var checkIn in tour.CheckIns)
            {
                checkInService.EditCheckIn(checkIn);
            }

            this.SaveTour();
        }
    }
}