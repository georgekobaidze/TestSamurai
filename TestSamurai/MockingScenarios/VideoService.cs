using System.IO;
using Newtonsoft.Json;

namespace TestSamurai.MockingScenarios;
public class VideoService
{
    private readonly IFileReader _fileReader;

    public VideoService(IFileReader fileReader) => _fileReader = fileReader;

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
