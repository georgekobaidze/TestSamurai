using NUnit.Framework;
using TestSamurai.MockingScenarios;

namespace TestSamurai.NUnitTests.MockingScenarios;

[TestFixture]
public class VideoServiceTests
{
    [Test]
    public void ReadVideoTitle_VideoIsEmpty_ResultContainsError()
    {
        var videoService = new VideoService(new FakeFileReader());
        var result = videoService.ReadVideoTitle();

        Assert.That(result, Does.Contain("error").IgnoreCase);
    }
}
