using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicketSystem
{
    public partial class TicketWindow : Form
    {
        int userID;
        string username;

        public TicketWindow(int userID, string username)
        {
            InitializeComponent();
            dateTimePicker.CustomFormat = "MM:dd:yyy hh:mm";
            this.userID = userID;
            this.username = username;
            userTextBox.Text = username;
            getPriorityList();
            getAreaList();
        }

        private void getPriorityList()
        {
            List<string> priorities = LoginWindow.connection.getPriortiy();
            foreach (string p in priorities) { importanceCB.Items.Add(p.ToString()); }
        }

        private void getAreaList()
        {
            List<string> areas = LoginWindow.connection.getArea();
            foreach (string a in areas) { areaCB.Items.Add(a.ToString()); }
        }

        private void addTicketButton_Click(object sender, EventArgs e)
        {
            try
            {
                string title = titelTextBox.Text;
                string content = descriptTextfield.Text;
                string date = dateTimePicker.Value.Date.ToShortDateString();
                string time = dateTimePicker.Value.ToShortTimeString();
                string priority = importanceCB.Text;
                string area = areaCB.Text;
                string status = "open";
                bool addOK = LoginWindow.connection.addTicket(userID, title, content, date, time, priority, area, status);

                if (addOK != true) MessageBox.Show("Ticket could not be added!");
                else
                {
                    MessageBox.Show("Ticket was added");
                    this.Close();
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
