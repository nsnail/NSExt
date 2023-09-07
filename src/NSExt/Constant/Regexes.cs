namespace NSExt.Constant;
#pragma warning disable SYSLIB1045

/// <summary>
///     使用 RegexGenerator 新特性会生成重复key值的xmlcomment导致出错
/// </summary>
internal static class Regexes
{
    public static readonly Regex RegexBacksLantUnicode
        = new("\\\\u([a-fA-F0-9]{4})", RegexOptions.Compiled | RegexOptions.IgnoreCase);

    public static readonly Regex RegexHtmlTag = new("<[^>]*>", RegexOptions.Compiled | RegexOptions.IgnoreCase);

    public static readonly Regex RegexMobile
        = new("^(\\d{3})\\d{4}(\\d{4})$", RegexOptions.Compiled | RegexOptions.IgnoreCase);

    public static readonly Regex RegexPercentUnicode
        = new("\\\\u([a-fA-F0-9]{4})", RegexOptions.Compiled | RegexOptions.IgnoreCase);

    public static readonly Regex RegexUpLetter = new("([A-Z])", RegexOptions.Compiled | RegexOptions.IgnoreCase);
}