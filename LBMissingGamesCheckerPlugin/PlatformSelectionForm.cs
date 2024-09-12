﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using Unbroken.LaunchBox.Plugins;
using Unbroken.LaunchBox.Plugins.Data;
using Unbroken.LaunchBox.Plugins.RetroAchievements;

namespace LBMissingGamesCheckerPlugin
{
    public partial class PlatformSelectionForm : Form
    {

        //** App Classes **//
        // Class to hold platforms from xml
        public class XMLPlatform
        {
            public string Name { get; set; }
            public string Category { get; set; }
            public string Developer { get; set; }
            public string Manufacturer { get; set; }
            public DateTime? ReleaseDate { get; set; }
        }

        // Class to hold the missing game (xml) data
        public class MissingGame
        {
            public int? LaunchBoxDbId { get; set; }
            public string Title { get; set; }
            public string Developer { get; set; }
            public string Publisher { get; set; }
            public string Region { get; set; } = string.Empty;
            public string Genres { get; set; }
            public int? MaxPlayers { get; set; }
            public DateTime? ReleaseDate { get; set; }
            public float? CommunityStarRating { get; set; }
            public string Platform { get; set; }
            public int? CommunityStarRatingTotalVotes { get; set; }
            public string VideoUrl { get; set; }
            public string ReleaseType { get; set; }
            public string WikipediaUrl { get; set; }
            public List<GameAlternateName> AlternateNames { get; set; } = new List<GameAlternateName>();

            // Constructor to initialize properties from MissingGame
            public MissingGame(string title, int? lbdbId, string developer, string publisher, string region, DateTime? releaseDate, float? starRating, int? starVotes, string platform,
                string releaseType, string genres, int? maxPlayers, string vidUrl, string wikiUrl)
            {
                Title = title;
                LaunchBoxDbId = lbdbId;
                Developer = developer ?? string.Empty;
                Publisher = publisher ?? string.Empty;
                Region = region ?? string.Empty;
                ReleaseDate = releaseDate;
                CommunityStarRating = starRating;
                CommunityStarRatingTotalVotes = starVotes;
                Platform = platform ?? string.Empty;
                ReleaseType = releaseType ?? string.Empty;
                Genres = genres ?? string.Empty;
                MaxPlayers = maxPlayers;
                VideoUrl = vidUrl ?? string.Empty;
                WikipediaUrl = wikiUrl ?? string.Empty;
            }
        }

        // Class to hold alternative/region data for missing games
        public class GameAlternateName
        {
            public string Name { get; set; }
            public int GameId { get; set; }
            public string Region { get; set; }

            public GameAlternateName( int databaseID, string alternateName, string region)
            {
                GameId = databaseID;
                Name = alternateName ?? string.Empty;
                Region = region ?? string.Empty;
            }
        }


        // Class to hold game data to display
        public class GameDisplayData
        {
            public string Title { get; set; }
            public string Developer { get; set; }
            public string Publisher { get; set; }
            public string ReleaseDate { get; set; }
            public string Region { get; set; } = string.Empty;
            public string Genres { get; set; }
            public string MaxPlayers { get; set; }
            public string CommunityStarRating { get; set; }
            public string CommunityStarRatingTotalVotes { get; set; }
            public string Platform { get; set; }
            public string ReleaseType { get; set; }
            public string LaunchBoxDbId { get; set; }
            public string VideoUrl { get; set; }
            public string WikipediaUrl { get; set; }
            public List<string> AlternateNamesDisplay { get; private set; } = new List<string>();

            // Constructor to initialize properties from MissingGame
            public GameDisplayData(MissingGame game, List<string> alternateNames)
            {
                Title = game.Title ?? string.Empty;
                LaunchBoxDbId = game.LaunchBoxDbId != 0 ? game.LaunchBoxDbId.ToString() : string.Empty;
                Developer = game.Developer ?? string.Empty;
                Publisher = game.Publisher ?? string.Empty;
                ReleaseDate = game.ReleaseDate?.ToShortDateString() ?? string.Empty;
                Region = game.Region ?? string.Empty;
                Genres = game.Genres ?? string.Empty;
                MaxPlayers = game.MaxPlayers.ToString() ?? string.Empty;
                CommunityStarRating = game.CommunityStarRating != 0 ? game.CommunityStarRating.ToString() : string.Empty;
                CommunityStarRatingTotalVotes = game.CommunityStarRatingTotalVotes != 0 ? game.CommunityStarRatingTotalVotes.ToString() : string.Empty;
                Platform = game.Platform ?? string.Empty;
                ReleaseType = game.ReleaseType ?? string.Empty;
                VideoUrl = game.VideoUrl ?? string.Empty;
                WikipediaUrl = game.WikipediaUrl ?? string.Empty;

                // Populate alternate names list
                PopulateAlternateNamesDisplay(game);
            }

            // Method to format and display alternate names with regions
            private void PopulateAlternateNamesDisplay(MissingGame game)  // TODO: Don't accept MissingGame, accept
            {
                foreach (var alternateName in game.AlternateNames)
                {
                    string formattedName = $"{alternateName.Name}";
                    if (!string.IsNullOrEmpty(alternateName.Region))
                    {
                        formattedName += $" ({alternateName.Region})";
                    }
                    AlternateNamesDisplay.Add(formattedName);
                }
            }

            // Public method to return a formatted string of alternate names for display
            public string GetAlternateNamesDisplay()
            {
                return AlternateNamesDisplay.Any() ? string.Join(", ", AlternateNamesDisplay) : "N/A";
            }
        }


        // Color Progress Bar Class
        public class ProgressBarEx : ProgressBar
        {
            public ProgressBarEx()
            {
                this.SetStyle(ControlStyles.UserPaint, true);
            }

            protected override void OnPaintBackground(PaintEventArgs pevent)
            {
                // None... Helps control the flicker.
            }

            protected override void OnPaint(PaintEventArgs e)
            {
                const int inset = 2; // A single inset value to control teh sizing of the inner rect.

                using (Image offscreenImage = new Bitmap(this.Width, this.Height))
                {
                    using (Graphics offscreen = Graphics.FromImage(offscreenImage))
                    {
                        Rectangle rect = new Rectangle(0, 0, this.Width, this.Height);

                        if (ProgressBarRenderer.IsSupported)
                            ProgressBarRenderer.DrawHorizontalBar(offscreen, rect);

                        rect.Inflate(new Size(-inset, -inset)); // Deflate inner rect.
                        rect.Width = (int)(rect.Width * ((double)this.Value / this.Maximum));
                        if (rect.Width == 0) rect.Width = 1; // Can't draw rec with width of 0.

                        LinearGradientBrush brush = new LinearGradientBrush(rect, this.BackColor, this.ForeColor, LinearGradientMode.Vertical);
                        offscreen.FillRectangle(brush, inset, inset, rect.Width, rect.Height);

                        e.Graphics.DrawImage(offscreenImage, 0, 0);
                    }
                }
            }
        }

        //** App Properties **//
        // Holds the currently selected platform
        public IPlatform SelectedPlatform { get; private set; }

        // Propertie to hold the location of the Metadata.xml file
        private string metadataFilePath = string.Empty;
        private readonly string metadataFile = "metadata.xml";

        // Lists to hold XML game/platform data
        List<XMLPlatform> xmlPlatforms = new List<XMLPlatform>();
        List<MissingGame> xmlGames = new List<MissingGame>();

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
            platformDropdown.SelectedIndex = 0;

        }

        // Based on the selected platform,
        // collect all Owned Games from the users collection
        // and all games from the LaunchBox Metadata.xml file
        private async void GetAllPlatformGames(IPlatform selectedPlatform)
        {
            // Clear lists of populated data
            ownedGames = new List<IGame>();
            missingGames = new List<MissingGame>();

            // Get a list of the games in your collection for the selected platform
            ownedGames = PluginHelper.DataManager.GetAllGames()
                .Where(game => game.Platform == selectedPlatform.Name).ToList();

            // Parse the metadata.xml to get all games for the selected platform
            var allGamesFromMetadata = await GetGamesFromMetadata(selectedPlatform); // Use await here

            // Check if "Released" filter is applied
            bool filterReleasedOnly = chkReleasedOnly.Checked;

            if (allGamesFromMetadata.ElementAt<MissingGame>(0).LaunchBoxDbId != 0)
            {
                // Find the missing games by comparing with ownedGames
                missingGames = allGamesFromMetadata
                .Where(mdGame => !ownedGames.Any(owned => string.Equals(owned.Title, mdGame.Title, StringComparison.OrdinalIgnoreCase) ||
                    (owned.LaunchBoxDbId.HasValue && mdGame.LaunchBoxDbId.HasValue && owned.LaunchBoxDbId == mdGame.LaunchBoxDbId)))
                .Where(mdGame => !filterReleasedOnly || mdGame.ReleaseType == "Released").ToList();
            }
            else
            {
                missingGames = allGamesFromMetadata;
            }

            PopulateGameList(ownedGames, missingGames);
        }


        // Populate the GridViews with the game lists
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
            List<GameDisplayData> ownedGamesDisplayData = new List<GameDisplayData>();
            foreach (var game in ownedGames.OrderBy(game => game.Title))
            {
                ownedGamesDisplayData.Add(new GameDisplayData(new MissingGame(game.Title, game.LaunchBoxDbId, game.Developer,
                    game.Publisher, game.Region, game.ReleaseDate, (float?)game.CommunityStarRating,
                    (int?)game.CommunityStarRatingTotalVotes, game.Platform, game.ReleaseType, game.GenresString,
                    game.MaxPlayers, game.VideoUrl, game.WikipediaUrl)));
            }
            ownedGamesGridView.DataSource = ownedGamesDisplayData;

            // Bind missingGames data to GridView
            if (missingGames.ElementAt<MissingGame>(0).LaunchBoxDbId != 0)  // If the selectedPlatform returned games from the local db
            {
                List<GameDisplayData> missingGamesDisplayData = new List<GameDisplayData>();
                foreach (var game in missingGames.OrderBy(game => game.Title))
                {
                    missingGamesDisplayData.Add(new GameDisplayData(game, game.AlternateNames));
                }
                missingGamesGridView.DataSource = missingGamesDisplayData;
                missingGamesGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                missingGamesGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(44, 156, 255);
            }
            else   // selectedPlatform was not found in the local db xml
            {
                // Procees metadata error and create a temporary DataTable to hold the message
                DataTable messageTable = new DataTable();
                messageTable.Columns.Add("Error", typeof(string));
                messageTable.Columns.Add("Message", typeof(string));

                foreach (var game in missingGames)
                {
                    messageTable.Rows.Add(game.Platform, game.Title);
                }

                missingGamesGridView.DataSource = messageTable;
                missingGamesGridView.AutoResizeColumns();
                missingGamesGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
                missingGamesGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(255, 191, 0);
                missingGamesGridView.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
            }
            

            // Populate the clbColumnSelection with the GridViews columns
            if (clbColumnSelection.Items == null || clbColumnSelection.Items.Count <= 0)
            {
                PopulateColumnSelection();
            }            

            // Format clickable cells in the GridViews
            FormatGridViewCells(ownedGamesGridView);
            FormatGridViewCells(missingGamesGridView);

            // Apply column visibility based on clbColumnSelection's check states
            for (int i = 0; i < clbColumnSelection.Items.Count; i++)
            {
                var columnName = clbColumnSelection.Items[i].ToString();
                var checkState = clbColumnSelection.GetItemCheckState(i);
                DGVColumnToggler(columnName, checkState); 
            }

            // Turn off Progress Bar as DataGridViews are processed
            pbGridViewLoading.Visible = false;
            btnMissingCSV.Enabled = true;
            btnOwnedCSV.Enabled = true;
        }


        //** Helper Methods **//
        // Get the platform games from the metadata.xml file
        private async Task<IList<MissingGame>> GetGamesFromMetadata(IPlatform selectedPlatform)
        {

            // Start progress bar
            ProgressBar progressBar = pbGridViewLoading;
            var games = new List<MissingGame>();
            var foundPlatforms = new HashSet<string>(); // Collect all platforms found in the XML
            string searchPlatform = string.IsNullOrWhiteSpace(selectedPlatform.ScrapeAs) ? selectedPlatform.Name : selectedPlatform.ScrapeAs;
            bool platformFound = false; // Flag to track if the platform is found

            try
            {
                // Open the file stream to track the number of bytes read
                using (FileStream fs = new FileStream(metadataFilePath, FileMode.Open, FileAccess.Read))
                {
                    long totalBytes = fs.Length; // Total file size
                    long bytesRead = 0;
                    int lastProgress = 0; // Track the last progress value

                    XmlReaderSettings settings = new XmlReaderSettings { Async = true };

                    using (XmlReader reader = XmlReader.Create(fs, settings))
                    {
                        pbGridViewLoading.Minimum = 0;
                        progressBar.Maximum = 100;
                        progressBar.Value = 0;
                        progressBar.Visible = true;

                        while (await reader.ReadAsync())
                        {
                            if (reader.NodeType == XmlNodeType.Element && reader.Name == "Game")
                            {
                                var gameElement = XNode.ReadFrom(reader) as XElement;
                                var platformInXml = (string)gameElement.Element("Platform");

                                if (!string.IsNullOrWhiteSpace(platformInXml))
                                {
                                    foundPlatforms.Add(platformInXml); // Add platform to the found list
                                }

                                if (string.Equals(platformInXml, searchPlatform, StringComparison.OrdinalIgnoreCase))
                                {
                                    platformFound = true;

                                    var game = new MissingGame((string)gameElement.Element("Name"), ParseInt((string)gameElement.Element("DatabaseID")),
                                        (string)gameElement.Element("Developer"), (string)gameElement.Element("Publisher"), 
                                        string.Empty, ParseDate((string)gameElement.Element("ReleaseDate")), ParseFloat((string)gameElement.Element("CommunityRating")), 
                                        ParseInt((string)gameElement.Element("CommunityRatingCount")), selectedPlatform.Name, (string)gameElement.Element("ReleaseType"),
                                        (string)gameElement.Element("Genres"), ParseInt((string)gameElement.Element("MaxPlayers")),
                                        (string)gameElement.Element("WikipediaURL"), (string)gameElement.Element("ReleaseType"));

                                    games.Add(game);
                                }
                            }

                            // Progress Bar updating
                            bytesRead = fs.Position;
                            int progress = (int)((double)bytesRead / totalBytes * 100);
                            if (progress > lastProgress)
                            {
                                lastProgress = progress;
                                progressBar.Value = progress;
                                progressBar.Refresh();
                            }
                        }
                    }
                }

                // If no games were found for the platform, return all platforms as separate rows
                if (!platformFound)
                {
                    // Add final "NoPlatformFound" message row
                    games.Add(new MissingGame($"The selected platform '{searchPlatform}' was not found in the LaunchBox DB.", 0,
                        string.Empty, string.Empty, string.Empty, null, null, null, "NoPlatformFound", string.Empty, string.Empty,
                        null, string.Empty, string.Empty));
     
                    if(!string.IsNullOrWhiteSpace(selectedPlatform.ScrapeAs))
                        games.Add(new MissingGame($"The selected platform ScrapeAs: '{selectedPlatform.ScrapeAs}'.", 0,
                        string.Empty, string.Empty, string.Empty, null, null, null, "ScrapeAs", string.Empty, string.Empty,
                        null, string.Empty, string.Empty));

                    games.Add(new MissingGame("=====================", 0,
                        string.Empty, string.Empty, string.Empty, null, null, null, "=====================", string.Empty, string.Empty,
                        null, string.Empty, string.Empty));

                    foreach (var platform in foundPlatforms)
                    {
                        games.Add(new MissingGame($"Platform: {platform}", 0,
                        string.Empty, string.Empty, string.Empty, null, null, null, "Platform Found", string.Empty, string.Empty,
                        null, string.Empty, string.Empty));
                    }

                }
            }
            catch (FileNotFoundException)
            {
                games.Add(new MissingGame("The metadata file was not found.", 0,
                        string.Empty, string.Empty, string.Empty, null, null, null, "FileNotFound", string.Empty, string.Empty,
                        null, string.Empty, string.Empty));
            }
            catch (XmlException)
            {
                games.Add(new MissingGame("There was an error reading the XML file.", 0,
                        string.Empty, string.Empty, string.Empty, null, null, null, "XmlException", string.Empty, string.Empty,
                        null, string.Empty, string.Empty));
            }
            catch (Exception ex)
            {
                games.Add(new MissingGame($"An unexpected error occurred: {ex.Message}", 0,
                        string.Empty, string.Empty, string.Empty, null, null, null, "Exception", string.Empty, string.Empty,
                        null, string.Empty, string.Empty));
            }
            return games;
        }

        // Add clickable elements to the GridViews
        private void FormatGridViewCells(DataGridView gridView)
        {
            if (gridView.Columns.Count != 2)
            {
                foreach (DataGridViewRow row in gridView.Rows)
                {
                    // Format LaunchBoxDbId column as a clickable link
                    if (row.Cells["LaunchBoxDbId"].Value != null)
                    {
                        if (int.TryParse(row.Cells["LaunchBoxDbId"].Value.ToString(), out int lbid))
                        {
                            row.Cells["LaunchBoxDbId"].Value = $"LaunchBoxDB #{lbid}";
                            row.Cells["LaunchBoxDbId"].Style.ForeColor = Color.FromArgb(255, 191, 0);
                            row.Cells["LaunchBoxDbId"].Style.SelectionForeColor = Color.FromArgb(255, 191, 0);
                            row.Cells["LaunchBoxDbId"].Style.Font = new Font(gridView.Font, FontStyle.Underline);
                        }
                        else
                        {
                            row.Cells["LaunchBoxDbId"].Style.ForeColor = Color.FromArgb(255, 191, 0);
                            row.Cells["LaunchBoxDbId"].Style.SelectionForeColor = Color.FromArgb(255, 191, 0);
                            row.Cells["LaunchBoxDbId"].Style.Font = new Font(gridView.Font, FontStyle.Underline);
                        }
                    }

                    // Format WikipediaUrl column as a clickable link
                    if (row.Cells["WikipediaUrl"].Value != null && !string.IsNullOrWhiteSpace(row.Cells["WikipediaUrl"].Value.ToString()))
                    {
                        row.Cells["WikipediaUrl"].Style.ForeColor = Color.FromArgb(255, 191, 0);
                        row.Cells["WikipediaUrl"].Style.SelectionForeColor = Color.FromArgb(255, 191, 0);
                        row.Cells["WikipediaUrl"].Style.Font = new Font(gridView.Font, FontStyle.Underline);
                    }

                    // Format VideoUrl column as a clickable link
                    if (row.Cells["VideoUrl"].Value != null && !string.IsNullOrWhiteSpace(row.Cells["VideoUrl"].Value.ToString()))
                    {
                        row.Cells["VideoUrl"].Style.ForeColor = Color.FromArgb(255, 191, 0);
                        row.Cells["VideoUrl"].Style.SelectionForeColor = Color.FromArgb(255, 191, 0);
                        row.Cells["VideoUrl"].Style.Font = new Font(gridView.Font, FontStyle.Underline);
                    }
                }
            }
        }

        // Populate the clbColumnSelection with the GridViews columns
        private void PopulateColumnSelection()
        {
            //Populate column selection checkbox list
            if (clbColumnSelection == null || clbColumnSelection.Items.Count <= 0)
            {
                clbColumnSelection.Items.Clear();
                foreach (DataGridViewColumn column in ownedGamesGridView.Columns)
                {
                    if (column.HeaderText != "Title")
                    {
                        // Add column header text as an item in the CheckedListBox
                        clbColumnSelection.Items.Add(column.HeaderText, column.Visible);
                    }

                }
            }
        }

        // Column toggler helper
        private void DGVColumnToggler(string columnName, CheckState value)
        {
            // Find the matching column in the GridView
            foreach (DataGridViewColumn column in ownedGamesGridView.Columns)
            {
                if (column.HeaderText == columnName)
                {
                    // Show or hide the column based on the CheckedListBox state
                    column.Visible = (value == CheckState.Checked);
                    break;
                }
            }
            foreach (DataGridViewColumn column in missingGamesGridView.Columns)
            {
                if (column.HeaderText == columnName && column.HeaderText != "message")
                {
                    // Show or hide the column based on the CheckedListBox state
                    column.Visible = (value == CheckState.Checked);
                    break;
                }
            }
        }

        // GridView sort method
        private List<GameDisplayData> SortGames(List<GameDisplayData> games, string columnName)
        {
            return ascending
                ? games.OrderBy(x => x.GetType().GetProperty(columnName).GetValue(x, null)).ToList()
                : games.OrderByDescending(x => x.GetType().GetProperty(columnName).GetValue(x, null)).ToList();
        }

        // Column sort toggle method
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

        // Format helpers
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

        // Form draggable code
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        private void PlatformSelectionForm_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        // Handle URL requests
        private void OpenUrl(string url)
        {
            try
            {
                var psi = new ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true
                };
                Process.Start(psi);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to open URL {url}: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    if (gridView.Columns[i].Visible)  // If column is selected
                    {
                        writer.Write(gridView.Columns[i].HeaderText);
                        if (i < gridView.Columns.Count - 1) writer.Write(","); // Comma after each column except the last one
                    }
                }
                writer.WriteLine();

                // Write each row
                foreach (DataGridViewRow row in gridView.Rows)
                {
                    for (int i = 0; i < gridView.Columns.Count; i++)
                    {
                        if (gridView.Columns[i].Visible)  // If column is selected
                        {
                            writer.Write(row.Cells[i].Value?.ToString());
                            if (i < gridView.Columns.Count - 1) writer.Write(","); // Comma after each cell except the last one
                        }
                    }
                    writer.WriteLine();
                }
            }
        }


        //** Event Handlers **//
        // Initialize the loading of the Metadata.xml file
        private async void PlatformSelectionForm_Shown(object sender, EventArgs e)
        {
            try
            {
                await Task.Delay(5000);
                // Find the Metadata.xml file in the current directory structure
                string[] files = Directory.GetFiles(Directory.GetCurrentDirectory(), metadataFile, SearchOption.AllDirectories);
                metadataFilePath = files[0];
                lblLoadingMetadata.Text = metadataFile + " found!";
                await Task.Delay(2000);
                confirmButton.Enabled = true;
                lblLoadingMetadata.Visible = false;
            }
            catch 
            {
                lblLoadingMetadata.Text = metadataFile + " not found";
                lblApplicationPath.Text = "Directory: " + Directory.GetCurrentDirectory();
                lblApplicationPath.Visible = true;
            }
            finally
            {
                pbMGCSpinner.Visible = false;
            }
        }

        // Confirm button handler for dropdown platform selection
        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            if (platformDropdown.SelectedItem != null && platformDropdown.SelectedIndex > 0)
            {
                SelectedPlatform = PluginHelper.DataManager.GetPlatformByName(platformDropdown.SelectedItem.ToString());
                if (SelectedPlatform == null) return;
                GetAllPlatformGames(SelectedPlatform);
            }
            else
            {
                MessageBox.Show("Please select a platform.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ownedGridView column click handlers
        private void OwnedGamesGridView_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string columnName = ownedGamesGridView.Columns[e.ColumnIndex].DataPropertyName;
            ToggleSortOrder(columnName);

            ownedGamesGridView.DataSource = SortGames((List<GameDisplayData>)ownedGamesGridView.DataSource, columnName);

            // Reapply formatting and ToolTipText properties
            FormatGridViewCells(ownedGamesGridView);
        }

        // missingGridView column click handlers
        private void MissingGamesGridView_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            if (missingGamesGridView.Columns.Count != 2)
            {
                string columnName = missingGamesGridView.Columns[e.ColumnIndex].DataPropertyName;
                ToggleSortOrder(columnName);

                missingGamesGridView.DataSource = SortGames((List<GameDisplayData>)missingGamesGridView.DataSource, columnName);

                // Reapply formatting and ToolTipText properties
                FormatGridViewCells(missingGamesGridView);
            }

        }

        // GridView cell click handler
        private void GridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!(sender is DataGridView gridView) || e.RowIndex < 0) return;

            var cell = gridView.Rows[e.RowIndex].Cells[e.ColumnIndex];
            var columnName = gridView.Columns[e.ColumnIndex].Name;

            if (columnName == "LaunchBoxDbId" && cell.Value != null)
            {
                var lbid = gridView.Rows[e.RowIndex].Cells["LaunchBoxDbId"].Value.ToString().Split('#').LastOrDefault();
                if (int.TryParse(lbid, out int dbId))
                {
                    string url = $"https://gamesdb.launchbox-app.com/games/dbid/{dbId}";
                    OpenUrl(url);
                }
            }
            else if (columnName == "WikipediaUrl" && cell.ToolTipText != null) 
            {
                string url = gridView.Rows[e.RowIndex].Cells["WikipediaUrl"].Value.ToString();
                if (!string.IsNullOrWhiteSpace(url))
                {
                    OpenUrl(url);
                }
            }
            else if (columnName == "VideoUrl" && cell.ToolTipText != null)
            {
                string url = gridView.Rows[e.RowIndex].Cells["VideoUrl"].Value.ToString();
                if (!string.IsNullOrWhiteSpace(url))
                {
                    OpenUrl(url);
                }
            }
        }

        // Toggle column visibility based on the CheckedListBox 
        private void CheckedListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            // Get the column name from the CheckedListBox
            string columnName = clbColumnSelection.Items[e.Index].ToString();
            DGVColumnToggler(columnName, e.NewValue);
            
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

        // PoweredBy link handler
        private void PoweredBy_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenUrl("https://forums.launchbox-app.com/profile/135650-agentjohnnyp/");
        }

        // Form close handler
        private void FormClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //** Form Themes **//
        public void ApplyTheme(Form form)
        {
            // Charcoal grey background
            form.BackColor = Color.FromArgb(54, 57, 63);

            // Loop through all controls and apply styles
            foreach (Control ctrl in form.Controls)
            {
                if (ctrl is Button btn && btn.Name != "btnClose")
                {
                    btn.BackColor = Color.FromArgb(44, 156, 255);
                    btn.ForeColor = Color.White;
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderColor = Color.FromArgb(30, 130, 200);
                    btn.FlatAppearance.BorderSize = 1;
                }
                else if (ctrl is LinkLabel llb) 
                {
                    llb.ForeColor = Color.FromArgb(255, 191, 0);
                    llb.VisitedLinkColor = Color.FromArgb(255, 191, 0);
                    llb.LinkColor = Color.FromArgb(255, 191, 0);
                    llb.ActiveLinkColor = Color.FromArgb(255, 191, 0);
                }
                else if (ctrl is ComboBox cbx)
                {
                    cbx.BackColor = Color.FromArgb(245, 245, 245);
                    cbx.ForeColor = Color.Black;
                    cbx.FlatStyle = FlatStyle.Flat;
                }
                else if (ctrl is GroupBox gbx)
                {
                    gbx.ForeColor = Color.FromArgb(255, 191, 0);
                    gbx.BackColor = Color.FromArgb(54, 57, 63);
                }
                else if (ctrl is CheckBox chk)
                {
                    chk.ForeColor = Color.FromArgb(255, 191, 0);
                    chk.BackColor = Color.FromArgb(54, 57, 63);
                }
                else if (ctrl is CheckedListBox clb)
                {
                    // CheckedListBox styled with grey background and white text
                    clb.BackColor = Color.FromArgb(54, 57, 63);
                    clb.ForeColor = Color.White;
                }
                else if (ctrl is ProgressBar pb)
                {
                    pb.BackColor = Color.FromArgb(54, 57, 63);
                    pb.ForeColor = Color.White;
                    pb.Style = ProgressBarStyle.Continuous;
                    pb.ForeColor = Color.FromArgb(44, 156, 255);
                }
                else if (ctrl is DataGridView dgv)
                {
                    dgv.BackgroundColor = Color.FromArgb(54, 57, 63);
                    dgv.GridColor = Color.FromArgb(44, 156, 255);
                    dgv.DefaultCellStyle.BackColor = Color.FromArgb(54, 57, 63);
                    dgv.DefaultCellStyle.ForeColor = Color.White;
                    dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(44, 156, 255);
                    dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                    dgv.EnableHeadersVisualStyles = false;
                }
            }
        }

        //** Form Init **//
        private void PlatformSelectionForm_Load(object sender, EventArgs e)
        {
            ApplyTheme(this);
  
        }

    }
}
