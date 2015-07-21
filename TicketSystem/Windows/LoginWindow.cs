using System;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace TicketSystem
{
    public partial class LoginWindow : Form
    {
        public static DBconnections.DBcommands connection; 

        public LoginWindow()
        {
            InitializeComponent();
            //this.checkNetworkConnection();
            this.usethelocalDB();
        }

        private void checkNetworkConnection()
        {
            bool checkconnection = System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable();

            if (checkconnection == true) connection = new DBconnections.MysqlDB();
             else Console.WriteLine("NO INTERNET! checkout XML or something like that!");
        }

        private void usethelocalDB()
        {

        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            string unameInput = uNameTextbox.Text;
            string passwdInput = passwdTextBox.Text;

            string secPasswd = CalculateMD5Hash(passwdInput);

            bool acceptAccess = connection.checkLoginData(unameInput, secPasswd);

            if (acceptAccess == true)
            {
                bool userIsAdmin = connection.isAdmin(unameInput);

                if (userIsAdmin == true)
                {
                    Windows.AdminMainWindow amw = new Windows.AdminMainWindow(unameInput);
                    this.Visible = false;
                    amw.Show();
                }
                else
                {
                    UserMainWindow umw = new UserMainWindow(unameInput);
                    this.Visible = false;
                    umw.Show();
                }

            }
            else MessageBox.Show("User or password false! Does the user exist?");
        }

        private void abortButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private string CalculateMD5Hash(string input)
        {
            // step 1, calculate MD5 hash from input
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);

            // step 2, convert byte array to hex string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }
    }
}
