namespace NSExt.Extensions;

/// <summary>
///     UriExtensions
/// </summary>
public static class UriExtensions
{
    /// <summary>
    ///     移除url的Scheme
    /// </summary>
    public static string RemoveScheme(this Uri me)
    {
        return "//" + me.Authority + me.PathAndQuery;
    }
}