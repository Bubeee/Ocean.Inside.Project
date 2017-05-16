using System.Data.Entity;
using Ocean.Inside.DAL.DbConfiguration;
using Ocean.Inside.Domain.Auth;
using Ocean.Inside.Domain.Entities;

namespace Ocean.Inside.DAL
{
    public class OceanInsideDbContext : DbContext
    {
        public OceanInsideDbContext() : base("db_OceanInside") { }

        public DbSet<Tour> Tours { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<TourStep> TourSteps { get; set; }
        public DbSet<CheckIn> CheckIns { get; set; }
        public DbSet<Waste> Wastes { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

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