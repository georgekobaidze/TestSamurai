using TestSamurai.MockingScenarios.Files;

namespace TestSamurai.NUnitTests.MockingScenarios.Files;
internal class FakeFileReader : IFileReader // Creating mock classes manually isn't the best practice, it's better to use mock libraries, like Moq
{
    public string Read()
    {
        return "";
    }
}
