namespace SpaceShooter2
{
    partial class EndScreen
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
            this.pnlWorL = new System.Windows.Forms.Panel();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnBacktoLobby = new System.Windows.Forms.Button();
            this.pnlLeaderBoard = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblFirst = new System.Windows.Forms.Label();
            this.lblSecond = new System.Windows.Forms.Label();
            this.lblScore1 = new System.Windows.Forms.Label();
            this.lblScore2 = new System.Windows.Forms.Label();
            this.pnlLeaderBoard.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlWorL
            // 
            this.pnlWorL.BackColor = System.Drawing.Color.Transparent;
            this.pnlWorL.BackgroundImage = global::SpaceShooter2.Properties.Resources.Defeat2;
            this.pnlWorL.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlWorL.Location = new System.Drawing.Point(1, 3);
            this.pnlWorL.Margin = new System.Windows.Forms.Padding(4);
            this.pnlWorL.Name = "pnlWorL";
            this.pnlWorL.Size = new System.Drawing.Size(1069, 562);
            this.pnlWorL.TabIndex = 0;
            this.pnlWorL.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlWorL_Paint);
            // 
            // btnExit
            // 
            this.btnExit.BackgroundImage = global::SpaceShooter2.Properties.Resources.Exit_Button;
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Location = new System.Drawing.Point(913, 26);
            this.btnExit.Margin = new System.Windows.Forms.Padding(4);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(128, 59);
            this.btnExit.TabIndex = 11;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnBacktoLobby
            // 
            this.btnBacktoLobby.Location = new System.Drawing.Point(886, 92);
            this.btnBacktoLobby.Name = "btnBacktoLobby";
            this.btnBacktoLobby.Size = new System.Drawing.Size(169, 52);
            this.btnBacktoLobby.TabIndex = 0;
            this.btnBacktoLobby.Text = "Back to Lobby";
            this.btnBacktoLobby.UseVisualStyleBackColor = true;
            this.btnBacktoLobby.Click += new System.EventHandler(this.btnBacktoLobby_Click);
            // 
            // pnlLeaderBoard
            // 
            this.pnlLeaderBoard.BackColor = System.Drawing.Color.Transparent;
            this.pnlLeaderBoard.Controls.Add(this.lblScore2);
            this.pnlLeaderBoard.Controls.Add(this.lblScore1);
            this.pnlLeaderBoard.Controls.Add(this.lblSecond);
            this.pnlLeaderBoard.Controls.Add(this.lblFirst);
            this.pnlLeaderBoard.Controls.Add(this.label2);
            this.pnlLeaderBoard.Controls.Add(this.label1);
            this.pnlLeaderBoard.Location = new System.Drawing.Point(407, 226);
            this.pnlLeaderBoard.Name = "pnlLeaderBoard";
            this.pnlLeaderBoard.Size = new System.Drawing.Size(304, 182);
            this.pnlLeaderBoard.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(21, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 22);
            this.label1.TabIndex = 14;
            this.label1.Text = "Name:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Black;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(154, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 22);
            this.label2.TabIndex = 15;
            this.label2.Text = "Score:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFirst
            // 
            this.lblFirst.AutoSize = true;
            this.lblFirst.BackColor = System.Drawing.Color.Black;
            this.lblFirst.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFirst.ForeColor = System.Drawing.Color.White;
            this.lblFirst.Location = new System.Drawing.Point(21, 61);
            this.lblFirst.Name = "lblFirst";
            this.lblFirst.Size = new System.Drawing.Size(69, 22);
            this.lblFirst.TabIndex = 16;
            this.lblFirst.Text = "winner";
            this.lblFirst.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSecond
            // 
            this.lblSecond.AutoSize = true;
            this.lblSecond.BackColor = System.Drawing.Color.Black;
            this.lblSecond.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSecond.ForeColor = System.Drawing.Color.White;
            this.lblSecond.Location = new System.Drawing.Point(21, 104);
            this.lblSecond.Name = "lblSecond";
            this.lblSecond.Size = new System.Drawing.Size(54, 22);
            this.lblSecond.TabIndex = 17;
            this.lblSecond.Text = "loser";
            this.lblSecond.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblScore1
            // 
            this.lblScore1.AutoSize = true;
            this.lblScore1.BackColor = System.Drawing.Color.Black;
            this.lblScore1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScore1.ForeColor = System.Drawing.Color.White;
            this.lblScore1.Location = new System.Drawing.Point(172, 61);
            this.lblScore1.Name = "lblScore1";
            this.lblScore1.Size = new System.Drawing.Size(70, 22);
            this.lblScore1.TabIndex = 18;
            this.lblScore1.Text = "score1";
            this.lblScore1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblScore2
            // 
            this.lblScore2.AutoSize = true;
            this.lblScore2.BackColor = System.Drawing.Color.Black;
            this.lblScore2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScore2.ForeColor = System.Drawing.Color.White;
            this.lblScore2.Location = new System.Drawing.Point(172, 104);
            this.lblScore2.Name = "lblScore2";
            this.lblScore2.Size = new System.Drawing.Size(70, 22);
            this.lblScore2.TabIndex = 19;
            this.lblScore2.Text = "score2";
            this.lblScore2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // EndScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::SpaceShooter2.Properties.Resources.Game_bg;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.pnlLeaderBoard);
            this.Controls.Add(this.btnBacktoLobby);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.pnlWorL);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "EndScreen";
            this.Text = "EndScreen";
            this.Load += new System.EventHandler(this.EndScreen_Load);
            this.pnlLeaderBoard.ResumeLayout(false);
            this.pnlLeaderBoard.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlWorL;
        private System.Windows.Forms.Button btnBacktoLobby;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Panel pnlLeaderBoard;
        private System.Windows.Forms.Label lblScore2;
        private System.Windows.Forms.Label lblScore1;
        private System.Windows.Forms.Label lblSecond;
        private System.Windows.Forms.Label lblFirst;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}