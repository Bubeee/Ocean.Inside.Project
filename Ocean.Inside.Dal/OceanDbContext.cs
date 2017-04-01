using System.Data.Entity;
using Ocean.Inside.Domain.Entities;

namespace Ocean.Inside.Dal
{
    public class OceanDbContext : DbContext
    {
        public OceanDbContext() : base("OceanDbContext") { }

        public DbSet<Tour> Tours { get; set; }
        public DbSet<TourProgram> TourPrograms { get; set; }

        public virtual void Commit()
        {
            base.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new TourConfiguration());
            modelBuilder.Configurations.Add(new TourProgramConfiguration());
        }
    }
}
