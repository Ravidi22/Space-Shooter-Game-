using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace SpaceShooter2.ConnectUser
{
    public class Verification
    {
        private static Random _rnd;
        private string _code;
        private const int ZeroAsciiCode = 48;
        private const int NineAsciiCode = 57;
        private SmtpClient _smtpClient;
        private MailMessage _mailMessage;
        private string _emailAddress = "spaceinvadorsteam@gmail.com";
        private string _emailPassword = "klxlitqfhxokalkd";

        public Verification()
        {
            InitSmtpClient();
            _rnd = new Random();
            _code = "";
        }

        public string SendVerification(string contactDetails)
        {
            return SendCodeByEmail(contactDetails);
        }

        #region Email

        private void InitSmtpClient()
        {
            _smtpClient = new SmtpClient("smtp.gmail.com", 587)
            {
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(_emailAddress, _emailPassword),
                DeliveryMethod = SmtpDeliveryMethod.Network
            };
        }

        private string SendCodeByEmail(string contactDetails)
        {
            _mailMessage = new MailMessage(new MailAddress(_emailAddress), new MailAddress(contactDetails));
            _mailMessage.Subject = "Verification code to play SpaceInvadors";
            _mailMessage.Body = CreateEmailMessageBody();
            Task SendMailTask = new Task(() => _smtpClient.Send(_mailMessage));
            SendMailTask.Start();
            return _code;
        }

        private string CreateEmailMessageBody()
        {
            GenerateCode();
            var emailBody = File.ReadAllText(@"E:\GameProjects\Document\EmailBody.txt");
            return emailBody.Replace("[insert reset code here]", _code);
        }

        #endregion

        private void GenerateCode()
        {
            for (int i = 0; i < 9; i++)
            {
                _code += (char)_rnd.Next(ZeroAsciiCode, NineAsciiCode + 1);
            }
        }
    }

}
