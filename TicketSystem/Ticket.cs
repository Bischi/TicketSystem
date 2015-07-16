using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketSystem
{
    public class Ticket
    {
        public int id{ get; private set; }
        public string title{ get; private set; }
        public string content{ get; private set; }
        public string date{ get; private set; }
        public string time{ get; private set; }
        public string priority{ get; private set; }
        public string area{ get; private set; }
        public string status{ get; private set; }
        public string username { get; private set; }
        public string userfname { get; private set; } //to create Tickets for the admin Window
        public string userlname { get; private set; } //to create Tickets for the admin Window

        public Ticket(int id, string title, string content, string date, string time, string priority, string status, string area)
        {
            this.id = id;
            this.title = title;
            this.content = content;
            this.date = date;
            this.time = time;
            this.priority = priority;
            this.status = status;
            this.area = area;
        }

        public Ticket(int id, string title, string content, string date, string time, string priority, string status, string area, string username, string userfname, string userlname) //to create Tickets for the admin Window
        {
            this.id = id;
            this.title = title;
            this.content = content;
            this.date = date;
            this.time = time;
            this.priority = priority;
            this.status = status;
            this.area = area;
            this.username = username;
            this.userfname = userfname;
            this.userlname = userlname;
        }
    }
}
