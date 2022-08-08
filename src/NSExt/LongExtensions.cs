// @program: NSExt
// @file: LongExtensions.cs
// @author: tao ke
// @mailto: taokeu@gmail.com
// @created: 07/26/2022 21:57

namespace NSExt;

public static class LongExtensions
{
    /// <summary>
    ///     判断枚举是否包含某个位
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="me"></param>
    /// <param name="flag"></param>
    /// <returns></returns>
    public static bool HasFlag<T>(this long me, T flag) where T : Enum
    {
        var val = (long)(object)flag;
        return (me & val) == val;
    }

    /// <summary>
    ///     1970毫秒数转换成日期对象
    /// </summary>
    /// <param name="msFrom1970"></param>
    /// <returns></returns>
    public static DateTime Time(this long msFrom1970)
    {
        return new DateTime(1970, 1, 1).AddMilliseconds(msFrom1970).ToLocalTime();
    }
}
