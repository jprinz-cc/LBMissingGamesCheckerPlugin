using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
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
        // Class for platforms from xml
        public class XmlPlatform
        {
            public string Name { get; set; }
            //public string Category { get; set; }
            //public string Developer { get; set; }
            //public string Manufacturer { get; set; }
            //public DateTime? ReleaseDate { get; set; }

            // Constructor to initialize properties from XmlPlatform
            public XmlPlatform(
                string name
                //string category,
                //string developer,
                //string manufacturer,
                //DateTime? releaseDate
                )
            {
                Name = name;
                //Category = category;
                //Developer = developer;
                //Manufacturer = manufacturer;
                //ReleaseDate = releaseDate ?? null;
            }
        }

        // Class for each game in the metadata.xml file
        public class XmlGame
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
            public List<IAlternateName> AlternateNames { get; set; } = new List<IAlternateName>();

            // Constructor to initialize properties from MissingGame
            public XmlGame(
                string title, 
                int? lbdbId, 
                string developer, 
                string publisher, 
                string region, 
                DateTime? releaseDate, 
                float? starRating, 
                int? starVotes, 
                string platform,
                string releaseType, 
                string genres, 
                int? maxPlayers, 
                string vidUrl, 
                string wikiUrl, 
                List<IAlternateName> alternateNames)
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
                AlternateNames = alternateNames ?? new List<IAlternateName>();
            }
        }

        // Class to hold alternative/region data for missing games
        public class XmlGameAlternateName : IAlternateName
        {
            public string Name { get; set; }
            public string GameId { get; set; }
            public string Region { get; set; }

            public XmlGameAlternateName(string databaseID, string alternateName, string region)
            {
                Name = alternateName ?? string.Empty;
                GameId = databaseID;
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
            public string AlternateNames { get; set; }

            // Constructor to initialize properties from MissingGame
            public GameDisplayData(XmlGame game)
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
                AlternateNames = GetAltNames(game.AlternateNames) ?? string.Empty;
            }

            // Return all Alternate Names to the AlternateNames propery as a string
            private string GetAltNames(List<IAlternateName> altNames)
            {
                string resultAlt = string.Empty;
                if(altNames != null && altNames.Count != 0)
                {
                    foreach (var item in altNames)
                    {
                        if (!string.IsNullOrWhiteSpace(item.ToString()) && resultAlt != string.Empty)
                        {
                            resultAlt += ", " + item.ToString();
                        }
                        else if (!!string.IsNullOrWhiteSpace(item.ToString()))
                        {
                            resultAlt += item.ToString();
                        }
                    }
                }                
                return resultAlt;
            }
        }


        // Color Progress Bar Class
        public class ProgressBarEx : ProgressBar
        {
            private Timer marqueeTimer;
            private int marqueePosition = 0;
            private const int marqueeSpeed = 20; // Speed of the marquee animation
            private const int marqueeSegmentWidth = 75; // Width of the marquee segment

            public ProgressBarEx()
            {
                this.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
                InitializeMarquee();
            }

            private void InitializeMarquee()
            {
                marqueeTimer = new Timer();
                marqueeTimer.Interval = 50; // Adjust the interval for smoother/faster animation
                marqueeTimer.Tick += (s, e) =>
                {
                    // Increment the position and wrap around when it exceeds the width
                    marqueePosition += marqueeSpeed;
                    if (marqueePosition > this.Width) marqueePosition = 0;
                    this.Invalidate(); // Redraw the control to show animation
                };
            }

            protected override void OnPaintBackground(PaintEventArgs pevent)
            {
                // Skip background painting to reduce flickering
            }

            protected override void OnPaint(PaintEventArgs e)
            {
                const int inset = 2; // A single inset value to control the sizing of the inner rect.

                // Use double buffering to draw everything to an offscreen bitmap first
                using (Bitmap offscreenBitmap = new Bitmap(this.Width, this.Height))
                using (Graphics offscreen = Graphics.FromImage(offscreenBitmap))
                {
                    Rectangle rect = new Rectangle(0, 0, this.Width, this.Height);

                    // Draw the progress bar background
                    if (ProgressBarRenderer.IsSupported)
                        ProgressBarRenderer.DrawHorizontalBar(offscreen, rect);

                    rect.Inflate(new Size(-inset, -inset)); // Deflate inner rect.

                    // Handle Marquee style separately
                    if (this.Style == ProgressBarStyle.Marquee)
                    {
                        // Start the timer to handle marquee animation
                        if (!marqueeTimer.Enabled)
                        {
                            marqueeTimer.Start();
                        }

                        // Draw the moving marquee segment
                        Rectangle marqueeRect = new Rectangle(marqueePosition, inset, marqueeSegmentWidth, rect.Height);
                        using (LinearGradientBrush brush = new LinearGradientBrush(marqueeRect, this.BackColor, this.ForeColor, LinearGradientMode.Vertical))
                        {
                            offscreen.FillRectangle(brush, marqueeRect);
                        }
                    }
                    else
                    {
                        // Handle regular progress mode
                        rect.Width = (int)(rect.Width * ((double)this.Value / this.Maximum));
                        if (rect.Width == 0) rect.Width = 1; // Can't draw rect with width of 0.

                        using (LinearGradientBrush brush = new LinearGradientBrush(rect, this.BackColor, this.ForeColor, LinearGradientMode.Vertical))
                        {
                            offscreen.FillRectangle(brush, inset, inset, rect.Width, rect.Height);
                        }
                    }

                    // Draw the offscreen bitmap to the screen
                    e.Graphics.DrawImage(offscreenBitmap, 0, 0);
                }
            }

            protected override void OnVisibleChanged(EventArgs e)
            {
                base.OnVisibleChanged(e);
                if (!this.Visible && marqueeTimer != null)
                {
                    // Stop the timer if the progress bar is not visible
                    marqueeTimer.Stop();
                }
            }

            protected override void Dispose(bool disposing)
            {
                if (disposing && marqueeTimer != null)
                {
                    marqueeTimer.Dispose();
                }
                base.Dispose(disposing);
            }
        }



        //** App Properties **//
        // Holds the currently selected platform
        public IPlatform SelectedPlatform { get; private set; }

        // Propertie to hold the location of the Metadata.xml file
        private string metadataFilePath = string.Empty;
        private readonly string metadataFile = "metadata.xml";

        // Lists to hold XML game/platform data
        readonly List<XmlPlatform> xmlPlatforms = new List<XmlPlatform>();
        readonly List<XmlGame> xmlGames = new List<XmlGame>();
        readonly List<IAlternateName> xmlGameAltNames = new List<IAlternateName>();

        // Lists to hold sorted games
        private IList<IGame> ownedGames;
        private IList<XmlGame> missingGames;

        // Properties to toggle sort order in the GridViews
        private string lastSortedColumn = string.Empty;
        private bool ascending = true;        

        //** Form Init and Main Methods **//
        public PlatformSelectionForm(IList<IPlatform> platforms)
        {
            InitializeComponent();
            ssPlatformDropdownMsg.Visible = false;
            DebugTxt(false);
            // Populate dropdown with user platforms
            foreach (var platform in platforms)
            {
                platformDropdown.Items.Add(platform.Name);   
            }
            platformDropdown.SelectedIndex = 0;

        }

        private void GetAllPlatformGames(IPlatform selectedPlatform)
        {
            if (selectedPlatform == null)
            {
                DebugTxt("selectedPlatform is null.");
                return;
            }

            DebugTxt("Starting GetAllPlatformGames...");
            // Clear lists of populated data
            ownedGames = new List<IGame>();
            missingGames = new List<XmlGame>();

            DebugTxt("Starting GetAllGames...");
            // Get a list of the games in your collection for the selected platform
            ownedGames = selectedPlatform.GetAllGames(true, true);
            if(ownedGames != null)
            {
                DebugTxt($"ownedGames Count: {ownedGames.Count}");
            }
            else
            {
                DebugTxt("ownedGames is null");
                return;
            }

            // Check if "Released" filter is applied
            bool filterReleasedOnly = chkReleasedOnly.Checked;
            DebugTxt($"Filer by Released: {filterReleasedOnly}");
            if (filterReleasedOnly)
            {
                DebugTxt("Filtering ownedGames");
                ownedGames = ownedGames.Where(og => og.LaunchBoxDbId.HasValue)
                .Where(og => !filterReleasedOnly || og.ReleaseType == "Released") // Check release type
                .ToList();
            }

            DebugTxt($"ownedGames.Count: {ownedGames.Count} FirstIdVal: {ownedGames[0].LaunchBoxDbId}");
            // Convert owned games to a HashSet for fast lookups
            DebugTxt("Creating HashSet...");
            HashSet<int> ownedGameIds = null;
            try
            {
                ownedGameIds = new HashSet<int>(ownedGames.Select(og => og.LaunchBoxDbId.Value));
                DebugTxt($"ownedGameIds HashSet complete: {ownedGameIds.Count}");
            }
            catch (Exception ex)
            {
                DebugTxt($"Error creating HashSet: {ex.Message}");
                DebugTxt($"ownedGames.Count: {ownedGames.Count} FirstIdVal: {ownedGames[0].LaunchBoxDbId}");
                return;
            }


            if (xmlPlatforms == null)
            {
                DebugTxt("xmlPlatforms is null.");
                return;
            }

            var platformFound = false;
            foreach (var platform in xmlPlatforms)
            {
                if (platform.Name == selectedPlatform.Name) { platformFound = true; break; }
            }
            DebugTxt($"Platform Found: {platformFound}");
            if (platformFound)
            {
                if (xmlGames == null)
                {
                    DebugTxt("xmlGames is null.");
                    return;
                }
                DebugTxt($"Processing Missing Games. xmlGames: {xmlGames.Count}");
                missingGames = xmlGames.Where(xmlGame => xmlGame.Platform == selectedPlatform.Name) // Ensure platform matches selected platform
                .Where(xmlGame => xmlGame.LaunchBoxDbId.HasValue && !ownedGameIds.Contains(xmlGame.LaunchBoxDbId.Value)) // Check if game is missing
                .Where(xmlGame => !filterReleasedOnly || xmlGame.ReleaseType == "Released") // Check release type
                .ToList();
                DebugTxt($"Processing Missing Games completed: {missingGames.Count}");
            }
            else
            {
                //Add final "NoPlatformFound" message row
                DebugTxt("Adding error to missingGames List");
                missingGames.Add(new XmlGame($"The selected platform '{selectedPlatform.Name}' was not found in the LaunchBox DB.", 0,
                    string.Empty, string.Empty, string.Empty, null, null, null, "NoPlatformFound", string.Empty, string.Empty,
                    null, string.Empty, string.Empty, null));

                if (!string.IsNullOrWhiteSpace(selectedPlatform.ScrapeAs))
                    missingGames.Add(new XmlGame($"The selected platform ScrapeAs: '{selectedPlatform.ScrapeAs}'.", 0,
                    string.Empty, string.Empty, string.Empty, null, null, null, "ScrapeAs", string.Empty, string.Empty,
                    null, string.Empty, string.Empty, null));

                missingGames.Add(new XmlGame("=====================", 0,
                    string.Empty, string.Empty, string.Empty, null, null, null, "=====================", string.Empty, string.Empty,
                    null, string.Empty, string.Empty, null));

                foreach (var platform in xmlPlatforms)
                {
                    missingGames.Add(new XmlGame($"Platform: {platform}", 0,
                    string.Empty, string.Empty, string.Empty, null, null, null, "Platform Found", string.Empty, string.Empty,
                    null, string.Empty, string.Empty, null));
                }
            }
            DebugTxt("Populating Game Lists!");
            DebugTxt($"ownedGames: {ownedGames.Count} - missingGames: {missingGames.Count}");
            PopulateGameList(ownedGames, missingGames);
        }


        // Populate the GridViews with the game lists
        private void PopulateGameList(IList<IGame> ownedGames, IList<XmlGame> missingGames)
        {
            DebugTxt("Clearing GridViews...");
            // Suspend layout to prevent unnecessary redraws
            ownedGamesGridView.SuspendLayout();
            missingGamesGridView.SuspendLayout();

            try
            {
                // Clear GridViews if populated
                ownedGamesGridView.DataSource = null;
                missingGamesGridView.DataSource = null;

                // Set GridView Counters
                lblOwnedGamesCount.Text = ownedGames.Count > 0 ? ownedGames.Count.ToString() : "0";
                lblMissingGamesCount.Text = missingGames.Count > 0 ? missingGames.Count.ToString() : "0";
                DebugTxt($"ownedGames.Count: {ownedGames.Count}");
                DebugTxt($"missingGames.Count: {missingGames.Count}");

                // Bind ownedGames data to GridView
                DebugTxt("Loading ownedGamesGridView...");
                List<GameDisplayData> ownedGamesDisplayData = new List<GameDisplayData>();
                foreach (var game in ownedGames.OrderBy(game => game.Title))
                {
                    List<IAlternateName> altNameList = new List<IAlternateName>();
                    var altGameNames = game.GetAllAlternateNames();
                    if (altGameNames != null)
                    {
                        foreach (var altName in altGameNames)
                        {
                            altNameList.Add(altName);
                        }
                    }
                    ownedGamesDisplayData.Add(new GameDisplayData(new XmlGame(
                        game.Title,
                        game.LaunchBoxDbId,
                        game.Developer,
                        game.Publisher,
                        game.Region,
                        game.ReleaseDate,
                        (float?)game.CommunityStarRating,
                        (int?)game.CommunityStarRatingTotalVotes,
                        game.Platform,
                        game.ReleaseType,
                        game.GenresString,
                        game.MaxPlayers,
                        game.VideoUrl,
                        game.WikipediaUrl,
                        altNameList)));
                }
                ownedGamesGridView.DataSource = ownedGamesDisplayData;
                DebugTxt("ownedGamesGridView loaded!");

                // Bind missingGames data to GridView
                if (missingGames.Any())
                {
                    DebugTxt($"missingGames first LBID: {missingGames.First().LaunchBoxDbId}");
                }
                else
                {
                    DebugTxt("First missingGames is null");
                }

                if (missingGames.Any() && missingGames.First().LaunchBoxDbId != null && missingGames.First().LaunchBoxDbId != 0)  // If the selectedPlatform returned games from the local db
                {
                    DebugTxt("Loading missingGamesGridView...");
                    List<GameDisplayData> missingGamesDisplayData = new List<GameDisplayData>();
                    foreach (var game in missingGames.OrderBy(game => game.Title))
                    {
                        missingGamesDisplayData.Add(new GameDisplayData(game));
                    }
                    missingGamesGridView.DataSource = missingGamesDisplayData;
                    missingGamesGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                    missingGamesGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(44, 156, 255);
                    DebugTxt("Loading missingGamesGridView completed!");
                }
                else   // selectedPlatform was not found in the local db xml
                {
                    // Procees metadata error and create a temporary DataTable to hold the message
                    DebugTxt($"Processing Missing Games error: {missingGames.Count}");
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
                DebugTxt("Loading missingGamesGridView completed!");

                // Populate the clbColumnSelection with the GridViews columns
                if (clbColumnSelection.Items == null || clbColumnSelection.Items.Count <= 0)
                {
                    DebugTxt($"Populating clbColumnSelection: {clbColumnSelection.Items.Count}");
                    PopulateColumnSelection();
                }
                DebugTxt("Formatting GridViews...");
                // Format clickable cells in the GridViews
                FormatGridViewCells(ownedGamesGridView);
                FormatGridViewCells(missingGamesGridView);
                DebugTxt("Formatting GridViews completed!");

                // Apply column visibility based on clbColumnSelection's check states
                DebugTxt($"Apply column visibility: {clbColumnSelection.Items.Count}");
                for (int i = 0; i < clbColumnSelection.Items.Count; i++)
                {
                    var columnName = clbColumnSelection.Items[i].ToString();
                    var checkState = clbColumnSelection.GetItemCheckState(i);
                    DGVColumnToggler(columnName, checkState);
                }

                // Turn off Progress Bar as DataGridViews are processed
                btnMissingCSV.Enabled = true;
                btnOwnedCSV.Enabled = true;
                DebugTxt("GridViews Processed!");
            }
            finally
            {
                ownedGamesGridView.ResumeLayout();
                missingGamesGridView.ResumeLayout();
            }            
        }


        //** Helper Methods **//
        // Process the directories to find the metadata.xml file
        private void FindMetadataFile()
        {
            // Directories to exclude
            var excludedDirectories = new List<string>
            {
                "Games",
                "Images",
                "Videos",
                "eXo",
                "Content",
                "Emulators",
                "Manuals",
                "LBThemes",
                "Music",
                "PauseThemes",
                "StartupThemes",
                "Themes",
                "ThirdParty",
                "Plugins"
            };

            // Get all directories except the excluded ones (case-insensitive)
            List<string> allDirectories = Directory.GetDirectories(Directory.GetCurrentDirectory(), "*", SearchOption.AllDirectories)
                .Where(dir => !excludedDirectories.Any(excludedDir => dir.IndexOf(excludedDir, StringComparison.OrdinalIgnoreCase) >= 0)) // Case-insensitive comparison
                .ToList();

            // Get files from allowed directories
            var files = new List<string>();
            bool fileFound = false; // Flag to track if the file was found

            foreach (var dir in allDirectories)
            {
                // Get all files from the current directory in a case-insensitive manner
                files.AddRange(Directory.GetFiles(dir, "*", SearchOption.TopDirectoryOnly)
                    .Where(f => Path.GetFileName(f).Equals(metadataFile, StringComparison.OrdinalIgnoreCase))
                );

                // Break if we found the metadata file
                if (files.Count > 0)
                {
                    fileFound = true;
                    break;
                }
            }
            // If metadata.xml found, add to metadataFilePath, else throw to the try and display error
            if (fileFound)
            {
                metadataFilePath = files[0];
                DebugTxt($"metadataFilePath: {metadataFilePath}");
            }
            else
            {
                DebugTxt($"metadata File Not Found! Path: {metadataFilePath}");
                DebugTxt(true);
                throw new Exception("Metadata file not found.");
            }
        }

        // Get the platform games from the metadata.xml file
        private async void GetGamesFromMetadata()
        {
            bool xmlReadCompleted = false;
            // Debugging
            int gameCount = 0;
            int platformCount = 0;
            int GameAltNamesCount = 0;
            int processedGamesCounter = 0;

            try
            {
                using (FileStream fs = new FileStream(metadataFilePath, FileMode.Open, FileAccess.Read, FileShare.Read, bufferSize: 4096, FileOptions.Asynchronous))
                {
                    XmlReaderSettings settings = new XmlReaderSettings { Async = true };

                    using (XmlReader reader = XmlReader.Create(fs, settings))
                    {
                        while (await reader.ReadAsync())
                        {
                            reader.MoveToContent();

                            if (reader.NodeType == XmlNodeType.Element && reader.Name == "LaunchBox")
                            {
                                while (await reader.ReadAsync())
                                {
                                    if (reader.NodeType == XmlNodeType.Element)
                                    {
                                        if (reader.Name == "Platform")
                                        {
                                            // Process the Platforms in the xml and add to xmlPlatforms
                                            var xmlElement = XNode.ReadFrom(reader) as XElement;
                                            if (xmlElement.Element("Name") != null && !xmlElement.Element("Name").IsEmpty)
                                            {
                                                var platform = new XmlPlatform(
                                                    (string)xmlElement.Element("Name")
                                                );
                                                xmlPlatforms.Add(platform);
                                                platformCount++;
                                            }
                                            
                                        }
                                        else if (reader.Name == "Game")
                                        {
                                            var xmlElement = XNode.ReadFrom(reader) as XElement;
                                            var game = new XmlGame(
                                                (string)xmlElement.Element("Name"),
                                                ParseInt((string)xmlElement.Element("DatabaseID")),
                                                (string)xmlElement.Element("Developer"),
                                                (string)xmlElement.Element("Publisher"),
                                                string.Empty,
                                                ParseDate((string)xmlElement.Element("ReleaseDate")),
                                                ParseFloat((string)xmlElement.Element("CommunityRating")),
                                                ParseInt((string)xmlElement.Element("CommunityRatingCount")),
                                                (string)xmlElement.Element("Platform"),
                                                (string)xmlElement.Element("ReleaseType"),
                                                (string)xmlElement.Element("Genres"),
                                                ParseInt((string)xmlElement.Element("MaxPlayers")),
                                                (string)xmlElement.Element("WikipediaURL"),
                                                (string)xmlElement.Element("ReleaseType"),
                                                new List<IAlternateName>()
                                            );
                                            xmlGames.Add(game);
                                            gameCount++;
                                        }
                                        else if (reader.Name == "GameAlternateName")
                                        {
                                            var xmlElement = XNode.ReadFrom(reader) as XElement;
                                            var altName = new XmlGameAlternateName(
                                                (string)xmlElement.Element("DatabaseID"),
                                                (string)xmlElement.Element("AlternateName"),
                                                (string)xmlElement.Element("Region")
                                            );
                                            xmlGameAltNames.Add(altName);
                                            GameAltNamesCount++;
                                        }
                                    }
                                }
                            }
                        }
                        xmlReadCompleted = true;
                    }
                    xmlReadCompleted = true;
                }
                xmlReadCompleted = true;
            }
            catch (Exception ex)
            {
                xmlGames.Add(new XmlGame($"An unexpected error occurred: {ex.Message}", 0,
                        string.Empty, string.Empty, string.Empty, null, null, null, "Exception", string.Empty, string.Empty,
                        null, string.Empty, string.Empty, null));
                UpdateStatus("error", "An unexpected error occurred");
                StopProgressBar();
            }
            finally
            {
                DebugTxt($"xmlReadCompleted: {xmlReadCompleted}");
                DebugTxt($"xmlGames.Count:  {xmlGames.Count}");
                DebugTxt($"gameCount: {gameCount}");
                DebugTxt($"platformCount:  {platformCount}");                
                DebugTxt($"GameAltNamesCount:  {GameAltNamesCount}");

                if (xmlReadCompleted)
                {
                    DebugTxt("Started processing games");
                    // Create a dictionary for faster lookup of alternate names by GameId
                    var altNamesDict = xmlGameAltNames
                        .Where(altName => !string.IsNullOrEmpty(altName.GameId))
                        .GroupBy(altName => altName.GameId)
                        .ToDictionary(g => g.Key, g => g.ToList());

                    foreach (var game in xmlGames)
                    {
                        if (game.LaunchBoxDbId.HasValue)
                        {
                            // Check if we have alternate names for this game using the dictionary
                            if (altNamesDict.TryGetValue(game.LaunchBoxDbId.ToString(), out var matchingAltNames))
                            {
                                // Add matching alternate names to the game
                                game.AlternateNames.AddRange(matchingAltNames);

                                // Use StringBuilder for building the region string
                                var regionBuilder = new StringBuilder(game.Region);

                                foreach (var altName in matchingAltNames)
                                {
                                    if (!string.IsNullOrWhiteSpace(altName.Region) && !regionBuilder.ToString().Contains(altName.Region))
                                    {
                                        if (regionBuilder.Length > 0)
                                        {
                                            regionBuilder.Append(", ");
                                        }
                                        regionBuilder.Append(altName.Region);
                                    }
                                }

                                game.Region = regionBuilder.ToString();
                            }

                            processedGamesCounter++;
                        }
                    }

                    UpdateStatus("success");
                    StopProgressBar();
                    confirmButton.Enabled = true;
                }
                else
                {
                    UpdateStatus("error");
                    DebugTxt(true);
                }

                DebugTxt("Ended processing games");
                DebugTxt($"processedGames: {processedGamesCounter}");
            }
        }

        // Method to update status
        private void UpdateStatus(string status, string message = null)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new Action<string, string>(UpdateStatus), new object[] { status, message });
                return;
            }

            switch (status)
            {
                case "processing":
                    tsslIcon.Image = Properties.Resources.warning;
                    tsslText.Text = message ?? "Updating Metadata";
                    tsslText.ForeColor = Color.Black;
                    tsslText.BackColor = Color.FromArgb(255, 191, 0);
                    break;
                case "success":
                    tsslIcon.Image = Properties.Resources.success;
                    tsslText.Text = message ?? "Metadata Loaded";
                    tsslText.ForeColor = Color.FromArgb(255, 191, 0);
                    tsslText.BackColor = Color.Transparent;
                    break;
                case "error":
                    tsslIcon.Image = Properties.Resources.error;
                    tsslText.ForeColor = Color.Black;
                    tsslText.BackColor = Color.FromArgb(255, 191, 0);
                    break;
            }
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

        // Setup the progressBar
        private void StartProgressBar()
        {
            // Set the progress bar style to Marquee for continuous movement
            pbMetadataLoading.Visible = true;
            pbMetadataLoading.Style = ProgressBarStyle.Marquee;
            pbMetadataLoading.Refresh();
        }

        // Method to stop the progress bar and hide it when processing is complete
        private void StopProgressBar()
        {
            pbMetadataLoading.Visible = false;
            pbMetadataLoading.Style = ProgressBarStyle.Blocks;
            pbMetadataLoading.Refresh();
        }

        // Add text to debug textbox
        private void DebugTxt(string txt)
        {
            if (tbDebug.InvokeRequired)
            {
                tbDebug.BeginInvoke(new Action<string>(DebugTxt), new object[] { txt });
                return;
            }
            StringBuilder sb = new StringBuilder(tbDebug.Text);
            sb.AppendLine(txt);
            tbDebug.Text = sb.ToString();
        }

        // Debug overload to toggle visibily of the debug textbox
        private void DebugTxt(bool visible)
        {
            if (visible)
            {
                pDebugLog.Visible = true;
            }
            else
            {
                pDebugLog.Visible = false;
            }
        }

        //** Event Handlers **//
        private async void PlatformSelectionForm_Shown(object sender, EventArgs e)
        {
            try
            {
                StartProgressBar();
                await Task.Delay(4000);
                UpdateStatus("processing", "Preparing for Metadata...");
                await Task.Delay(4000);
                UpdateStatus("processing", "Searching for Metadata...");
                // Find the Metadata.xml file in the current directory structure
                await Task.Run(() => FindMetadataFile());
                UpdateStatus("success", "Metadata Found!");
                StopProgressBar();
                await Task.Delay(3500);
                StartProgressBar();
                // Process the metadata.xml
                UpdateStatus("processing", "Processing Metadata...");
                await Task.Run(() => GetGamesFromMetadata());
            }
            catch 
            {
                DebugTxt($"metadataFilePath: {metadataFilePath}");
                DebugTxt($"Directory: {Directory.GetCurrentDirectory()}");
                DebugTxt(true);
                UpdateStatus("error", $"{metadataFile} not found");
            }

        }

        // Confirm button handler for dropdown platform selection
        private async void ConfirmButton_Click(object sender, EventArgs e)
        {
            if (platformDropdown.SelectedItem != null && platformDropdown.SelectedIndex > 0)
            {
                DebugTxt($"Dropdown Item: {platformDropdown.SelectedItem}");
                SelectedPlatform = PluginHelper.DataManager.GetPlatformByName(platformDropdown.SelectedItem.ToString());
                if (SelectedPlatform == null)
                {
                    tsslPlatformDropdownMsg.Text = $"Error with Platform: {platformDropdown.SelectedItem}";
                    ssPlatformDropdownMsg.Visible = true;
                    return;
                }
                ssPlatformDropdownMsg.Visible = false;
                DebugTxt($"SelectedPlatform found: {SelectedPlatform.Name}");

                await Task.Run(() => GetAllPlatformGames(SelectedPlatform)); // Run asynchronously
            }
            else
            {
                ssPlatformDropdownMsg.Visible = true;
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

            try
            {
                if (columnName == "LaunchBoxDbId" && cell.Value != null)
                {
                    var lbid = cell.Value.ToString().Split('#').LastOrDefault();
                    if (int.TryParse(lbid, out int dbId))
                    {
                        string url = $"https://gamesdb.launchbox-app.com/games/dbid/{dbId}";
                        OpenUrl(url);
                    }
                }
                else if (columnName == "WikipediaUrl" && cell.Value != null)
                {
                    string url = cell.Value.ToString();
                    if (!string.IsNullOrWhiteSpace(url))
                    {
                        OpenUrl(url);
                    }
                }
                else if (columnName == "VideoUrl" && cell.Value != null)
                {
                    string url = cell.Value.ToString();
                    if (!string.IsNullOrWhiteSpace(url))
                    {
                        OpenUrl(url);
                    }
                }
            }
            catch (Exception ex)
            {
                DebugTxt($"An error occurred while processing the cell click: {ex.Message}");
                MessageBox.Show($"An error occurred while processing the cell click: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void CloseDebug_Click(object sender, EventArgs e)
        {
            pDebugLog.Visible = false;
        }

        // Debug textbox visibility
        private void DebugBtn_Click(object sender, EventArgs e)
        {
            if (pDebugLog.Visible)
            {
                DebugTxt(false);
            }
            else
            {
                DebugTxt(true);
            }
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
