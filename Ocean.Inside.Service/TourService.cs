using System.Collections.Generic;
using System.Linq;
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
        private readonly IImageRepository _imageRepository;

        public TourService(
            IUnitOfWork unitOfWork, 
            ITourRepository tourRepository, 
            ITourProgramRepository tourProgramRepository, 
            IImageRepository imageRepository)
        {
            _unitOfWork = unitOfWork;
            _tourRepository = tourRepository;
            _tourProgramRepository = tourProgramRepository;
            _imageRepository = imageRepository;
        }

        public IEnumerable<Tour> GetTours()
        {
            var tours = _tourRepository.GetAll().ToList();
            foreach (var tour in tours)
            {
                tour.Images = GetTourImages(tour.Id).ToList();
            }

            return tours;
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

        private IEnumerable<Image> GetTourImages(int tourId)
        {
            return _imageRepository.GetMany(image => image.TourId == tourId);
        }
    }
}