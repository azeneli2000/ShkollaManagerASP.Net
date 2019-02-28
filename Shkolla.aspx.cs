using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.IO;

namespace WebApplication2
{
    public partial class Shkolla : System.Web.UI.Page
    {
        public string conn_str = "Server = tcp:azeneli2000.database.windows.net,1433; Initial Catalog = shkolla_prova; Persist Security Info = False; User ID = andi; Password =Matrix2001; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;";
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

            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString(),true);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["statusi"].ToString()=="visitor")
            {
               
                Server.Transfer("~/sfondi.aspx");
               // msbox("Ky perdorues nuk ka akses ne kete modul !");
                return;
            }
            if (Session["shkolla"] == null)

            {
                Server.Transfer("~/login.aspx");
            }
            if (!Page.IsPostBack)
            {
                bind();
            }
            }

        void bind()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = conn_str;
            SqlCommand cmd = new SqlCommand();            
            cmd.CommandText = "SELECT * FROM TBL_SHKOLLAT WHERE SH_ID = " + Convert.ToInt64(Session["shkolla"]);
            cmd.Connection = conn;
            conn.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            TextBox1.Text = dt.Rows[0]["SH_EMRI"].ToString();
            TextBox2.Text = dt.Rows[0]["SH_VENDODHJA"].ToString();
            TextBox3.Text = dt.Rows[0]["SH_EMAIL"].ToString();
            TextBox4.Text = dt.Rows[0]["SH_TEL"].ToString();
            Image1.ImageUrl = "~/Handler1.ashx?Id=" + Session["shkolla"].ToString();
            conn.Close();
        }
        void update()
        {
            Stream fs = FileUpload1.PostedFile.InputStream;
            BinaryReader br = new BinaryReader(fs);
            Byte[] bytes = br.ReadBytes((Int32)fs.Length);
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = conn_str;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            SqlCommandBuilder b = new SqlCommandBuilder(da);
            cmd.CommandText = "select * from TBL_SHKOLLAT where SH_ID = " + Convert.ToInt64(Session["shkolla"].ToString());
           // cmd.CommandText = "UPDATE TBL_SHKOLLAT SET SH_EMRI = '"+ TextBox1.Text + "', SH_VENDODHJA = '" + TextBox2.Text + "',SH_EMAIL = '" + TextBox3.Text + "', SH_TEL = '"  + TextBox4.Text + "', LOGO = " + bytes +  " WHERE SH_ID = " + Convert.ToInt64(Session["shkolla"]);
            conn.Open();
            da.Fill(dt);
            if ( fs.Length>0)
            dt.Rows[0]["LOGO"] = bytes;
            dt.Rows[0]["SH_EMRI"] = TextBox1.Text;
            dt.Rows[0]["SH_VENDODHJA"] = TextBox2.Text;
            dt.Rows[0]["SH_EMAIL"]=TextBox3.Text;
            dt.Rows[0]["SH_TEL"] = TextBox4.Text;
            da.Update(dt);
            conn.Close();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            update();
            bind();
        }

        
    }
}