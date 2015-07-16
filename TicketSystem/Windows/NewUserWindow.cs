using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicketSystem.Windows
{
    public partial class NewUserWindow : Form
    {
        public NewUserWindow()
        {
            InitializeComponent();
            fillTypCB();
        }

        private void fillTypCB()
        {
            List<string> typs = LoginWindow.connection.getTyp();
           
            foreach(string typ in typs)
            {
                typCB.Items.Add(typ);
            }
        }

        private void addUserButton_Click(object sender, EventArgs e)
        {
            string fname = fnameTextBox.Text;
            string lname = lnameTextBox.Text;
            string username = usernameTextBox.Text;
            string password = passwordTextBox.Text;
            password = CalculateMD5Hash(password);
            string email = emailTextBox.Text;
            string typ = typCB.Text;

            bool addOK = LoginWindow.connection.addUser(fname, lname, username, password, email, typ);

            if (addOK == true)
            {
                MessageBox.Show("User was added!");
                this.Close();
            }
            else MessageBox.Show("User could not be added!", null, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
