namespace Ocean.Inside.BLL.Services.Implementations
{
    using Ocean.Inside.BLL.Services.Interfaces;
    using Ocean.Inside.DAL.Infrastructure;
    using Ocean.Inside.DAL.Repositories.RepositoryInterfaces;
    using Ocean.Inside.Domain.Entities;

    public class StepService : IStepService
    {
        private readonly IStepRepository stepRepository;
        private readonly IUnitOfWork unitOfWork;

        public StepService(IStepRepository stepRepository, IUnitOfWork unitOfWork)
        {
            this.stepRepository = stepRepository;
            this.unitOfWork = unitOfWork;
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
        }

        public TourStep GetStep(int id)
        {
            return this.stepRepository.GetById(id);
        }

        public void CommitChanges()
        {
            this.unitOfWork.Commit();
        }
    }
}
