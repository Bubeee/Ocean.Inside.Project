using System;
using System.Collections.Generic;

namespace Ocean.Inside.Domain.Entities
{
    public class Tour
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Hotel { get; set; }
        public string Location { get; set; }
        public string DepartFrom { get; set; }
        public decimal Price { get; set; }
        public Currencies CurrencyCode { get; set; }
        public int DurationDays { get; set; }
        public int DurationNights { get; set; }
        public string ImageUrl { get; set; }

        public DateTime StartDate { get; set; }

        public virtual ICollection<Image> Images { get; set; }
    }
}