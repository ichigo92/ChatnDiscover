using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;
namespace ChatnDiscover
{
    public partial class ContactUs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void sumit_Click(object sender, EventArgs e)
        {
            Contact cb = new Contact();
            cb.s_firstname = txtfirstname.Text;
            cb.lastname = txtlastname.Text;
            cb.email = txtemail.Text;
            cb.subject = txtsubject.Text;
            cb.message = txtmessage.Text;
            cb.insertviadatareader();
        }
    }
}