using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace TicketSystem.Windows
{
    public partial class AdminMainWindow : Form
    {
        private int userID;
        private string username;

        public AdminMainWindow(string unameInput)
        {
            InitializeComponent();
            getUserData(unameInput); //get Userdata out of the Database
            getTicketList();
            this.username = unameInput; //set the Username
        }

        private void getUserData(string uname)
        {
            List<string[]> userdata = LoginWindow.connection.getUserData(uname);

            userID = Convert.ToInt32(userdata[0][0]);
            fnameLabel.Text = userdata[0][1].ToString();
            hellolabel.Text = userdata[0][1].ToString();
            lnameLabel.Text = userdata[0][2].ToString();
            usernameLabel.Text = userdata[0][3].ToString();
            emailLabel.Text = userdata[0][4].ToString();
        }

        private void getTicketList()
        {
            List<Ticket> ticketList = LoginWindow.connection.getTickets();

            foreach (Ticket t in ticketList)
            {
                Button tbutton = new Button();
                tbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                switch (t.status)
                {
                    case "open":
                        tbutton.BackColor = Color.Red;
                        break;
                    case "in progress":
                        tbutton.BackColor = Color.Orange;
                        break;
                    case "done":
                        tbutton.BackColor = Color.Green;
                        break;
                    case "rejected":
                        tbutton.BackColor = Color.SkyBlue;
                        break;
                    default:
                        break;
                }
                tbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                tbutton.Location = new System.Drawing.Point(3, 3);
                tbutton.Name = t.id.ToString();
                tbutton.AutoSize = true;
                string title = t.title;
                tbutton.Text = t.title + "\r\n\r\n" + t.date + "\r\n" + t.time + "\r\n\r\nstatus: " + t.status + "\r\n"+ t.userfname + " " + t.userlname;
                tbutton.UseVisualStyleBackColor = true;
                tbutton.Click += new EventHandler(tbutton_Clicked);
                this.TicketsflowLayoutPanel.Controls.Add(tbutton);
            }
        }

        private void tbutton_Clicked(object sender, EventArgs e)
        {
            Button button = (Button)sender; //sender is the object, which is clicked
            int buttonid = Convert.ToInt32(button.Name);
            TicketAdminWindow taw = new TicketAdminWindow(buttonid, username);
            taw.ShowDialog();
            //renew the TicketList
            this.TicketsflowLayoutPanel.Controls.Clear();
            getTicketList();
        }

        private void newUserButton_Click(object sender, EventArgs e)
        {
            Windows.NewUserWindow nuw = new NewUserWindow();
            nuw.ShowDialog();
        }

        private void listUserButton_Click(object sender, EventArgs e)
        {
            ListUserWindow luw = new ListUserWindow();
            luw.ShowDialog();
            this.TicketsflowLayoutPanel.Controls.Clear();
            getTicketList();
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
