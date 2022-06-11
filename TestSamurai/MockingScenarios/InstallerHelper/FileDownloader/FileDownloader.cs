namespace TestSamurai.MockingScenarios.InstallerHelper.FileDownloader;
public class FileDownloader : IFileDownloader
{
    public async Task DownloadFileAsync(string url) => await new HttpClient().GetAsync(url);
}
