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
        var typeOfEnum  = e.GetType();
        var typeOfField = typeOfEnum.GetField(Enum.GetName(typeOfEnum, e)!);
        var descAttr    = typeOfField!.GetCustomAttribute<DescriptionAttribute>(true);
        if (descAttr is null) {
            return Enum.GetName(typeOfEnum, e);
        }

        var str     = descAttr.Description;
        var locAttr = typeOfField!.GetCustomAttribute<LocalizationAttribute>(true);
        return locAttr is null ? str : locAttr.ResourceClass.GetProperty(str)?.GetValue(default) as string ?? str;
    }

    /// <summary>
    ///     获取枚举的本地化资源描述
    /// </summary>
    public static string ResDesc<T>(this Enum e)
    {
        var typeOfEnum  = e.GetType();
        var typeOfField = typeOfEnum.GetField(Enum.GetName(typeOfEnum, e)!);
        var resDescAttr = typeOfField!.GetCustomAttribute<ResourceDescriptionAttribute<T>>(true);
        return resDescAttr is null
            ? Enum.GetName(typeOfEnum, e)
            : typeof(T).GetProperty(resDescAttr.ResourceName)?.GetValue(default) as string;
    }
}