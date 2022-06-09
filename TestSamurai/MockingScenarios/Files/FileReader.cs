namespace TestSamurai.MockingScenarios.Files;

public class FileReader : IFileReader
{
    public string Read() => File.ReadAllText("../../../Assets/video.txt");
}
