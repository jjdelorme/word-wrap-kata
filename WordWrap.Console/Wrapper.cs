namespace WordWrap.Library;

public class Wrapper
{
    public static string Wrap(string text, int lineLength)
    {
        if (text?.Length < lineLength)
            return text;
        else
            return "";
    }
}