namespace Ocean.Inside.Project.Models
{
    public class WasteViewModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool IsIncluded { get; set; }

        public int TourId { get; set; }
    }
}