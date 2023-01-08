using System.Reflection;
using NSExt.Attributes;

namespace NSExt.Extensions;

/// <summary>
///     EnumExtensions
/// </summary>
public static class EnumExtensions
{
    /// <summary>
    ///     获取枚举的description属性
    /// </summary>
    /// <param name="e">枚举对象</param>
    /// <returns>description属性</returns>
    public static string Desc(this Enum e)
    {
        var t        = e.GetType();
        var fi       = t.GetField(Enum.GetName(t, e)!);
        var descAttr = fi!.GetCustomAttribute<DescriptionAttribute>(false);
        if (descAttr is null) {
            return Enum.GetName(t, e);
        }

        var str     = descAttr.Description;
        var locAttr = fi!.GetCustomAttribute<LocalizationAttribute>(false);
        return locAttr is null ? str : locAttr.ResourceClass.GetProperty(str)?.GetValue(default) as string ?? str;
    }
}