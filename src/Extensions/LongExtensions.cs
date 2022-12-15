namespace NSExt.Extensions;

/// <summary>
///     LongExtensions
/// </summary>
public static class LongExtensions
{
    /// <summary>
    ///     判断枚举是否包含某个位
    /// </summary>
    public static bool HasFlag<T>(this long me, T flag)
        where T : Enum
    {
        var val = (long)(object)flag;
        return (me & val) == val;
    }

    /// <summary>
    ///     1970毫秒数转换成日期对象
    /// </summary>
    public static DateTime Time(this long msFrom1970)
    {
        return new DateTime(1970, 1, 1).AddMilliseconds(msFrom1970).ToLocalTime();
    }
}