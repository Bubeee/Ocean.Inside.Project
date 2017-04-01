using System;
using System.Collections.Generic;

namespace Ocean.Inside.Domain.Entities
{
    public class Tour
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Price { get; set; }
        public float Rating { get; set; }
        public bool IsHot { get; set; }

        public virtual List<TourProgram> Program { get; set; }
    }
}