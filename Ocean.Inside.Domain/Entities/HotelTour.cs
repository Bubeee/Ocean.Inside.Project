namespace Ocean.Inside.Domain.Entities
{
    public class HotelTour : Tour
    {
        public int HotelId { get; set; }
        public virtual Hotel Hotel { get; set; }
    }
}