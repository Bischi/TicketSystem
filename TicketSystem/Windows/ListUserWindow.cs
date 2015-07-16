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
           // string firstname = userListView.SelectedItems.ToString();

            //Console.WriteLine(firstname);


            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            foreach (object item in userListView.Items)
            {
                sb.Append(item.ToString());
                sb.Append(" ");
            }
            MessageBox.Show(sb.ToString());
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {

        }
    }
}
