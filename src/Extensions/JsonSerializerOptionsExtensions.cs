using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace NSExt.Extensions;

/// <summary>
///     JsonSerializerOptionsExtensions
/// </summary>
public static class JsonSerializerOptionsExtensions
{
    /// <summary>
    ///     NewJsonSerializerOptions
    /// </summary>
    public static JsonSerializerOptions NewJsonSerializerOptions(this JsonSerializerOptions _)
    {
        return new JsonSerializerOptions {
                                             ReadCommentHandling  = JsonCommentHandling.Skip
                                           , AllowTrailingCommas  = true
                                           , DictionaryKeyPolicy  = JsonNamingPolicy.CamelCase
                                           , PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                                           , Encoder              = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
                                           , NumberHandling
                                                 = JsonNumberHandling.AllowReadingFromString |
                                                   JsonNumberHandling.WriteAsString
                                           , PropertyNameCaseInsensitive = true
                                         };
    }
}