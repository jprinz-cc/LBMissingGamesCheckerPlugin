using Unbroken.LaunchBox.Plugins.Data;

namespace LBMissingGamesCheckerPlugin.Models
{
    public class MetadataDbAlternateName : IAlternateName
    {
        public string Name { get; set; }
        public string GameId { get; set; }
        public string Region { get; set; }

        public MetadataDbAlternateName(string databaseID, string alternateName, string region)
        {
            Name = alternateName ?? string.Empty;
            GameId = databaseID;
            Region = region ?? string.Empty;
        }
    }
}
