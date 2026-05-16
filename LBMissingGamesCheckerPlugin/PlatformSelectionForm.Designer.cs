namespace LBMissingGamesCheckerPlugin
{
    partial class PlatformSelectionForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            //if (ownedGames != null)
            //{
            //    ownedGames.Clear();
            //    ownedGames = null;
            //}
            //if (missingGames != null)
            //{
            //    missingGames.Clear();
            //    missingGames = null;
            //}
            //if (xmlGames != null)
            //{
            //    xmlGames.Clear();
            //}
            //if (xmlGameAltNames != null)
            //{
            //    xmlGameAltNames.Clear();
            //}
            //if (xmlPlatforms != null)
            //{
            //    xmlPlatforms.Clear();
            //}
            //if (missingGamesGridView.DataSource != null)
            //{
            //    missingGamesGridView.DataSource = null;
            //}
            //if (ownedGamesGridView.DataSource != null)
            //{
            //    ownedGamesGridView.DataSource = null;
            //}
            

            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle11 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle12 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle10 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlatformSelectionForm));
            DataGridViewCellStyle dataGridViewCellStyle13 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle14 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle15 = new DataGridViewCellStyle();
            platformDropdown = new ComboBox();
            confirmButton = new Button();
            ownedGamesGridView = new DataGridView();
            TitleOwned = new DataGridViewTextBoxColumn();
            DeveloperOwned = new DataGridViewTextBoxColumn();
            PublisherOwned = new DataGridViewTextBoxColumn();
            RegionOwned = new DataGridViewTextBoxColumn();
            ReleaseDateOwned = new DataGridViewTextBoxColumn();
            CommunityStarRatingOwned = new DataGridViewTextBoxColumn();
            CommunityStarRatingTotalVotesOwned = new DataGridViewTextBoxColumn();
            PlatformOwned = new DataGridViewTextBoxColumn();
            ReleaseTypeOwned = new DataGridViewTextBoxColumn();
            GenresOwned = new DataGridViewTextBoxColumn();
            AlternateNamesOwned = new DataGridViewTextBoxColumn();
            MaxPlayersOwned = new DataGridViewTextBoxColumn();
            LaunchBoxDbIdOwned = new DataGridViewButtonColumn();
            VideoUrlOwned = new DataGridViewButtonColumn();
            WikipediaUrlOwned = new DataGridViewButtonColumn();
            ownedGamesBindingSource = new BindingSource(components);
            missingGamesGridView = new DataGridView();
            TitleMissing = new DataGridViewTextBoxColumn();
            DeveloperMissing = new DataGridViewTextBoxColumn();
            PublisherMissing = new DataGridViewTextBoxColumn();
            RegionMissing = new DataGridViewTextBoxColumn();
            ReleaseDateMissing = new DataGridViewTextBoxColumn();
            CommunityStarRatingMissing = new DataGridViewTextBoxColumn();
            CommunityStarRatingTotalVotesMissing = new DataGridViewTextBoxColumn();
            PlatformMissing = new DataGridViewTextBoxColumn();
            ReleaseTypeMissing = new DataGridViewTextBoxColumn();
            GenresMissing = new DataGridViewTextBoxColumn();
            AlternateNamesMissing = new DataGridViewTextBoxColumn();
            MaxPlayersMissing = new DataGridViewTextBoxColumn();
            LaunchBoxDbIdMissing = new DataGridViewButtonColumn();
            VideoUrlMissing = new DataGridViewButtonColumn();
            WikipediaUrlMissing = new DataGridViewButtonColumn();
            missingGamesBindingSource = new BindingSource(components);
            lblDropdown = new Label();
            lblOwnedGamesGridView = new Label();
            lblMissingGamesGridView = new Label();
            lblOwnedGamesCount = new Label();
            lblMissingGamesCount = new Label();
            btnOwnedCSV = new Button();
            btnMissingCSV = new Button();
            gbOptional = new GroupBox();
            clbColumnSelection = new CheckedListBox();
            lblColumnSelection = new Label();
            chkReleasedOnly = new CheckBox();
            timer1 = new System.Windows.Forms.Timer(components);
            btnClose = new Button();
            llbPoweredBy = new LinkLabel();
            ssMetadataStatus = new StatusStrip();
            tsslIcon = new ToolStripStatusLabel();
            tsslText = new ToolStripStatusLabel();
            pbMetadataLoading = new LBMissingGamesCheckerPlugin.Controls.ProgressBarEx();
            tbDebug = new TextBox();
            ssPlatformDropdownMsg = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            tsslPlatformDropdownMsg = new ToolStripStatusLabel();
            pDebugLog = new Panel();
            btnClearDebugLog = new Button();
            btnCopyToClipboard = new Button();
            label1 = new Label();
            btnCloseDebug = new Button();
            pbDebugHeader = new PictureBox();
            pbSpinner = new PictureBox();
            lblCongrats = new Label();
            noPlatformGridView = new DataGridView();
            errorNoPlatform = new DataGridViewTextBoxColumn();
            msgNoPlatform = new DataGridViewTextBoxColumn();
            errorLBDbId = new DataGridViewTextBoxColumn();
            noPlatformBindingSource = new BindingSource(components);
            lblScrapeAs = new Label();
            gbFilterOptions = new GroupBox();
            chkSelectAll = new CheckBox();
            pbCloseFilter = new PictureBox();
            btnFilterReset = new Button();
            clbFilterOptions = new CheckedListBox();
            btnApplyFilters = new Button();
            pbCongrats = new PictureBox();
            pbDebugBtn = new PictureBox();
            pbMGCHeader = new PictureBox();
            pbMGCLogo = new PictureBox();
            lblPlatformWarning = new Label();
            tbOwnedSearch = new TextBox();
            lblOwnedSearch = new Label();
            tbMissingSearch = new TextBox();
            lblMissingSearch = new Label();
            ((System.ComponentModel.ISupportInitialize)ownedGamesGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ownedGamesBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)missingGamesGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)missingGamesBindingSource).BeginInit();
            gbOptional.SuspendLayout();
            ssMetadataStatus.SuspendLayout();
            ssPlatformDropdownMsg.SuspendLayout();
            pDebugLog.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbDebugHeader).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbSpinner).BeginInit();
            ((System.ComponentModel.ISupportInitialize)noPlatformGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)noPlatformBindingSource).BeginInit();
            gbFilterOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbCloseFilter).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbCongrats).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbDebugBtn).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbMGCHeader).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbMGCLogo).BeginInit();
            SuspendLayout();
            // 
            // platformDropdown
            // 
            platformDropdown.DropDownStyle = ComboBoxStyle.DropDownList;
            platformDropdown.Font = new Font("Microsoft Sans Serif", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            platformDropdown.FormattingEnabled = true;
            platformDropdown.Items.AddRange(new object[] { "Select a Platform" });
            platformDropdown.Location = new Point(19, 69);
            platformDropdown.Margin = new Padding(4, 3, 4, 3);
            platformDropdown.Name = "platformDropdown";
            platformDropdown.Size = new Size(256, 21);
            platformDropdown.TabIndex = 0;
            platformDropdown.SelectedIndexChanged += PlatformDropdown_SelectedIndexChanged;
            // 
            // confirmButton
            // 
            confirmButton.Enabled = false;
            confirmButton.Font = new Font("Microsoft Sans Serif", 8.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            confirmButton.Location = new Point(187, 98);
            confirmButton.Margin = new Padding(4, 3, 4, 3);
            confirmButton.Name = "confirmButton";
            confirmButton.Size = new Size(88, 27);
            confirmButton.TabIndex = 1;
            confirmButton.Text = "Check It!";
            confirmButton.UseVisualStyleBackColor = true;
            confirmButton.Click += ConfirmButton_Click;
            // 
            // ownedGamesGridView
            // 
            ownedGamesGridView.AllowUserToAddRows = false;
            ownedGamesGridView.AllowUserToDeleteRows = false;
            ownedGamesGridView.AllowUserToOrderColumns = true;
            ownedGamesGridView.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            ownedGamesGridView.AutoGenerateColumns = false;
            ownedGamesGridView.BackgroundColor = Color.FromArgb(54, 57, 63);
            ownedGamesGridView.BorderStyle = BorderStyle.Fixed3D;
            ownedGamesGridView.CellBorderStyle = DataGridViewCellBorderStyle.Sunken;
            ownedGamesGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(44, 156, 255);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = Color.SteelBlue;
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            ownedGamesGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            ownedGamesGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ownedGamesGridView.Columns.AddRange(new DataGridViewColumn[] { TitleOwned, DeveloperOwned, PublisherOwned, RegionOwned, ReleaseDateOwned, CommunityStarRatingOwned, CommunityStarRatingTotalVotesOwned, PlatformOwned, ReleaseTypeOwned, GenresOwned, AlternateNamesOwned, MaxPlayersOwned, LaunchBoxDbIdOwned, VideoUrlOwned, WikipediaUrlOwned });
            ownedGamesGridView.DataSource = ownedGamesBindingSource;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = Color.FromArgb(54, 57, 63);
            dataGridViewCellStyle5.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle5.ForeColor = Color.White;
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.False;
            ownedGamesGridView.DefaultCellStyle = dataGridViewCellStyle5;
            ownedGamesGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
            ownedGamesGridView.EnableHeadersVisualStyles = false;
            ownedGamesGridView.GridColor = Color.FromArgb(44, 156, 255);
            ownedGamesGridView.Location = new Point(288, 142);
            ownedGamesGridView.Margin = new Padding(4, 3, 4, 3);
            ownedGamesGridView.Name = "ownedGamesGridView";
            ownedGamesGridView.ReadOnly = true;
            ownedGamesGridView.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = Color.FromArgb(54, 57, 63);
            dataGridViewCellStyle6.ForeColor = Color.White;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.True;
            ownedGamesGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            ownedGamesGridView.RowHeadersWidth = 51;
            ownedGamesGridView.ShowEditingIcon = false;
            ownedGamesGridView.Size = new Size(814, 173);
            ownedGamesGridView.TabIndex = 2;
            ownedGamesGridView.CellContentClick += GridView_CellContentClick;
            ownedGamesGridView.CellFormatting += GridView_CellFormatting;
            ownedGamesGridView.CellMouseEnter += GridView_CellMouseEnter;
            ownedGamesGridView.CellMouseLeave += GridView_CellMouseLeave;
            ownedGamesGridView.ColumnHeaderMouseClick += GridView_ColumnHeaderMouseClick;
            // 
            // TitleOwned
            // 
            TitleOwned.DataPropertyName = "Title";
            TitleOwned.HeaderText = "Title";
            TitleOwned.MinimumWidth = 6;
            TitleOwned.Name = "TitleOwned";
            TitleOwned.ReadOnly = true;
            TitleOwned.Width = 125;
            // 
            // DeveloperOwned
            // 
            DeveloperOwned.DataPropertyName = "Developer";
            DeveloperOwned.HeaderText = "Developer";
            DeveloperOwned.MinimumWidth = 6;
            DeveloperOwned.Name = "DeveloperOwned";
            DeveloperOwned.ReadOnly = true;
            DeveloperOwned.Width = 125;
            // 
            // PublisherOwned
            // 
            PublisherOwned.DataPropertyName = "Publisher";
            PublisherOwned.HeaderText = "Publisher";
            PublisherOwned.MinimumWidth = 6;
            PublisherOwned.Name = "PublisherOwned";
            PublisherOwned.ReadOnly = true;
            PublisherOwned.Width = 125;
            // 
            // RegionOwned
            // 
            RegionOwned.DataPropertyName = "Region";
            RegionOwned.HeaderText = "Region";
            RegionOwned.MinimumWidth = 6;
            RegionOwned.Name = "RegionOwned";
            RegionOwned.ReadOnly = true;
            RegionOwned.Width = 125;
            // 
            // ReleaseDateOwned
            // 
            ReleaseDateOwned.DataPropertyName = "ReleaseDate";
            ReleaseDateOwned.HeaderText = "ReleaseDate";
            ReleaseDateOwned.MinimumWidth = 6;
            ReleaseDateOwned.Name = "ReleaseDateOwned";
            ReleaseDateOwned.ReadOnly = true;
            ReleaseDateOwned.Width = 125;
            // 
            // CommunityStarRatingOwned
            // 
            CommunityStarRatingOwned.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            CommunityStarRatingOwned.DataPropertyName = "CommunityStarRating";
            CommunityStarRatingOwned.HeaderText = "CommunityStarRating";
            CommunityStarRatingOwned.MinimumWidth = 6;
            CommunityStarRatingOwned.Name = "CommunityStarRatingOwned";
            CommunityStarRatingOwned.ReadOnly = true;
            CommunityStarRatingOwned.Width = 133;
            // 
            // CommunityStarRatingTotalVotesOwned
            // 
            CommunityStarRatingTotalVotesOwned.DataPropertyName = "CommunityStarRatingTotalVotes";
            CommunityStarRatingTotalVotesOwned.HeaderText = "CommunityStarRatingTotalVotes";
            CommunityStarRatingTotalVotesOwned.MinimumWidth = 6;
            CommunityStarRatingTotalVotesOwned.Name = "CommunityStarRatingTotalVotesOwned";
            CommunityStarRatingTotalVotesOwned.ReadOnly = true;
            CommunityStarRatingTotalVotesOwned.Width = 125;
            // 
            // PlatformOwned
            // 
            PlatformOwned.DataPropertyName = "Platform";
            PlatformOwned.HeaderText = "Platform";
            PlatformOwned.MinimumWidth = 6;
            PlatformOwned.Name = "PlatformOwned";
            PlatformOwned.ReadOnly = true;
            PlatformOwned.Width = 125;
            // 
            // ReleaseTypeOwned
            // 
            ReleaseTypeOwned.DataPropertyName = "ReleaseType";
            ReleaseTypeOwned.HeaderText = "ReleaseType";
            ReleaseTypeOwned.MinimumWidth = 6;
            ReleaseTypeOwned.Name = "ReleaseTypeOwned";
            ReleaseTypeOwned.ReadOnly = true;
            ReleaseTypeOwned.Width = 125;
            // 
            // GenresOwned
            // 
            GenresOwned.DataPropertyName = "Genres";
            GenresOwned.HeaderText = "Genres";
            GenresOwned.MinimumWidth = 6;
            GenresOwned.Name = "GenresOwned";
            GenresOwned.ReadOnly = true;
            GenresOwned.Width = 125;
            // 
            // AlternateNamesOwned
            // 
            AlternateNamesOwned.DataPropertyName = "AlternateNames";
            AlternateNamesOwned.HeaderText = "AlternateNames";
            AlternateNamesOwned.MinimumWidth = 6;
            AlternateNamesOwned.Name = "AlternateNamesOwned";
            AlternateNamesOwned.ReadOnly = true;
            AlternateNamesOwned.Width = 125;
            // 
            // MaxPlayersOwned
            // 
            MaxPlayersOwned.DataPropertyName = "MaxPlayers";
            MaxPlayersOwned.HeaderText = "MaxPlayers";
            MaxPlayersOwned.MinimumWidth = 6;
            MaxPlayersOwned.Name = "MaxPlayersOwned";
            MaxPlayersOwned.ReadOnly = true;
            MaxPlayersOwned.Width = 125;
            // 
            // LaunchBoxDbIdOwned
            // 
            LaunchBoxDbIdOwned.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            LaunchBoxDbIdOwned.DataPropertyName = "LaunchBoxDbId";
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(255, 191, 0);
            dataGridViewCellStyle2.Font = new Font("Arial", 8.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.Black;
            dataGridViewCellStyle2.Padding = new Padding(3, 0, 3, 0);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(54, 57, 63);
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(255, 191, 0);
            LaunchBoxDbIdOwned.DefaultCellStyle = dataGridViewCellStyle2;
            LaunchBoxDbIdOwned.FlatStyle = FlatStyle.Popup;
            LaunchBoxDbIdOwned.HeaderText = "LaunchBoxDBID";
            LaunchBoxDbIdOwned.MinimumWidth = 6;
            LaunchBoxDbIdOwned.Name = "LaunchBoxDbIdOwned";
            LaunchBoxDbIdOwned.ReadOnly = true;
            LaunchBoxDbIdOwned.SortMode = DataGridViewColumnSortMode.Automatic;
            LaunchBoxDbIdOwned.Text = "LaunchBoxDBID";
            LaunchBoxDbIdOwned.Width = 112;
            // 
            // VideoUrlOwned
            // 
            VideoUrlOwned.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            VideoUrlOwned.DataPropertyName = "VideoUrl";
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(255, 191, 0);
            dataGridViewCellStyle3.Font = new Font("Arial", 8.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = Color.Black;
            dataGridViewCellStyle3.Padding = new Padding(3, 0, 3, 0);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(54, 57, 63);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(255, 191, 0);
            VideoUrlOwned.DefaultCellStyle = dataGridViewCellStyle3;
            VideoUrlOwned.FlatStyle = FlatStyle.Popup;
            VideoUrlOwned.HeaderText = "VideoURL";
            VideoUrlOwned.MinimumWidth = 6;
            VideoUrlOwned.Name = "VideoUrlOwned";
            VideoUrlOwned.ReadOnly = true;
            VideoUrlOwned.Text = "";
            VideoUrlOwned.Width = 62;
            // 
            // WikipediaUrlOwned
            // 
            WikipediaUrlOwned.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            WikipediaUrlOwned.DataPropertyName = "WikipediaUrl";
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(255, 191, 0);
            dataGridViewCellStyle4.Font = new Font("Arial", 8.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle4.ForeColor = Color.Black;
            dataGridViewCellStyle4.Padding = new Padding(3, 0, 3, 0);
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(54, 57, 63);
            dataGridViewCellStyle4.SelectionForeColor = Color.FromArgb(255, 191, 0);
            WikipediaUrlOwned.DefaultCellStyle = dataGridViewCellStyle4;
            WikipediaUrlOwned.FlatStyle = FlatStyle.Popup;
            WikipediaUrlOwned.HeaderText = "WikipediaURL";
            WikipediaUrlOwned.MinimumWidth = 6;
            WikipediaUrlOwned.Name = "WikipediaUrlOwned";
            WikipediaUrlOwned.ReadOnly = true;
            WikipediaUrlOwned.Text = "";
            WikipediaUrlOwned.Width = 82;
            // 
            // missingGamesGridView
            // 
            missingGamesGridView.AllowUserToAddRows = false;
            missingGamesGridView.AllowUserToDeleteRows = false;
            missingGamesGridView.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            missingGamesGridView.AutoGenerateColumns = false;
            missingGamesGridView.BackgroundColor = Color.FromArgb(54, 57, 63);
            missingGamesGridView.BorderStyle = BorderStyle.Fixed3D;
            missingGamesGridView.CellBorderStyle = DataGridViewCellBorderStyle.Sunken;
            missingGamesGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = Color.FromArgb(44, 156, 255);
            dataGridViewCellStyle7.ForeColor = Color.White;
            dataGridViewCellStyle7.SelectionBackColor = Color.SteelBlue;
            dataGridViewCellStyle7.WrapMode = DataGridViewTriState.True;
            missingGamesGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            missingGamesGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            missingGamesGridView.Columns.AddRange(new DataGridViewColumn[] { TitleMissing, DeveloperMissing, PublisherMissing, RegionMissing, ReleaseDateMissing, CommunityStarRatingMissing, CommunityStarRatingTotalVotesMissing, PlatformMissing, ReleaseTypeMissing, GenresMissing, AlternateNamesMissing, MaxPlayersMissing, LaunchBoxDbIdMissing, VideoUrlMissing, WikipediaUrlMissing });
            missingGamesGridView.DataSource = missingGamesBindingSource;
            dataGridViewCellStyle11.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = Color.FromArgb(54, 57, 63);
            dataGridViewCellStyle11.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle11.ForeColor = Color.White;
            dataGridViewCellStyle11.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = DataGridViewTriState.False;
            missingGamesGridView.DefaultCellStyle = dataGridViewCellStyle11;
            missingGamesGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
            missingGamesGridView.EnableHeadersVisualStyles = false;
            missingGamesGridView.GridColor = Color.FromArgb(44, 156, 255);
            missingGamesGridView.Location = new Point(288, 359);
            missingGamesGridView.Margin = new Padding(4, 3, 4, 3);
            missingGamesGridView.Name = "missingGamesGridView";
            missingGamesGridView.ReadOnly = true;
            missingGamesGridView.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle12.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = Color.FromArgb(54, 57, 63);
            dataGridViewCellStyle12.ForeColor = Color.White;
            dataGridViewCellStyle12.WrapMode = DataGridViewTriState.True;
            missingGamesGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
            missingGamesGridView.RowHeadersWidth = 51;
            missingGamesGridView.Size = new Size(814, 217);
            missingGamesGridView.TabIndex = 3;
            missingGamesGridView.CellContentClick += GridView_CellContentClick;
            missingGamesGridView.CellFormatting += GridView_CellFormatting;
            missingGamesGridView.CellMouseEnter += GridView_CellMouseEnter;
            missingGamesGridView.CellMouseLeave += GridView_CellMouseLeave;
            missingGamesGridView.ColumnHeaderMouseClick += GridView_ColumnHeaderMouseClick;
            // 
            // TitleMissing
            // 
            TitleMissing.DataPropertyName = "Title";
            TitleMissing.HeaderText = "Title";
            TitleMissing.MinimumWidth = 6;
            TitleMissing.Name = "TitleMissing";
            TitleMissing.ReadOnly = true;
            TitleMissing.Width = 125;
            // 
            // DeveloperMissing
            // 
            DeveloperMissing.DataPropertyName = "Developer";
            DeveloperMissing.HeaderText = "Developer";
            DeveloperMissing.MinimumWidth = 6;
            DeveloperMissing.Name = "DeveloperMissing";
            DeveloperMissing.ReadOnly = true;
            DeveloperMissing.Width = 125;
            // 
            // PublisherMissing
            // 
            PublisherMissing.DataPropertyName = "Publisher";
            PublisherMissing.HeaderText = "Publisher";
            PublisherMissing.MinimumWidth = 6;
            PublisherMissing.Name = "PublisherMissing";
            PublisherMissing.ReadOnly = true;
            PublisherMissing.Width = 125;
            // 
            // RegionMissing
            // 
            RegionMissing.DataPropertyName = "Region";
            RegionMissing.HeaderText = "Region";
            RegionMissing.MinimumWidth = 6;
            RegionMissing.Name = "RegionMissing";
            RegionMissing.ReadOnly = true;
            RegionMissing.Width = 125;
            // 
            // ReleaseDateMissing
            // 
            ReleaseDateMissing.DataPropertyName = "ReleaseDate";
            ReleaseDateMissing.HeaderText = "ReleaseDate";
            ReleaseDateMissing.MinimumWidth = 6;
            ReleaseDateMissing.Name = "ReleaseDateMissing";
            ReleaseDateMissing.ReadOnly = true;
            ReleaseDateMissing.Width = 125;
            // 
            // CommunityStarRatingMissing
            // 
            CommunityStarRatingMissing.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            CommunityStarRatingMissing.DataPropertyName = "CommunityStarRating";
            CommunityStarRatingMissing.HeaderText = "CommunityStarRating";
            CommunityStarRatingMissing.MinimumWidth = 6;
            CommunityStarRatingMissing.Name = "CommunityStarRatingMissing";
            CommunityStarRatingMissing.ReadOnly = true;
            CommunityStarRatingMissing.Width = 133;
            // 
            // CommunityStarRatingTotalVotesMissing
            // 
            CommunityStarRatingTotalVotesMissing.DataPropertyName = "CommunityStarRatingTotalVotes";
            CommunityStarRatingTotalVotesMissing.HeaderText = "CommunityStarRatingTotalVotes";
            CommunityStarRatingTotalVotesMissing.MinimumWidth = 6;
            CommunityStarRatingTotalVotesMissing.Name = "CommunityStarRatingTotalVotesMissing";
            CommunityStarRatingTotalVotesMissing.ReadOnly = true;
            CommunityStarRatingTotalVotesMissing.Width = 125;
            // 
            // PlatformMissing
            // 
            PlatformMissing.DataPropertyName = "Platform";
            PlatformMissing.HeaderText = "Platform";
            PlatformMissing.MinimumWidth = 6;
            PlatformMissing.Name = "PlatformMissing";
            PlatformMissing.ReadOnly = true;
            PlatformMissing.Width = 125;
            // 
            // ReleaseTypeMissing
            // 
            ReleaseTypeMissing.DataPropertyName = "ReleaseType";
            ReleaseTypeMissing.HeaderText = "ReleaseType";
            ReleaseTypeMissing.MinimumWidth = 6;
            ReleaseTypeMissing.Name = "ReleaseTypeMissing";
            ReleaseTypeMissing.ReadOnly = true;
            ReleaseTypeMissing.Width = 125;
            // 
            // GenresMissing
            // 
            GenresMissing.DataPropertyName = "Genres";
            GenresMissing.HeaderText = "Genres";
            GenresMissing.MinimumWidth = 6;
            GenresMissing.Name = "GenresMissing";
            GenresMissing.ReadOnly = true;
            GenresMissing.Width = 125;
            // 
            // AlternateNamesMissing
            // 
            AlternateNamesMissing.DataPropertyName = "AlternateNames";
            AlternateNamesMissing.HeaderText = "AlternateNames";
            AlternateNamesMissing.MinimumWidth = 6;
            AlternateNamesMissing.Name = "AlternateNamesMissing";
            AlternateNamesMissing.ReadOnly = true;
            AlternateNamesMissing.Width = 125;
            // 
            // MaxPlayersMissing
            // 
            MaxPlayersMissing.DataPropertyName = "MaxPlayers";
            MaxPlayersMissing.HeaderText = "MaxPlayers";
            MaxPlayersMissing.MinimumWidth = 6;
            MaxPlayersMissing.Name = "MaxPlayersMissing";
            MaxPlayersMissing.ReadOnly = true;
            MaxPlayersMissing.Width = 125;
            // 
            // LaunchBoxDbIdMissing
            // 
            LaunchBoxDbIdMissing.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            LaunchBoxDbIdMissing.DataPropertyName = "LaunchBoxDbId";
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = Color.FromArgb(255, 191, 0);
            dataGridViewCellStyle8.Font = new Font("Arial", 8.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle8.ForeColor = Color.Black;
            dataGridViewCellStyle8.SelectionBackColor = Color.FromArgb(54, 57, 63);
            dataGridViewCellStyle8.SelectionForeColor = Color.FromArgb(255, 191, 0);
            LaunchBoxDbIdMissing.DefaultCellStyle = dataGridViewCellStyle8;
            LaunchBoxDbIdMissing.FlatStyle = FlatStyle.Popup;
            LaunchBoxDbIdMissing.HeaderText = "LaunchBoxDBID";
            LaunchBoxDbIdMissing.MinimumWidth = 6;
            LaunchBoxDbIdMissing.Name = "LaunchBoxDbIdMissing";
            LaunchBoxDbIdMissing.ReadOnly = true;
            LaunchBoxDbIdMissing.SortMode = DataGridViewColumnSortMode.Automatic;
            LaunchBoxDbIdMissing.Text = "";
            LaunchBoxDbIdMissing.Width = 112;
            // 
            // VideoUrlMissing
            // 
            VideoUrlMissing.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            VideoUrlMissing.DataPropertyName = "VideoUrl";
            dataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = Color.FromArgb(255, 191, 0);
            dataGridViewCellStyle9.Font = new Font("Arial", 8.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle9.ForeColor = Color.Black;
            dataGridViewCellStyle9.SelectionBackColor = Color.FromArgb(54, 57, 63);
            dataGridViewCellStyle9.SelectionForeColor = Color.FromArgb(255, 191, 0);
            VideoUrlMissing.DefaultCellStyle = dataGridViewCellStyle9;
            VideoUrlMissing.FlatStyle = FlatStyle.Popup;
            VideoUrlMissing.HeaderText = "VideoURL";
            VideoUrlMissing.MinimumWidth = 6;
            VideoUrlMissing.Name = "VideoUrlMissing";
            VideoUrlMissing.ReadOnly = true;
            VideoUrlMissing.Text = "";
            VideoUrlMissing.Width = 62;
            // 
            // WikipediaUrlMissing
            // 
            WikipediaUrlMissing.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            WikipediaUrlMissing.DataPropertyName = "WikipediaUrl";
            dataGridViewCellStyle10.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.BackColor = Color.FromArgb(255, 191, 0);
            dataGridViewCellStyle10.Font = new Font("Arial", 8.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle10.ForeColor = Color.Black;
            dataGridViewCellStyle10.SelectionBackColor = Color.FromArgb(54, 57, 63);
            dataGridViewCellStyle10.SelectionForeColor = Color.FromArgb(255, 191, 0);
            WikipediaUrlMissing.DefaultCellStyle = dataGridViewCellStyle10;
            WikipediaUrlMissing.FlatStyle = FlatStyle.Popup;
            WikipediaUrlMissing.HeaderText = "WikipediaURL";
            WikipediaUrlMissing.MinimumWidth = 6;
            WikipediaUrlMissing.Name = "WikipediaUrlMissing";
            WikipediaUrlMissing.ReadOnly = true;
            WikipediaUrlMissing.Text = "";
            WikipediaUrlMissing.Width = 82;
            // 
            // lblDropdown
            // 
            lblDropdown.AutoSize = true;
            lblDropdown.BackColor = Color.Transparent;
            lblDropdown.Font = new Font("Microsoft Sans Serif", 11.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDropdown.ForeColor = Color.FromArgb(230, 230, 230);
            lblDropdown.Location = new Point(14, 43);
            lblDropdown.Margin = new Padding(4, 0, 4, 0);
            lblDropdown.Name = "lblDropdown";
            lblDropdown.Size = new Size(193, 20);
            lblDropdown.TabIndex = 4;
            lblDropdown.Text = "Select a platform to check";
            // 
            // lblOwnedGamesGridView
            // 
            lblOwnedGamesGridView.AutoSize = true;
            lblOwnedGamesGridView.BackColor = Color.Transparent;
            lblOwnedGamesGridView.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblOwnedGamesGridView.ForeColor = Color.FromArgb(230, 230, 230);
            lblOwnedGamesGridView.Location = new Point(285, 125);
            lblOwnedGamesGridView.Margin = new Padding(4, 0, 4, 0);
            lblOwnedGamesGridView.Name = "lblOwnedGamesGridView";
            lblOwnedGamesGridView.Size = new Size(149, 15);
            lblOwnedGamesGridView.TabIndex = 5;
            lblOwnedGamesGridView.Text = "Owned Games List Count:";
            // 
            // lblMissingGamesGridView
            // 
            lblMissingGamesGridView.AutoSize = true;
            lblMissingGamesGridView.BackColor = Color.Transparent;
            lblMissingGamesGridView.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMissingGamesGridView.ForeColor = Color.FromArgb(230, 230, 230);
            lblMissingGamesGridView.Location = new Point(285, 342);
            lblMissingGamesGridView.Margin = new Padding(4, 0, 4, 0);
            lblMissingGamesGridView.Name = "lblMissingGamesGridView";
            lblMissingGamesGridView.Size = new Size(153, 15);
            lblMissingGamesGridView.TabIndex = 6;
            lblMissingGamesGridView.Text = "Missing Games List Count:";
            // 
            // lblOwnedGamesCount
            // 
            lblOwnedGamesCount.AutoSize = true;
            lblOwnedGamesCount.BackColor = Color.Transparent;
            lblOwnedGamesCount.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblOwnedGamesCount.ForeColor = Color.FromArgb(230, 230, 230);
            lblOwnedGamesCount.Location = new Point(465, 125);
            lblOwnedGamesCount.Margin = new Padding(4, 0, 4, 0);
            lblOwnedGamesCount.Name = "lblOwnedGamesCount";
            lblOwnedGamesCount.Size = new Size(14, 15);
            lblOwnedGamesCount.TabIndex = 7;
            lblOwnedGamesCount.Text = "0";
            // 
            // lblMissingGamesCount
            // 
            lblMissingGamesCount.AutoSize = true;
            lblMissingGamesCount.BackColor = Color.Transparent;
            lblMissingGamesCount.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMissingGamesCount.ForeColor = Color.FromArgb(230, 230, 230);
            lblMissingGamesCount.Location = new Point(470, 342);
            lblMissingGamesCount.Margin = new Padding(4, 0, 4, 0);
            lblMissingGamesCount.Name = "lblMissingGamesCount";
            lblMissingGamesCount.Size = new Size(14, 15);
            lblMissingGamesCount.TabIndex = 8;
            lblMissingGamesCount.Text = "0";
            // 
            // btnOwnedCSV
            // 
            btnOwnedCSV.Enabled = false;
            btnOwnedCSV.Font = new Font("Microsoft Sans Serif", 7F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnOwnedCSV.Location = new Point(993, 116);
            btnOwnedCSV.Margin = new Padding(4, 3, 4, 3);
            btnOwnedCSV.Name = "btnOwnedCSV";
            btnOwnedCSV.Size = new Size(99, 23);
            btnOwnedCSV.TabIndex = 9;
            btnOwnedCSV.Text = "Export to CSV";
            btnOwnedCSV.UseVisualStyleBackColor = true;
            btnOwnedCSV.Click += ExportOwnedGamesButton_Click;
            // 
            // btnMissingCSV
            // 
            btnMissingCSV.Enabled = false;
            btnMissingCSV.Font = new Font("Microsoft Sans Serif", 7F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnMissingCSV.Location = new Point(993, 333);
            btnMissingCSV.Margin = new Padding(4, 3, 4, 3);
            btnMissingCSV.Name = "btnMissingCSV";
            btnMissingCSV.Size = new Size(99, 23);
            btnMissingCSV.TabIndex = 10;
            btnMissingCSV.Text = "Export to CSV";
            btnMissingCSV.UseVisualStyleBackColor = true;
            btnMissingCSV.Click += ExportMissingGamesButton_Click;
            // 
            // gbOptional
            // 
            gbOptional.Controls.Add(clbColumnSelection);
            gbOptional.Controls.Add(lblColumnSelection);
            gbOptional.Controls.Add(chkReleasedOnly);
            gbOptional.ForeColor = Color.FromArgb(255, 191, 0);
            gbOptional.Location = new Point(24, 150);
            gbOptional.Margin = new Padding(4, 3, 4, 0);
            gbOptional.Name = "gbOptional";
            gbOptional.Padding = new Padding(4, 3, 4, 3);
            gbOptional.Size = new Size(238, 337);
            gbOptional.TabIndex = 11;
            gbOptional.TabStop = false;
            gbOptional.Text = "Optional Items";
            // 
            // clbColumnSelection
            // 
            clbColumnSelection.CheckOnClick = true;
            clbColumnSelection.Dock = DockStyle.Bottom;
            clbColumnSelection.FormattingEnabled = true;
            clbColumnSelection.Location = new Point(4, 78);
            clbColumnSelection.Margin = new Padding(4, 1, 4, 2);
            clbColumnSelection.Name = "clbColumnSelection";
            clbColumnSelection.Size = new Size(230, 256);
            clbColumnSelection.TabIndex = 1;
            clbColumnSelection.ItemCheck += CheckedListBox_ItemCheck;
            // 
            // lblColumnSelection
            // 
            lblColumnSelection.AutoSize = true;
            lblColumnSelection.ForeColor = Color.FromArgb(255, 191, 0);
            lblColumnSelection.Location = new Point(8, 56);
            lblColumnSelection.Margin = new Padding(4, 0, 4, 0);
            lblColumnSelection.Name = "lblColumnSelection";
            lblColumnSelection.Size = new Size(101, 15);
            lblColumnSelection.TabIndex = 2;
            lblColumnSelection.Text = "Column Selection";
            // 
            // chkReleasedOnly
            // 
            chkReleasedOnly.AutoSize = true;
            chkReleasedOnly.ForeColor = Color.FromArgb(255, 191, 0);
            chkReleasedOnly.Location = new Point(12, 23);
            chkReleasedOnly.Margin = new Padding(4, 3, 4, 3);
            chkReleasedOnly.Name = "chkReleasedOnly";
            chkReleasedOnly.Size = new Size(180, 19);
            chkReleasedOnly.TabIndex = 0;
            chkReleasedOnly.Text = "Only include Released games";
            chkReleasedOnly.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.MidnightBlue;
            btnClose.FlatAppearance.BorderColor = Color.FromArgb(30, 130, 200);
            btnClose.FlatAppearance.MouseDownBackColor = Color.Black;
            btnClose.FlatAppearance.MouseOverBackColor = Color.Navy;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClose.ForeColor = Color.FromArgb(255, 191, 0);
            btnClose.Location = new Point(989, 13);
            btnClose.Margin = new Padding(2);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(113, 33);
            btnClose.TabIndex = 13;
            btnClose.Text = "Close MGC";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += FormClose_Click;
            // 
            // llbPoweredBy
            // 
            llbPoweredBy.ActiveLinkColor = Color.MidnightBlue;
            llbPoweredBy.AutoSize = true;
            llbPoweredBy.BackColor = Color.Transparent;
            llbPoweredBy.Font = new Font("Microsoft Sans Serif", 7F, FontStyle.Regular, GraphicsUnit.Point, 0);
            llbPoweredBy.ForeColor = Color.FromArgb(255, 191, 0);
            llbPoweredBy.LinkBehavior = LinkBehavior.AlwaysUnderline;
            llbPoweredBy.LinkColor = Color.FromArgb(255, 191, 0);
            llbPoweredBy.Location = new Point(21, 550);
            llbPoweredBy.Margin = new Padding(4, 0, 4, 0);
            llbPoweredBy.Name = "llbPoweredBy";
            llbPoweredBy.Size = new Size(162, 13);
            llbPoweredBy.TabIndex = 16;
            llbPoweredBy.TabStop = true;
            llbPoweredBy.Text = "MGC Powered by AgentJohnnyP";
            llbPoweredBy.VisitedLinkColor = Color.FromArgb(255, 191, 0);
            llbPoweredBy.LinkClicked += PoweredBy_LinkClicked;
            // 
            // ssMetadataStatus
            // 
            ssMetadataStatus.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            ssMetadataStatus.AutoSize = false;
            ssMetadataStatus.BackColor = Color.Transparent;
            ssMetadataStatus.Dock = DockStyle.None;
            ssMetadataStatus.ImageScalingSize = new Size(20, 20);
            ssMetadataStatus.Items.AddRange(new ToolStripItem[] { tsslIcon, tsslText });
            ssMetadataStatus.Location = new Point(24, 606);
            ssMetadataStatus.Name = "ssMetadataStatus";
            ssMetadataStatus.Padding = new Padding(1, 0, 16, 0);
            ssMetadataStatus.Size = new Size(239, 30);
            ssMetadataStatus.SizingGrip = false;
            ssMetadataStatus.TabIndex = 19;
            // 
            // tsslIcon
            // 
            tsslIcon.Image = (Image)resources.GetObject("tsslIcon.Image");
            tsslIcon.Name = "tsslIcon";
            tsslIcon.Padding = new Padding(5, 0, 0, 5);
            tsslIcon.Size = new Size(25, 25);
            // 
            // tsslText
            // 
            tsslText.BackColor = Color.FromArgb(255, 191, 0);
            tsslText.Font = new Font("Segoe UI", 9F);
            tsslText.ForeColor = Color.Black;
            tsslText.Name = "tsslText";
            tsslText.Padding = new Padding(10, 0, 0, 5);
            tsslText.Size = new Size(151, 25);
            tsslText.Text = "Preparing Environment....";
            // 
            // pbMetadataLoading
            // 
            pbMetadataLoading.BackColor = Color.FromArgb(54, 57, 63);
            pbMetadataLoading.ForeColor = Color.FromArgb(4, 173, 255);
            pbMetadataLoading.Location = new Point(24, 517);
            pbMetadataLoading.Margin = new Padding(4, 3, 4, 3);
            pbMetadataLoading.MarqueeAnimationSpeed = 50;
            pbMetadataLoading.Name = "pbMetadataLoading";
            pbMetadataLoading.Size = new Size(251, 24);
            pbMetadataLoading.TabIndex = 20;
            pbMetadataLoading.Visible = false;
            // 
            // tbDebug
            // 
            tbDebug.BackColor = Color.FromArgb(54, 57, 63);
            tbDebug.ForeColor = Color.FromArgb(255, 191, 0);
            tbDebug.Location = new Point(2, 50);
            tbDebug.Margin = new Padding(2);
            tbDebug.MaxLength = 15000;
            tbDebug.Multiline = true;
            tbDebug.Name = "tbDebug";
            tbDebug.ReadOnly = true;
            tbDebug.ScrollBars = ScrollBars.Vertical;
            tbDebug.Size = new Size(622, 211);
            tbDebug.TabIndex = 21;
            tbDebug.Text = "Debug Log";
            // 
            // ssPlatformDropdownMsg
            // 
            ssPlatformDropdownMsg.AutoSize = false;
            ssPlatformDropdownMsg.BackColor = Color.FromArgb(255, 191, 0);
            ssPlatformDropdownMsg.Dock = DockStyle.None;
            ssPlatformDropdownMsg.ImageScalingSize = new Size(20, 20);
            ssPlatformDropdownMsg.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1, tsslPlatformDropdownMsg });
            ssPlatformDropdownMsg.Location = new Point(0, 0);
            ssPlatformDropdownMsg.Name = "ssPlatformDropdownMsg";
            ssPlatformDropdownMsg.Padding = new Padding(1, 0, 16, 0);
            ssPlatformDropdownMsg.Size = new Size(257, 30);
            ssPlatformDropdownMsg.SizingGrip = false;
            ssPlatformDropdownMsg.TabIndex = 23;
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Image = (Image)resources.GetObject("toolStripStatusLabel1.Image");
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Padding = new Padding(5, 0, 0, 5);
            toolStripStatusLabel1.Size = new Size(25, 25);
            // 
            // tsslPlatformDropdownMsg
            // 
            tsslPlatformDropdownMsg.Font = new Font("Segoe UI", 10F);
            tsslPlatformDropdownMsg.ForeColor = Color.Black;
            tsslPlatformDropdownMsg.Name = "tsslPlatformDropdownMsg";
            tsslPlatformDropdownMsg.Padding = new Padding(10, 0, 0, 5);
            tsslPlatformDropdownMsg.Size = new Size(166, 25);
            tsslPlatformDropdownMsg.Text = "Please select a platform!";
            // 
            // pDebugLog
            // 
            pDebugLog.BorderStyle = BorderStyle.Fixed3D;
            pDebugLog.Controls.Add(tbDebug);
            pDebugLog.Controls.Add(btnClearDebugLog);
            pDebugLog.Controls.Add(btnCopyToClipboard);
            pDebugLog.Controls.Add(label1);
            pDebugLog.Controls.Add(btnCloseDebug);
            pDebugLog.Controls.Add(pbDebugHeader);
            pDebugLog.Controls.Add(pbSpinner);
            pDebugLog.ForeColor = Color.FromArgb(255, 191, 0);
            pDebugLog.Location = new Point(321, 220);
            pDebugLog.Margin = new Padding(4, 3, 4, 3);
            pDebugLog.Name = "pDebugLog";
            pDebugLog.Size = new Size(633, 267);
            pDebugLog.TabIndex = 24;
            // 
            // btnClearDebugLog
            // 
            btnClearDebugLog.BackColor = Color.Transparent;
            btnClearDebugLog.BackgroundImageLayout = ImageLayout.Zoom;
            btnClearDebugLog.Font = new Font("Microsoft Sans Serif", 6.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnClearDebugLog.ForeColor = Color.Black;
            btnClearDebugLog.Location = new Point(360, 12);
            btnClearDebugLog.Margin = new Padding(4, 3, 4, 3);
            btnClearDebugLog.Name = "btnClearDebugLog";
            btnClearDebugLog.Size = new Size(94, 24);
            btnClearDebugLog.TabIndex = 26;
            btnClearDebugLog.Text = "Clear Debug Log";
            btnClearDebugLog.UseVisualStyleBackColor = false;
            btnClearDebugLog.Click += ClearDebugLog_Click;
            // 
            // btnCopyToClipboard
            // 
            btnCopyToClipboard.BackColor = Color.Transparent;
            btnCopyToClipboard.BackgroundImageLayout = ImageLayout.Zoom;
            btnCopyToClipboard.Font = new Font("Microsoft Sans Serif", 6.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCopyToClipboard.ForeColor = Color.Black;
            btnCopyToClipboard.Location = new Point(241, 12);
            btnCopyToClipboard.Margin = new Padding(4, 3, 4, 3);
            btnCopyToClipboard.Name = "btnCopyToClipboard";
            btnCopyToClipboard.Size = new Size(104, 24);
            btnCopyToClipboard.TabIndex = 25;
            btnCopyToClipboard.Text = "Copy To Clipboard";
            btnCopyToClipboard.UseVisualStyleBackColor = false;
            btnCopyToClipboard.Click += CopyToClipboard_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(57, 8);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(152, 24);
            label1.TabIndex = 24;
            label1.Text = "MGC Debug Log";
            // 
            // btnCloseDebug
            // 
            btnCloseDebug.BackColor = Color.MidnightBlue;
            btnCloseDebug.FlatAppearance.BorderColor = Color.FromArgb(30, 130, 200);
            btnCloseDebug.FlatAppearance.MouseDownBackColor = Color.Black;
            btnCloseDebug.FlatAppearance.MouseOverBackColor = Color.Navy;
            btnCloseDebug.FlatStyle = FlatStyle.Flat;
            btnCloseDebug.Font = new Font("Microsoft Sans Serif", 7F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCloseDebug.ForeColor = Color.FromArgb(255, 191, 0);
            btnCloseDebug.Location = new Point(492, 5);
            btnCloseDebug.Margin = new Padding(2);
            btnCloseDebug.Name = "btnCloseDebug";
            btnCloseDebug.Size = new Size(133, 32);
            btnCloseDebug.TabIndex = 23;
            btnCloseDebug.Text = "Close Debug Log";
            btnCloseDebug.UseVisualStyleBackColor = false;
            btnCloseDebug.Click += CloseDebug_Click;
            // 
            // pbDebugHeader
            // 
            pbDebugHeader.BackColor = Color.Transparent;
            pbDebugHeader.BackgroundImage = (Image)resources.GetObject("pbDebugHeader.BackgroundImage");
            pbDebugHeader.BackgroundImageLayout = ImageLayout.Stretch;
            pbDebugHeader.Location = new Point(5, 5);
            pbDebugHeader.Margin = new Padding(4, 3, 4, 3);
            pbDebugHeader.Name = "pbDebugHeader";
            pbDebugHeader.Size = new Size(46, 42);
            pbDebugHeader.TabIndex = 22;
            pbDebugHeader.TabStop = false;
            // 
            // pbSpinner
            // 
            pbSpinner.BackColor = Color.Transparent;
            pbSpinner.BackgroundImageLayout = ImageLayout.Zoom;
            pbSpinner.Image = Properties.Resources.mgc_spinner;
            pbSpinner.Location = new Point(157, 45);
            pbSpinner.Margin = new Padding(4, 3, 4, 3);
            pbSpinner.Name = "pbSpinner";
            pbSpinner.Size = new Size(352, 177);
            pbSpinner.SizeMode = PictureBoxSizeMode.Zoom;
            pbSpinner.TabIndex = 26;
            pbSpinner.TabStop = false;
            // 
            // lblCongrats
            // 
            lblCongrats.AutoSize = true;
            lblCongrats.BackColor = Color.FromArgb(255, 191, 0);
            lblCongrats.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCongrats.Location = new Point(288, 102);
            lblCongrats.Margin = new Padding(4, 0, 4, 0);
            lblCongrats.Name = "lblCongrats";
            lblCongrats.Padding = new Padding(0, 2, 0, 2);
            lblCongrats.Size = new Size(281, 21);
            lblCongrats.TabIndex = 27;
            lblCongrats.Text = "Congrats! Your collection is complete!";
            // 
            // noPlatformGridView
            // 
            noPlatformGridView.AllowUserToAddRows = false;
            noPlatformGridView.AllowUserToDeleteRows = false;
            noPlatformGridView.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            noPlatformGridView.AutoGenerateColumns = false;
            noPlatformGridView.BackgroundColor = Color.FromArgb(54, 57, 63);
            noPlatformGridView.BorderStyle = BorderStyle.Fixed3D;
            noPlatformGridView.CellBorderStyle = DataGridViewCellBorderStyle.Sunken;
            noPlatformGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle13.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = Color.FromArgb(255, 191, 0);
            dataGridViewCellStyle13.ForeColor = Color.Black;
            dataGridViewCellStyle13.SelectionBackColor = Color.Black;
            dataGridViewCellStyle13.SelectionForeColor = Color.FromArgb(255, 191, 0);
            dataGridViewCellStyle13.WrapMode = DataGridViewTriState.True;
            noPlatformGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle13;
            noPlatformGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            noPlatformGridView.Columns.AddRange(new DataGridViewColumn[] { errorNoPlatform, msgNoPlatform, errorLBDbId });
            noPlatformGridView.DataSource = noPlatformBindingSource;
            dataGridViewCellStyle14.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = Color.FromArgb(54, 57, 63);
            dataGridViewCellStyle14.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle14.ForeColor = Color.FromArgb(255, 191, 0);
            dataGridViewCellStyle14.SelectionBackColor = Color.FromArgb(255, 191, 0);
            dataGridViewCellStyle14.SelectionForeColor = Color.FromArgb(54, 57, 63);
            dataGridViewCellStyle14.WrapMode = DataGridViewTriState.False;
            noPlatformGridView.DefaultCellStyle = dataGridViewCellStyle14;
            noPlatformGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
            noPlatformGridView.EnableHeadersVisualStyles = false;
            noPlatformGridView.GridColor = Color.FromArgb(44, 156, 255);
            noPlatformGridView.Location = new Point(288, 359);
            noPlatformGridView.Margin = new Padding(4, 3, 4, 3);
            noPlatformGridView.Name = "noPlatformGridView";
            noPlatformGridView.ReadOnly = true;
            noPlatformGridView.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle15.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = Color.FromArgb(54, 57, 63);
            dataGridViewCellStyle15.ForeColor = Color.White;
            dataGridViewCellStyle15.WrapMode = DataGridViewTriState.True;
            noPlatformGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle15;
            noPlatformGridView.RowHeadersWidth = 51;
            noPlatformGridView.Size = new Size(813, 217);
            noPlatformGridView.TabIndex = 25;
            // 
            // errorNoPlatform
            // 
            errorNoPlatform.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            errorNoPlatform.DataPropertyName = "Title";
            errorNoPlatform.HeaderText = "Error";
            errorNoPlatform.MinimumWidth = 6;
            errorNoPlatform.Name = "errorNoPlatform";
            errorNoPlatform.ReadOnly = true;
            errorNoPlatform.SortMode = DataGridViewColumnSortMode.NotSortable;
            errorNoPlatform.Width = 35;
            // 
            // msgNoPlatform
            // 
            msgNoPlatform.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            msgNoPlatform.DataPropertyName = "Platform";
            msgNoPlatform.HeaderText = "Message";
            msgNoPlatform.MinimumWidth = 6;
            msgNoPlatform.Name = "msgNoPlatform";
            msgNoPlatform.ReadOnly = true;
            msgNoPlatform.SortMode = DataGridViewColumnSortMode.NotSortable;
            msgNoPlatform.Width = 56;
            // 
            // errorLBDbId
            // 
            errorLBDbId.DataPropertyName = "LaunchBoxDbId";
            errorLBDbId.HeaderText = "LaunchBoxDbId";
            errorLBDbId.MinimumWidth = 6;
            errorLBDbId.Name = "errorLBDbId";
            errorLBDbId.ReadOnly = true;
            errorLBDbId.SortMode = DataGridViewColumnSortMode.NotSortable;
            errorLBDbId.Visible = false;
            errorLBDbId.Width = 125;
            // 
            // lblScrapeAs
            // 
            lblScrapeAs.AutoSize = true;
            lblScrapeAs.Font = new Font("Microsoft Sans Serif", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblScrapeAs.ForeColor = Color.FromArgb(255, 191, 0);
            lblScrapeAs.Location = new Point(18, 24);
            lblScrapeAs.Margin = new Padding(2, 0, 2, 0);
            lblScrapeAs.Name = "lblScrapeAs";
            lblScrapeAs.Size = new Size(76, 13);
            lblScrapeAs.TabIndex = 28;
            lblScrapeAs.Text = "Searching As: ";
            // 
            // gbFilterOptions
            // 
            gbFilterOptions.AutoSize = true;
            gbFilterOptions.Controls.Add(chkSelectAll);
            gbFilterOptions.Controls.Add(pbCloseFilter);
            gbFilterOptions.Controls.Add(btnFilterReset);
            gbFilterOptions.Controls.Add(clbFilterOptions);
            gbFilterOptions.Controls.Add(btnApplyFilters);
            gbFilterOptions.ForeColor = Color.FromArgb(255, 191, 0);
            gbFilterOptions.Location = new Point(512, 122);
            gbFilterOptions.Margin = new Padding(4, 3, 4, 3);
            gbFilterOptions.Name = "gbFilterOptions";
            gbFilterOptions.Padding = new Padding(4, 3, 4, 3);
            gbFilterOptions.Size = new Size(173, 210);
            gbFilterOptions.TabIndex = 29;
            gbFilterOptions.TabStop = false;
            gbFilterOptions.Text = "Filter";
            // 
            // chkSelectAll
            // 
            chkSelectAll.AutoSize = true;
            chkSelectAll.Checked = true;
            chkSelectAll.CheckState = CheckState.Checked;
            chkSelectAll.Location = new Point(7, 50);
            chkSelectAll.Name = "chkSelectAll";
            chkSelectAll.Size = new Size(108, 19);
            chkSelectAll.TabIndex = 4;
            chkSelectAll.Text = "Select All/None";
            chkSelectAll.UseVisualStyleBackColor = true;
            chkSelectAll.CheckedChanged += chkSelectAll_CheckedChanged;
            // 
            // pbCloseFilter
            // 
            pbCloseFilter.AccessibleDescription = "Close Filter Window";
            pbCloseFilter.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pbCloseFilter.BackColor = Color.Transparent;
            pbCloseFilter.Cursor = Cursors.Hand;
            pbCloseFilter.Image = Properties.Resources.error;
            pbCloseFilter.Location = new Point(150, 12);
            pbCloseFilter.Margin = new Padding(0);
            pbCloseFilter.Name = "pbCloseFilter";
            pbCloseFilter.Size = new Size(15, 15);
            pbCloseFilter.SizeMode = PictureBoxSizeMode.Zoom;
            pbCloseFilter.TabIndex = 3;
            pbCloseFilter.TabStop = false;
            pbCloseFilter.Click += CloseFilter_Click;
            // 
            // btnFilterReset
            // 
            btnFilterReset.Font = new Font("Microsoft Sans Serif", 7F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnFilterReset.ForeColor = Color.Black;
            btnFilterReset.Location = new Point(69, 20);
            btnFilterReset.Margin = new Padding(4, 3, 4, 3);
            btnFilterReset.Name = "btnFilterReset";
            btnFilterReset.Size = new Size(55, 24);
            btnFilterReset.TabIndex = 2;
            btnFilterReset.Text = "Reset";
            btnFilterReset.UseVisualStyleBackColor = true;
            btnFilterReset.Click += FilterReset_Click;
            // 
            // clbFilterOptions
            // 
            clbFilterOptions.CheckOnClick = true;
            clbFilterOptions.Dock = DockStyle.Bottom;
            clbFilterOptions.FormattingEnabled = true;
            clbFilterOptions.Location = new Point(4, 77);
            clbFilterOptions.Margin = new Padding(4, 3, 4, 3);
            clbFilterOptions.Name = "clbFilterOptions";
            clbFilterOptions.Size = new Size(165, 130);
            clbFilterOptions.Sorted = true;
            clbFilterOptions.TabIndex = 1;
            clbFilterOptions.ThreeDCheckBoxes = true;
            // 
            // btnApplyFilters
            // 
            btnApplyFilters.Font = new Font("Microsoft Sans Serif", 7F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnApplyFilters.ForeColor = Color.Black;
            btnApplyFilters.Location = new Point(7, 20);
            btnApplyFilters.Margin = new Padding(4, 3, 4, 3);
            btnApplyFilters.Name = "btnApplyFilters";
            btnApplyFilters.Size = new Size(55, 24);
            btnApplyFilters.TabIndex = 0;
            btnApplyFilters.Text = "Apply";
            btnApplyFilters.UseVisualStyleBackColor = true;
            btnApplyFilters.Click += ApplyFilters_Click;
            // 
            // pbCongrats
            // 
            pbCongrats.Image = Properties.Resources.congrats;
            pbCongrats.Location = new Point(497, 383);
            pbCongrats.Margin = new Padding(2);
            pbCongrats.Name = "pbCongrats";
            pbCongrats.Size = new Size(400, 173);
            pbCongrats.SizeMode = PictureBoxSizeMode.Zoom;
            pbCongrats.TabIndex = 3;
            pbCongrats.TabStop = false;
            // 
            // pbDebugBtn
            // 
            pbDebugBtn.BackColor = Color.Transparent;
            pbDebugBtn.BackgroundImage = (Image)resources.GetObject("pbDebugBtn.BackgroundImage");
            pbDebugBtn.BackgroundImageLayout = ImageLayout.Zoom;
            pbDebugBtn.Cursor = Cursors.Help;
            pbDebugBtn.Location = new Point(252, 547);
            pbDebugBtn.Margin = new Padding(4, 3, 4, 3);
            pbDebugBtn.Name = "pbDebugBtn";
            pbDebugBtn.Size = new Size(23, 23);
            pbDebugBtn.TabIndex = 24;
            pbDebugBtn.TabStop = false;
            pbDebugBtn.Click += DebugBtn_Click;
            // 
            // pbMGCHeader
            // 
            pbMGCHeader.BackColor = Color.Transparent;
            pbMGCHeader.Image = Properties.Resources.mgc_header;
            pbMGCHeader.Location = new Point(413, -1);
            pbMGCHeader.Margin = new Padding(4, 3, 4, 3);
            pbMGCHeader.Name = "pbMGCHeader";
            pbMGCHeader.Size = new Size(550, 112);
            pbMGCHeader.SizeMode = PictureBoxSizeMode.Zoom;
            pbMGCHeader.TabIndex = 15;
            pbMGCHeader.TabStop = false;
            pbMGCHeader.MouseDown += PlatformSelectionForm_MouseDown;
            // 
            // pbMGCLogo
            // 
            pbMGCLogo.BackColor = Color.Transparent;
            pbMGCLogo.Image = Properties.Resources.mgc_logo;
            pbMGCLogo.Location = new Point(321, 13);
            pbMGCLogo.Margin = new Padding(4, 3, 4, 3);
            pbMGCLogo.Name = "pbMGCLogo";
            pbMGCLogo.Size = new Size(85, 68);
            pbMGCLogo.SizeMode = PictureBoxSizeMode.Zoom;
            pbMGCLogo.TabIndex = 14;
            pbMGCLogo.TabStop = false;
            pbMGCLogo.MouseDown += PlatformSelectionForm_MouseDown;
            // 
            // lblPlatformWarning
            // 
            lblPlatformWarning.AutoSize = true;
            lblPlatformWarning.BackColor = Color.FromArgb(255, 191, 0);
            lblPlatformWarning.Font = new Font("Microsoft Sans Serif", 7F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPlatformWarning.ForeColor = Color.Black;
            lblPlatformWarning.Location = new Point(0, 98);
            lblPlatformWarning.Margin = new Padding(2, 0, 2, 0);
            lblPlatformWarning.Name = "lblPlatformWarning";
            lblPlatformWarning.Padding = new Padding(2);
            lblPlatformWarning.Size = new Size(172, 43);
            lblPlatformWarning.TabIndex = 30;
            lblPlatformWarning.Text = "Warning! This platform contains\r\na lot of data! Processing may take \r\na few moments!";
            // 
            // tbOwnedSearch
            // 
            tbOwnedSearch.Location = new Point(777, 116);
            tbOwnedSearch.Name = "tbOwnedSearch";
            tbOwnedSearch.Size = new Size(188, 23);
            tbOwnedSearch.TabIndex = 31;
            tbOwnedSearch.TextChanged += tbOwnedSearch_TextChanged;
            // 
            // lblOwnedSearch
            // 
            lblOwnedSearch.AutoSize = true;
            lblOwnedSearch.ForeColor = Color.FromArgb(230, 230, 230);
            lblOwnedSearch.Location = new Point(648, 122);
            lblOwnedSearch.Margin = new Padding(4, 0, 4, 0);
            lblOwnedSearch.Name = "lblOwnedSearch";
            lblOwnedSearch.Size = new Size(122, 15);
            lblOwnedSearch.TabIndex = 32;
            lblOwnedSearch.Text = "Search Owned Games";
            // 
            // tbMissingSearch
            // 
            tbMissingSearch.Location = new Point(777, 333);
            tbMissingSearch.Name = "tbMissingSearch";
            tbMissingSearch.Size = new Size(188, 23);
            tbMissingSearch.TabIndex = 31;
            tbMissingSearch.TextChanged += tbMissingSearch_TextChanged;
            // 
            // lblMissingSearch
            // 
            lblMissingSearch.AutoSize = true;
            lblMissingSearch.ForeColor = Color.FromArgb(230, 230, 230);
            lblMissingSearch.Location = new Point(648, 339);
            lblMissingSearch.Margin = new Padding(4, 0, 4, 0);
            lblMissingSearch.Name = "lblMissingSearch";
            lblMissingSearch.Size = new Size(125, 15);
            lblMissingSearch.TabIndex = 32;
            lblMissingSearch.Text = "Search Missing Games";
            // 
            // PlatformSelectionForm
            // 
            AccessibleDescription = "A LaunchBox plugin designed to help users identify missing games in their collection based on platform metadata.";
            AccessibleName = "Missing Games Checker";
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(54, 57, 63);
            ClientSize = new Size(1115, 586);
            ControlBox = false;
            Controls.Add(lblMissingSearch);
            Controls.Add(tbMissingSearch);
            Controls.Add(lblOwnedSearch);
            Controls.Add(tbOwnedSearch);
            Controls.Add(lblPlatformWarning);
            Controls.Add(gbFilterOptions);
            Controls.Add(pbCongrats);
            Controls.Add(lblCongrats);
            Controls.Add(pDebugLog);
            Controls.Add(lblScrapeAs);
            Controls.Add(noPlatformGridView);
            Controls.Add(missingGamesGridView);
            Controls.Add(ssPlatformDropdownMsg);
            Controls.Add(pbMetadataLoading);
            Controls.Add(pbDebugBtn);
            Controls.Add(ssMetadataStatus);
            Controls.Add(llbPoweredBy);
            Controls.Add(btnClose);
            Controls.Add(gbOptional);
            Controls.Add(btnMissingCSV);
            Controls.Add(btnOwnedCSV);
            Controls.Add(lblMissingGamesCount);
            Controls.Add(lblOwnedGamesCount);
            Controls.Add(lblMissingGamesGridView);
            Controls.Add(lblOwnedGamesGridView);
            Controls.Add(lblDropdown);
            Controls.Add(ownedGamesGridView);
            Controls.Add(confirmButton);
            Controls.Add(platformDropdown);
            Controls.Add(pbMGCHeader);
            Controls.Add(pbMGCLogo);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 3, 4, 3);
            MinimumSize = new Size(1115, 553);
            Name = "PlatformSelectionForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Missing Games Checker";
            FormClosing += PlatformSelectionForm_FormClosing;
            Load += PlatformSelectionForm_Load;
            Shown += PlatformSelectionForm_Shown;
            MouseDown += PlatformSelectionForm_MouseDown;
            ((System.ComponentModel.ISupportInitialize)ownedGamesGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)ownedGamesBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)missingGamesGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)missingGamesBindingSource).EndInit();
            gbOptional.ResumeLayout(false);
            gbOptional.PerformLayout();
            ssMetadataStatus.ResumeLayout(false);
            ssMetadataStatus.PerformLayout();
            ssPlatformDropdownMsg.ResumeLayout(false);
            ssPlatformDropdownMsg.PerformLayout();
            pDebugLog.ResumeLayout(false);
            pDebugLog.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbDebugHeader).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbSpinner).EndInit();
            ((System.ComponentModel.ISupportInitialize)noPlatformGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)noPlatformBindingSource).EndInit();
            gbFilterOptions.ResumeLayout(false);
            gbFilterOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbCloseFilter).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbCongrats).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbDebugBtn).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbMGCHeader).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbMGCLogo).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox platformDropdown;
        private System.Windows.Forms.Button confirmButton;
        private System.Windows.Forms.DataGridView ownedGamesGridView;
        private System.Windows.Forms.DataGridView missingGamesGridView;
        private System.Windows.Forms.Label lblDropdown;
        private System.Windows.Forms.Label lblOwnedGamesGridView;
        private System.Windows.Forms.Label lblMissingGamesGridView;
        private System.Windows.Forms.Label lblOwnedGamesCount;
        private System.Windows.Forms.Label lblMissingGamesCount;
        private System.Windows.Forms.Button btnOwnedCSV;
        private System.Windows.Forms.Button btnMissingCSV;
        private System.Windows.Forms.GroupBox gbOptional;
        private System.Windows.Forms.CheckBox chkReleasedOnly;
        private System.Windows.Forms.CheckedListBox clbColumnSelection;
        private System.Windows.Forms.Label lblColumnSelection;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.PictureBox pbMGCLogo;
        private System.Windows.Forms.PictureBox pbMGCHeader;
        private System.Windows.Forms.LinkLabel llbPoweredBy;
        private System.Windows.Forms.StatusStrip ssMetadataStatus;
        private System.Windows.Forms.ToolStripStatusLabel tsslIcon;
        private System.Windows.Forms.ToolStripStatusLabel tsslText;
        private Controls.ProgressBarEx pbMetadataLoading;
        private System.Windows.Forms.TextBox tbDebug;
        private System.Windows.Forms.StatusStrip ssPlatformDropdownMsg;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel tsslPlatformDropdownMsg;
        private System.Windows.Forms.PictureBox pbDebugBtn;
        private System.Windows.Forms.Panel pDebugLog;
        private System.Windows.Forms.Button btnCloseDebug;
        private System.Windows.Forms.PictureBox pbDebugHeader;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCopyToClipboard;
        private System.Windows.Forms.Button btnClearDebugLog;
        private System.Windows.Forms.DataGridView noPlatformGridView;
        private System.Windows.Forms.PictureBox pbSpinner;
        private System.Windows.Forms.BindingSource ownedGamesBindingSource;
        private System.Windows.Forms.BindingSource missingGamesBindingSource;
        private System.Windows.Forms.BindingSource noPlatformBindingSource;
        private System.Windows.Forms.Label lblCongrats;
        private System.Windows.Forms.DataGridViewTextBoxColumn errorNoPlatform;
        private System.Windows.Forms.DataGridViewTextBoxColumn msgNoPlatform;
        private System.Windows.Forms.DataGridViewTextBoxColumn errorLBDbId;
        private System.Windows.Forms.Label lblScrapeAs;
        private System.Windows.Forms.PictureBox pbCongrats;
        private System.Windows.Forms.GroupBox gbFilterOptions;
        private System.Windows.Forms.CheckedListBox clbFilterOptions;
        private System.Windows.Forms.Button btnApplyFilters;
        private System.Windows.Forms.Button btnFilterReset;
        private System.Windows.Forms.PictureBox pbCloseFilter;
        private System.Windows.Forms.Label lblPlatformWarning;
        private System.Windows.Forms.DataGridViewTextBoxColumn TitleMissing;
        private System.Windows.Forms.DataGridViewTextBoxColumn DeveloperMissing;
        private System.Windows.Forms.DataGridViewTextBoxColumn PublisherMissing;
        private System.Windows.Forms.DataGridViewTextBoxColumn RegionMissing;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReleaseDateMissing;
        private System.Windows.Forms.DataGridViewTextBoxColumn CommunityStarRatingMissing;
        private System.Windows.Forms.DataGridViewTextBoxColumn CommunityStarRatingTotalVotesMissing;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlatformMissing;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReleaseTypeMissing;
        private System.Windows.Forms.DataGridViewTextBoxColumn GenresMissing;
        private System.Windows.Forms.DataGridViewTextBoxColumn AlternateNamesMissing;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaxPlayersMissing;
        private System.Windows.Forms.DataGridViewButtonColumn LaunchBoxDbIdMissing;
        private System.Windows.Forms.DataGridViewButtonColumn VideoUrlMissing;
        private System.Windows.Forms.DataGridViewButtonColumn WikipediaUrlMissing;
        private System.Windows.Forms.DataGridViewTextBoxColumn TitleOwned;
        private System.Windows.Forms.DataGridViewTextBoxColumn DeveloperOwned;
        private System.Windows.Forms.DataGridViewTextBoxColumn PublisherOwned;
        private System.Windows.Forms.DataGridViewTextBoxColumn RegionOwned;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReleaseDateOwned;
        private System.Windows.Forms.DataGridViewTextBoxColumn CommunityStarRatingOwned;
        private System.Windows.Forms.DataGridViewTextBoxColumn CommunityStarRatingTotalVotesOwned;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlatformOwned;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReleaseTypeOwned;
        private System.Windows.Forms.DataGridViewTextBoxColumn GenresOwned;
        private System.Windows.Forms.DataGridViewTextBoxColumn AlternateNamesOwned;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaxPlayersOwned;
        private System.Windows.Forms.DataGridViewButtonColumn LaunchBoxDbIdOwned;
        private System.Windows.Forms.DataGridViewButtonColumn VideoUrlOwned;
        private System.Windows.Forms.DataGridViewButtonColumn WikipediaUrlOwned;
        private CheckBox chkSelectAll;
        private TextBox tbOwnedSearch;
        private Label lblOwnedSearch;
        private TextBox tbMissingSearch;
        private Label lblMissingSearch;
    }
}