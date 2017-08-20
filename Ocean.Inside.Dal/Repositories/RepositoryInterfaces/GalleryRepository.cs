namespace Ocean.Inside.DAL.Repositories.RepositoryInterfaces
{
    using Ocean.Inside.DAL.Infrastructure;
    using Ocean.Inside.Domain.Entities;
    public class GalleryRepository : RepositoryBase<GalleryItem>, IGalleryRepository
    {
        public GalleryRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }
    }
}