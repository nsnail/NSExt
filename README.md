# ns-ext
[中](README.zh-CN.md) | **En**
The **ns-ext** is a .NET extension function library, containing the following types of extension modules:


| Features | File name |
| -------- | ---------------------------------- |
| Byte type extension | ByteExtensions.cs |
|  Character Type Extensions | CharExtensions.cs |
| Date Type Extensions | DateTimeExtensions.cs |
| Database command type extension | DbCommandExtensions.cs |
| Decimal Number Type extension | DecimalExtensions.cs |
| Enumable type extension | EnumerableExtensions.cs |
| Enumeration type extension | EnumExtensions.cs |
| General type extension | GenericExtensions.cs |
| Integer type extension | IntExtensions.cs |
| Json Serialization option type extension | JsonSerializerOptionsExtensions.cs |
| Log type extension | LoggerExtensions.cs |
| Long integer extension | LongExtensions.cs |
| Object type extension | ObjectExtensions.cs |
| Stream type extension | StreamExtensions.cs |
|  String type extension | StringExtensions.cs |
| Prototype type extension | TypeExtensions.cs |
| Resource locator type extension | UriExtensions.cs |

## Quick start

### Install

```shell
dotnet add package NSExt --prerelease
```

### Example

```c#
using NSExt.Extensions;

internal static class Program
{
    private class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
    public static void Main(string[] args)
    {
        var person =
        """
{
  "Name": "Jason",
  "Age": "30"
}
""".Object<Person>();

        Console.WriteLine(person.Json());
    }
}
```

### Output

```json
{"name":"Jason","age":30}
```