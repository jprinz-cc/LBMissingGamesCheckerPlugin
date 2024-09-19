using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using Unbroken.LaunchBox.Plugins;
using Unbroken.LaunchBox.Plugins.Data;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LBMissingGamesCheckerPlugin
{
    public partial class PlatformSelectionForm : Form
    {
        #region FormClasses
        // Class for platforms from xml
        public class XmlPlatform
        {
            public string Name { get; set; }

            // Constructor to initialize properties from XmlPlatform
            public XmlPlatform(string name)
            {
                Name = name;
            }
        }

        // Class for each game in the metadata.xml file
        public class XmlGame
        {
            public string Title { get; set; }
            public string Developer { get; set; }
            public string Publisher { get; set; }
            public string Region { get; set; } = string.Empty;
            public DateTime? ReleaseDate { get; set; }
            public float? CommunityStarRating { get; set; }
            public int? CommunityStarRatingTotalVotes { get; set; }
            public string Platform { get; set; }
            public string ReleaseType { get; set; }
            public string Genres { get; set; }
            public List<IAlternateName> AlternateNames { get; set; } = new List<IAlternateName>();
            public int? MaxPlayers { get; set; }
            public int? LaunchBoxDbId { get; set; }
            public string VideoUrl { get; set; }
            public string WikipediaUrl { get; set; }

            // Constructor to initialize properties from MissingGame
            public XmlGame(
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
                List<IAlternateName> alternateNames,
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
                AlternateNames = alternateNames ?? new List<IAlternateName>();
                MaxPlayers = maxPlayers;
                LaunchBoxDbId = lbdbId;
                VideoUrl = vidUrl ?? string.Empty;
                WikipediaUrl = wikiUrl ?? string.Empty;
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
            public string Region { get; set; } = string.Empty;
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

            // Constructor to initialize properties from MissingGame
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

            // Return all Alternate Names to the AlternateNames propery as a string
            private string GetAltNames(List<IAlternateName> altNames)
            {
                string resultAlt = string.Empty;
                if (altNames != null && altNames.Count != 0)
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
        public class ProgressBarEx : System.Windows.Forms.ProgressBar
        {
            private System.Windows.Forms.Timer marqueeTimer;
            private int marqueePosition = 0;
            private const int marqueeSpeed = 20; // Speed of the marquee animation
            private const int marqueeSegmentWidth = 75; // Width of the marquee segment
            private bool disposed = false; // Flag to indicate if the object has been disposed

            public ProgressBarEx()
            {
                this.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
                InitializeMarquee();
            }

            private void InitializeMarquee()
            {
                marqueeTimer = new System.Windows.Forms.Timer
                {
                    Interval = 50 // Adjust the interval for smoother/faster animation
                };
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
                if (disposed)
                    return;

                if (disposing)
                {
                    if (marqueeTimer != null)
                    {
                        marqueeTimer.Dispose();
                        marqueeTimer = null;
                    }
                }
                disposed = true;
                base.Dispose(disposing);
            }
        }
        #endregion

        #region AppProperties
        // Holds the currently selected platform
        public IPlatform SelectedPlatform { get; private set; }

        // Propertie to hold the location of the Metadata.xml file
        private string metadataFilePath = string.Empty;
        private readonly string metadataFile = "metadata.xml";

        // Lists to hold XML game/platform data
        readonly ConcurrentBag<XmlPlatform> xmlPlatforms = new ConcurrentBag<XmlPlatform>();
        readonly ConcurrentBag<XmlGame> xmlGames = new ConcurrentBag<XmlGame>();
        readonly ConcurrentBag<IAlternateName> xmlGameAltNames = new ConcurrentBag<IAlternateName>();

        // Lists to hold sorted games
        private ConcurrentBag<IGame> ownedGames = new ConcurrentBag<IGame>();
        private ConcurrentBag<XmlGame> missingGames = new ConcurrentBag<XmlGame>();

        // Declare GridViews

        // Declare DataSources
        

        // Declare BindingSources
        private readonly BindingSource ownedGamesBindingSource = new BindingSource();
        private readonly BindingSource missingGamesBindingSource = new BindingSource();

        // Properties to toggle sort order in the GridViews
        private string lastSortedColumn = string.Empty;
        private bool ascending = true;
        #endregion

        #region FormInit
        public PlatformSelectionForm(IList<IPlatform> platforms)
        {
            InitializeComponent();

            // Hide debug/error messaging
            ssPlatformDropdownMsg.Visible = false;
            DebugTxt(false);

            // Populate dropdown with user platforms
            foreach (var platform in platforms)
            {
                platformDropdown.Items.Add(platform.Name);
            }
            platformDropdown.SelectedIndex = 0;

            // Populate column selection checkboxes
            PopulateColumnSelection();
        }

        // Form Load //
        private void PlatformSelectionForm_Load(object sender, EventArgs e)
        {
            ApplyTheme(this);
        }
        #endregion

        #region EventHandlers
        private async void PlatformSelectionForm_Shown(object sender, EventArgs e)
        {
            try
            {
                StartProgressBar();
                await Task.Delay(2000);
                UpdateStatus("processing", "Preparing for Metadata...");
                await Task.Delay(2000);
                UpdateStatus("processing", "Searching for Metadata...");
                // Find the Metadata.xml file in the current directory structure
                FindMetadataFile();
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
        private readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1, 1);
        private async void ConfirmButton_Click(object sender, EventArgs e)
        {
            if (platformDropdown.SelectedItem != null && platformDropdown.SelectedIndex > 0)
            {
                ownedGamesGridView.Columns.Clear();
                missingGamesGridView.Columns.Clear();

                // Then proceed to add the columns and bind data
                await _semaphore.WaitAsync();
                try
                {
                    DebugTxt($"Starting GridView loading. Dropdown Item: {platformDropdown.SelectedItem}");
                    SelectedPlatform = PluginHelper.DataManager.GetPlatformByName(platformDropdown.SelectedItem.ToString());
                    if (SelectedPlatform == null)
                    {
                        tsslPlatformDropdownMsg.Text = $"Error with Platform: {platformDropdown.SelectedItem}";
                        ssPlatformDropdownMsg.Visible = true;
                        return;
                    }
                    ssPlatformDropdownMsg.Visible = false;
                    DebugTxt($"SelectedPlatform found: {SelectedPlatform.Name}");

                    await Task.Run(()=> GetAllPlatformGames(SelectedPlatform));
                }
                finally
                {
                    _semaphore.Release();
                }
            }
            else
            {
                ssPlatformDropdownMsg.Visible = true;
            }
        }

        private void OwnedGamesGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == ownedGamesGridView.Columns["LaunchBoxDbId"].Index && e.Value != null)
            {
                var cell = (DataGridViewButtonCell)ownedGamesGridView.Rows[e.RowIndex].Cells[e.ColumnIndex];
                cell.Value = $"LaunchBoxDB #{e.Value}";
                cell.Tag = $"https://gamesdb.launchbox-app.com/games/dbid/{e.Value.ToString().Trim()}";
            }
            else if (e.ColumnIndex == ownedGamesGridView.Columns["VideoUrl"].Index && e.Value != null)
            {
                var cell = (DataGridViewButtonCell)ownedGamesGridView.Rows[e.RowIndex].Cells[e.ColumnIndex];
                cell.Tag = e.Value.ToString();
            }
            else if (e.ColumnIndex == ownedGamesGridView.Columns["WikipediaUrl"].Index && e.Value != null)
            {
                var cell = (DataGridViewButtonCell)ownedGamesGridView.Rows[e.RowIndex].Cells[e.ColumnIndex];
                cell.Tag = e.Value.ToString();
            }
        }


        // ownedGamesGridView column click handlers
        private void OwnedGamesGridView_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new Action<object, DataGridViewCellMouseEventArgs>(OwnedGamesGridView_ColumnHeaderMouseClick), new object[] { sender, e });
                return;
            }
            string columnName = ownedGamesGridView.Columns[e.ColumnIndex].DataPropertyName;
            ToggleSortOrder(columnName);

            if (ownedGamesGridView.DataSource is BindingSource bindingSource)
            {
                var list = bindingSource.List.Cast<GameDisplayData>().ToList();
                ownedGamesBindingSource.DataSource = SortGames(list, columnName);
                ownedGamesGridView.DataSource = ownedGamesBindingSource;
            }
            // Reapply formatting and ToolTipText properties
            //FormatGridViewCells(ownedGamesGridView);
        }

        // missingGamesGridView column click handlers
        private void MissingGamesGridView_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new Action<object, DataGridViewCellMouseEventArgs>(MissingGamesGridView_ColumnHeaderMouseClick), new object[] { sender, e });
                return;
            }
            string columnName = missingGamesGridView.Columns[e.ColumnIndex].DataPropertyName;
            ToggleSortOrder(columnName);

            if (missingGamesGridView.DataSource is BindingSource bindingSource)
            {
                var list = bindingSource.List.Cast<GameDisplayData>().ToList();
                missingGamesBindingSource.DataSource = SortGames(list, columnName);
                missingGamesGridView.DataSource = missingGamesBindingSource;
            }
            // Reapply formatting and ToolTipText properties
            //FormatGridViewCells(missingGamesGridView);
        }

        // GridView cell click handler
        private void GridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new Action<object, DataGridViewCellEventArgs>(GridView_CellContentClick), new object[] { sender, e });
                return;
            }
            DebugTxt("Start of cell click handler...");
            if (e.RowIndex >= 0 && ownedGamesGridView.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                var cell = (DataGridViewButtonCell)ownedGamesGridView.Rows[e.RowIndex].Cells[e.ColumnIndex];
                DebugTxt($"Cell clicker: {cell.Value}");
                string url = cell.Tag.ToString();
                DebugTxt($"Opening URL: {url}");
                try
                {
                    Process.Start(url); // Open the URL in the default browser
                }
                catch (Exception ex)
                {
                    DebugTxt($"An error occurred while processing the cell click: {ex.Message}");
                    MessageBox.Show($"An error occurred while processing the cell click: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
            //if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            //{
            //    var gridView = (DataGridView)sender;
            //    var clickedCell = gridView.Rows[e.RowIndex].Cells[e.ColumnIndex] as DataGridViewButtonCell;

            //    DebugTxt($"Cell clicker: {clickedCell.Value}");
            //    if (clickedCell != null && clickedCell.Tag != null)
            //    {
            //        string url = clickedCell.Tag.ToString();
            //        DebugTxt($"Opening URL: {url}");
            //        try
            //        {
            //            Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
            //        }
            //        catch (Exception ex)
            //        {
            //            DebugTxt($"An error occurred while processing the cell click: {ex.Message}");
            //            MessageBox.Show($"An error occurred while processing the cell click: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        }
            //    }
            //}            
        }


        // Toggle column visibility based on the CheckedListBox 
        private void CheckedListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new Action<object, ItemCheckEventArgs>(CheckedListBox_ItemCheck), new object[] {sender, e});
                return;
            }
            string columnName = clbColumnSelection.Items[e.Index].ToString();
            // Find the matching column in the GridView
            foreach (DataGridViewColumn column in ownedGamesGridView.Columns)
            {
                if (column.HeaderText == columnName)
                {
                    // Show or hide the column based on the CheckedListBox state
                    column.Visible = (e.NewValue == CheckState.Checked);
                    break;
                }
            }
            foreach (DataGridViewColumn column in missingGamesGridView.Columns)
            {
                if (column.HeaderText == columnName && column.HeaderText != "message")
                {
                    // Show or hide the column based on the CheckedListBox state
                    column.Visible = (e.NewValue == CheckState.Checked);
                    break;
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
            DebugTxt(false);
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

        // Copy To Clipboard
        private void CopyToClipboard_Click(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new Action<object, ItemCheckEventArgs>(CopyToClipboard_Click), new object[] { sender, e });
                return;
            }
            // Ensure that text is selected in the text box.
            tbDebug.SelectAll();
            if (tbDebug.SelectionLength > 0)
            {
                // Copy Debug Log text to the Clipboard.
                tbDebug.Copy();
                tbDebug.DeselectAll();
            }            
        }

        // Clear Debug Log
        private void ClearDebugLog_Click(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new Action<object, ItemCheckEventArgs>(ClearDebugLog_Click), new object[] { sender, e });
                return;
            }
            // Ensure that text is selected in the text box.
            if (tbDebug.Text.Length > 0)
            {
                // Copy the selected text to the Clipboard.
                tbDebug.Clear();
                StringBuilder sb = new StringBuilder(tbDebug.Text);
                sb.AppendLine("Debug");
                sb.AppendLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")); // Add the current date/time
                tbDebug.Text = sb.ToString();

            }
        }
        #endregion

        #region MainMethods
        private async void GetAllPlatformGames(IPlatform selectedPlatform)
        {
            DebugTxt("Starting GetAllPlatformGames...");
            if (selectedPlatform == null)
            {
                DebugTxt("selectedPlatform is null.");
                return;
            }

            HashSet<int> ownedGameIds = null;

            // Check if "Released" filter is applied
            bool filterReleasedOnly = chkReleasedOnly.Checked;
            DebugTxt($"Filter by Released: {filterReleasedOnly}");

            // Clear lists of populated data
            if (!ownedGames.IsEmpty)
            {
                DebugTxt("Clearing ownedGames bag...");
                ownedGames = new ConcurrentBag<IGame>();
                DebugTxt("Clearing ownedGames bag completed!");
            }
            if (!missingGames.IsEmpty)
            {
                DebugTxt("Clearing missingGames bag...");
                missingGames = new ConcurrentBag<XmlGame>();
                DebugTxt("Clearing missingGames bag completed!");
            }

            DebugTxt("Starting GetAllGames...");
            // Get a list of the games in your collection for the selected platform
            var ownedGamesList = await Task.Run(()=> selectedPlatform.GetAllGames(true, true));
            if (ownedGamesList != null)
            {
                DebugTxt($"ownedGamesList Count: {ownedGamesList.Count()}");
                await Task.Run(() => {
                    foreach (var game in ownedGamesList)
                    {
                        ownedGames.Add(game);
                    }
                });
            }
            else
            {
                DebugTxt("ownedGames is null");
                return;
            }
            DebugTxt($"ownedGames Count: {ownedGames.Count}");

                
            if (filterReleasedOnly)
            {
                DebugTxt("Filtering ownedGames...");
                await Task.Run(() => {
                    ownedGames = new ConcurrentBag<IGame>(ownedGames.Where(og => og.LaunchBoxDbId.HasValue && og.ReleaseType == "Released"));
                });
                DebugTxt("Filtering ownedGames completed!");
            }

            DebugTxt($"ownedGames.Count: {ownedGames.Count} FirstIdVal: {ownedGames.FirstOrDefault()?.LaunchBoxDbId}");

            // Convert owned games to a HashSet for fast lookups
            DebugTxt("Creating HashSet...");
            await Task.Run(() => {
                try
                {
                    ownedGameIds = new HashSet<int>(ownedGames.Where(og => og.LaunchBoxDbId.HasValue).Select(og => og.LaunchBoxDbId.Value));
                    DebugTxt($"ownedGameIds HashSet complete: {ownedGameIds.Count}");
                }
                catch (Exception ex)
                {
                    DebugTxt($"Error creating HashSet: {ex.Message}");
                    DebugTxt($"ownedGames.Count: {ownedGames.Count} FirstIdVal: {ownedGames.FirstOrDefault()?.LaunchBoxDbId}");
                    return;
                }
            });

            if (xmlPlatforms == null)
            {
                DebugTxt("xmlPlatforms is null.");
                return;
            }

            DebugTxt("Starting missingGames check...");
            string platformToCheck = !string.IsNullOrEmpty(selectedPlatform.ScrapeAs) ? selectedPlatform.ScrapeAs : selectedPlatform.Name;
            var platformFound = xmlPlatforms.Any(platform => platform.Name == platformToCheck);
            DebugTxt($"Platform Found: {platformFound}");
            if (platformFound)
            {
                if (xmlGames == null)
                {
                    DebugTxt("xmlGames is null.");
                    return;
                }

                DebugTxt($"Processing Missing Games. xmlGames: {xmlGames.Count}");
                try
                {
                    await Task.Run(() => {
                        var filteredGames = xmlGames.Where(xmlGame => xmlGame.Platform == selectedPlatform.Name) // Ensure platform matches selected platform
                            .Where(xmlGame => xmlGame.LaunchBoxDbId.HasValue && !ownedGameIds.Contains(xmlGame.LaunchBoxDbId.Value)) // Check if game is missing
                            .Where(xmlGame => !filterReleasedOnly || xmlGame.ReleaseType == "Released") // Check release type
                            .Select(xmlGame => {
                                //** Enable to debug each game being processed **//
                                //DebugTxt($"Processing xmlGame: {xmlGame.Title}, ID: {xmlGame.LaunchBoxDbId}");
                                return xmlGame;
                            })
                            .ToList();
                        missingGames = new ConcurrentBag<XmlGame>(filteredGames);
                    });
                }
                catch (Exception ex)
                {
                    DebugTxt($"Exception processing Missing Games: {ex.Message}");
                }               
                DebugTxt($"Processing Missing Games completed!");
                DebugTxt($"ownedGames: {ownedGames.Count} - missingGames: {missingGames.Count}");
            }
            else
            {
                // Add final "NoPlatformFound" message row
                DebugTxt("Adding error to missingGames List...");
                try
                {
                    await Task.Run(() => ProcessNoPlatformErrorList(selectedPlatform, xmlPlatforms));
                }
                catch (Exception ex)
                {
                    DebugTxt($"Exception processing Missing Games: {ex.Message}");
                }                
            }

            DebugTxt("Populating Game Lists!");
            PopulateGameList(ownedGames, missingGames);
        }

        // Populate the GridViews with the game lists
        private async void PopulateGameList(ConcurrentBag<IGame> ownedGames, ConcurrentBag<XmlGame> missingGames)
        {
            // Suspend layout to prevent unnecessary redraws
            DebugTxt("Suspending ownedGamesGridView...");
            ownedGamesGridView.SuspendLayout();

            DebugTxt("Suspending missingGamesGridView...");
            missingGamesGridView.SuspendLayout();


            try
            {                
                // Clear GridViews BindingSource
                if (missingGamesGridView.DataSource != null)
                {
                    DebugTxt("null missingGames DataSource...");
                    missingGamesGridView.DataSource = null;

                    DebugTxt("Clear missingGames BindingSource...");
                    missingGamesBindingSource.Clear();
                }
                if (ownedGamesGridView.DataSource != null)
                {
                    DebugTxt("null ownedGames DataSource...");
                    ownedGamesGridView.DataSource = null;

                    DebugTxt("Clear ownedGames BindingSource...");
                    ownedGamesBindingSource.Clear();                    
                }

                // Loading data to GridView
                DebugTxt("Loading ownedGamesDisplayData...");
                var ownedGamesDisplayData = new List<GameDisplayData>();
                try
                {
                    ownedGamesDisplayData = await Task.Run(() =>
                    {
                        return ownedGames.OrderBy(game => game.Title)
                            .Select(game =>
                            {
                                var altNameList = game.GetAllAlternateNames()?.ToList() ?? new List<IAlternateName>();
                                return new GameDisplayData(new XmlGame(
                                    game.Title,
                                    game.Developer,
                                    game.Publisher,
                                    game.Region,
                                    game.ReleaseDate,
                                    (float?)game.CommunityStarRating,
                                    (int?)game.CommunityStarRatingTotalVotes,
                                    game.Platform,
                                    game.ReleaseType,
                                    game.GenresString,
                                    altNameList,
                                    game.MaxPlayers,
                                    game.LaunchBoxDbId,
                                    game.VideoUrl,
                                    game.WikipediaUrl
                                    ));
                            }).ToList();
                    });
                    DebugTxt("ownedGamesDisplayData loaded!");
                } catch
                {
                    ownedGamesDisplayData = await Task.Run(() =>
                    {
                        return ownedGames.OrderBy(game => game.Title)
                            .Select(game =>
                            {
                                var altNameList = game.GetAllAlternateNames()?.ToList() ?? new List<IAlternateName>();
                                return new GameDisplayData(new XmlGame(
                                    game.Title,
                                    game.Developer,
                                    game.Publisher,
                                    game.Region,
                                    game.ReleaseDate,
                                    (float?)game.CommunityStarRating,
                                    (int?)game.CommunityStarRatingTotalVotes,
                                    game.Platform,
                                    game.ReleaseType,
                                    game.GenresString,
                                    altNameList,
                                    game.MaxPlayers,
                                    game.LaunchBoxDbId,
                                    game.VideoUrl,
                                    game.WikipediaUrl
                                    ));
                            }).ToList();
                    });
                }
                

                // Bind missingGames data to GridView
                if (missingGames.Any())
                {
                    DebugTxt($"missingGames first LBID: {missingGames.First().LaunchBoxDbId}");
                }
                else
                {
                    DebugTxt("First missingGames is null");
                }

                DebugTxt("Loading missingGamesDisplayData...");
                var missingGamesDisplayData = new List<GameDisplayData>();
                var noPlatformErrorDisplay = new List<(string Title, string Platform, int? LaunchBoxDbId)>();

                if (missingGames.Any() && missingGames.First().LaunchBoxDbId != null && missingGames.First().LaunchBoxDbId != 0)  // If the selectedPlatform returned games from the local db
                {
                    missingGamesDisplayData = await Task.Run(() =>
                    {
                        return missingGames.OrderBy(game => game.Title)
                            .Select(game => new GameDisplayData(game))
                            .ToList();
                    });
                    DebugTxt("Loading missingGamesDisplayData completed!");                    
                }
                else if (missingGames.Any() && missingGames.First().LaunchBoxDbId == 0)  // If the selectedPlatform was not found in the LaunchBoxDb
                {
                    noPlatformErrorDisplay = await Task.Run(() =>
                    {
                        return missingGames.Select(game => (game.Title, game.Platform, game.LaunchBoxDbId)).ToList();
                    });                 
                    DebugTxt("Loading missingGames Error completed!");
                }
                else
                {
                    DebugTxt("Loading missingGamesDisplayData did NOT complete!");
                    return;
                }
                DebugTxt("Loading missingGamesDisplayData completed!");

                // Update UI bindings synchronously on the UI thread
                Invoke(new Action(() =>
                {
                    // Create ButtonColumns
                    DataGridViewButtonColumn launchBoxDbIdColumn = new DataGridViewButtonColumn
                    {
                        Name = "LaunchBoxDbId",
                        HeaderText = "LaunchBoxDbId",
                        Text = "LaunchBoxDB",
                        UseColumnTextForButtonValue = false
                    };

                    DataGridViewButtonColumn videoUrlColumn = new DataGridViewButtonColumn
                    {
                        Name = "VideoUrl",
                        HeaderText = "VideoUrl",
                        Text = "YouTube",
                        UseColumnTextForButtonValue = true
                    };

                    DataGridViewButtonColumn wikipediaUrlColumn = new DataGridViewButtonColumn
                    {
                        Name = "WikipediaUrl",
                        HeaderText = "WikipediaUrl",
                        Text = "Wiki",
                        UseColumnTextForButtonValue = true
                    };

                    // Add ButtonColumns to the GridView
                    ownedGamesGridView.Columns.Add(launchBoxDbIdColumn);
                    ownedGamesGridView.Columns.Add(videoUrlColumn);
                    ownedGamesGridView.Columns.Add(wikipediaUrlColumn);

                    ownedGamesBindingSource.DataSource = ownedGamesDisplayData;
                    ownedGamesGridView.DataSource = ownedGamesBindingSource;

                    if (missingGamesDisplayData.Any())
                    {
                        missingGamesGridView.Columns.Clear();
                        
                        missingGamesBindingSource.DataSource = missingGamesDisplayData;
                        missingGamesGridView.DataSource = missingGamesBindingSource;
                        missingGamesGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(44, 156, 255);
                        missingGamesGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                    }
                    else if (noPlatformErrorDisplay.Any())
                    {
                        missingGamesGridView.Columns.Clear();
                        // Add columns to the DataGridView
                        missingGamesGridView.Columns.Add(new DataGridViewTextBoxColumn { Name = "Title", HeaderText = "Error" });
                        missingGamesGridView.Columns.Add(new DataGridViewTextBoxColumn { Name = "Platform", HeaderText = "Message" });
                        missingGamesGridView.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
                        var errorData = noPlatformErrorDisplay.Select(errLine => new { Error = errLine.Title, Message = errLine.Platform }).ToList();
                        // Add rows to the DataGridView
                        foreach (var (Title, Platform, LaunchBoxDbId) in noPlatformErrorDisplay.AsEnumerable().Reverse())
                        {
                            missingGamesGridView.Rows.Add(Title, Platform);
                        }
                        missingGamesGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
                        missingGamesGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(255, 191, 0);
                        missingGamesGridView.AutoResizeColumns();
                    }                    
                    

                    
                    // Set GridView Counters
                    DebugTxt("Setting GridViewCounters...");
                    lblOwnedGamesCount.Text = ownedGames.Count > 0 ? ownedGames.Count.ToString() : "0";
                    lblMissingGamesCount.Text = missingGames.Count > 0 && missingGames.First().LaunchBoxDbId != 0 ? missingGames.Count.ToString() : "0";
                    DebugTxt($"ownedGames.Count: {ownedGames.Count}");
                    DebugTxt($"missingGames.Count: {missingGames.Count}");
                }));

                // Add clickable columns
                Invoke(new Action(() =>
                {
                    //DebugTxt("Adding clickable columns...");
                    //AddClickableColumns(ownedGamesGridView);
                    if (missingGamesDisplayData.Any())
                    {
                        //AddClickableColumns(missingGamesGridView);
                    }                    

                    DebugTxt("Recalculate the maximum width...");
                    // Recalculate the maximum width after populating the gridviews
                    int maxWidth = CalculateMaxWidth();
                    if (this.Width > maxWidth)
                    {
                        this.Width = maxWidth;
                    }

                    // Apply column visibility based on clbColumnSelection's check states
                    DebugTxt($"Apply column visibility: {clbColumnSelection.Items.Count}");
                    UpdateColumnVisibility();
                }));                                

                // DataGridViews are processed
                btnMissingCSV.Enabled = true;
                btnOwnedCSV.Enabled = true;
                DebugTxt("GridViews Processed!");
            }
            finally
            {
                DebugTxt("Resuming ownedGamesGridView...");
                ownedGamesGridView.ResumeLayout();

                DebugTxt("Resuming missingGamesGridView...");
                missingGamesGridView.ResumeLayout();

                DebugTxt("Resuming GridViews completed!");
            }
        }

        // Process the directories to find the metadata.xml file
        private async void FindMetadataFile()
        {
            // Flag to track if the file was found
            bool fileFound = false; 
            // Get files from allowed directories
            var files = new List<string>();

            try
            {
                DebugTxt("Looking for Metadata...");
                string currentFolder = AppDomain.CurrentDomain.BaseDirectory;
                string launchboxRootFolder = currentFolder.Replace("\\Core", ""); // Remove the "\Core" part
                metadataFilePath = Path.Combine(launchboxRootFolder, "Metadata", "metadata.xml");
                if (File.Exists(metadataFilePath)) fileFound = true;
                DebugTxt("Metadata Found!");
            }
            catch 
            {
                DebugTxt("Searching for Metadata...");
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
                List<string> allDirectories = new List<string>();
                await Task.Run(() => {
                    allDirectories = Directory.GetDirectories(Directory.GetCurrentDirectory(), "*", SearchOption.AllDirectories)
                    .Where(dir => !excludedDirectories.Any(excludedDir => dir.IndexOf(excludedDir, StringComparison.OrdinalIgnoreCase) >= 0)) // Case-insensitive comparison
                    .ToList();
                });

                await Task.Run(() => {
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
                });
            }
            

            // If metadata.xml found, add to metadataFilePath, else throw to the try and display error
            if (fileFound)
            {
                metadataFilePath = files.Any() ? files[0] : metadataFilePath;
                DebugTxt($"metadataFilePath: {metadataFilePath}");
                UpdateStatus("success", "Metadata Found!");
                StopProgressBar();
                await Task.Delay(3500);
                StartProgressBar();
                // Process the metadata.xml
                UpdateStatus("processing", "Processing Metadata...");
                await Task.Run(() =>
                {
                    GetGamesFromMetadata();
                });
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

            FileStream fs = new FileStream(metadataFilePath, FileMode.Open, FileAccess.Read, FileShare.Read, bufferSize: 4096, FileOptions.Asynchronous);
            try
            {
                using (fs)
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
                                                (string)xmlElement.Element("Developer"),
                                                (string)xmlElement.Element("Publisher"),
                                                (string)xmlElement.Element("Region"),
                                                ParseDate((string)xmlElement.Element("ReleaseDate")),
                                                ParseFloat((string)xmlElement.Element("CommunityRating")),
                                                ParseInt((string)xmlElement.Element("CommunityRatingCount")),
                                                (string)xmlElement.Element("Platform"),
                                                (string)xmlElement.Element("ReleaseType"),
                                                (string)xmlElement.Element("Genres"),
                                                new List<IAlternateName>(),
                                                ParseInt((string)xmlElement.Element("MaxPlayers")),
                                                ParseInt((string)xmlElement.Element("DatabaseID")),
                                                (string)xmlElement.Element("WikipediaURL"),
                                                (string)xmlElement.Element("ReleaseType")
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
                xmlGames.Add(new XmlGame($"An unexpected error occurred: {ex.Message}",
                        string.Empty, string.Empty, string.Empty, null, null, null, "Exception", string.Empty, string.Empty,
                        null, null, null, string.Empty, string.Empty));
                UpdateStatus("error", "An unexpected error occurred");
                StopProgressBar();
            }
            finally
            {
                fs?.Close();
                DebugTxt($"xmlReadCompleted: {xmlReadCompleted}");
                DebugTxt($"xmlGames.Count:  {xmlGames.Count}");
                DebugTxt($"gameCount: {gameCount}");
                DebugTxt($"platformCount:  {platformCount}");
                DebugTxt($"GameAltNamesCount:  {GameAltNamesCount}");

                if (xmlReadCompleted)
                {
                    DebugTxt("Started processing games...");
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
                                    if (!string.IsNullOrWhiteSpace(altName.Region) && !altName.Region.ToString().Contains(altName.Region))
                                    {
                                        if (altName.Region.Length > 0)
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
        #endregion

        #region HelperMethods
        private void AddClickableColumns(DataGridView gridView)
        {
            // Convert existing columns to button columns if necessary
            ConvertToButtonColumn(gridView, "LaunchBoxDbId", "LaunchBoxDbIdButton", "LaunchBoxDB #");
            ConvertToButtonColumn(gridView, "VideoUrl", "VideoUrlButton", "YouTube");
            ConvertToButtonColumn(gridView, "WikipediaUrl", "WikipediaUrlButton", "Wiki");

            // Set the text and URL for the buttons
            foreach (DataGridViewRow row in gridView.Rows)
            {
                // LaunchBoxDbId button
                if (gridView.Columns.Contains("LaunchBoxDbIdButton") && row.Cells["LaunchBoxDbIdButton"] is DataGridViewButtonCell lbidCell)
                {
                    var lbidValue = row.Cells["LaunchBoxDbId"].Value?.ToString();
                    if (!string.IsNullOrWhiteSpace(lbidValue))
                    {
                        lbidCell.Value = $"LaunchBoxDB #{lbidValue}";
                        lbidCell.Tag = $"https://gamesdb.launchbox-app.com/games/dbid/{lbidValue.Trim()}";
                        //lbidCell.Style.BackColor = Color.Transparent;
                        //lbidCell.Style.ForeColor = Color.FromArgb(255, 191, 0);
                    }
                    else
                    {
                        lbidCell.Value = string.Empty;
                        lbidCell.Tag = null;
                    }
                }

                // VideoUrl button
                if (gridView.Columns.Contains("VideoUrlButton") && row.Cells["VideoUrlButton"] is DataGridViewButtonCell videoCell)
                {
                    var videoUrl = row.Cells["VideoUrl"].Value?.ToString();
                    if (!string.IsNullOrWhiteSpace(videoUrl))
                    {
                        videoCell.Value = "YouTube";
                        videoCell.Tag = videoUrl;
                        //videoCell.Style.BackColor = Color.Transparent;
                        //videoCell.Style.ForeColor = Color.FromArgb(255, 191, 0);
                    }
                    else
                    {
                        videoCell.Value = string.Empty;
                        videoCell.Tag = null;
                    }
                }

                // WikipediaUrl button
                if (gridView.Columns.Contains("WikipediaUrlButton") && row.Cells["WikipediaUrlButton"] is DataGridViewButtonCell wikiCell)
                {
                    var wikiUrl = row.Cells["WikipediaUrl"].Value?.ToString();
                    if (!string.IsNullOrWhiteSpace(wikiUrl))
                    {
                        wikiCell.Value = "Wiki";
                        wikiCell.Tag = wikiUrl;
                        //wikiCell.Style.BackColor = Color.Transparent;
                        //wikiCell.Style.ForeColor = Color.FromArgb(255, 191, 0);
                    }
                    else
                    {
                        wikiCell.Value = string.Empty;
                        wikiCell.Tag = null;
                    }
                }
            }
        }
        private void ConvertToButtonColumn(DataGridView gridView, string columnName, string buttonColumnName, string buttonText)
        {
            if (gridView.Columns.Contains(columnName))
            {
                var columnIndex = gridView.Columns[columnName].Index;
                if (!(gridView.Columns[columnIndex] is DataGridViewButtonColumn))
                {
                    // Create a new button column
                    var buttonColumn = new DataGridViewButtonColumn
                    {
                        Name = buttonColumnName,
                        HeaderText = gridView.Columns[columnIndex].HeaderText,
                        UseColumnTextForButtonValue = false
                    };

                    // Insert the new button column at the same index
                    gridView.Columns.Insert(columnIndex, buttonColumn);

                    // Copy data from the old column to the new button column
                    foreach (DataGridViewRow row in gridView.Rows)
                    {
                        row.Cells[buttonColumnName].Value = row.Cells[columnName].Value;
                    }

                    // Remove the old column
                    gridView.Columns.RemoveAt(columnIndex + 1);
                }
            }
        }


        private void ProcessNoPlatformErrorList(IPlatform selectedPlatform, ConcurrentBag<XmlPlatform> xmlPlatforms)
        {
            var noPlatformErrorList = new List<XmlGame>
            {
                new XmlGame("NoPlatformFound", string.Empty, string.Empty, string.Empty, null, null, null,
                    $"The selected platform '{selectedPlatform.Name}' was not found in the LaunchBox DB.", string.Empty, string.Empty, null, null, 0, string.Empty, string.Empty),
                new XmlGame("=====================", string.Empty, string.Empty, string.Empty, null, null, null,
                    "=====================", string.Empty, string.Empty, null, null, 0, string.Empty, string.Empty)
            };

            if (!string.IsNullOrWhiteSpace(selectedPlatform.ScrapeAs))
            {
                noPlatformErrorList.Add(new XmlGame("ScrapeAs", string.Empty, string.Empty, string.Empty, null, null, null,
                    $"The selected platform ScrapeAs: '{selectedPlatform.ScrapeAs}'.", string.Empty, string.Empty, null, null, 0, string.Empty, string.Empty));
                noPlatformErrorList.Add(new XmlGame("=====================", string.Empty, string.Empty, string.Empty, null, null, null,
                    "=====================", string.Empty, string.Empty, null, null, 0, string.Empty, string.Empty));
            }

            foreach (var platform in xmlPlatforms)
            {
                noPlatformErrorList.Add(new XmlGame("Platform Found: ", string.Empty, string.Empty, string.Empty, null, null, null,
                    $"Platform: {platform.Name}", string.Empty, string.Empty, null, null, 0, string.Empty, string.Empty));
            }

            missingGames = new ConcurrentBag<XmlGame>(noPlatformErrorList);
            DebugTxt("Adding errors to missingGames List completed!");
            DebugTxt($"ownedGames: {ownedGames.Count} - missingGames: NoPlatformFound");
        }

        // GridView sort method
        private List<GameDisplayData> SortGames(List<GameDisplayData> games, string columnName)
        {
            return ascending
                ? games.OrderBy(x => x.GetType().GetProperty(columnName).GetValue(x, null)).ToList()
                : games.OrderByDescending(x => x.GetType().GetProperty(columnName).GetValue(x, null)).ToList();
        }


        private void PlatformSelectionForm_Resize(object sender, EventArgs e)
        {
            // Calculate the maximum width based on the gridviews' total width with all columns visible
            int maxWidth = CalculateMaxWidth();

            // Enforce the minimum and maximum width constraints
            if (this.Width > maxWidth)
            {
                this.Width = maxWidth;
            }
        }

        // Method to calculate the maximum width based on the gridviews' total width with all columns visible
        private int CalculateMaxWidth()
        {
            int ogTotalWidth = 0;
            // Calculate the total width of all visible columns in ownedGamesGridView
            if (ownedGamesGridView.Columns.Count > 0)
            {
                foreach (DataGridViewColumn column in ownedGamesGridView.Columns)
                {
                    if (column.Visible)
                    {
                        ogTotalWidth += column.Width;
                    }
                }
            }

            int mgTotalWidth = 0;
            // Calculate the total width of all visible columns in missingGamesGridView
            if (missingGamesGridView.Columns.Count > 0)
            {
                foreach (DataGridViewColumn column in missingGamesGridView.Columns)
                {
                    if (column.Visible)
                    {
                        mgTotalWidth += column.Width;
                    }
                }
            }

            var maxWidth = ogTotalWidth > mgTotalWidth ? ogTotalWidth : mgTotalWidth;
            // Add some padding or margin if needed
            maxWidth += 50; // Adjust this value as needed

            return maxWidth;
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



        // Populate the clbColumnSelection with the GridViews columns
        private void PopulateColumnSelection()
        {
            // Check if the ComboBox is null
            if (clbColumnSelection == null || clbColumnSelection.Items.Count <= 0)
            {
                // Get the properties of GameDisplayData
                Type type = typeof(GameDisplayData);
                PropertyInfo[] props = type.GetProperties();

                // Iterate through the properties
                foreach (PropertyInfo prop in props)
                {
                    if (prop.Name != "Title")
                    {
                        clbColumnSelection.Items.Add(prop.Name, true);
                    }
                }
            }
        }

        // Column toggler helper
        private void UpdateColumnVisibility()
        {
            foreach (DataGridViewColumn column in ownedGamesGridView.Columns)
            {
                var itemIndex = clbColumnSelection.Items.IndexOf(column.Name);
                if (itemIndex >= 0)
                {
                    column.Visible = clbColumnSelection.GetItemChecked(itemIndex);
                }
            }
            foreach (DataGridViewColumn column in missingGamesGridView.Columns)
            {
                var itemIndex = clbColumnSelection.Items.IndexOf(column.Name);
                if (itemIndex >= 0)
                {
                    column.Visible = clbColumnSelection.GetItemChecked(itemIndex);
                }
            }
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
                // Ensure the following code runs on the UI thread
                this.Invoke((MethodInvoker)delegate {
                    ReleaseCapture();
                    SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
                });
            }
        }

        // Handle URL requests
        private void OpenUrl(string url)
        {
            if (!string.IsNullOrEmpty(url))
            {
                DebugTxt($"OpenUrl: {url}");
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
            else
            {
                DebugTxt("OpenUrl url is empty or null!");
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
            if (pbMetadataLoading.InvokeRequired)
            {
                pbMetadataLoading.BeginInvoke(new Action(StartProgressBar));
                return;
            }
            // Set the progress bar style to Marquee for continuous movement
            pbMetadataLoading.Visible = true;
            pbMetadataLoading.Style = ProgressBarStyle.Marquee;
            pbMetadataLoading.Refresh();           
        }

        // Method to stop the progress bar and hide it when processing is complete
        private void StopProgressBar()
        {
            if (pbMetadataLoading.InvokeRequired)
            {
                pbMetadataLoading.BeginInvoke(new Action(StopProgressBar));
                return;
            }
            pbMetadataLoading.Visible = false;
            pbMetadataLoading.Style = ProgressBarStyle.Blocks;
            pbMetadataLoading.Refresh();
        }

        // Add text to debug textbox
        private bool isFirstUse = true; // Flag to track if it's the first use
        private void DebugTxt(string txt)
        {
            if (tbDebug.InvokeRequired)
            {
                tbDebug.BeginInvoke(new Action<string>(DebugTxt), new object[] { txt });
                return;
            }

            StringBuilder sb = new StringBuilder(tbDebug.Text);
            if (isFirstUse)
            {
                sb.AppendLine(); // Add a blank line
                sb.AppendLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")); // Add the current date/time
                isFirstUse = false; // Set the flag to false after the first use
            }
            sb.AppendLine(txt);
            tbDebug.Text = sb.ToString();
        }


        // Debug overload to toggle visibily of the debug textbox
        private void DebugTxt(bool visible)
        {
            if (tbDebug.InvokeRequired)
            {
                tbDebug.BeginInvoke(new Action<bool>(DebugTxt), new object[] { visible });
                return;
            }
            if (visible)
            {
                pDebugLog.Visible = true;
            }
            else
            {
                pDebugLog.Visible = false;
            }
        }
                
        // Only allow right resizing of the form
        protected override void WndProc(ref Message m)
        {
            const int WM_NCHITTEST = 0x84;
            const int HTRIGHT = 11;

            base.WndProc(ref m);

            if (m.Msg == WM_NCHITTEST)
            {
                Point pos = new Point(m.LParam.ToInt32());
                pos = this.PointToClient(pos);

                if (pos.X >= this.ClientSize.Width - 10 && pos.Y >= 0 && pos.Y <= this.ClientSize.Height)
                {
                    m.Result = (IntPtr)HTRIGHT;
                    return;
                }
            }
        }
        #endregion

        #region FormThemes
        public void ApplyTheme(Form form)
        {
            // Charcoal grey background
            form.BackColor = Color.FromArgb(54, 57, 63);

            // Loop through all controls and apply styles
            foreach (Control ctrl in form.Controls)
            {
                if (ctrl is System.Windows.Forms.Button btn && btn.Name != "btnClose")
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
                else if (ctrl is System.Windows.Forms.ComboBox cbx)
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
        #endregion
    }
}
