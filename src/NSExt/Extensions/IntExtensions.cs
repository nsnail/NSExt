namespace NSExt.Extensions;

/// <summary>
///     IntExtensions
/// </summary>
public static class IntExtensions
{
    /// <summary>
    ///     判断枚举是否包含某个位
    /// </summary>
    public static bool HasFlag<T>(this int me, T flag)
        where T : Enum
    {
        return ((long)me).HasFlag(flag);
    }

    /// <summary>
    ///     生成随机数
    /// </summary>
    /// <param name="me">me</param>
    public static int Rand(this int[] me)
    {
        return new Random(Guid.NewGuid().GetHashCode()).Next(me[0], me[1]);
    }

    /// <summary>
    ///     ToString 的 Invariant 版本
    /// </summary>
    public static string ToInvString(this int me)
    {
        return me.ToString(CultureInfo.InvariantCulture);
    }

    /// <summary>
    ///     转换成ipv4
    /// </summary>
    public static string ToIpV4(this int me)
    {
        return string.Join(".", BitConverter.GetBytes(me).Reverse());
    }
}