namespace Ocean.Inside.Project.Models
{
    public class ReasonViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public string Content { get; set; }

        public ImageViewModel Picture { get; set; }
    }
}