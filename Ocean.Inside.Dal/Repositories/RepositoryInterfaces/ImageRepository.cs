using Ocean.Inside.DAL.Infrastructure;
using Ocean.Inside.Domain.Entities;

namespace Ocean.Inside.DAL.Repositories.RepositoryInterfaces
{
    public class ImageRepository : RepositoryBase<Image>, IImageRepository
    {
        public ImageRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}