using Newtonsoft.Json;

namespace NSExt;

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
        return JsonConvert.SerializeObject(me, format ? Formatting.Indented : Formatting.None);
    }
}
