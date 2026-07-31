using LBMissingGamesCheckerPlugin.Controls;
using LBMissingGamesCheckerPlugin.Models;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using Unbroken.LaunchBox.Plugins;

namespace LBMissingGamesCheckerPlugin
{
    public partial class PlatformSelectionForm : Form
    {
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

                string pluginVersion = Assembly.GetExecutingAssembly().GetName().Version?.ToString() ?? "2.1.0.0";
                string shadowPlatformName = $"{SelectedPlatform.Name} Wishlist";
                string targetCategoryName = "Wishlists";

                // Check Nesting State
                bool shouldNestUnderCategory = toggleNestedWishlistToolStripMenuItem.Checked;

                // Resolve or Create Shadow Platform
                var shadowPlatform = PluginHelper.DataManager.GetPlatformByName(shadowPlatformName);

                if (shadowPlatform != null)
                {
                    var result = MessageBox.Show(
                        $"A wishlist platform named '{shadowPlatformName}' already exists.\n\n" +
                        $"Would you like to overwrite its games with a fresh list?\n\n" +
                        $"(Selecting 'No' will cancel the export).",
                        "Wishlist Exists",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    );

                    if (result == DialogResult.Yes)
                    {
                        DebugTxt($"Clearing old placeholder games from {shadowPlatformName}...");
                        var oldGames = PluginHelper.DataManager.GetAllGames().Where(g => g.Platform == shadowPlatformName).ToList();
                        foreach (var oldGame in oldGames)
                        {
                            PluginHelper.DataManager.TryRemoveGame(oldGame);
                        }

                        DebugTxt($"Removing {shadowPlatformName} from LaunchBox...");
                        PluginHelper.DataManager.TryRemovePlatform(shadowPlatform);
                        DebugTxt($"Removed {shadowPlatformName} successfully!");
                    }
                    else
                    {
                        return;
                    }
                }

                // Re-instantiate a fresh shadow platform
                shadowPlatform = PluginHelper.DataManager.AddNewPlatform(shadowPlatformName);
                shadowPlatform.Notes = $"Automated Platform Wishlist generated by Missing Games Checker v{pluginVersion} on {DateTime.Now.ToShortDateString()}.";

                // Category Property Assignment
                if (shouldNestUnderCategory)
                {
                    var wishlistCategory = PluginHelper.DataManager.GetAllPlatformCategories()
                        .FirstOrDefault(c => c.Name.Equals(targetCategoryName, StringComparison.OrdinalIgnoreCase));

                    if (wishlistCategory == null)
                    {
                        wishlistCategory = PluginHelper.DataManager.AddNewPlatformCategory(targetCategoryName);
                        wishlistCategory.Notes = "Root category for all Missing Games Checker wishlist platforms.";

                        // Auto-install custom logo for the Wishlists category
                        EnsureWishlistCategoryIcon();

                        DebugTxt($"Created new root Platform Category '{targetCategoryName}' and added icon.");
                    }

                    shadowPlatform.Category = targetCategoryName;
                    DebugTxt($"Set '{shadowPlatformName}' Category property to '{targetCategoryName}'.");
                }
                else
                {
                    shadowPlatform.ScrapeAs = SelectedPlatform.Name;

                    if (shadowPlatform.Category != string.Empty)
                    {
                        DebugTxt($"Set '{shadowPlatformName}' Category property to '{shadowPlatform.Category}' hardware category.");
                    }
                    else
                    {
                        DebugTxt($"Cleared Category property for '{shadowPlatformName}'; (No default category found).");
                    }
                }

                // Create Placeholder Games
                int addedCount = 0;
                foreach (var missingGame in OriginalMissingGameList)
                {
                    if (missingGame.Title == "NoPlatformFound" || missingGame.Title.StartsWith("==")) continue;

                    var newGame = PluginHelper.DataManager.AddNewGame(missingGame.Title);
                    newGame.Platform = shadowPlatformName;
                    newGame.Source = "Missing Games Checker";
                    newGame.Notes = $"Automated '{shadowPlatformName}' Game generated by Missing Games Checker v{pluginVersion} on {DateTime.Now.ToShortDateString()}.";

                    if (!string.IsNullOrWhiteSpace(missingGame.LaunchBoxDbId) && int.TryParse(missingGame.LaunchBoxDbId.ToString(), out int parsedDbId))
                    {
                        newGame.LaunchBoxDbId = parsedDbId;
                    }

                    newGame.Status = "Wishlist";
                    newGame.Progress = "Not Started / Want to Play";

                    addedCount++;
                }

                // Commit to disk
                PluginHelper.DataManager.Save();

                DebugTxt($"Wishlist successfully committed with {addedCount} placeholder games.");

                string locationText = shouldNestUnderCategory
                    ? $"nested under the '{targetCategoryName}' Category."
                    : $"under the '{shadowPlatform.Category}' Category.";

                MessageBox.Show(
                    $"Successfully added {addedCount} placeholder games to LaunchBox!\n\n" +
                    $"They have been saved to '{shadowPlatformName}' {locationText}",
                    "Export Successful!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            catch (Exception ex)
            {
                LogException(ex);
                MessageBox.Show($"An error occurred while communicating with the LaunchBox API: {ex.Message}", "API Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmsMissingExportOptions_Closing(object sender, ToolStripDropDownClosingEventArgs e)
        {
            if (e.CloseReason == ToolStripDropDownCloseReason.ItemClicked)
            {
                // Check if the item clicked was our checkable menu item
                if (cmsMissingExportOptions.SourceControl != null ||
                    toggleNestedWishlistToolStripMenuItem.Pressed)
                {
                    e.Cancel = true;
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
    }
}