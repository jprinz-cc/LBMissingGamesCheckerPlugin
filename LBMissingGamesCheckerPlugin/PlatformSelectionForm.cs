﻿using System;
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
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using Unbroken.LaunchBox.Plugins;
using Unbroken.LaunchBox.Plugins.Data;
using static LBMissingGamesCheckerPlugin.PlatformSelectionForm.GameDisplayData;

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

            // Return all Alternate Names to the AlternateNames propery as a string
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


        // Color Progress Bar Class
        public class ProgressBarEx : ProgressBar
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
                        if (rect.Width == 0) rect.Width = 1;

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


        public class DataGridViewFilterHeaderCell : DataGridViewColumnHeaderCell
        {
            private readonly Image filterIcon = Properties.Resources.filter;
            private readonly DataGridView ownedGamesGridView;
            private readonly DataGridView missingGamesGridView;
            private readonly CheckedListBox clbFilterOptions;
            private readonly GroupBox gbFilterOptions;
            private readonly PlatformSelectionForm form;

            public DataGridViewFilterHeaderCell(DataGridViewColumnHeaderCell oldHeaderCell, DataGridView ownedGamesGridView, DataGridView missingGamesGridView, CheckedListBox clbFilterOptions, GroupBox gbFilterOptions, PlatformSelectionForm form)
                : base()
            {
                this.Value = oldHeaderCell.Value;
                this.ownedGamesGridView = ownedGamesGridView;
                this.missingGamesGridView = missingGamesGridView;
                this.clbFilterOptions = clbFilterOptions;
                this.gbFilterOptions = gbFilterOptions;
                this.form = form;
            }

            protected override void Paint(Graphics graphics, Rectangle clipBounds, Rectangle cellBounds, int rowIndex, DataGridViewElementStates dataGridViewElementState, object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
            {
                base.Paint(graphics, clipBounds, cellBounds, rowIndex, dataGridViewElementState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts);

                // Resize the filter icon to match the height of the column header cell
                int iconHeight = cellBounds.Height - 4; // Adjust as needed for padding
                int iconWidth = (filterIcon.Width * iconHeight) / filterIcon.Height; // Maintain aspect ratio
                int iconX = cellBounds.Right - iconWidth - 5;
                int iconY = cellBounds.Y + (cellBounds.Height - iconHeight) / 2;
                graphics.DrawImage(filterIcon, new Rectangle(iconX, iconY, iconWidth, iconHeight));
            }

            protected override void OnMouseClick(DataGridViewCellMouseEventArgs e)
            {
                base.OnMouseClick(e);

                // Check if the filter icon was clicked
                if (e.X >= this.Size.Width - filterIcon.Width - 5)
                {
                    Point screenPosition = Cursor.Position;
                    var gridView = this.DataGridView;
                    Point clientPosition = gridView.PointToClient(screenPosition);
                    clientPosition.X += (gbFilterOptions.Width - 20);
                    clientPosition.Y = gridView.Location.Y + 20;
                    // Show the filter options
                    ShowFilterOptions(this.OwningColumn, clientPosition);
                }
            }

            public bool IsIconClicked(int x)
            {
                int iconWidth = (filterIcon.Width * this.Size.Height) / filterIcon.Height;
                int iconX = this.Size.Width - iconWidth - 5;
                return x >= iconX && x <= iconX + iconWidth;
            }

            private void ShowFilterOptions(DataGridViewColumn column, Point clickPosition)
            {
                clbFilterOptions.Items.Clear();
                // Update the current grid view and column
                form.currentGridView = this.DataGridView;
                form.currentColumn = column;

                // Add this to repopulate clbFilterOptions
                var key = (form.currentGridView.Name, form.currentColumn.HeaderText);
                if (form.columnCheckedItems.ContainsKey(key))
                {
                    var checkedItems = form.columnCheckedItems[key];
                    foreach (var (item, isChecked) in checkedItems)
                    {
                        clbFilterOptions.Items.Add(item, isChecked);
                    }
                }
                
                gbFilterOptions.Location = new Point(clickPosition.X, clickPosition.Y);
                gbFilterOptions.Visible = true;
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

        private BindingList<GameDisplayData> ownedGamesDisplayData = new BindingList<GameDisplayData>();
        private BindingList<GameDisplayData> missingGamesDisplayData = new BindingList<GameDisplayData>();
        private BindingList<NoPlatformErrorData> noPlatformErrorDisplayData = new BindingList<NoPlatformErrorData>();

        public BindingList<GameDisplayData> OwnedGamesDisplayData => ownedGamesDisplayData;
        public BindingList<GameDisplayData> MissingGamesDisplayData => missingGamesDisplayData;
        public BindingList<NoPlatformErrorData> NoPlatformErrorDisplayData => noPlatformErrorDisplayData;

        // Properties to toggle sort order in the GridViews
        private string lastSortedColumnOwnedGames = string.Empty;
        private string lastSortedColumnMissingGames = string.Empty;
        private bool ascendingOwnedGames = true;
        private bool ascendingMissingGames = true;

        // Properties for the filtering
        private readonly Dictionary<(string GridViewName, string ColumnHeaderText), List<(string Item, bool IsChecked)>> columnCheckedItems = new Dictionary<(string, string), List<(string, bool)>>();
        private DataGridView currentGridView;
        private DataGridViewColumn currentColumn;
        private BindingList<GameDisplayData> originalOwnedGameList;
        private BindingList<GameDisplayData> originalMissingGameList;
        private List<GameDisplayData> filteredOwnedGameList = new List<GameDisplayData>();
        private List<GameDisplayData> filteredMissingGameList = new List<GameDisplayData>();

        // Graceful exit token
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        #endregion

        #region FormInit
        public PlatformSelectionForm(IList<IPlatform> platforms)
        {
            InitializeComponent();
            this.Paint += new PaintEventHandler(this.PlatformSelectionForm_Paint);
            this.Resize += new EventHandler(this.PlatformSelectionForm_Resize);

            Application.ApplicationExit += new EventHandler(this.OnApplicationExit);

            AddFilterIcons();

            // Bind BindingSources to GridViews
            ownedGamesGridView.DataSource = ownedGamesBindingSource;
            missingGamesGridView.DataSource = missingGamesBindingSource;
            noPlatformGridView.DataSource = noPlatformBindingSource;

            // Set elements visibility on load
            lblScrapeAs.Visible = false;
            lblPlatformWarning.Visible = false;
            noPlatformGridView.Visible = false;
            ssPlatformDropdownMsg.Visible = false;
            gbFilterOptions.Visible = false;
            DebugTxt(false);
            pbSpinner.Visible = true;
            pbSpinner.BringToFront();
            lblCongrats.Visible = false;
            pbCongrats.Visible = false;

            // Populate dropdown with user platforms
            foreach (var platform in platforms)
            {
                platformDropdown.Items.Add(platform.Name);
            }
            platformDropdown.SelectedIndex = 0;

            // Populate column selection checkboxes
            PopulateColumnSelection();
        }

        // Form Load
        private void PlatformSelectionForm_Load(object sender, EventArgs e)
        {
            EnableDoubleBuffering(ownedGamesGridView);
            EnableDoubleBuffering(missingGamesGridView);
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
                DebugTxt($"->metadataFilePath: {metadataFilePath}");
                DebugTxt($"Directory: {Directory.GetCurrentDirectory()}");
                DebugTxt(true);
                UpdateStatus("error", $"{metadataFile} not found");
            }
        }

        private void EnableDoubleBuffering(DataGridView dgv)
        {
            typeof(DataGridView).InvokeMember("DoubleBuffered",
                BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty,
                null,
                dgv,
                new object[] { true });
        }

        private void PlatformSelectionForm_Paint(object sender, PaintEventArgs e)
        {
            DrawResizeHandle(e.Graphics);
        }

        private void PlatformSelectionForm_Resize(object sender, EventArgs e)
        {
            this.Invalidate(); // Invalidate the form to trigger a repaint
        }

        private void DrawResizeHandle(Graphics g)
        {
            int gripSize = 10;
            int gripCount = 3;
            int spacing = 4;
            int startX = this.ClientSize.Width - gripSize - 2;
            int startY = (this.ClientSize.Height / 2) - ((gripSize * gripCount + spacing * (gripCount - 1)) / 2) + 30;

            for (int i = 0; i < gripCount; i++)
            {
                g.FillRectangle(Brushes.Gray, startX, startY + i * (gripSize + spacing), gripSize, gripSize);
            }
        }

        // Confirm button handler for dropdown platform selection
        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            if (platformDropdown.SelectedItem != null && platformDropdown.SelectedIndex > 0)
            {
                confirmButton.Enabled = false;
                gbFilterOptions.Visible = false;
                columnCheckedItems?.Clear();
                originalOwnedGameList?.Clear();
                originalMissingGameList?.Clear();
                try
                {
                    DebugTxt($"-> Starting GridView loading. Dropdown Item: {platformDropdown.SelectedItem}");
                    SelectedPlatform = PluginHelper.DataManager.GetPlatformByName(platformDropdown.SelectedItem.ToString());
                    if (SelectedPlatform == null)
                    {
                        tsslPlatformDropdownMsg.Text = $"Error with Platform: {platformDropdown.SelectedItem}";
                        ssPlatformDropdownMsg.Visible = true;
                        return;
                    }
                    // Validate ScrapeAs value
                    var isScrapeAs = string.IsNullOrEmpty(SelectedPlatform.ScrapeAs) ? "NullOrEmpty" : SelectedPlatform.ScrapeAs;
                    DebugTxt($"Selected Platform ScrapeAs: {isScrapeAs}");
                    if (isScrapeAs != "NullOrEmpty")
                    {
                        lblScrapeAs.Text = $"Searching As: {isScrapeAs}";
                        lblScrapeAs.Visible = true;
                    }
                    else
                    {
                        lblScrapeAs.Text = $"Searching As: ";
                        lblScrapeAs.Visible = false;
                    }
                    var platformToCheck = string.IsNullOrEmpty(SelectedPlatform.ScrapeAs) ? SelectedPlatform.Name : SelectedPlatform.ScrapeAs;
                    var platformFound = xmlPlatforms.Any(platform => platform.Name == platformToCheck);
                    DebugTxt($"Platform Found: {platformFound}");
                    ssPlatformDropdownMsg.Visible = false;
                    GetAllPlatformGames(SelectedPlatform, platformFound, platformToCheck);
                }
                catch (Exception ex)
                {
                    LogException(ex);
                }
                finally
                {
                    confirmButton.Enabled = true;
                }
            }
            else
            {
                confirmButton.Enabled = true;
                ssPlatformDropdownMsg.Visible = true;
            }
        }

        // GridView column click handlers
        private async void GridView_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new Action<object, DataGridViewCellMouseEventArgs>(GridView_ColumnHeaderMouseClick), new object[] { sender, e });
                return;
            }
            if (!(sender is DataGridView gridView)) return;

            // Check if the column is a button column
            if (gridView.Columns[e.ColumnIndex].HeaderCell is DataGridViewFilterHeaderCell headerCell && headerCell.IsIconClicked(e.X))
            {
                // Click was on the icon, ignore sorting
                return;
            }

            // Store the Tag properties for button columns before sorting
            DebugTxt("-> Starting column sort. Checking if column is YT or wiki");
            gridView.SuspendLayout();
            string columnName = gridView.Columns[e.ColumnIndex].HeaderText;
            if (columnName == "VideoUrl" || columnName == "WikipediaUrl") return;

            string gridViewName = gridView.Name;

            // Toggle sort order
            DebugTxt("Start of sort toggle...");
            ToggleSortOrder(columnName, gridViewName);
            DebugTxt("Sort toggle completed!");

            // Perform the sorting using SortGames method
            DebugTxt("Start of Column Sorting...");
            if (gridView.DataSource is BindingSource bindingSource && bindingSource.DataSource is BindingList<GameDisplayData> bindingList)
            {
                var sortedList = await Task.Run(() =>
                {
                    return SortGames(bindingList, gridView.Columns[e.ColumnIndex].HeaderText, gridView);
                });
                DebugTxt($"Column Sorting completed! Sorted list contains {sortedList.Count} entries.");
                bindingSource.DataSource = new BindingList<GameDisplayData>(sortedList);

            }
            DebugTxt("Column Sorting completed!");

            gridView.Refresh();
            gridView.ResumeLayout();
        }

        // GridView cell formatting
        private void GridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new Action<object, DataGridViewCellFormattingEventArgs>(GridView_CellFormatting), new object[] { sender, e });
                return;
            }
            if (!(sender is DataGridView gridView)) return;
            DataGridViewCell currentCell = gridView.Rows[e.RowIndex].Cells[e.ColumnIndex];

            if (gridView.Columns[e.ColumnIndex].HeaderText == "LaunchBoxDbId")
            {
                if (e.Value != null)
                {
                    // Check for the string "LBDbId" in the cell.
                    string stringValue = (string)e.Value;
                    try
                    {
                        if (!string.IsNullOrEmpty(stringValue))
                        {
                            currentCell.Tag = $"https://gamesdb.launchbox-app.com/games/dbid/{stringValue.Trim()}";
                            e.Value = $"LaunchBoxDB #{stringValue}";
                            currentCell.ToolTipText = e.Value.ToString();
                            e.FormattingApplied = true;
                        }
                        else
                        {
                            e.CellStyle.BackColor = Color.FromArgb(54, 57, 63);
                            e.FormattingApplied = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        LogException(ex);
                        e.FormattingApplied = false;
                    }
                }
            }
            else if (gridView.Columns[e.ColumnIndex].HeaderText == "VideoUrl")
            {
                if (e.Value != null)
                {
                    // Check for the string "LBDbId" in the cell.
                    string stringValue = (string)e.Value;
                    try
                    {
                        if (!string.IsNullOrEmpty(stringValue))
                        {
                            currentCell.Tag = e.Value.ToString();
                            currentCell.ToolTipText = e.Value.ToString();
                            e.Value = "YouTube";
                            e.FormattingApplied = true;
                        }
                        else
                        {
                            e.CellStyle.BackColor = Color.FromArgb(54, 57, 63);
                            e.FormattingApplied = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        LogException(ex);
                        e.FormattingApplied = false;
                    }
                }
            }
            else if (gridView.Columns[e.ColumnIndex].HeaderText == "WikipediaUrl")
            {
                if (e.Value != null)
                {
                    // Check for the string "LBDbId" in the cell.
                    string stringValue = (string)e.Value;
                    try
                    {
                        if (!string.IsNullOrEmpty(stringValue))
                        {
                            currentCell.Tag = e.Value.ToString();
                            currentCell.ToolTipText = e.Value.ToString();
                            e.Value = "Wiki";
                            e.FormattingApplied = true;
                        }
                        else
                        {
                            e.CellStyle.BackColor = Color.FromArgb(54, 57, 63);
                            e.FormattingApplied = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        LogException(ex);
                        e.FormattingApplied = false;
                    }

                }
            }
        }

        private void PlatformDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedPlatform = platformDropdown.SelectedItem.ToString().ToLower();

            if (selectedPlatform.Contains("windows") || selectedPlatform.Contains("ms-dos"))
            {
                lblPlatformWarning.Visible = true;
            }
            else
            {
                lblPlatformWarning.Visible = false;
            }
        }

        private void GridView_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new Action<object, DataGridViewCellEventArgs>(GridView_CellMouseEnter), new object[] { sender, e });
                return;
            }
            if (!(sender is DataGridView gridView)) return;

            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && gridView.Columns[e.ColumnIndex] is DataGridViewTextBoxColumn)
            {
                DataGridViewTextBoxCell cell = (DataGridViewTextBoxCell)gridView.Rows?[e.RowIndex].Cells?[e.ColumnIndex];
                if (!string.IsNullOrEmpty(cell.Value.ToString()))
                {
                    cell.Style.ForeColor = Color.FromArgb(255, 191, 0);
                }
            }
        }

        private void GridView_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new Action<object, DataGridViewCellEventArgs>(GridView_CellMouseEnter), new object[] { sender, e });
                return;
            }
            if (!(sender is DataGridView gridView)) return;

            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && gridView.Columns[e.ColumnIndex] is DataGridViewTextBoxColumn)
            {
                DataGridViewTextBoxCell cell = (DataGridViewTextBoxCell)gridView.Rows?[e.RowIndex].Cells?[e.ColumnIndex];
                if (!string.IsNullOrEmpty(cell.Value.ToString()))
                {
                    cell.Style.ForeColor = Color.White;
                }
            }
        }

        // GridView cell click handler
        private void GridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new Action<object, DataGridViewCellEventArgs>(GridView_CellContentClick), new object[] { sender, e });
                return;
            }
            if (!(sender is DataGridView gridView)) return;
            if (e.RowIndex >= 0 && gridView.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                DebugTxt("Start of cell click handler...");
                DataGridViewCell cell = gridView.Rows[e.RowIndex].Cells[e.ColumnIndex];
                DebugTxt($"Cell clicker: {cell.Value}");
                if (string.IsNullOrWhiteSpace(cell.Value?.ToString()))
                {
                    // Cancel the click event
                    gridView.CurrentCell = null;
                }
                else
                {
                    try
                    {
                        string url = cell.Tag.ToString();
                        DebugTxt($"Opening URL: {url}");
                        Process.Start(new ProcessStartInfo(url) { UseShellExecute = true }); // Open the URL in the default browser
                    }
                    catch (Exception ex)
                    {
                        LogException(ex);
                        MessageBox.Show($"An error occurred while processing the cell click: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // Column filtering events
        private void ApplyFilters_Click(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new Action<object, EventArgs>(ApplyFilters_Click), new object[] { sender, e });
                return;
            }

            // Apply filtering logic
            if (currentGridView != null && currentColumn != null)
            {
                currentGridView.SuspendLayout();

                var gameList = currentGridView.Name == "ownedGamesGridView" ? originalOwnedGameList : originalMissingGameList;                                                              

                if (gameList == null)
                {
                    DebugTxt("Game lists are null, unable to filter.");
                    gbFilterOptions.Visible = false;
                    return;
                }

                var filteredList = new List<GameDisplayData>();


                foreach (var item in clbFilterOptions.CheckedItems)
                {
                    string value = item.ToString();
                    if (currentColumn.HeaderText == "Genres")
                    {
                        var values = value.Split(new[] { ';' }, StringSplitOptions.None).Select(v => v.Trim()).ToList();

                        filteredList.AddRange(gameList.Where(game =>
                        {
                            var genres = game.Genres.Split(new[] { ';' }, StringSplitOptions.None).Select(g => g.Trim()).ToList();
                            return values.Any(v => genres.Contains(v));
                        }).ToList());
                    }
                    else if (currentColumn.HeaderText == "Region")
                    {
                        var values = value.Split(new[] { ',' }, StringSplitOptions.None).Select(v => v.Trim()).ToList();

                        filteredList.AddRange(gameList.Where(game =>
                        {
                            var genres = game.Region.Split(new[] { ',' }, StringSplitOptions.None).Select(g => g.Trim()).ToList();
                            return values.Any(v => genres.Contains(v));
                        }).ToList());
                    }
                    else if (currentColumn.HeaderText == "CommunityStarRating")
                    {
                        filteredList.AddRange(gameList.Where(game =>
                        {
                            var rating = float.TryParse(game.CommunityStarRating, out float parsedRating) ? parsedRating : 0f;
                            var bucket = value.Split('-');
                            if (bucket.Length == 2 && float.TryParse(bucket[0], out float min) && float.TryParse(bucket[1], out float max))
                            {
                                return rating >= min && rating < max;
                            }
                            return false;
                        }).ToList());
                    }
                    else
                    {
                        var propertyName = currentColumn.DataPropertyName;

                        filteredList.AddRange(gameList.Where(game =>
                        {
                            var propertyValue = game.GetType().GetProperty(propertyName)?.GetValue(game, null);
                            return propertyValue?.ToString() == value;
                        }).ToList());
                    }
                }

                // Remove duplicates from filteredList
                filteredList = filteredList.Distinct().ToList();

                // Apply the filtered list to the BindingSource
                if (currentGridView.Name == "ownedGamesGridView")
                {
                    ownedGamesBindingSource.DataSource = new BindingList<GameDisplayData>(filteredList);
                    lblOwnedGamesCount.Text = filteredList.Count.ToString();
                }
                else if (currentGridView.Name == "missingGamesGridView")
                {
                    missingGamesBindingSource.DataSource = new BindingList<GameDisplayData>(filteredList);
                    lblMissingGamesCount.Text = filteredList.Count.ToString();
                }

                // Update checked status in the columnCheckedItems dictionary against each item in the clbFilterOptions
                if (currentColumn != null)
                {
                    var key = (currentGridView.Name, currentColumn.HeaderText);
                    var checkedItems = columnCheckedItems[key];
                    for (int i = 0; i < clbFilterOptions.Items.Count; i++)
                    {
                        string item = clbFilterOptions.Items[i].ToString();
                        bool isChecked = clbFilterOptions.GetItemChecked(i);

                        var index = checkedItems.FindIndex(x => x.Item == item);
                        if (index >= 0)
                        {
                            checkedItems[index] = (item, isChecked);
                        }
                    }
                }

                currentGridView.Refresh();
                currentGridView.ResumeLayout();

                gbFilterOptions.Visible = false;
            }
        }

        private void FilterReset_Click(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new Action<object, EventArgs>(FilterReset_Click), new object[] { sender, e });
                return;
            }
            currentGridView.SuspendLayout();

            if (currentGridView.Name == "ownedGamesGridView")
            {
                ownedGamesBindingSource.DataSource = originalOwnedGameList;
                lblOwnedGamesCount.Text = originalOwnedGameList.Count.ToString();
                filteredOwnedGameList.Clear();
            }
            else if (currentGridView.Name == "missingGamesGridView")
            {
                lblMissingGamesCount.Text = originalMissingGameList.Count.ToString();
                missingGamesBindingSource.DataSource = originalMissingGameList;
                filteredMissingGameList.Clear();
            }

            var key = (currentGridView.Name, currentColumn.HeaderText);
            for (int i = 0; i < columnCheckedItems[key].Count; i++)
            {
                columnCheckedItems[key][i] = (columnCheckedItems[key][i].Item, true);
            }
            currentGridView.Refresh();
            currentGridView.ResumeLayout();
            gbFilterOptions.Visible = false;
        }

        // Toggle column visibility based on the CheckedListBox 
        private void CheckedListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new Action<object, ItemCheckEventArgs>(CheckedListBox_ItemCheck), new object[] { sender, e });
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
                if (column.HeaderText == columnName)
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

        private void PlatformSelectionForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _cancellationTokenSource.Cancel();
        }

        private void CloseFilter_Click(object sender, EventArgs e)
        {
            DebugTxt("Closing Filter Options Panel!");
            gbFilterOptions.Visible = false;
        }

        private void OnApplicationExit(object sender, EventArgs e)
        {
            _cancellationTokenSource.Cancel();
        }
        #endregion

        #region MainMethods
        private async void GetAllPlatformGames(IPlatform selectedPlatform, bool platformFound, string platformToCheck)
        {
            // Disable form btns and reset for new load
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() =>
                {
                    confirmButton.Enabled = false;
                    clbColumnSelection.Enabled = false;
                    btnOwnedCSV.Enabled = false;
                    btnMissingCSV.Enabled = false;
                    lblOwnedGamesCount.Text = "0";
                    lblMissingGamesCount.Text = "0";
                }));
            }
            else
            {
                confirmButton.Enabled = false;
                clbColumnSelection.Enabled = false;
                btnOwnedCSV.Enabled = false;
                btnMissingCSV.Enabled = false;
                lblOwnedGamesCount.Text = "0";
                lblMissingGamesCount.Text = "0";
            }

            DebugTxt("Starting GetAllPlatformGames...");
            HashSet<int> ownedGameIds = new HashSet<int>();

            // Check if "Released" filter is applied
            bool filterReleasedOnly = chkReleasedOnly.Checked;

            if (selectedPlatform == null)
            {
                DebugTxt("selectedPlatform is null.");
                return;
            }
            try
            {
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
                var ownedGamesList = await Task.Run(() => selectedPlatform.GetAllGames(true, true));
                if (ownedGamesList == null)
                {
                    DebugTxt("ownedGames is null");
                    return;
                }
                else
                {
                    DebugTxt($"ownedGamesList Count: {ownedGamesList.Count()}");
                    var ownedGamesCount = await Task.Run(() => {
                        try
                        {
                            foreach (var game in ownedGamesList)
                            {
                                if (game.LaunchBoxDbId != null && !string.IsNullOrEmpty(game.LaunchBoxDbId?.ToString()))
                                {
                                    ownedGames.Add(game);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            DebugTxt($"Exception processing Missing Games: {ex.Message}");
                        }
                        return ownedGames.Count;
                    });
                    DebugTxt($"ownedGames Count: {ownedGamesCount}");
                }

                if (filterReleasedOnly)
                {
                    DebugTxt("Filtering ownedGames...");
                    ownedGames = await Task.Run(() => {
                        return new ConcurrentBag<IGame>(ownedGames.Where(og => og.LaunchBoxDbId.HasValue && og.ReleaseType == "Released"));
                    });
                    DebugTxt("Filtering ownedGames completed!");
                }

                // Convert owned games to a HashSet for fast lookups
                DebugTxt("Creating HashSet...");
                ownedGameIds = await Task.Run(() => {
                    return new HashSet<int>(ownedGames.Where(og => og.LaunchBoxDbId.HasValue).Select(og => og.LaunchBoxDbId.Value));
                });
                DebugTxt($"ownedGameIds HashSet complete: {ownedGameIds.Count}");
            }
            catch (Exception ex)
            {
                LogException(ex);
            }


            if (xmlPlatforms == null)
            {
                DebugTxt("xmlPlatforms is null.");
                return;
            }

            DebugTxt("Starting missingGames check...");

            if (platformFound)
            {
                DebugTxt($"Processing Missing Games. xmlGames: {xmlGames.Count}");
                try
                {
                    var filteredGames = await Task.Run(() =>
                    {
                        return xmlGames.Where(xmlGame => xmlGame.Platform == platformToCheck) // Ensure platform matches selected platform
                        .Where(xmlGame => xmlGame.LaunchBoxDbId.HasValue && !ownedGameIds.Contains(xmlGame.LaunchBoxDbId.Value)) // Check if game is missing
                        .Where(xmlGame => !filterReleasedOnly || xmlGame.ReleaseType == "Released").ToList(); // Check release type
                        //** Enable to debug each game being processed **//
                        //.Select(xmlGame => {
                        //DebugTxt($"Processing xmlGame: {xmlGame.Title}, ID: {xmlGame.LaunchBoxDbId}");
                        //return xmlGame;
                        //})
                        //.ToList();
                    });
                    missingGames = new ConcurrentBag<XmlGame>(filteredGames);
                    DebugTxt($"ownedGames: {ownedGames.Count} - missingGames: {missingGames.Count}");
                }
                catch (Exception ex)
                {
                    DebugTxt($"Exception processing Missing Games: {ex.Message}");
                }
                DebugTxt($"Processing Missing Games completed!");
            }
            else
            {
                // Add final "NoPlatformFound" message row
                try
                {
                    DebugTxt("Adding error to missingGames List...");
                    var noPlatformErrorList = new List<XmlGame>
                    {
                        new XmlGame("NoPlatformFound", string.Empty, string.Empty, string.Empty, null, null, null,
                            $"The selected platform '{platformDropdown.SelectedItem}' was not found in the LaunchBox DB.", string.Empty, string.Empty, null, null, 0, string.Empty, string.Empty),
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

                    var sortedPlatforms = xmlPlatforms.OrderBy(platform => platform.Name).ToList();
                    foreach (var platform in sortedPlatforms)
                    {
                        noPlatformErrorList.Add(new XmlGame("Platform Found: ", string.Empty, string.Empty, string.Empty, null, null, null,
                            $"Platform: {platform.Name}", string.Empty, string.Empty, null, null, 0, string.Empty, string.Empty));
                    }

                    missingGames = new ConcurrentBag<XmlGame>(noPlatformErrorList);
                    DebugTxt("Adding errors to missingGames List completed!");
                    DebugTxt($"ownedGames: {ownedGames.Count} - missingGames: NoPlatformFound");
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

            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() =>
                {
                    // Suspend layout to prevent unnecessary redraws
                    DebugTxt("Suspending ownedGamesGridView...");
                    ownedGamesGridView.SuspendLayout();

                    DebugTxt("Suspending missingGamesGridView...");
                    missingGamesGridView.SuspendLayout();

                    DebugTxt("Suspending noPlatformGridView...");
                    noPlatformGridView.SuspendLayout();

                    DebugTxt("Clearing data containers...");
                    ownedGamesDisplayData.Clear();
                    missingGamesDisplayData.Clear();
                    noPlatformErrorDisplayData.Clear();
                    ownedGamesBindingSource.Clear();
                    missingGamesBindingSource.Clear();
                    noPlatformBindingSource.Clear();
                    filteredOwnedGameList.Clear();
                    DebugTxt("Clearing data containers completed!");
                }));
            }
            else
            {
                // Suspend layout to prevent unnecessary redraws
                DebugTxt("Suspending ownedGamesGridView...");
                ownedGamesGridView.SuspendLayout();

                DebugTxt("Suspending missingGamesGridView...");
                missingGamesGridView.SuspendLayout();

                DebugTxt("Suspending noPlatformGridView...");
                noPlatformGridView.SuspendLayout();

                DebugTxt("Clearing data containers...");
                ownedGamesDisplayData.Clear();
                missingGamesDisplayData.Clear();
                noPlatformErrorDisplayData.Clear();
                ownedGamesBindingSource.Clear();
                missingGamesBindingSource.Clear();
                noPlatformBindingSource.Clear();
                filteredOwnedGameList.Clear();
                DebugTxt("Clearing data containers completed!");
            }

            try
            {
                DebugTxt("Loading ownedGamesDisplayData...");
                var ownedGamesList = await Task.Run(() =>
                {
                    return ownedGames.OrderBy(game => game.Title)
                    .Select(game => new GameDisplayData(new XmlGame(
                        game.Title, game.Developer, game.Publisher, game.Region, (DateTime?)game.ReleaseDate,
                        (float?)game.CommunityStarRating, (int?)game.CommunityStarRatingTotalVotes,
                        game.Platform, game.ReleaseType, game.GenresString, game.GetAllAlternateNames(),
                        game.MaxPlayers, game.LaunchBoxDbId, game.VideoUrl, game.WikipediaUrl
                    ))).ToList();
                });
                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(() =>
                    {
                        ownedGamesDisplayData = new BindingList<GameDisplayData>(ownedGamesList);
                    }));
                }
                else
                {
                    ownedGamesDisplayData = new BindingList<GameDisplayData>(ownedGamesList);
                }
                DebugTxt($"ownedGamesDisplayData loaded! {ownedGamesDisplayData.Count}");

                try
                {
                    // Bind missingGames data to GridView                
                    if (missingGames != null && missingGames.Any() && missingGames.First()?.LaunchBoxDbId != null && missingGames.First().LaunchBoxDbId != 0)  // If the selectedPlatform returned games from the local db
                    {
                        DebugTxt("Loading missingGamesDisplayData...");
                        DebugTxt($"missingGames first LBID: {missingGames.First().LaunchBoxDbId}");
                        var missingGamesList = await Task.Run(() =>
                        {
                            return missingGames.OrderBy(game => game.Title)
                            .Select(game => new GameDisplayData(game)).ToList();
                        });
                        if (this.InvokeRequired)
                        {
                            this.Invoke(new Action(() =>
                            {
                                missingGamesDisplayData = new BindingList<GameDisplayData>(missingGamesList);
                            }));
                        }
                        else
                        {
                            missingGamesDisplayData = new BindingList<GameDisplayData>(missingGamesList);
                        }
                        DebugTxt("Loading missingGamesDisplayData completed!");
                    }
                    else if (missingGames != null && missingGames.Any() && missingGames.First()?.LaunchBoxDbId == 0)  // If the selectedPlatform was not found in the LaunchBoxDb
                    {
                        DebugTxt("Loading noPlatformErrorDisplayData...");
                        var errorList = await Task.Run(() =>
                        {
                            return missingGames.Reverse().Select(item => new NoPlatformErrorData(
                                    item.Title,
                                    item.Platform,
                                    item.LaunchBoxDbId
                                )).ToList();
                        });
                        if (this.InvokeRequired)
                        {
                            this.Invoke(new Action(() =>
                            {
                                noPlatformErrorDisplayData = new BindingList<NoPlatformErrorData>(errorList);
                            }));
                        }
                        else
                        {
                            noPlatformErrorDisplayData = new BindingList<NoPlatformErrorData>(errorList);
                        }
                        DebugTxt("Loading noPlatformErrorDisplayData completed!");
                    }
                    else if (missingGames == null)
                    {
                        DebugTxt("Loading missingGamesDisplayData did NOT complete, missingGames is null!");
                        return;
                    }
                    DebugTxt("Loading DisplayData completed!");
                }
                catch (Exception ex)
                {
                    LogException(ex);
                }

                try
                {
                    if (this.InvokeRequired)
                    {
                        this.Invoke(new Action(() =>
                        {
                            DebugTxt($"Binding ownedGamesBindingSource with {ownedGamesDisplayData.Count} ownedGamesDisplayData elements...");
                            ownedGamesBindingSource.DataSource = ownedGamesDisplayData;
                            originalOwnedGameList = ownedGamesDisplayData;
                            lblOwnedGamesCount.Text = ownedGamesDisplayData.Count > 0 ? ownedGamesDisplayData.Count.ToString() : "0";
                            btnOwnedCSV.Enabled = true;
                            LoadFilterOptions(ownedGamesGridView);
                        }));
                    }
                    else
                    {
                        DebugTxt($"Binding ownedGamesBindingSource with {ownedGamesDisplayData.Count} ownedGamesDisplayData elements...");
                        ownedGamesBindingSource.DataSource = ownedGamesDisplayData;
                        originalOwnedGameList = ownedGamesDisplayData;
                        lblOwnedGamesCount.Text = ownedGamesDisplayData.Count > 0 ? ownedGamesDisplayData.Count.ToString() : "0";
                        btnOwnedCSV.Enabled = true;
                        LoadFilterOptions(ownedGamesGridView);
                    }
                    DebugTxt("Binding ownedGamesBindingSource completed!");
                }
                catch (Exception ex)
                {
                    LogException(ex);
                }

                try
                {
                    DebugTxt("Starting missingGames or noPlatform binding...");
                    if (missingGamesDisplayData != null && missingGamesDisplayData.Any() && !string.IsNullOrEmpty(missingGamesDisplayData.FirstOrDefault()?.LaunchBoxDbId) && missingGamesDisplayData.First().LaunchBoxDbId != "0")
                    {
                        if (this.InvokeRequired)
                        {
                            this.Invoke(new Action(() =>
                            {
                                DebugTxt($"Binding missingGamesBindingSource with {missingGamesDisplayData.Count} missingGamesDisplayData elements...");
                                missingGamesGridView.Visible = true;
                                noPlatformGridView.Visible = false;
                                missingGamesBindingSource.DataSource = missingGamesDisplayData;
                                originalMissingGameList = missingGamesDisplayData;
                                LoadFilterOptions(missingGamesGridView);
                            }));
                        }
                        else
                        {
                            DebugTxt($"Binding missingGamesBindingSource with {missingGamesDisplayData.Count} missingGamesDisplayData elements...");
                            missingGamesGridView.Visible = true;
                            noPlatformGridView.Visible = false;
                            missingGamesBindingSource.DataSource = missingGamesDisplayData;
                            originalMissingGameList = missingGamesDisplayData;
                            LoadFilterOptions(missingGamesGridView);
                        }

                        if (this.InvokeRequired)
                        {
                            this.Invoke(new Action(() =>
                            {
                                lblMissingGamesCount.Text = missingGamesDisplayData.Count.ToString();
                                btnMissingCSV.Enabled = true;
                                DebugTxt($"missingGames.Count: {missingGamesDisplayData.Count}");
                                lblCongrats.Visible = false;
                                pbCongrats.Visible = false;
                            }));
                        }
                        else
                        {
                            lblMissingGamesCount.Text = missingGamesDisplayData.Count.ToString();
                            btnMissingCSV.Enabled = true;
                            DebugTxt($"missingGames.Count: {missingGamesDisplayData.Count}");
                            lblCongrats.Visible = false;
                            pbCongrats.Visible = false;
                        }
                        DebugTxt("Binding missingGamesBindingSource completed!");
                    }
                    else if (noPlatformErrorDisplayData != null && noPlatformErrorDisplayData.Any() && noPlatformErrorDisplayData.First() != null && noPlatformErrorDisplayData.First().LaunchBoxDbId != null && noPlatformErrorDisplayData.First().LaunchBoxDbId == "0")
                    {
                        if (this.InvokeRequired)
                        {
                            this.Invoke(new Action(() =>
                            {
                                DebugTxt($"Binding noPlatformBindingSource with {noPlatformErrorDisplayData.Count} noPlatformErrorDisplayData elements...");
                                noPlatformGridView.Visible = true;
                                missingGamesGridView.Visible = false;
                                noPlatformBindingSource.DataSource = noPlatformErrorDisplayData;
                                lblMissingGamesCount.Text = "0";
                                lblCongrats.Visible = false;
                                pbCongrats.Visible = false;
                            }));
                        }
                        else
                        {
                            DebugTxt($"Binding noPlatformBindingSource with {noPlatformErrorDisplayData.Count} noPlatformErrorDisplayData elements...");
                            noPlatformGridView.Visible = true;
                            missingGamesGridView.Visible = false;
                            noPlatformBindingSource.DataSource = noPlatformErrorDisplayData;
                            lblMissingGamesCount.Text = "0";
                            lblCongrats.Visible = false;
                            pbCongrats.Visible = false;
                        }
                        DebugTxt("Binding noPlatformBindingSource completed!");
                    }
                    else if (missingGamesDisplayData != null && !missingGamesDisplayData.Any())
                    {
                        if (this.InvokeRequired)
                        {
                            this.Invoke(new Action(() =>
                            {
                                DebugTxt("There are no Missing Games! Congrates!");
                                missingGamesGridView.Visible = true;
                                noPlatformGridView.Visible = false;
                                lblCongrats.Visible = true;
                                pbCongrats.Visible = true;
                                pbCongrats.BringToFront();
                            }));
                        }
                        else
                        {
                            DebugTxt("There are no Missing Games! Congrates!");
                            missingGamesGridView.Visible = true;
                            noPlatformGridView.Visible = false;
                            lblCongrats.Visible = true;
                            pbCongrats.Visible = true;
                            pbCongrats.BringToFront();
                        }
                    }
                    else if (missingGamesDisplayData == null && NoPlatformErrorDisplayData == null || missingGamesDisplayData != null && !missingGamesDisplayData.Any() && ownedGamesDisplayData != null && !ownedGamesDisplayData.Any())
                    {
                        if (this.InvokeRequired)
                        {
                            this.Invoke(new Action(() =>
                            {
                                DebugTxt("Neither missingGames/noPlatform binding occured!");
                                DebugTxt(true);
                                lblCongrats.Visible = false;
                                pbCongrats.Visible = false;
                            }));
                        }
                        else
                        {
                            DebugTxt("Neither missingGames/noPlatform binding occured!");
                            DebugTxt(true);
                            lblCongrats.Visible = false;
                            pbCongrats.Visible = false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    LogException(ex);
                }

                // DataGridViews are processed
                DebugTxt("GridViews Processed!");
            }
            catch (Exception ex)
            {
                DebugTxt($"An exception happened processing the GridViews: {ex.Message}");
                LogException(ex);
            }
            finally
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(() =>
                    {
                        // Apply column visibility based on clbColumnSelection's check states
                        DebugTxt($"Apply column visibility to {clbColumnSelection.Items.Count} columns.");
                        UpdateColumnVisibility();

                        DebugTxt("Resuming ownedGamesGridView...");
                        ownedGamesGridView.ResumeLayout();

                        DebugTxt("Resuming missingGamesGridView...");
                        missingGamesGridView.ResumeLayout();

                        DebugTxt("Resuming noPlatformGridView...");
                        noPlatformGridView.ResumeLayout();

                        confirmButton.Enabled = true;
                        clbColumnSelection.Enabled = true;
                    }));
                }
                else
                {
                    // Apply column visibility based on clbColumnSelection's check states
                    DebugTxt($"Apply column visibility to {clbColumnSelection.Items.Count} columns.");
                    UpdateColumnVisibility();
                    DebugTxt("Resuming ownedGamesGridView...");
                    ownedGamesGridView.ResumeLayout();

                    DebugTxt("Resuming missingGamesGridView...");
                    missingGamesGridView.ResumeLayout();

                    DebugTxt("Resuming noPlatformGridView...");
                    noPlatformGridView.ResumeLayout();

                    confirmButton.Enabled = true;
                    clbColumnSelection.Enabled = true;
                }
                DebugTxt("Resuming GridViews completed!");
            }
        }

        private void LoadFilterOptions(DataGridView dgv)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new Action<DataGridView>(LoadFilterOptions), new object[] { dgv });
                return;
            }

            var uniqueValues = new HashSet<string>();
            var checkedItems = new List<(string Item, bool IsChecked)>();

            // Find the matching column in the GridView
            foreach (DataGridViewColumn column in dgv.Columns)
            {
                if (column.HeaderText == "Developer" || column.HeaderText == "Publisher" || column.HeaderText == "Region" ||
                    column.HeaderText == "CommunityStarRating" || column.HeaderText == "Genres")
                {
                    if (column.HeaderText == "Region")
                    {
                        uniqueValues = dgv.Rows.Cast<DataGridViewRow>()
                            .SelectMany(row => row.Cells[column.Index].Value?.ToString().Split(new[] { ',' }, StringSplitOptions.None))
                            .Select(value => value.Trim())
                            .ToHashSet();
                    }
                    else if (column.HeaderText == "Genres")
                    {
                        uniqueValues = dgv.Rows.Cast<DataGridViewRow>()
                            .SelectMany(row => row.Cells[column.Index].Value?.ToString().Split(new[] { ';' }, StringSplitOptions.None))
                            .Select(value => value.Trim())
                            .ToHashSet();
                    }
                    else if (column.HeaderText == "CommunityStarRating")
                    {
                        var ratingBuckets = new Dictionary<string, (float Min, float Max)>
                        {
                            { "0-1", (0f, 1f) },
                            { "1-2", (1f, 2f) },
                            { "2-3", (2f, 3f) },
                            { "3-4", (3f, 4f) },
                            { "4-5", (4f, 5f) }
                        };

                        var ratings = dgv.Rows.Cast<DataGridViewRow>()
                            .Select(row => row.Cells[column.Index].Value?.ToString())
                            .Where(value => float.TryParse(value, out _))
                            .Select(value => float.Parse(value))
                            .ToList();
                        if (uniqueValues != null && uniqueValues.Any()) uniqueValues.Clear();
                        foreach (var bucket in ratingBuckets)
                        {
                            if (ratings.Any(rating => rating >= bucket.Value.Min && rating < bucket.Value.Max))
                            {
                                uniqueValues.Add(bucket.Key);
                            }
                        }
                    }
                    else
                    {
                        uniqueValues = dgv.Rows.Cast<DataGridViewRow>()
                            .Select(row => row.Cells[column.Index].Value?.ToString())
                            .Select(value => value?.Trim())
                            .ToHashSet();

                        // Add empty value explicitly if it exists
                        if (dgv.Rows.Cast<DataGridViewRow>().Any(row => string.IsNullOrEmpty(row.Cells[column.Index].Value?.ToString())))
                        {
                            uniqueValues.Add(string.Empty);
                        }

                    }

                    //uniqueValues = uniqueValues.Distinct().ToList();
                    checkedItems = new List<(string Item, bool IsChecked)>();
                    foreach (var value in uniqueValues)
                    {
                        clbFilterOptions.Items.Add(value, true);
                        checkedItems.Add((value, true));
                    }
                    var key = (dgv.Name, column.HeaderText);
                    columnCheckedItems[key] = checkedItems;
                }
            }
        }


        // Process the directories to find the metadata.xml file
        private async void FindMetadataFile()
        {
            // Flag to track if the file was found
            var fileFound = false;
            // Get files from allowed directories
            var files = new List<string>();

            try
            {
                fileFound = await Task.Run(() => ProcessingAppDirectories(_cancellationTokenSource.Token, files));
            }
            catch (OperationCanceledException)
            {
                _cancellationTokenSource.Cancel();
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
                try
                {
                    await Task.Run(() =>
                    {
                        GetGamesFromMetadata(_cancellationTokenSource.Token);
                    });
                }
                catch (OperationCanceledException)
                {
                    _cancellationTokenSource.Cancel();
                }
            }
            else
            {
                DebugTxt($"metadata File Not Found! Path: {metadataFilePath}");
                pbSpinner.Visible = false;
                pbMetadataLoading.Visible = false;
                UpdateStatus("error", "metadata File Not Found!");
                DebugTxt(true);
            }
        }

        private async Task<bool> ProcessingAppDirectories(CancellationToken token, List<string> files)
        {
            var fileFound = false;
            // Check for cancellation
            if (token.IsCancellationRequested)
            {
                token.ThrowIfCancellationRequested();
                return false;
            }

            try
            {
                DebugTxt("->Looking for Metadata...");
                string currentFolder = AppDomain.CurrentDomain.BaseDirectory;
                string launchboxRootFolder = currentFolder.Replace("\\Core", ""); // Remove the "\Core" part
                metadataFilePath = Path.Combine(launchboxRootFolder, "Metadata", "metadata.xml");
                DebugTxt($"Looking for Metadata at {metadataFilePath}...");
                fileFound = await Task.Run(() =>
                {
                    return File.Exists(metadataFilePath);
                });
                if (fileFound)
                {
                    DebugTxt($"Metadata found at {metadataFilePath}!");
                    return true;
                }
                else
                {
                    DebugTxt($"Metadata not found at {metadataFilePath}...");
                    metadataFilePath = string.Empty;
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

                    fileFound = await Task.Run(() => {
                        foreach (string dir in allDirectories)
                        {
                            // Get all files from the current directory in a case-insensitive manner
                            files.AddRange(Directory.GetFiles(dir, "*", SearchOption.TopDirectoryOnly)
                                .Where(f => Path.GetFileName(f).Equals(metadataFile, StringComparison.OrdinalIgnoreCase))
                            );

                            // Break if we found the metadata file
                            if (files.Count > 0)
                            {
                                return true;
                            }
                        }
                        return false;
                    });
                }
                return true;
            }
            catch (Exception ex)
            {
                DebugTxt($"An Exception occured: {ex.Message}");
                return false;
            }
        }

        // Get the platform games from the metadata.xml file
        private async void GetGamesFromMetadata(CancellationToken token)
        {
            // Check for cancellation
            if (token.IsCancellationRequested)
            {
                token.ThrowIfCancellationRequested();
            }
            bool xmlReadCompleted = false;
            // Debugging
            int gameCount = 0;
            int platformCount = 0;
            int GameAltNamesCount = 0;
            int processedGamesCounter = 0;
            int processedAltNamesCounter = 0;

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
                                                new IAlternateName[0],
                                                ParseInt((string)xmlElement.Element("MaxPlayers")),
                                                ParseInt((string)xmlElement.Element("DatabaseID")),
                                                (string)xmlElement.Element("VideoURL"),
                                                (string)xmlElement.Element("WikipediaURL")
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
                    DebugTxt("Adding alt names to game data");
                    var altNamesDict = xmlGameAltNames
                        .Where(altName => !string.IsNullOrEmpty(altName.GameId))
                        .GroupBy(altName => altName.GameId)
                        .ToDictionary(g => g.Key, g => g.ToList());
                    DebugTxt($"altNameDict contains {altNamesDict.Count} entries.");
                    await Task.Run(() =>
                    {
                        foreach (var game in xmlGames)
                        {
                            if (game.LaunchBoxDbId.HasValue)
                            {
                                // Check if we have alternate names for this game using the dictionary
                                if (altNamesDict.TryGetValue(game.LaunchBoxDbId.ToString(), out var matchingAltNames))
                                {
                                    // Use StringBuilder for building the region string
                                    var regionBuilder = new StringBuilder(game.Region);
                                    game.AlternateNames = new IAlternateName[matchingAltNames.Count];
                                    Array.Copy(matchingAltNames.ToArray(), game.AlternateNames, matchingAltNames.Count);
                                    foreach (var altName in matchingAltNames)
                                    {
                                        if (!string.IsNullOrWhiteSpace(altName.Region) &&
                                            !game.Region.Contains(altName.Region) &&
                                            !regionBuilder.ToString().Contains(altName.Region))
                                        {
                                            if (regionBuilder.Length > 0 || game.Region.Length > 0)
                                            {
                                                regionBuilder.Append(", ");
                                            }
                                            regionBuilder.Append(altName.Region);
                                        }
                                    }
                                    game.Region = regionBuilder.ToString();
                                    processedAltNamesCounter++;
                                }
                                processedGamesCounter++;
                            }
                        }
                    });

                    DebugTxt($"Processed: {processedGamesCounter} metadata games!");
                    DebugTxt($"Processed: {processedAltNamesCounter} AltGameNames!");
                    UpdateStatus("success");
                    StopProgressBar();
                    Invoke(new Action(() =>
                    {
                        pbSpinner.Visible = false;
                        confirmButton.Enabled = true;
                    }));

                }
                else
                {
                    UpdateStatus("error");
                    DebugTxt(true);
                }
                DebugTxt("Ended processing games");
                StopProgressBar();
                Invoke(new Action(() =>
                {
                    pbSpinner.Visible = false;
                    confirmButton.Enabled = true;
                }));
            }
        }
        #endregion

        #region HelperMethods
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

        // GridView column sort method
        private BindingList<GameDisplayData> SortGames(BindingList<GameDisplayData> games, string columnName, DataGridView dgv)
        {
            DebugTxt("Determining which gridview to sort...");
            var ascending = dgv.Name.Equals("ownedGamesGridView") ? ascendingOwnedGames : ascendingMissingGames;
            DebugTxt("Sorting list...");
            List<GameDisplayData> sortedList;
            if (columnName == "LaunchBoxDbId" || columnName == "MaxPlayers" || columnName == "CommunityStarRatingTotalVotes")
            {
                // Special case for numeric columns to sort by numeric value
                sortedList = ascending
                    ? games.OrderBy(x => int.TryParse(x.GetType().GetProperty(columnName).GetValue(x, null)?.ToString(), out int num) ? num : int.MaxValue).ToList()
                    : games.OrderByDescending(x => int.TryParse(x.GetType().GetProperty(columnName).GetValue(x, null)?.ToString(), out int num) ? num : int.MinValue).ToList();
            }
            else if (columnName == "ReleaseDate")
            {
                // Special case for ReleaseDate to sort by date value
                sortedList = ascending
                    ? games.OrderBy(x => DateTime.TryParse(x.ReleaseDate, out DateTime date) ? date : DateTime.MaxValue).ToList()
                    : games.OrderByDescending(x => DateTime.TryParse(x.ReleaseDate, out DateTime date) ? date : DateTime.MinValue).ToList();
            }
            else if (columnName == "CommunityStarRating")
            {
                // Special case for CommunityStarRating to sort by float value
                sortedList = ascending
                    ? games.OrderBy(x => float.TryParse(x.CommunityStarRating, out float num) ? num : float.MaxValue).ToList()
                    : games.OrderByDescending(x => float.TryParse(x.CommunityStarRating, out float num) ? num : float.MinValue).ToList();
            }
            else
            {
                // General case for other columns
                var propertyInfo = typeof(GameDisplayData).GetProperty(columnName);
                sortedList = ascending
                    ? games.OrderBy(x => propertyInfo.GetValue(x, null)).ToList()
                    : games.OrderByDescending(x => propertyInfo.GetValue(x, null)).ToList();
            }
            DebugTxt("Sorting list completed!");
            return new BindingList<GameDisplayData>(sortedList);
        }

        // Column sort toggle method
        private void ToggleSortOrder(string columnName, string gridViewName)
        {
            DebugTxt($"Toggling {gridViewName} sort order...");
            if (gridViewName == "ownedGamesGridView")
            {
                if (lastSortedColumnOwnedGames == columnName)
                {
                    ascendingOwnedGames = !ascendingOwnedGames;
                }
                else
                {
                    ascendingOwnedGames = true;
                    lastSortedColumnOwnedGames = columnName;
                }
            }
            else if (gridViewName == "missingGamesGridView")
            {
                if (lastSortedColumnMissingGames == columnName)
                {
                    ascendingMissingGames = !ascendingMissingGames;
                }
                else
                {
                    ascendingMissingGames = true;
                    lastSortedColumnMissingGames = columnName;
                }
            }
            DebugTxt($"Toggling {gridViewName} sort order completed!");
        }

        // Column filtering
        private void AddFilterIcons()
        {
            foreach (DataGridViewColumn column in ownedGamesGridView.Columns)
            {
                if (column.HeaderText == "Developer" || column.HeaderText == "Publisher" || column.HeaderText == "Region" || column.HeaderText == "CommunityStarRating" || column.HeaderText == "Genres")
                {
                    column.HeaderCell = new DataGridViewFilterHeaderCell(column.HeaderCell, ownedGamesGridView, missingGamesGridView, clbFilterOptions, gbFilterOptions, this);
                }
            }

            foreach (DataGridViewColumn column in missingGamesGridView.Columns)
            {
                if (column.HeaderText == "Developer" || column.HeaderText == "Publisher" || column.HeaderText == "Region" || column.HeaderText == "CommunityStarRating" || column.HeaderText == "Genres")
                {
                    column.HeaderCell = new DataGridViewFilterHeaderCell(column.HeaderCell, ownedGamesGridView, missingGamesGridView, clbFilterOptions, gbFilterOptions, this);
                }
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

        // Column toggler helper
        private void UpdateColumnVisibility()
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new Action(UpdateColumnVisibility), new object[] { });
                return;
            }
            try
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
            catch (Exception ex)
            {
                LogException(ex);
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
                pDebugLog.BringToFront();
                pDebugLog.Visible = true;
            }
            else
            {
                pDebugLog.Visible = false;
            }
        }

        // Log exceptions to the debug textbox
        private void LogException(Exception ex)
        {
            var stackTrace = new System.Diagnostics.StackTrace(ex, true);
            var frame = stackTrace.GetFrame(0);
            var lineNumber = frame.GetFileLineNumber();
            var fileName = frame.GetFileName();
            var method = frame.GetMethod();

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Exception: " + ex.Message);
            sb.AppendLine("File: " + fileName);
            sb.AppendLine("Method: " + method.Name);
            sb.AppendLine("Line: " + lineNumber);
            sb.AppendLine("Stack Trace: " + ex.StackTrace);
            if (ex.InnerException != null)
            {
                sb.AppendLine("Inner Exception: " + ex.InnerException.Message);
                sb.AppendLine("Inner Stack Trace: " + ex.InnerException.StackTrace);
            }
            DebugTxt(sb.ToString());
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
            }
        }
        #endregion
    }
}
