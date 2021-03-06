﻿namespace Ocean.Inside.DAL.Repositories.RepositoryInterfaces
{
    using Ocean.Inside.DAL.Infrastructure;
    using Ocean.Inside.Domain.Entities;

    public class WasteRepository :RepositoryBase<Waste>, IWasteRepository
    {
        public WasteRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }
    }
}
