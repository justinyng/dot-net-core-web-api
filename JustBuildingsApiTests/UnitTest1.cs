using JustBuildingsApi;
using Xunit;

namespace JustBuildingsApiTests;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        var result = Class1.Add(1, 3);
        Assert.Equal(4, result);
    }
}