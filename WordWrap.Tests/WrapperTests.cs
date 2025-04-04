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
    public void Wrap0LineLengthShouldThrowException()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => Wrapper.Wrap("hello", 0));
    }

    [Fact]
    public void OneShortWordDoesNotWrap()
    {
        Assert.Equal("hello", Wrapper.Wrap("hello", 10));
    }

    [Fact]
    public void OneWordLongerThanLimitShouldWrap()
    {
        Assert.Equal("long\nword", Wrapper.Wrap("longword", 4));
        Assert.Equal("longer\nword", Wrapper.Wrap("longerword", 6));
    }

    [Fact]
    public void WordLongerThanTwiceLengthShouldBreakTwice()
    {
        Assert.Equal("very\nlong\nword", Wrapper.Wrap("verylongword", 4));
    }

    [Fact]
    public void TwoWordsLongerThanLimitShouldWrap()
    {
        Assert.Equal("word\nword", Wrapper.Wrap("word word", 6));
        Assert.Equal("wrap\nhere", Wrapper.Wrap("wrap here", 6));
    }

    [Fact]
    public void DoubleSpaceShouldTrim()
    {
        Assert.Equal("more\nspace", Wrapper.Wrap("more  space", 5));
    }

    [Fact]
    public void ThreeWordsJustOverTheLimitShouldWrapAtSecondWord()
    {
        Assert.Equal("word word\nword", Wrapper.Wrap("word word word", 9));
    }

}