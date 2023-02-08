using NSExt.Attributes;
using NSExt.Extensions;
using Xunit;
using Xunit.Abstractions;

namespace NSExt.Tests;

/// <summary>
///     测试用例
/// </summary>
public class TestCase
{
    private readonly ITestOutputHelper _testOutputHelper;

    public TestCase(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    public enum MyEnum
    {
        [ResourceDescription<TestCase>(nameof(Description))]
        Online = 1

      , Offline = 2
    }

    public static string Description { get; set; } = "123";

    /// <summary>
    ///     Case1
    /// </summary>
    [Fact]
    public void Case1()
    {
        var test = MyEnum.Online.ResDesc<TestCase>();

        _testOutputHelper.WriteLine(test);
        Assert.True(test is not null);
    }
}