namespace Ocean.Inside.DAL.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        private OceanInsideDbContext _dbContext;
        public OceanInsideDbContext Init()
        {
            return _dbContext ?? (_dbContext = new OceanInsideDbContext());
        }

        protected override void DisposeCore()
        {
            _dbContext?.Dispose();
        }
    }
}