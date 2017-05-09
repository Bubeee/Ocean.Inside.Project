using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Ocean.Inside.Domain.Entities;

namespace Ocean.Inside.DAL.DbConfiguration
{
    public class GroupTourConfiguration : EntityTypeConfiguration<Tour>
    {
        public GroupTourConfiguration()
        {
            ToTable("GroupTour");
            Property(tour => tour.Id).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(tour => tour.Title).IsRequired();
            Property(tour => tour.Price).IsRequired().HasPrecision(10,2);
        }
    }
}