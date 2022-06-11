using System;
using System.Net;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using TestSamurai.MockingScenarios.InstallerHelper;
using TestSamurai.MockingScenarios.InstallerHelper.FileDownloader;

namespace TestSamurai.NUnitTests.MockingScenarios.InstallHelper;

[TestFixture]
public class InstallHelperTests
{
    private Mock<IFileDownloader> _fileDownloader;
    private InstallerHelper _installerHelper;

    [SetUp]
    public void SetUp()
    {
        _fileDownloader = new Mock<IFileDownloader>();
        _installerHelper = new InstallerHelper(_fileDownloader.Object);
    }

    [Test]
    public async Task DownloadInstallerAsync_NetworkFailure_ReturnFalse()
    {
        /*_fileDownloader.Setup(x => x.DownloadFileAsync("https://example.com/customer/installer")).Throws<WebException>();*/ // The exception will only be thrown if https://example.com/customer/installer is passed as an argument

        // To make it more generic we should write it like:
        _fileDownloader.Setup(x => x.DownloadFileAsync(It.IsAny<string>())).Throws<WebException>();
        var result = await _installerHelper.DownloadInstallerAsync("customer", "installer");

        Assert.That(result, Is.False);
    }

    [Test]
    public async Task DownloadInstallerAsync_Success_ReturTrue()
    {
        _fileDownloader.Setup(x => x.DownloadFileAsync(It.IsAny<string>())).Returns(Task.CompletedTask);
        var result = await _installerHelper.DownloadInstallerAsync("customer", "installer");

        Assert.That(result, Is.True);
    }
}
