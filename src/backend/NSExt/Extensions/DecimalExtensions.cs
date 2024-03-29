namespace NSExt.Extensions;

/// <summary>
///     DecimalExtensions
/// </summary>
public static class DecimalExtensions
{
    /// <summary>
    ///     四舍五入后的近似值
    /// </summary>
    /// <param name="me">me</param>
    /// <param name="place">小数点位数</param>
    /// <returns>处理后的值</returns>
    public static decimal Round(this decimal me, int place)
    {
        return Math.Round(me, place);
    }

    /// <summary>
    ///     ToString 的 Invariant 版本
    /// </summary>
    public static string ToInvString(this decimal me)
    {
        return me.ToString(CultureInfo.InvariantCulture);
    }
}