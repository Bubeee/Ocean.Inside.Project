using System;

namespace Ocean.Inside.DAL.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        OceanInsideDbContext Init();
    }
}