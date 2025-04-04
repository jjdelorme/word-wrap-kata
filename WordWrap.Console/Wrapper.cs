namespace WordWrap.Library;

public class Wrapper
{
    public static string[] Wrap(string text, int lineLength)
    {
        int start = 0;
        var result = new List<string>();

        while (start < text.Length)
        {
            var line = GetLine(text, start, lineLength);
            result.Add(line.Text);
            start = line.LineBreakPosition;
        }

        return result.ToArray();
    }

    private static Line GetLine(string text, int start, int lineLength)
    {
        start = AdvanceForLeadingSpaces(text, start);

        int lineBreak = GetLineBreakPosition(text, start, lineLength);
        bool forceBreak = lineBreak == -1;

        if (forceBreak)
        {
            lineBreak = start + lineLength - 1;
        }

        string lineText = text.Substring(start, lineBreak - start).Trim();

        if (forceBreak)
        {
            lineText += "-";
        }

        return new(lineText, lineBreak);
    }

    private static int AdvanceForLeadingSpaces(string text, int start)
    {
        while (start < text.Length && text[start] == ' ')
        {
            start++;
        }

        return start;
    }

    private static int GetLineBreakPosition(string text, int start, int lineLength)
    {
        int lineBreak = start + lineLength;

        if (text.Length <= lineBreak)
        {
            return text.Length;
        }

        int index = text.LastIndexOf(' ', lineBreak);

        if (index < start)
            return -1;

        return index;
    }

    private record Line(string Text, int LineBreakPosition);
}