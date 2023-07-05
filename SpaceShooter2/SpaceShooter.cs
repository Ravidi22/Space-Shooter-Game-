using SpaceShooter2.Lazers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UITimer = System.Windows.Forms.Timer;
using SpaceShooter2.ConnectUser;
using SpaceShooter2.Server;
using System.Threading;

namespace SpaceShooter2
{
    public partial class SpaceShooter : Form
    {
        public static User User;
        ServerManager _serverManager;

        #region game related parmeters

        SpawnManger spawnManger;
        CollisionManger collisionManger;
        EnemyMovment movmentManger;

        bool goLeft, goRight, goUp, goDown;

        int playerShield = 100;
        int speed = 10;
        int score = 0;
        Direction playerDirection;

        UITimer gameTimer1 = new UITimer();

        PictureBox[] BoomAnimation = new PictureBox[8];
        UITimer boomTimer = new UITimer();
        int enemyScore = 0;
        #endregion
        public SpawnManger SpawnManger { get => spawnManger; }
        public int PlayerShield { get => playerShield; set => playerShield = value; }
        public int Score { get => score; set => score = value; }

        public int EnemyScore { get => enemyScore; set => enemyScore = value; }
        private void GameTick(object sender, EventArgs e)
        {
            player.BringToFront();
            IsPlayerAlive();
            labelScore.Text = score.ToString();
            MovePlayer();
            collisionManger.DetectCollision();
            movmentManger.MoveUfo();
            if (!_serverManager.IsAlone)
            {
                EnemyScore = _serverManager.CheckRivalPoints();
                if (_serverManager.IsGameOnline) lblRivelScore.Text = _serverManager.RivalName + " Score : " + EnemyScore.ToString();
            }        
            else lblRivelScore.Visible = false;
        }

        public SpaceShooter(ServerManager serverManager)
        {
            gameTimer1.Interval = 100;
            gameTimer1.Start();
            gameTimer1.Tick += new EventHandler(GameTick);
            _serverManager = serverManager;
            InitializeComponent();
        }

        private void labelScore_Click(object sender, EventArgs e)
        {

        }

        private void SpaceShooter_Closed(object sender, EventArgs e)
        {
            _serverManager.PlayerDisconnected();
        }
        private void SpaceShooter_Closing(object sender, FormClosingEventArgs e)
        {
            _serverManager.PlayerDisconnected();
        }
        private void IsKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goLeft = true;
                playerDirection = Direction.left;
                player.Image = Properties.Resources.Left;
            }
            if (e.KeyCode == Keys.Right)
            {
                goRight = true;
                playerDirection = Direction.right;
                player.Image = Properties.Resources.Right;
            }
            if (e.KeyCode == Keys.Up)
            {
                goUp = true;
                playerDirection = Direction.up;
                player.Image = Properties.Resources.Up;
            }
            if (e.KeyCode == Keys.Down)
            {
                goDown = true;
                playerDirection = Direction.down;
                player.Image = Properties.Resources.Down;
            }
            if (e.KeyCode == Keys.Escape)
            {
                pnlEsc.Visible = true;
            }
        }

        private void IsKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goLeft = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                goRight = false;
            }
            if (e.KeyCode == Keys.Up)
            {
                goUp = false;
            }
            if (e.KeyCode == Keys.Down)
            {
                goDown = false;
            }
            if (e.KeyCode == Keys.Space)
            {
                ShootLazer(playerDirection);
            }
            if (e.KeyCode == Keys.Escape)
            {
                pnlEsc.Visible = false;
            }
        }

        private void SpaceShooter_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < BoomAnimation.Length; i++)
            {
                BoomAnimation[i] = new PictureBox();
                BoomAnimation[i].Image = (Image)Properties.Resources.ResourceManager.GetObject("boom" + (i + 1));
                BoomAnimation[i].Enabled = true;
                BoomAnimation[i].Visible = false;
                BoomAnimation[i].BackColor = Color.Transparent;
                BoomAnimation[i].SizeMode = PictureBoxSizeMode.StretchImage;
                BoomAnimation[i].Size = player.Size;
                Controls.Add(BoomAnimation[i]);
            }
            pnlEsc.Visible = false;
            spawnManger = new SpawnManger(this);
            collisionManger = new CollisionManger(this);
            movmentManger = new EnemyMovment(this);
        }

        private void pnlEsc_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            this.Close();
            new MainMenu().Show();
            //stay in application
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
            _serverManager.PlayerDisconnected();
        }

        private void MovePlayer()
        {
            if (goLeft == true && player.Left > 0)
            {
                player.Left -= speed;
            }
            if (goRight == true && player.Left + player.Width < this.ClientSize.Width)
            {
                player.Left += speed;
            }
            if (goUp == true && player.Top > 0)
            {
                player.Top -= speed;
            }
            if (goDown == true && player.Top + player.Height < this.ClientSize.Height - 100)
            {
                player.Top += speed;
            }
        }
        private void IsPlayerAlive()
        {
            if (playerShield > 1)
            {
                shieldBar.Value = PlayerShield;
            }
            else
            {
                // add boom animation
                boomTimer.Interval = 100;
                boomTimer.Tick += new EventHandler(BoomTimer_Tick);
                boomTimer.Enabled = true;
                gameTimer1.Stop();
                movmentManger.EndGame();
                SpawnManger.EndGame();
                Thread.Sleep(200);
                this.Dispose();
                //_serverManager.EndGame(User.Name);
                new EndScreen(_serverManager ,this).ShowDialog();
            }

        }

        private void labelShield_Click(object sender, EventArgs e)
        {

        }

        private void lblRivelScore_Click(object sender, EventArgs e)
        {

        }

        int count = 0;
        private void BoomTimer_Tick(object sender, EventArgs e)
        {
            count++;
            if (player != null && count < 8)
            {
                BoomAnimation[count].Location = player.Location;
                BoomAnimation[count].Visible = true;
                BoomAnimation[count].BringToFront();
            }
            if (count == 9)
            {
                boomTimer.Enabled = false;
                for (int i = 0; i < BoomAnimation.Length; i++)
                {
                    BoomAnimation[i].Visible = false;
                }
                count = 0;
            }
            player.Image = null;
        }

        private void ShootLazer(Direction direction)
        {
            Lazer newLazer = new LazerBlue();
            newLazer.Direction = playerDirection;
            newLazer.LazerPosLeft = player.Left + (player.Width / 2);
            newLazer.LazerPosTop = player.Top + (player.Height / 2);
            newLazer.CreateLazer(this);
        }
    }
}
