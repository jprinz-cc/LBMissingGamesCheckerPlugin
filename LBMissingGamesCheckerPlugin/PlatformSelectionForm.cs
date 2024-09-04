using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;
using Unbroken.LaunchBox.Plugins;
using Unbroken.LaunchBox.Plugins.Data;

namespace LBMissingGamesCheckerPlugin
{
    public partial class PlatformSelectionForm : Form
    {
        public string SelectedPlatform { get; private set; }

        // Class to hold game data to display
        public class GameDisplayData
        {
            public string Title { get; set; }
            public string Developer { get; set; }
            public string Publisher { get; set; }
            public string ReleaseDate { get; set; }
            public string CommunityStarRating { get; set; }
            public string CommunityStarRatingTotalVotes { get; set; }
            public string Platform { get; set; }
            public string ReleaseType { get; set; }
            public string LaunchBoxDbId { get; set; }
            public string VideoUrl { get; set; }
            public string WikipediaUrl { get; set; }

            // Constructor to initialize properties from MissingGame
            public GameDisplayData(MissingGame game)
            {
                Title = game.Title ?? "";
                Developer = game.Developer ?? "";
                Publisher = game.Publisher ?? "";
                ReleaseDate = game.ReleaseDate?.ToShortDateString() ?? "";
                CommunityStarRating = game.CommunityStarRating != 0 ? game.CommunityStarRating.ToString() : (string)null;
                CommunityStarRatingTotalVotes = game.CommunityStarRatingTotalVotes != 0 ? game.CommunityStarRatingTotalVotes.ToString() : (string)null;
                Platform = game.Platform ?? "";
                ReleaseType = game.ReleaseType ?? "";
                LaunchBoxDbId = game.LaunchBoxDbId != 0 ? game.LaunchBoxDbId.ToString() : (string)null;
                VideoUrl = game.VideoUrl ?? "";
                WikipediaUrl = game.WikipediaUrl ?? "";
            }
        }

        // Lists to hold sorted games
        private IList<IGame> ownedGames;
        private IList<MissingGame> missingGames;

        // Properties to toggle sort order in the GridViews
        private string lastSortedColumn = string.Empty;
        private bool ascending = true;

        public PlatformSelectionForm(IList<IPlatform> platforms)
        {
            InitializeComponent();

            // Populate dropdown with user platforms
            foreach (var platform in platforms)
            {
                platformDropdown.Items.Add(platform.Name);
            }

            // Set column sort modes
            foreach (DataGridViewColumn column in ownedGamesGridView.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.Automatic;
            }

            foreach (DataGridViewColumn column in missingGamesGridView.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.Automatic;
            }
        }

        // Confirm button for dropdown platform selection
        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            if (platformDropdown.SelectedItem != null || platformDropdown.SelectedIndex <= 0)
            {
                SelectedPlatform = platformDropdown.SelectedItem.ToString();
                GetAllPlatformGames(SelectedPlatform);
            }
            else
            {
                MessageBox.Show("Please select a platform.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GetAllPlatformGames(string selectedPlatform)
        {
            // Clear lists of populated data
            ownedGames = new List<IGame>();
            missingGames = new List<MissingGame>();

            var platform = PluginHelper.DataManager.GetPlatformByName(selectedPlatform);
            if (platform == null) return;

            // Get a list of the games in your collection for the selected platform
            ownedGames = PluginHelper.DataManager.GetAllGames()
                .Where(game => game.Platform == platform.Name).ToList();

            // Get the current folder where the executable is running
            string currentFolder = AppDomain.CurrentDomain.BaseDirectory;
            string launchboxRootFolder = currentFolder.Replace("\\Core", ""); // Remove the "\Core" part
            string metadataFilePath = Path.Combine(launchboxRootFolder, "Metadata", "metadata.xml");
            if (!File.Exists(metadataFilePath))
            {
                MessageBox.Show("Metadata file not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Parse the metadata.xml to get all games for the selected platform
            var allGamesFromMetadata = GetGamesFromMetadata(metadataFilePath, selectedPlatform);

            // Find the missing games by comparing with ownedGames
            missingGames = allGamesFromMetadata
                .Where(mdGame => !ownedGames.Any(owned => string.Equals(owned.Title, mdGame.Title, StringComparison.OrdinalIgnoreCase)))
                .ToList();

            PopulateGameList(ownedGames, missingGames);
        }

        private IList<MissingGame> GetGamesFromMetadata(string metadataFilePath, string platformName)
        {
            var games = new List<MissingGame>();

            // Load and parse the metadata.xml file
            XDocument xmlDoc = XDocument.Load(metadataFilePath);

            // Find games for the selected platform
            var gameElements = xmlDoc.Descendants("Game")
                .Where(g => string.Equals((string)g.Element("Platform"), platformName, StringComparison.OrdinalIgnoreCase));

            foreach (var gameElement in gameElements)
            {
                var game = new MissingGame
                {
                    Platform = platformName,
                    Title = (string)gameElement.Element("Name") ?? "",
                    LaunchBoxDbId = ParseInt((string)gameElement.Element("DatabaseID")),
                    Developer = (string)gameElement.Element("Developer") ?? "",
                    Publisher = (string)gameElement.Element("Publisher") ?? "",
                    ReleaseDate = ParseDate((string)gameElement.Element("ReleaseDate")),
                    CommunityStarRating = ParseFloat((string)gameElement.Element("CommunityRating")),
                    CommunityStarRatingTotalVotes = ParseInt((string)gameElement.Element("CommunityRatingCount")),
                    VideoUrl = (string)gameElement.Element("VideoUrl") ?? "",
                    WikipediaUrl = (string)gameElement.Element("WikipediaUrl") ?? "",
                    ReleaseType = (string)gameElement.Element("ReleaseType") ?? ""
                };

                games.Add(game);
            }

            return games;
        }

        private DateTime? ParseDate(string dateStr)
        {
            if (DateTime.TryParse(dateStr, out DateTime date))
                return date;
            return null;
        }

        private int? ParseInt(string intStr)
        {
            if (int.TryParse(intStr, out int value))
                return value;
            return 0;
        }

        private float? ParseFloat(string floatStr)
        {
            if (float.TryParse(floatStr, out float value))
                return value;
            return 0f;
        }

        private void PopulateGameList(IList<IGame> ownedGames, IList<MissingGame> missingGames)
        {
            // Clear GridViews if populated
            if (ownedGamesGridView.RowCount > 0)
            {
                ownedGamesGridView.DataSource = null;
            }
            if (missingGamesGridView.RowCount > 0)
            {
                missingGamesGridView.DataSource = null;
            }

            // Set GridView Counters
            lblOwnedGamesCount.Text = ownedGames.Count > 0 ? ownedGames.Count.ToString() : "0";
            lblMissingGamesCount.Text = missingGames.Count > 0 ? missingGames.Count.ToString() : "0";
            
            // Bind ownedGames data to GridView
            ownedGamesGridView.DataSource = ownedGames.OrderBy(game => game.Title).Select(game => new GameDisplayData(new MissingGame
            {
                Title = game.Title,
                Developer = game.Developer ?? null,
                Publisher = game.Publisher ?? null,
                Platform = game.Platform ?? null,
                ReleaseDate = game.ReleaseDate ?? null,
                CommunityStarRating = (float?)game.CommunityStarRating ?? null,
                CommunityStarRatingTotalVotes = (int?)game.CommunityStarRatingTotalVotes ?? null,
                LaunchBoxDbId = (int?)game.LaunchBoxDbId ?? null,
                VideoUrl = game.VideoUrl ?? null,
                WikipediaUrl = game.WikipediaUrl ?? null,
                ReleaseType = game.ReleaseType ?? null
            })).ToList();

            // Bind missingGames data to GridView
            missingGamesGridView.DataSource = missingGames.OrderBy(game => game.Title).Select(game => new GameDisplayData(game)).ToList();
        }

        // GridView sort method
        private List<GameDisplayData> SortGames(List<GameDisplayData> games, string columnName)
        {
            return ascending
                ? games.OrderBy(x => x.GetType().GetProperty(columnName).GetValue(x, null)).ToList()
                : games.OrderByDescending(x => x.GetType().GetProperty(columnName).GetValue(x, null)).ToList();
        }

        // GridView column click handlers
        private void OwnedGamesGridView_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string columnName = ownedGamesGridView.Columns[e.ColumnIndex].DataPropertyName;
            ToggleSortOrder(columnName);

            ownedGamesGridView.DataSource = SortGames((List<GameDisplayData>)ownedGamesGridView.DataSource, columnName);
        }

        private void MissingGamesGridView_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string columnName = missingGamesGridView.Columns[e.ColumnIndex].DataPropertyName;
            ToggleSortOrder(columnName);

            missingGamesGridView.DataSource = SortGames((List<GameDisplayData>)missingGamesGridView.DataSource, columnName);
        }

        private void ToggleSortOrder(string columnName)
        {
            if (lastSortedColumn == columnName)
            {
                ascending = !ascending;
            }
            else
            {
                ascending = true;
                lastSortedColumn = columnName;
            }
        }

        // Export to CSV method
        private void ExportGridViewToCSV(DataGridView gridView, string filePath)
        {
            // Check if the GridView has any rows
            if (gridView.Rows.Count == 0) return;

            // Open a file stream to write the CSV
            using (var writer = new System.IO.StreamWriter(filePath))
            {
                // Write the header
                for (int i = 0; i < gridView.Columns.Count; i++)
                {
                    writer.Write(gridView.Columns[i].HeaderText);
                    if (i < gridView.Columns.Count - 1) writer.Write(","); // Comma after each column except the last one
                }
                writer.WriteLine();

                // Write each row
                foreach (DataGridViewRow row in gridView.Rows)
                {
                    for (int i = 0; i < gridView.Columns.Count; i++)
                    {
                        writer.Write(row.Cells[i].Value?.ToString());
                        if (i < gridView.Columns.Count - 1) writer.Write(","); // Comma after each cell except the last one
                    }
                    writer.WriteLine();
                }
            }
        }

        // Export to CSV handler for OwnedGames
        private void ExportOwnedGamesButton_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "CSV files (*.csv)|*.csv";
                saveFileDialog.Title = "Save Owned Games as CSV";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    ExportGridViewToCSV(ownedGamesGridView, saveFileDialog.FileName);
                    MessageBox.Show("Owned games exported successfully!");
                }
            }
        }

        // Export to CSV handler for MissingGames
        private void ExportMissingGamesButton_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "CSV files (*.csv)|*.csv";
                saveFileDialog.Title = "Save Missing Games as CSV";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    ExportGridViewToCSV(missingGamesGridView, saveFileDialog.FileName);
                    MessageBox.Show("Missing games exported successfully!");
                }
            }
        }
        private void PlatformSelectionForm_Load(object sender, EventArgs e)
        {
            
        }
    }

    public class MissingGame
    {
        public int? LaunchBoxDbId { get; set; }
        public string Title { get; set; }
        public string Developer { get; set; }
        public string Publisher { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public float? CommunityStarRating { get; set; }
        public string Platform { get; set; }
        public int? CommunityStarRatingTotalVotes { get; set; }
        public string VideoUrl { get; set; }
        public string ReleaseType { get; set; }
        public string WikipediaUrl { get; set; }
    }
}
