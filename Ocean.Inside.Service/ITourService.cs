using System.Collections.Generic;
using Ocean.Inside.Domain.Entities;

namespace Ocean.Inside.BLL
{
    public interface ITourService
    {
        IEnumerable<Tour> GetGadgets();
        IEnumerable<Tour> GetCategoryGadgets(string categoryName, string gadgetName = null);
        Tour GetGadget(int id);
        void CreateGadget(Tour gadget);
        void SaveGadget();
    }
}
