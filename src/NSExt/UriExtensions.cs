// @program: NSExt
// @file: UriExtensions.cs
// @author: tao ke
// @mailto: taokeu@gmail.com
// @created: 07/15/2022 20:36

namespace NSExt;

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
