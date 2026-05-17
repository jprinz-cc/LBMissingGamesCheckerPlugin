using LBMissingGamesCheckerPlugin.Models;
using Microsoft.Data.Sqlite;

namespace LBMissingGamesCheckerPlugin.Data
{
    public enum MetadataStatus
    {
        SqliteFound,
        XmlFound,
        Missing
    }

    public class MetadataRepository
    {
        private readonly string _dbPath;
        private readonly string _xmlPath;

        public MetadataRepository()
        {
            // Locate the LaunchBox Metadata folder
            string currentFolder = AppDomain.CurrentDomain.BaseDirectory;
            string launchboxRootFolder = currentFolder.Replace("\\Core", "");

            _dbPath = Path.Combine(launchboxRootFolder, "Metadata", "LaunchBox.Metadata.db");
            _xmlPath = Path.Combine(launchboxRootFolder, "Metadata", "metadata.xml");
        }

        public MetadataStatus CheckMetadataStatus()
        {
            if (File.Exists(_dbPath)) return MetadataStatus.SqliteFound;
            if (File.Exists(_xmlPath)) return MetadataStatus.XmlFound;
            return MetadataStatus.Missing;
        }

        // Fetch only the games for the selected platform
        public async Task<List<MetadataDbGame>> GetGamesForPlatformAsync(string platformName)
        {
            var games = new List<MetadataDbGame>();

            if (CheckMetadataStatus() != MetadataStatus.SqliteFound) return games;

            using (var connection = new SqliteConnection($"Data Source={_dbPath};Mode=ReadOnly"))
            {
                await connection.OpenAsync();

                // Fetch the base games
                string gameQuery = @"
                    SELECT DatabaseID, Name, Developer, Publisher, ReleaseDate, 
                           CommunityRating, CommunityRatingCount, Platform, ReleaseType, 
                           Genres, MaxPlayers, VideoURL, WikipediaURL 
                    FROM Games 
                    WHERE Platform = @Platform";

                using (var command = new SqliteCommand(gameQuery, connection))
                {
                    command.Parameters.AddWithValue("@Platform", platformName);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var gameId = reader.GetInt32(0);

                            DateTime? releaseDate = null;
                            if (!reader.IsDBNull(4) && DateTime.TryParse(reader.GetString(4), out DateTime parsedDate))
                            {
                                releaseDate = parsedDate;
                            }

                            var game = new MetadataDbGame(
                                title: reader.IsDBNull(1) ? string.Empty : reader.GetString(1),
                                developer: reader.IsDBNull(2) ? string.Empty : reader.GetString(2),
                                publisher: reader.IsDBNull(3) ? string.Empty : reader.GetString(3),
                                region: string.Empty,
                                releaseDate: releaseDate,
                                starRating: reader.IsDBNull(5) ? 0f : reader.GetFloat(5),
                                starVotes: reader.IsDBNull(6) ? 0 : reader.GetInt32(6),
                                platform: reader.IsDBNull(7) ? string.Empty : reader.GetString(7),
                                releaseType: reader.IsDBNull(8) ? string.Empty : reader.GetString(8),
                                genres: reader.IsDBNull(9) ? string.Empty : reader.GetString(9),
                                alternateNames: new Unbroken.LaunchBox.Plugins.Data.IAlternateName[0],
                                maxPlayers: reader.IsDBNull(10) ? 0 : reader.GetInt32(10),
                                lbdbId: gameId,
                                vidUrl: reader.IsDBNull(11) ? string.Empty : reader.GetString(11),
                                wikiUrl: reader.IsDBNull(12) ? string.Empty : reader.GetString(12)
                            );

                            games.Add(game);
                        }
                    }
                }

                // Fetch Alternate Names & Regions ONLY for the games on this platform
                string altNameQuery = @"
                    SELECT DatabaseID, AlternateName, Region 
                    FROM GameAlternateTitles 
                    WHERE DatabaseID IN (SELECT DatabaseID FROM Games WHERE Platform = @Platform)";

                var altNamesDict = new Dictionary<int, List<MetadataDbAlternateName>>();

                using (var altCommand = new SqliteCommand(altNameQuery, connection))
                {
                    altCommand.Parameters.AddWithValue("@Platform", platformName);

                    using (var reader = await altCommand.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            int dbId = reader.GetInt32(0);
                            var altName = new MetadataDbAlternateName(
                                databaseID: dbId.ToString(),
                                alternateName: reader.IsDBNull(1) ? string.Empty : reader.GetString(1),
                                region: reader.IsDBNull(2) ? string.Empty : reader.GetString(2)
                            );

                            if (!altNamesDict.ContainsKey(dbId))
                            {
                                altNamesDict[dbId] = new List<MetadataDbAlternateName>();
                            }
                            altNamesDict[dbId].Add(altName);
                        }
                    }
                }

                // Attach Alternate Names to their respective games
                foreach (var game in games)
                {
                    if (game.LaunchBoxDbId.HasValue && altNamesDict.TryGetValue(game.LaunchBoxDbId.Value, out var altNames))
                    {
                        game.AlternateNames = altNames.ToArray();

                        foreach (var alt in altNames)
                        {
                            if (!string.IsNullOrEmpty(alt.Region))
                            {
                                game.Region = alt.Region;
                                break;
                            }
                        }
                    }
                }
            }

            return games;
        }
    }
}
