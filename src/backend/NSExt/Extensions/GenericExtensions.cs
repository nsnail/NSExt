namespace NSExt.Extensions;

/// <summary>
///     GenericExtensions
/// </summary>
public static class GenericExtensions
{
    /// <summary>
    ///     从指定的对象拷贝属性
    /// </summary>
    /// <typeparam name="T">对象类型</typeparam>
    /// <param name="me">me</param>
    /// <param name="copyObj">拷贝来源</param>
    /// <param name="propNameList">需要处理的属性名</param>
    /// <param name="isIncludeOrExclude">True包含，false排除</param>
    public static void CopyFrom<T>(this T me, T copyObj, IList<string> propNameList = null
                                 , bool   isIncludeOrExclude = false)
    {
        foreach (var p in me.GetType().GetProperties()) {
            if (!p.CanWrite) {
                continue;
            }

            var isSet = isIncludeOrExclude
                ? propNameList?.Contains(p.Name)  ?? false
                : !propNameList?.Contains(p.Name) ?? true;
            if (isSet) {
                p.SetValue(me, copyObj.GetType().GetProperty(p.Name)?.GetValue(copyObj, null), null);
            }
        }
    }

    /// <summary>
    ///     判断是否与某对象相等
    /// </summary>
    public static T Is<T>(this T me, T compare, T ret)
        where T : struct
    {
        return me.Equals(compare) ? ret : me;
    }
}