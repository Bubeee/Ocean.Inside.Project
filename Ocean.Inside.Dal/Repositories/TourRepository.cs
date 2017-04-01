using Ocean.Inside.DAL.Infrastructure;
using Ocean.Inside.Domain.Entities;

namespace Ocean.Inside.DAL.Repositories
{
    public class TourRepository : RepositoryBase<Tour>
    {
        public TourRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}