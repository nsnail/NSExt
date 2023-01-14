using System.Text.Json;

namespace NSExt.Extensions;

/// <summary>
///     ObjectExtensions
/// </summary>
public static class ObjectExtensions
{
    /// <summary>
    ///     将一个对象序列化成json文本
    /// </summary>
    /// <param name="me">指定对象</param>
    /// <param name="format">是否格式化</param>
    /// <returns>json文本</returns>
    public static string Json(this object me, bool format = false)
    {
        var defaultOptions = default(JsonSerializerOptions).NewJsonSerializerOptions();
        defaultOptions.WriteIndented = format;
        return Json(me, defaultOptions);
    }

    /// <summary>
    ///     将一个对象序列化成json文本
    /// </summary>
    /// <param name="me">指定对象</param>
    /// <param name="options">序列化选项</param>
    /// <returns>json文本</returns>
    public static string Json(this object me, JsonSerializerOptions options)
    {
        return JsonSerializer.Serialize(me, options);
    }
}