using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicketSystem.Windows
{
    public partial class TicketAdminWindow : Form
    {
        private int ticketID;

        public TicketAdminWindow(int ticketID, string username)
        {
            InitializeComponent();
            this.ticketID = ticketID;
            userTextBox.Text = "Welcome to TicketSystem "+username;
            fillBoxes();
            getPriorityList();
            getAreaList();
            getStatusList();
        }

        private void getPriorityList()
        {
            List<string> priorities = LoginWindow.connection.getPriortiy();
            foreach (string p in priorities) { priorityCB.Items.Add(p.ToString());}
        }

        private void getAreaList()
        {
            List<string> areas = LoginWindow.connection.getArea();
            foreach (string a in areas) { areaCB.Items.Add(a.ToString()); }
        }

        private void getStatusList()
        {
            List<string> statuse = LoginWindow.connection.getStatus();
            foreach (string s in statuse) { statusCB.Items.Add(s.ToString()); }
        }

        private void fillBoxes()
        {
            try
            {
                Ticket ticket = LoginWindow.connection.getTicketDeatils(ticketID);

                userTextBox.Text = ticket.username;
                titleTextBox.Text = ticket.title;
                descriptTextfield.Text = ticket.content;
                dateTextBox.Text = ticket.date + ticket.time;
                priorityCB.Text = ticket.priority;
                areaCB.Text = ticket.area;
                flnameTextBox.Text = ticket.userfname + " " +ticket.userlname;
                statusCB.Text = ticket.status;     
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong! Please contact your administrator! ERROR: " + ex);
            }
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            string newStatus = statusCB.Text;
            bool updateOK = LoginWindow.connection.updateTicket(ticketID, newStatus);
            if (updateOK == true) MessageBox.Show("Status was updated!");
            else MessageBox.Show("Status could not be updated!");
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void deleteTicketButton_Click(object sender, EventArgs e)
        {
            bool deleteOK = LoginWindow.connection.deleteTicket(ticketID);
            if (deleteOK == true)
            {
                MessageBox.Show("Ticket was removed!");
                this.Close();
            }
            else MessageBox.Show("Ticket could not be deleted!");
        }
    }
}
