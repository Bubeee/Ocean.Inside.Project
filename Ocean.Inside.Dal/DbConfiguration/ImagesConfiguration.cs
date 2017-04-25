using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Ocean.Inside.Domain.Entities;

namespace Ocean.Inside.DAL.DbConfiguration
{
    public class ImagesConfiguration : EntityTypeConfiguration<Image>
    {
        public ImagesConfiguration()
        {
            ToTable("Image");
            Property(image => image.Id).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(image => image.TourId).IsRequired();
            Property(image => image.Path).IsRequired();
        }
    }
}
