using System;
using System.Collections.Generic;

namespace Ocean.Inside.Domain.Entities
{
    public class GroupTour
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Location { get; set; }
        public string DepartFrom { get; set; }
        public decimal Price { get; set; }
        public Currencies CurrencyCode { get; set; }
        public int DurationDays { get; set; }
        public string ImageUrl { get; set; }

        public List<string> Included { get; set; }
        public List<string> NotIncluded { get; set; }

        public List<DateTime> Dates { get; set; }

        public virtual ICollection<GroupTourImage> Images { get; set; }
        public virtual ICollection<GroupTourProgram> GroupTourPrograms { get; set; }
    }
}
