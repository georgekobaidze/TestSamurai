using Newtonsoft.Json;
using TestSamurai.MockingScenarios.Files;
using TestSamurai.MockingScenarios.Videos.Context;

namespace TestSamurai.MockingScenarios.Videos;
public class VideoService
{
    private readonly IFileReader _fileReader;

    public VideoService(IFileReader fileReader = null) => _fileReader = fileReader ?? new FileReader();

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
        var context = new VideoContext();
        var videoIds = context.Videos.Where(x => !x.IsProcessed).Select(x => x.Id);

        return string.Join(", ", videoIds);
    }
}
