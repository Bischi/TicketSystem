namespace TicketSystem.Windows
{
    partial class ListUserWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.hellolabel = new System.Windows.Forms.Label();
            this.userListView = new System.Windows.Forms.ListView();
            this.fnameHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lnameHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.usernameHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.emailHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.typHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.editButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // hellolabel
            // 
            this.hellolabel.AutoSize = true;
            this.hellolabel.Font = new System.Drawing.Font("Lucida Sans Unicode", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hellolabel.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.hellolabel.Location = new System.Drawing.Point(11, 9);
            this.hellolabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.hellolabel.Name = "hellolabel";
            this.hellolabel.Size = new System.Drawing.Size(127, 20);
            this.hellolabel.TabIndex = 9;
            this.hellolabel.Text = "Registed Users";
            // 
            // userListView
            // 
            this.userListView.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.userListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.fnameHeader,
            this.lnameHeader,
            this.usernameHeader,
            this.emailHeader,
            this.typHeader,
            this.columnHeader1,
            this.columnHeader2});
            this.userListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.userListView.Location = new System.Drawing.Point(12, 49);
            this.userListView.MultiSelect = false;
            this.userListView.Name = "userListView";
            this.userListView.Size = new System.Drawing.Size(688, 237);
            this.userListView.TabIndex = 1;
            this.userListView.UseCompatibleStateImageBehavior = false;
            // 
            // fnameHeader
            // 
            this.fnameHeader.Text = "Firstname";
            this.fnameHeader.Width = 100;
            // 
            // lnameHeader
            // 
            this.lnameHeader.Text = "Lastname";
            this.lnameHeader.Width = 100;
            // 
            // usernameHeader
            // 
            this.usernameHeader.Text = "Username";
            this.usernameHeader.Width = 100;
            // 
            // emailHeader
            // 
            this.emailHeader.Text = "Email";
            this.emailHeader.Width = 100;
            // 
            // typHeader
            // 
            this.typHeader.Text = "Typ";
            this.typHeader.Width = 100;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "";
            // 
            // editButton
            // 
            this.editButton.Location = new System.Drawing.Point(12, 291);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(123, 24);
            this.editButton.TabIndex = 10;
            this.editButton.Text = "Edit";
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(141, 291);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(123, 24);
            this.deleteButton.TabIndex = 11;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // ListUserWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 327);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.editButton);
            this.Controls.Add(this.userListView);
            this.Controls.Add(this.hellolabel);
            this.MinimumSize = new System.Drawing.Size(728, 366);
            this.Name = "ListUserWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Usermanagement";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label hellolabel;
        private System.Windows.Forms.ListView userListView;
        private System.Windows.Forms.ColumnHeader fnameHeader;
        private System.Windows.Forms.ColumnHeader lnameHeader;
        private System.Windows.Forms.ColumnHeader usernameHeader;
        private System.Windows.Forms.ColumnHeader emailHeader;
        private System.Windows.Forms.ColumnHeader typHeader;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.Button deleteButton;
    }
}