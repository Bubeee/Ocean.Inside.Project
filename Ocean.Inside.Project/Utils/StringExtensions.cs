using System.Globalization;
using System.Linq;
using Ocean.Inside.Domain.Entities;

namespace Ocean.Inside.Project.Utils
{
    public static class StringExtensions
    {
        public static string CurrencyCodeToSymbol(this CurrencyCode currencyCode)
        {
            var symbol = CultureInfo
                .GetCultures(CultureTypes.AllCultures)
                .Where(c => !c.IsNeutralCulture)
                .Select(culture =>
                {
                    try
                    {
                        return new RegionInfo(culture.LCID);
                    }
                    catch
                    {
                        return null;
                    }
                })
                .Where(regionInfo => regionInfo != null && regionInfo.ISOCurrencySymbol == currencyCode.ToString())
                .Select(regionInfo => regionInfo.CurrencySymbol)
                .FirstOrDefault();

            return symbol;
        }
    }
}