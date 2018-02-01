namespace Ocean.Inside.Domain.Entities
{
    public class Hotel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public HotelStars Stars { get; set; }

        public int CityId { get; set; }
        
        public virtual City City{ get; set; }
    }
}
