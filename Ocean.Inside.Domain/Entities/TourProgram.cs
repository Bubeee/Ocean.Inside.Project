namespace Ocean.Inside.Domain.Entities
{
    public class TourProgram
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int StartingDay { get; set; }
        public int EndingDay { get; set; }
        public string Description { get; set; }

        public int TourId { get; set; }
        public Tour Tour { get; set; }
    }
}
