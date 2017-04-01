using System.Collections.Generic;
using Ocean.Inside.Domain.Entities;

namespace Ocean.Inside.BLL
{
    public class TourService : ITourService
    {
        public IEnumerable<Tour> GetGadgets()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Tour> GetCategoryGadgets(string categoryName, string gadgetName = null)
        {
            throw new System.NotImplementedException();
        }

        public Tour GetGadget(int id)
        {
            throw new System.NotImplementedException();
        }

        public void CreateGadget(Tour gadget)
        {
            throw new System.NotImplementedException();
        }

        public void SaveGadget()
        {
            throw new System.NotImplementedException();
        }
    }
}