using NSExt.Extensions;
using Xunit;

namespace NSExt;

/// <summary>
///     所有测试用例
/// </summary>
public class AllTests
{
    /// <summary>
    ///     IsJsonString
    /// </summary>
    [Fact]
    public void IsJsonString()
    {
        Assert.True("{\"a\":\"b\"}".IsJsonString());
    }
}