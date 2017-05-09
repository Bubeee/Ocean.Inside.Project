namespace Ocean.Inside.Domain.Entities
{
    public class GroupTourProgram
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int StartingDay { get; set; }
        public int Duration { get; set; }
        public string Description { get; set; }

        public int GroupTourId { get; set; }
        public virtual GroupTour GroupTour { get; set; }
    }
}
