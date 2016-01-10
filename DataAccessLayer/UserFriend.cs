using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DataAccessLayer
{
    public class UserFriend
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

        public UserFriend()
        { }

        public int GetUserbyUsername(string Username)
        {
            int _id=0;

            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Mystery 92\documents\visual studio 2012\Projects\ChatnDiscover\ChatnDiscover\App_Data\CnDDB.mdf;Integrated Security=True");
            conn.Open();

            SqlCommand cmd = new SqlCommand("SELECT * from login WHERE username ='" + Username + "'", conn);

            IDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {

                _id = Convert.ToInt32(reader["user_id"]);
                _username = Convert.ToString(reader["username"]);
            }

            return _id;

        }

        public bool checkStatus(string username_one, string username_two)
        {
            int status=0;
            int friend_one=GetUserbyUsername(username_one);
            int friend_two=GetUserbyUsername(username_two);
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Mystery 92\documents\visual studio 2012\Projects\ChatnDiscover\ChatnDiscover\App_Data\CnDDB.mdf;Integrated Security=True");
            conn.Open();

            SqlCommand cmd = new SqlCommand("SELECT friend_one,friend_two,status from friends WHERE (friend_one ='" + friend_one + "'OR friend_two = '" + friend_one + "') AND (friend_one ='" + friend_two + "'OR friend_two ='" + friend_two + "')", conn);

            IDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {

                status = Convert.ToInt32(reader["status"]);
            }
            if (status == 1)
            {
                return true;
            }
            return false;
        }


    }
}
