namespace Ocean.Inside.Domain.Entities
{
    using System.Collections.Generic;

    public class GalleryItem
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Image> Images { get; set; }
    }
}
