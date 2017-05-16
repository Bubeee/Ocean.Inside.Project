namespace Ocean.Inside.DAL.Repositories.RepositoryInterfaces
{
    using Ocean.Inside.DAL.Infrastructure;
    using Ocean.Inside.Domain.Entities;
    public class StepRepository : RepositoryBase<TourStep>, IStepRepository
    {
        public StepRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }
    }
}
