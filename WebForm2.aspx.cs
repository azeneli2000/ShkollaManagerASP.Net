using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Abandon();
            Session.Clear();
            Session.RemoveAll();
            System.Web.Security.FormsAuthentication.SignOut();
            Server.Transfer("~/login.aspx", true);
        }
    }
}