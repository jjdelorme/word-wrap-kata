using WordWrap.Library;

namespace WordWrap.Tests;

public class WrapperTests
{
    [Fact]
    public void WrapNullShouldReturnEmptyString()
    {
        Assert.Equal("", Wrapper.Wrap(null, 10));
    }

    [Fact]
    public void WrapEmptyStringShouldReturnEmptyString()
    {
        Assert.Equal("", Wrapper.Wrap("", 10));
    }

    [Fact]
    public void OneShortWordDoesNotWrap()
    {
        Assert.Equal("hello", Wrapper.Wrap("hello", 10));
    }
}