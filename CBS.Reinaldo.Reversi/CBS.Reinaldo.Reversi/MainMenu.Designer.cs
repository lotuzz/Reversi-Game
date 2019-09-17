namespace CBS.Reinaldo.Reversi
{
    partial class MainMenu
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
            this._PVPButton = new System.Windows.Forms.Button();
            this._WhitePlayerButton = new System.Windows.Forms.Button();
            this._OtheloMainMenuLabel = new System.Windows.Forms.Label();
            this._DeveloperNameLabel = new System.Windows.Forms.Label();
            this._BlackPlayerButton = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this._gameHistoryLabel = new System.Windows.Forms.Label();
            this.Winner = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Black = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.White = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // _PVPButton
            // 
            this._PVPButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._PVPButton.Location = new System.Drawing.Point(28, 93);
            this._PVPButton.Name = "_PVPButton";
            this._PVPButton.Size = new System.Drawing.Size(100, 84);
            this._PVPButton.TabIndex = 0;
            this._PVPButton.Text = "Player\r\nVs\r\nPlayer";
            this._PVPButton.UseVisualStyleBackColor = true;
            this._PVPButton.Click += new System.EventHandler(this._PVPButton_Click);
            // 
            // _WhitePlayerButton
            // 
            this._WhitePlayerButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._WhitePlayerButton.Location = new System.Drawing.Point(222, 138);
            this._WhitePlayerButton.Name = "_WhitePlayerButton";
            this._WhitePlayerButton.Size = new System.Drawing.Size(100, 39);
            this._WhitePlayerButton.TabIndex = 1;
            this._WhitePlayerButton.Text = "As WhitePlayer";
            this._WhitePlayerButton.UseVisualStyleBackColor = true;
            this._WhitePlayerButton.Click += new System.EventHandler(this._WhitePlayerButton_Click);
            // 
            // _OtheloMainMenuLabel
            // 
            this._OtheloMainMenuLabel.AutoSize = true;
            this._OtheloMainMenuLabel.Font = new System.Drawing.Font("Mongolian Baiti", 15F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._OtheloMainMenuLabel.Location = new System.Drawing.Point(79, 20);
            this._OtheloMainMenuLabel.Name = "_OtheloMainMenuLabel";
            this._OtheloMainMenuLabel.Size = new System.Drawing.Size(202, 21);
            this._OtheloMainMenuLabel.TabIndex = 2;
            this._OtheloMainMenuLabel.Text = "O t h e l l o   G a m e";
            // 
            // _DeveloperNameLabel
            // 
            this._DeveloperNameLabel.AutoSize = true;
            this._DeveloperNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._DeveloperNameLabel.Location = new System.Drawing.Point(151, 41);
            this._DeveloperNameLabel.Name = "_DeveloperNameLabel";
            this._DeveloperNameLabel.Size = new System.Drawing.Size(64, 13);
            this._DeveloperNameLabel.TabIndex = 3;
            this._DeveloperNameLabel.Text = "By Reinaldo";
            // 
            // _BlackPlayerButton
            // 
            this._BlackPlayerButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._BlackPlayerButton.Location = new System.Drawing.Point(222, 93);
            this._BlackPlayerButton.Name = "_BlackPlayerButton";
            this._BlackPlayerButton.Size = new System.Drawing.Size(100, 39);
            this._BlackPlayerButton.TabIndex = 4;
            this._BlackPlayerButton.Text = "As BlackPlayer";
            this._BlackPlayerButton.UseVisualStyleBackColor = true;
            this._BlackPlayerButton.Click += new System.EventHandler(this._BlackPlayerButton_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.White,
            this.Black,
            this.Date,
            this.Winner});
            this.dataGridView1.Location = new System.Drawing.Point(28, 226);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(294, 150);
            this.dataGridView1.TabIndex = 5;
            // 
            // _gameHistoryLabel
            // 
            this._gameHistoryLabel.AutoSize = true;
            this._gameHistoryLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._gameHistoryLabel.Location = new System.Drawing.Point(120, 201);
            this._gameHistoryLabel.Name = "_gameHistoryLabel";
            this._gameHistoryLabel.Size = new System.Drawing.Size(119, 22);
            this._gameHistoryLabel.TabIndex = 7;
            this._gameHistoryLabel.Text = "Game History";
            // 
            // Winner
            // 
            this.Winner.HeaderText = "Winner";
            this.Winner.Name = "Winner";
            this.Winner.Width = 50;
            // 
            // Date
            // 
            this.Date.HeaderText = "Date Played";
            this.Date.Name = "Date";
            // 
            // Black
            // 
            this.Black.HeaderText = "Black Disks";
            this.Black.Name = "Black";
            this.Black.Width = 50;
            // 
            // White
            // 
            this.White.HeaderText = "White Disks";
            this.White.Name = "White";
            this.White.Width = 50;
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(361, 450);
            this.Controls.Add(this._gameHistoryLabel);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this._BlackPlayerButton);
            this.Controls.Add(this._DeveloperNameLabel);
            this.Controls.Add(this._OtheloMainMenuLabel);
            this.Controls.Add(this._WhitePlayerButton);
            this.Controls.Add(this._PVPButton);
            this.Name = "MainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainMenu";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _PVPButton;
        private System.Windows.Forms.Button _WhitePlayerButton;
        private System.Windows.Forms.Label _OtheloMainMenuLabel;
        private System.Windows.Forms.Label _DeveloperNameLabel;
        private System.Windows.Forms.Button _BlackPlayerButton;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label _gameHistoryLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn White;
        private System.Windows.Forms.DataGridViewTextBoxColumn Black;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Winner;
    }
}