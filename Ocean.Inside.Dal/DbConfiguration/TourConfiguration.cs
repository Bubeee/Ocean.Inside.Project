using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Ocean.Inside.Domain.Entities;

namespace Ocean.Inside.DAL.DbConfiguration
{
    public class TourConfiguration : EntityTypeConfiguration<Tour>
    {
        public TourConfiguration()
        {
            ToTable("Tour");
            Property(tour => tour.Id).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(tour => tour.Title).IsRequired();
            Property(tour => tour.Price).IsRequired().HasPrecision(10,2);

            //HasOptional(t => t.GalleryImages).WithOptionalPrincipal().WillCascadeOnDelete(true);
            //HasOptional(t => t.CheckIns).WithOptionalPrincipal().WillCascadeOnDelete(true);
            //HasOptional(t => t.TourSteps).WithOptionalPrincipal().WillCascadeOnDelete(true);
            //HasOptional(t => t.Wastes).WithOptionalPrincipal().WillCascadeOnDelete(true);
        }
    }
}