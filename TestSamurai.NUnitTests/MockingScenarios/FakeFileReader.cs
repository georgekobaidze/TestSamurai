using TestSamurai.MockingScenarios;

namespace TestSamurai.NUnitTests.MockingScenarios;
internal class FakeFileReader : IFileReader
{
    public string Read()
    {
        return "";
    }
}
