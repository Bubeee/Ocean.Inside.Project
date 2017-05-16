namespace Ocean.Inside.Domain.Entities
{
    using System;

    public class CheckIn
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }

        public int TourId { get; set; }

        public virtual Tour Tour { get; set; }
    }
}
