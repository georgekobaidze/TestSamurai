namespace TestSamurai.SimpleScenarios;

public class TextFormatter
{
    public string MakeBold(string text)
    {
        if (string.IsNullOrWhiteSpace(text))
            throw new ArgumentNullException(nameof(text));

        return $"<strong>{text}</strong>";
    }
}
