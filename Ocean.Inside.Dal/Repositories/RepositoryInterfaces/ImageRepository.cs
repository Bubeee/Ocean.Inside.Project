namespace Ocean.Inside.DAL.Repositories.RepositoryInterfaces
{
    using Ocean.Inside.DAL.Infrastructure;
    using Ocean.Inside.Domain.Entities;
    public class ImageRepository : RepositoryBase<Image>, IImageRepository
    {
        public ImageRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }
    }
}
