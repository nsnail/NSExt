namespace NSExt.Extensions;

/// <summary>
///     LongExtensions
/// </summary>
public static class LongExtensions
{
    private const string _CHARS_36 = "0123456789abcdefghijklmnopqrstuvwxyz";

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
    ///     生成随机数
    /// </summary>
    /// <param name="me">me</param>
    public static long Rand(this long[] me)
    {
        return new Random(Guid.NewGuid().GetHashCode()).NextInt64(me[0], me[1]);
    }

    /// <summary>
    ///     转36进制
    /// </summary>
    public static string Sys36(this long me)
    {
        var ret = new StringBuilder();
        while (me > 35)
        {
            _ = ret.Insert(0, _CHARS_36[(int)(me % 36)]);
            me /= 36;
        }

        _ = ret.Insert(0, _CHARS_36[(int)me]);
        return ret.ToString();
    }

    /// <summary>
    ///     1970毫秒数转换成日期对象
    /// </summary>
    public static DateTime Time(this long msFrom1970)
    {
        return DateTime.UnixEpoch.AddMilliseconds(msFrom1970).ToLocalTime();
    }

    /// <summary>
    ///     ToString 的 Invariant 版本
    /// </summary>
    public static string ToInvString(this long me)
    {
        return me.ToString(CultureInfo.InvariantCulture);
    }
}