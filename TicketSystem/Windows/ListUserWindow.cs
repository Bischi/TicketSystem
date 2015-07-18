using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace TicketSystem.Windows
{
    public partial class ListUserWindow : Form
    {
        public ListUserWindow()
        {
            InitializeComponent();
            fillListView();
        }

        private void fillListView()
        {
            List<string[]> Userlist = LoginWindow.connection.getUsers();

            var items = userListView.Items;

            foreach (string[] user in Userlist)
            {
                ListViewItem item = new ListViewItem(new[] { user[1], user[2], user[3], user[4], user[5]});
                userListView.Items.Add(item);
                userListView.View = View.Details;

            }
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            string firstname = userListView.SelectedItems[0].SubItems[0].Text;
            string lastname = userListView.SelectedItems[0].SubItems[1].Text;
            string username = userListView.SelectedItems[0].SubItems[2].Text;
            string email = userListView.SelectedItems[0].SubItems[3].Text;
            string typ = userListView.SelectedItems[0].SubItems[4].Text;

            NewUserWindow nuw = new NewUserWindow(firstname, lastname, username, email, typ);
            nuw.ShowDialog();

            userListView.Items.Clear();
            fillListView();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("By deleting the user his tickets will be deleted too! Do you want to remove the user?", "SURE?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    string firstname = userListView.SelectedItems[0].SubItems[0].Text;
                    string lastname = userListView.SelectedItems[0].SubItems[1].Text;
                    string username = userListView.SelectedItems[0].SubItems[2].Text;
                    string email = userListView.SelectedItems[0].SubItems[3].Text;
                    string typ = userListView.SelectedItems[0].SubItems[4].Text;

                    List<string[]> userdata = LoginWindow.connection.getUserData(username);
                    int userID = Convert.ToInt32(userdata[0][0]);

                    bool deleteOK = LoginWindow.connection.deleteUser(userID);

                    if (deleteOK == true) MessageBox.Show("User was deleted successfully!");
                    else MessageBox.Show("User couldn't be deleted!");

                    userListView.Items.Clear();
                    fillListView();
                }
                catch
                {
                    MessageBox.Show("User couldn't be deleted!");
                }
            }
        }
    }
}
