using TestSamurai.MockingScenarios.Videos;

var videoService = new VideoService();
var title = videoService.ReadVideoTitle();

Console.WriteLine(title);

var unprocessedVideos = videoService.GetUnprocessedVideoAsCsv();
Console.WriteLine(unprocessedVideos);
