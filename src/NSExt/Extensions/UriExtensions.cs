namespace NSExt.Extensions;

public static class UriExtensions
{
    /// <summary>
    ///     移除url的Scheme
    /// </summary>
    /// <param name="me"></param>
    /// <returns></returns>
    public static string RemoveScheme(this Uri me)
    {
        return "//" + me.Authority + me.PathAndQuery;
    }
}



