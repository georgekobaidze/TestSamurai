using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using TestSamurai.MockingScenarios.Files;
using TestSamurai.MockingScenarios.Videos;
using TestSamurai.MockingScenarios.Videos.Context;

namespace TestSamurai.NUnitTests.MockingScenarios.Videos;

[TestFixture]
public class VideoServiceTests
{
    private VideoService _videoService;
    private Mock<IFileReader> _fileReader;
    private Mock<IVideoContext> _videoContext;

    [SetUp]
    public void SetUp()
    {
        _fileReader = new Mock<IFileReader>();
        _videoContext = new Mock<IVideoContext>();
        _videoService = new VideoService(_fileReader.Object, _videoContext.Object);
    }

    [Test]
    public void ReadVideoTitle_VideoIsEmpty_ResultContainsError()
    {
        _fileReader.Setup(fr => fr.Read()).Returns("");
        var result = _videoService.ReadVideoTitle();

        Assert.That(result, Does.Contain("error").IgnoreCase);
    }

    [Test]
    public void GetUnprocessedVideo_AllVideosAreProcessed_ReturnEmptyString()
    {
        _videoContext.Setup(c => c.Videos).Returns(new List<Video>());
        var result = _videoService.GetUnprocessedVideoAsCsv();

        Assert.That(result, Is.EqualTo(""));
    }

    [Test]
    public void GetUnprocessedVideo_SomeVideosAreUnprocessed_ReturnsVideoIdAsString()
    {
        _videoContext.Setup(c => c.Videos).Returns(new List<Video>
        {
            new Video { Id = 1, IsProcessed = false, Title = "Video1" },
            new Video { Id = 2, IsProcessed = false, Title = "Video2" },
            new Video { Id = 3, IsProcessed = false, Title = "Video3" }
        });

        var result = _videoService.GetUnprocessedVideoAsCsv();
        Assert.That(result, Is.EqualTo("1, 2, 3"));
    }
}
