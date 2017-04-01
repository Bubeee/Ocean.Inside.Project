using Ocean.Inside.Dal.Infrastructure;
using Ocean.Inside.Domain.Entities;

namespace Ocean.Inside.Dal.Repositories
{
    public class TourRepository : RepositoryBase<Tour>
    {
        public TourRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}