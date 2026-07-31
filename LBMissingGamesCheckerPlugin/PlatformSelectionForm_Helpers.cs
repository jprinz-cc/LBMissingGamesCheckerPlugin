using LBMissingGamesCheckerPlugin.Controls;
using LBMissingGamesCheckerPlugin.Models;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Reflection;
using System.Text;

namespace LBMissingGamesCheckerPlugin
{
    public partial class PlatformSelectionForm : Form
    {
        // Add wishlists icon when creating Wishlists category in LaunchBox
        private void EnsureWishlistCategoryIcon()
        {
            try
            {
                // Resolve LaunchBox's Platform Category folder
                string lbBaseDir = AppDomain.CurrentDomain.BaseDirectory;
                string categoryImagesDir = Path.Combine(lbBaseDir, "Images", "Media Packs", "Platform Icons", "Legacy Conversion Icon Pack", "Platform Categories");

                if (!Directory.Exists(categoryImagesDir))
                {
                    Directory.CreateDirectory(categoryImagesDir);
                }

                string targetImagePath = Path.Combine(categoryImagesDir, "Wishlists.png");

                // If the image doesn't exist yet, extract it from Plugin Resources
                if (!File.Exists(targetImagePath))
                {
                    using (var iconImage = Properties.Resources.Wishlists)
                    {
                        iconImage.Save(targetImagePath, System.Drawing.Imaging.ImageFormat.Png);
                    }
                    DebugTxt($"Successfully installed custom 'Wishlists.png' category icon to: '{categoryImagesDir}'");
                }
                else
                {
                    DebugTxt("'Wishlists.png' category icon already exists. No action taken.");
                }
            }
            catch (Exception ex)
            {
                DebugTxt($"Warning: Could not auto-install Wishlists category icon: {ex.Message}");
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
            // Toggle 'X' button visibility based on text content
            if (!UpdateSearchState(tbOwnedSearch, btnClearOwnedSearch, OriginalOwnedGameList))
            {
                return;
            }

            string query = tbOwnedSearch.Text.Trim().ToLower();

            // Suspend layout for performance
            ownedGamesGridView.SuspendLayout();

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
            // Toggle 'X' button visibility based on text content
            if (!UpdateSearchState(tbMissingSearch, btnClearMissingSearch, OriginalMissingGameList))
            {
                return;
            }

            string query = tbMissingSearch.Text.Trim().ToLower();

            // Suspend layout for performance
            missingGamesGridView.SuspendLayout();

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

        private void SetupSearchClearButtons()
        {
            // Initially hide clear icons
            btnClearOwnedSearch.Visible = false;
            btnClearMissingSearch.Visible = false;

            // Click handlers
            btnClearOwnedSearch.Click += (s, e) => tbOwnedSearch.Text = string.Empty;
            btnClearMissingSearch.Click += (s, e) => tbMissingSearch.Text = string.Empty;

            // Hover styling
            btnClearOwnedSearch.MouseEnter += (s, e) => btnClearOwnedSearch.ForeColor = Color.Red;
            btnClearOwnedSearch.MouseLeave += (s, e) => btnClearOwnedSearch.ForeColor = Color.Gray;

            btnClearMissingSearch.MouseEnter += (s, e) => btnClearMissingSearch.ForeColor = Color.Red;
            btnClearMissingSearch.MouseLeave += (s, e) => btnClearMissingSearch.ForeColor = Color.Gray;
        }

        private bool UpdateSearchState(TextBox textBox, Control clearButton, System.Collections.IEnumerable sourceList)
        {
            // Toggle 'X' visibility based on whether text is present
            clearButton.Visible = !string.IsNullOrWhiteSpace(textBox.Text);

            // Return true if list is populated, false if null
            return sourceList != null;
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
                    menu.Items.Add("📋 Copy Title to Clipboard", null, (s, args) =>
                    {
                        Clipboard.SetText($"{gameTitle}".Trim());
                    });

                    // Item 2: Copy Title/Platform to Clipboard
                    menu.Items.Add("📋 Copy Title/Platform to Clipboard", null, (s, args) =>
                    {
                        Clipboard.SetText($"{gameTitle} {gamePlatform}".Trim());
                    });

                    // Item 3: Formatted Data Row Copy
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

                    // Item 4: Copy Row for CSV/Spreadsheet
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

                    // Item 5: Search eBay
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
    }
}