using System.Data.Entity;
using Ocean.Inside.DAL.DbConfiguration;
using Ocean.Inside.Domain.Entities;

namespace Ocean.Inside.DAL
{
    public class OceanInsideDbContext : DbContext
    {
        public OceanInsideDbContext() : base("db_OceanInside") { }

        public DbSet<Tour> Tours { get; set; }
        public Image Images { get; set; }
        public DbSet<TourStep> TourSteps { get; set; }
        public DbSet<CheckIn> CheckIns { get; set; }
        public DbSet<Waste> Wastes { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<GalleryItem> GalleryItems { get; set; }
        public DbSet<Reason> Reasons { get; set; }

        public virtual void Commit()
        {
            base.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new TourConfiguration());
            modelBuilder.Configurations.Add(new ImagesConfiguration());
        }
    }
}