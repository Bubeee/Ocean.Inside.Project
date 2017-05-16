namespace Ocean.Inside.DAL.Repositories.RepositoryInterfaces
{
    using Ocean.Inside.DAL.Infrastructure;
    using Ocean.Inside.Domain.Entities;
    public class CheckInRepository : RepositoryBase<CheckIn>, ICheckInRepository
    {
        public CheckInRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }
    }
}
