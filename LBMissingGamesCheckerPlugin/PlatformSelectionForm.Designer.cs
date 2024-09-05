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
            this.platformDropdown = new System.Windows.Forms.ComboBox();
            this.confirmButton = new System.Windows.Forms.Button();
            this.ownedGamesGridView = new System.Windows.Forms.DataGridView();
            this.missingGamesGridView = new System.Windows.Forms.DataGridView();
            this.lblDropdown = new System.Windows.Forms.Label();
            this.lblOwnedGamesGridView = new System.Windows.Forms.Label();
            this.lblMissingGamesGridView = new System.Windows.Forms.Label();
            this.lblOwnedGamesCount = new System.Windows.Forms.Label();
            this.lblMissingGamesCount = new System.Windows.Forms.Label();
            this.btnOwnedCSV = new System.Windows.Forms.Button();
            this.btnMissingCSV = new System.Windows.Forms.Button();
            this.gbOptional = new System.Windows.Forms.GroupBox();
            this.lblColumnSelection = new System.Windows.Forms.Label();
            this.clbColumnSelection = new System.Windows.Forms.CheckedListBox();
            this.chkReleasedOnly = new System.Windows.Forms.CheckBox();
            this.pbGridViewLoading = new System.Windows.Forms.ProgressBar();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ownedGamesGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.missingGamesGridView)).BeginInit();
            this.gbOptional.SuspendLayout();
            this.SuspendLayout();
            // 
            // platformDropdown
            // 
            this.platformDropdown.FormattingEnabled = true;
            this.platformDropdown.Location = new System.Drawing.Point(22, 91);
            this.platformDropdown.Name = "platformDropdown";
            this.platformDropdown.Size = new System.Drawing.Size(161, 21);
            this.platformDropdown.TabIndex = 0;
            this.platformDropdown.Text = "Select a Platform";
            // 
            // confirmButton
            // 
            this.confirmButton.Location = new System.Drawing.Point(71, 118);
            this.confirmButton.Name = "confirmButton";
            this.confirmButton.Size = new System.Drawing.Size(112, 23);
            this.confirmButton.TabIndex = 1;
            this.confirmButton.Text = "Confirm Selection";
            this.confirmButton.UseVisualStyleBackColor = true;
            this.confirmButton.Click += new System.EventHandler(this.ConfirmButton_Click);
            // 
            // ownedGamesGridView
            // 
            this.ownedGamesGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ownedGamesGridView.Location = new System.Drawing.Point(225, 91);
            this.ownedGamesGridView.Name = "ownedGamesGridView";
            this.ownedGamesGridView.RowHeadersWidth = 51;
            this.ownedGamesGridView.Size = new System.Drawing.Size(720, 150);
            this.ownedGamesGridView.TabIndex = 2;
            this.ownedGamesGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridView_CellContentClick);
            this.ownedGamesGridView.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.OwnedGamesGridView_ColumnHeaderMouseClick);
            // 
            // missingGamesGridView
            // 
            this.missingGamesGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.missingGamesGridView.Location = new System.Drawing.Point(225, 279);
            this.missingGamesGridView.Name = "missingGamesGridView";
            this.missingGamesGridView.RowHeadersWidth = 51;
            this.missingGamesGridView.Size = new System.Drawing.Size(720, 188);
            this.missingGamesGridView.TabIndex = 3;
            this.missingGamesGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridView_CellContentClick);
            this.missingGamesGridView.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.MissingGamesGridView_ColumnHeaderMouseClick);
            // 
            // lblDropdown
            // 
            this.lblDropdown.AutoSize = true;
            this.lblDropdown.Location = new System.Drawing.Point(22, 72);
            this.lblDropdown.Name = "lblDropdown";
            this.lblDropdown.Size = new System.Drawing.Size(131, 13);
            this.lblDropdown.TabIndex = 4;
            this.lblDropdown.Text = "Select a platform to check";
            // 
            // lblOwnedGamesGridView
            // 
            this.lblOwnedGamesGridView.AutoSize = true;
            this.lblOwnedGamesGridView.Location = new System.Drawing.Point(225, 72);
            this.lblOwnedGamesGridView.Name = "lblOwnedGamesGridView";
            this.lblOwnedGamesGridView.Size = new System.Drawing.Size(130, 13);
            this.lblOwnedGamesGridView.TabIndex = 5;
            this.lblOwnedGamesGridView.Text = "Owned Games List Count:";
            // 
            // lblMissingGamesGridView
            // 
            this.lblMissingGamesGridView.AutoSize = true;
            this.lblMissingGamesGridView.Location = new System.Drawing.Point(225, 260);
            this.lblMissingGamesGridView.Name = "lblMissingGamesGridView";
            this.lblMissingGamesGridView.Size = new System.Drawing.Size(131, 13);
            this.lblMissingGamesGridView.TabIndex = 6;
            this.lblMissingGamesGridView.Text = "Missing Games List Count:";
            // 
            // lblOwnedGamesCount
            // 
            this.lblOwnedGamesCount.AutoSize = true;
            this.lblOwnedGamesCount.Location = new System.Drawing.Point(361, 72);
            this.lblOwnedGamesCount.Name = "lblOwnedGamesCount";
            this.lblOwnedGamesCount.Size = new System.Drawing.Size(13, 13);
            this.lblOwnedGamesCount.TabIndex = 7;
            this.lblOwnedGamesCount.Text = "0";
            // 
            // lblMissingGamesCount
            // 
            this.lblMissingGamesCount.AutoSize = true;
            this.lblMissingGamesCount.Location = new System.Drawing.Point(362, 260);
            this.lblMissingGamesCount.Name = "lblMissingGamesCount";
            this.lblMissingGamesCount.Size = new System.Drawing.Size(13, 13);
            this.lblMissingGamesCount.TabIndex = 8;
            this.lblMissingGamesCount.Text = "0";
            // 
            // btnOwnedCSV
            // 
            this.btnOwnedCSV.Location = new System.Drawing.Point(851, 67);
            this.btnOwnedCSV.Name = "btnOwnedCSV";
            this.btnOwnedCSV.Size = new System.Drawing.Size(94, 23);
            this.btnOwnedCSV.TabIndex = 9;
            this.btnOwnedCSV.Text = "Export to CSV";
            this.btnOwnedCSV.UseVisualStyleBackColor = true;
            this.btnOwnedCSV.Click += new System.EventHandler(this.ExportOwnedGamesButton_Click);
            // 
            // btnMissingCSV
            // 
            this.btnMissingCSV.Location = new System.Drawing.Point(851, 255);
            this.btnMissingCSV.Name = "btnMissingCSV";
            this.btnMissingCSV.Size = new System.Drawing.Size(93, 23);
            this.btnMissingCSV.TabIndex = 10;
            this.btnMissingCSV.Text = "Export to CSV";
            this.btnMissingCSV.UseVisualStyleBackColor = true;
            this.btnMissingCSV.Click += new System.EventHandler(this.ExportMissingGamesButton_Click);
            // 
            // gbOptional
            // 
            this.gbOptional.Controls.Add(this.lblColumnSelection);
            this.gbOptional.Controls.Add(this.clbColumnSelection);
            this.gbOptional.Controls.Add(this.chkReleasedOnly);
            this.gbOptional.Location = new System.Drawing.Point(15, 156);
            this.gbOptional.Name = "gbOptional";
            this.gbOptional.Size = new System.Drawing.Size(204, 228);
            this.gbOptional.TabIndex = 11;
            this.gbOptional.TabStop = false;
            this.gbOptional.Text = "Optional Items";
            // 
            // lblColumnSelection
            // 
            this.lblColumnSelection.AutoSize = true;
            this.lblColumnSelection.Location = new System.Drawing.Point(4, 52);
            this.lblColumnSelection.Name = "lblColumnSelection";
            this.lblColumnSelection.Size = new System.Drawing.Size(89, 13);
            this.lblColumnSelection.TabIndex = 2;
            this.lblColumnSelection.Text = "Column Selection";
            // 
            // clbColumnSelection
            // 
            this.clbColumnSelection.FormattingEnabled = true;
            this.clbColumnSelection.Items.AddRange(new object[] {
            "Developer",
            "Publisher",
            "Platform",
            "ReleaseDate",
            "CommunityStarRating",
            "CommunityStarRatingTotalVotes",
            "LaunchBoxDbId",
            "VideoUrl",
            "WikipediaUrl",
            "ReleaseType"});
            this.clbColumnSelection.Location = new System.Drawing.Point(6, 68);
            this.clbColumnSelection.Name = "clbColumnSelection";
            this.clbColumnSelection.Size = new System.Drawing.Size(191, 154);
            this.clbColumnSelection.TabIndex = 1;
            this.clbColumnSelection.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.CheckedListBox_ItemCheck);
            // 
            // chkReleasedOnly
            // 
            this.chkReleasedOnly.AutoSize = true;
            this.chkReleasedOnly.Location = new System.Drawing.Point(7, 20);
            this.chkReleasedOnly.Name = "chkReleasedOnly";
            this.chkReleasedOnly.Size = new System.Drawing.Size(166, 17);
            this.chkReleasedOnly.TabIndex = 0;
            this.chkReleasedOnly.Text = "Only include Released games";
            this.chkReleasedOnly.UseVisualStyleBackColor = true;
            // 
            // pbGridViewLoading
            // 
            this.pbGridViewLoading.Location = new System.Drawing.Point(21, 409);
            this.pbGridViewLoading.Name = "pbGridViewLoading";
            this.pbGridViewLoading.Size = new System.Drawing.Size(190, 18);
            this.pbGridViewLoading.TabIndex = 12;
            this.pbGridViewLoading.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(879, 10);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(68, 19);
            this.btnClose.TabIndex = 13;
            this.btnClose.Text = "Close MGC";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.FormClose_Click);
            // 
            // PlatformSelectionForm
            // 
            this.AccessibleDescription = "A LaunchBox plugin designed to help users identify missing games in their collect" +
    "ion based on platform metadata.";
            this.AccessibleName = "Missing Games Checker";
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(956, 477);
            this.ControlBox = false;
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.pbGridViewLoading);
            this.Controls.Add(this.gbOptional);
            this.Controls.Add(this.btnMissingCSV);
            this.Controls.Add(this.btnOwnedCSV);
            this.Controls.Add(this.lblMissingGamesCount);
            this.Controls.Add(this.lblOwnedGamesCount);
            this.Controls.Add(this.lblMissingGamesGridView);
            this.Controls.Add(this.lblOwnedGamesGridView);
            this.Controls.Add(this.lblDropdown);
            this.Controls.Add(this.missingGamesGridView);
            this.Controls.Add(this.ownedGamesGridView);
            this.Controls.Add(this.confirmButton);
            this.Controls.Add(this.platformDropdown);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PlatformSelectionForm";
            this.Text = "Missing Games Checker";
            this.Load += new System.EventHandler(this.PlatformSelectionForm_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PlatformSelectionForm_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.ownedGamesGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.missingGamesGridView)).EndInit();
            this.gbOptional.ResumeLayout(false);
            this.gbOptional.PerformLayout();
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
        private System.Windows.Forms.ProgressBar pbGridViewLoading;
        private System.Windows.Forms.CheckedListBox clbColumnSelection;
        private System.Windows.Forms.Label lblColumnSelection;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnClose;
    }
}