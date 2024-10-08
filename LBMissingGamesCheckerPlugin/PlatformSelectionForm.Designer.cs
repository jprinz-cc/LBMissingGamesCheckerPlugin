﻿namespace LBMissingGamesCheckerPlugin
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle46 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle50 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle51 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle47 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle48 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle49 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle52 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle56 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle57 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle53 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle54 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle55 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlatformSelectionForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle58 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle59 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle60 = new System.Windows.Forms.DataGridViewCellStyle();
            this.platformDropdown = new System.Windows.Forms.ComboBox();
            this.confirmButton = new System.Windows.Forms.Button();
            this.ownedGamesGridView = new System.Windows.Forms.DataGridView();
            this.TitleOwned = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DeveloperOwned = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PublisherOwned = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RegionOwned = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReleaseDateOwned = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CommunityStarRatingOwned = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CommunityStarRatingTotalVotesOwned = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlatformOwned = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReleaseTypeOwned = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GenresOwned = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AlternateNamesOwned = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaxPlayersOwned = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LaunchBoxDbIdOwned = new System.Windows.Forms.DataGridViewButtonColumn();
            this.VideoUrlOwned = new System.Windows.Forms.DataGridViewButtonColumn();
            this.WikipediaUrlOwned = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ownedGamesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.missingGamesGridView = new System.Windows.Forms.DataGridView();
            this.TitleMissing = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DeveloperMissing = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PublisherMissing = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RegionMissing = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReleaseDateMissing = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CommunityStarRatingMissing = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CommunityStarRatingTotalVotesMissing = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlatformMissing = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReleaseTypeMissing = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GenresMissing = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AlternateNamesMissing = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaxPlayersMissing = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LaunchBoxDbIdMissing = new System.Windows.Forms.DataGridViewButtonColumn();
            this.VideoUrlMissing = new System.Windows.Forms.DataGridViewButtonColumn();
            this.WikipediaUrlMissing = new System.Windows.Forms.DataGridViewButtonColumn();
            this.missingGamesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lblDropdown = new System.Windows.Forms.Label();
            this.lblOwnedGamesGridView = new System.Windows.Forms.Label();
            this.lblMissingGamesGridView = new System.Windows.Forms.Label();
            this.lblOwnedGamesCount = new System.Windows.Forms.Label();
            this.lblMissingGamesCount = new System.Windows.Forms.Label();
            this.btnOwnedCSV = new System.Windows.Forms.Button();
            this.btnMissingCSV = new System.Windows.Forms.Button();
            this.gbOptional = new System.Windows.Forms.GroupBox();
            this.clbColumnSelection = new System.Windows.Forms.CheckedListBox();
            this.lblColumnSelection = new System.Windows.Forms.Label();
            this.chkReleasedOnly = new System.Windows.Forms.CheckBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnClose = new System.Windows.Forms.Button();
            this.llbPoweredBy = new System.Windows.Forms.LinkLabel();
            this.ssMetadataStatus = new System.Windows.Forms.StatusStrip();
            this.tsslIcon = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslText = new System.Windows.Forms.ToolStripStatusLabel();
            this.pbMetadataLoading = new LBMissingGamesCheckerPlugin.PlatformSelectionForm.ProgressBarEx();
            this.tbDebug = new System.Windows.Forms.TextBox();
            this.ssPlatformDropdownMsg = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslPlatformDropdownMsg = new System.Windows.Forms.ToolStripStatusLabel();
            this.pDebugLog = new System.Windows.Forms.Panel();
            this.btnClearDebugLog = new System.Windows.Forms.Button();
            this.btnCopyToClipboard = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCloseDebug = new System.Windows.Forms.Button();
            this.pbDebugHeader = new System.Windows.Forms.PictureBox();
            this.noPlatformGridView = new System.Windows.Forms.DataGridView();
            this.errorNoPlatform = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.msgNoPlatform = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.errorLBDbId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.noPlatformBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lblCongrats = new System.Windows.Forms.Label();
            this.lblScrapeAs = new System.Windows.Forms.Label();
            this.gbFilterOptions = new System.Windows.Forms.GroupBox();
            this.pbCloseFilter = new System.Windows.Forms.PictureBox();
            this.btnFilterReset = new System.Windows.Forms.Button();
            this.clbFilterOptions = new System.Windows.Forms.CheckedListBox();
            this.btnApplyFilters = new System.Windows.Forms.Button();
            this.pbCongrats = new System.Windows.Forms.PictureBox();
            this.pbSpinner = new System.Windows.Forms.PictureBox();
            this.pbDebugBtn = new System.Windows.Forms.PictureBox();
            this.pbMGCHeader = new System.Windows.Forms.PictureBox();
            this.pbMGCLogo = new System.Windows.Forms.PictureBox();
            this.lblPlatformWarning = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ownedGamesGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ownedGamesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.missingGamesGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.missingGamesBindingSource)).BeginInit();
            this.gbOptional.SuspendLayout();
            this.ssMetadataStatus.SuspendLayout();
            this.ssPlatformDropdownMsg.SuspendLayout();
            this.pDebugLog.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbDebugHeader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.noPlatformGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.noPlatformBindingSource)).BeginInit();
            this.gbFilterOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCloseFilter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCongrats)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSpinner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDebugBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMGCHeader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMGCLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // platformDropdown
            // 
            this.platformDropdown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.platformDropdown.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.platformDropdown.FormattingEnabled = true;
            this.platformDropdown.Items.AddRange(new object[] {
            "Select a Platform"});
            this.platformDropdown.Location = new System.Drawing.Point(21, 74);
            this.platformDropdown.Margin = new System.Windows.Forms.Padding(4);
            this.platformDropdown.Name = "platformDropdown";
            this.platformDropdown.Size = new System.Drawing.Size(292, 24);
            this.platformDropdown.TabIndex = 0;
            this.platformDropdown.SelectedIndexChanged += new System.EventHandler(this.PlatformDropdown_SelectedIndexChanged);
            // 
            // confirmButton
            // 
            this.confirmButton.Enabled = false;
            this.confirmButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.confirmButton.Location = new System.Drawing.Point(213, 105);
            this.confirmButton.Margin = new System.Windows.Forms.Padding(4);
            this.confirmButton.Name = "confirmButton";
            this.confirmButton.Size = new System.Drawing.Size(100, 28);
            this.confirmButton.TabIndex = 1;
            this.confirmButton.Text = "Check It!";
            this.confirmButton.UseVisualStyleBackColor = true;
            this.confirmButton.Click += new System.EventHandler(this.ConfirmButton_Click);
            // 
            // ownedGamesGridView
            // 
            this.ownedGamesGridView.AllowUserToAddRows = false;
            this.ownedGamesGridView.AllowUserToDeleteRows = false;
            this.ownedGamesGridView.AllowUserToOrderColumns = true;
            this.ownedGamesGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ownedGamesGridView.AutoGenerateColumns = false;
            this.ownedGamesGridView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(57)))), ((int)(((byte)(63)))));
            this.ownedGamesGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ownedGamesGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.ownedGamesGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle46.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle46.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(156)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle46.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle46.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle46.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle46.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ownedGamesGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle46;
            this.ownedGamesGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ownedGamesGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TitleOwned,
            this.DeveloperOwned,
            this.PublisherOwned,
            this.RegionOwned,
            this.ReleaseDateOwned,
            this.CommunityStarRatingOwned,
            this.CommunityStarRatingTotalVotesOwned,
            this.PlatformOwned,
            this.ReleaseTypeOwned,
            this.GenresOwned,
            this.AlternateNamesOwned,
            this.MaxPlayersOwned,
            this.LaunchBoxDbIdOwned,
            this.VideoUrlOwned,
            this.WikipediaUrlOwned});
            this.ownedGamesGridView.DataSource = this.ownedGamesBindingSource;
            dataGridViewCellStyle50.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle50.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(57)))), ((int)(((byte)(63)))));
            dataGridViewCellStyle50.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle50.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle50.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle50.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle50.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ownedGamesGridView.DefaultCellStyle = dataGridViewCellStyle50;
            this.ownedGamesGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.ownedGamesGridView.EnableHeadersVisualStyles = false;
            this.ownedGamesGridView.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(156)))), ((int)(((byte)(255)))));
            this.ownedGamesGridView.Location = new System.Drawing.Point(329, 112);
            this.ownedGamesGridView.Margin = new System.Windows.Forms.Padding(4);
            this.ownedGamesGridView.Name = "ownedGamesGridView";
            this.ownedGamesGridView.ReadOnly = true;
            this.ownedGamesGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle51.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle51.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(57)))), ((int)(((byte)(63)))));
            dataGridViewCellStyle51.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle51.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ownedGamesGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle51;
            this.ownedGamesGridView.RowHeadersWidth = 51;
            this.ownedGamesGridView.ShowEditingIcon = false;
            this.ownedGamesGridView.Size = new System.Drawing.Size(931, 185);
            this.ownedGamesGridView.TabIndex = 2;
            this.ownedGamesGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridView_CellContentClick);
            this.ownedGamesGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.GridView_CellFormatting);
            this.ownedGamesGridView.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridView_CellMouseEnter);
            this.ownedGamesGridView.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridView_CellMouseLeave);
            this.ownedGamesGridView.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.GridView_ColumnHeaderMouseClick);
            // 
            // TitleOwned
            // 
            this.TitleOwned.DataPropertyName = "Title";
            this.TitleOwned.HeaderText = "Title";
            this.TitleOwned.MinimumWidth = 6;
            this.TitleOwned.Name = "TitleOwned";
            this.TitleOwned.ReadOnly = true;
            this.TitleOwned.Width = 125;
            // 
            // DeveloperOwned
            // 
            this.DeveloperOwned.DataPropertyName = "Developer";
            this.DeveloperOwned.HeaderText = "Developer";
            this.DeveloperOwned.MinimumWidth = 6;
            this.DeveloperOwned.Name = "DeveloperOwned";
            this.DeveloperOwned.ReadOnly = true;
            this.DeveloperOwned.Width = 125;
            // 
            // PublisherOwned
            // 
            this.PublisherOwned.DataPropertyName = "Publisher";
            this.PublisherOwned.HeaderText = "Publisher";
            this.PublisherOwned.MinimumWidth = 6;
            this.PublisherOwned.Name = "PublisherOwned";
            this.PublisherOwned.ReadOnly = true;
            this.PublisherOwned.Width = 125;
            // 
            // RegionOwned
            // 
            this.RegionOwned.DataPropertyName = "Region";
            this.RegionOwned.HeaderText = "Region";
            this.RegionOwned.MinimumWidth = 6;
            this.RegionOwned.Name = "RegionOwned";
            this.RegionOwned.ReadOnly = true;
            this.RegionOwned.Width = 125;
            // 
            // ReleaseDateOwned
            // 
            this.ReleaseDateOwned.DataPropertyName = "ReleaseDate";
            this.ReleaseDateOwned.HeaderText = "ReleaseDate";
            this.ReleaseDateOwned.MinimumWidth = 6;
            this.ReleaseDateOwned.Name = "ReleaseDateOwned";
            this.ReleaseDateOwned.ReadOnly = true;
            this.ReleaseDateOwned.Width = 125;
            // 
            // CommunityStarRatingOwned
            // 
            this.CommunityStarRatingOwned.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.CommunityStarRatingOwned.DataPropertyName = "CommunityStarRating";
            this.CommunityStarRatingOwned.HeaderText = "CommunityStarRating";
            this.CommunityStarRatingOwned.MinimumWidth = 6;
            this.CommunityStarRatingOwned.Name = "CommunityStarRatingOwned";
            this.CommunityStarRatingOwned.ReadOnly = true;
            this.CommunityStarRatingOwned.Width = 173;
            // 
            // CommunityStarRatingTotalVotesOwned
            // 
            this.CommunityStarRatingTotalVotesOwned.DataPropertyName = "CommunityStarRatingTotalVotes";
            this.CommunityStarRatingTotalVotesOwned.HeaderText = "CommunityStarRatingTotalVotes";
            this.CommunityStarRatingTotalVotesOwned.MinimumWidth = 6;
            this.CommunityStarRatingTotalVotesOwned.Name = "CommunityStarRatingTotalVotesOwned";
            this.CommunityStarRatingTotalVotesOwned.ReadOnly = true;
            this.CommunityStarRatingTotalVotesOwned.Width = 125;
            // 
            // PlatformOwned
            // 
            this.PlatformOwned.DataPropertyName = "Platform";
            this.PlatformOwned.HeaderText = "Platform";
            this.PlatformOwned.MinimumWidth = 6;
            this.PlatformOwned.Name = "PlatformOwned";
            this.PlatformOwned.ReadOnly = true;
            this.PlatformOwned.Width = 125;
            // 
            // ReleaseTypeOwned
            // 
            this.ReleaseTypeOwned.DataPropertyName = "ReleaseType";
            this.ReleaseTypeOwned.HeaderText = "ReleaseType";
            this.ReleaseTypeOwned.MinimumWidth = 6;
            this.ReleaseTypeOwned.Name = "ReleaseTypeOwned";
            this.ReleaseTypeOwned.ReadOnly = true;
            this.ReleaseTypeOwned.Width = 125;
            // 
            // GenresOwned
            // 
            this.GenresOwned.DataPropertyName = "Genres";
            this.GenresOwned.HeaderText = "Genres";
            this.GenresOwned.MinimumWidth = 6;
            this.GenresOwned.Name = "GenresOwned";
            this.GenresOwned.ReadOnly = true;
            this.GenresOwned.Width = 125;
            // 
            // AlternateNamesOwned
            // 
            this.AlternateNamesOwned.DataPropertyName = "AlternateNames";
            this.AlternateNamesOwned.HeaderText = "AlternateNames";
            this.AlternateNamesOwned.MinimumWidth = 6;
            this.AlternateNamesOwned.Name = "AlternateNamesOwned";
            this.AlternateNamesOwned.ReadOnly = true;
            this.AlternateNamesOwned.Width = 125;
            // 
            // MaxPlayersOwned
            // 
            this.MaxPlayersOwned.DataPropertyName = "MaxPlayers";
            this.MaxPlayersOwned.HeaderText = "MaxPlayers";
            this.MaxPlayersOwned.MinimumWidth = 6;
            this.MaxPlayersOwned.Name = "MaxPlayersOwned";
            this.MaxPlayersOwned.ReadOnly = true;
            this.MaxPlayersOwned.Width = 125;
            // 
            // LaunchBoxDbIdOwned
            // 
            this.LaunchBoxDbIdOwned.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.LaunchBoxDbIdOwned.DataPropertyName = "LaunchBoxDbId";
            dataGridViewCellStyle47.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle47.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(191)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle47.Font = new System.Drawing.Font("Arial", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle47.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle47.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            dataGridViewCellStyle47.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(57)))), ((int)(((byte)(63)))));
            dataGridViewCellStyle47.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(191)))), ((int)(((byte)(0)))));
            this.LaunchBoxDbIdOwned.DefaultCellStyle = dataGridViewCellStyle47;
            this.LaunchBoxDbIdOwned.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.LaunchBoxDbIdOwned.HeaderText = "LaunchBoxDbId";
            this.LaunchBoxDbIdOwned.MinimumWidth = 6;
            this.LaunchBoxDbIdOwned.Name = "LaunchBoxDbIdOwned";
            this.LaunchBoxDbIdOwned.ReadOnly = true;
            this.LaunchBoxDbIdOwned.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.LaunchBoxDbIdOwned.Text = "";
            this.LaunchBoxDbIdOwned.Width = 136;
            // 
            // VideoUrlOwned
            // 
            this.VideoUrlOwned.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.VideoUrlOwned.DataPropertyName = "VideoUrl";
            dataGridViewCellStyle48.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle48.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(191)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle48.Font = new System.Drawing.Font("Arial", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle48.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle48.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            dataGridViewCellStyle48.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(57)))), ((int)(((byte)(63)))));
            dataGridViewCellStyle48.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(191)))), ((int)(((byte)(0)))));
            this.VideoUrlOwned.DefaultCellStyle = dataGridViewCellStyle48;
            this.VideoUrlOwned.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.VideoUrlOwned.HeaderText = "VideoUrl";
            this.VideoUrlOwned.MinimumWidth = 6;
            this.VideoUrlOwned.Name = "VideoUrlOwned";
            this.VideoUrlOwned.ReadOnly = true;
            this.VideoUrlOwned.Text = "";
            this.VideoUrlOwned.Width = 68;
            // 
            // WikipediaUrlOwned
            // 
            this.WikipediaUrlOwned.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.WikipediaUrlOwned.DataPropertyName = "WikipediaUrl";
            dataGridViewCellStyle49.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle49.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(191)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle49.Font = new System.Drawing.Font("Arial", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle49.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle49.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            dataGridViewCellStyle49.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(57)))), ((int)(((byte)(63)))));
            dataGridViewCellStyle49.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(191)))), ((int)(((byte)(0)))));
            this.WikipediaUrlOwned.DefaultCellStyle = dataGridViewCellStyle49;
            this.WikipediaUrlOwned.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.WikipediaUrlOwned.HeaderText = "WikipediaUrl";
            this.WikipediaUrlOwned.MinimumWidth = 6;
            this.WikipediaUrlOwned.Name = "WikipediaUrlOwned";
            this.WikipediaUrlOwned.ReadOnly = true;
            this.WikipediaUrlOwned.Text = "";
            this.WikipediaUrlOwned.Width = 93;
            // 
            // missingGamesGridView
            // 
            this.missingGamesGridView.AllowUserToAddRows = false;
            this.missingGamesGridView.AllowUserToDeleteRows = false;
            this.missingGamesGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.missingGamesGridView.AutoGenerateColumns = false;
            this.missingGamesGridView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(57)))), ((int)(((byte)(63)))));
            this.missingGamesGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.missingGamesGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.missingGamesGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle52.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle52.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(156)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle52.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle52.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle52.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.missingGamesGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle52;
            this.missingGamesGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.missingGamesGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TitleMissing,
            this.DeveloperMissing,
            this.PublisherMissing,
            this.RegionMissing,
            this.ReleaseDateMissing,
            this.CommunityStarRatingMissing,
            this.CommunityStarRatingTotalVotesMissing,
            this.PlatformMissing,
            this.ReleaseTypeMissing,
            this.GenresMissing,
            this.AlternateNamesMissing,
            this.MaxPlayersMissing,
            this.LaunchBoxDbIdMissing,
            this.VideoUrlMissing,
            this.WikipediaUrlMissing});
            this.missingGamesGridView.DataSource = this.missingGamesBindingSource;
            dataGridViewCellStyle56.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle56.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(57)))), ((int)(((byte)(63)))));
            dataGridViewCellStyle56.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle56.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle56.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle56.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle56.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.missingGamesGridView.DefaultCellStyle = dataGridViewCellStyle56;
            this.missingGamesGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.missingGamesGridView.EnableHeadersVisualStyles = false;
            this.missingGamesGridView.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(156)))), ((int)(((byte)(255)))));
            this.missingGamesGridView.Location = new System.Drawing.Point(329, 343);
            this.missingGamesGridView.Margin = new System.Windows.Forms.Padding(4);
            this.missingGamesGridView.Name = "missingGamesGridView";
            this.missingGamesGridView.ReadOnly = true;
            this.missingGamesGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle57.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle57.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(57)))), ((int)(((byte)(63)))));
            dataGridViewCellStyle57.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle57.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.missingGamesGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle57;
            this.missingGamesGridView.RowHeadersWidth = 51;
            this.missingGamesGridView.Size = new System.Drawing.Size(931, 231);
            this.missingGamesGridView.TabIndex = 3;
            this.missingGamesGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridView_CellContentClick);
            this.missingGamesGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.GridView_CellFormatting);
            this.missingGamesGridView.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridView_CellMouseEnter);
            this.missingGamesGridView.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridView_CellMouseLeave);
            this.missingGamesGridView.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.GridView_ColumnHeaderMouseClick);
            // 
            // TitleMissing
            // 
            this.TitleMissing.DataPropertyName = "Title";
            this.TitleMissing.HeaderText = "Title";
            this.TitleMissing.MinimumWidth = 6;
            this.TitleMissing.Name = "TitleMissing";
            this.TitleMissing.ReadOnly = true;
            this.TitleMissing.Width = 125;
            // 
            // DeveloperMissing
            // 
            this.DeveloperMissing.DataPropertyName = "Developer";
            this.DeveloperMissing.HeaderText = "Developer";
            this.DeveloperMissing.MinimumWidth = 6;
            this.DeveloperMissing.Name = "DeveloperMissing";
            this.DeveloperMissing.ReadOnly = true;
            this.DeveloperMissing.Width = 125;
            // 
            // PublisherMissing
            // 
            this.PublisherMissing.DataPropertyName = "Publisher";
            this.PublisherMissing.HeaderText = "Publisher";
            this.PublisherMissing.MinimumWidth = 6;
            this.PublisherMissing.Name = "PublisherMissing";
            this.PublisherMissing.ReadOnly = true;
            this.PublisherMissing.Width = 125;
            // 
            // RegionMissing
            // 
            this.RegionMissing.DataPropertyName = "Region";
            this.RegionMissing.HeaderText = "Region";
            this.RegionMissing.MinimumWidth = 6;
            this.RegionMissing.Name = "RegionMissing";
            this.RegionMissing.ReadOnly = true;
            this.RegionMissing.Width = 125;
            // 
            // ReleaseDateMissing
            // 
            this.ReleaseDateMissing.DataPropertyName = "ReleaseDate";
            this.ReleaseDateMissing.HeaderText = "ReleaseDate";
            this.ReleaseDateMissing.MinimumWidth = 6;
            this.ReleaseDateMissing.Name = "ReleaseDateMissing";
            this.ReleaseDateMissing.ReadOnly = true;
            this.ReleaseDateMissing.Width = 125;
            // 
            // CommunityStarRatingMissing
            // 
            this.CommunityStarRatingMissing.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.CommunityStarRatingMissing.DataPropertyName = "CommunityStarRating";
            this.CommunityStarRatingMissing.HeaderText = "CommunityStarRating";
            this.CommunityStarRatingMissing.MinimumWidth = 6;
            this.CommunityStarRatingMissing.Name = "CommunityStarRatingMissing";
            this.CommunityStarRatingMissing.ReadOnly = true;
            this.CommunityStarRatingMissing.Width = 173;
            // 
            // CommunityStarRatingTotalVotesMissing
            // 
            this.CommunityStarRatingTotalVotesMissing.DataPropertyName = "CommunityStarRatingTotalVotes";
            this.CommunityStarRatingTotalVotesMissing.HeaderText = "CommunityStarRatingTotalVotes";
            this.CommunityStarRatingTotalVotesMissing.MinimumWidth = 6;
            this.CommunityStarRatingTotalVotesMissing.Name = "CommunityStarRatingTotalVotesMissing";
            this.CommunityStarRatingTotalVotesMissing.ReadOnly = true;
            this.CommunityStarRatingTotalVotesMissing.Width = 125;
            // 
            // PlatformMissing
            // 
            this.PlatformMissing.DataPropertyName = "Platform";
            this.PlatformMissing.HeaderText = "Platform";
            this.PlatformMissing.MinimumWidth = 6;
            this.PlatformMissing.Name = "PlatformMissing";
            this.PlatformMissing.ReadOnly = true;
            this.PlatformMissing.Width = 125;
            // 
            // ReleaseTypeMissing
            // 
            this.ReleaseTypeMissing.DataPropertyName = "ReleaseType";
            this.ReleaseTypeMissing.HeaderText = "ReleaseType";
            this.ReleaseTypeMissing.MinimumWidth = 6;
            this.ReleaseTypeMissing.Name = "ReleaseTypeMissing";
            this.ReleaseTypeMissing.ReadOnly = true;
            this.ReleaseTypeMissing.Width = 125;
            // 
            // GenresMissing
            // 
            this.GenresMissing.DataPropertyName = "Genres";
            this.GenresMissing.HeaderText = "Genres";
            this.GenresMissing.MinimumWidth = 6;
            this.GenresMissing.Name = "GenresMissing";
            this.GenresMissing.ReadOnly = true;
            this.GenresMissing.Width = 125;
            // 
            // AlternateNamesMissing
            // 
            this.AlternateNamesMissing.DataPropertyName = "AlternateNames";
            this.AlternateNamesMissing.HeaderText = "AlternateNames";
            this.AlternateNamesMissing.MinimumWidth = 6;
            this.AlternateNamesMissing.Name = "AlternateNamesMissing";
            this.AlternateNamesMissing.ReadOnly = true;
            this.AlternateNamesMissing.Width = 125;
            // 
            // MaxPlayersMissing
            // 
            this.MaxPlayersMissing.DataPropertyName = "MaxPlayers";
            this.MaxPlayersMissing.HeaderText = "MaxPlayers";
            this.MaxPlayersMissing.MinimumWidth = 6;
            this.MaxPlayersMissing.Name = "MaxPlayersMissing";
            this.MaxPlayersMissing.ReadOnly = true;
            this.MaxPlayersMissing.Width = 125;
            // 
            // LaunchBoxDbIdMissing
            // 
            this.LaunchBoxDbIdMissing.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.LaunchBoxDbIdMissing.DataPropertyName = "LaunchBoxDbId";
            dataGridViewCellStyle53.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle53.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(191)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle53.Font = new System.Drawing.Font("Arial", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle53.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle53.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(57)))), ((int)(((byte)(63)))));
            dataGridViewCellStyle53.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(191)))), ((int)(((byte)(0)))));
            this.LaunchBoxDbIdMissing.DefaultCellStyle = dataGridViewCellStyle53;
            this.LaunchBoxDbIdMissing.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.LaunchBoxDbIdMissing.HeaderText = "LaunchBoxDbId";
            this.LaunchBoxDbIdMissing.MinimumWidth = 6;
            this.LaunchBoxDbIdMissing.Name = "LaunchBoxDbIdMissing";
            this.LaunchBoxDbIdMissing.ReadOnly = true;
            this.LaunchBoxDbIdMissing.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.LaunchBoxDbIdMissing.Text = "";
            this.LaunchBoxDbIdMissing.Width = 136;
            // 
            // VideoUrlMissing
            // 
            this.VideoUrlMissing.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.VideoUrlMissing.DataPropertyName = "VideoUrl";
            dataGridViewCellStyle54.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle54.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(191)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle54.Font = new System.Drawing.Font("Arial", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle54.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle54.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(57)))), ((int)(((byte)(63)))));
            dataGridViewCellStyle54.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(191)))), ((int)(((byte)(0)))));
            this.VideoUrlMissing.DefaultCellStyle = dataGridViewCellStyle54;
            this.VideoUrlMissing.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.VideoUrlMissing.HeaderText = "VideoUrl";
            this.VideoUrlMissing.MinimumWidth = 6;
            this.VideoUrlMissing.Name = "VideoUrlMissing";
            this.VideoUrlMissing.ReadOnly = true;
            this.VideoUrlMissing.Text = "";
            this.VideoUrlMissing.Width = 68;
            // 
            // WikipediaUrlMissing
            // 
            this.WikipediaUrlMissing.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.WikipediaUrlMissing.DataPropertyName = "WikipediaUrl";
            dataGridViewCellStyle55.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle55.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(191)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle55.Font = new System.Drawing.Font("Arial", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle55.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle55.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(57)))), ((int)(((byte)(63)))));
            dataGridViewCellStyle55.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(191)))), ((int)(((byte)(0)))));
            this.WikipediaUrlMissing.DefaultCellStyle = dataGridViewCellStyle55;
            this.WikipediaUrlMissing.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.WikipediaUrlMissing.HeaderText = "WikipediaUrl";
            this.WikipediaUrlMissing.MinimumWidth = 6;
            this.WikipediaUrlMissing.Name = "WikipediaUrlMissing";
            this.WikipediaUrlMissing.ReadOnly = true;
            this.WikipediaUrlMissing.Text = "";
            this.WikipediaUrlMissing.Width = 93;
            // 
            // lblDropdown
            // 
            this.lblDropdown.AutoSize = true;
            this.lblDropdown.BackColor = System.Drawing.Color.Transparent;
            this.lblDropdown.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDropdown.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.lblDropdown.Location = new System.Drawing.Point(16, 46);
            this.lblDropdown.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDropdown.Name = "lblDropdown";
            this.lblDropdown.Size = new System.Drawing.Size(235, 25);
            this.lblDropdown.TabIndex = 4;
            this.lblDropdown.Text = "Select a platform to check";
            // 
            // lblOwnedGamesGridView
            // 
            this.lblOwnedGamesGridView.AutoSize = true;
            this.lblOwnedGamesGridView.BackColor = System.Drawing.Color.Transparent;
            this.lblOwnedGamesGridView.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOwnedGamesGridView.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.lblOwnedGamesGridView.Location = new System.Drawing.Point(325, 90);
            this.lblOwnedGamesGridView.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOwnedGamesGridView.Name = "lblOwnedGamesGridView";
            this.lblOwnedGamesGridView.Size = new System.Drawing.Size(183, 18);
            this.lblOwnedGamesGridView.TabIndex = 5;
            this.lblOwnedGamesGridView.Text = "Owned Games List Count:";
            // 
            // lblMissingGamesGridView
            // 
            this.lblMissingGamesGridView.AutoSize = true;
            this.lblMissingGamesGridView.BackColor = System.Drawing.Color.Transparent;
            this.lblMissingGamesGridView.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMissingGamesGridView.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.lblMissingGamesGridView.Location = new System.Drawing.Point(325, 321);
            this.lblMissingGamesGridView.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMissingGamesGridView.Name = "lblMissingGamesGridView";
            this.lblMissingGamesGridView.Size = new System.Drawing.Size(187, 18);
            this.lblMissingGamesGridView.TabIndex = 6;
            this.lblMissingGamesGridView.Text = "Missing Games List Count:";
            // 
            // lblOwnedGamesCount
            // 
            this.lblOwnedGamesCount.AutoSize = true;
            this.lblOwnedGamesCount.BackColor = System.Drawing.Color.Transparent;
            this.lblOwnedGamesCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOwnedGamesCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.lblOwnedGamesCount.Location = new System.Drawing.Point(532, 90);
            this.lblOwnedGamesCount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOwnedGamesCount.Name = "lblOwnedGamesCount";
            this.lblOwnedGamesCount.Size = new System.Drawing.Size(16, 18);
            this.lblOwnedGamesCount.TabIndex = 7;
            this.lblOwnedGamesCount.Text = "0";
            // 
            // lblMissingGamesCount
            // 
            this.lblMissingGamesCount.AutoSize = true;
            this.lblMissingGamesCount.BackColor = System.Drawing.Color.Transparent;
            this.lblMissingGamesCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMissingGamesCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.lblMissingGamesCount.Location = new System.Drawing.Point(537, 321);
            this.lblMissingGamesCount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMissingGamesCount.Name = "lblMissingGamesCount";
            this.lblMissingGamesCount.Size = new System.Drawing.Size(16, 18);
            this.lblMissingGamesCount.TabIndex = 8;
            this.lblMissingGamesCount.Text = "0";
            // 
            // btnOwnedCSV
            // 
            this.btnOwnedCSV.Enabled = false;
            this.btnOwnedCSV.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOwnedCSV.Location = new System.Drawing.Point(1135, 81);
            this.btnOwnedCSV.Margin = new System.Windows.Forms.Padding(4);
            this.btnOwnedCSV.Name = "btnOwnedCSV";
            this.btnOwnedCSV.Size = new System.Drawing.Size(113, 25);
            this.btnOwnedCSV.TabIndex = 9;
            this.btnOwnedCSV.Text = "Export to CSV";
            this.btnOwnedCSV.UseVisualStyleBackColor = true;
            this.btnOwnedCSV.Click += new System.EventHandler(this.ExportOwnedGamesButton_Click);
            // 
            // btnMissingCSV
            // 
            this.btnMissingCSV.Enabled = false;
            this.btnMissingCSV.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMissingCSV.Location = new System.Drawing.Point(1135, 313);
            this.btnMissingCSV.Margin = new System.Windows.Forms.Padding(4);
            this.btnMissingCSV.Name = "btnMissingCSV";
            this.btnMissingCSV.Size = new System.Drawing.Size(113, 25);
            this.btnMissingCSV.TabIndex = 10;
            this.btnMissingCSV.Text = "Export to CSV";
            this.btnMissingCSV.UseVisualStyleBackColor = true;
            this.btnMissingCSV.Click += new System.EventHandler(this.ExportMissingGamesButton_Click);
            // 
            // gbOptional
            // 
            this.gbOptional.Controls.Add(this.clbColumnSelection);
            this.gbOptional.Controls.Add(this.lblColumnSelection);
            this.gbOptional.Controls.Add(this.chkReleasedOnly);
            this.gbOptional.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(191)))), ((int)(((byte)(0)))));
            this.gbOptional.Location = new System.Drawing.Point(28, 159);
            this.gbOptional.Margin = new System.Windows.Forms.Padding(4, 4, 4, 0);
            this.gbOptional.Name = "gbOptional";
            this.gbOptional.Padding = new System.Windows.Forms.Padding(4);
            this.gbOptional.Size = new System.Drawing.Size(272, 336);
            this.gbOptional.TabIndex = 11;
            this.gbOptional.TabStop = false;
            this.gbOptional.Text = "Optional Items";
            // 
            // clbColumnSelection
            // 
            this.clbColumnSelection.CheckOnClick = true;
            this.clbColumnSelection.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.clbColumnSelection.FormattingEnabled = true;
            this.clbColumnSelection.Location = new System.Drawing.Point(4, 73);
            this.clbColumnSelection.Margin = new System.Windows.Forms.Padding(4, 1, 4, 2);
            this.clbColumnSelection.Name = "clbColumnSelection";
            this.clbColumnSelection.Size = new System.Drawing.Size(264, 259);
            this.clbColumnSelection.TabIndex = 1;
            this.clbColumnSelection.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.CheckedListBox_ItemCheck);
            // 
            // lblColumnSelection
            // 
            this.lblColumnSelection.AutoSize = true;
            this.lblColumnSelection.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(191)))), ((int)(((byte)(0)))));
            this.lblColumnSelection.Location = new System.Drawing.Point(8, 62);
            this.lblColumnSelection.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblColumnSelection.Name = "lblColumnSelection";
            this.lblColumnSelection.Size = new System.Drawing.Size(111, 16);
            this.lblColumnSelection.TabIndex = 2;
            this.lblColumnSelection.Text = "Column Selection";
            // 
            // chkReleasedOnly
            // 
            this.chkReleasedOnly.AutoSize = true;
            this.chkReleasedOnly.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(191)))), ((int)(((byte)(0)))));
            this.chkReleasedOnly.Location = new System.Drawing.Point(13, 26);
            this.chkReleasedOnly.Margin = new System.Windows.Forms.Padding(4);
            this.chkReleasedOnly.Name = "chkReleasedOnly";
            this.chkReleasedOnly.Size = new System.Drawing.Size(210, 20);
            this.chkReleasedOnly.TabIndex = 0;
            this.chkReleasedOnly.Text = "Only include Released games";
            this.chkReleasedOnly.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(130)))), ((int)(((byte)(200)))));
            this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Navy;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(191)))), ((int)(((byte)(0)))));
            this.btnClose.Location = new System.Drawing.Point(1131, 14);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(129, 36);
            this.btnClose.TabIndex = 13;
            this.btnClose.Text = "Close MGC";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.FormClose_Click);
            // 
            // llbPoweredBy
            // 
            this.llbPoweredBy.ActiveLinkColor = System.Drawing.Color.MidnightBlue;
            this.llbPoweredBy.AutoSize = true;
            this.llbPoweredBy.BackColor = System.Drawing.Color.Transparent;
            this.llbPoweredBy.Cursor = System.Windows.Forms.Cursors.Default;
            this.llbPoweredBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llbPoweredBy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(191)))), ((int)(((byte)(0)))));
            this.llbPoweredBy.LinkBehavior = System.Windows.Forms.LinkBehavior.AlwaysUnderline;
            this.llbPoweredBy.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(191)))), ((int)(((byte)(0)))));
            this.llbPoweredBy.Location = new System.Drawing.Point(24, 566);
            this.llbPoweredBy.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.llbPoweredBy.Name = "llbPoweredBy";
            this.llbPoweredBy.Size = new System.Drawing.Size(183, 15);
            this.llbPoweredBy.TabIndex = 16;
            this.llbPoweredBy.TabStop = true;
            this.llbPoweredBy.Text = "MGC Powered by AgentJohnnyP";
            this.llbPoweredBy.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(191)))), ((int)(((byte)(0)))));
            this.llbPoweredBy.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.PoweredBy_LinkClicked);
            // 
            // ssMetadataStatus
            // 
            this.ssMetadataStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ssMetadataStatus.AutoSize = false;
            this.ssMetadataStatus.BackColor = System.Drawing.Color.Transparent;
            this.ssMetadataStatus.Dock = System.Windows.Forms.DockStyle.None;
            this.ssMetadataStatus.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ssMetadataStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslIcon,
            this.tsslText});
            this.ssMetadataStatus.Location = new System.Drawing.Point(28, 495);
            this.ssMetadataStatus.Name = "ssMetadataStatus";
            this.ssMetadataStatus.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.ssMetadataStatus.Size = new System.Drawing.Size(273, 32);
            this.ssMetadataStatus.SizingGrip = false;
            this.ssMetadataStatus.TabIndex = 19;
            // 
            // tsslIcon
            // 
            this.tsslIcon.Image = ((System.Drawing.Image)(resources.GetObject("tsslIcon.Image")));
            this.tsslIcon.Name = "tsslIcon";
            this.tsslIcon.Padding = new System.Windows.Forms.Padding(5, 0, 0, 5);
            this.tsslIcon.Size = new System.Drawing.Size(25, 26);
            // 
            // tsslText
            // 
            this.tsslText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(191)))), ((int)(((byte)(0)))));
            this.tsslText.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tsslText.ForeColor = System.Drawing.Color.Black;
            this.tsslText.Name = "tsslText";
            this.tsslText.Padding = new System.Windows.Forms.Padding(10, 0, 0, 5);
            this.tsslText.Size = new System.Drawing.Size(182, 26);
            this.tsslText.Text = "Preparing Environment....";
            // 
            // pbMetadataLoading
            // 
            this.pbMetadataLoading.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(57)))), ((int)(((byte)(63)))));
            this.pbMetadataLoading.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(173)))), ((int)(((byte)(255)))));
            this.pbMetadataLoading.Location = new System.Drawing.Point(28, 532);
            this.pbMetadataLoading.Margin = new System.Windows.Forms.Padding(4);
            this.pbMetadataLoading.MarqueeAnimationSpeed = 50;
            this.pbMetadataLoading.Name = "pbMetadataLoading";
            this.pbMetadataLoading.Size = new System.Drawing.Size(287, 26);
            this.pbMetadataLoading.TabIndex = 20;
            this.pbMetadataLoading.Visible = false;
            // 
            // tbDebug
            // 
            this.tbDebug.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(57)))), ((int)(((byte)(63)))));
            this.tbDebug.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(191)))), ((int)(((byte)(0)))));
            this.tbDebug.Location = new System.Drawing.Point(3, 53);
            this.tbDebug.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbDebug.MaxLength = 15000;
            this.tbDebug.Multiline = true;
            this.tbDebug.Name = "tbDebug";
            this.tbDebug.ReadOnly = true;
            this.tbDebug.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbDebug.Size = new System.Drawing.Size(711, 224);
            this.tbDebug.TabIndex = 21;
            this.tbDebug.Text = "Debug Log";
            // 
            // ssPlatformDropdownMsg
            // 
            this.ssPlatformDropdownMsg.AutoSize = false;
            this.ssPlatformDropdownMsg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(191)))), ((int)(((byte)(0)))));
            this.ssPlatformDropdownMsg.Dock = System.Windows.Forms.DockStyle.None;
            this.ssPlatformDropdownMsg.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ssPlatformDropdownMsg.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.tsslPlatformDropdownMsg});
            this.ssPlatformDropdownMsg.Location = new System.Drawing.Point(0, 0);
            this.ssPlatformDropdownMsg.Name = "ssPlatformDropdownMsg";
            this.ssPlatformDropdownMsg.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.ssPlatformDropdownMsg.Size = new System.Drawing.Size(293, 32);
            this.ssPlatformDropdownMsg.SizingGrip = false;
            this.ssPlatformDropdownMsg.TabIndex = 23;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripStatusLabel1.Image")));
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Padding = new System.Windows.Forms.Padding(5, 0, 0, 5);
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(25, 26);
            // 
            // tsslPlatformDropdownMsg
            // 
            this.tsslPlatformDropdownMsg.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tsslPlatformDropdownMsg.ForeColor = System.Drawing.Color.Black;
            this.tsslPlatformDropdownMsg.Name = "tsslPlatformDropdownMsg";
            this.tsslPlatformDropdownMsg.Padding = new System.Windows.Forms.Padding(10, 0, 0, 5);
            this.tsslPlatformDropdownMsg.Size = new System.Drawing.Size(205, 26);
            this.tsslPlatformDropdownMsg.Text = "Please select a platform!";
            // 
            // pDebugLog
            // 
            this.pDebugLog.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pDebugLog.Controls.Add(this.tbDebug);
            this.pDebugLog.Controls.Add(this.btnClearDebugLog);
            this.pDebugLog.Controls.Add(this.btnCopyToClipboard);
            this.pDebugLog.Controls.Add(this.label1);
            this.pDebugLog.Controls.Add(this.btnCloseDebug);
            this.pDebugLog.Controls.Add(this.pbDebugHeader);
            this.pDebugLog.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(191)))), ((int)(((byte)(0)))));
            this.pDebugLog.Location = new System.Drawing.Point(433, 212);
            this.pDebugLog.Margin = new System.Windows.Forms.Padding(4);
            this.pDebugLog.Name = "pDebugLog";
            this.pDebugLog.Size = new System.Drawing.Size(723, 285);
            this.pDebugLog.TabIndex = 24;
            // 
            // btnClearDebugLog
            // 
            this.btnClearDebugLog.BackColor = System.Drawing.Color.Transparent;
            this.btnClearDebugLog.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnClearDebugLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearDebugLog.ForeColor = System.Drawing.Color.Black;
            this.btnClearDebugLog.Location = new System.Drawing.Point(412, 12);
            this.btnClearDebugLog.Margin = new System.Windows.Forms.Padding(4);
            this.btnClearDebugLog.Name = "btnClearDebugLog";
            this.btnClearDebugLog.Size = new System.Drawing.Size(108, 26);
            this.btnClearDebugLog.TabIndex = 26;
            this.btnClearDebugLog.Text = "Clear Debug Log";
            this.btnClearDebugLog.UseVisualStyleBackColor = false;
            this.btnClearDebugLog.Click += new System.EventHandler(this.ClearDebugLog_Click);
            // 
            // btnCopyToClipboard
            // 
            this.btnCopyToClipboard.BackColor = System.Drawing.Color.Transparent;
            this.btnCopyToClipboard.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnCopyToClipboard.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCopyToClipboard.ForeColor = System.Drawing.Color.Black;
            this.btnCopyToClipboard.Location = new System.Drawing.Point(276, 12);
            this.btnCopyToClipboard.Margin = new System.Windows.Forms.Padding(4);
            this.btnCopyToClipboard.Name = "btnCopyToClipboard";
            this.btnCopyToClipboard.Size = new System.Drawing.Size(119, 26);
            this.btnCopyToClipboard.TabIndex = 25;
            this.btnCopyToClipboard.Text = "Copy To Clipboard";
            this.btnCopyToClipboard.UseVisualStyleBackColor = false;
            this.btnCopyToClipboard.Click += new System.EventHandler(this.CopyToClipboard_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(65, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(193, 29);
            this.label1.TabIndex = 24;
            this.label1.Text = "MGC Debug Log";
            // 
            // btnCloseDebug
            // 
            this.btnCloseDebug.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnCloseDebug.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(130)))), ((int)(((byte)(200)))));
            this.btnCloseDebug.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.btnCloseDebug.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Navy;
            this.btnCloseDebug.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCloseDebug.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCloseDebug.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(191)))), ((int)(((byte)(0)))));
            this.btnCloseDebug.Location = new System.Drawing.Point(563, 5);
            this.btnCloseDebug.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCloseDebug.Name = "btnCloseDebug";
            this.btnCloseDebug.Size = new System.Drawing.Size(152, 34);
            this.btnCloseDebug.TabIndex = 23;
            this.btnCloseDebug.Text = "Close Debug Log";
            this.btnCloseDebug.UseVisualStyleBackColor = false;
            this.btnCloseDebug.Click += new System.EventHandler(this.CloseDebug_Click);
            // 
            // pbDebugHeader
            // 
            this.pbDebugHeader.BackColor = System.Drawing.Color.Transparent;
            this.pbDebugHeader.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbDebugHeader.BackgroundImage")));
            this.pbDebugHeader.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbDebugHeader.Location = new System.Drawing.Point(5, 5);
            this.pbDebugHeader.Margin = new System.Windows.Forms.Padding(4);
            this.pbDebugHeader.Name = "pbDebugHeader";
            this.pbDebugHeader.Size = new System.Drawing.Size(52, 44);
            this.pbDebugHeader.TabIndex = 22;
            this.pbDebugHeader.TabStop = false;
            // 
            // noPlatformGridView
            // 
            this.noPlatformGridView.AllowUserToAddRows = false;
            this.noPlatformGridView.AllowUserToDeleteRows = false;
            this.noPlatformGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.noPlatformGridView.AutoGenerateColumns = false;
            this.noPlatformGridView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(57)))), ((int)(((byte)(63)))));
            this.noPlatformGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.noPlatformGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.noPlatformGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle58.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle58.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(191)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle58.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle58.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle58.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(191)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle58.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.noPlatformGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle58;
            this.noPlatformGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.noPlatformGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.errorNoPlatform,
            this.msgNoPlatform,
            this.errorLBDbId});
            this.noPlatformGridView.DataSource = this.noPlatformBindingSource;
            dataGridViewCellStyle59.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle59.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(57)))), ((int)(((byte)(63)))));
            dataGridViewCellStyle59.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle59.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(191)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle59.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(191)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle59.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(57)))), ((int)(((byte)(63)))));
            dataGridViewCellStyle59.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.noPlatformGridView.DefaultCellStyle = dataGridViewCellStyle59;
            this.noPlatformGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.noPlatformGridView.EnableHeadersVisualStyles = false;
            this.noPlatformGridView.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(156)))), ((int)(((byte)(255)))));
            this.noPlatformGridView.Location = new System.Drawing.Point(329, 343);
            this.noPlatformGridView.Margin = new System.Windows.Forms.Padding(4);
            this.noPlatformGridView.Name = "noPlatformGridView";
            this.noPlatformGridView.ReadOnly = true;
            this.noPlatformGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle60.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle60.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(57)))), ((int)(((byte)(63)))));
            dataGridViewCellStyle60.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle60.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.noPlatformGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle60;
            this.noPlatformGridView.RowHeadersWidth = 51;
            this.noPlatformGridView.Size = new System.Drawing.Size(931, 231);
            this.noPlatformGridView.TabIndex = 25;
            // 
            // errorNoPlatform
            // 
            this.errorNoPlatform.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.errorNoPlatform.DataPropertyName = "Title";
            this.errorNoPlatform.HeaderText = "Error";
            this.errorNoPlatform.MinimumWidth = 6;
            this.errorNoPlatform.Name = "errorNoPlatform";
            this.errorNoPlatform.ReadOnly = true;
            this.errorNoPlatform.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.errorNoPlatform.Width = 46;
            // 
            // msgNoPlatform
            // 
            this.msgNoPlatform.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.msgNoPlatform.DataPropertyName = "Platform";
            this.msgNoPlatform.HeaderText = "Message";
            this.msgNoPlatform.MinimumWidth = 6;
            this.msgNoPlatform.Name = "msgNoPlatform";
            this.msgNoPlatform.ReadOnly = true;
            this.msgNoPlatform.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.msgNoPlatform.Width = 71;
            // 
            // errorLBDbId
            // 
            this.errorLBDbId.DataPropertyName = "LaunchBoxDbId";
            this.errorLBDbId.HeaderText = "LaunchBoxDbId";
            this.errorLBDbId.MinimumWidth = 6;
            this.errorLBDbId.Name = "errorLBDbId";
            this.errorLBDbId.ReadOnly = true;
            this.errorLBDbId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.errorLBDbId.Visible = false;
            this.errorLBDbId.Width = 125;
            // 
            // lblCongrats
            // 
            this.lblCongrats.AutoSize = true;
            this.lblCongrats.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(191)))), ((int)(((byte)(0)))));
            this.lblCongrats.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCongrats.Location = new System.Drawing.Point(629, 311);
            this.lblCongrats.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCongrats.Name = "lblCongrats";
            this.lblCongrats.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.lblCongrats.Size = new System.Drawing.Size(331, 24);
            this.lblCongrats.TabIndex = 27;
            this.lblCongrats.Text = "Congrats! Your collection is complete!";
            // 
            // lblScrapeAs
            // 
            this.lblScrapeAs.AutoSize = true;
            this.lblScrapeAs.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScrapeAs.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(191)))), ((int)(((byte)(0)))));
            this.lblScrapeAs.Location = new System.Drawing.Point(20, 26);
            this.lblScrapeAs.Name = "lblScrapeAs";
            this.lblScrapeAs.Size = new System.Drawing.Size(100, 17);
            this.lblScrapeAs.TabIndex = 28;
            this.lblScrapeAs.Text = "Searching As: ";
            // 
            // gbFilterOptions
            // 
            this.gbFilterOptions.AutoSize = true;
            this.gbFilterOptions.Controls.Add(this.pbCloseFilter);
            this.gbFilterOptions.Controls.Add(this.btnFilterReset);
            this.gbFilterOptions.Controls.Add(this.clbFilterOptions);
            this.gbFilterOptions.Controls.Add(this.btnApplyFilters);
            this.gbFilterOptions.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(191)))), ((int)(((byte)(0)))));
            this.gbFilterOptions.Location = new System.Drawing.Point(308, 143);
            this.gbFilterOptions.Margin = new System.Windows.Forms.Padding(4);
            this.gbFilterOptions.Name = "gbFilterOptions";
            this.gbFilterOptions.Padding = new System.Windows.Forms.Padding(4);
            this.gbFilterOptions.Size = new System.Drawing.Size(197, 197);
            this.gbFilterOptions.TabIndex = 29;
            this.gbFilterOptions.TabStop = false;
            this.gbFilterOptions.Text = "Filter";
            // 
            // pbCloseFilter
            // 
            this.pbCloseFilter.AccessibleDescription = "Close Filter Window";
            this.pbCloseFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbCloseFilter.BackColor = System.Drawing.Color.Transparent;
            this.pbCloseFilter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbCloseFilter.Image = global::LBMissingGamesCheckerPlugin.Properties.Resources.error;
            this.pbCloseFilter.Location = new System.Drawing.Point(172, 12);
            this.pbCloseFilter.Margin = new System.Windows.Forms.Padding(0);
            this.pbCloseFilter.Name = "pbCloseFilter";
            this.pbCloseFilter.Size = new System.Drawing.Size(17, 16);
            this.pbCloseFilter.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbCloseFilter.TabIndex = 3;
            this.pbCloseFilter.TabStop = false;
            this.pbCloseFilter.Click += new System.EventHandler(this.CloseFilter_Click);
            // 
            // btnFilterReset
            // 
            this.btnFilterReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFilterReset.ForeColor = System.Drawing.Color.Black;
            this.btnFilterReset.Location = new System.Drawing.Point(79, 21);
            this.btnFilterReset.Margin = new System.Windows.Forms.Padding(4);
            this.btnFilterReset.Name = "btnFilterReset";
            this.btnFilterReset.Size = new System.Drawing.Size(63, 26);
            this.btnFilterReset.TabIndex = 2;
            this.btnFilterReset.Text = "Reset";
            this.btnFilterReset.UseVisualStyleBackColor = true;
            this.btnFilterReset.Click += new System.EventHandler(this.FilterReset_Click);
            // 
            // clbFilterOptions
            // 
            this.clbFilterOptions.CheckOnClick = true;
            this.clbFilterOptions.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.clbFilterOptions.FormattingEnabled = true;
            this.clbFilterOptions.Location = new System.Drawing.Point(4, 53);
            this.clbFilterOptions.Margin = new System.Windows.Forms.Padding(4);
            this.clbFilterOptions.Name = "clbFilterOptions";
            this.clbFilterOptions.Size = new System.Drawing.Size(189, 140);
            this.clbFilterOptions.Sorted = true;
            this.clbFilterOptions.TabIndex = 1;
            this.clbFilterOptions.ThreeDCheckBoxes = true;
            // 
            // btnApplyFilters
            // 
            this.btnApplyFilters.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApplyFilters.ForeColor = System.Drawing.Color.Black;
            this.btnApplyFilters.Location = new System.Drawing.Point(8, 21);
            this.btnApplyFilters.Margin = new System.Windows.Forms.Padding(4);
            this.btnApplyFilters.Name = "btnApplyFilters";
            this.btnApplyFilters.Size = new System.Drawing.Size(63, 26);
            this.btnApplyFilters.TabIndex = 0;
            this.btnApplyFilters.Text = "Apply";
            this.btnApplyFilters.UseVisualStyleBackColor = true;
            this.btnApplyFilters.Click += new System.EventHandler(this.ApplyFilters_Click);
            // 
            // pbCongrats
            // 
            this.pbCongrats.Image = global::LBMissingGamesCheckerPlugin.Properties.Resources.congrats;
            this.pbCongrats.Location = new System.Drawing.Point(565, 366);
            this.pbCongrats.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pbCongrats.Name = "pbCongrats";
            this.pbCongrats.Size = new System.Drawing.Size(457, 185);
            this.pbCongrats.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbCongrats.TabIndex = 3;
            this.pbCongrats.TabStop = false;
            // 
            // pbSpinner
            // 
            this.pbSpinner.BackColor = System.Drawing.Color.Transparent;
            this.pbSpinner.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbSpinner.Image = global::LBMissingGamesCheckerPlugin.Properties.Resources.mgc_spinner;
            this.pbSpinner.Location = new System.Drawing.Point(593, 366);
            this.pbSpinner.Margin = new System.Windows.Forms.Padding(4);
            this.pbSpinner.Name = "pbSpinner";
            this.pbSpinner.Size = new System.Drawing.Size(403, 188);
            this.pbSpinner.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbSpinner.TabIndex = 26;
            this.pbSpinner.TabStop = false;
            // 
            // pbDebugBtn
            // 
            this.pbDebugBtn.BackColor = System.Drawing.Color.Transparent;
            this.pbDebugBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbDebugBtn.BackgroundImage")));
            this.pbDebugBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbDebugBtn.Cursor = System.Windows.Forms.Cursors.Help;
            this.pbDebugBtn.Location = new System.Drawing.Point(288, 564);
            this.pbDebugBtn.Margin = new System.Windows.Forms.Padding(4);
            this.pbDebugBtn.Name = "pbDebugBtn";
            this.pbDebugBtn.Size = new System.Drawing.Size(27, 25);
            this.pbDebugBtn.TabIndex = 24;
            this.pbDebugBtn.TabStop = false;
            this.pbDebugBtn.Click += new System.EventHandler(this.DebugBtn_Click);
            // 
            // pbMGCHeader
            // 
            this.pbMGCHeader.BackColor = System.Drawing.Color.Transparent;
            this.pbMGCHeader.Image = global::LBMissingGamesCheckerPlugin.Properties.Resources.mgc_header;
            this.pbMGCHeader.Location = new System.Drawing.Point(481, -1);
            this.pbMGCHeader.Margin = new System.Windows.Forms.Padding(4);
            this.pbMGCHeader.Name = "pbMGCHeader";
            this.pbMGCHeader.Size = new System.Drawing.Size(628, 119);
            this.pbMGCHeader.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbMGCHeader.TabIndex = 15;
            this.pbMGCHeader.TabStop = false;
            this.pbMGCHeader.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PlatformSelectionForm_MouseDown);
            // 
            // pbMGCLogo
            // 
            this.pbMGCLogo.BackColor = System.Drawing.Color.Transparent;
            this.pbMGCLogo.Image = global::LBMissingGamesCheckerPlugin.Properties.Resources.mgc_logo;
            this.pbMGCLogo.Location = new System.Drawing.Point(376, 14);
            this.pbMGCLogo.Margin = new System.Windows.Forms.Padding(4);
            this.pbMGCLogo.Name = "pbMGCLogo";
            this.pbMGCLogo.Size = new System.Drawing.Size(97, 73);
            this.pbMGCLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbMGCLogo.TabIndex = 14;
            this.pbMGCLogo.TabStop = false;
            this.pbMGCLogo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PlatformSelectionForm_MouseDown);
            // 
            // lblPlatformWarning
            // 
            this.lblPlatformWarning.AutoSize = true;
            this.lblPlatformWarning.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(191)))), ((int)(((byte)(0)))));
            this.lblPlatformWarning.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlatformWarning.ForeColor = System.Drawing.Color.Black;
            this.lblPlatformWarning.Location = new System.Drawing.Point(0, 105);
            this.lblPlatformWarning.Name = "lblPlatformWarning";
            this.lblPlatformWarning.Padding = new System.Windows.Forms.Padding(2);
            this.lblPlatformWarning.Size = new System.Drawing.Size(196, 49);
            this.lblPlatformWarning.TabIndex = 30;
            this.lblPlatformWarning.Text = "Warning! This platform contains\r\na lot of data! Processing may take \r\na few momen" +
    "ts!";
            // 
            // PlatformSelectionForm
            // 
            this.AccessibleDescription = "A LaunchBox plugin designed to help users identify missing games in their collect" +
    "ion based on platform metadata.";
            this.AccessibleName = "Missing Games Checker";
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(57)))), ((int)(((byte)(63)))));
            this.ClientSize = new System.Drawing.Size(1275, 590);
            this.ControlBox = false;
            this.Controls.Add(this.lblPlatformWarning);
            this.Controls.Add(this.gbFilterOptions);
            this.Controls.Add(this.pbCongrats);
            this.Controls.Add(this.pbSpinner);
            this.Controls.Add(this.lblScrapeAs);
            this.Controls.Add(this.pDebugLog);
            this.Controls.Add(this.noPlatformGridView);
            this.Controls.Add(this.missingGamesGridView);
            this.Controls.Add(this.ssPlatformDropdownMsg);
            this.Controls.Add(this.pbMetadataLoading);
            this.Controls.Add(this.pbDebugBtn);
            this.Controls.Add(this.ssMetadataStatus);
            this.Controls.Add(this.llbPoweredBy);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.gbOptional);
            this.Controls.Add(this.btnMissingCSV);
            this.Controls.Add(this.btnOwnedCSV);
            this.Controls.Add(this.lblMissingGamesCount);
            this.Controls.Add(this.lblOwnedGamesCount);
            this.Controls.Add(this.lblMissingGamesGridView);
            this.Controls.Add(this.lblOwnedGamesGridView);
            this.Controls.Add(this.lblDropdown);
            this.Controls.Add(this.ownedGamesGridView);
            this.Controls.Add(this.confirmButton);
            this.Controls.Add(this.platformDropdown);
            this.Controls.Add(this.pbMGCHeader);
            this.Controls.Add(this.pbMGCLogo);
            this.Controls.Add(this.lblCongrats);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(1275, 590);
            this.Name = "PlatformSelectionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Missing Games Checker";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PlatformSelectionForm_FormClosing);
            this.Load += new System.EventHandler(this.PlatformSelectionForm_Load);
            this.Shown += new System.EventHandler(this.PlatformSelectionForm_Shown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PlatformSelectionForm_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.ownedGamesGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ownedGamesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.missingGamesGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.missingGamesBindingSource)).EndInit();
            this.gbOptional.ResumeLayout(false);
            this.gbOptional.PerformLayout();
            this.ssMetadataStatus.ResumeLayout(false);
            this.ssMetadataStatus.PerformLayout();
            this.ssPlatformDropdownMsg.ResumeLayout(false);
            this.ssPlatformDropdownMsg.PerformLayout();
            this.pDebugLog.ResumeLayout(false);
            this.pDebugLog.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbDebugHeader)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.noPlatformGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.noPlatformBindingSource)).EndInit();
            this.gbFilterOptions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbCloseFilter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCongrats)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSpinner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDebugBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMGCHeader)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMGCLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private ProgressBarEx pbMetadataLoading;
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
        private System.Windows.Forms.Label lblPlatformWarning;
    }
}