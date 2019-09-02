namespace CBS.Reinaldo.Reversi
{
    partial class Form1
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
            this.playerlabel = new System.Windows.Forms.Label();
            this.labelturn = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // playerlabel
            // 
            this.playerlabel.AutoSize = true;
            this.playerlabel.Font = new System.Drawing.Font("MingLiU-ExtB", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playerlabel.Location = new System.Drawing.Point(66, 9);
            this.playerlabel.Name = "playerlabel";
            this.playerlabel.Size = new System.Drawing.Size(123, 34);
            this.playerlabel.TabIndex = 0;
            this.playerlabel.Text = "Color ";
            // 
            // labelturn
            // 
            this.labelturn.AutoSize = true;
            this.labelturn.Font = new System.Drawing.Font("MingLiU-ExtB", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelturn.Location = new System.Drawing.Point(174, 9);
            this.labelturn.Name = "labelturn";
            this.labelturn.Size = new System.Drawing.Size(213, 34);
            this.labelturn.TabIndex = 1;
            this.labelturn.Text = "Player Turn";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.labelturn);
            this.Controls.Add(this.playerlabel);
            this.Name = "Form1";
            this.Text = "Othello Game";
            this.Load += new System.EventHandler(this._StartGame);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label playerlabel;
        private System.Windows.Forms.Label labelturn;
    }
}

