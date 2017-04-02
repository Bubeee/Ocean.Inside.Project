using System.Collections.Generic;
using Ocean.Inside.DAL.Infrastructure;
using Ocean.Inside.DAL.Repositories.RepositoryInterfaces;
using Ocean.Inside.Domain.Entities;

namespace Ocean.Inside.BLL
{
    public class TourService : ITourService
    {
        private readonly ITourRepository _tourRepository;
        private readonly ITourProgramRepository _tourProgramRepository;
        private readonly IUnitOfWork _unitOfWork;

        public TourService(IUnitOfWork unitOfWork, ITourRepository tourRepository, ITourProgramRepository tourProgramRepository)
        {
            _unitOfWork = unitOfWork;
            _tourRepository = tourRepository;
            _tourProgramRepository = tourProgramRepository;
        }

        public IEnumerable<Tour> GetTours()
        {
            return _tourRepository.GetAll();
        }

        public IEnumerable<TourProgram> GetTourPrograms(string tourId)
        {
            throw new System.NotImplementedException();
        }

        public Tour GetTour(int id)
        {
            return _tourRepository.GetById(id);
        }

        public void CreateTour(Tour tour)
        {
            _tourRepository.Add(tour);
        }

        public void SaveTour()
        {
            _unitOfWork.Commit();
        }
    }
}