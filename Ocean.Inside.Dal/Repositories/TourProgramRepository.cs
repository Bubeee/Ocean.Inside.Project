using Ocean.Inside.DAL.Infrastructure;
using Ocean.Inside.Domain.Entities;

namespace Ocean.Inside.DAL.Repositories
{
    public class TourProgramRepository: RepositoryBase<TourProgram>
    {
        public TourProgramRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}