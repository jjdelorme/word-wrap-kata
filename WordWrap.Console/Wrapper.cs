namespace WordWrap.Library;

public class Wrapper
{
    int lineLength;

    public Wrapper(int lineLength)
    {
        this.lineLength = lineLength;
    }

    public static string Wrap(string text, int lineLength)
    {
        return new Wrapper(lineLength).Wrap(text);
    }

    public string Wrap(string text)
    {
        if (lineLength <= 0)
            throw new ArgumentOutOfRangeException("lineLength", "Must be greater than 0.");

        if (string.IsNullOrEmpty(text))
            return "";

        text = text.Trim();

        if (text.Length <= lineLength)
        {
            return text;
        }
        else
        {
            return BreakLine(text);
        }
    }

    private string BreakLine(string text)
    {
        int breakPoint = GetBreakPoint(text);

        string line = text.Substring(0, breakPoint).Trim();

        return line + '\n' +
            Wrap(text.Substring(breakPoint));
    }

    private int GetBreakPoint(string text)
    {
        int space = text.LastIndexOf(' ');
        
        if (space > 0)
            return space;
        else
            return lineLength;
    }
}