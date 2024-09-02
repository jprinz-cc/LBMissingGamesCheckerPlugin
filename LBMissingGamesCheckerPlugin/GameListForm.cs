using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Unbroken.LaunchBox.Plugins;
using Unbroken.LaunchBox.Plugins.Data;

namespace LBMissingGamesCheckerPlugin
{
    public partial class GameListForm : Form
    {
        public GameListForm(string platformName)
        {
            InitializeComponent();

            var platform = PluginHelper.DataManager.GetAllPlatforms()
                .FirstOrDefault(p => p.Name == platformName);
            if (platform == null) return;

            var allGames = PluginHelper.DataManager.GetAllGames()
                .Where(game => game.Platform == platform.Name).ToList();

            var ownedGames = allGames.Where(game => game.Installed == true).ToList();
            var missingGames = allGames.Where(game => game.Installed == false).ToList();

            PopulateGameList(ownedGames, missingGames);


        }

        private void PopulateGameList(IList<IGame> ownedGames, IList<IGame> missingGames)
        {
            ownedGamesGridView.DataSource = ownedGames.Select(game => new
            {
                Title = game.Title,
                Developer = game.Developer,
                Publisher = game.Publisher,
                ReleaseDate = game.ReleaseDate?.ToShortDateString(),
                Installed = game.Installed
            }).ToList();

            missingGamesGridView.DataSource = missingGames.Select(game => new
            {
                Title = game.Title,
                Developer = game.Developer,
                Publisher = game.Publisher,
                ReleaseDate = game.ReleaseDate?.ToShortDateString(),
                Installed = game.Installed
            }).ToList() ;

        }

        private void GameListForm_Load(object sender, EventArgs e)
        {

        }
    }
}
