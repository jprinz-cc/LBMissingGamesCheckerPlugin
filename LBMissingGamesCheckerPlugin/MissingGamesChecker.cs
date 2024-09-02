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
        { 
            get { return Properties.Resources.mgc; }
        }

        public bool ShowInLaunchBox 
        { 
            get { return true; }
        }

        public bool ShowMenuItem => true;

        public bool ShowInBigBox
        { get { return false; } }

        public bool AllowInBigBoxWhenLocked
        { get { return false; } }

        public void OnSelected()
        {
            using (PlatformSelectionForm form = new PlatformSelectionForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    string selectedPlatform = form.SelectedPlatform;
                    if (!string.IsNullOrEmpty(selectedPlatform))
                    {
                        ShowGameListForm(selectedPlatform);
                    }
                }
            }
        }

        private void ShowGameListForm(string platformName)
        {
            using (GameListForm form = new GameListForm(platformName))
            {
                form.ShowDialog();
            }
        }
    }
}
