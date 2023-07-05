using SpaceShooter2.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceShooter2.ConnectUser
{
    public class Validation
    {
        public static bool IsValidUserName(string input)
        {
            var regex = new Regex(@"^[a-zA-Z][a-zA-Z0-9]{0,7}$");

            if (!regex.IsMatch(input))
            {
                MessageBox.Show("Username must start with a letter and can only contain up to 8 alphanumeric characters.");
                return false;
            }

            return true;
        }

        public static bool IsValidEmail(string input)
        {
            var valid = true;

            try
            {
                var emailAddress = new MailAddress(input);
            }
            catch
            {
                valid = false;
                MessageBox.Show("Incorrect email address");
            }

            return valid;
        }
        public static bool IsValidPassword(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                MessageBox.Show("Password should not be empty");
            }

            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasMiniMaxChars = new Regex(@".{8,15}");
            var hasLowerChar = new Regex(@"[a-z]+");
            var hasSymbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]");

            if (!hasLowerChar.IsMatch(input))
            {
                MessageBox.Show("Password should contain At least one lower case letter");
                return false;
            }
            else if (!hasUpperChar.IsMatch(input))
            {
                MessageBox.Show("Password should contain At least one upper case letter");
                return false;
            }
            else if (!hasMiniMaxChars.IsMatch(input))
            {
                MessageBox.Show("Password should not be less than or greater than 12 characters");
                return false;
            }
            else if (!hasNumber.IsMatch(input))
            {
                MessageBox.Show("Password should contain At least one numeric value");
                return false;
            }

            else if (!hasSymbols.IsMatch(input))
            {
                MessageBox.Show("Password should contain At least one special case characters");
                return false;
            }
            else
            {
                return true;
            }
        }
       
    }
}
