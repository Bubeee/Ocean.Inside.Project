using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Ocean.Inside.Domain.Entities;

namespace Ocean.Inside.DAL.DbConfiguration
{
    public class TourProgramConfiguration : EntityTypeConfiguration<GroupTourProgram>
    {
        public TourProgramConfiguration()
        {
            ToTable("TourProgram");
            Property(tourProgram => tourProgram.Id).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(tourProgram => tourProgram.GroupTourId).IsRequired();
            Property(tourProgram => tourProgram.StartingDay).IsRequired();
            Property(tourProgram => tourProgram.Duration).IsRequired();
            Property(tourProgram => tourProgram.Description).IsRequired().HasMaxLength(int.MaxValue);
        }
    }
}