namespace Ocean.Inside.Domain.Entities
{
    public class Image
    {
        public int Id { get; set; }
        public string Path { get; set; }
        
        public int? TourId { get; set; }
        public int? GalleryItemId { get; set; }
        public virtual Tour Tour { get; set; }
        public virtual GalleryItem GalleryItem { get; set; }
    }
}