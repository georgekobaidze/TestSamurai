namespace TestSamurai.MockingScenarios.Videos.Context;
public class VideoContext : IVideoContext
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
