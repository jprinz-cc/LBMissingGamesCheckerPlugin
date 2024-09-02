using System;
using System.Windows.Forms;
using Unbroken.LaunchBox.Plugins;
using Unbroken.LaunchBox.Plugins.Data;

namespace LBMissingGamesCheckerPlugin
{
    public partial class PlatformSelectionForm : Form
    {
        public string SelectedPlatform { get; private set; }

        public PlatformSelectionForm()
        {
            InitializeComponent();

            var platforms = PluginHelper.DataManager.GetAllPlatforms();
            foreach ( var platform in platforms )
            {
                platformDropdown.Items.Add(platform.Name);
            }
        }

        private void ConfirmButton_Click( object sender, EventArgs e )
        {
            if(platformDropdown.SelectedItem != null)
            {
                SelectedPlatform = platformDropdown.SelectedItem.ToString();
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Please select a platform.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error );
            }
        }

        private void PlatformSelectionForm_Load(object sender, EventArgs e)
        {
            
        }
    }
}
