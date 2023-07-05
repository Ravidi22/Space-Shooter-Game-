namespace SpaceShooter2
{
    partial class UserInviteScreen
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
            this.btnExit = new System.Windows.Forms.Button();
            this.lbltext = new System.Windows.Forms.Label();
            this.lblHelloPlayer = new System.Windows.Forms.Label();
            this.pnlTopLeft = new System.Windows.Forms.Panel();
            this.PicAvatar = new System.Windows.Forms.PictureBox();
            this.btnStartPlay = new System.Windows.Forms.Button();
            this.pnlNofriends = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlTopLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicAvatar)).BeginInit();
            this.pnlNofriends.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.Transparent;
            this.btnExit.BackgroundImage = global::SpaceShooter2.Properties.Resources.Exit_Button;
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Location = new System.Drawing.Point(813, 34);
            this.btnExit.Margin = new System.Windows.Forms.Padding(4);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(128, 59);
            this.btnExit.TabIndex = 11;
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lbltext
            // 
            this.lbltext.AutoSize = true;
            this.lbltext.BackColor = System.Drawing.Color.Black;
            this.lbltext.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltext.ForeColor = System.Drawing.Color.White;
            this.lbltext.Location = new System.Drawing.Point(12, 34);
            this.lbltext.Name = "lbltext";
            this.lbltext.Size = new System.Drawing.Size(107, 22);
            this.lbltext.TabIndex = 12;
            this.lbltext.Text = "invited you";
            this.lbltext.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbltext.Visible = false;
            this.lbltext.Click += new System.EventHandler(this.lbltext_Click);
            // 
            // lblHelloPlayer
            // 
            this.lblHelloPlayer.AutoSize = true;
            this.lblHelloPlayer.BackColor = System.Drawing.Color.Black;
            this.lblHelloPlayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHelloPlayer.ForeColor = System.Drawing.Color.White;
            this.lblHelloPlayer.Location = new System.Drawing.Point(122, 47);
            this.lblHelloPlayer.Name = "lblHelloPlayer";
            this.lblHelloPlayer.Size = new System.Drawing.Size(62, 22);
            this.lblHelloPlayer.TabIndex = 13;
            this.lblHelloPlayer.Text = "Hello ";
            this.lblHelloPlayer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlTopLeft
            // 
            this.pnlTopLeft.BackColor = System.Drawing.Color.Transparent;
            this.pnlTopLeft.Controls.Add(this.PicAvatar);
            this.pnlTopLeft.Controls.Add(this.lblHelloPlayer);
            this.pnlTopLeft.Location = new System.Drawing.Point(12, 12);
            this.pnlTopLeft.Name = "pnlTopLeft";
            this.pnlTopLeft.Size = new System.Drawing.Size(348, 117);
            this.pnlTopLeft.TabIndex = 14;
            // 
            // PicAvatar
            // 
            this.PicAvatar.BackgroundImage = global::SpaceShooter2.Properties.Resources.Up_Red;
            this.PicAvatar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PicAvatar.Location = new System.Drawing.Point(14, 22);
            this.PicAvatar.Name = "PicAvatar";
            this.PicAvatar.Size = new System.Drawing.Size(91, 75);
            this.PicAvatar.TabIndex = 14;
            this.PicAvatar.TabStop = false;
            // 
            // btnStartPlay
            // 
            this.btnStartPlay.BackColor = System.Drawing.Color.Transparent;
            this.btnStartPlay.BackgroundImage = global::SpaceShooter2.Properties.Resources.Start;
            this.btnStartPlay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnStartPlay.FlatAppearance.BorderSize = 0;
            this.btnStartPlay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStartPlay.ForeColor = System.Drawing.Color.White;
            this.btnStartPlay.Location = new System.Drawing.Point(813, 101);
            this.btnStartPlay.Margin = new System.Windows.Forms.Padding(4);
            this.btnStartPlay.Name = "btnStartPlay";
            this.btnStartPlay.Size = new System.Drawing.Size(128, 59);
            this.btnStartPlay.TabIndex = 15;
            this.btnStartPlay.UseVisualStyleBackColor = false;
            this.btnStartPlay.Click += new System.EventHandler(this.btnStartPlay_Click);
            // 
            // pnlNofriends
            // 
            this.pnlNofriends.BackColor = System.Drawing.Color.Transparent;
            this.pnlNofriends.Controls.Add(this.pictureBox1);
            this.pnlNofriends.Controls.Add(this.label1);
            this.pnlNofriends.Location = new System.Drawing.Point(287, 308);
            this.pnlNofriends.Name = "pnlNofriends";
            this.pnlNofriends.Size = new System.Drawing.Size(353, 111);
            this.pnlNofriends.TabIndex = 15;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Image = global::SpaceShooter2.Properties.Resources.SadFace1;
            this.pictureBox1.Location = new System.Drawing.Point(222, 24);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(91, 75);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(34, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 22);
            this.label1.TabIndex = 13;
            this.label1.Text = "No friends online";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UserInviteScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::SpaceShooter2.Properties.Resources.Game_bg;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(982, 753);
            this.Controls.Add(this.pnlNofriends);
            this.Controls.Add(this.btnStartPlay);
            this.Controls.Add(this.pnlTopLeft);
            this.Controls.Add(this.lbltext);
            this.Controls.Add(this.btnExit);
            this.Name = "UserInviteScreen";
            this.Text = "UserInviteScreen";
            this.Load += new System.EventHandler(this.UserInviteScreen_Load);
            this.pnlTopLeft.ResumeLayout(false);
            this.pnlTopLeft.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicAvatar)).EndInit();
            this.pnlNofriends.ResumeLayout(false);
            this.pnlNofriends.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lbltext;
        private System.Windows.Forms.Label lblHelloPlayer;
        private System.Windows.Forms.Panel pnlTopLeft;
        private System.Windows.Forms.PictureBox PicAvatar;
        private System.Windows.Forms.Button btnStartPlay;
        private System.Windows.Forms.Panel pnlNofriends;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
    }
}