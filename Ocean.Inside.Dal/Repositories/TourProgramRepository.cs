using Ocean.Inside.Dal.Infrastructure;
using Ocean.Inside.Domain.Entities;

namespace Ocean.Inside.Dal.Repositories
{
    public class TourProgramRepository: RepositoryBase<TourProgram>
    {
        public TourProgramRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}