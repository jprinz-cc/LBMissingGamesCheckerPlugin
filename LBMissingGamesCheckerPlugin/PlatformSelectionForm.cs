using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
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
            public string LaunchBoxDbId { get; set; }
            public string CommunityStarRating { get; set; }
            public string Status { get; set; }
            public string DateAdded { get; set; }
        }

        // Lists to hold sorted games
        private IList<IGame> ownedGames;
        private IList<IGame> missingGames;

        // Properties to toggle sort order in the GridViews
        private string lastSortedColumn = string.Empty;
        private bool ascending = true;


        public PlatformSelectionForm(IList<IPlatform> platforms)
        {
            InitializeComponent();

            // Populate dropdown with user platforms
            foreach ( var platform in platforms )
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

        private void ConfirmButton_Click( object sender, EventArgs e )
        {
            if(platformDropdown.SelectedItem != null)
            {
                SelectedPlatform = platformDropdown.SelectedItem.ToString();
                GetAllPlatformGames(SelectedPlatform);
            }
            else
            {
                MessageBox.Show("Please select a platform.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error );
            }
        }

        private void GetAllPlatformGames(string selectedPlatform)
        {
            // Clear lists of populated data
            if (ownedGames != null)
            {
                ownedGames = null;
            }
            if (missingGames != null)
            {
                missingGames = null;
            }
            
            
            var platform = PluginHelper.DataManager.GetPlatformByName(selectedPlatform);
            if (platform == null) return;

            var games = platform.GetAllGames(true,false);

            var allGames = PluginHelper.DataManager.GetAllGames()
                .Where(game => game.Platform == platform.Name).ToList();         

            //TODO: Get a list of all platform games from local Launchbox DB (metadata.xml?)
            //ownedGames = allGames.Where(game => game.Installed == true).ToList();
            //missingGames = allGames.Where(game => game.Installed == false).ToList();
            ownedGames = allGames;  // Sample Data
            missingGames = games;   // Sample Data

            PopulateGameList(ownedGames, missingGames);
        }

        private void PopulateGameList(IList<IGame> ownedGames, IList<IGame> missingGames)
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
            if (ownedGames.Count > 0)
            {
                lblOwnedGamesCount.Text = ownedGames.Count.ToString();
            }
            else
            {
                lblOwnedGamesCount.Text = "0";
            }

            if (missingGames.Count > 0)
            {
                lblMissingGamesCount.Text = missingGames.Count.ToString();
            }
            else
            {
                lblMissingGamesCount.Text = "0";
            }

            // Bind ownedGames data to GridView
            ownedGamesGridView.DataSource = ownedGames.OrderBy(game => game.Title).Select(game => new GameDisplayData
            {
                Title = game.Title,
                LaunchBoxDbId = game.LaunchBoxDbId.ToString(),
                Developer = game.Developer,
                Publisher = game.Publisher,
                ReleaseDate = game.ReleaseDate?.ToShortDateString(),
                CommunityStarRating = game.CommunityStarRating.ToString(),
                Status = game.Status,
                DateAdded = game.DateAdded.ToShortDateString()
            }).ToList();

            // Bind missingGames data to GridView
            missingGamesGridView.DataSource = missingGames.OrderBy(game => game.Title).Select(game => new GameDisplayData
            {
                Title = game.Title,
                LaunchBoxDbId = game.LaunchBoxDbId.ToString(),
                Developer = game.Developer,
                Publisher = game.Publisher,
                ReleaseDate = game.ReleaseDate?.ToShortDateString(),
                CommunityStarRating = game.CommunityStarRating.ToString(),
                Status = game.Status,
                DateAdded = game.DateAdded.ToShortDateString()
            }).ToList();

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
                ascending = !ascending;  // Toggle sort order
            }
            else
            {
                ascending = true;  // Default to ascending on new column
            }
            lastSortedColumn = columnName;
        }


        private void PlatformSelectionForm_Load(object sender, EventArgs e)
        {
            
        }
    }
}
