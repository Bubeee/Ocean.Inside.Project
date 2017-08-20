namespace Ocean.Inside.BLL.Services.Interfaces
{
    using Ocean.Inside.Domain.Entities;

    public interface IWasteService
    {
        void AddWaste(Waste waste);
        void RemoveWaste(Waste waste);
        void Save();
    }
}