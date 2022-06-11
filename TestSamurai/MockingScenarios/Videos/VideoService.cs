using Newtonsoft.Json;
using TestSamurai.MockingScenarios.Files;
using TestSamurai.MockingScenarios.Videos.Context;

namespace TestSamurai.MockingScenarios.Videos;
public class VideoService
{
    private readonly IFileReader _fileReader;
    private readonly IVideoContext _videoContext;

    public VideoService(
        IFileReader? fileReader = null,
        IVideoContext? videoContext = null)
    {
        _fileReader = fileReader ?? new FileReader();
        _videoContext = videoContext ?? new VideoContext();
    }
    

    public string ReadVideoTitleWithoutLooseCoupling()
    {
        var str = new FileReader().Read(); // We can't mock this class in a test method
        var video = JsonConvert.DeserializeObject<Video>(str);
        if (video == null)
            return "Error while parsing the video";

        return video.Title;
    }

    public string ReadVideoTitle()
    {
        var str = _fileReader.Read();
        var video = JsonConvert.DeserializeObject<Video>(str);
        if (video == null)
            return "Error while parsing the video";

        return video.Title;
    }

    public string GetUnprocessedVideoAsCsv()
    {
        var videoIds = _videoContext.Videos.Where(x => !x.IsProcessed).Select(x => x.Id);

        return string.Join(", ", videoIds);
    }
}
