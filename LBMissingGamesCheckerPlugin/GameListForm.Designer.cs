namespace LBMissingGamesCheckerPlugin
{
    partial class GameListForm
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
            this.ownedGamesGridView = new System.Windows.Forms.DataGridView();
            this.missingGamesGridView = new System.Windows.Forms.DataGridView();
            this.ownedGamesLabel = new System.Windows.Forms.Label();
            this.missingGamesLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ownedGamesGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.missingGamesGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // ownedGamesGridView
            // 
            this.ownedGamesGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ownedGamesGridView.Location = new System.Drawing.Point(61, 42);
            this.ownedGamesGridView.Name = "ownedGamesGridView";
            this.ownedGamesGridView.Size = new System.Drawing.Size(664, 150);
            this.ownedGamesGridView.TabIndex = 0;
            // 
            // missingGamesGridView
            // 
            this.missingGamesGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.missingGamesGridView.Location = new System.Drawing.Point(61, 226);
            this.missingGamesGridView.Name = "missingGamesGridView";
            this.missingGamesGridView.Size = new System.Drawing.Size(664, 199);
            this.missingGamesGridView.TabIndex = 1;
            // 
            // ownedGamesLabel
            // 
            this.ownedGamesLabel.AutoSize = true;
            this.ownedGamesLabel.Location = new System.Drawing.Point(61, 23);
            this.ownedGamesLabel.Name = "ownedGamesLabel";
            this.ownedGamesLabel.Size = new System.Drawing.Size(96, 13);
            this.ownedGamesLabel.TabIndex = 2;
            this.ownedGamesLabel.Text = "Owned Games List";
            // 
            // missingGamesLabel
            // 
            this.missingGamesLabel.AutoSize = true;
            this.missingGamesLabel.Location = new System.Drawing.Point(64, 207);
            this.missingGamesLabel.Name = "missingGamesLabel";
            this.missingGamesLabel.Size = new System.Drawing.Size(97, 13);
            this.missingGamesLabel.TabIndex = 3;
            this.missingGamesLabel.Text = "Missing Games List";
            // 
            // GameListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.missingGamesLabel);
            this.Controls.Add(this.ownedGamesLabel);
            this.Controls.Add(this.missingGamesGridView);
            this.Controls.Add(this.ownedGamesGridView);
            this.Name = "GameListForm";
            this.Text = "GameListForm";
            this.Load += new System.EventHandler(this.GameListForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ownedGamesGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.missingGamesGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView ownedGamesGridView;
        private System.Windows.Forms.DataGridView missingGamesGridView;
        private System.Windows.Forms.Label ownedGamesLabel;
        private System.Windows.Forms.Label missingGamesLabel;
    }
}