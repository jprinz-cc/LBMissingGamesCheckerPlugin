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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.pbGridViewLoading = new LBMissingGamesCheckerPlugin.PlatformSelectionForm.ProgressBarEx();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ownedGamesGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.missingGamesGridView)).BeginInit();
            this.gbOptional.SuspendLayout();
            this.SuspendLayout();
            // 
            // platformDropdown
            // 
            this.platformDropdown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.platformDropdown.FormattingEnabled = true;
            this.platformDropdown.Items.AddRange(new object[] {
            "Select a Platform"});
            this.platformDropdown.Location = new System.Drawing.Point(21, 91);
            this.platformDropdown.Name = "platformDropdown";
            this.platformDropdown.Size = new System.Drawing.Size(191, 21);
            this.platformDropdown.TabIndex = 0;
            // 
            // confirmButton
            // 
            this.confirmButton.Location = new System.Drawing.Point(22, 118);
            this.confirmButton.Name = "confirmButton";
            this.confirmButton.Size = new System.Drawing.Size(112, 23);
            this.confirmButton.TabIndex = 1;
            this.confirmButton.Text = "Confirm Selection";
            this.confirmButton.UseVisualStyleBackColor = true;
            this.confirmButton.Click += new System.EventHandler(this.ConfirmButton_Click);
            // 
            // ownedGamesGridView
            // 
            this.ownedGamesGridView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(57)))), ((int)(((byte)(63)))));
            this.ownedGamesGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ownedGamesGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.ownedGamesGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(156)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle19.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ownedGamesGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle19;
            this.ownedGamesGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(57)))), ((int)(((byte)(63)))));
            dataGridViewCellStyle20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle20.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle20.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle20.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ownedGamesGridView.DefaultCellStyle = dataGridViewCellStyle20;
            this.ownedGamesGridView.EnableHeadersVisualStyles = false;
            this.ownedGamesGridView.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(156)))), ((int)(((byte)(255)))));
            this.ownedGamesGridView.Location = new System.Drawing.Point(225, 91);
            this.ownedGamesGridView.Name = "ownedGamesGridView";
            this.ownedGamesGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle21.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(57)))), ((int)(((byte)(63)))));
            dataGridViewCellStyle21.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ownedGamesGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle21;
            this.ownedGamesGridView.RowHeadersWidth = 51;
            this.ownedGamesGridView.Size = new System.Drawing.Size(720, 150);
            this.ownedGamesGridView.TabIndex = 2;
            this.ownedGamesGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridView_CellContentClick);
            this.ownedGamesGridView.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.OwnedGamesGridView_ColumnHeaderMouseClick);
            // 
            // missingGamesGridView
            // 
            this.missingGamesGridView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(57)))), ((int)(((byte)(63)))));
            this.missingGamesGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.missingGamesGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.missingGamesGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle22.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(156)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle22.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle22.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.missingGamesGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle22;
            this.missingGamesGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle23.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(57)))), ((int)(((byte)(63)))));
            dataGridViewCellStyle23.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle23.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle23.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle23.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle23.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.missingGamesGridView.DefaultCellStyle = dataGridViewCellStyle23;
            this.missingGamesGridView.EnableHeadersVisualStyles = false;
            this.missingGamesGridView.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(156)))), ((int)(((byte)(255)))));
            this.missingGamesGridView.Location = new System.Drawing.Point(225, 279);
            this.missingGamesGridView.Name = "missingGamesGridView";
            this.missingGamesGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle24.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(57)))), ((int)(((byte)(63)))));
            dataGridViewCellStyle24.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle24.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.missingGamesGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle24;
            this.missingGamesGridView.RowHeadersWidth = 51;
            this.missingGamesGridView.Size = new System.Drawing.Size(720, 188);
            this.missingGamesGridView.TabIndex = 3;
            this.missingGamesGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridView_CellContentClick);
            this.missingGamesGridView.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.MissingGamesGridView_ColumnHeaderMouseClick);
            // 
            // lblDropdown
            // 
            this.lblDropdown.AutoSize = true;
            this.lblDropdown.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDropdown.Location = new System.Drawing.Point(19, 72);
            this.lblDropdown.Name = "lblDropdown";
            this.lblDropdown.Size = new System.Drawing.Size(171, 17);
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
            this.gbOptional.Controls.Add(this.lblColumnSelection);
            this.gbOptional.Controls.Add(this.clbColumnSelection);
            this.gbOptional.Controls.Add(this.chkReleasedOnly);
            this.gbOptional.Location = new System.Drawing.Point(15, 156);
            this.gbOptional.Name = "gbOptional";
            this.gbOptional.Size = new System.Drawing.Size(204, 225);
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
            this.pbGridViewLoading.Location = new System.Drawing.Point(22, 406);
            this.pbGridViewLoading.Name = "pbGridViewLoading";
            this.pbGridViewLoading.Size = new System.Drawing.Size(190, 18);
            this.pbGridViewLoading.TabIndex = 12;
            this.pbGridViewLoading.Visible = false;
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
        private System.Windows.Forms.CheckedListBox clbColumnSelection;
        private System.Windows.Forms.Label lblColumnSelection;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnClose;
        private ProgressBarEx pbGridViewLoading;
    }
}