namespace HelperLib;

public static class ToStringHelper
{
    public static string ToStringHelperHHMM(this TimeSpan d)
    {
        return d.ToString("hh\\:mm");
    }
    public static string ToStringHelperHHMMSS(this TimeSpan d)
    {
        return d.ToString("hh\\:mm\\:ss");
    }

    public static string ToStringHelperDDMMYYYYHHMMSS(this DateTime d)
    {
        return d.ToString("dd/MM/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
    }

    public static string ToStringHelperXML(this DateTime d)
    {
        return d.ToString("yyyyMMddTHHmmss");
    }

    public static string ToStringHelperJS(this DateTime dt)
    {
        return Math.Floor(
            dt
                .Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc))
                .TotalMilliseconds).ToString("f0");
    }

    public static string ToStringHelperDDMMYYYY(this DateTime d)
    {
        return d.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
    }

    public static string ToStringHelperYYYYMMDD(this DateTime d)
    {
        return d.ToString("yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);
    }

    public static string ToStringHelperN2(this double d)
    {
        return d.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
    }
    public static string ToStringHelperN2(this decimal d)
    {
        return d.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
    }
    public static string ToStringHelperNoZeroDecimal(this decimal d)
    {
        if (d.RightPart() == 0)
        {
            return d.ToString("f0", System.Globalization.CultureInfo.InvariantCulture);
        }
        return d.ToString(d.RightPart() == 0 ? "f0" : "0.00", System.Globalization.CultureInfo.InvariantCulture);
    }
}