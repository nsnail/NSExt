namespace NSExt;

public static class EnumerableExtensions
{
    /// <summary>
    ///     将列表转成分隔符分隔的字符串
    /// </summary>
    /// <param name="me"></param>
    /// <param name="separator"></param>
    /// <returns></returns>
    public static string Join(this IEnumerable<object> me, string separator)
    {
        return string.Join(separator, me);
    }

    /// <summary>
    ///     判断对象是否为null或不存在子元素（如果为集合对象）
    /// </summary>
    /// <typeparam name="T">对象类型</typeparam>
    /// <param name="me">指定对象</param>
    /// <returns>空则返回true</returns>
    public static bool NullOrEmpty<T>(this IEnumerable<T> me)
    {
        return me is null || !me.Any();
    }
}
