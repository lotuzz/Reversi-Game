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
            this.SuspendLayout();
            // 
            // _PVPButton
            // 
            this._PVPButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._PVPButton.Location = new System.Drawing.Point(36, 105);
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
            this._WhitePlayerButton.Location = new System.Drawing.Point(222, 150);
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
            this._BlackPlayerButton.Location = new System.Drawing.Point(222, 105);
            this._BlackPlayerButton.Name = "_BlackPlayerButton";
            this._BlackPlayerButton.Size = new System.Drawing.Size(100, 39);
            this._BlackPlayerButton.TabIndex = 4;
            this._BlackPlayerButton.Text = "As BlackPlayer";
            this._BlackPlayerButton.UseVisualStyleBackColor = true;
            this._BlackPlayerButton.Click += new System.EventHandler(this._BlackPlayerButton_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(361, 450);
            this.Controls.Add(this._BlackPlayerButton);
            this.Controls.Add(this._DeveloperNameLabel);
            this.Controls.Add(this._OtheloMainMenuLabel);
            this.Controls.Add(this._WhitePlayerButton);
            this.Controls.Add(this._PVPButton);
            this.Name = "MainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainMenu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _PVPButton;
        private System.Windows.Forms.Button _WhitePlayerButton;
        private System.Windows.Forms.Label _OtheloMainMenuLabel;
        private System.Windows.Forms.Label _DeveloperNameLabel;
        private System.Windows.Forms.Button _BlackPlayerButton;
    }
}