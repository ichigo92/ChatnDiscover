using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DataAccessLayer
{
    public class UserLogin
    {
        private int _userid;

        private string _name;

        private string _username;

        private string _password;

        private string _login_type;

        private string _email;

        public int UserID
        {
            get { return _userid; }
            set { _userid = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        public string LoginType
        {
            get { return _login_type; }
            set { _login_type = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public UserLogin()
        { }

        public UserLogin(int UserId)
        {
            GetUserbyId(UserId);
        }

        public UserLogin(string Username)
        {
            GetUserbyUsername(Username);
        }

        public UserLogin(string Username, string Password)
        {
            GetUserbyUsernameandPassword(Username, Password);
        }

        public void GetUserbyUsernameandPassword(string Username, string Password)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Mystery 92\documents\visual studio 2012\Projects\ChatnDiscover\ChatnDiscover\App_Data\CnDDB.mdf;Integrated Security=True");
            conn.Open();

            SqlCommand cmd = new SqlCommand("SELECT * from login WHERE username='" + Username + "' AND password='" + Password + "'", conn);

            IDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {

                _userid = Convert.ToInt32(reader["user_id"]);
                _username = Convert.ToString(reader["Username"]);
                _email = Convert.ToString(reader["email"]);

            }
        }

        public void GetUserbyId(int UserId)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Mystery 92\documents\visual studio 2012\Projects\ChatnDiscover\ChatnDiscover\App_Data\CnDDB.mdf;Integrated Security=True");
            conn.Open();

            SqlCommand cmd = new SqlCommand("SELECT * from login WHERE user_id='" + _userid + "'", conn);

            IDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {

                _userid = Convert.ToInt32(reader["user_id"]);
                _username = Convert.ToString(reader["username"]);

            }

        }

        public void GetUserbyUsername(string Username)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Mystery 92\documents\visual studio 2012\Projects\ChatnDiscover\ChatnDiscover\App_Data\CnDDB.mdf;Integrated Security=True");
            conn.Open();

            SqlCommand cmd = new SqlCommand("SELECT * from login WHERE username ='" + Username + "'", conn);

            IDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {

                _userid = Convert.ToInt32(reader["user_id"]);
                _username = Convert.ToString(reader["username"]);

            }

        }

        public void NewUser()
        {
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Mystery 92\documents\visual studio 2012\Projects\ChatnDiscover\ChatnDiscover\App_Data\CnDDB.mdf;Integrated Security=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO login(name,username,password,email,login_type) VALUES('" + _name + "','" + _username + "','" + _password + "','" + _email + "','" + _login_type + "')", conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void CheckUser()
        {
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Mystery 92\documents\visual studio 2012\Projects\ChatnDiscover\ChatnDiscover\App_Data\CnDDB.mdf;Integrated Security=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM login ", conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    _userid = Convert.ToInt32(dr["user_id"]);
                    _name = dr["name"].ToString();
                }
            }
            else
            {
                Console.Write("Database Empty");
            }
            dr.Close();
        }
    }
}
