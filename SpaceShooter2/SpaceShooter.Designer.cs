namespace SpaceShooter2
{
    partial class SpaceShooter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SpaceShooter));
            this.labelScore = new System.Windows.Forms.Label();
            this.shieldBar = new System.Windows.Forms.ProgressBar();
            this.pnlEsc = new System.Windows.Forms.Panel();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.labelShield = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.player = new System.Windows.Forms.PictureBox();
            this.lblRivelScore = new System.Windows.Forms.Label();
            this.pnlEsc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.player)).BeginInit();
            this.SuspendLayout();
            // 
            // labelScore
            // 
            this.labelScore.AutoSize = true;
            this.labelScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.labelScore.ForeColor = System.Drawing.Color.White;
            this.labelScore.Location = new System.Drawing.Point(154, 702);
            this.labelScore.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelScore.Name = "labelScore";
            this.labelScore.Size = new System.Drawing.Size(55, 46);
            this.labelScore.TabIndex = 6;
            this.labelScore.Text = " 0";
            this.labelScore.Click += new System.EventHandler(this.labelScore_Click);
            // 
            // shieldBar
            // 
            this.shieldBar.Location = new System.Drawing.Point(677, 706);
            this.shieldBar.Margin = new System.Windows.Forms.Padding(4);
            this.shieldBar.Name = "shieldBar";
            this.shieldBar.Size = new System.Drawing.Size(277, 34);
            this.shieldBar.TabIndex = 9;
            this.shieldBar.Value = 100;
            // 
            // pnlEsc
            // 
            this.pnlEsc.BackColor = System.Drawing.Color.Transparent;
            this.pnlEsc.Controls.Add(this.btnLogOut);
            this.pnlEsc.Controls.Add(this.btnExit);
            this.pnlEsc.Location = new System.Drawing.Point(393, 301);
            this.pnlEsc.Margin = new System.Windows.Forms.Padding(4);
            this.pnlEsc.Name = "pnlEsc";
            this.pnlEsc.Size = new System.Drawing.Size(175, 149);
            this.pnlEsc.TabIndex = 11;
            this.pnlEsc.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlEsc_Paint);
            // 
            // btnLogOut
            // 
            this.btnLogOut.BackgroundImage = global::SpaceShooter2.Properties.Resources.Log_Our_Button;
            this.btnLogOut.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLogOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogOut.Location = new System.Drawing.Point(21, 20);
            this.btnLogOut.Margin = new System.Windows.Forms.Padding(4);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(128, 59);
            this.btnLogOut.TabIndex = 11;
            this.btnLogOut.UseVisualStyleBackColor = true;
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackgroundImage = global::SpaceShooter2.Properties.Resources.Exit_Button;
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Location = new System.Drawing.Point(21, 86);
            this.btnExit.Margin = new System.Windows.Forms.Padding(4);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(128, 59);
            this.btnExit.TabIndex = 10;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // labelShield
            // 
            this.labelShield.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.labelShield.ForeColor = System.Drawing.Color.White;
            this.labelShield.Image = global::SpaceShooter2.Properties.Resources.Shield;
            this.labelShield.Location = new System.Drawing.Point(498, 702);
            this.labelShield.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelShield.Name = "labelShield";
            this.labelShield.Size = new System.Drawing.Size(171, 46);
            this.labelShield.TabIndex = 8;
            this.labelShield.Click += new System.EventHandler(this.labelShield_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Image = ((System.Drawing.Image)(resources.GetObject("label1.Image")));
            this.label1.Location = new System.Drawing.Point(13, 687);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 66);
            this.label1.TabIndex = 7;
            // 
            // player
            // 
            this.player.Image = global::SpaceShooter2.Properties.Resources.Up;
            this.player.Location = new System.Drawing.Point(414, 583);
            this.player.Margin = new System.Windows.Forms.Padding(4);
            this.player.Name = "player";
            this.player.Size = new System.Drawing.Size(112, 75);
            this.player.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.player.TabIndex = 4;
            this.player.TabStop = false;
            this.player.Tag = "player";
            // 
            // lblRivelScore
            // 
            this.lblRivelScore.AutoSize = true;
            this.lblRivelScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRivelScore.ForeColor = System.Drawing.Color.White;
            this.lblRivelScore.Location = new System.Drawing.Point(12, 25);
            this.lblRivelScore.Name = "lblRivelScore";
            this.lblRivelScore.Size = new System.Drawing.Size(88, 25);
            this.lblRivelScore.TabIndex = 0;
            this.lblRivelScore.Text = "Score : ";
            this.lblRivelScore.Click += new System.EventHandler(this.lblRivelScore_Click);
            // 
            // SpaceShooter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(982, 753);
            this.Controls.Add(this.lblRivelScore);
            this.Controls.Add(this.pnlEsc);
            this.Controls.Add(this.shieldBar);
            this.Controls.Add(this.labelShield);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelScore);
            this.Controls.Add(this.player);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SpaceShooter";
            this.Text = "SpaceShooter";
            this.Load += new System.EventHandler(this.SpaceShooter_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.IsKeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.IsKeyUp);
            this.pnlEsc.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.player)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.PictureBox player;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelScore;
        private System.Windows.Forms.ProgressBar shieldBar;
        private System.Windows.Forms.Label labelShield;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Panel pnlEsc;
        private System.Windows.Forms.Button btnLogOut;
        private System.Windows.Forms.Label lblRivelScore;
    }
}

