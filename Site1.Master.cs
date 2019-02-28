using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void msbox(string msg)
        {
            //string message = "Hello! Mudassar.";

            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            sb.Append("<script type = 'text/javascript'>");

            sb.Append("window.onload=function(){");

            sb.Append("alert('");

            sb.Append(msg);

            sb.Append("')};");

            sb.Append("</script>");

            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["shkolla"] != null)
            {
                Label1.Text ="SHKOLLA : "+ Session["emri"].ToString();
                
            }
            //else
            ////{
            ////    Response.Redirect("~/login.aspx");
            ////    return;
            //}
            }
    }
}