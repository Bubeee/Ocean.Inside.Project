namespace Ocean.Inside.Domain.Entities
{
    public class GroupTourImage
    {
        public int Id { get; set; }
        public int GroupTourId { get; set; }
        public string Path { get; set; }

        public virtual GroupTour Tour { get; set; }
    }
}
