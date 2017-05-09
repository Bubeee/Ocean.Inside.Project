using System;
using System.Collections.Generic;
using System.Linq;
using Ocean.Inside.DAL.Infrastructure;
using Ocean.Inside.DAL.Repositories.RepositoryInterfaces;
using Ocean.Inside.Domain.Entities;

namespace Ocean.Inside.BLL
{
    public class GroupTourService : IGroupTourService
    {
        private readonly IGroupTourRepository _groupTourRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IImageRepository _imageRepository;

        public GroupTourService(IUnitOfWork unitOfWork, IImageRepository imageRepository, IGroupTourRepository groupTourRepository)
        {
            _unitOfWork = unitOfWork;
            _imageRepository = imageRepository;
            _groupTourRepository = groupTourRepository;
        }

        public IEnumerable<GroupTour> GetGroupTours()
        {
            return _groupTourRepository.GetAll().ToList();
        }

        public GroupTour GetGroupTour(int id)
        {
            return _groupTourRepository.GetById(id);
        }
    }
}