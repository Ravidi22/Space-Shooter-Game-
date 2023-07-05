using SpaceShooter2.ConnectUser;
using SpaceShooter2.Server;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceShooter2
{
    public partial class UserInviteScreen : Form
    {
        private readonly ServerManager _serverManager;

        private string myName = MainMenu.User.Name;
        private ObservableCollection<string> onlineUsers;


        public UserInviteScreen(ServerManager serverManager)
        {
            InitializeComponent();
            _serverManager = serverManager;
            _serverManager.PropertyChanged += ServerManager_PropertyChanged;
            onlineUsers = _serverManager.UsersNames;
            ShowFriends();
        }
        private void ShowFriends()
        {
            var usersCount = onlineUsers?.Count ?? 0;
            if (usersCount > 0)
            {
                pnlNofriends.Visible = false;

                foreach (var user in onlineUsers)
                {
                    CreatePlayerInvitePanel(user);
                }
            }
            else { pnlNofriends.Visible = true; }
        }
        private void ServerManager_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "UsersNames")
            {
                onlineUsers = _serverManager.UsersNames;
                if (onlineUsers.Count == 0)
                {
                    // Remove all player panels on the UI thread
                    this.Invoke((Action)(() =>
                    {
                        foreach (var panel in this.Controls.OfType<Panel>().ToList())
                        {
                            if (panel.Name.StartsWith("playerPanel_"))
                            {
                                this.Controls.Remove(panel);
                            }
                        }
                        pnlNofriends.Visible = true;
                    }));
                }
                else
                {
                    // If previous online friends was 0, delete empty panel and show player panels
                    this.Invoke((Action)(() =>
                       {
                           pnlNofriends.Visible = false;
                       }));

                       
                    foreach (var user in onlineUsers)
                    {
                        if (!this.Controls.ContainsKey("playerPanel_" + user))
                        {
                            CreatePlayerInvitePanel(user);
                        }
                    }

                    //Remove any extra player panels
                    foreach (var panel in this.Controls.OfType<Panel>().ToList())
                    {
                        if (panel.Name.StartsWith("playerPanel_") && !onlineUsers.Contains(panel.Name.Substring("playerPanel_".Length)))
                        {
                            this.Invoke((Action)(() =>
                            {
                                this.Controls.Remove(panel);
                            }));                           
                        }
                    }

                }
            } 
            if  (e.PropertyName == "RivalName")
            {
                var isRequestReceived = _serverManager.IsRequestReceived;
                if (isRequestReceived)
                {
                    if (!this.Controls.ContainsKey("RequestPanel_" + _serverManager.RivalName))
                    {
                        CreateRequestPanel(_serverManager.RivalName);
                    }    
                }
            }
        }

        private void UserInviteScreen_Load(object sender, EventArgs e)
        {
            _serverManager.CurrForm = this;
            lblHelloPlayer.Text += MainMenu.User.Name + "!";
            _serverManager.ReadyToPlay(myName);

            this.Closed += new EventHandler(UserInviteScreen_Closed);
            this.FormClosing += new FormClosingEventHandler(UserInviteScreen_Closing);
        }
        private void UserInviteScreen_Closed(object sender, EventArgs e)
        {
            _serverManager.PlayerDisconnected();
        }
        private void UserInviteScreen_Closing(object sender, FormClosingEventArgs e)
        {
            _serverManager.PlayerDisconnected();
        }

        private void InviteButton_Click(object sender, EventArgs e)
        {
            Button inviteButton = (Button)sender;

            string playerName = inviteButton.Name.Substring("inviteButton_".Length);

            _serverManager.SendRequestToPlay(playerName, myName);
        }


        public void CreatePlayerInvitePanel(string playerName)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<string>(CreatePlayerInvitePanel), playerName);
                return;
            }
            Panel playerPanel = new Panel();
            playerPanel.Name = "playerPanel_" + playerName;
            playerPanel.Size = new Size(260, 59);
            playerPanel.BackColor = Color.Transparent;
            playerPanel.BorderStyle = BorderStyle.FixedSingle;

            Label playerNameLabel = new Label();
            playerNameLabel.Name = "playerNameLabel_" + playerName;
            playerNameLabel.Text = playerName;
            playerNameLabel.Font = lbltext.Font;
            playerNameLabel.AutoSize = false;
            playerNameLabel.ForeColor = Color.White;
            playerNameLabel.BackColor = Color.Transparent;
            playerNameLabel.TextAlign = ContentAlignment.MiddleRight;
            playerNameLabel.Dock = DockStyle.Left;

            Button inviteButton = new Button();
            inviteButton.Name = "inviteButton_" + playerName;
            inviteButton.Size = btnExit.Size;
            inviteButton.BackColor = Color.Transparent;
            inviteButton.AutoSize = false;
            inviteButton.Tag = playerName;
            inviteButton.BackgroundImage = Properties.Resources.Invite;
            inviteButton.BackgroundImageLayout = ImageLayout.Stretch;
            inviteButton.ImageAlign = ContentAlignment.MiddleLeft;
            inviteButton.FlatStyle = FlatStyle.Flat;
            inviteButton.BackColor = Color.Transparent;
            inviteButton.Click += InviteButton_Click;
            inviteButton.Dock = DockStyle.Right;

            playerPanel.Controls.Add(playerNameLabel);
            playerPanel.Controls.Add(inviteButton);

            var panelCount = 0;

            foreach (Control control in this.Controls)
            {
                if (control is Panel && control.Name.StartsWith("playerPanel_"))
                {
                    panelCount++;
                }
            }
            int totalHeight = (panelCount + 1) * playerPanel.Height;
            int StartY = 100;

            playerPanel.Location = new Point((this.ClientSize.Width - playerPanel.Width) / 2, StartY + totalHeight);

            this.Controls.Add(playerPanel);
        }



        public void CreateRequestPanel(string hostPlayerName)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<string>(CreateRequestPanel), hostPlayerName);
                return;
            }
            Panel InvitePanel = new Panel();
            InvitePanel.Name = "RequestPanel_" + hostPlayerName;
            InvitePanel.Tag = hostPlayerName;
            InvitePanel.Size = new Size(300, 74);
            InvitePanel.BackColor = Color.Transparent;
            InvitePanel.BorderStyle = BorderStyle.FixedSingle;
            InvitePanel.Location = new Point((this.ClientSize.Width - InvitePanel.Width) / 2, 500);

            Label playerNameLabel = new Label();
            playerNameLabel.Name = "playerNameLabel_" + hostPlayerName;
            playerNameLabel.Text = hostPlayerName + " want to play!";
            playerNameLabel.Font = lbltext.Font;
            playerNameLabel.AutoSize = false;
            playerNameLabel.ForeColor = Color.White;
            playerNameLabel.BackColor = Color.Transparent;
            playerNameLabel.TextAlign = ContentAlignment.MiddleRight;
            playerNameLabel.Dock = DockStyle.Fill;

            Button BtnAccept = new Button();
            BtnAccept.Name = "BtnAccept_" + hostPlayerName;
            BtnAccept.Size = new Size(57, 44);
            BtnAccept.BackColor = Color.Transparent;
            BtnAccept.AutoSize = false;
            BtnAccept.Tag = hostPlayerName;
            BtnAccept.BackgroundImage = Properties.Resources.accept;
            BtnAccept.BackgroundImageLayout = ImageLayout.Stretch;
            BtnAccept.ImageAlign = ContentAlignment.MiddleLeft;
            BtnAccept.FlatStyle = FlatStyle.Flat;
            BtnAccept.BackColor = Color.Transparent;
            BtnAccept.Click += BtnAccept_Click;
            BtnAccept.Dock = DockStyle.Right;

            Button BtnDenay = new Button();
            BtnDenay.Name = "BtnAccept_" + hostPlayerName;
            BtnDenay.Size = new Size(57, 44);
            BtnDenay.BackColor = Color.Transparent;
            BtnDenay.AutoSize = false;
            BtnDenay.Tag = hostPlayerName;
            BtnDenay.BackgroundImage = Properties.Resources.denay;
            BtnDenay.BackgroundImageLayout = ImageLayout.Stretch;
            BtnDenay.ImageAlign = ContentAlignment.MiddleLeft;
            BtnDenay.FlatStyle = FlatStyle.Flat;
            BtnDenay.BackColor = Color.Transparent;
            BtnDenay.Click += BtnDenay_Click;
            BtnDenay.Dock = DockStyle.Right;

            InvitePanel.Controls.Add(playerNameLabel);
            InvitePanel.Controls.Add(BtnAccept);
            InvitePanel.Controls.Add(BtnDenay);

            this.Controls.Add(InvitePanel);
        }
        private void BtnDenay_Click(object sender, EventArgs e)
        {
            Button btnDenay = (Button)sender;
            _serverManager.RefuseToPlay();
            this.Invoke((Action)(() =>
            {
                if (this.Controls.ContainsKey("RequestPanel_" + btnDenay.Tag.ToString()))
                {
                    this.Controls.RemoveByKey("RequestPanel_" + btnDenay.Tag.ToString());
                }
            }));

        }


        private void BtnAccept_Click(object sender, EventArgs e)
        {
            Button btnAccept = (Button)sender;
            this.Invoke((Action)(() =>
            {
                if (this.Controls.ContainsKey("RequestPanel_" + btnAccept.Tag.ToString()))
                {
                    this.Controls.RemoveByKey("RequestPanel_" + btnAccept.Tag.ToString());
                }
            }));
            _serverManager.AgreeToPlay(myName);
        }


        private void lbltext_Click(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            _serverManager.PlayerDisconnected();
            Application.Exit();
        }

        private void btnStartPlay_Click(object sender, EventArgs e)
        {
            new SpaceShooter(_serverManager).Show();
        }
    }
}
