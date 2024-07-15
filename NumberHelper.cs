namespace HelperLib;
public static class NumberHelper
{
    public enum ByteSizeUnitsEnum
    {
        Byte, KB, MB, GB, TB, PB, EB, ZB, YB
    }
    public static bool IsBetweenInclusive(this decimal n, decimal min, decimal max)
    {
        return n >= min && n <= max;
    }
    public static bool IsBetween(this decimal n, decimal min, decimal max)
    {
        return n > min && n < max;
    }
    public static bool IsBetweenInclusive(this int n, int min, int max)
    {
        return n >= min && n <= max;
    }
    public static bool IsBetween(this int n, int min, int max)
    {
        return n > min && n < max;
    }
    public static decimal RightPart(this decimal n)
    {
        return Math.Abs(n % 1);
    }
    public static void GetGroupRange(this decimal v, decimal range, bool forceGroup, out decimal min, out decimal max)
    {
        min = max = 0;
        decimal r = (range * 2m);
        decimal d = v % r;
        min = v - d;
        if (forceGroup && d == 0)
        {
            min -= r;
        }
        max = min + r;
    }
    public static double ConvertToSize(this long value, ByteSizeUnitsEnum unit)
    {
        return (value / (double)Math.Pow(1024, (long)unit));
    }

    public static string ToSize(this long value, ByteSizeUnitsEnum unit)
    {
        return string.Concat(ConvertToSize(value, unit).ToString("0.00"), unit.ToString());
    }
    public static string ToSize(this ulong value, ByteSizeUnitsEnum unit)
    {
        return string.Concat((value / (double)Math.Pow(1024, (ulong)unit)).ToString("0.00"), unit.ToString());
    }
}
