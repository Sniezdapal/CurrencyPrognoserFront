using System;

public static class Extensions
{
    public static long ToTimestamp(this DateTime date)
    {
        var t = new DateTime(1970, 1, 1, 0, 0, 0);
        TimeSpan span = date - t;
        return (long)span.TotalSeconds;
    }

    public static DateTime FromTimestamp(this string timestamp)
    {
        var t = new DateTime(1970, 1, 1, 0, 0, 0);
        t = t.AddSeconds(long.Parse(timestamp));
        return t;
    }
}