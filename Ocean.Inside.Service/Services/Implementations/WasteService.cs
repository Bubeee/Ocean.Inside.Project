namespace Ocean.Inside.BLL.Services.Implementations
{
    using Ocean.Inside.BLL.Services.Interfaces;
    using Ocean.Inside.DAL.Infrastructure;
    using Ocean.Inside.DAL.Repositories.RepositoryInterfaces;
    using Ocean.Inside.Domain.Entities;

    public class WasteService : IWasteService
    {
        private readonly IWasteRepository wasteRepository;
        private readonly IUnitOfWork unitOfWork;

        public WasteService(IWasteRepository wasteRepository, IUnitOfWork unitOfWork)
        {
            this.wasteRepository = wasteRepository;
            this.unitOfWork = unitOfWork;
        }

        public void AddWaste(Waste waste)
        {
            this.wasteRepository.Add(waste);
            this.unitOfWork.Commit();
        }

        public void RemoveWaste(Waste waste)
        {
            this.wasteRepository.Delete(waste);
        }

        public void CommitChanges()
        {
            this.unitOfWork.Commit();
        }
    }
}
