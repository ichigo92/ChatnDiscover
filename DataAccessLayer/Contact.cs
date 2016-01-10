using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class Contact
    {
        public int ID;
        public string firstname;
        public string lastname;
        public string email;
        public string message;
        public string subject;

        public Contact()
        {
        }

        public string s_firstname
        {
            get { return firstname; }
            set { firstname = value; }
        }

        public string s_lastname
        {

            get { return lastname; }
            set { lastname = value; }
        }


        public string s_email
        {

            get { return email; }
            set { email = value; }
        }

        public string s_subject
        {
            get { return subject; }
            set { subject = value; }
        }

        public string s_message
        {
            get { return message; }
            set { message = value; }
        }

        public void insertviadatareader()
        {
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Mystery 92\documents\visual studio 2012\Projects\ChatnDiscover\ChatnDiscover\App_Data\CnDDB.mdf;Integrated Security=True");
            conn.Open();
            //conn.CommandType = CommandType.StoredProcedure;
            SqlCommand sq = new SqlCommand("Insert INTO UserContact (FirstName,LastName,Email,Subject,Message) Values ('" + firstname + "','" + lastname + "','" + email + "','" + subject + "','" + message + "')", conn);
            sq.ExecuteNonQuery();
            //SqlDataReader reader = conn.ExecuteReader();
            conn.Close();
        }
    }
}
