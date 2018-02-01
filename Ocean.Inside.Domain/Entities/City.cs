namespace Ocean.Inside.Domain.Entities
{
    using System.Collections.Generic;

    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int CountryId { get; set; }
        public virtual Country Country { get; set; }
        public virtual IList<Hotel> Hotels { get; set; }
    }
}
