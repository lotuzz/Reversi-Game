namespace CBS.Reinaldo.Reversi
{
    partial class OthelloGame
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
            this._PlayerTurnLabel = new System.Windows.Forms.Label();
            this._labelTurn = new System.Windows.Forms.Label();
            this._whitePlayerLabel = new System.Windows.Forms.Label();
            this._WhitePlayerScoreLabel = new System.Windows.Forms.Label();
            this._blackPlayerLabel = new System.Windows.Forms.Label();
            this._BlackPlayerScoreLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // _PlayerTurnLabel
            // 
            this._PlayerTurnLabel.AutoSize = true;
            this._PlayerTurnLabel.Font = new System.Drawing.Font("MingLiU-ExtB", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._PlayerTurnLabel.Location = new System.Drawing.Point(66, 9);
            this._PlayerTurnLabel.Name = "_PlayerTurnLabel";
            this._PlayerTurnLabel.Size = new System.Drawing.Size(123, 34);
            this._PlayerTurnLabel.TabIndex = 0;
            this._PlayerTurnLabel.Text = "Color ";
            // 
            // _labelTurn
            // 
            this._labelTurn.AutoSize = true;
            this._labelTurn.Font = new System.Drawing.Font("MingLiU-ExtB", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._labelTurn.Location = new System.Drawing.Point(174, 9);
            this._labelTurn.Name = "_labelTurn";
            this._labelTurn.Size = new System.Drawing.Size(213, 34);
            this._labelTurn.TabIndex = 1;
            this._labelTurn.Text = "Player Turn";
            // 
            // _whitePlayerLabel
            // 
            this._whitePlayerLabel.AutoSize = true;
            this._whitePlayerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._whitePlayerLabel.Location = new System.Drawing.Point(430, 91);
            this._whitePlayerLabel.Name = "_whitePlayerLabel";
            this._whitePlayerLabel.Size = new System.Drawing.Size(179, 22);
            this._whitePlayerLabel.TabIndex = 2;
            this._whitePlayerLabel.Text = "White Player Score : ";
            // 
            // _WhitePlayerScoreLabel
            // 
            this._WhitePlayerScoreLabel.AutoSize = true;
            this._WhitePlayerScoreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._WhitePlayerScoreLabel.Location = new System.Drawing.Point(615, 91);
            this._WhitePlayerScoreLabel.Name = "_WhitePlayerScoreLabel";
            this._WhitePlayerScoreLabel.Size = new System.Drawing.Size(70, 22);
            this._WhitePlayerScoreLabel.TabIndex = 21;
            this._WhitePlayerScoreLabel.Text = "0";
            // 
            // _blackPlayerLabel
            // 
            this._blackPlayerLabel.AutoSize = true;
            this._blackPlayerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._blackPlayerLabel.Location = new System.Drawing.Point(430, 151);
            this._blackPlayerLabel.Name = "_blackPlayerLabel";
            this._blackPlayerLabel.Size = new System.Drawing.Size(177, 22);
            this._blackPlayerLabel.TabIndex = 3;
            this._blackPlayerLabel.Text = "Black Player Score : ";
            // 
            // _BlackPlayerScoreLabel
            // 
            this._BlackPlayerScoreLabel.AutoSize = true;
            this._BlackPlayerScoreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._BlackPlayerScoreLabel.Location = new System.Drawing.Point(615, 151);
            this._BlackPlayerScoreLabel.Name = "_BlackPlayerScoreLabel";
            this._BlackPlayerScoreLabel.Size = new System.Drawing.Size(70, 22);
            this._BlackPlayerScoreLabel.TabIndex = 31;
            this._BlackPlayerScoreLabel.Text = "0";
            // 
            // OthelloGame Board
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(695, 450);
            this.Controls.Add(this._whitePlayerLabel);
            this.Controls.Add(this._WhitePlayerScoreLabel);
            this.Controls.Add(this._blackPlayerLabel);
            this.Controls.Add(this._BlackPlayerScoreLabel);
            this.Controls.Add(this._labelTurn);
            this.Controls.Add(this._PlayerTurnLabel);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Othello Game";
            this.Load += new System.EventHandler(_StartGame);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label _PlayerTurnLabel;
        private System.Windows.Forms.Label _labelTurn;

        private System.Windows.Forms.Label _whitePlayerLabel;
        private System.Windows.Forms.Label _WhitePlayerScoreLabel;

        private System.Windows.Forms.Label _blackPlayerLabel;
        private System.Windows.Forms.Label _BlackPlayerScoreLabel;
    }
}

