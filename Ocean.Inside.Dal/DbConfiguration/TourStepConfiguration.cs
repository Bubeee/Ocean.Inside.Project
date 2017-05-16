using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Ocean.Inside.Domain.Entities;

namespace Ocean.Inside.DAL.DbConfiguration
{
    public class TourStepConfiguration : EntityTypeConfiguration<TourStep>
    {
        public TourStepConfiguration()
        {
            ToTable("TourStep");
            Property(step => step.Id).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(step => step.Title).IsRequired();
            Property(step => step.TourId).IsRequired();
            Property(step => step.Description).IsRequired();
        }
    }
}