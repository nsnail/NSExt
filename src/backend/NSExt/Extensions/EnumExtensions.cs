using System.ComponentModel.DataAnnotations;
using System.Reflection;
using NSExt.Attributes;

namespace NSExt.Extensions;

/// <summary>
///     EnumExtensions
/// </summary>
public static class EnumExtensions
{
    /// <summary>
    ///     获取显示特性
    /// </summary>
    public static DisplayAttribute GetDisplay(this Enum me)
    {
        return me.GetAttributeOfType<DisplayAttribute>();
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

    /// <summary>
    ///     通过类泛型类型获取特性
    /// </summary>
    private static T GetAttributeOfType<T>(this Enum me)
        where T : Attribute
    {
        return me.GetType().GetMember(me.ToString())[0].GetCustomAttributes<T>(false).FirstOrDefault();
    }
}