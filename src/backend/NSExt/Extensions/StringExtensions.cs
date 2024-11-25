using System.Numerics;
using System.Reflection;
using System.Security.Cryptography;
using System.Text.Json;
using System.Web;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;
using NSExt.Constant;

namespace NSExt.Extensions;

/// <summary>
///     StringExtensions
/// </summary>
public static partial class StringExtensions
{
    private const string _CHARACTERS = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
    private static readonly Regex _regexIpV4 = RegexIpV4();

    /// <summary>
    ///     aes加密
    /// </summary>
    /// <param name="me">me</param>
    /// <param name="key">密钥</param>
    public static string Aes(this string me, string key)
    {
        using var aes = System.Security.Cryptography.Aes.Create();
        aes.Padding = PaddingMode.PKCS7;
        aes.Mode = CipherMode.ECB;
        aes.Key = key.Hex();
        using var encryptor = aes.CreateEncryptor();
        var bytes = me.Hex();
        var decrypted = encryptor.TransformFinalBlock(bytes, 0, bytes.Length);
        return decrypted.Base64();
    }

    /// <summary>
    ///     aes解密
    /// </summary>
    /// <param name="me">me</param>
    /// <param name="key">密钥</param>
    public static string AesDe(this string me, string key)
    {
        using var aes = System.Security.Cryptography.Aes.Create();
        aes.Padding = PaddingMode.PKCS7;
        aes.Mode = CipherMode.ECB;
        aes.Key = key.Hex();
        using var encryptor = aes.CreateDecryptor();
        var bytes = me.Base64De();
        var decrypted = encryptor.TransformFinalBlock(bytes, 0, bytes.Length);
        return decrypted.HexDe();
    }

    /// <summary>
    ///     将指定的输入字符串进行Base62解码
    /// </summary>
    /// <exception cref="ArgumentException">ArgumentException</exception>
    public static string Base62Decode(this string me)
    {
        BigInteger result = 0;

        foreach (var index in me.Select(c => _CHARACTERS.IndexOf(c)))
        {
            if (index < 0)
            {
                throw new ArgumentException("Invalid character in Base62 string.");
            }

            result = result * 62 + index;
        }

        // Convert BigInteger back to byte array and then to string
        var bytes = result.ToByteArray();

        // Handle the sign bit
        if (bytes[^1] == 0)
        {
            Array.Resize(ref bytes, bytes.Length - 1);
        }

        return Encoding.UTF8.GetString(bytes);
    }

    /// <summary>
    ///     将指定的输入字符串进行Base62编码
    /// </summary>
    public static string Base62Encode(this string me)
    {
        // Convert string to byte array
        var bytes = Encoding.UTF8.GetBytes(me);

        // Convert byte array to BigInteger for easier processing
        var bigInteger = new BigInteger(bytes);

        if (bigInteger == 0)
        {
            return _CHARACTERS[0].ToString();
        }

        var result = new StringBuilder();

        while (bigInteger > 0)
        {
            var remainder = (int)(bigInteger % 62);
            bigInteger /= 62;
            _ = result.Insert(0, _CHARACTERS[remainder]);
        }

        return result.ToString();
    }

    /// <summary>
    ///     base64编码
    /// </summary>
    /// <param name="me">me</param>
    /// <param name="e">字符串的编码方式</param>
    /// <returns>编码后的base64字符串</returns>
    public static string Base64(this string me, Encoding e)
    {
        return e.GetBytes(me).Base64();
    }

    /// <summary>
    ///     base64解码
    /// </summary>
    /// <param name="me">me</param>
    /// <returns>解码后的原始字节数组</returns>
    public static byte[] Base64De(this string me)
    {
        return Convert.FromBase64String(me);
    }

    /// <summary>
    ///     base64解码
    /// </summary>
    /// <param name="me">me</param>
    /// <param name="e">字符串的编码方式</param>
    /// <returns>解码后的原始字符串</returns>
    public static string Base64De(this string me, Encoding e)
    {
        return e.GetString(me.Base64De());
    }

    /// <summary>
    ///     解码避免转义的Base64
    /// </summary>
    public static string Base64InUrlDecode(this string me)
    {
        return me.Replace("-", "+").Replace("_", "/");
    }

    /// <summary>
    ///     编码避免转义的Base64
    /// </summary>
    public static string Base64InUrlEncode(this string me)
    {
        return me.Replace("+", "-").Replace("/", "_");
    }

    /// <summary>
    ///     将易于web传输的base64web字符串转换为原生base64
    /// </summary>
    /// <returns>原生base64</returns>
    public static string Base64Sys(this string me)
    {
        return me.Replace("-", "+").Replace("_", "/").Replace(".", "=");
    }

    /// <summary>
    ///     将原生base64字符串转换成易于web传输的字符串
    /// </summary>
    /// <returns>易于web传输的字符串</returns>
    public static string Base64Web(this string me)
    {
        return me.Replace("+", "-").Replace("/", "_").Replace("=", ".");
    }

    /// <summary>
    ///     计算Crc32
    /// </summary>
    public static int Crc32(this string me)
    {
        return BitConverter.ToInt32(System.IO.Hashing.Crc32.Hash(Encoding.UTF8.GetBytes(me)));
    }

    /// <summary>
    ///     将字符串转换成日期对象
    /// </summary>
    /// <param name="me">me</param>
    /// <returns>转换后的日期对象</returns>
    public static DateTime DateTime(this string me)
    {
        return System.DateTime.Parse(me, CultureInfo.CurrentCulture);
    }

    /// <summary>
    ///     将字符串转换成日期对象
    /// </summary>
    /// <param name="me">me</param>
    /// <param name="format">日期格式</param>
    /// <returns>转换后的日期对象</returns>
    public static DateTime DateTimeExact(this string me, string format)
    {
        return System.DateTime.ParseExact(me, format, CultureInfo.CurrentCulture);
    }

    /// <summary>
    ///     将字符串转换成日期对象
    /// </summary>
    /// <param name="me">me</param>
    /// <param name="format">日期格式</param>
    /// <param name="def">转换失败时返回的日期对象</param>
    /// <returns>转换后的日期对象</returns>
    public static DateTime DateTimeExactTry(this string me, string format, DateTime def)
    {
        return !System.DateTime.TryParseExact(me, format, CultureInfo.CurrentCulture, DateTimeStyles.None, out var ret) ? def : ret;
    }

    /// <summary>
    ///     将字符串转换成日期对象
    /// </summary>
    /// <param name="me">me</param>
    /// <param name="def">转换失败时返回的日期对象</param>
    /// <returns>转换后的日期对象</returns>
    public static DateTime DateTimeTry(this string me, DateTime def)
    {
        return !System.DateTime.TryParse(me, CultureInfo.InvariantCulture, DateTimeStyles.None, out var ret) ? def : ret;
    }

    /// <summary>
    ///     string to decimal
    /// </summary>
    /// <param name="me">me</param>
    /// <returns>decimal</returns>
    public static decimal Dec(this string me)
    {
        return decimal.Parse(me, CultureInfo.CurrentCulture);
    }

    /// <summary>
    ///     尝试将字符串转为decimal
    /// </summary>
    /// <param name="me">me</param>
    /// <param name="def">转换失败后返回的默认值</param>
    /// <returns>转换后的decimal</returns>
    public static decimal DecTry(this string me, decimal def)
    {
        return !decimal.TryParse(me, out var ret) ? def : ret;
    }

    /// <summary>
    ///     string to double
    /// </summary>
    /// <param name="me">me</param>
    /// <returns>Int32</returns>
    public static double Double(this string me)
    {
        return double.Parse(me, CultureInfo.CurrentCulture);
    }

    /// <summary>
    ///     将字符串转换成枚举对象
    /// </summary>
    public static T Enum<T>(this string name)
        where T : Enum
    {
        return (T)System.Enum.Parse(typeof(T), name, true);
    }

    /// <summary>
    ///     将字符串转换成枚举对象
    /// </summary>
    public static T EnumTry<T>(this string name, T def)
        where T : Enum
    {
        return !System.Enum.TryParse(typeof(T), name, out var ret) ? def : (T)ret;
    }

    /// <summary>
    ///     执行C#代码
    /// </summary>
    public static Task<T> ExecuteCSharpCodeAsync<T>(this string me, Assembly[] assemblies, params string[] importNamespaces)
    {
        // 使用 Roslyn 编译并执行代码
        return CSharpScript.EvaluateAsync<T>(me, ScriptOptions.Default.WithReferences(assemblies).WithImports(importNamespaces));
    }

    /// <summary>
    ///     string to float
    /// </summary>
    /// <param name="me">me</param>
    /// <returns>Int32</returns>
    public static float Float(this string me)
    {
        return float.Parse(me, CultureInfo.CurrentCulture);
    }

    /// <summary>
    ///     将字符串转为guid
    /// </summary>
    /// <param name="me">me</param>
    public static Guid Guid(this string me)
    {
        return System.Guid.Parse(me);
    }

    /// <summary>
    ///     将字符串转换成guid
    /// </summary>
    /// <param name="me">me</param>
    /// <param name="def">转换失败的返回值</param>
    public static Guid Guid(this string me, Guid def)
    {
        return System.Guid.TryParse(me, out var ret) ? ret : def;
    }

    /// <summary>
    ///     将字符串转换成字节数组形式
    /// </summary>
    /// <param name="me">me</param>
    /// <param name="e">字符串使用的编码</param>
    /// <returns>字节数组</returns>
    public static byte[] Hex(this string me, Encoding e)
    {
        return e.GetBytes(me);
    }

    /// <summary>
    ///     将字符串转换成字节数组形式
    /// </summary>
    /// <param name="me">me</param>
    /// <returns>字节数组</returns>
    public static byte[] Hex(this string me)
    {
        return me.Hex(Encoding.UTF8);
    }

    /// <summary>
    ///     对一个字符串进行sha1 hash运算
    /// </summary>
    /// <param name="me">me</param>
    /// <param name="secret">密钥</param>
    /// <param name="e">使用的编码</param>
    /// <returns>hash摘要的16进制文本形式（无连字符小写）</returns>
    public static string HmacSha1(this string me, string secret, Encoding e)
    {
        using var hmacSha1 = new HMACSHA1(e.GetBytes(secret));

#if NET9_0_OR_GREATER
        return Convert.ToHexStringLower(hmacSha1.ComputeHash(e.GetBytes(me)));
#else
        return BitConverter.ToString(hmacSha1.ComputeHash(e.GetBytes(me))).Replace("-", string.Empty).ToLower(CultureInfo.CurrentCulture);
#endif
    }

    /// <summary>
    ///     html编码
    /// </summary>
    public static string Html(this string me)
    {
        return HttpUtility.HtmlEncode(me);
    }

    /// <summary>
    ///     解码html编码
    /// </summary>
    /// <param name="me">me</param>
    /// <returns>解码后的原始字符串</returns>
    public static string HtmlDe(this string me)
    {
        return HttpUtility.HtmlDecode(me);
    }

    /// <summary>
    ///     string to Int32
    /// </summary>
    /// <param name="me">me</param>
    /// <returns>Int32</returns>
    public static int Int32(this string me)
    {
        return int.Parse(me, CultureInfo.CurrentCulture);
    }

    /// <summary>
    ///     尝试将字符串转为int32
    /// </summary>
    /// <param name="me">me</param>
    /// <param name="def">转换失败后返回的默认值</param>
    /// <returns>转换后的int32</returns>
    public static int Int32Try(this string me, int def)
    {
        return !int.TryParse(me, out var ret) ? def : ret;
    }

    /// <summary>
    ///     string to Int64
    /// </summary>
    /// <param name="me">me</param>
    /// <returns>Int64</returns>
    public static long Int64(this string me)
    {
        return long.Parse(me, CultureInfo.CurrentCulture);
    }

    /// <summary>
    ///     尝试将字符串转为int64
    /// </summary>
    /// <param name="me">me</param>
    /// <param name="def">转换失败后返回的默认值</param>
    /// <returns>转换后的int64</returns>
    public static long Int64Try(this string me, long def)
    {
        return !long.TryParse(me, out var ret) ? def : ret;
    }

    /// <summary>
    ///     ipv4格式转int32格式
    /// </summary>
    public static int IpV4ToInt32(this string me)
    {
        return BitConverter.ToInt32(me.Split('.').Select(byte.Parse).Reverse().ToArray(), 0);
    }

    /// <summary>
    ///     是否base64字符串
    /// </summary>
    /// <param name="me">me</param>
    public static bool IsBase64String(this string me)
    {
        // 一个合法的Base64，有着以下特征：
        // 字符串的长度为4的整数倍。
        // 字符串的符号取值只能在A -Z, a -z, 0 -9, +, /, =共计65个字符中，且 = 如果出现就必须在结尾出现。
        if (!me.All(x => x.IsBase64Character()))
        {
            return false;
        }

        if (me.Length % 4 != 0)
        {
            return false;
        }

        var firstEqualSignPos = me.IndexOf('=');
        if (firstEqualSignPos < 0)
        {
            return true;
        }

        var lastEqualSignPos = me.LastIndexOf('=');
        return lastEqualSignPos == me.Length - 1 && me[firstEqualSignPos..lastEqualSignPos].All(x => x == '=');
    }

    /// <summary>
    ///     是否IPV4地址
    /// </summary>
    public static bool IsIpV4(this string me)
    {
        return _regexIpV4.IsMatch(me);
    }

    /// <summary>
    ///     是否json字符串
    /// </summary>
    /// <param name="me">me</param>
    public static bool IsJsonString(this string me)
    {
        if (me.NullOrEmpty())
        {
            return false;
        }

        try
        {
            _ = JsonDocument.Parse(me);
        }
        catch
        {
            return false;
        }

        return true;
    }

    /// <summary>
    ///     中文姓名打马赛克
    /// </summary>
    public static string MaskChineseName(this string me)
    {
        return me.Length == 2 ? "*" + me[1..] : me[..1] + "*" + me[^1..];
    }

    /// <summary>
    ///     对一个手机号进行掩码处理
    /// </summary>
    /// <param name="me">me</param>
    /// <returns>掩码后的手机号</returns>
    public static string MaskMobile(this string me)
    {
        return Regexes.RegexMobile.Replace(me, "$1****$2");
    }

    /// <summary>
    ///     对一个字符串进行md5hash运算
    /// </summary>
    /// <param name="me">me</param>
    /// <param name="e">字符串使用的编码</param>
    /// <returns>hash摘要的16进制文本形式（无连字符小写）</returns>
    public static string Md5(this string me, Encoding e)
    {
#if NET9_0_OR_GREATER
        return Convert.ToHexStringLower(MD5.HashData(e.GetBytes(me)));
#else
        return BitConverter.ToString(MD5.HashData(e.GetBytes(me)))
            .Replace("-", string.Empty)
            .ToLower(CultureInfo.CurrentCulture);
#endif
    }

    /// <summary>
    ///     判断字符串是否为null或不存在子元素（如果为集合对象）；如果为空，返回指定的默认值，否则返回字符串本身
    /// </summary>
    /// <param name="me">me</param>
    /// <param name="defVal">指定的默认值</param>
    /// <returns>如果为空，返回指定的默认值，否则返回字符串本身</returns>
    public static string NullOrEmpty(this string me, string defVal)
    {
        return me.AsEnumerable().NullOrEmpty() ? defVal : me;
    }

    /// <summary>
    ///     null或空白字符
    /// </summary>
    public static bool NullOrWhiteSpace(this string me)
    {
        return string.IsNullOrWhiteSpace(me);
    }

    /// <summary>
    ///     反序列化一个文件获得指定类型的数据对象
    /// </summary>
    /// <param name="me">me</param>
    /// <param name="options">序列化选项</param>
    /// <returns>反序列化后生成的对象</returns>
    public static T Object<T>(this string me, JsonSerializerOptions options = null)
    {
        return JsonSerializer.Deserialize<T>(me, options);
    }

    /// <summary>
    ///     反序列化一个文件获得指定类型的数据对象
    /// </summary>
    /// <param name="me">me</param>
    /// <param name="type">实际类型</param>
    /// <param name="options">序列化选项</param>
    /// <returns>反序列化后生成的对象</returns>
    public static object Object(this string me, Type type, JsonSerializerOptions options = null)
    {
        return JsonSerializer.Deserialize(me, type, options);
    }

    /// <summary>
    ///     生成密码
    /// </summary>
    /// <param name="me">me</param>
    /// <returns>密文</returns>
    public static string Pwd(this string me)
    {
        return me.Md5Hmac(me.Md5(Encoding.UTF8), Encoding.UTF8);
    }

    /// <summary>
    ///     移除字符串中的html标签
    /// </summary>
    /// <param name="me">me</param>
    /// <returns>处理之后的字符串</returns>
    public static string RemoveHtmlTag(this string me)
    {
        return Regexes.RegexHtmlTag.Replace(me, string.Empty);
    }

    /// <summary>
    ///     删除换行符
    /// </summary>
    public static string RemoveWrapped(this string me)
    {
        return me.Replace("\r", string.Empty).Replace("\n", string.Empty);
    }

    /// <summary>
    ///     对一个字符串进行sha1 hash运算
    /// </summary>
    /// <param name="me">me</param>
    /// <param name="e">字符串使用的编码</param>
    /// <returns>hash摘要的16进制文本形式（无连字符小写）</returns>
    public static string Sha1(this string me, Encoding e)
    {
#if NET9_0_OR_GREATER
        return Convert.ToHexStringLower(SHA1.HashData(e.GetBytes(me)));
#else
        return BitConverter.ToString(SHA1.HashData(e.GetBytes(me)))
            .Replace("-", string.Empty)
            .ToLower(CultureInfo.CurrentCulture);
#endif
    }

    /// <summary>
    ///     蛇形命名
    /// </summary>
    public static string SnakeCase(this string me)
    {
        return Regexes.RegexUpLetter.Replace(me, "-$1").ToLower(CultureInfo.InvariantCulture).TrimStart('-');
    }

    /// <summary>
    ///     截取指定长度的字符串，代替substring
    /// </summary>
    public static string Sub(this string me, int startIndex, int length)
    {
        if (startIndex + length > me.Length)
        {
            length = me.Length - startIndex;
        }

        return me.Substring(startIndex, length);
    }

    /// <summary>
    ///     纯文本字符串转html
    /// </summary>
    public static string Text2Html(this string me)
    {
        return $"<pre>{me}</pre>";
    }

    /// <summary>
    ///     首字母小写
    /// </summary>
    public static string ToLowerCamelCase(this string me)
    {
        return string.IsNullOrWhiteSpace(me) ? me : string.Concat(me[0].ToString(CultureInfo.InvariantCulture).ToLowerInvariant(), me.AsSpan(1));
    }

    /// <summary>
    ///     首字母大写
    /// </summary>
    public static string ToUpperCamelCase(this string me)
    {
        return string.IsNullOrWhiteSpace(me) ? me : string.Concat(me[0].ToString().ToUpperInvariant(), me.AsSpan(1));
    }

    /// <summary>
    ///     去掉前部字符串
    /// </summary>
    public static string TrimPrefix(this string me, string clearStr)
    {
        return Regex.Replace(me, $"^{clearStr}", string.Empty);
    }

    /// <summary>
    ///     将连续多个空格替换成一个空格
    /// </summary>
    public static string TrimSpaces(this string me)
    {
        var ret = me.Replace("  ", " ");

        // ReSharper disable once TailRecursiveCall
        return ret == me ? ret : ret.TrimSpaces();
    }

    /// <summary>
    ///     去掉尾部字符串
    /// </summary>
    public static string TrimSuffix(this string me, string clearStr)
    {
        return Regex.Replace(me, $"{clearStr}$", string.Empty);
    }

    /// <summary>
    ///     将\ux0000 、 %u0000 、 &amp;#x0000;  编码转换成可读字符串
    /// </summary>
    public static string UnicodeDe(this string me)
    {
#pragma warning disable S3358, RCS1238
        const string replacement = "&#x$1;";
        return !me.Contains(@"\u")
            ? me.Contains("%u") ? Regexes.RegexPercentUnicode.Replace(me, replacement).HtmlDe() : me.HtmlDe()
            : Regexes.RegexBacksLantUnicode.Replace(me, replacement).HtmlDe();
#pragma warning restore S3358, RCS1238
    }

    /// <summary>
    ///     url编码
    /// </summary>
    /// <param name="me">me</param>
    /// <returns>url编码后的字符串</returns>
    public static string Url(this string me)
    {
        return Uri.EscapeDataString(me);
    }

    /// <summary>
    ///     解码url编码
    /// </summary>
    /// <param name="me">me</param>
    /// <returns>解码后的原始字符串</returns>
    public static string UrlDe(this string me)
    {
        return Uri.UnescapeDataString(me);
    }

    /// <summary>
    ///     MD5 hmac编码
    /// </summary>
    /// <param name="me">me</param>
    /// <param name="key">密钥</param>
    /// <param name="e">字符串使用的编码</param>
    /// <returns>hash摘要的16进制文本形式（无连字符小写）</returns>
    private static string Md5Hmac(this string me, string key, Encoding e)
    {
        using var md5Hmac = new HMACMD5(e.GetBytes(key));

#if NET9_0_OR_GREATER
        return Convert.ToHexStringLower(md5Hmac.ComputeHash(e.GetBytes(me)));
#else
        return BitConverter.ToString(md5Hmac.ComputeHash(e.GetBytes(me))).Replace("-", string.Empty).ToLower(CultureInfo.CurrentCulture);
#endif
    }

    [GeneratedRegex(@"^(25[0-5]|2[0-4][0-9]|[0-1]?[0-9]{1,2})(\.(25[0-5]|2[0-4][0-9]|[0-1]?[0-9]{1,2})){3}$")]
    private static partial Regex RegexIpV4();
}