namespace Ocean.Inside.DAL.Repositories.RepositoryInterfaces
{
    using System.Collections.Generic;
    using System.Linq;

    using Ocean.Inside.DAL.Infrastructure;
    using Ocean.Inside.Domain.Entities;
    public class StepRepository : RepositoryBase<TourStep>, IStepRepository
    {
        public StepRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }

        public override IEnumerable<TourStep> GetAll()
        {
            return _dbSet.OrderBy(step => step.Day).ToList();
        }
    }
}
