using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;

namespace ChatnDiscover
{
    public partial class Chat : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            //hidUsername.Value = "myfirsthiddenfield";
            string username = Page.User.Identity.Name;
           // txtNickName.Value = username;
            hidUsername.Value = username;
            //txtNickName.InnerText = username;
        }

        protected void GetUserDetails(object sender, EventArgs e)
        {
            UserLogin ul = new UserLogin();

            string username = Page.User.Identity.Name; 
            ul.GetUserbyUsername(username);
            //hidUsername.Value = username;
            //txtNickName.Value = username;
        }

        //protected void click_me(object sender, EventArgs e)
        //{
        //    HubInstanceMethods him=new HubInstanceMethods();
        //    him.addkingpin("admin");
        //}
    }
}