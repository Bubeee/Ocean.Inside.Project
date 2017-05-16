using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ocean.Inside.Domain.Entities
{
    public class TourStep
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Day { get; set; }
        public int Duration { get; set; }
        public string Description { get; set; }
        public int TourId { get; set; }

        public virtual Tour Tour { get; set; }
    }
}
