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
        private readonly IWasteRepository wasteRepository;
        private readonly IStepRepository stepRepository;
        private readonly IUnitOfWork unitOfWork;

        public TourService(
            IUnitOfWork unitOfWork,
            ITourRepository tourRepository, ICheckInRepository checkInRepository, IWasteRepository wasteRepository, IStepRepository stepRepository)
        {
            this.unitOfWork = unitOfWork;
            this.tourRepository = tourRepository;
            this.checkInRepository = checkInRepository;
            this.wasteRepository = wasteRepository;
            this.stepRepository = stepRepository;
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
                EditCheckIn(checkIn);
            }

            this.SaveTour();
        }

        public void AddCheckIn(CheckIn checkIn)
        {
            this.checkInRepository.Add(checkIn);
            this.unitOfWork.Commit();
        }

        public void EditCheckIn(CheckIn checkIn)
        {
            this.checkInRepository.Update(checkIn);
            this.SaveTour();
        }

        public void RemoveCheckIn(CheckIn checkIn)
        {
            this.checkInRepository.Delete(checkIn);
            this.unitOfWork.Commit();
        }

        public void AddWaste(Waste waste)
        {
            this.wasteRepository.Add(waste);
            this.unitOfWork.Commit();
        }

        public void RemoveWaste(Waste waste)
        {
            this.wasteRepository.Delete(waste);
            this.unitOfWork.Commit();
        }

        public void AddStep(TourStep tourStep)
        {
            this.stepRepository.Add(tourStep);
            this.unitOfWork.Commit();
        }

        public void EditStep(TourStep tourStep)
        {
            this.stepRepository.Update(tourStep);
            this.unitOfWork.Commit();
        }

        public void RemoveStep(TourStep tourStep)
        {
            this.stepRepository.Delete(tourStep);
            this.unitOfWork.Commit();
        }

        public TourStep GetStep(int id)
        {
            return this.stepRepository.GetById(id);
        }
    }
}