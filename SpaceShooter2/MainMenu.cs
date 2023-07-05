using SpaceShooter2.ConnectUser;
using SpaceShooter2.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebSocketSharp;

namespace SpaceShooter2
{

    public partial class MainMenu : Form
    {
        public static User User;
        public static ServerManager serverManager = new ServerManager();
        ResetPassword resetPassword = new ResetPassword(serverManager);
        public MainMenu()
        {       
            InitializeComponent();
            serverManager.CurrForm = this;  
        }

        private void btnMenuLogIn_Click(object sender, EventArgs e)
        {
            pnlLogIn.Visible = true;
            pnlButtons.Visible = false;
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            pnlButtons.Visible = false;
            pnlSignIn.Visible = true;
        }

        private void btnForgotPassword_Click(object sender, EventArgs e)
        {
            pnlLogIn.Visible = false;
            pnlForgotPass.Visible = true;

        }

        private void btnGoToSign_Click(object sender, EventArgs e)
        {
            pnlLogIn.Visible = false;
            pnlSignIn.Visible = true;
        }

        private void btnLogIn2_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text != "" && txtPassword.Text != "")
            {
                User = new User(txtUserName.Text, null, txtPassword.Text);
                if (serverManager.CheckUserLogin(txtUserName.Text, txtPassword.Text) != null)
                {
                   pnlLogIn.Visible = false;
                   this.Visible = false;
                   new UserInviteScreen(serverManager).ShowDialog();
                }
                else
                {
                    MessageBox.Show("User name or password is incorrect", "user Input Erorr");
                }
            }
            else
            {
                MessageBox.Show("You must fill in all the data");
            }

        }

        private void btnSignIn2_Click(object sender, EventArgs e)
        {
            if (txtUserNameS.Text != "" && txtPassS.Text != "" && txtEmail.Text != "")
            {                
                if (Validation.IsValidUserName(txtUserNameS.Text) && Validation.IsValidEmail(txtEmail.Text) && Validation.IsValidPassword(txtPassS.Text))
                {
                    User = new User(txtUserNameS.Text, txtEmail.Text, txtPassS.Text);
                    if (!serverManager.IsNameExist(User.Name) && !serverManager.IsEmailExist(User.Email))
                    {
                        pnlSignIn.Visible = false;
                        SpaceShooter.User = User;
                        serverManager.CreateUser(User);
                        this.Visible = false;
                        new UserInviteScreen(serverManager).ShowDialog();
                    }   
                    else
                    {
                        MessageBox.Show("Username or Email is allready taken");
                    }
                }
            }
            else
            {
                MessageBox.Show("You must fill in all the data");
            }
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            pnlLogIn.Visible = false;
            pnlSignIn.Visible = false;
            pnlButtons.Visible = true;
            pnlForgotPass.Visible = false;
        }

        private void pnlLogIn_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtEmailF_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (txtEmailF.Text != String.Empty)
            {
                if (resetPassword.CheckEmailExist(txtEmailF.Text)) 
                {
                    resetPassword.SendVerificationCode(txtEmailF.Text);
                    lblForgotPass.Image = Properties.Resources.Code;
                    txtEmailF.Visible = false;
                    btnSend.Visible = false;
                    btnSubmit.Visible = true;
                    txtCode.Visible = true;
                }
            }
            else MessageBox.Show("You must enter your email");
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtCode.Text != String.Empty)
            {
                resetPassword.SubmitCode(txtCode.Text);
                lblForgotPass.Image = Properties.Resources.Password;
                txtCode.Visible = false;
                btnSubmit.Visible = false;
                btnChangePass.Visible = true;
                txtChangePass.Visible = true;

            }
        }

        private void btnChangePass_Click(object sender, EventArgs e)
        {
            if (txtChangePass.Text != string.Empty)
            {
                resetPassword.ResetPass(txtChangePass.Text);
                MessageBox.Show("Password changed");
                pnlForgotPass.Visible = false;
                pnlLogIn.Visible = true;
            }

        }

        private void lblForgotPass_Click(object sender, EventArgs e)
        {

        }
    }
}
