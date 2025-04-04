using WordWrap.Library;

namespace WordWrap.Tests;

public class WrapperTests
{
    [Fact]
    public void WrapNullShouldReturnEmptyString()
    {
        Assert.Equal("", Wrapper.Wrap(null, 10));
    }
}