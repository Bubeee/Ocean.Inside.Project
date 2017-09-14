namespace Ocean.Inside.BLL.Services.Implementations
{
    using Ocean.Inside.BLL.Services.Interfaces;
    using Ocean.Inside.DAL.Infrastructure;
    using Ocean.Inside.DAL.Repositories.RepositoryInterfaces;
    using Ocean.Inside.Domain.Entities;

    public class CheckInService : ICheckInService
    {
        private readonly ICheckInRepository checkInRepository;
        private readonly IUnitOfWork unitOfWork;

        public CheckInService(ICheckInRepository checkInRepository, IUnitOfWork unitOfWork)
        {
            this.checkInRepository = checkInRepository;
            this.unitOfWork = unitOfWork;
        }
        
        public void AddCheckIn(CheckIn checkIn)
        {
            this.checkInRepository.Add(checkIn);
            this.unitOfWork.Commit();
        }

        public void EditCheckIn(CheckIn checkIn)
        {
            this.checkInRepository.Update(checkIn);
            this.CommitChanges();
        }

        public void RemoveCheckIn(CheckIn checkIn)
        {
            this.checkInRepository.Delete(checkIn);
            this.unitOfWork.Commit();
        }

        public void CommitChanges()
        {
            this.unitOfWork.Commit();
        }
    }
}
