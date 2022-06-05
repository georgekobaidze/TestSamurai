using TestSamurai.MockingScenarios;

var videoService = new VideoService();
var title = videoService.ReadVideoTitle();

Console.WriteLine(title);
