using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace NSExt.Extensions;

public static class JsonSerializerOptionsExtensions
{
    public static JsonSerializerOptions NewJsonSerializerOptions(this JsonSerializerOptions me)
    {
        return new JsonSerializerOptions {
            ReadCommentHandling         = JsonCommentHandling.Skip,
            AllowTrailingCommas         = true,
            DictionaryKeyPolicy         = JsonNamingPolicy.CamelCase,
            PropertyNamingPolicy        = JsonNamingPolicy.CamelCase,
            Encoder                     = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            NumberHandling              = JsonNumberHandling.AllowReadingFromString | JsonNumberHandling.WriteAsString,
            PropertyNameCaseInsensitive = true
        };
    }
}