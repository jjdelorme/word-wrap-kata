using NuGet.Frameworks;
using WordWrap.Library;

namespace WordWrap.Tests;

public class WrapperTests
{
    [Fact]
    public void ItReturnsASingleLineWhenStringIsLessThan80Chars()
    {
        string text = "foo";

        Assert.Single(Wrapper.Wrap(text, 80));
    }

    [Fact]
    public void ItReturns2Lines()
    {
        string text = "The grey fox jumped over the brown cow.";

        var result = Wrapper.Wrap(text, 19);
        Assert.Equal(2, result.Length);
        Assert.Equal("The grey fox jumped", result[0]);
        Assert.Equal("over the brown cow.", result[1]);
    }

    [Fact]
    public void ItReturnsMoreThan2Lines()
    {
        string text = "The grey fox jumped over the brown cow.  " +
            "The grey fox jumped over the brown cow.";

        var result = Wrapper.Wrap(text, 19);
        Assert.Equal(4, result.Length);
        Assert.Equal("The grey fox jumped", result[0]);
        Assert.Equal("over the brown cow.", result[1]);
        Assert.Equal("over the brown cow.", result[3]);
    }

    [Fact]
    public void ItHandlesWordsAtTheLineEndingBoundary()
    {
        string text = "The grey fox jumped over the brown cow.";
        
        var result = Wrapper.Wrap(text, 22);
        Assert.Equal(2, result.Length);
        Assert.Equal("The grey fox jumped", result[0]);
        Assert.Equal("over the brown cow.", result[1]);
    }

    [Fact]
    public void ItHandlesWordsThatAreLongerThanTheLineLength()
    {
        // TODO: in the future we may want to support this by focing a break with a -
        string text = "Thegreyfoxjumpedoverthebrowncow.";
        
        var result = Wrapper.Wrap(text, 20);
        Assert.Equal(2, result.Length);
        Assert.Equal("Thegreyfoxjumpedove-", result[0]);
        Assert.Equal("rthebrowncow.", result[1]);
    }
}