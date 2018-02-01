namespace Ocean.Inside.Domain.Entities
{
    using System.Collections.Generic;

    public class Country
    {
        public int Id { get; set; }

        public string Name { get; set; }
        
        public virtual IList<City> Cities { get; set; }
    }
}
