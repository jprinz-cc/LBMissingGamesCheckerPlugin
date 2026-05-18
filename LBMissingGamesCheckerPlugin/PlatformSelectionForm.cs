using LBMissingGamesCheckerPlugin.Controls;
using LBMissingGamesCheckerPlugin.Models;
using System.Collections.Concurrent;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using Unbroken.LaunchBox.Plugins;
using Unbroken.LaunchBox.Plugins.Data;

namespace LBMissingGamesCheckerPlugin
{
    public partial class PlatformSelectionForm : Form
    {
        #region AppProperties
        // Holds the currently selected platform
        public IPlatform SelectedPlatform { get; private set; }

        // Lists to hold sorted games
        private ConcurrentBag<IGame> ownedGames = new ConcurrentBag<IGame>();
        private ConcurrentBag<MetadataDbGame> missingGames = new ConcurrentBag<MetadataDbGame>();

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
        public readonly Dictionary<(string GridViewName, string ColumnHeaderText), List<(string Item, bool IsChecked)>> ColumnCheckedItems = new Dictionary<(string, string), List<(string, bool)>>();
        public DataGridView CurrentGridView;
        public DataGridViewColumn CurrentColumn;
        private BindingList<GameDisplayData> OriginalOwnedGameList;
        private BindingList<GameDisplayData> OriginalMissingGameList;
        private List<GameDisplayData> FilteredOwnedGameList = new List<GameDisplayData>();
        private List<GameDisplayData> FilteredMissingGameList = new List<GameDisplayData>();

        // Graceful exit token
        private readonly CancellationTokenSource _CancellationTokenSource = new CancellationTokenSource();
        #endregion

        #region FormInit
        public PlatformSelectionForm(IList<IPlatform> platforms)
        {
            InitializeComponent();

            this.Load += new EventHandler(this.PlatformSelectionForm_Load);
            this.Shown += new EventHandler(this.PlatformSelectionForm_Shown);
            this.Paint += new PaintEventHandler(this.PlatformSelectionForm_Paint);
            this.Resize += new EventHandler(this.PlatformSelectionForm_Resize);
            this.FormClosing += new FormClosingEventHandler(this.PlatformSelectionForm_FormClosing);
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
            lblCongrats.Visible = false;
            pbCongrats.Visible = false;

            DebugTxt(false);

            // Populate dropdown with user platforms
            foreach (var platform in platforms)
            {
                platformDropdown.Items.Add(platform.Name);
            }
            if (platformDropdown.Items.Count > 0) platformDropdown.SelectedIndex = 0;

            // Populate column selection checkboxes
            PopulateColumnSelection();

            // Populate Region Filter dropdown
            cmbRegionFilter.Items.AddRange(new string[] { "All Regions", "North America", "Europe", "Japan" });
            cmbRegionFilter.SelectedIndex = 0;
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
        private void PlatformSelectionForm_Shown(object sender, EventArgs e)
        {
            DebugTxt("Form Shown Event Triggered!");
            DebugTxt("Checking LaunchBox SQLite Metadata Database status...");

            var repo = new Data.MetadataRepository();
            var status = repo.CheckMetadataStatus();

            if (status == Data.MetadataStatus.SqliteFound)
            {
                DebugTxt("Status: SQLite Database Ready!");
                UpdateStatus("success", "Database Ready!");
                confirmButton.Enabled = true;
            }
            else if (status == Data.MetadataStatus.XmlFound)
            {
                DebugTxt("Status: Legacy XML Found!");
                UpdateStatus("error", "Legacy XML File Found");
                confirmButton.Enabled = false;

                MessageBox.Show(
                    "It looks like you are using an older version of LaunchBox that relies on the 'metadata.xml' file.\n\nPlease use v1.2 of the Missing Games Checker plugin, as Version 2.0+ is optimized exclusively for LaunchBox's modern SQLite database.",
                    "Legacy Metadata Found",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            else
            {
                DebugTxt("Status: Metadata Database Not Found!");
                UpdateStatus("error", "Metadata Database Not Found!");
                confirmButton.Enabled = false;
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
                ColumnCheckedItems?.Clear();
                OriginalOwnedGameList?.Clear();
                OriginalMissingGameList?.Clear();
                tbOwnedSearch.Text = string.Empty;
                tbMissingSearch.Text = string.Empty;
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

                    ssPlatformDropdownMsg.Visible = false;

                    GetAllPlatformGames(SelectedPlatform, platformToCheck);
                }
                catch (Exception ex)
                {
                    LogException(ex);
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
            if (!(sender is DataGridView gridView)) return;
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            // Use DataPropertyName for a link to the model
            string colName = gridView.Columns[e.ColumnIndex].DataPropertyName;
            if (string.IsNullOrEmpty(colName)) colName = gridView.Columns[e.ColumnIndex].Name;

            if (colName == "LaunchBoxDbId")
            {
                if (e.Value != null && !string.IsNullOrWhiteSpace(e.Value.ToString()))
                {
                    e.Value = $"LaunchBoxDB #{e.Value}";
                    e.FormattingApplied = true;
                }
                else
                {
                    e.CellStyle.BackColor = Color.FromArgb(54, 57, 63);
                }
            }
            else if (colName == "VideoUrl")
            {
                if (e.Value != null && !string.IsNullOrWhiteSpace(e.Value.ToString()))
                {
                    e.Value = "YouTube";
                    e.FormattingApplied = true;
                }
                else
                {
                    e.CellStyle.BackColor = Color.FromArgb(54, 57, 63);
                }
            }
            else if (colName == "WikipediaUrl")
            {
                if (e.Value != null && !string.IsNullOrWhiteSpace(e.Value.ToString()))
                {
                    e.Value = "Wiki";
                    e.FormattingApplied = true;
                }
                else
                {
                    e.CellStyle.BackColor = Color.FromArgb(54, 57, 63);
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

                // Use DataPropertyName to match the model property
                string colName = gridView.Columns[e.ColumnIndex].DataPropertyName;
                if (string.IsNullOrEmpty(colName)) colName = gridView.Columns[e.ColumnIndex].Name;

                // Grab the raw value from the bound data
                string rawValue = cell.Value?.ToString();

                DebugTxt($"Cell clicker underlying value: {rawValue}");

                if (string.IsNullOrWhiteSpace(rawValue))
                {
                    gridView.CurrentCell = null;
                }
                else
                {
                    try
                    {
                        string url = "";

                        // Construct the LaunchBox URL or use the raw value
                        if (colName == "LaunchBoxDbId")
                        {
                            url = $"https://gamesdb.launchbox-app.com/games/dbid/{rawValue.Trim()}";
                        }
                        else
                        {
                            url = rawValue.Trim();
                        }

                        DebugTxt($"Opening URL: {url}");
                        Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
                    }
                    catch (Exception ex)
                    {
                        LogException(ex);
                        MessageBox.Show($"An error occurred while opening the link: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            if (CurrentGridView != null && CurrentColumn != null)
            {
                CurrentGridView.SuspendLayout();

                var gameList = CurrentGridView.Name == "ownedGamesGridView" ? OriginalOwnedGameList : OriginalMissingGameList;

                if (gameList == null)
                {
                    DebugTxt("Game lists are null, unable to filter.");
                    gbFilterOptions.Visible = false;
                    return;
                }

                // Update the Dictionary state for the current column from the checkboxes
                var currentKey = (CurrentGridView.Name, CurrentColumn.HeaderText);
                if (ColumnCheckedItems.ContainsKey(currentKey))
                {
                    var checkedItems = ColumnCheckedItems[currentKey];
                    for (int i = 0; i < clbFilterOptions.Items.Count; i++)
                    {
                        string itemText = clbFilterOptions.Items[i].ToString();
                        bool isChecked = clbFilterOptions.GetItemChecked(i);

                        var index = checkedItems.FindIndex(x => x.Item == itemText);
                        if (index >= 0)
                        {
                            checkedItems[index] = (itemText, isChecked);
                        }
                    }
                }

                // Start with the full OG list
                var workingList = gameList.ToList();

                // Apply filters from ALL columns for this grid
                var gridFilters = ColumnCheckedItems.Where(kvp => kvp.Key.GridViewName == CurrentGridView.Name).ToList();

                foreach (var filterColumn in gridFilters)
                {
                    string colHeader = filterColumn.Key.ColumnHeaderText;
                    var checkedValues = filterColumn.Value.Where(x => x.IsChecked).Select(x => x.Item).ToList();
                    var allValuesCount = filterColumn.Value.Count;

                    // If everything is checked in this column, skip filtering it
                    if (checkedValues.Count == allValuesCount || allValuesCount == 0) continue;

                    // Otherwise, filter the working list down
                    if (colHeader == "Genres")
                    {
                        workingList = workingList.Where(game =>
                        {
                            var genres = game.Genres?.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries).Select(g => g.Trim()).ToList() ?? new List<string>();
                            if (!genres.Any() && checkedValues.Contains(string.Empty)) return true;
                            return genres.Any(g => checkedValues.Contains(g));
                        }).ToList();
                    }
                    else if (colHeader == "Region")
                    {
                        workingList = workingList.Where(game =>
                        {
                            var regions = game.Region?.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(r => r.Trim()).ToList() ?? new List<string>();
                            if (!regions.Any() && checkedValues.Contains(string.Empty)) return true;
                            return regions.Any(r => checkedValues.Contains(r));
                        }).ToList();
                    }
                    else if (colHeader == "CommunityStarRating")
                    {
                        workingList = workingList.Where(game =>
                        {
                            var rating = float.TryParse(game.CommunityStarRating, out float parsedRating) ? parsedRating : 0f;
                            foreach (var val in checkedValues)
                            {
                                var bucket = val.Split('-');
                                if (bucket.Length == 2 && float.TryParse(bucket[0], out float min) && float.TryParse(bucket[1], out float max))
                                {
                                    if (rating >= min && rating < max) return true;
                                }
                            }
                            return false;
                        }).ToList();
                    }
                    else
                    {
                        // Generic property match using DataPropertyName
                        string dataPropName = CurrentGridView.Columns.Cast<DataGridViewColumn>().FirstOrDefault(c => c.HeaderText == colHeader)?.DataPropertyName ?? colHeader;
                        var propInfo = typeof(GameDisplayData).GetProperty(dataPropName);

                        if (propInfo != null)
                        {
                            workingList = workingList.Where(game =>
                            {
                                var propertyValue = propInfo.GetValue(game, null)?.ToString() ?? string.Empty;
                                return checkedValues.Contains(propertyValue);
                            }).ToList();
                        }
                    }
                }

                // Bing the final filtered list
                var finalFilteredList = workingList.Distinct().ToList();

                if (CurrentGridView.Name == "ownedGamesGridView")
                {
                    ownedGamesBindingSource.DataSource = new BindingList<GameDisplayData>(finalFilteredList);
                    lblOwnedGamesCount.Text = finalFilteredList.Count.ToString();
                    FilteredOwnedGameList = finalFilteredList;
                }
                else if (CurrentGridView.Name == "missingGamesGridView")
                {
                    missingGamesBindingSource.DataSource = new BindingList<GameDisplayData>(finalFilteredList);
                    lblMissingGamesCount.Text = finalFilteredList.Count.ToString();
                    FilteredMissingGameList = finalFilteredList;
                }

                CurrentGridView.Refresh();
                CurrentGridView.ResumeLayout();

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

            // Verify all items in the UI checklist
            for (int i = 0; i < clbFilterOptions.Items.Count; i++)
            {
                clbFilterOptions.SetItemChecked(i, true);
            }

            // Call ApplyFilters logic so it processes the reset 
            ApplyFilters_Click(sender, e);
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

        // Filter Select All handler
        private void chkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            bool checkState = chkSelectAll.Checked;

            for (int i = 0; i < clbFilterOptions.Items.Count; i++)
            {
                clbFilterOptions.SetItemChecked(i, checkState);
            }
        }

        public void UpdateSelectAllState()
        {
            // Temporarily unplug the event so changing the checkbox doesn't trigger loop
            chkSelectAll.CheckedChanged -= chkSelectAll_CheckedChanged;

            // Loop through and check if even a single item is unchecked
            bool allChecked = true;
            for (int i = 0; i < clbFilterOptions.Items.Count; i++)
            {
                if (!clbFilterOptions.GetItemChecked(i))
                {
                    allChecked = false;
                    break;
                }
            }

            // Set the master checkbox state (and ensure it doesn't check if the list is empty)
            chkSelectAll.Checked = (clbFilterOptions.Items.Count > 0 && allChecked);

            // Plug the event back in
            chkSelectAll.CheckedChanged += chkSelectAll_CheckedChanged;
        }

        // Export to CSV handler for OwnedGames
        private void ExportOwnedGamesButton_Click(object sender, EventArgs e)
        {
            // Show the export dropdown menu right under the button
            cmsOwnedExportOptions.Show(btnOwnedExportOptions, new Point(0, btnOwnedExportOptions.Height));
        }

        // Export to CSV handler for MissingGames
        private void ExportMissingGamesButton_Click(object sender, EventArgs e)
        {
            cmsMissingExportOptions.Show(btnMissingExportOptions, new Point(0, btnMissingExportOptions.Height));
        }

        // Export MissingGames to LaunchBox Playlist
        private void createLaunchBoxWishlistPlaylistToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SelectedPlatform == null || OriginalMissingGameList == null || OriginalMissingGameList.Count == 0)
            {
                MessageBox.Show("There are no missing games to export for this platform.", "Export Interrupted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                DebugTxt($"Starting LaunchBox Wishlist creation for {SelectedPlatform.Name}...");

                string shadowPlatformName = $"{SelectedPlatform.Name} Wishlists";
                string pluginVersion = Assembly.GetExecutingAssembly().GetName().Version?.ToString() ?? "2.0.0.0";

                // Explicitly handle the Shadow Platform
                var shadowPlatform = PluginHelper.DataManager.GetPlatformByName(shadowPlatformName);

                if (shadowPlatform != null)
                {
                    // The platform exists. Prompt the user to overwrite!
                    var result = MessageBox.Show(
                        $"A wishlist platform named '{shadowPlatformName}' already exists.\n\nWould you like to overwrite it with a fresh list?\n\n(Selecting 'No' will cancel the export).",
                        "Wishlist Exists",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    );

                    if (result == DialogResult.Yes)
                    {
                        DebugTxt($"Clearing old placeholder games from {shadowPlatformName}...");

                        // Find all existing games in this specific shadow platform and delete them
                        var oldGames = PluginHelper.DataManager.GetAllGames().Where(g => g.Platform == shadowPlatformName).ToList();
                        foreach (var oldGame in oldGames)
                        {
                            PluginHelper.DataManager.TryRemoveGame(oldGame);
                        }
                    }
                    else
                    {
                        // User clicked No, abort the export gracefully
                        return;
                    }
                }
                else
                {
                    // It doesn't exist yet, create it natively
                    shadowPlatform = PluginHelper.DataManager.AddNewPlatform(shadowPlatformName);

                    // Assign ScrapeAs to the PLATFORM so the user can download game media and metadata
                    shadowPlatform.ScrapeAs = SelectedPlatform.Name;
                    shadowPlatform.Notes = $"Automated Platform Wishlist generated by Missing Games Checker v{pluginVersion} on {DateTime.Now.ToShortDateString()}.";
                }

                // Create Placeholder Games
                int addedCount = 0;
                foreach (var missingGame in OriginalMissingGameList)
                {
                    // Skip structural row markers like "NoPlatformFound"
                    if (missingGame.Title == "NoPlatformFound" || missingGame.Title.StartsWith("==")) continue;

                    // Create the physical game
                    var newGame = PluginHelper.DataManager.AddNewGame(missingGame.Title);

                    // Assign it to isolated shadow platform
                    newGame.Platform = shadowPlatformName;
                    newGame.Source = "Missing Games Checker";
                    newGame.Notes = $"Automated '{shadowPlatformName}' Game generated by Missing Games Checker v{pluginVersion} on {DateTime.Now.ToShortDateString()}.";

                    // Safely parse the Database ID
                    if (!string.IsNullOrWhiteSpace(missingGame.LaunchBoxDbId) && int.TryParse(missingGame.LaunchBoxDbId.ToString(), out int parsedDbId))
                    {
                        newGame.LaunchBoxDbId = parsedDbId;
                    }

                    // Mark as unplayed Wishlist item
                    newGame.Status = "Wishlist";
                    newGame.Progress = "Not Started / Want to Play";

                    addedCount++;
                }

                // Save to disk
                PluginHelper.DataManager.Save();

                DebugTxt($"Wishlist successfully committed with {addedCount} placeholder games.");

                MessageBox.Show($"Successfully added {addedCount} placeholder games to LaunchBox!\n\nThey have been safely isolated in a new platform called\n\n'{shadowPlatformName}' in your sidebar.", "Export Successful!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                LogException(ex);
                MessageBox.Show($"An error occurred while communicating with the LaunchBox API: {ex.Message}", "API Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            // Ensure that text is selected in the text box
            tbDebug.SelectAll();
            if (tbDebug.SelectionLength > 0)
            {
                // Copy Debug Log text to the Clipboard
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
            // Ensure that text is selected in the text box
            if (tbDebug.Text.Length > 0)
            {
                // Copy the selected text to the Clipboard
                tbDebug.Clear();
                StringBuilder sb = new StringBuilder(tbDebug.Text);
                sb.AppendLine("Debug");
                sb.AppendLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")); // Add the current date/time
                tbDebug.Text = sb.ToString();
            }
        }

        private void PlatformSelectionForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _CancellationTokenSource.Cancel();
        }

        private void CloseFilter_Click(object sender, EventArgs e)
        {
            DebugTxt("Closing Filter Options Panel!");
            gbFilterOptions.Visible = false;
        }

        private void OnApplicationExit(object sender, EventArgs e)
        {
            _CancellationTokenSource.Cancel();
        }
        #endregion

        #region MainMethods
        private async void GetAllPlatformGames(IPlatform selectedPlatform, string platformToCheck)
        {
            // Disable form btns and reset for new load
            Invoke((Action)(() =>
            {
                confirmButton.Enabled = false;
                clbColumnSelection.Enabled = false;
                btnOwnedExportOptions.Enabled = false;
                btnMissingExportOptions.Enabled = false;
                lblOwnedGamesCount.Text = "0";
                lblMissingGamesCount.Text = "0";
            }));

            DebugTxt("Starting GetAllPlatformGames via SQLite...");
            HashSet<int> ownedGameIds = new HashSet<int>();

            // Capture UI state on the main thread before background tasks
            bool filterReleasedOnly = chkReleasedOnly.Checked;
            string selectedRegion = cmbRegionFilter.SelectedItem?.ToString() ?? "All Regions";
            bool includeEmptyRegions = chkIncludeEmptyRegions.Checked;

            if (selectedPlatform == null)
            {
                DebugTxt("selectedPlatform is null.");
                return;
            }

            try
            {
                DebugTxt($"Filter by Released: {filterReleasedOnly} | Region: {selectedRegion} | Include Empty: {includeEmptyRegions}");

                // Clear lists of populated data
                ownedGames = new ConcurrentBag<IGame>();
                missingGames = new ConcurrentBag<MetadataDbGame>();

                DebugTxt("Fetching Owned Games from LaunchBox API...");
                var ownedGamesList = await Task.Run(() => selectedPlatform.GetAllGames(true, true));

                if (ownedGamesList != null)
                {
                    await Task.Run(() =>
                    {
                        foreach (var game in ownedGamesList)
                        {
                            // ALWAYS add to the exclusion list IF IT HAS AN ID 
                            if (game.LaunchBoxDbId.HasValue && game.LaunchBoxDbId != 0)
                            {
                                ownedGameIds.Add(game.LaunchBoxDbId.Value);
                            }

                            // Process EVERYTHING for the visual Owned grid (even unscraped games)

                            // Check Released filter
                            bool passesReleased = !filterReleasedOnly || game.ReleaseType == "Released";

                            // Evaluate Region Logic cleanly
                            bool passesRegion;
                            if (string.IsNullOrWhiteSpace(game.Region))
                            {
                                // The game has NO region. Only pass it if the user checked the safety net box!
                                passesRegion = includeEmptyRegions;
                            }
                            else
                            {
                                // The game HAS a region. Pass it if they want "All", or if it matches their specific choice.
                                passesRegion = (selectedRegion == "All Regions") || game.Region.Contains(selectedRegion, StringComparison.OrdinalIgnoreCase);
                            }

                            // Only add to the visual display list if it passes both optional filters
                            if (passesReleased && passesRegion)
                            {
                                ownedGames.Add(game);
                            }
                        }
                    });
                }
                DebugTxt($"ownedGames Count (Filtered): {ownedGames.Count}");

                DebugTxt("Fetching Platform Games from SQLite DB...");
                var repo = new Data.MetadataRepository();
                var platformGames = await repo.GetGamesForPlatformAsync(platformToCheck);

                if (platformGames.Count > 0)
                {
                    // Filter out games already own, and apply the 'Released' and 'Region' filters
                    var filteredMissing = await Task.Run(() =>
                    {
                        return platformGames
                            .Where(dbGame => dbGame.LaunchBoxDbId.HasValue && !ownedGameIds.Contains(dbGame.LaunchBoxDbId.Value))
                            .Where(dbGame => !filterReleasedOnly || dbGame.ReleaseType == "Released")
                            .Where(dbGame =>
                                string.IsNullOrWhiteSpace(dbGame.Region)
                                    ? includeEmptyRegions
                                    : (selectedRegion == "All Regions" || dbGame.Region.Contains(selectedRegion, StringComparison.OrdinalIgnoreCase))
                            )
                            .ToList();
                    });

                    missingGames = new ConcurrentBag<MetadataDbGame>(filteredMissing);
                    DebugTxt($"missingGames Count (Filtered): {missingGames.Count}");
                }
                else
                {
                    // Add final "NoPlatformFound" message row
                    DebugTxt("Adding error to missingGames List...");
                    var noPlatformErrorList = new List<MetadataDbGame>
            {
                new MetadataDbGame("NoPlatformFound", string.Empty, string.Empty, string.Empty, null, null, null,
                    $"The selected platform '{platformToCheck}' was not found in the LaunchBox DB.", string.Empty, string.Empty, null, null, 0, string.Empty, string.Empty),
                new MetadataDbGame("=====================", string.Empty, string.Empty, string.Empty, null, null, null,
                    "=====================", string.Empty, string.Empty, null, null, 0, string.Empty, string.Empty)
            };

                    missingGames = new ConcurrentBag<MetadataDbGame>(noPlatformErrorList);
                    DebugTxt($"ownedGames: {ownedGames.Count} - missingGames: NoPlatformFound");
                }

                DebugTxt("Populating Game Lists!");
                PopulateGameList(ownedGames, missingGames);
            }
            catch (Exception ex)
            {
                LogException(ex);
                Invoke((Action)(() => confirmButton.Enabled = true));
            }
        }

        // Populate the GridViews with the game lists
        private async void PopulateGameList(ConcurrentBag<IGame> ownedGames, ConcurrentBag<MetadataDbGame> missingGames)
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
                    FilteredOwnedGameList.Clear();
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
                FilteredOwnedGameList.Clear();
                DebugTxt("Clearing data containers completed!");
            }

            try
            {
                DebugTxt("Loading ownedGamesDisplayData...");
                var ownedGamesList = await Task.Run(() =>
                {
                    return ownedGames.OrderBy(game => game.Title)
                    .Select(game => new GameDisplayData(new MetadataDbGame(
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
                            OriginalOwnedGameList = ownedGamesDisplayData;
                            lblOwnedGamesCount.Text = ownedGamesDisplayData.Count > 0 ? ownedGamesDisplayData.Count.ToString() : "0";
                            btnOwnedExportOptions.Enabled = true;
                            LoadFilterOptions(ownedGamesGridView);
                        }));
                    }
                    else
                    {
                        DebugTxt($"Binding ownedGamesBindingSource with {ownedGamesDisplayData.Count} ownedGamesDisplayData elements...");
                        ownedGamesBindingSource.DataSource = ownedGamesDisplayData;
                        OriginalOwnedGameList = ownedGamesDisplayData;
                        lblOwnedGamesCount.Text = ownedGamesDisplayData.Count > 0 ? ownedGamesDisplayData.Count.ToString() : "0";
                        btnOwnedExportOptions.Enabled = true;
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
                                OriginalMissingGameList = missingGamesDisplayData;
                                LoadFilterOptions(missingGamesGridView);
                            }));
                        }
                        else
                        {
                            DebugTxt($"Binding missingGamesBindingSource with {missingGamesDisplayData.Count} missingGamesDisplayData elements...");
                            missingGamesGridView.Visible = true;
                            noPlatformGridView.Visible = false;
                            missingGamesBindingSource.DataSource = missingGamesDisplayData;
                            OriginalMissingGameList = missingGamesDisplayData;
                            LoadFilterOptions(missingGamesGridView);
                        }

                        if (this.InvokeRequired)
                        {
                            this.Invoke(new Action(() =>
                            {
                                lblMissingGamesCount.Text = missingGamesDisplayData.Count.ToString();
                                btnMissingExportOptions.Enabled = true;
                                DebugTxt($"missingGames.Count: {missingGamesDisplayData.Count}");
                                lblCongrats.Visible = false;
                                pbCongrats.Visible = false;
                            }));
                        }
                        else
                        {
                            lblMissingGamesCount.Text = missingGamesDisplayData.Count.ToString();
                            btnMissingExportOptions.Enabled = true;
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
                                DebugTxt("There are no Missing Games! Congrats!");
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
                // Calculate Completion Statistics
                if (OriginalOwnedGameList != null && OriginalMissingGameList != null)
                {
                    DebugTxt("Calculating Completion Statistics...");
                    int ownedCount = OriginalOwnedGameList.Count;
                    int missingCount = OriginalMissingGameList.Count;
                    int totalGames = ownedCount + missingCount;

                    if (totalGames > 0)
                    {
                        double percentage = Math.Round((double)ownedCount / totalGames * 100, 1);
                        lblCompletionStats.Text = $"Platform Completion: {percentage}% ({ownedCount} / {totalGames} Games)";

                        // Color coding based on Completion Percentage
                        if (percentage >= 80)
                        {
                            // 80%+ Complete (Very few missing) -> Green
                            lblCompletionStats.ForeColor = Color.LightGreen;
                        }
                        else if (percentage >= 30)
                        {
                            // 30% to 79% Complete -> Yellow
                            lblCompletionStats.ForeColor = Color.Gold;
                        }
                        else
                        {
                            // 0% to 29% Complete (Mostly missing) -> Red
                            lblCompletionStats.ForeColor = Color.LightCoral;
                        }

                        lblCompletionStats.Visible = true;
                    }
                    DebugTxt("Calculated Completion Statistics!");
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
                    column.HeaderText == "CommunityStarRating" || column.HeaderText == "ReleaseType" || column.HeaderText == "Genres" || column.HeaderText == "MaxPlayers")
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

                    checkedItems = new List<(string Item, bool IsChecked)>();
                    foreach (var value in uniqueValues)
                    {
                        clbFilterOptions.Items.Add(value, true);
                        checkedItems.Add((value, true));
                    }
                    var key = (dgv.Name, column.HeaderText);
                    ColumnCheckedItems[key] = checkedItems;
                }
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
                if (column.HeaderText == "Developer" || column.HeaderText == "Publisher" || column.HeaderText == "Region" || column.HeaderText == "CommunityStarRating" || column.HeaderText == "ReleaseType" || column.HeaderText == "Genres" || column.HeaderText == "MaxPlayers")
                {
                    column.HeaderCell = new DataGridViewFilterHeaderCell(column.HeaderCell, ownedGamesGridView, missingGamesGridView, clbFilterOptions, gbFilterOptions, this);
                }
            }

            foreach (DataGridViewColumn column in missingGamesGridView.Columns)
            {
                if (column.HeaderText == "Developer" || column.HeaderText == "Publisher" || column.HeaderText == "Region" || column.HeaderText == "CommunityStarRating" || column.HeaderText == "ReleaseType" || column.HeaderText == "Genres" || column.HeaderText == "MaxPlayers")
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
                    tsslText.Text = message ?? "Metadata Load Failed";
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
                this.Invoke((System.Windows.Forms.MethodInvoker)delegate
                {
                    ReleaseCapture();
                    SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
                });
            }
        }

        // Grid Search Handlers
        private void tbOwnedSearch_TextChanged(object sender, EventArgs e)
        {
            // Suspend layout for performance
            ownedGamesGridView.SuspendLayout();

            string query = tbOwnedSearch.Text.Trim().ToLower();

            // If search is empty, restore the original list
            if (string.IsNullOrWhiteSpace(query))
            {
                ownedGamesBindingSource.DataSource = OriginalOwnedGameList;
                lblOwnedGamesCount.Text = OriginalOwnedGameList?.Count.ToString() ?? "0";
            }
            else
            {
                // Smart Global Search: Filter across key text columns
                var searchResults = OriginalOwnedGameList
                    .Where(g =>
                        (g.Title != null && g.Title.ToLower().Contains(query)) ||
                        (g.Developer != null && g.Developer.ToLower().Contains(query)) ||
                        (g.Publisher != null && g.Publisher.ToLower().Contains(query)) ||
                        (g.Region != null && g.Region.ToLower().Contains(query)) ||
                        (g.Genres != null && g.Genres.ToLower().Contains(query)) ||
                        (g.ReleaseDate != null && g.ReleaseDate.ToLower().Contains(query))
                    )
                    .ToList();

                ownedGamesBindingSource.DataSource = new BindingList<GameDisplayData>(searchResults);
                lblOwnedGamesCount.Text = searchResults.Count.ToString();
            }

            ownedGamesGridView.ResumeLayout();
        }

        private void tbMissingSearch_TextChanged(object sender, EventArgs e)
        {
            // Suspend layout for performance
            missingGamesGridView.SuspendLayout();

            string query = tbMissingSearch.Text.Trim().ToLower();

            // If search is empty, restore the original list
            if (string.IsNullOrWhiteSpace(query))
            {
                missingGamesBindingSource.DataSource = OriginalMissingGameList;
                lblMissingGamesCount.Text = OriginalMissingGameList?.Count.ToString() ?? "0";
            }
            else
            {
                // Smart Global Search: Filter across key text columns
                var searchResults = OriginalMissingGameList
                    .Where(g =>
                        (g.Title != null && g.Title.ToLower().Contains(query)) ||
                        (g.Developer != null && g.Developer.ToLower().Contains(query)) ||
                        (g.Publisher != null && g.Publisher.ToLower().Contains(query)) ||
                        (g.Region != null && g.Region.ToLower().Contains(query)) ||
                        (g.Genres != null && g.Genres.ToLower().Contains(query)) ||
                        (g.ReleaseDate != null && g.ReleaseDate.ToLower().Contains(query))
                    )
                    .ToList();

                missingGamesBindingSource.DataSource = new BindingList<GameDisplayData>(searchResults);
                lblMissingGamesCount.Text = searchResults.Count.ToString();
            }

            missingGamesGridView.ResumeLayout();
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

        // Export to CSV methods
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

        private void GridView_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (!(sender is DataGridView grid)) return;

            // Ensure Right-Click and not on the header row
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                // Select the row user right-clicked
                grid.ClearSelection();
                grid.Rows[e.RowIndex].Selected = true;

                string gameTitle = string.Empty;
                string gamePlatform = string.Empty;

                // Grab the underlying object bound to this row
                var boundItem = grid.Rows[e.RowIndex].DataBoundItem;

                if (boundItem is GameDisplayData gameData)
                {
                    gameTitle = gameData.Title;
                    gamePlatform = gameData.Platform;
                }

                if (!string.IsNullOrEmpty(gameTitle))
                {
                    // Build the context menu dynamically
                    ContextMenuStrip menu = new ContextMenuStrip();

                    // Item 1: Copy Title/Platform to Clipboard
                    menu.Items.Add("📋 Copy Title/Platform to Clipboard", null, (s, args) =>
                    {
                        Clipboard.SetText($"{gameTitle} {gamePlatform}".Trim());
                    });

                    // Item 2: Formatted Data Row Copy
                    menu.Items.Add("📝 Copy Row Data to Clipboard", null, (s, args) =>
                    {
                        var formattedValues = new List<string>();

                        foreach (DataGridViewCell cell in grid.Rows[e.RowIndex].Cells)
                        {
                            // Only include visible columns that actually have a value
                            if (cell.OwningColumn.Visible && cell.Value != null)
                            {
                                string cellValue = cell.Value.ToString();

                                if (!string.IsNullOrWhiteSpace(cellValue))
                                {
                                    // Output format -> HeaderText: Value
                                    formattedValues.Add($"{cell.OwningColumn.HeaderText}→ {cellValue}");
                                }
                            }
                        }

                        string rowData = string.Join("; ", formattedValues);

                        if (!string.IsNullOrWhiteSpace(rowData))
                        {
                            Clipboard.SetText(rowData);
                        }
                    });

                    // Item 3: Copy Row for CSV/Spreadsheet
                    menu.Items.Add("🗄️ Copy Row for CSV/Spreadsheet (Tab)", null, (s, args) =>
                    {
                        var rowValues = new List<string>();

                        // Loop through all cells in the clicked row
                        foreach (DataGridViewCell cell in grid.Rows[e.RowIndex].Cells)
                        {
                            // Only copy the data if the column is currently visible on the screen
                            if (cell.OwningColumn.Visible)
                            {
                                rowValues.Add(cell.Value?.ToString() ?? "");
                            }
                        }

                        // Join them with a tab character so it pastes perfectly into Excel
                        string rowData = string.Join("\t", rowValues);

                        if (!string.IsNullOrWhiteSpace(rowData))
                        {
                            Clipboard.SetText(rowData);
                        }
                    });

                    // Item 4: Search eBay
                    string searchTerm = $"{gameTitle} {gamePlatform}".Trim();

                    menu.Items.Add($"🌐 Search eBay for '{searchTerm}'", null, (s, args) =>
                    {
                        // Ensure spaces and symbols are URL-encoded properly
                        string encodedSearch = Uri.EscapeDataString(searchTerm);
                        string ebayUrl = $"https://www.ebay.com/sch/i.html?_nkw={encodedSearch}";

                        Process.Start(new ProcessStartInfo(ebayUrl) { UseShellExecute = true });
                    });

                    // Show the menu at the mouse cursor location
                    menu.Show(Cursor.Position);
                }
            }
        }

        private void cmsOwnedExportCSV_Click(object sender, EventArgs e)
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

        private void exportMissingGamesListToCSVToolStripMenuItem_Click(object sender, EventArgs e)
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
