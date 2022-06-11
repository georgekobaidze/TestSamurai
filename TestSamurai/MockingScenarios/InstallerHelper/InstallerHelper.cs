using System.Net;
using TestSamurai.MockingScenarios.InstallerHelper.FileDownloader;

namespace TestSamurai.MockingScenarios.InstallerHelper;
public class InstallerHelper
{
    private readonly IFileDownloader _fileDownloader;

    public InstallerHelper(IFileDownloader fileDownloader) => _fileDownloader = fileDownloader;

    public async Task<bool> DownloadInstallerAsync(string customerName, string installerName)
    {
        try
        {
            var url = $"https://example.com/{customerName}/{installerName}";
            await _fileDownloader.DownloadFileAsync(url);

            return true;
        }
        catch (WebException)
        {
            return false;
        }
    }
}
