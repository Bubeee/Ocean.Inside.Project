namespace Ocean.Inside.BLL.Services.Interfaces
{
    using Ocean.Inside.Domain.Entities;

    public interface IStepService
    {
        void AddStep(TourStep tourStep);
        TourStep GetStep(int id);
        void EditStep(TourStep tourStep);
        void RemoveStep(TourStep tourStep);
        void CommitChanges();
    }
}