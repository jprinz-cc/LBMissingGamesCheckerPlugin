using System.Linq;
using System.Windows.Forms;
using Unbroken.LaunchBox.Plugins;


namespace LBMissingGamesCheckerPlugin
{
    public class MissingGamesChecker : ISystemMenuItemPlugin
    {
        public string Caption => "Missing Games Checker";
        public string Description => "Check which games you have and don't have for a selected platform.";
        public string Version => "1.0";
        public string MenuItemTitle => "Missing Games Checker";

        public System.Drawing.Image IconImage
        { get { return Properties.Resources.mgc; } }

        public bool ShowInLaunchBox
        { get { return true; } }

        public bool ShowMenuItem
        { get { return true; } }

        public bool ShowInBigBox
        { get { return false; } }

        public bool AllowInBigBoxWhenLocked
        { get { return false; } }

        public void OnSelected()
        {
            // Get all platforms
            var platforms = PluginHelper.DataManager.GetAllPlatforms().OrderBy(p => p.SortTitleOrTitle != null ? p.SortTitleOrTitle : p.Name).ToList();

            if (platforms == null || !platforms.Any())
            {
                MessageBox.Show("No platforms found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Create and show the platform selection form
            var platformSelectionForm = new PlatformSelectionForm(platforms);
            platformSelectionForm.ShowDialog();
        }
    }
}
