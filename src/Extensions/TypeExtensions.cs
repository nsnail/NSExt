namespace NSExt.Extensions;

/// <summary>
///     TypeExtensions
/// </summary>
public static class TypeExtensions
{
    /// <summary>
    ///     搜索此成员的继承链以查找自定义属性，接口也会被搜索。
    /// </summary>
    public static IEnumerable<T> GetCustomAttributesIncludingBaseInterfaces<T>(this Type me)
    {
        var attributeType = typeof(T);
        return me.GetCustomAttributes(attributeType, true)
                 .Union(me.GetInterfaces()
                          .SelectMany(interfaceType => interfaceType.GetCustomAttributes(attributeType, true)))
                 .Cast<T>();
    }
}