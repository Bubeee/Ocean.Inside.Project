namespace Ocean.Inside.Domain.Entities
{
    public class Waste
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool IsIncluded { get; set; }

        public int TourId { get; set; }

        public virtual Tour Tour { get; set; }
    }
}
