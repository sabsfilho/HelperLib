namespace HelperLib;

public static class DateHelper
{
    public static DateTime FirstDayOfYear(this DateTime dt)
    {
        return new DateTime(dt.Year, 1, 1);
    }

    public static DateTime LastDayOfYear(this DateTime dt)
    {
        return new DateTime(dt.Year, 12, 31);
    }

    public static DateTime FirstDayOfMonth(this DateTime dt)
    {
        return new DateTime(dt.Year, dt.Month, 1);
    }

    public static DateTime LastDayOfMonth(this DateTime dt)
    {
        return FirstDayOfMonth(dt.AddMonths(1)).AddDays(-1);
    }

    public static DateTime FirstDayOfWeek(this DateTime dt)
    {
        return dt.AddDays(DayOfWeek.Sunday - dt.DayOfWeek);
    }

    public static bool IsWeekend(this DateTime dt)
    {
        return dt.DayOfWeek == DayOfWeek.Saturday || dt.DayOfWeek == DayOfWeek.Sunday;
    }

    public static bool IsWorkdayInBrazil(this DateTime dt)
    {
        return !IsWeekend(dt) && !GetHolidaysInBrazil(dt).Contains(dt.Date);
    }
    public static DateTime GetNextWorkdayInBrazil(this DateTime dt, int days)
    {
        var dtx = dt;

        for (int i = 0; i < days; i++)
        {
            dtx = dtx.GetNextWorkdayInBrazil();
        }

        return dtx;
    }
    public static DateTime GetNextWorkdayInBrazil(this DateTime dt)
    {
        var dt2 = GetNextWorkday(dt, GetHolidaysInBrazil(dt));
        if (dt2.Year != dt.Year)
        {
            var hs = GetHolidaysInBrazil(dt2);
            if (hs.Contains(dt2.Date))
            {
                dt2 = dt2.GetNextWorkday(hs);
            }
        }
        return dt2;
    }
    public static DateTime GetNextWorkday(this DateTime dt, DateTime[] holidays)
    {
        return GetWorkday(dt, false, holidays);
    }
    public static DateTime GetPreviousWorkdayInBrazil(this DateTime dt, int days)
    {
        var dtx = dt;

        for (int i = 0; i < days; i++)
        {
            dtx = dtx.GetPreviousWorkdayInBrazil();
        }

        return dtx;
    }
    public static DateTime GetPreviousWorkdayInBrazil(this DateTime dt)
    {
        return GetPreviousWorkday(dt, GetHolidaysInBrazil(dt));
    }
    public static DateTime GetPreviousWorkday(this DateTime dt, DateTime[] holidays)
    {
        var dt2 = GetWorkday(dt, true, holidays);
        if (dt2.Year != dt.Year)
        {
            var hs = GetHolidaysInBrazil(dt2);
            if (hs.Contains(dt2.Date))
            {
                dt2 = dt2.GetPreviousWorkday(hs);
            }
        }
        return dt2;
    }
    private static DateTime GetWorkday(this DateTime dt, bool previous, DateTime[] holidays)
    {
        int q = 0;
        var d = dt.AddDays(previous ? -1 : 1);
        while (++q < 30 && (d.IsWeekend() || (holidays != null && holidays.Contains(d.Date))))
            d = d.AddDays(previous ? -1 : 1);
        return d;
    }

    public static DateTime[] GetHolidaysInBrazil(this DateTime dt)
    {
        return GetHolidaysInBrazil(dt.Year);
    }
    public static DateTime[] GetHolidaysInBrazil(int year)
    {
        return GetHolidaysInBrazilWithKeys(year).Keys.ToArray();
    }
    public static SortedDictionary<DateTime, string> GetHolidaysInBrazilWithKeys(int year)
    {
        var lst = new SortedDictionary<DateTime, string>();

        lst.Add(new DateTime(year, 1, 1), "AnoNovo1"); // ano novo

        if (year < 2022)
        {
            lst.Add(new DateTime(year, 1, 25), "AniversarioSP"); // aniversário são paulo
        }

        lst.Add(new DateTime(year, 4, 21), "Tiradentes"); // tiradentes
        lst.Add(new DateTime(year, 5, 1), "Trabalho"); // dia do trabalho

        if (year != 2020 && year < 2024)
        {
            lst.Add(new DateTime(year, 7, 9), "RevolucaoConstitucionalista"); // revolução constitucionalista
        }

        lst.Add(new DateTime(year, 9, 7), "Independencia"); // independencia
        lst.Add(new DateTime(year, 10, 12), "Aparecida"); // aparecida	
        lst.Add(new DateTime(year, 11, 2), "Finados"); // finados
        lst.Add(new DateTime(year, 11, 15), "Republica"); // proclamação da república
        if (year >= 2020 && year != 2023)
        {
            lst.Add(new DateTime(year, 11, 20), "ConscienciaNegra"); // consciência negra
        }

        lst.Add(new DateTime(year, 12, 24), "Natal2"); // natal
        lst.Add(new DateTime(year, 12, 25), "Natal1"); // natal
        var lastDay = new DateTime(year, 12, 31);
        lst.Add(lastDay, "AnoNovo2"); // ano novo
        if (lastDay.DayOfWeek == DayOfWeek.Saturday)
        {
            lst.Add(new DateTime(year, 12, 30), "AnoNovo2"); // ano novo
        }
        else if (lastDay.DayOfWeek == DayOfWeek.Sunday)
        {
            lst.Add(new DateTime(year, 12, 29), "AnoNovo2"); // ano novo
        }

        var pascoa = GetEaster(year);

        lst.Add(pascoa.AddDays(60), "CorpusChristi"); // Corpus Christi
        lst.Add(pascoa.AddDays(-2), "PaixaoCristo"); // Paixao Cristo
        lst.Add(pascoa.AddDays(-48), "Carnaval2a"); // 2a Carnaval
        lst.Add(pascoa.AddDays(-47), "Carnaval3a"); // 3a Carnaval

        return lst;

    }

    public static DateTime GetEaster(this DateTime dt)
    {
        return GetEaster(dt.Year);
    }

    public static DateTime GetEaster(int year)
    {
        double a = year % 19;
        double b = Math.Floor(year / 100.0);
        double c = year % 100;
        double d = Math.Floor(b / 4.0);
        double e = b % 4;
        double f = Math.Floor((b + 8) / 25.0);
        double g = Math.Floor((b - f + 1) / 3.0);
        double h = (19 * a + b - d - g + 15.0) % 30;
        double i = Math.Floor(c / 4);
        double k = c % 4;
        double l = (32 + 2 * e + 2 * i - h - k) % 7;
        double m = Math.Floor((a + 11 * h + 22 * l) / 451);
        int mth = Convert.ToInt32(Math.Floor((h + l - 7 * m + 114) / 31));
        int day = Convert.ToInt32(((h + l - 7 * m + 114) % 31) + 1);

        return new DateTime(year, mth, day);
    }


    public static bool IsBetweenInclusive(this DateTime n, DateTime min, DateTime max)
    {
        return n >= min && n <= max;
    }
    public static bool IsBetween(this DateTime n, DateTime min, DateTime max)
    {
        return n > min && n < max;
    }

    public static DateTime? Parse(string s)
    {
        return Parse(s, "dd/MM/yyyy");
    }

    public static DateTime? Parse(string s, string fmt)
    {
        DateTime dt;
        if (DateTime.TryParseExact(s, fmt, GlobalInfo.CULTURE, System.Globalization.DateTimeStyles.None, out dt))
        {
            return dt;
        }
        return null;
    }
}
