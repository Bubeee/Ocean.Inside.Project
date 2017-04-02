using Ocean.Inside.DAL.Infrastructure;
using Ocean.Inside.Domain.Entities;

namespace Ocean.Inside.DAL.Repositories.RepositoryInterfaces
{
    public class TourRepository : RepositoryBase<Tour>, ITourRepository
    {
        public TourRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}