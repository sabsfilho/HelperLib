namespace HelperLib;

public static class StringHelper
{

    public static string Left(this string s, int len)
    {
        return s.LimitLength(len, string.Empty);
    }

    public static string LimitLength(this string s, int len)
    {
        return s.LimitLength(len, "...");
    }

    public static string LimitLength(this string s, int len, string elipsis)
    {
        int l = len - elipsis.Length;
        return string.IsNullOrEmpty(s) || s.Length < len || l < 1 ? s : string.Concat(s.Substring(0, l), elipsis);
    }

    public static string Right(this string txt, int len)
    {
        return txt.Length > len ? txt.Substring(txt.Length - len) : txt;
    }

    public static string set(this string txt, params object[] args)
    {
        return string.Format(txt, args);
    }
}