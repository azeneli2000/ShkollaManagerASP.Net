using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Web.UI.HtmlControls;

namespace WebApplication2
{
    public partial class login : System.Web.UI.Page
    {
        public string conn_str = "Server = tcp:azeneli2000.database.windows.net,1433; Initial Catalog = shkolla_prova; Persist Security Info = False; User ID = andi; Password =Matrix2001; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;";

        // public string conn_str = "Data Source=.\\SQLEXPRESS;Initial Catalog=shkolla_prova;Integrated Security=True";  /*ConfigurationManager.ConnectionStrings["db_conn"].ConnectionString;*/


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

            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "hide()", true);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            HttpContext CurrContext = HttpContext.Current;
            

            string id_shkolla;string emri_shkolla;string statusi;
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = conn_str;
            conn.Open();
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT SH_ID,SH_EMRI,USERS_STATUSI  FROM TBL_SHKOLLAT,TBL_USERS WHERE SH_ID = USERS_ID_SHKOLLA AND USERS_EMRI_PERDORUESI = " + "'" + TextBox1.Text + "'" + " AND USERS_PASSWORD = " + "'" + TextBox2.Text + "'";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                id_shkolla = ds.Tables[0].Rows[0]["SH_ID"].ToString();
                emri_shkolla = ds.Tables[0].Rows[0]["SH_EMRI"].ToString();
                statusi = ds.Tables[0].Rows[0]["USERS_STATUSI"].ToString();
                conn.Close();
               
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction1", "show()", true);
               
              
                CurrContext.Items.Add("shkolla",id_shkolla);
                CurrContext.Items.Add("emri", emri_shkolla);
                CurrContext.Items.Add("statusi", statusi);
                Session["shkolla"] = id_shkolla;
                Session["emri"] = emri_shkolla;
                Session["statusi"] = statusi;
                Server.Transfer("~/sfondi.aspx", true);
            }
            else
            {
                msbox("Perdorues ose fjalekalim i gabuar !");
                TextBox1.Text = "";
                TextBox2.Text = "";
            }
            
        }
    }
}