namespace TicketSystem
{
    partial class UserTicketsWindow
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
            this.label1 = new System.Windows.Forms.Label();
            this.ticketPanel = new System.Windows.Forms.Panel();
            this.TicketsflowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.ticketPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Sans Unicode", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(11, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Your Tickets";
            // 
            // ticketPanel
            // 
            this.ticketPanel.Controls.Add(this.TicketsflowLayoutPanel);
            this.ticketPanel.Location = new System.Drawing.Point(15, 49);
            this.ticketPanel.Name = "ticketPanel";
            this.ticketPanel.Size = new System.Drawing.Size(615, 289);
            this.ticketPanel.TabIndex = 5;
            // 
            // TicketsflowLayoutPanel
            // 
            this.TicketsflowLayoutPanel.AutoScroll = true;
            this.TicketsflowLayoutPanel.AutoSize = true;
            this.TicketsflowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TicketsflowLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.TicketsflowLayoutPanel.Name = "TicketsflowLayoutPanel";
            this.TicketsflowLayoutPanel.Size = new System.Drawing.Size(615, 289);
            this.TicketsflowLayoutPanel.TabIndex = 0;
            // 
            // UserTicketsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(642, 353);
            this.Controls.Add(this.ticketPanel);
            this.Controls.Add(this.label1);
            this.Name = "UserTicketsWindow";
            this.Text = "UserTicketsWindow";
            this.ticketPanel.ResumeLayout(false);
            this.ticketPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel ticketPanel;
        private System.Windows.Forms.FlowLayoutPanel TicketsflowLayoutPanel;
    }
}