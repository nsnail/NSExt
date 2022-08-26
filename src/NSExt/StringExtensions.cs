// @program: NSExt
// @file: StringExtensions.cs
// @author: tao ke
// @mailto: taokeu@gmail.com
// @created: 07/26/2022 21:57

using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SshNet.Security.Cryptography;
using HMACMD5 = System.Security.Cryptography.HMACMD5;

// ReSharper disable UnusedMember.Global

namespace NSExt;

public static class StringExtensions
{
    /// <summary>
    ///     base64编码
    /// </summary>
    /// <param name="me">待base64编码的字符串</param>
    /// <param name="e">字符串的编码方式</param>
    /// <returns>编码后的base64字符串</returns>
    public static string Base64(this string me, Encoding e)
    {
        return e.GetBytes(me).Base64();
    }

    /// <summary>
    ///     base64解码
    /// </summary>
    /// <param name="me">待解码的字符串</param>
    /// <returns>解码后的原始字节数组</returns>
    public static byte[] Base64De(this string me)
    {
        return Convert.FromBase64String(me);
    }

    /// <summary>
    ///     base64解码
    /// </summary>
    /// <param name="me">待解码的字符串</param>
    /// <param name="e">字符串的编码方式</param>
    /// <returns>解码后的原始字符串</returns>
    public static string Base64De(this string me, Encoding e)
    {
        return e.GetString(Base64De(me));
    }

    /// <summary>
    ///     将易于web传输的base64web字符串转换为原生base64
    /// </summary>
    /// <param name="me"></param>
    /// <returns>原生base64</returns>
    public static string Base64Sys(this string me)
    {
        return me.Replace("-", "+").Replace("_", "/").Replace(".", "=");
    }

    /// <summary>
    ///     将原生base64字符串转换成易于web传输的字符串
    /// </summary>
    /// <param name="me"></param>
    /// <returns>易于web传输的字符串</returns>
    public static string Base64Web(this string me)
    {
        return me.Replace("+", "-").Replace("/", "_").Replace("=", ".");
    }

    /// <summary>
    ///     将字符串转换成日期对象
    /// </summary>
    /// <param name="me">待转换字符串</param>
    /// <returns>转换后的日期对象</returns>
    public static DateTime DateTime(this string me)
    {
        return System.DateTime.Parse(me, CultureInfo.CurrentCulture);
    }

    /// <summary>
    ///     将字符串转换成日期对象
    /// </summary>
    /// <param name="me">待转换字符串</param>
    /// <param name="def">转换失败时返回的日期对象</param>
    /// <returns>转换后的日期对象</returns>
    public static DateTime DateTimeTry(this string me, DateTime def)
    {
        return !System.DateTime.TryParse(me, out var ret) ? def : ret;
    }

    /// <summary>
    ///     string to decimal
    /// </summary>
    /// <param name="me">string</param>
    /// <returns>decimal</returns>
    public static decimal Dec(this string me)
    {
        return decimal.Parse(me, CultureInfo.CurrentCulture);
    }


    /// <summary>
    ///     尝试将字符串转为decimal
    /// </summary>
    /// <param name="me">字符串</param>
    /// <param name="def">转换失败后返回的默认值</param>
    /// <returns>转换后的decimal</returns>
    public static decimal DecTry(this string me, decimal def)
    {
        return !decimal.TryParse(me, out var ret) ? def : ret;
    }

    /// <summary>
    ///     将字符串转换成枚举对象
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="name"></param>
    /// <returns></returns>
    public static T Enum<T>(this string name) where T : Enum
    {
        return (T)System.Enum.Parse(typeof(T), name);
    }


    /// <summary>
    ///     将字符串转换成枚举对象
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="name"></param>
    /// <param name="def"></param>
    /// <returns></returns>
    public static T EnumTry<T>(this string name, T def) where T : Enum
    {
        return !System.Enum.TryParse(typeof(T), name, out var ret) ? def : (T)ret;
    }


    /// <summary>
    ///     将字符串转为guid
    /// </summary>
    /// <param name="me">字符串</param>
    /// <returns></returns>
    public static Guid Guid(this string me)
    {
        return System.Guid.Parse(me);
    }

    /// <summary>
    ///     将字符串转换成guid
    /// </summary>
    /// <param name="me">字符串</param>
    /// <param name="def">转换失败的返回值</param>
    /// <returns></returns>
    public static Guid Guid(this string me, Guid def)
    {
        return System.Guid.TryParse(me, out var ret) ? ret : def;
    }


    /// <summary>
    ///     将字符串转换成字节数组形式
    /// </summary>
    /// <param name="me">字符串</param>
    /// <param name="e">字符串使用的编码</param>
    /// <returns>字节数组</returns>
    public static byte[] Hex(this string me, Encoding e)
    {
        return e.GetBytes(me);
    }

    /// <summary>
    ///     解码html编码
    /// </summary>
    /// <param name="me">html编码后的字符串</param>
    /// <returns>解码后的原始字符串</returns>
    public static string HtmlDe(this string me)
    {
        return HttpUtility.HtmlDecode(me);
    }

    /// <summary>
    ///     string to Int32
    /// </summary>
    /// <param name="me">string</param>
    /// <returns>Int32</returns>
    public static int Int32(this string me)
    {
        return int.Parse(me, CultureInfo.CurrentCulture);
    }


    /// <summary>
    ///     尝试将字符串转为int32
    /// </summary>
    /// <param name="me">字符串</param>
    /// <param name="def">转换失败后返回的默认值</param>
    /// <returns>转换后的int32</returns>
    public static int Int32Try(this string me, int def)
    {
        return !int.TryParse(me, out var ret) ? def : ret;
    }


    /// <summary>
    ///     string to Int64
    /// </summary>
    /// <param name="me">string</param>
    /// <returns>Int64</returns>
    public static long Int64(this string me)
    {
        return long.Parse(me, CultureInfo.CurrentCulture);
    }

    /// <summary>
    ///     尝试将字符串转为int64
    /// </summary>
    /// <param name="me">字符串</param>
    /// <param name="def">转换失败后返回的默认值</param>
    /// <returns>转换后的int64</returns>
    public static long Int64Try(this string me, long def)
    {
        return !long.TryParse(me, out var ret) ? def : ret;
    }


    /// <summary>
    ///     将一个json字符串反序列化成为jObject对象
    /// </summary>
    /// <param name="me">字符串</param>
    /// <returns></returns>
    public static JObject JObject(this string me)
    {
        return Newtonsoft.Json.Linq.JObject.Parse(me);
    }

    public static string MaskChineseName(this string me)
    {
        if (me.Length == 2) return "*" + me[1..];

        return me[..1] + "*" + me[^1..];
    }

    /// <summary>
    ///     对一个手机号进行掩码处理
    /// </summary>
    /// <param name="me">手机号</param>
    /// <returns>掩码后的手机号</returns>
    public static string MaskMobile(this string me)
    {
        return new Regex(@"^(\d{3})\d{4}(\d{4})$").Replace(me, "$1****$2");
    }


    /// <summary>
    ///     对一个字符串进行md5hash运算
    /// </summary>
    /// <param name="me">字符串</param>
    /// <param name="e">字符串使用的编码</param>
    /// <returns>hash摘要的16进制文本形式（无连字符小写）</returns>
    public static string Md5(this string me, Encoding e)
    {
        using var md5 = new MD5();
        return BitConverter.ToString(md5.ComputeHash(e.GetBytes(me)))
                           .Replace("-", string.Empty)
                           .ToLower(CultureInfo.CurrentCulture);
    }


    /// <summary>
    ///     对一个字符串进行sha1hash运算
    /// </summary>
    /// <param name="me">字符串</param>
    /// <param name="e">字符串使用的编码</param>
    /// <returns>hash摘要的16进制文本形式（无连字符小写）</returns>
    public static string Sha1(this string me, Encoding e)
    {
        using var sha1 = new SHA1();
        return BitConverter.ToString(sha1.ComputeHash(e.GetBytes(me)))
                           .Replace("-", string.Empty)
                           .ToLower(CultureInfo.CurrentCulture);
    }


    /// <summary>
    ///     对一个字符串进行sha1hash运算
    /// </summary>
    /// <param name="me">字符串</param>
    /// <param name="secret">密钥</param>
    /// <param name="e">字符串使用的编码</param>
    /// <returns>hash摘要的16进制文本形式（无连字符小写）</returns>
    public static string HmacSha1(this string me, string secret, Encoding e)
    {
        using var hmacSha1 = new HMACSHA1(e.GetBytes(secret));
        return BitConverter.ToString(hmacSha1.ComputeHash(e.GetBytes(me)))
                           .Replace("-", string.Empty)
                           .ToLower(CultureInfo.CurrentCulture);
    }


    /// <summary>
    ///     MD5 hmac编码
    /// </summary>
    /// <param name="me">字符串</param>
    /// <param name="key">密钥</param>
    /// <param name="e">字符串使用的编码</param>
    /// <returns>hash摘要的16进制文本形式（无连字符小写）</returns>
    private static string Md5Hmac(this string me, string key, Encoding e)
    {
        using var md5Hmac = new HMACMD5(e.GetBytes(key));
        return BitConverter.ToString(md5Hmac.ComputeHash(e.GetBytes(me)))
                           .Replace("-", string.Empty)
                           .ToLower(CultureInfo.CurrentCulture);
    }

    /// <summary>
    ///     判断字符串是否为null或不存在子元素（如果为集合对象）；如果为空，返回指定的默认值，否则返回字符串本身
    /// </summary>
    /// <param name="me">指定字符串</param>
    /// <param name="defVal">指定的默认值</param>
    /// <returns>如果为空，返回指定的默认值，否则返回字符串本身</returns>
    public static string NullOrEmpty(this string me, string defVal)
    {
        return me.AsEnumerable().NullOrEmpty() ? defVal : me;
    }

    /// <summary>
    ///     反序列化一个文件获得指定类型的数据对象
    /// </summary>
    /// <param name="me">等待反序列化的json文本</param>
    /// <returns>反序列化后生成的对象</returns>
    public static T Object<T>(this string me)
    {
        return JsonConvert.DeserializeObject<T>(me);
    }

    /// <summary>
    ///     生成密码
    /// </summary>
    /// <param name="me">密码原文</param>
    /// <returns>密文</returns>
    public static string Pwd(this string me)
    {
        return me.Md5Hmac(me.Md5(Encoding.UTF8), Encoding.UTF8);
    }

    /// <summary>
    ///     移除字符串中的html标签
    /// </summary>
    /// <param name="me">字符串</param>
    /// <returns>处理之后的字符串</returns>
    public static string RemoveHtmlTag(this string me)
    {
        return new Regex(@"<[^>]*>").Replace(me, "");
    }

    /// <summary>
    ///     删除换行符
    /// </summary>
    /// <param name="me"></param>
    /// <returns></returns>
    public static string RemoveWrapped(this string me)
    {
        return me.Replace("\r", "").Replace("\n", "");
    }


    /// <summary>
    ///     截取指定长度的字符串，代替substring
    /// </summary>
    /// <param name="me"></param>
    /// <param name="startIndex"></param>
    /// <param name="length"></param>
    /// <returns></returns>
    public static string Sub(this string me, int startIndex, int length)
    {
        if (startIndex + length > me.Length) length = me.Length - startIndex;
        return me.Substring(startIndex, length);
    }

    /// <summary>
    ///     将连续多个空格替换成一个空格
    /// </summary>
    /// <param name="me"></param>
    /// <returns></returns>
    public static string TrimSpaces(this string me)
    {
        var ret = me.Replace("  ", " ");
        // ReSharper disable once TailRecursiveCall
        return ret == me ? ret : TrimSpaces(ret);
    }


    /// <summary>
    ///     url编码
    /// </summary>
    /// <param name="me">字符串</param>
    /// <returns>url编码后的字符串</returns>
    public static string Url(this string me)
    {
        return Uri.EscapeDataString(me);
    }

    /// <summary>
    ///     解码url编码
    /// </summary>
    /// <param name="me">url编码后的字符串</param>
    /// <returns>解码后的原始字符串</returns>
    public static string UrlDe(this string me)
    {
        return Uri.UnescapeDataString(me);
    }

    public static int IpV4ToInt32(this string me)
    {
        return BitConverter.ToInt32(me.Split('.').Select(byte.Parse).Reverse().ToArray(), 0);
    }
}
