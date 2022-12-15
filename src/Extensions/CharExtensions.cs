namespace NSExt.Extensions;

/// <summary>
///     CharExtensions
/// </summary>
public static class CharExtensions
{
    /// <summary>
    ///     是否数字或大小写字母
    /// </summary>
    public static bool IsAsciiLetterOrDigit(this char me)
    {
        return (((uint)me - 'A') & ~0x20) < 26 || (uint)me - '0' < 10;
    }

    /// <summary>
    ///     是否base64字符
    /// </summary>
    public static bool IsBase64Character(this char me)
    {
        return IsAsciiLetterOrDigit(me) || me is '+' or '/' or '=';
    }
}