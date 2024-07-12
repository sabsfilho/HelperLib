using System.Globalization;

namespace HelperLib;

internal static class GlobalInfo
{
    public static string SystemLocale = "pt-BR";
    public static CultureInfo CULTURE = CultureInfo.GetCultureInfo(SystemLocale);
}