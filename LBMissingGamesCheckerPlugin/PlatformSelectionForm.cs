using LBMissingGamesCheckerPlugin.Models;
using System.Collections.Concurrent;
using System.ComponentModel;
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
    }
}
