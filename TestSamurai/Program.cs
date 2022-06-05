using TestSamurai.MockingScenarios;

var videoService = new VideoService(new FileReader());
var title = videoService.ReadVideoTitle();

Console.WriteLine(title);
