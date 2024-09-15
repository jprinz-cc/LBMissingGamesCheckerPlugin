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
            if (ownedGames != null)
            {
                ownedGames.Clear();
                ownedGames = null;
            }
            if (missingGames != null)
            {
                missingGames.Clear();
                missingGames = null;
            }
            if (xmlGames != null)
            {
                xmlGames.Clear();
            }
            if (xmlGameAltNames != null)
            {
                xmlGameAltNames.Clear();
            }
            if (xmlPlatforms != null)
            {
                xmlPlatforms.Clear();
            }
            if (missingGamesGridView.DataSource != null)
            {
                missingGamesGridView.DataSource = null;
            }
            if (ownedGamesGridView.DataSource != null)
            {
                ownedGamesGridView.DataSource = null;
            }
            

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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnClose = new System.Windows.Forms.Button();
            this.llbPoweredBy = new System.Windows.Forms.LinkLabel();
            this.lblDebug = new System.Windows.Forms.Label();
            this.pbMGCLogo = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ssMetadataStatus = new System.Windows.Forms.StatusStrip();
            this.tsslIcon = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslText = new System.Windows.Forms.ToolStripStatusLabel();
            this.pbMetadataLoading = new LBMissingGamesCheckerPlugin.PlatformSelectionForm.ProgressBarEx();
            this.tbDebug = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.ownedGamesGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.missingGamesGridView)).BeginInit();
            this.gbOptional.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbMGCLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.ssMetadataStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // platformDropdown
            // 
            this.platformDropdown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.platformDropdown.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.platformDropdown.FormattingEnabled = true;
            this.platformDropdown.Items.AddRange(new object[] {
            "Select a Platform"});
            this.platformDropdown.Location = new System.Drawing.Point(21, 53);
            this.platformDropdown.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.platformDropdown.Name = "platformDropdown";
            this.platformDropdown.Size = new System.Drawing.Size(292, 24);
            this.platformDropdown.TabIndex = 0;
            // 
            // confirmButton
            // 
            this.confirmButton.Enabled = false;
            this.confirmButton.Location = new System.Drawing.Point(165, 86);
            this.confirmButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.confirmButton.Name = "confirmButton";
            this.confirmButton.Size = new System.Drawing.Size(149, 28);
            this.confirmButton.TabIndex = 1;
            this.confirmButton.Text = "Confirm Selection";
            this.confirmButton.UseVisualStyleBackColor = true;
            this.confirmButton.Click += new System.EventHandler(this.ConfirmButton_Click);
            // 
            // ownedGamesGridView
            // 
            this.ownedGamesGridView.AllowUserToAddRows = false;
            this.ownedGamesGridView.AllowUserToDeleteRows = false;
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
            this.ownedGamesGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.ownedGamesGridView.EnableHeadersVisualStyles = false;
            this.ownedGamesGridView.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(156)))), ((int)(((byte)(255)))));
            this.ownedGamesGridView.Location = new System.Drawing.Point(329, 112);
            this.ownedGamesGridView.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ownedGamesGridView.Name = "ownedGamesGridView";
            this.ownedGamesGridView.ReadOnly = true;
            this.ownedGamesGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle21.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(57)))), ((int)(((byte)(63)))));
            dataGridViewCellStyle21.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ownedGamesGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle21;
            this.ownedGamesGridView.RowHeadersWidth = 51;
            this.ownedGamesGridView.Size = new System.Drawing.Size(931, 185);
            this.ownedGamesGridView.TabIndex = 2;
            this.ownedGamesGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridView_CellContentClick);
            this.ownedGamesGridView.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.OwnedGamesGridView_ColumnHeaderMouseClick);
            // 
            // missingGamesGridView
            // 
            this.missingGamesGridView.AllowUserToAddRows = false;
            this.missingGamesGridView.AllowUserToDeleteRows = false;
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
            this.missingGamesGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.missingGamesGridView.EnableHeadersVisualStyles = false;
            this.missingGamesGridView.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(156)))), ((int)(((byte)(255)))));
            this.missingGamesGridView.Location = new System.Drawing.Point(329, 343);
            this.missingGamesGridView.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.missingGamesGridView.Name = "missingGamesGridView";
            this.missingGamesGridView.ReadOnly = true;
            this.missingGamesGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle24.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(57)))), ((int)(((byte)(63)))));
            dataGridViewCellStyle24.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle24.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.missingGamesGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle24;
            this.missingGamesGridView.RowHeadersWidth = 51;
            this.missingGamesGridView.Size = new System.Drawing.Size(931, 231);
            this.missingGamesGridView.TabIndex = 3;
            this.missingGamesGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridView_CellContentClick);
            this.missingGamesGridView.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.MissingGamesGridView_ColumnHeaderMouseClick);
            // 
            // lblDropdown
            // 
            this.lblDropdown.AutoSize = true;
            this.lblDropdown.BackColor = System.Drawing.Color.Transparent;
            this.lblDropdown.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDropdown.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.lblDropdown.Location = new System.Drawing.Point(16, 25);
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
            this.btnOwnedCSV.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
            this.btnMissingCSV.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnMissingCSV.Name = "btnMissingCSV";
            this.btnMissingCSV.Size = new System.Drawing.Size(113, 25);
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
            this.gbOptional.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(191)))), ((int)(((byte)(0)))));
            this.gbOptional.Location = new System.Drawing.Point(28, 122);
            this.gbOptional.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbOptional.Name = "gbOptional";
            this.gbOptional.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbOptional.Size = new System.Drawing.Size(287, 374);
            this.gbOptional.TabIndex = 11;
            this.gbOptional.TabStop = false;
            this.gbOptional.Text = "Optional Items";
            // 
            // lblColumnSelection
            // 
            this.lblColumnSelection.AutoSize = true;
            this.lblColumnSelection.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(191)))), ((int)(((byte)(0)))));
            this.lblColumnSelection.Location = new System.Drawing.Point(12, 64);
            this.lblColumnSelection.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblColumnSelection.Name = "lblColumnSelection";
            this.lblColumnSelection.Size = new System.Drawing.Size(111, 16);
            this.lblColumnSelection.TabIndex = 2;
            this.lblColumnSelection.Text = "Column Selection";
            // 
            // clbColumnSelection
            // 
            this.clbColumnSelection.FormattingEnabled = true;
            this.clbColumnSelection.Location = new System.Drawing.Point(16, 84);
            this.clbColumnSelection.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.clbColumnSelection.Name = "clbColumnSelection";
            this.clbColumnSelection.Size = new System.Drawing.Size(253, 276);
            this.clbColumnSelection.TabIndex = 1;
            this.clbColumnSelection.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.CheckedListBox_ItemCheck);
            // 
            // chkReleasedOnly
            // 
            this.chkReleasedOnly.AutoSize = true;
            this.chkReleasedOnly.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(191)))), ((int)(((byte)(0)))));
            this.chkReleasedOnly.Location = new System.Drawing.Point(16, 27);
            this.chkReleasedOnly.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
            // lblDebug
            // 
            this.lblDebug.AutoSize = true;
            this.lblDebug.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(57)))), ((int)(((byte)(63)))));
            this.lblDebug.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDebug.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(191)))), ((int)(((byte)(0)))));
            this.lblDebug.Location = new System.Drawing.Point(340, 534);
            this.lblDebug.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDebug.Name = "lblDebug";
            this.lblDebug.Size = new System.Drawing.Size(168, 25);
            this.lblDebug.TabIndex = 18;
            this.lblDebug.Text = "current path text";
            // 
            // pbMGCLogo
            // 
            this.pbMGCLogo.BackColor = System.Drawing.Color.Transparent;
            this.pbMGCLogo.Image = global::LBMissingGamesCheckerPlugin.Properties.Resources.mgc_logo;
            this.pbMGCLogo.Location = new System.Drawing.Point(376, 14);
            this.pbMGCLogo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pbMGCLogo.Name = "pbMGCLogo";
            this.pbMGCLogo.Size = new System.Drawing.Size(97, 73);
            this.pbMGCLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbMGCLogo.TabIndex = 14;
            this.pbMGCLogo.TabStop = false;
            this.pbMGCLogo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PlatformSelectionForm_MouseDown);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::LBMissingGamesCheckerPlugin.Properties.Resources.mgc_header;
            this.pictureBox1.Location = new System.Drawing.Point(481, -1);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(628, 119);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PlatformSelectionForm_MouseDown);
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
            this.ssMetadataStatus.Location = new System.Drawing.Point(28, 498);
            this.ssMetadataStatus.Name = "ssMetadataStatus";
            this.ssMetadataStatus.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.ssMetadataStatus.Size = new System.Drawing.Size(273, 32);
            this.ssMetadataStatus.SizingGrip = false;
            this.ssMetadataStatus.TabIndex = 19;
            // 
            // tsslIcon
            // 
            this.tsslIcon.Image = global::LBMissingGamesCheckerPlugin.Properties.Resources.warning;
            this.tsslIcon.Name = "tsslIcon";
            this.tsslIcon.Padding = new System.Windows.Forms.Padding(5, 0, 0, 5);
            this.tsslIcon.Size = new System.Drawing.Size(25, 26);
            // 
            // tsslText
            // 
            this.tsslText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(191)))), ((int)(((byte)(0)))));
            this.tsslText.Name = "tsslText";
            this.tsslText.Padding = new System.Windows.Forms.Padding(10, 0, 0, 5);
            this.tsslText.Size = new System.Drawing.Size(182, 26);
            this.tsslText.Text = "Preparing Environment....";
            // 
            // pbMetadataLoading
            // 
            this.pbMetadataLoading.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(57)))), ((int)(((byte)(63)))));
            this.pbMetadataLoading.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(173)))), ((int)(((byte)(255)))));
            this.pbMetadataLoading.Location = new System.Drawing.Point(28, 534);
            this.pbMetadataLoading.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
            this.tbDebug.Location = new System.Drawing.Point(353, 356);
            this.tbDebug.Multiline = true;
            this.tbDebug.Name = "tbDebug";
            this.tbDebug.Size = new System.Drawing.Size(569, 174);
            this.tbDebug.TabIndex = 21;
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
            this.Controls.Add(this.tbDebug);
            this.Controls.Add(this.pbMetadataLoading);
            this.Controls.Add(this.ssMetadataStatus);
            this.Controls.Add(this.lblDebug);
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
            this.Controls.Add(this.missingGamesGridView);
            this.Controls.Add(this.ownedGamesGridView);
            this.Controls.Add(this.confirmButton);
            this.Controls.Add(this.platformDropdown);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pbMGCLogo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "PlatformSelectionForm";
            this.Text = "Missing Games Checker";
            this.Load += new System.EventHandler(this.PlatformSelectionForm_Load);
            this.Shown += new System.EventHandler(this.PlatformSelectionForm_Shown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PlatformSelectionForm_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.ownedGamesGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.missingGamesGridView)).EndInit();
            this.gbOptional.ResumeLayout(false);
            this.gbOptional.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbMGCLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ssMetadataStatus.ResumeLayout(false);
            this.ssMetadataStatus.PerformLayout();
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
        private System.Windows.Forms.Label lblDebug;
        private System.Windows.Forms.StatusStrip ssMetadataStatus;
        private System.Windows.Forms.ToolStripStatusLabel tsslIcon;
        private System.Windows.Forms.ToolStripStatusLabel tsslText;
        private ProgressBarEx pbMetadataLoading;
        private System.Windows.Forms.TextBox tbDebug;
    }
}