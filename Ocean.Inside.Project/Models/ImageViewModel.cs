namespace Ocean.Inside.Project.Models
{
    using System.Web;

    public class ImageViewModel
    {
        public int Id { get; set; }
        public int TourId { get; set; }
        public string Path { get; set; }

        public HttpPostedFileBase ImageRaw { get; set; }
    }
}