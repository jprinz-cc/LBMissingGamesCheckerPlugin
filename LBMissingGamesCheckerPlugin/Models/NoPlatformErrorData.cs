namespace LBMissingGamesCheckerPlugin.Models
{
    public class NoPlatformErrorData
    {
        public string Title { get; set; }
        public string Platform { get; set; }
        public string LaunchBoxDbId { get; set; }

        public NoPlatformErrorData(string title, string platform, int? launchBoxDbId)
        {
            Title = title;
            Platform = platform;
            LaunchBoxDbId = launchBoxDbId.ToString();
        }
    }
}
