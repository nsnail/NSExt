// @program: NSExt
// @file: DateTimeExtensions.cs
// @author: tao ke
// @mailto: taokeu@gmail.com
// @created: 07/15/2022 16:49

// ReSharper disable UnusedMember.Global

namespace NSExt;

public static class DateTimeExtensions
{
    /// <summary>
    ///     将一个过去时间对象与当前时间相减转换成“xx以前”的字符串，如2秒以前，3天以前
    /// </summary>
    /// <param name="me">时间对象</param>
    /// <returns>字符串</returns>
    public static string TimeAgo(this DateTime me)
    {
        var ts = DateTime.Now - me;
        if (ts.Days > 0) return ts.Days + "天前";

        if (ts.Hours > 0) return ts.Hours + "小时前";

        if (ts.Minutes > 0) return ts.Minutes + "分钟前";

        return ts.Seconds + "秒前";
    }


    /// <summary>
    ///     指定时间的世界协调时的unix时间戳形式
    /// </summary>
    /// <param name="me">指定时间</param>
    /// <returns>unix时间戳</returns>
    public static long TimeUnixUtc(this DateTime me)
    {
        return (me.ToUniversalTime().Ticks - 621355968000000000) / 10000000;
    }

    /// <summary>
    ///     指定时间的世界协调时的unix时间戳形式（毫秒）
    /// </summary>
    /// <param name="me"></param>
    /// <returns></returns>
    public static long TimeUnixUtcMs(this DateTime me)
    {
        return (me.ToUniversalTime().Ticks - 621355968000000000) / 10000;
    }


    // ReSharper disable once InconsistentNaming
    public static string yyyyMM(this DateTime me)
    {
        return me.ToString("yyyy-MM");
    }

    // ReSharper disable once InconsistentNaming
    public static string yyyyMMdd(this DateTime me)
    {
        return me.ToString("yyyy-MM-dd");
    }

    // ReSharper disable once InconsistentNaming
    public static string yyyyMMddHHmm(this DateTime me)
    {
        return me.ToString("yyyy-MM-dd HH:mm");
    }


    // ReSharper disable once InconsistentNaming
    public static string yyyyMMddHHmmss(this DateTime me)
    {
        return me.ToString("yyyy-MM-dd HH:mm:ss");
    }

    public static string yyyyMMddHHmmssfff(this DateTime me)
    {
        return me.ToString("yyyy-MM-dd HH:mm:ss.fff");
    }
}
