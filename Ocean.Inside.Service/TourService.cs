using System.Collections.Generic;
using System.Linq;
using Ocean.Inside.DAL.Infrastructure;
using Ocean.Inside.DAL.Repositories.RepositoryInterfaces;
using Ocean.Inside.Domain.Entities;

namespace Ocean.Inside.BLL
{
    using System;
    using System.Linq.Expressions;

    public class TourService : ITourService
    {
        private readonly ITourRepository tourRepository;
        private readonly ICheckInRepository checkInRepository;
        private readonly IUnitOfWork unitOfWork;

        public TourService(
            IUnitOfWork unitOfWork,
            ITourRepository tourRepository, ICheckInRepository checkInRepository)
        {
            this.unitOfWork = unitOfWork;
            this.tourRepository = tourRepository;
            this.checkInRepository = checkInRepository;
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
            this.SaveTour();
        }

        public void AddCheckIn(CheckIn checkIn)
        {
            checkInRepository.Add(checkIn);
            this.unitOfWork.Commit();
        }

        public void RemoveCheckIn(CheckIn checkIn)
        {
            checkInRepository.Delete(checkIn);
            this.unitOfWork.Commit();
        }

        public void AddWaste(Waste waste)
        {
            throw new NotImplementedException();
        }

        public void RemoveWaste(Waste waste)
        {
            throw new NotImplementedException();
        }

        public void AddStep(TourStep tourStep)
        {
            throw new NotImplementedException();
        }

        public void EditStep(TourStep tourStep)
        {
            throw new NotImplementedException();
        }

        public void RemoveStep(TourStep tourStep)
        {
            throw new NotImplementedException();
        }
    }
}