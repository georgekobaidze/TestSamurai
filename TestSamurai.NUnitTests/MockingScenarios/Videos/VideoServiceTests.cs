﻿using Moq;
using NUnit.Framework;
using TestSamurai.MockingScenarios.Files;
using TestSamurai.MockingScenarios.Videos;

namespace TestSamurai.NUnitTests.MockingScenarios.Videos;

[TestFixture]
public class VideoServiceTests
{
    private VideoService _videoService;

    [SetUp]
    public void SetUp()
    {
        var fileReader = new Mock<IFileReader>();
        fileReader.Setup(fr => fr.Read()).Returns("");

        _videoService = new VideoService(fileReader.Object);
    }

    [Test]
    public void ReadVideoTitle_VideoIsEmpty_ResultContainsError()
    {
        var result = _videoService.ReadVideoTitle();

        Assert.That(result, Does.Contain("error").IgnoreCase);
    }
}
