namespace NSExt.Extensions;

public static class ByteExtensions
{
    /// <summary>
    ///     base64编码
    /// </summary>
    /// <param name="me">待编码的字节数组</param>
    /// <returns>编码后的base64字符串</returns>
    public static string Base64(this byte[] me)
    {
        return Convert.ToBase64String(me);
    }


    /// <summary>
    ///     将字节数组解码成字符串
    /// </summary>
    /// <param name="me">字节数组</param>
    /// <param name="e">字符串使用的编码方式</param>
    /// <returns>解码后的原始字符串</returns>
    public static string HexDe(this byte[] me, Encoding e)
    {
        return e.GetString(me);
    }


    /// <summary>
    ///     将字节数组解码成字符串
    /// </summary>
    /// <param name="me">字节数组</param>
    /// <returns>解码后的原始字符串</returns>
    public static string HexDe(this byte[] me)
    {
        return me.HexDe(Encoding.UTF8);
    }
}