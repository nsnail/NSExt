# ns-ext
[En](README.md) | **中**
**ns-ext** 是一个.NET扩展函数库，包含以下类型扩展模块：


| 功能      | 文件名                              |
| -------- | ---------------------------------- |
| 字节类型扩展 | ByteExtensions.cs                  |
| 字符类型扩展 | CharExtensions.cs                  |
| 日期类型扩展 | DateTimeExtensions.cs              |
| 数据库命令类型扩展 | DbCommandExtensions.cs             |
| 十进制数类型扩展 | DecimalExtensions.cs               |
| 可枚举类型扩展 | EnumerableExtensions.cs            |
| 枚举类型扩展 | EnumExtensions.cs                  |
| 泛型类型扩展 | GenericExtensions.cs               |
| 整数型扩展 | IntExtensions.cs                   |
| Json序列化选项类型扩展 | JsonSerializerOptionsExtensions.cs |
| 日志类型扩展 | LoggerExtensions.cs                |
| 长整型扩展 | LongExtensions.cs                  |
| 对象类型扩展 | ObjectExtensions.cs                |
| 流类型扩展 | StreamExtensions.cs                |
| 字符串类型扩展 | StringExtensions.cs                |
| 原型类型扩展 | TypeExtensions.cs                  |
| 资源定位符类型扩展 | UriExtensions.cs                   |

## 快速开始

### 安装

```shell
dotnet add package NSExt --prerelease
```

### 示例

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

### 输出

```json
{"name":"Jason","age":30}
```