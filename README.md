# HelperLib a useful helper library

*Avoid the wheel reinvention*

**DateHelper** (DateTime extension static methods):<br/>
  *GetHolidaysInBrazilWithKeys, IsWorkdayInBrazil, GetNextWorkdayInBrazil, GetPreviousWorkdayInBrazil* => These methods help to identify if the a requested day is a Brazilian Holiday<br/>
  *FirstDayOfYear, LastDayOfYear, FirstDayOfMonth, LastDayOfMonth, FirstDayOfWeek* => These methods help to easily get a specified date<br/>
  *IsBetween, IsBetweenInclusive* => These methods help easily to compare a date range<br/>

**NetworkHelper**<br/>
  *Ping* => Returns true if the host respond to a ping signal<br/>
  *CheckServerPort* => Returns true if the host respond on the specified port<br/>
  *GetLocalIPAddress* => Returns the Local IP address<br/>
  *GetHostName* => Returns the Local DNS name<br/>

**NumberHelper** (Decimal extension static methods):<br/>
  *IsBetween, IsBetweenInclusive* => These methods help easily to compare a number range<br/>
  *RightPart* => Returns the decimal part of a non integer number<br/>
  *ConvertToSize, ToSize*/ => Convert number to Byte, KB, MB, GB, TB, PB, EB, ZB, YB<br/>

**StringHelper** (String extension static methods): <br/>
  *Left,Right* => Returns a defined portion of the string<br/>
  *LimitLength* => Returns the string limited to a number of characters. It's possible to put ellipsis in the end.<br/>
  *set* => a convenient way to use the string Format method<br/>

**ToStringHelper** (String extension static methods): <br/>
  methods to format a string
  

**__document under construction__**

*This project is a small piece of a broader brownfield project for modernizing our .NET Framework ecosystem. I am creating and migrating methods on demand here.*
