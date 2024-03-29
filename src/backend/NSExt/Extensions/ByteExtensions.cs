namespace NSExt.Extensions;

/// <summary>
///     ByteExtensions
/// </summary>
public static class ByteExtensions
{
    /// <summary>
    ///     base64编码
    /// </summary>
    /// <param name="me">me</param>
    /// <returns>编码后的base64字符串</returns>
    public static string Base64(this byte[] me)
    {
        return Convert.ToBase64String(me);
    }

    /// <summary>
    ///     将字节数组解码成字符串
    /// </summary>
    /// <param name="me">me</param>
    /// <param name="e">字符串使用的编码方式</param>
    /// <returns>解码后的原始字符串</returns>
    public static string HexDe(this byte[] me, Encoding e)
    {
        return e.GetString(me);
    }

    /// <summary>
    ///     将字节数组解码成字符串
    /// </summary>
    /// <param name="me">me</param>
    /// <returns>解码后的原始字符串</returns>
    public static string HexDe(this byte[] me)
    {
        return me.HexDe(Encoding.UTF8);
    }

    /// <summary>
    ///     将字节数组转换成16进制字符串
    /// </summary>
    /// <param name="me">me</param>
    /// <param name="upperCase">是否大写</param>
    /// <param name="splitShar">字节间分隔符</param>
    /// <param name="splitInterval">分隔符跳跃字节数</param>
    public static string Str(this IEnumerable<byte> me, bool upperCase = true, string splitShar = ""
                           , int                    splitInterval = 1)
    {
        var sb = new StringBuilder();
        var i  = 0;
        foreach (var c in me.Select(x => x.ToString(upperCase ? "X2" : "x2", CultureInfo.InvariantCulture))) {
            if (i++ % splitInterval == 0) {
                _ = sb.Append(splitShar);
            }

            _ = sb.Append(c);
        }

        return sb.ToString();
    }
}