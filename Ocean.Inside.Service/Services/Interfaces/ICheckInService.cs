namespace Ocean.Inside.BLL.Services.Interfaces
{
    using Ocean.Inside.Domain.Entities;

    public interface ICheckInService
    {
        void AddCheckIn(CheckIn checkIn);
        void EditCheckIn(CheckIn checkIn);
        void RemoveCheckIn(CheckIn checkIn);
        void Save();
    }
}