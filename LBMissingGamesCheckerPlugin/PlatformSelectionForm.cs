using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using Unbroken.LaunchBox.Plugins;
using Unbroken.LaunchBox.Plugins.Data;

namespace LBMissingGamesCheckerPlugin
{
    public partial class PlatformSelectionForm : Form
    {
        // Holds the currently selected platform
        public string SelectedPlatform { get; private set; }

        // Class to hold the missing game data
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

        // Based on the selected platform,
        // collect all Owned Games from the users collection
        // and all games from the LaunchBox Metadata.xml file
        private async void GetAllPlatformGames(string selectedPlatform)
        {
            // Clear lists of populated data
            ownedGames = new List<IGame>();
            missingGames = new List<MissingGame>();

            // Get IPlatform of the selected platform
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
            var allGamesFromMetadata = await GetGamesFromMetadata(metadataFilePath, selectedPlatform, pbGridViewLoading); // Use await here

            // Check if "Released" filter is applied
            bool filterReleasedOnly = chkReleasedOnly.Checked;

            // Find the missing games by comparing with ownedGames
            missingGames = allGamesFromMetadata
                .Where(mdGame => !ownedGames.Any(owned => string.Equals(owned.Title, mdGame.Title, StringComparison.OrdinalIgnoreCase) ||
                    (owned.LaunchBoxDbId.HasValue && mdGame.LaunchBoxDbId.HasValue && owned.LaunchBoxDbId == mdGame.LaunchBoxDbId)))
                .Where(mdGame => !filterReleasedOnly || mdGame.ReleaseType == "Released").ToList();

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
                ownedGamesDisplayData.Add(new GameDisplayData(new MissingGame
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
                }));
            }
            ownedGamesGridView.DataSource = ownedGamesDisplayData;

            // Bind missingGames data to GridView
            List<GameDisplayData> missingGamesDisplayData = new List<GameDisplayData>();
            foreach (var game in missingGames.OrderBy(game => game.Title))
            {
                missingGamesDisplayData.Add(new GameDisplayData(game));
            }
            missingGamesGridView.DataSource = missingGamesDisplayData;

            //Populate column selection checkbox list
            clbColumnSelection.Items.Clear();
            foreach (DataGridViewColumn column in ownedGamesGridView.Columns)
            {
                if(column.HeaderText != "Title")
                {
                    // Add column header text as an item in the CheckedListBox
                    clbColumnSelection.Items.Add(column.HeaderText, column.Visible);
                }
                
            }

            // Format clickable cells in the GridViews
            FormatGridViewCells(ownedGamesGridView);
            FormatGridViewCells(missingGamesGridView);
            pbGridViewLoading.Visible = false;
        }


        //** Helper Methods **//
        // Get the platform games from the metadata.xml file
        private async Task<IList<MissingGame>> GetGamesFromMetadata(string metadataFilePath, string platformName, ProgressBar progressBar)
        {
            var games = new List<MissingGame>();

            // Open the file stream to track the number of bytes read
            using (FileStream fs = new FileStream(metadataFilePath, FileMode.Open, FileAccess.Read))
            {
                long totalBytes = fs.Length; // Total file size
                long bytesRead = 0;
                int lastProgress = 0; // To track the last progress value

                XmlReaderSettings settings = new XmlReaderSettings
                {
                    Async = true
                };

                using (XmlReader reader = XmlReader.Create(fs, settings))
                {
                    progressBar.Minimum = 0;
                    progressBar.Maximum = 100;
                    progressBar.Value = 0;
                    progressBar.Visible = true;

                    while (await reader.ReadAsync())
                    {
                        if (reader.NodeType == XmlNodeType.Element && reader.Name == "Game")
                        {
                            var gameElement = XNode.ReadFrom(reader) as XElement;

                            if (string.Equals((string)gameElement.Element("Platform"), platformName, StringComparison.OrdinalIgnoreCase))
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
                                    VideoUrl = (string)gameElement.Element("VideoURL") ?? "",
                                    WikipediaUrl = (string)gameElement.Element("WikipediaURL") ?? "",
                                    ReleaseType = (string)gameElement.Element("ReleaseType") ?? ""
                                };

                                games.Add(game);
                            }
                        }

                        // Only update the progress bar every 1% or so to reduce UI overhead
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
            return games;
        }

        // Add clickable elements to the GridViews
        private void FormatGridViewCells(DataGridView gridView)
        {
            foreach (DataGridViewRow row in gridView.Rows)
            {
                // Format LaunchBoxDbId column as a clickable link
                if (row.Cells["LaunchBoxDbId"].Value != null)
                {
                    int lbid;
                    if (int.TryParse(row.Cells["LaunchBoxDbId"].Value.ToString(), out lbid))
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
        // Confirm button handler for dropdown platform selection
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
            string columnName = missingGamesGridView.Columns[e.ColumnIndex].DataPropertyName;
            ToggleSortOrder(columnName);

            missingGamesGridView.DataSource = SortGames((List<GameDisplayData>)missingGamesGridView.DataSource, columnName);

            // Reapply formatting and ToolTipText properties
            FormatGridViewCells(missingGamesGridView);
        }

        // GridView cell click handler
        private void GridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var gridView = sender as DataGridView;
            if (gridView == null || e.RowIndex < 0) return;

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

        // Form close handler
        private void FormClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //** Form Theme **//
        public void ApplyTheme(Form form)
        {
            // Charcoal grey background
            form.BackColor = Color.FromArgb(54, 57, 63);

            // Loop through all controls and apply styles
            foreach (Control ctrl in form.Controls)
            {
                if (ctrl is Button btn && btn.Name != "btnClose")
                {
                    // Buttons with electric blue primary accent
                    btn.BackColor = Color.FromArgb(44, 156, 255);
                    btn.ForeColor = Color.White;
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderColor = Color.FromArgb(30, 130, 200);
                    btn.FlatAppearance.BorderSize = 1;
                }
                else if (ctrl is Label lbl)
                {
                    // Labels with contrasting text color
                    lbl.ForeColor = Color.FromArgb(230, 230, 230);
                }
                else if (ctrl is ComboBox cbx)
                {
                    // ComboBoxes with modern styling
                    cbx.BackColor = Color.FromArgb(245, 245, 245);
                    cbx.ForeColor = Color.Black;
                    cbx.FlatStyle = FlatStyle.Flat;
                }
                else if (ctrl is GroupBox gbx)
                {
                    // GroupBoxes styled with amber accent
                    gbx.ForeColor = Color.FromArgb(255, 191, 0);
                    gbx.BackColor = Color.FromArgb(54, 57, 63);
                }
                else if (ctrl is CheckBox chk)
                {
                    // Checkboxes styled with amber accent
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
                    // ProgressBar styled with electric blue accent
                    pb.BackColor = Color.FromArgb(54, 57, 63);
                    pb.ForeColor = Color.White;
                    pb.Style = ProgressBarStyle.Continuous;
                    pb.ForeColor = Color.FromArgb(44, 156, 255);
                }
                else if (ctrl is DataGridView dgv)
                {
                    // DataGridView with modern theme
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

        public class NewProgressBar : ProgressBar
        {
            public NewProgressBar()
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

        //** Form Init **//
        private void PlatformSelectionForm_Load(object sender, EventArgs e)
        {
            // Set Column Selection checkboxes to checked
            for(int i = 0; i < clbColumnSelection.Items.Count; i++)
            {
                clbColumnSelection.SetItemChecked(i, true);
            }
            ApplyTheme(this);
        }
    }
}
