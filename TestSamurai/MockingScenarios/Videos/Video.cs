using Newtonsoft.Json;

namespace TestSamurai.MockingScenarios.Videos;
public class Video
{
    [JsonProperty(PropertyName = "id")]
    public int Id { get; set; }

    [JsonProperty(PropertyName = "title")]
    public string Title { get; set; }

    [JsonProperty(PropertyName = "isProcessed")]
    public bool IsProcessed { get; set; }
}
