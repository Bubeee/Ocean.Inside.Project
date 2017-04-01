using System;

namespace Ocean.Inside.Dal.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        private OceanDbContext _dbContext;
        public OceanDbContext Init()
        {
            return _dbContext ?? (_dbContext = new OceanDbContext());
        }

        protected override void DisposeCore()
        {
            _dbContext?.Dispose();
        }
    }
}