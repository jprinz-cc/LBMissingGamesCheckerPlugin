using Unbroken.LaunchBox.Plugins.Data;

namespace LBMissingGamesCheckerPlugin.Models
{
    public class GameDisplayData
    {
        public string Title { get; set; }
        public string Developer { get; set; }
        public string Publisher { get; set; }
        public string Region { get; set; }
        public string ReleaseDate { get; set; }
        public string CommunityStarRating { get; set; }
        public string CommunityStarRatingTotalVotes { get; set; }
        public string Platform { get; set; }
        public string ReleaseType { get; set; }
        public string Genres { get; set; }
        public string AlternateNames { get; set; }
        public string MaxPlayers { get; set; }
        public string LaunchBoxDbId { get; set; }
        public string VideoUrl { get; set; }
        public string WikipediaUrl { get; set; }

        public GameDisplayData(XmlGame game)
        {
            Title = game.Title ?? string.Empty;
            Developer = game.Developer ?? string.Empty;
            Publisher = game.Publisher ?? string.Empty;
            Region = game.Region ?? string.Empty;
            ReleaseDate = game.ReleaseDate?.ToShortDateString() ?? string.Empty;
            CommunityStarRating = game.CommunityStarRating != 0 ? game.CommunityStarRating.ToString() : string.Empty;
            CommunityStarRatingTotalVotes = game.CommunityStarRatingTotalVotes != 0 ? game.CommunityStarRatingTotalVotes.ToString() : string.Empty;
            Platform = game.Platform ?? string.Empty;
            ReleaseType = game.ReleaseType ?? string.Empty;
            Genres = game.Genres ?? string.Empty;
            AlternateNames = GetAltNames(game.AlternateNames) ?? string.Empty;
            MaxPlayers = game.MaxPlayers.ToString() ?? string.Empty;
            LaunchBoxDbId = game.LaunchBoxDbId != 0 ? game.LaunchBoxDbId.ToString() : string.Empty;
            VideoUrl = game.VideoUrl ?? string.Empty;
            WikipediaUrl = game.WikipediaUrl ?? string.Empty;
        }

        private string GetAltNames(IAlternateName[] altNames)
        {
            string resultAlt = string.Empty;
            if (altNames != null && altNames.Length > 0)
            {
                foreach (var item in altNames)
                {
                    if (!string.IsNullOrWhiteSpace(item.Name) && resultAlt != string.Empty)
                    {
                        resultAlt += "; " + item.Name;
                    }
                    else if (!string.IsNullOrWhiteSpace(item.Name))
                    {
                        resultAlt += item.Name;
                    }
                }
            }
            return resultAlt;
        }
    }
}