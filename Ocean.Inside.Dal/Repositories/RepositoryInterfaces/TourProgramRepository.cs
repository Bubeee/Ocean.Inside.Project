using Ocean.Inside.DAL.Infrastructure;
using Ocean.Inside.DAL.Repositories.RepositoryInterfaces;
using Ocean.Inside.Domain.Entities;

namespace Ocean.Inside.DAL.Repositories
{
    public class TourProgramRepository : RepositoryBase<TourProgram>, ITourProgramRepository
    {
        public TourProgramRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}