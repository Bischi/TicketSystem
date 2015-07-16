using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketSystem.DBconnections
{
    public abstract class DBcommands
    {
        public abstract List<string[]> getUserData(string uname);
        public abstract List<string[]> getUsers();
        public abstract bool addUser(string fname, string lname, string username, string passwd, string email, string typ); 
        public abstract void deleteUser(int userID); 
        public abstract void updateUser(int userID); 

        public abstract bool addTicket(int userID, string title, string content, string date, string time, string priority, string area, string status);
        public abstract bool deleteTicket(int ticketID); 
        public abstract bool updateTicket(int ticketID, string newStatus);
        public abstract Ticket getTicketDeatils(int ticketID);
        public abstract List<Ticket> getTickets(int userid); //get user's tickets
        public abstract List<Ticket> getTickets(); //get all tickets (admin is using that) 

        public abstract bool checkLoginData(string uname, string passwd); //is the user allowed to log into the system?
        public abstract bool isAdmin(string uname); //check if the user is admin

        public abstract List<string> getPriortiy();
        public abstract List<string> getArea();
        public abstract List<string> getStatus();

        public abstract List<string> getTyp(); //to select the typ of a user by adding a new one
    }
}
