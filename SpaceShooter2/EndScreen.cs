using SpaceShooter2.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceShooter2
{
    public partial class EndScreen : Form
    {
        private ServerManager _serverManager;
        private SpaceShooter gameForm;
        public EndScreen(ServerManager serverManager , SpaceShooter gameform)
        {
            InitializeComponent();
            _serverManager = serverManager; 
            gameForm = gameform;
        }

        private void pnlWorL_Paint(object sender, PaintEventArgs e)
        {

        }

        private void EndScreen_Load(object sender, EventArgs e)
        {
            ShowLorWPanel();
            Thread.Sleep(400);
            pnlWorL.Visible = false;
            UpdateTable();
        }
        private void ShowLorWPanel()
        {
            pnlLeaderBoard.Visible = false;
            if (UpdateWinner()) pnlWorL.BackgroundImage = Properties.Resources.winner;
            else pnlWorL.BackgroundImage = Properties.Resources.Defeat2;
        }

        private bool UpdateWinner()
        {
            if (gameForm.Score > gameForm.EnemyScore) return true;
            return false;
        }
        private void UpdateTable()
        {
            pnlLeaderBoard.Visible = true;
            if (UpdateWinner())
            {
                this.lblFirst.Text = MainMenu.User.Name;
                this.lblSecond.Text = _serverManager.RivalName;
                this.lblScore1.Text = gameForm.Score.ToString();
                this.lblScore2.Text = gameForm.EnemyScore.ToString();
            }
            else
            {
                this.lblFirst.Text = _serverManager.RivalName;
                this.lblSecond.Text = MainMenu.User.Name;
                this.lblScore1.Text = gameForm.EnemyScore.ToString(); 
                this.lblScore2.Text = gameForm.Score.ToString();
            }
        }

        private void btnBacktoLobby_Click(object sender, EventArgs e)
        {
            new UserInviteScreen(_serverManager).Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            _serverManager.PlayerDisconnected();
            Application.Exit();
        }
    }
}
