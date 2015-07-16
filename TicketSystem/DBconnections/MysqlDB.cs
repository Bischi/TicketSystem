using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketSystem.DBconnections
{
    class MysqlDB : DBcommands
    {
        private string server;
        private string database;
        private string dbuser;
        private string dbpasswd; 

        private MySqlConnection sql_conn;
        private MySqlCommand sql_cmd;
        private MySqlDataReader datareader;

        public MysqlDB()
        {
            connect();
        }

        private bool connect()
        {
            this.server = "localhost";
            this.database = "tsystem";
            this.dbuser = "root";
            this.dbpasswd = "";

            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + dbuser + ";" + "PASSWORD=" + dbpasswd + ";";

            sql_conn = new MySqlConnection(connectionString);

            try
            {
                sql_conn.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
            return true;
        }

        #region Login 
        public override bool checkLoginData(string uname, string passwd)
        {
            sql_cmd = new MySqlCommand(null, sql_conn);
            sql_cmd.CommandText = "SELECT COUNT(*) from tbl_user where username='"+uname+"' and password='"+passwd+"'";
            /*MySqlParameter unameParam = new MySqlParameter("@username", MySqlDbType.Text, 45);
            MySqlParameter passwordParam = new MySqlParameter("@password", MySqlDbType.String, 255);

            unameParam.Value = uname;
            passwordParam.Value = passwd;

            sql_cmd.Parameters.Add(unameParam);
            sql_cmd.Parameters.Add(passwordParam);
            sql_cmd.Prepare();
            */
            try
            {
                if (sql_conn.State != System.Data.ConnectionState.Open) sql_conn.Open();
                int count = Convert.ToInt16(sql_cmd.ExecuteScalar());
                sql_conn.Close();
                if (count >=1) return true; //ein benutzer vorhanden
                else return false;
                
            }
            catch(Exception ex)
            {
                sql_conn.Close();
                Console.WriteLine("ERROR:" +ex);
                return false;
            }
        }

        public override bool isAdmin(string uname)
        {
            sql_cmd = new MySqlCommand(null, sql_conn);
            sql_cmd.CommandText = "SELECT tbl_typ_id from tbl_user where username = '"+uname+"'";
            try
            {
                if (sql_conn.State != System.Data.ConnectionState.Open) sql_conn.Open();
                int typID = Convert.ToInt16(sql_cmd.ExecuteScalar());
                sql_conn.Close();
                if (typID == 1) return true; //ein benutzer vorhanden
                else return false;
            }
            catch (Exception ex)
            {
                sql_conn.Close();
                Console.WriteLine("ERROR:" + ex);
                return false;
            }
        }

        #endregion

        #region Usermanagement

        public override List<string[]> getUserData(string uname)
        {
            sql_cmd = new MySqlCommand(null, sql_conn);
            sql_cmd.CommandText = "SELECT id, fname, lname, username, email from tbl_user where username='" + uname + "'";
            if (sql_conn.State != System.Data.ConnectionState.Open) sql_conn.Open();

            List<string[]> userdataList = new List<string[]>();

            try
            {
                datareader = sql_cmd.ExecuteReader();
                
                string[] userdata = new string[5];

                while(datareader.Read())
                {
                    userdata[0] = datareader.GetInt16(0).ToString();
                    userdata[1] = datareader.GetString(1);
                    userdata[2] = datareader.GetString(2);
                    userdata[3] = datareader.GetString(3);
                    userdata[4] = datareader.GetString(4);
                    userdataList.Add(userdata);
                }
                sql_conn.Close();
                return userdataList;
            }
            catch (MySqlException ex)
            {
                sql_conn.Close();
                Console.WriteLine("ERROR:" + ex);
                return userdataList;
            }
        }

        public override List<string[]> getUsers()
        {

            sql_cmd = new MySqlCommand(null, sql_conn);
            sql_cmd.CommandText = "SELECT u.id, u.fname, u.lname, u.username, u.email, t.description FROM tsystem.tbl_user u inner join tbl_typ t on u.tbl_typ_id = t.id";
            
            List<string[]> userdataList = new List<string[]>();

            try
            {
                if (sql_conn.State != System.Data.ConnectionState.Open) sql_conn.Open();
                datareader = sql_cmd.ExecuteReader();

                while (datareader.Read())
                {
                    string[] userdata = new string[6];
                    userdata[0] = datareader.GetInt32(0).ToString();
                    userdata[1] = datareader.GetString(1);
                    userdata[2] = datareader.GetString(2);
                    userdata[3] = datareader.GetString(3);
                    userdata[4] = datareader.GetString(4);
                    userdata[5] = datareader.GetString(5);
                    userdataList.Add(userdata);
                }
                sql_conn.Close();
                return userdataList;
            }
            catch (MySqlException ex)
            {
                sql_conn.Close();
                Console.WriteLine("ERROR:" + ex);
                return userdataList;
            }
        }

        public override bool addUser(string fname, string lname, string username, string passwd, string email, string typ)
        {
            try
            {
                sql_cmd.CommandText = "Select id from tbl_typ Where description ='" + typ + "'";
                if (sql_conn.State != System.Data.ConnectionState.Open) sql_conn.Open();
                int typID = (Int32)sql_cmd.ExecuteScalar();

                sql_cmd.CommandText = "INSERT INTO `tsystem`.`tbl_user`(`fname`,`lname`,`username`,`password`,`email`,`tbl_typ_id`)VALUES('" + fname + "','" + lname + "','" + username + "','" + passwd + "','" + email + "','" + typID + "')";
                if (sql_conn.State != System.Data.ConnectionState.Open) sql_conn.Open();
                sql_cmd.ExecuteNonQuery();

                sql_conn.Close();
                return true;
            }
            catch(Exception ex)
            {
                sql_conn.Close();
                return false;
            }
        }

        public override bool updateUser(int userID, string fname, string lname, string username, string passwd, string email, string typ)
        {
            try
            {
                sql_cmd.CommandText = "Select id from tbl_typ where description ='" + typ + "'";
                if (sql_conn.State != System.Data.ConnectionState.Open) sql_conn.Open();
                int typID = Convert.ToInt32(sql_cmd.ExecuteScalar());

                sql_cmd.CommandText = "UPDATE `tsystem`.`tbl_user` SET `fname` = '"+fname+"',`lname` = '"+lname+"' ,`username` = '"+username+"',`password` = '"+passwd+"',`email` = '"+email+"',`tbl_typ_id` = "+typID+" WHERE `id` = "+userID;
                sql_cmd.ExecuteNonQuery();
                sql_conn.Close();
                //writeLine into ex
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public override bool deleteUser(int userID)
        {
            try
            {
                sql_cmd.CommandText = "DELETE FROM `tsystem`.`tbl_ticket_has_tbl_user`WHERE tbl_user_id =" + userID + "";
                if (sql_conn.State != System.Data.ConnectionState.Open) sql_conn.Open();
                sql_cmd.ExecuteNonQuery();
                sql_cmd.CommandText = "DELETE FROM `tsystem`.`tbl_user`WHERE id =" + userID + "";
                sql_cmd.ExecuteNonQuery();
                sql_conn.Close();
                //writeLine into ex
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion

        #region Ticketmanagement

        public override List<Ticket> getTickets(int userid)
        {
            sql_cmd = new MySqlCommand(null, sql_conn);
            sql_cmd.CommandText = "SELECT t.id, t.title, t.content, t.date, t. time, p.description, s.description, a.description FROM tsystem.tbl_ticket t Inner join tbl_priority p on t.tbl_priority_id = p.id Inner join tbl_status s on t.tbl_status_id = s.id inner join tbl_area a on t.tbl_area_id = a.id Inner join tbl_ticket_has_tbl_user tu on t.id = tu.tbl_ticket_id inner join tbl_user u on tu.tbl_user_id = u.id WHERE u.id ="+ userid;
            if (sql_conn.State != System.Data.ConnectionState.Open) sql_conn.Open();

            List<Ticket> ticketList = new List<Ticket>();

            try
            {
                datareader = sql_cmd.ExecuteReader();

                Ticket ticket;
                int id; 
                string title;
                string content; 
                string date;
                string time;
                string priority;
                string area;
                string status;

                while (datareader.Read())
                {
                    id = datareader.GetInt16(0);
                    title = datareader.GetString(1);
                    content = datareader.GetString(2);
                    date = datareader.GetString(3);
                    time = datareader.GetString(4);
                    priority = datareader.GetString(5);
                    status = datareader.GetString(6);
                    area = datareader.GetString(7); 

                    ticket = new Ticket(id, title, content, date, time, priority, status, area);
                    ticketList.Add(ticket);
                }
                sql_conn.Close();
                return ticketList;
            }
            catch (MySqlException ex)
            {
                sql_conn.Close();
                Console.WriteLine("ERROR:" + ex);
                return ticketList;
            }
        }

        public override List<Ticket> getTickets()
        {
            sql_cmd = new MySqlCommand(null, sql_conn);
            sql_cmd.CommandText = "SELECT t.id, t.title, t.content, t.date, t. time, p.description, s.description, a.description, u.username, u.fname, u.lname FROM tsystem.tbl_ticket t Inner join tbl_priority p on t.tbl_priority_id = p.id Inner join tbl_status s on t.tbl_status_id = s.id inner join tbl_area a on t.tbl_area_id = a.id Inner join tbl_ticket_has_tbl_user tu on t.id = tu.tbl_ticket_id inner join tbl_user u on tu.tbl_user_id = u.id";
         
            List<Ticket> ticketList = new List<Ticket>();

            try
            {
                if (sql_conn.State != System.Data.ConnectionState.Open) sql_conn.Open();
                datareader = sql_cmd.ExecuteReader();

                Ticket ticket;
                int id;
                string title;
                string content;
                string date;
                string time;
                string priority;
                string area;
                string status;
                string username;
                string userfname;
                string userlname;

                while (datareader.Read())
                {
                    id = datareader.GetInt16(0);
                    title = datareader.GetString(1);
                    content = datareader.GetString(2);
                    date = datareader.GetString(3);
                    time = datareader.GetString(4);
                    priority = datareader.GetString(5);
                    status = datareader.GetString(6);
                    area = datareader.GetString(7);
                    username = datareader.GetString(8);
                    userfname = datareader.GetString(9);
                    userlname = datareader.GetString(10);
                    ticket = new Ticket(id, title, content, date, time, priority, status, area, username, userfname, userlname);
                    ticketList.Add(ticket);
                }
                sql_conn.Close();
                return ticketList;
            }
            catch (MySqlException ex)
            {
                sql_conn.Close();
                Console.WriteLine("ERROR:" + ex);
                return ticketList;
            }
        }

        public override Ticket getTicketDeatils(int ticketID)
        {
            sql_cmd = new MySqlCommand(null, sql_conn);
            sql_cmd.CommandText = "SELECT t.id, t.title, t.content, t.date, t. time, p.description, s.description, a.description, u.username, u.fname, u.lname FROM tsystem.tbl_ticket t Inner join tbl_priority p on t.tbl_priority_id = p.id Inner join tbl_status s on t.tbl_status_id = s.id inner join tbl_area a on t.tbl_area_id = a.id Inner join tbl_ticket_has_tbl_user tu on t.id = tu.tbl_ticket_id inner join tbl_user u on tu.tbl_user_id = u.id Where t.id =" + ticketID;

            Ticket t = new Ticket(0, "", "", "", "", "", "", "");

            try
            {
                if (sql_conn.State != System.Data.ConnectionState.Open) sql_conn.Open();
                int id;
                string title;
                string content;
                string date;
                string time;
                string priority;
                string area;
                string status;
                string username;
                string userfname;
                string userlname;

                datareader = sql_cmd.ExecuteReader();

                while (datareader.Read())
                {
                    id = datareader.GetInt16(0);
                    title = datareader.GetString(1);
                    content = datareader.GetString(2);
                    date = datareader.GetString(3);
                    time = datareader.GetString(4);
                    priority = datareader.GetString(5);
                    status = datareader.GetString(6);
                    area = datareader.GetString(7);
                    username = datareader.GetString(8);
                    userfname = datareader.GetString(9);
                    userlname = datareader.GetString(10);

                    t = new Ticket(id, title, content, date, time, priority, status, area, username, userfname, userlname);
                }
                sql_conn.Close();
                return t;
            }
            catch (MySqlException ex)
            {
                sql_conn.Close();
                Console.WriteLine("ERROR:" + ex);
                return t;
            }
        }

        public override bool addTicket(int userID, string title, string content, string date, string time, string priority, string area, string status)
        {
            int ticketID = 0;
            try
            {
                sql_cmd = new MySqlCommand(null, sql_conn);
                sql_cmd.CommandText = "Select id from tbl_priority Where description ='" + priority + "'";
                if (sql_conn.State != System.Data.ConnectionState.Open) sql_conn.Open();
                int priorityID = (Int32)sql_cmd.ExecuteScalar();

                sql_cmd.CommandText = "Select id from tbl_area Where description ='" + area + "'";
                if (sql_conn.State != System.Data.ConnectionState.Open) sql_conn.Open();
                int areaID = (Int32)sql_cmd.ExecuteScalar();

                sql_cmd.CommandText = "Select id from tbl_status Where description ='" + status + "'";
                if (sql_conn.State != System.Data.ConnectionState.Open) sql_conn.Open();
                int statusID = (Int32)sql_cmd.ExecuteScalar();
                
                sql_conn.Close();

                sql_cmd.CommandText = "INSERT INTO tbl_ticket (title, content, date, time, tbl_priority_id, tbl_status_id, tbl_area_id) VALUES ('" + title + "', '" + content + "', '" + date + "','" + time + "', " + priorityID + ", " + statusID + "," + areaID + ")";
                if (sql_conn.State != System.Data.ConnectionState.Open) sql_conn.Open();
                sql_cmd.ExecuteNonQuery();

                sql_conn.Close();

                sql_cmd.CommandText = "Select id from tbl_ticket Where title ='" + title + "'";
                if (sql_conn.State != System.Data.ConnectionState.Open) sql_conn.Open();
                ticketID = (Int32)sql_cmd.ExecuteScalar();

                sql_conn.Close();

                sql_cmd.CommandText = "INSERT INTO `tsystem`.`tbl_ticket_has_tbl_user`(`tbl_ticket_id`,`tbl_user_id`)VALUES("+ticketID+","+userID+")";
                if (sql_conn.State != System.Data.ConnectionState.Open) sql_conn.Open();
                sql_cmd.ExecuteNonQuery();
                sql_conn.Close();

                return true;
            }
            catch (MySqlException ex)
            {
                sql_cmd.CommandText = "DELETE FROM `tsystem`.`tbl_ticket`WHERE id =" + ticketID + "";
                if (sql_conn.State != System.Data.ConnectionState.Open) sql_conn.Open();
                sql_cmd.ExecuteNonQuery();
                sql_conn.Close();
                //writeLine into ex
                return false;
            }
        }

        public override bool updateTicket(int ticketID, string newStatus)
        {
            try
            {
                sql_cmd.CommandText = "Select id from tbl_status where description ='" + newStatus + "'";
                if (sql_conn.State != System.Data.ConnectionState.Open) sql_conn.Open();
                int statusID = Convert.ToInt32(sql_cmd.ExecuteScalar());
                sql_cmd.CommandText = "UPDATE `tsystem`.`tbl_ticket` SET tbl_status_id = "+statusID+" WHERE id =" + ticketID + "";
                sql_cmd.ExecuteNonQuery();
                sql_conn.Close();
                //writeLine into ex
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public override bool deleteTicket(int ticketID)
        {
            try
            {
                sql_cmd.CommandText = "DELETE FROM `tsystem`.`tbl_ticket_has_tbl_user`WHERE tbl_ticket_id =" + ticketID + "";
                if (sql_conn.State != System.Data.ConnectionState.Open) sql_conn.Open();
                sql_cmd.ExecuteNonQuery();
                sql_cmd.CommandText = "DELETE FROM `tsystem`.`tbl_ticket`WHERE id =" + ticketID + "";
                sql_cmd.ExecuteNonQuery();
                sql_conn.Close();
                //writeLine into ex
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion

        #region readItems
        public override List<string> getPriortiy()
        {
            sql_cmd = new MySqlCommand(null, sql_conn);
            sql_cmd.CommandText = "SELECT description from tbl_priority";
            if (sql_conn.State != System.Data.ConnectionState.Open) sql_conn.Open();

            List<string> priorityList = new List<string>();

            try
            {
                datareader = sql_cmd.ExecuteReader();
                string priority = "";

                while (datareader.Read())
                {
                    priority = datareader.GetString(0);
                    priorityList.Add(priority);
                }
                sql_conn.Close();
                return priorityList;
            }
            catch (MySqlException ex)
            {
                sql_conn.Close();
                Console.WriteLine("ERROR:" + ex);
                return priorityList;
            }
        }

        public override List<string> getArea()
        {
            sql_cmd = new MySqlCommand(null, sql_conn);
            sql_cmd.CommandText = "SELECT description from tbl_area";
            if (sql_conn.State != System.Data.ConnectionState.Open) sql_conn.Open();

            List<string> areaList = new List<string>();

            try
            {
                datareader = sql_cmd.ExecuteReader();
                string areadata = "";

                while (datareader.Read())
                {
                    areadata = datareader.GetString(0);
                    areaList.Add(areadata);
                }
                sql_conn.Close();
                return areaList;
            }
            catch (MySqlException ex)
            {
                sql_conn.Close();
                Console.WriteLine("ERROR:" + ex);
                return areaList;
            }
        }

        public override List<string> getStatus()
        {
            sql_cmd = new MySqlCommand(null, sql_conn);
            sql_cmd.CommandText = "SELECT description from tbl_status";

            List<string> areaList = new List<string>();

            try
            {
                if (sql_conn.State != System.Data.ConnectionState.Open) sql_conn.Open();
                datareader = sql_cmd.ExecuteReader();
                string areadata = "";

                while (datareader.Read())
                {
                    areadata = datareader.GetString(0);
                    areaList.Add(areadata);
                }
                sql_conn.Close();
                return areaList;
            }
            catch (MySqlException ex)
            {
                sql_conn.Close();
                Console.WriteLine("ERROR:" + ex);
                return areaList;
            }
        }

        public override List<string> getTyp()
        {
            sql_cmd = new MySqlCommand(null, sql_conn);
            sql_cmd.CommandText = "SELECT description from tbl_typ";

            List<string> typList = new List<string>();

            try
            {
                if (sql_conn.State != System.Data.ConnectionState.Open) sql_conn.Open();
                datareader = sql_cmd.ExecuteReader();

                while (datareader.Read())
                {
                    typList.Add(datareader.GetString(0));
                }
                sql_conn.Close();
                return typList;
            }
            catch (MySqlException ex)
            {
                sql_conn.Close();
                Console.WriteLine("ERROR:" + ex);
                return typList;
            }
        }
        #endregion

    }
}
