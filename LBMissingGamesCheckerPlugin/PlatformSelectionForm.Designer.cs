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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.platformDropdown = new System.Windows.Forms.ComboBox();
            this.confirmButton = new System.Windows.Forms.Button();
            this.ownedGamesGridView = new System.Windows.Forms.DataGridView();
            this.ownedGamesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.missingGamesGridView = new System.Windows.Forms.DataGridView();
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
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pbDebugBtn = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pbMGCLogo = new System.Windows.Forms.PictureBox();
            this.noPlatformGridView = new System.Windows.Forms.DataGridView();
            this.errorNoPlatform = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.msgNoPlatform = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.errorLBDbId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.noPlatformBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pbSpinner = new System.Windows.Forms.PictureBox();
            this.lblCongrats = new System.Windows.Forms.Label();
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
            ((System.ComponentModel.ISupportInitialize)(this.ownedGamesGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ownedGamesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.missingGamesGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.missingGamesBindingSource)).BeginInit();
            this.gbOptional.SuspendLayout();
            this.ssMetadataStatus.SuspendLayout();
            this.ssPlatformDropdownMsg.SuspendLayout();
            this.pDebugLog.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDebugBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMGCLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.noPlatformGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.noPlatformBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSpinner)).BeginInit();
            this.SuspendLayout();
            // 
            // platformDropdown
            // 
            this.platformDropdown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.platformDropdown.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.platformDropdown.FormattingEnabled = true;
            this.platformDropdown.Items.AddRange(new object[] {
            "Select a Platform"});
            this.platformDropdown.Location = new System.Drawing.Point(16, 60);
            this.platformDropdown.Name = "platformDropdown";
            this.platformDropdown.Size = new System.Drawing.Size(220, 21);
            this.platformDropdown.TabIndex = 0;
            // 
            // confirmButton
            // 
            this.confirmButton.Enabled = false;
            this.confirmButton.Location = new System.Drawing.Point(124, 87);
            this.confirmButton.Name = "confirmButton";
            this.confirmButton.Size = new System.Drawing.Size(112, 23);
            this.confirmButton.TabIndex = 1;
            this.confirmButton.Text = "Confirm Selection";
            this.confirmButton.UseVisualStyleBackColor = true;
            this.confirmButton.Click += new System.EventHandler(this.ConfirmButton_Click);
            // 
            // ownedGamesGridView
            // 
            this.ownedGamesGridView.AllowUserToAddRows = false;
            this.ownedGamesGridView.AllowUserToDeleteRows = false;
            this.ownedGamesGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ownedGamesGridView.AutoGenerateColumns = false;
            this.ownedGamesGridView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(57)))), ((int)(((byte)(63)))));
            this.ownedGamesGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ownedGamesGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.ownedGamesGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(156)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ownedGamesGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
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
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(57)))), ((int)(((byte)(63)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ownedGamesGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.ownedGamesGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.ownedGamesGridView.EnableHeadersVisualStyles = false;
            this.ownedGamesGridView.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(156)))), ((int)(((byte)(255)))));
            this.ownedGamesGridView.Location = new System.Drawing.Point(247, 91);
            this.ownedGamesGridView.Name = "ownedGamesGridView";
            this.ownedGamesGridView.ReadOnly = true;
            this.ownedGamesGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(57)))), ((int)(((byte)(63)))));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ownedGamesGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.ownedGamesGridView.RowHeadersWidth = 51;
            this.ownedGamesGridView.ShowEditingIcon = false;
            this.ownedGamesGridView.Size = new System.Drawing.Size(698, 150);
            this.ownedGamesGridView.TabIndex = 2;
            this.ownedGamesGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridView_CellContentClick);
            this.ownedGamesGridView.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.GridView_ColumnHeaderMouseClick);
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
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(156)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.missingGamesGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
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
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(57)))), ((int)(((byte)(63)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.missingGamesGridView.DefaultCellStyle = dataGridViewCellStyle5;
            this.missingGamesGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.missingGamesGridView.EnableHeadersVisualStyles = false;
            this.missingGamesGridView.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(156)))), ((int)(((byte)(255)))));
            this.missingGamesGridView.Location = new System.Drawing.Point(247, 279);
            this.missingGamesGridView.Name = "missingGamesGridView";
            this.missingGamesGridView.ReadOnly = true;
            this.missingGamesGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(57)))), ((int)(((byte)(63)))));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.missingGamesGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.missingGamesGridView.RowHeadersWidth = 51;
            this.missingGamesGridView.Size = new System.Drawing.Size(698, 188);
            this.missingGamesGridView.TabIndex = 3;
            this.missingGamesGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridView_CellContentClick);
            this.missingGamesGridView.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.GridView_ColumnHeaderMouseClick);
            // 
            // lblDropdown
            // 
            this.lblDropdown.AutoSize = true;
            this.lblDropdown.BackColor = System.Drawing.Color.Transparent;
            this.lblDropdown.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDropdown.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.lblDropdown.Location = new System.Drawing.Point(12, 37);
            this.lblDropdown.Name = "lblDropdown";
            this.lblDropdown.Size = new System.Drawing.Size(193, 20);
            this.lblDropdown.TabIndex = 4;
            this.lblDropdown.Text = "Select a platform to check";
            // 
            // lblOwnedGamesGridView
            // 
            this.lblOwnedGamesGridView.AutoSize = true;
            this.lblOwnedGamesGridView.BackColor = System.Drawing.Color.Transparent;
            this.lblOwnedGamesGridView.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOwnedGamesGridView.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.lblOwnedGamesGridView.Location = new System.Drawing.Point(244, 73);
            this.lblOwnedGamesGridView.Name = "lblOwnedGamesGridView";
            this.lblOwnedGamesGridView.Size = new System.Drawing.Size(149, 15);
            this.lblOwnedGamesGridView.TabIndex = 5;
            this.lblOwnedGamesGridView.Text = "Owned Games List Count:";
            // 
            // lblMissingGamesGridView
            // 
            this.lblMissingGamesGridView.AutoSize = true;
            this.lblMissingGamesGridView.BackColor = System.Drawing.Color.Transparent;
            this.lblMissingGamesGridView.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMissingGamesGridView.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.lblMissingGamesGridView.Location = new System.Drawing.Point(244, 261);
            this.lblMissingGamesGridView.Name = "lblMissingGamesGridView";
            this.lblMissingGamesGridView.Size = new System.Drawing.Size(153, 15);
            this.lblMissingGamesGridView.TabIndex = 6;
            this.lblMissingGamesGridView.Text = "Missing Games List Count:";
            // 
            // lblOwnedGamesCount
            // 
            this.lblOwnedGamesCount.AutoSize = true;
            this.lblOwnedGamesCount.BackColor = System.Drawing.Color.Transparent;
            this.lblOwnedGamesCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOwnedGamesCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.lblOwnedGamesCount.Location = new System.Drawing.Point(399, 73);
            this.lblOwnedGamesCount.Name = "lblOwnedGamesCount";
            this.lblOwnedGamesCount.Size = new System.Drawing.Size(14, 15);
            this.lblOwnedGamesCount.TabIndex = 7;
            this.lblOwnedGamesCount.Text = "0";
            // 
            // lblMissingGamesCount
            // 
            this.lblMissingGamesCount.AutoSize = true;
            this.lblMissingGamesCount.BackColor = System.Drawing.Color.Transparent;
            this.lblMissingGamesCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMissingGamesCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.lblMissingGamesCount.Location = new System.Drawing.Point(403, 261);
            this.lblMissingGamesCount.Name = "lblMissingGamesCount";
            this.lblMissingGamesCount.Size = new System.Drawing.Size(14, 15);
            this.lblMissingGamesCount.TabIndex = 8;
            this.lblMissingGamesCount.Text = "0";
            // 
            // btnOwnedCSV
            // 
            this.btnOwnedCSV.Enabled = false;
            this.btnOwnedCSV.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOwnedCSV.Location = new System.Drawing.Point(851, 66);
            this.btnOwnedCSV.Name = "btnOwnedCSV";
            this.btnOwnedCSV.Size = new System.Drawing.Size(85, 20);
            this.btnOwnedCSV.TabIndex = 9;
            this.btnOwnedCSV.Text = "Export to CSV";
            this.btnOwnedCSV.UseVisualStyleBackColor = true;
            this.btnOwnedCSV.Click += new System.EventHandler(this.ExportOwnedGamesButton_Click);
            // 
            // btnMissingCSV
            // 
            this.btnMissingCSV.Enabled = false;
            this.btnMissingCSV.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMissingCSV.Location = new System.Drawing.Point(851, 254);
            this.btnMissingCSV.Name = "btnMissingCSV";
            this.btnMissingCSV.Size = new System.Drawing.Size(85, 20);
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
            this.gbOptional.Location = new System.Drawing.Point(21, 116);
            this.gbOptional.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.gbOptional.Name = "gbOptional";
            this.gbOptional.Size = new System.Drawing.Size(204, 279);
            this.gbOptional.TabIndex = 11;
            this.gbOptional.TabStop = false;
            this.gbOptional.Text = "Optional Items";
            // 
            // clbColumnSelection
            // 
            this.clbColumnSelection.CheckOnClick = true;
            this.clbColumnSelection.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.clbColumnSelection.FormattingEnabled = true;
            this.clbColumnSelection.Location = new System.Drawing.Point(3, 62);
            this.clbColumnSelection.Margin = new System.Windows.Forms.Padding(3, 3, 3, 2);
            this.clbColumnSelection.Name = "clbColumnSelection";
            this.clbColumnSelection.Size = new System.Drawing.Size(198, 214);
            this.clbColumnSelection.TabIndex = 1;
            this.clbColumnSelection.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.CheckedListBox_ItemCheck);
            // 
            // lblColumnSelection
            // 
            this.lblColumnSelection.AutoSize = true;
            this.lblColumnSelection.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(191)))), ((int)(((byte)(0)))));
            this.lblColumnSelection.Location = new System.Drawing.Point(6, 47);
            this.lblColumnSelection.Name = "lblColumnSelection";
            this.lblColumnSelection.Size = new System.Drawing.Size(89, 13);
            this.lblColumnSelection.TabIndex = 2;
            this.lblColumnSelection.Text = "Column Selection";
            // 
            // chkReleasedOnly
            // 
            this.chkReleasedOnly.AutoSize = true;
            this.chkReleasedOnly.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(191)))), ((int)(((byte)(0)))));
            this.chkReleasedOnly.Location = new System.Drawing.Point(10, 21);
            this.chkReleasedOnly.Name = "chkReleasedOnly";
            this.chkReleasedOnly.Size = new System.Drawing.Size(166, 17);
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
            this.btnClose.Location = new System.Drawing.Point(848, 11);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(97, 29);
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
            this.llbPoweredBy.Location = new System.Drawing.Point(18, 460);
            this.llbPoweredBy.Name = "llbPoweredBy";
            this.llbPoweredBy.Size = new System.Drawing.Size(162, 13);
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
            this.ssMetadataStatus.Location = new System.Drawing.Point(21, 402);
            this.ssMetadataStatus.Name = "ssMetadataStatus";
            this.ssMetadataStatus.Size = new System.Drawing.Size(205, 26);
            this.ssMetadataStatus.SizingGrip = false;
            this.ssMetadataStatus.TabIndex = 19;
            // 
            // tsslIcon
            // 
            this.tsslIcon.Image = global::LBMissingGamesCheckerPlugin.Properties.Resources.warning;
            this.tsslIcon.Name = "tsslIcon";
            this.tsslIcon.Padding = new System.Windows.Forms.Padding(5, 0, 0, 5);
            this.tsslIcon.Size = new System.Drawing.Size(25, 21);
            // 
            // tsslText
            // 
            this.tsslText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(191)))), ((int)(((byte)(0)))));
            this.tsslText.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tsslText.ForeColor = System.Drawing.Color.Black;
            this.tsslText.Name = "tsslText";
            this.tsslText.Padding = new System.Windows.Forms.Padding(10, 0, 0, 5);
            this.tsslText.Size = new System.Drawing.Size(151, 21);
            this.tsslText.Text = "Preparing Environment....";
            // 
            // pbMetadataLoading
            // 
            this.pbMetadataLoading.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(57)))), ((int)(((byte)(63)))));
            this.pbMetadataLoading.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(173)))), ((int)(((byte)(255)))));
            this.pbMetadataLoading.Location = new System.Drawing.Point(21, 432);
            this.pbMetadataLoading.MarqueeAnimationSpeed = 50;
            this.pbMetadataLoading.Name = "pbMetadataLoading";
            this.pbMetadataLoading.Size = new System.Drawing.Size(215, 21);
            this.pbMetadataLoading.TabIndex = 20;
            this.pbMetadataLoading.Visible = false;
            // 
            // tbDebug
            // 
            this.tbDebug.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(57)))), ((int)(((byte)(63)))));
            this.tbDebug.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(191)))), ((int)(((byte)(0)))));
            this.tbDebug.Location = new System.Drawing.Point(2, 43);
            this.tbDebug.Margin = new System.Windows.Forms.Padding(2);
            this.tbDebug.MaxLength = 15000;
            this.tbDebug.Multiline = true;
            this.tbDebug.Name = "tbDebug";
            this.tbDebug.ReadOnly = true;
            this.tbDebug.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbDebug.Size = new System.Drawing.Size(534, 183);
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
            this.ssPlatformDropdownMsg.Size = new System.Drawing.Size(220, 26);
            this.ssPlatformDropdownMsg.SizingGrip = false;
            this.ssPlatformDropdownMsg.TabIndex = 23;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Image = global::LBMissingGamesCheckerPlugin.Properties.Resources.warning;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Padding = new System.Windows.Forms.Padding(5, 0, 0, 5);
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(25, 21);
            // 
            // tsslPlatformDropdownMsg
            // 
            this.tsslPlatformDropdownMsg.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tsslPlatformDropdownMsg.ForeColor = System.Drawing.Color.Black;
            this.tsslPlatformDropdownMsg.Name = "tsslPlatformDropdownMsg";
            this.tsslPlatformDropdownMsg.Padding = new System.Windows.Forms.Padding(10, 0, 0, 5);
            this.tsslPlatformDropdownMsg.Size = new System.Drawing.Size(166, 21);
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
            this.pDebugLog.Controls.Add(this.pictureBox2);
            this.pDebugLog.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(191)))), ((int)(((byte)(0)))));
            this.pDebugLog.Location = new System.Drawing.Point(320, 172);
            this.pDebugLog.Name = "pDebugLog";
            this.pDebugLog.Size = new System.Drawing.Size(543, 232);
            this.pDebugLog.TabIndex = 24;
            // 
            // btnClearDebugLog
            // 
            this.btnClearDebugLog.BackColor = System.Drawing.Color.Transparent;
            this.btnClearDebugLog.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnClearDebugLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearDebugLog.ForeColor = System.Drawing.Color.Black;
            this.btnClearDebugLog.Location = new System.Drawing.Point(309, 10);
            this.btnClearDebugLog.Name = "btnClearDebugLog";
            this.btnClearDebugLog.Size = new System.Drawing.Size(81, 21);
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
            this.btnCopyToClipboard.Location = new System.Drawing.Point(207, 10);
            this.btnCopyToClipboard.Name = "btnCopyToClipboard";
            this.btnCopyToClipboard.Size = new System.Drawing.Size(89, 21);
            this.btnCopyToClipboard.TabIndex = 25;
            this.btnCopyToClipboard.Text = "Copy To Clipboard";
            this.btnCopyToClipboard.UseVisualStyleBackColor = false;
            this.btnCopyToClipboard.Click += new System.EventHandler(this.CopyToClipboard_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(49, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 24);
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
            this.btnCloseDebug.Location = new System.Drawing.Point(422, 4);
            this.btnCloseDebug.Margin = new System.Windows.Forms.Padding(2);
            this.btnCloseDebug.Name = "btnCloseDebug";
            this.btnCloseDebug.Size = new System.Drawing.Size(114, 28);
            this.btnCloseDebug.TabIndex = 23;
            this.btnCloseDebug.Text = "Close Debug Log";
            this.btnCloseDebug.UseVisualStyleBackColor = false;
            this.btnCloseDebug.Click += new System.EventHandler(this.CloseDebug_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.BackgroundImage = global::LBMissingGamesCheckerPlugin.Properties.Resources.debug;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Location = new System.Drawing.Point(4, 4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(39, 36);
            this.pictureBox2.TabIndex = 22;
            this.pictureBox2.TabStop = false;
            // 
            // pbDebugBtn
            // 
            this.pbDebugBtn.BackColor = System.Drawing.Color.Transparent;
            this.pbDebugBtn.BackgroundImage = global::LBMissingGamesCheckerPlugin.Properties.Resources.debug;
            this.pbDebugBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbDebugBtn.Cursor = System.Windows.Forms.Cursors.Help;
            this.pbDebugBtn.Location = new System.Drawing.Point(216, 458);
            this.pbDebugBtn.Name = "pbDebugBtn";
            this.pbDebugBtn.Size = new System.Drawing.Size(20, 20);
            this.pbDebugBtn.TabIndex = 24;
            this.pbDebugBtn.TabStop = false;
            this.pbDebugBtn.Click += new System.EventHandler(this.DebugBtn_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::LBMissingGamesCheckerPlugin.Properties.Resources.mgc_header;
            this.pictureBox1.Location = new System.Drawing.Point(361, -1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(471, 97);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PlatformSelectionForm_MouseDown);
            // 
            // pbMGCLogo
            // 
            this.pbMGCLogo.BackColor = System.Drawing.Color.Transparent;
            this.pbMGCLogo.Image = global::LBMissingGamesCheckerPlugin.Properties.Resources.mgc_logo;
            this.pbMGCLogo.Location = new System.Drawing.Point(282, 11);
            this.pbMGCLogo.Name = "pbMGCLogo";
            this.pbMGCLogo.Size = new System.Drawing.Size(73, 59);
            this.pbMGCLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbMGCLogo.TabIndex = 14;
            this.pbMGCLogo.TabStop = false;
            this.pbMGCLogo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PlatformSelectionForm_MouseDown);
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
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(191)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(191)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.noPlatformGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.noPlatformGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.noPlatformGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.errorNoPlatform,
            this.msgNoPlatform,
            this.errorLBDbId});
            this.noPlatformGridView.DataSource = this.noPlatformBindingSource;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(57)))), ((int)(((byte)(63)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(191)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(191)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(57)))), ((int)(((byte)(63)))));
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.noPlatformGridView.DefaultCellStyle = dataGridViewCellStyle8;
            this.noPlatformGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.noPlatformGridView.EnableHeadersVisualStyles = false;
            this.noPlatformGridView.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(156)))), ((int)(((byte)(255)))));
            this.noPlatformGridView.Location = new System.Drawing.Point(247, 279);
            this.noPlatformGridView.Name = "noPlatformGridView";
            this.noPlatformGridView.ReadOnly = true;
            this.noPlatformGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(57)))), ((int)(((byte)(63)))));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.noPlatformGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.noPlatformGridView.RowHeadersWidth = 51;
            this.noPlatformGridView.Size = new System.Drawing.Size(698, 188);
            this.noPlatformGridView.TabIndex = 25;
            // 
            // errorNoPlatform
            // 
            this.errorNoPlatform.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.errorNoPlatform.DataPropertyName = "Title";
            this.errorNoPlatform.HeaderText = "Error";
            this.errorNoPlatform.Name = "errorNoPlatform";
            this.errorNoPlatform.ReadOnly = true;
            this.errorNoPlatform.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.errorNoPlatform.Width = 35;
            // 
            // msgNoPlatform
            // 
            this.msgNoPlatform.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.msgNoPlatform.DataPropertyName = "Platform";
            this.msgNoPlatform.HeaderText = "Message";
            this.msgNoPlatform.Name = "msgNoPlatform";
            this.msgNoPlatform.ReadOnly = true;
            this.msgNoPlatform.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.msgNoPlatform.Width = 56;
            // 
            // errorLBDbId
            // 
            this.errorLBDbId.DataPropertyName = "LaunchBoxDbId";
            this.errorLBDbId.HeaderText = "LaunchBoxDbId";
            this.errorLBDbId.Name = "errorLBDbId";
            this.errorLBDbId.ReadOnly = true;
            this.errorLBDbId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.errorLBDbId.Visible = false;
            // 
            // pbSpinner
            // 
            this.pbSpinner.BackColor = System.Drawing.Color.Transparent;
            this.pbSpinner.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbSpinner.Image = global::LBMissingGamesCheckerPlugin.Properties.Resources.mgc_spinner;
            this.pbSpinner.Location = new System.Drawing.Point(460, 310);
            this.pbSpinner.Name = "pbSpinner";
            this.pbSpinner.Size = new System.Drawing.Size(240, 131);
            this.pbSpinner.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbSpinner.TabIndex = 26;
            this.pbSpinner.TabStop = false;
            // 
            // lblCongrats
            // 
            this.lblCongrats.AutoSize = true;
            this.lblCongrats.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(191)))), ((int)(((byte)(0)))));
            this.lblCongrats.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCongrats.Location = new System.Drawing.Point(444, 253);
            this.lblCongrats.Name = "lblCongrats";
            this.lblCongrats.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.lblCongrats.Size = new System.Drawing.Size(281, 21);
            this.lblCongrats.TabIndex = 27;
            this.lblCongrats.Text = "Congrats! Your collection is complete!";
            // 
            // TitleOwned
            // 
            this.TitleOwned.DataPropertyName = "Title";
            this.TitleOwned.HeaderText = "Title";
            this.TitleOwned.Name = "TitleOwned";
            this.TitleOwned.ReadOnly = true;
            // 
            // DeveloperOwned
            // 
            this.DeveloperOwned.DataPropertyName = "Developer";
            this.DeveloperOwned.HeaderText = "Developer";
            this.DeveloperOwned.Name = "DeveloperOwned";
            this.DeveloperOwned.ReadOnly = true;
            // 
            // PublisherOwned
            // 
            this.PublisherOwned.DataPropertyName = "Publisher";
            this.PublisherOwned.HeaderText = "Publisher";
            this.PublisherOwned.Name = "PublisherOwned";
            this.PublisherOwned.ReadOnly = true;
            // 
            // RegionOwned
            // 
            this.RegionOwned.DataPropertyName = "Region";
            this.RegionOwned.HeaderText = "Region";
            this.RegionOwned.Name = "RegionOwned";
            this.RegionOwned.ReadOnly = true;
            // 
            // ReleaseDateOwned
            // 
            this.ReleaseDateOwned.DataPropertyName = "ReleaseDate";
            this.ReleaseDateOwned.HeaderText = "ReleaseDate";
            this.ReleaseDateOwned.Name = "ReleaseDateOwned";
            this.ReleaseDateOwned.ReadOnly = true;
            // 
            // CommunityStarRatingOwned
            // 
            this.CommunityStarRatingOwned.DataPropertyName = "CommunityStarRating";
            this.CommunityStarRatingOwned.HeaderText = "CommunityStarRating";
            this.CommunityStarRatingOwned.Name = "CommunityStarRatingOwned";
            this.CommunityStarRatingOwned.ReadOnly = true;
            // 
            // CommunityStarRatingTotalVotesOwned
            // 
            this.CommunityStarRatingTotalVotesOwned.DataPropertyName = "CommunityStarRatingTotalVotes";
            this.CommunityStarRatingTotalVotesOwned.HeaderText = "CommunityStarRatingTotalVotes";
            this.CommunityStarRatingTotalVotesOwned.Name = "CommunityStarRatingTotalVotesOwned";
            this.CommunityStarRatingTotalVotesOwned.ReadOnly = true;
            // 
            // PlatformOwned
            // 
            this.PlatformOwned.DataPropertyName = "Platform";
            this.PlatformOwned.HeaderText = "Platform";
            this.PlatformOwned.Name = "PlatformOwned";
            this.PlatformOwned.ReadOnly = true;
            // 
            // ReleaseTypeOwned
            // 
            this.ReleaseTypeOwned.DataPropertyName = "ReleaseType";
            this.ReleaseTypeOwned.HeaderText = "ReleaseType";
            this.ReleaseTypeOwned.Name = "ReleaseTypeOwned";
            this.ReleaseTypeOwned.ReadOnly = true;
            // 
            // GenresOwned
            // 
            this.GenresOwned.DataPropertyName = "Genres";
            this.GenresOwned.HeaderText = "Genres";
            this.GenresOwned.Name = "GenresOwned";
            this.GenresOwned.ReadOnly = true;
            // 
            // AlternateNamesOwned
            // 
            this.AlternateNamesOwned.DataPropertyName = "AlternateNames";
            this.AlternateNamesOwned.HeaderText = "AlternateNames";
            this.AlternateNamesOwned.Name = "AlternateNamesOwned";
            this.AlternateNamesOwned.ReadOnly = true;
            // 
            // MaxPlayersOwned
            // 
            this.MaxPlayersOwned.DataPropertyName = "MaxPlayers";
            this.MaxPlayersOwned.HeaderText = "MaxPlayers";
            this.MaxPlayersOwned.Name = "MaxPlayersOwned";
            this.MaxPlayersOwned.ReadOnly = true;
            // 
            // LaunchBoxDbIdOwned
            // 
            this.LaunchBoxDbIdOwned.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.LaunchBoxDbIdOwned.DataPropertyName = "LaunchBoxDbId";
            this.LaunchBoxDbIdOwned.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.LaunchBoxDbIdOwned.HeaderText = "LaunchBoxDbId";
            this.LaunchBoxDbIdOwned.Name = "LaunchBoxDbIdOwned";
            this.LaunchBoxDbIdOwned.ReadOnly = true;
            this.LaunchBoxDbIdOwned.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.LaunchBoxDbIdOwned.Text = "LaunchBoxDB #";
            this.LaunchBoxDbIdOwned.Width = 109;
            // 
            // VideoUrlOwned
            // 
            this.VideoUrlOwned.DataPropertyName = "VideoUrl";
            this.VideoUrlOwned.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.VideoUrlOwned.HeaderText = "VideoUrl";
            this.VideoUrlOwned.Name = "VideoUrlOwned";
            this.VideoUrlOwned.ReadOnly = true;
            this.VideoUrlOwned.Text = "YouTube";
            // 
            // WikipediaUrlOwned
            // 
            this.WikipediaUrlOwned.DataPropertyName = "WikipediaUrl";
            this.WikipediaUrlOwned.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.WikipediaUrlOwned.HeaderText = "WikipediaUrl";
            this.WikipediaUrlOwned.Name = "WikipediaUrlOwned";
            this.WikipediaUrlOwned.ReadOnly = true;
            this.WikipediaUrlOwned.Text = "Wiki";
            // 
            // TitleMissing
            // 
            this.TitleMissing.DataPropertyName = "Title";
            this.TitleMissing.HeaderText = "Title";
            this.TitleMissing.Name = "TitleMissing";
            this.TitleMissing.ReadOnly = true;
            // 
            // DeveloperMissing
            // 
            this.DeveloperMissing.DataPropertyName = "Developer";
            this.DeveloperMissing.HeaderText = "Developer";
            this.DeveloperMissing.Name = "DeveloperMissing";
            this.DeveloperMissing.ReadOnly = true;
            // 
            // PublisherMissing
            // 
            this.PublisherMissing.DataPropertyName = "Publisher";
            this.PublisherMissing.HeaderText = "Publisher";
            this.PublisherMissing.Name = "PublisherMissing";
            this.PublisherMissing.ReadOnly = true;
            // 
            // RegionMissing
            // 
            this.RegionMissing.DataPropertyName = "Region";
            this.RegionMissing.HeaderText = "Region";
            this.RegionMissing.Name = "RegionMissing";
            this.RegionMissing.ReadOnly = true;
            // 
            // ReleaseDateMissing
            // 
            this.ReleaseDateMissing.DataPropertyName = "ReleaseDate";
            this.ReleaseDateMissing.HeaderText = "ReleaseDate";
            this.ReleaseDateMissing.Name = "ReleaseDateMissing";
            this.ReleaseDateMissing.ReadOnly = true;
            // 
            // CommunityStarRatingMissing
            // 
            this.CommunityStarRatingMissing.DataPropertyName = "CommunityStarRating";
            this.CommunityStarRatingMissing.HeaderText = "CommunityStarRating";
            this.CommunityStarRatingMissing.Name = "CommunityStarRatingMissing";
            this.CommunityStarRatingMissing.ReadOnly = true;
            // 
            // CommunityStarRatingTotalVotesMissing
            // 
            this.CommunityStarRatingTotalVotesMissing.DataPropertyName = "CommunityStarRatingTotalVotes";
            this.CommunityStarRatingTotalVotesMissing.HeaderText = "CommunityStarRatingTotalVotes";
            this.CommunityStarRatingTotalVotesMissing.Name = "CommunityStarRatingTotalVotesMissing";
            this.CommunityStarRatingTotalVotesMissing.ReadOnly = true;
            // 
            // PlatformMissing
            // 
            this.PlatformMissing.DataPropertyName = "Platform";
            this.PlatformMissing.HeaderText = "Platform";
            this.PlatformMissing.Name = "PlatformMissing";
            this.PlatformMissing.ReadOnly = true;
            // 
            // ReleaseTypeMissing
            // 
            this.ReleaseTypeMissing.DataPropertyName = "ReleaseType";
            this.ReleaseTypeMissing.HeaderText = "ReleaseType";
            this.ReleaseTypeMissing.Name = "ReleaseTypeMissing";
            this.ReleaseTypeMissing.ReadOnly = true;
            // 
            // GenresMissing
            // 
            this.GenresMissing.DataPropertyName = "Genres";
            this.GenresMissing.HeaderText = "Genres";
            this.GenresMissing.Name = "GenresMissing";
            this.GenresMissing.ReadOnly = true;
            // 
            // AlternateNamesMissing
            // 
            this.AlternateNamesMissing.DataPropertyName = "AlternateNames";
            this.AlternateNamesMissing.HeaderText = "AlternateNames";
            this.AlternateNamesMissing.Name = "AlternateNamesMissing";
            this.AlternateNamesMissing.ReadOnly = true;
            // 
            // MaxPlayersMissing
            // 
            this.MaxPlayersMissing.DataPropertyName = "MaxPlayers";
            this.MaxPlayersMissing.HeaderText = "MaxPlayers";
            this.MaxPlayersMissing.Name = "MaxPlayersMissing";
            this.MaxPlayersMissing.ReadOnly = true;
            // 
            // LaunchBoxDbIdMissing
            // 
            this.LaunchBoxDbIdMissing.DataPropertyName = "LaunchBoxDbId";
            this.LaunchBoxDbIdMissing.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.LaunchBoxDbIdMissing.HeaderText = "LaunchBoxDbId";
            this.LaunchBoxDbIdMissing.Name = "LaunchBoxDbIdMissing";
            this.LaunchBoxDbIdMissing.ReadOnly = true;
            this.LaunchBoxDbIdMissing.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.LaunchBoxDbIdMissing.Text = "LaunchBoxDB #";
            // 
            // VideoUrlMissing
            // 
            this.VideoUrlMissing.DataPropertyName = "VideoUrl";
            this.VideoUrlMissing.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.VideoUrlMissing.HeaderText = "VideoUrl";
            this.VideoUrlMissing.Name = "VideoUrlMissing";
            this.VideoUrlMissing.ReadOnly = true;
            this.VideoUrlMissing.Text = "YouTube";
            // 
            // WikipediaUrlMissing
            // 
            this.WikipediaUrlMissing.DataPropertyName = "WikipediaUrl";
            this.WikipediaUrlMissing.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.WikipediaUrlMissing.HeaderText = "WikipediaUrl";
            this.WikipediaUrlMissing.Name = "WikipediaUrlMissing";
            this.WikipediaUrlMissing.ReadOnly = true;
            this.WikipediaUrlMissing.Text = "Wiki";
            // 
            // PlatformSelectionForm
            // 
            this.AccessibleDescription = "A LaunchBox plugin designed to help users identify missing games in their collect" +
    "ion based on platform metadata.";
            this.AccessibleName = "Missing Games Checker";
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(57)))), ((int)(((byte)(63)))));
            this.ClientSize = new System.Drawing.Size(956, 479);
            this.ControlBox = false;
            this.Controls.Add(this.pbSpinner);
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
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pbMGCLogo);
            this.Controls.Add(this.lblCongrats);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(956, 479);
            this.Name = "PlatformSelectionForm";
            this.Text = "Missing Games Checker";
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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDebugBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMGCLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.noPlatformGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.noPlatformBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSpinner)).EndInit();
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
        private System.Windows.Forms.PictureBox pictureBox1;
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
        private System.Windows.Forms.PictureBox pictureBox2;
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
    }
}