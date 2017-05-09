using Ocean.Inside.DAL.Infrastructure;
using Ocean.Inside.Domain.Entities;

namespace Ocean.Inside.DAL.Repositories.RepositoryInterfaces
{
    public class GroupTourRepository : RepositoryBase<GroupTour>, IGroupTourRepository
    {
        public GroupTourRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}