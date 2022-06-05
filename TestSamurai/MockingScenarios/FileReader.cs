namespace TestSamurai.MockingScenarios;

public class FileReader : IFileReader
{
    public string Read() => File.ReadAllText("../../../Assets/video.txt");
}
