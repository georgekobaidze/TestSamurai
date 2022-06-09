using Newtonsoft.Json;
using TestSamurai.MockingScenarios.Files;

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

public class Video
{
    [JsonProperty(PropertyName = "id")]
    public int Id { get; set; }

    [JsonProperty(PropertyName = "title")]
    public string Title { get; set; }

    [JsonProperty(PropertyName = "isProcessed")]
    public bool IsProcessed { get; set; }
}

public class VideoContext
{
    public List<Video> Videos
    {
        get
        {
            return new List<Video>
            {
                new Video { Id = 1, IsProcessed = true, Title = "Video1" },
                new Video { Id = 2, IsProcessed = true, Title = "Video2" },
                new Video { Id = 3, IsProcessed = false, Title = "Video3" },
                new Video { Id = 4, IsProcessed = true, Title = "Video4" },
                new Video { Id = 5, IsProcessed = true, Title = "Video5" },
                new Video { Id = 6, IsProcessed = false, Title = "Video6" }
            };
        }
    }
}
