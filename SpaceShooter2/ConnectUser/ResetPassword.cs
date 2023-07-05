using SpaceShooter2.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceShooter2.ConnectUser
{
    public class ResetPassword
    {
        private string _textCode;
        private Verification _verification;
        private ServerManager _server;
        private string email;

        
        public ResetPassword(ServerManager serverManager)
        {
            _server = serverManager;
            _verification = new Verification();
        }
        public bool CheckEmailExist(string email)
        {
            if (_server.IsEmailExist(email)) return true;
            MessageBox.Show("Email don't exist");
            return false;
        }


        public void SubmitCode(string UserInput)
        {
            if (!UserInput.Equals(_textCode))
            {
                MessageBox.Show("Code is incorrect"); 
                return;
            }
        }
        public void SendVerificationCode(string UserInput)
        {
            email = UserInput;
            _textCode = _verification.SendVerification(UserInput);
        }

        public void ResetPass(string UserInput)
        {
            _server.ResetPassword(UserInput, email);
            Task.Delay(2000);
        }
     
    }
}
