namespace NSExt.Extensions;

public static class IntExtensions
{
    /// <summary>
    ///     判断枚举是否包含某个位
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="me"></param>
    /// <param name="flag"></param>
    /// <returns></returns>
    public static bool HasFlag<T>(this int me, T flag) where T : Enum
    {
        return ((long)me).HasFlag(flag);
    }

    /// <summary>
    ///     生成随机数
    /// </summary>
    /// <param name="me">大于等于[0]，小于[1]</param>
    /// <returns></returns>
    public static int Rand(this int[] me)
    {
        return new Random(Guid.NewGuid().GetHashCode()).Next(me[0], me[1]);
    }

    public static string ToIpV4(this int me)
    {
        return string.Join(".", BitConverter.GetBytes(me).Reverse());
    }
}
