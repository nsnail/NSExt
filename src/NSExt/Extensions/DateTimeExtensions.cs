// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global

#pragma warning disable SA1300
#pragma warning disable IDE1006
namespace NSExt.Extensions;

/// <summary>
///     DateTimeExtensions
/// </summary>
public static class DateTimeExtensions
{
    /// <summary>
    ///     将一个过去时间对象与当前时间相减转换成“xx以前”的字符串, 如2秒以前, 3天以前
    /// </summary>
    /// <param name="me">me</param>
    /// <returns>字符串</returns>
    public static string TimeAgo(this DateTime me)
    {
        var ts = DateTime.Now - me;
        return ts.Days > 0 ? ts.Days    + "天前" :
            ts.Hours   > 0 ? ts.Hours   + "小时前" :
            ts.Minutes > 0 ? ts.Minutes + "分钟前" : ts.Seconds + "秒前";
    }

    /// <summary>
    ///     指定时间的世界协调时的unix时间戳形式
    /// </summary>
    /// <param name="me">me</param>
    /// <returns>unix时间戳</returns>
    public static long TimeUnixUtc(this DateTime me)
    {
        return (me.ToUniversalTime().Ticks - 621355968000000000) / 10000000;
    }

    /// <summary>
    ///     指定时间的世界协调时的unix时间戳形式（毫秒）
    /// </summary>
    public static long TimeUnixUtcMs(this DateTime me)
    {
        return (me.ToUniversalTime().Ticks - 621355968000000000) / 10000;
    }

    /// <summary>
    ///     ToString 的 Invariant 版本
    /// </summary>
    public static string ToInvString(this DateTime me)
    {
        return me.ToString(CultureInfo.InvariantCulture);
    }

    /// <summary>
    ///     yyyy_MM
    /// </summary>
    public static string yyyy_MM(this DateTime me)
    {
        return me.ToString("yyyy-MM", CultureInfo.InvariantCulture);
    }

    /// <summary>
    ///     yyyy_MM_dd
    /// </summary>
    public static string yyyy_MM_dd(this DateTime me)
    {
        return me.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
    }

    /// <summary>
    ///     yyyy_MM_dd_HH_mm
    /// </summary>
    public static string yyyy_MM_dd_HH_mm(this DateTime me)
    {
        return me.ToString("yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture);
    }

    /// <summary>
    ///     yyyy_MM_dd_HH_mm_ss
    /// </summary>
    public static string yyyy_MM_dd_HH_mm_ss(this DateTime me)
    {
        return me.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
    }

    /// <summary>
    ///     yyyy_MM_dd_HH_mm_ss_fff
    /// </summary>
    public static string yyyy_MM_dd_HH_mm_ss_fff(this DateTime me)
    {
        return me.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture);
    }

    /// <summary>
    ///     yyyyMM
    /// </summary>
    public static string yyyyMM(this DateTime me)
    {
        return me.ToString("yyyyMM", CultureInfo.InvariantCulture);
    }

    /// <summary>
    ///     yyyyMMdd
    /// </summary>
    public static string yyyyMMdd(this DateTime me)
    {
        return me.ToString("yyyyMMdd", CultureInfo.InvariantCulture);
    }
}