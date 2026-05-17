using System;
using Unbroken.LaunchBox.Plugins.Data;

namespace LBMissingGamesCheckerPlugin.Models
{
    public class MetadataDbGame
    {
        public string Title { get; set; }
        public string Developer { get; set; }
        public string Publisher { get; set; }
        public string Region { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public float? CommunityStarRating { get; set; }
        public int? CommunityStarRatingTotalVotes { get; set; }
        public string Platform { get; set; }
        public string ReleaseType { get; set; }
        public string Genres { get; set; }
        public IAlternateName[] AlternateNames { get; set; } = new IAlternateName[0];
        public int? MaxPlayers { get; set; }
        public int? LaunchBoxDbId { get; set; }
        public string VideoUrl { get; set; }
        public string WikipediaUrl { get; set; }

        public MetadataDbGame(
            string title,
            string developer,
            string publisher,
            string region,
            DateTime? releaseDate,
            float? starRating,
            int? starVotes,
            string platform,
            string releaseType,
            string genres,
            IAlternateName[] alternateNames,
            int? maxPlayers,
            int? lbdbId,
            string vidUrl,
            string wikiUrl
            )
        {
            Title = title;
            Developer = developer ?? string.Empty;
            Publisher = publisher ?? string.Empty;
            Region = region ?? string.Empty;
            ReleaseDate = releaseDate;
            CommunityStarRating = starRating;
            CommunityStarRatingTotalVotes = starVotes;
            Platform = platform ?? string.Empty;
            ReleaseType = releaseType ?? string.Empty;
            Genres = genres ?? string.Empty;
            AlternateNames = alternateNames ?? new IAlternateName[0];
            MaxPlayers = maxPlayers;
            LaunchBoxDbId = lbdbId;
            VideoUrl = vidUrl ?? string.Empty;
            WikipediaUrl = wikiUrl ?? string.Empty;
        }
    }
}
