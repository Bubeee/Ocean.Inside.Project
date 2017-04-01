using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Ocean.Inside.Domain.Entities;

namespace Ocean.Inside.DAL
{
    public class TourProgramConfiguration : EntityTypeConfiguration<TourProgram>
    {
        public TourProgramConfiguration()
        {
            ToTable("TourProgram");
            Property(tourProgram => tourProgram.Id).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(tourProgram => tourProgram.TourId).IsRequired();
            Property(tourProgram => tourProgram.StartingDay).IsRequired();
            Property(tourProgram => tourProgram.EndingDay).IsRequired();
            Property(tourProgram => tourProgram.Description).IsRequired().HasMaxLength(int.MaxValue);
        }
    }
}