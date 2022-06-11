namespace TestSamurai.MockingScenarios.InstallerHelper.FileDownloader;
public interface IFileDownloader
{
    public Task DownloadFileAsync(string url);
}
