// @program: NSExt
// @file: DecimalExtensions.cs
// @author: tao ke
// @mailto: taokeu@gmail.com
// @created: 07/15/2022 20:36

namespace NSExt;

public static class DecimalExtensions
{
    /// <summary>
    ///     四舍五入后的近似值
    /// </summary>
    /// <param name="me">数字</param>
    /// <param name="place">小数点位数</param>
    /// <returns>处理后的值</returns>
    public static decimal Round(this decimal me, int place)
    {
        var dec = Math.Round(me, place);
        return dec;
    }
}
