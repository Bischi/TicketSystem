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
    public partial class TicketDetailWindow : Form
    {

        private int ticketID;

        public TicketDetailWindow(int ticketID, string username)
        {
            InitializeComponent();
            this.ticketID = ticketID;
            userTextBox.Text = username;
            fillBoxes();

        }

        private void fillBoxes()
        {
            try
            {
                Ticket ticket = LoginWindow.connection.getTicketDeatils(ticketID);

                titelTextBox.Text = ticket.title;
                descriptTextfield.Text = ticket.content;
                dateTextBox.Text = ticket.date + ticket.time;
                importanceCB.Text = ticket.priority;
                areaCB.Text = ticket.area;

                switch (ticket.status)
                {
                    case "open":
                        statusLabel.Text = ticket.status;
                        statusLabel.ForeColor = Color.Red;
                        break;
                    case "in progress":
                        statusLabel.Text = ticket.status;
                        statusLabel.ForeColor = Color.Orange;
                        break;
                    case "done":
                        statusLabel.Text = ticket.status;
                        statusLabel.ForeColor = Color.Green;
                        break;
                    case "rejected":
                        statusLabel.Text = ticket.status;
                        statusLabel.ForeColor = Color.Red;
                        break;
                    default:
                        statusLabel.Text = ticket.status;
                        statusLabel.ForeColor = Color.Black;
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong! Please contact your administrator! ERROR: "+ex);
            }
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

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
