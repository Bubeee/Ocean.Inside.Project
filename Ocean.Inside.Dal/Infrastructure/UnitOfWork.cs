using Ocean.Inside.DAL.Repositories;

namespace Ocean.Inside.DAL.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbFactory _dbFactory;
        private OceanInsideDbContext _dbContext;

        public UnitOfWork(IDbFactory dbFactory)
        {
            this._dbFactory = dbFactory;
        }

        public OceanInsideDbContext DbContext => _dbContext ?? (_dbContext = _dbFactory.Init());

        public void Commit()
        {
            DbContext.Commit();
        }
    }
}