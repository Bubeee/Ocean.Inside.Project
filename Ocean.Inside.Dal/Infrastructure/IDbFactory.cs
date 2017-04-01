using System;

namespace Ocean.Inside.Dal.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        OceanDbContext Init();
    }
}