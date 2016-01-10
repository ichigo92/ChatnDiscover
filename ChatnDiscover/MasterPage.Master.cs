using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;
using System.Text;
using System.Web.Security;

namespace ChatnDiscover
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void InsertUser(object sender, EventArgs e)
        {
            UserLogin ul = new UserLogin();
            string name = txtSignName.Text;
            string email = txtSignEmail.Text;
            string username = txtSignUsername.Text;
            string password = txtSignPassword.Text;
            string login_type = "User";
            ul.Name = name;
            ul.Email = email;
            ul.Username = username;
            ul.Password = password;
            ul.LoginType = login_type;
            ul.NewUser();
        }

        protected void LoginValidation(object sender, EventArgs e)
        {
            UserLogin ul = new UserLogin(txtUsername.Text, txtPassword.Text);

            if (ul.UserID > 0)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(ul.Username);

                HttpCookie ck;

                FormsAuthenticationTicket tkt = new FormsAuthenticationTicket(1, sb.ToString(), DateTime.Now, DateTime.Now.AddDays(5), true, "");

                ck = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(tkt));
                ck.Path = FormsAuthentication.FormsCookiePath;
                ck.Domain = FormsAuthentication.CookieDomain;

                Response.Cookies.Add(ck);

                Response.Redirect("Default.aspx?msg=You are Logged in!!");


            }

            else
                Response.Redirect("Default.aspx?msg=Invalid username and password!");


            /* ul.CheckUser();
             string username = txtUsername.Text;
             string password = txtPassword.Text;
             string name = ul.Name;
             int id = ul.UserID;
             Session["id"] = id;
             Session["name"] = name;
             string username_db = ul.Username;
             string password_db = ul.Password;
             if (username == username_db && password == password_db)
             {
                 Response.Redirect("Default.aspx?msg=You are logged in!");
             }
             //Response.Redirect("Default.aspx?msg=" + id + " " + name);*/
        }
    }
}