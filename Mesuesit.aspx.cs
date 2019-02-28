using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.IO;

namespace WebApplication2
{
    
    public partial class Mesuesit : System.Web.UI.Page
    {

        public string conn_str = "Server = tcp:azeneli2000.database.windows.net,1433; Initial Catalog = shkolla_prova; Persist Security Info = False; User ID = andi; Password =Matrix2001; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;";
        // public string conn_str = "Data Source=.\\SQLEXPRESS;Initial Catalog=shkolla_prova;Integrated Security=True";
        public string gjej_vitin()
        {
            if (DateTime.Now.Month >= 7)
                return (DateTime.Now.Year).ToString() + "-" + (DateTime.Now.Year + 1).ToString();
            else
                return
                 (DateTime.Now.Year - 1).ToString() + "-" + (DateTime.Now.Year).ToString();
        }

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
        void bind(long idshkolla)
        {
            SqlConnection conn = new SqlConnection();
            DataSet ds1 = new DataSet();
            int i = 0;
            conn.ConnectionString = conn_str;
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM TBL_MESUESI WHERE MS_ID_SHKOLLA = " + idshkolla + " ORDER BY MS_EMRI, MS_MBIEMRI");
            SqlCommand cmd1 = new SqlCommand("INSERT INTO TBL_MESUESI (MS_ID_SHKOLLA, MS_EMRI, MS_MBIEMRI, MS_USERNAME1, MS_PASSWORD1, MS_GJENDJA) VALUES(" + idshkolla + ", '" + 0 + "', " + "'" + 0 + "'" + ", '" + 0 + "', '"  + 0 + "', '" + 0 + "')");
            SqlCommand cmd2 = new SqlCommand("DELETE FROM TBL_MESUESI WHERE MS_GJENDJA =" + 0);
            cmd.Connection = conn;
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds,"TBL_MESUESI");
            if (ds.Tables[0].Rows.Count == 0)
            {
                //insert record bosh me nr amze 0
                cmd1.Connection = conn;
                cmd2.Connection = conn;
                cmd1.ExecuteNonQuery();
                da.Fill(ds,"TBL_MESUESI");
                GridView1.DataSource = ds;
                GridView1.DataBind();
                GridView1.Rows[0].Visible = false;
                //delete recordit qe u fut
                cmd2.ExecuteNonQuery();
            }
            else
            {
                GridView1.DataSource = ds;
                GridView1.DataBind();
            }
         
            conn.Close();

        }

        protected void Page_Load(object sender, EventArgs e)
        {
          
         
            if (Session["shkolla"] == null)

            {
                Server.Transfer("~/login.aspx");
            }

            if (Session["statusi"].ToString() == "visitor")
            {

                Server.Transfer("~/sfondi.aspx");
                // msbox("Ky perdorues nuk ka akses ne kete modul !");
                return;
            }
            Image1.ImageUrl = "~/Handler1.ashx?Id=" + Session["shkolla"].ToString();
            if (!Page.IsPostBack)
            {
                
                bind(Convert.ToInt64(Session["shkolla"].ToString()));
            }
            }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            e.Cancel = true;
            GridView1.EditIndex = -1;
            bind(Convert.ToInt64(Session["shkolla"].ToString()));
        }
        bool gjej_perdoruesin(string username)
        {
            int i = 0;
            SqlConnection conn = new SqlConnection(conn_str);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT MS_USERNAME1 FROM TBL_MESUESI WHERE UPPER(MS_USERNAME1) = " + "'" + username.Trim().ToUpper() + "'";
            conn.Open();
            SqlDataReader r = cmd.ExecuteReader();
          
            while (r.Read())
            {
                i++;
            }
            conn.Close();
            if (i > 0) return true;
            else return false;
           
        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Insert")
            {

                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = conn_str;
                SqlCommand cmd = new SqlCommand();
                SqlCommand cmd1 = new SqlCommand();
                SqlCommand cmd2 = new SqlCommand();                
                string emri = (((TextBox)GridView1.FooterRow.FindControl("insertemri")).Text).ToString();
                string mbiemri = (((TextBox)GridView1.FooterRow.FindControl("insertmbiemri")).Text).ToString();
                string username = (((TextBox)GridView1.FooterRow.FindControl("insertp")).Text).ToString();
                string password = (((TextBox)GridView1.FooterRow.FindControl("insertfjalekalimi")).Text).ToString();
                cmd.CommandText  = "INSERT INTO TBL_MESUESI (MS_ID_SHKOLLA, MS_EMRI, MS_MBIEMRI, MS_USERNAME1, MS_PASSWORD1 , MS_GJENDJA) VALUES(" + Convert.ToUInt64(Session["shkolla"].ToString()) + ",'" + emri + "', " + "'" + mbiemri + "'" + ", '" + username + "', '" + password.Trim() + "', '" + "Aktiv')";
                cmd.Connection = conn;
                conn.Open();
                if (!gjej_perdoruesin(username))
                    cmd.ExecuteNonQuery();
                else
                    msbox("Ky emer perdoruesi egziston !" + "\\n" + "Zgjidhni nje emer perdoruesi tjeter !");
                conn.Close();
                bind(Convert.ToInt64(Session["shkolla"].ToString()));
            }
           
            }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

            long id = Convert.ToInt64(GridView1.DataKeys[e.RowIndex].Value);
            string sql_update = "SELECT * FROM TBL_MESUESI WHERE MS_ID_SHKOLLA = " + Convert.ToInt64(Session["shkolla"].ToString()) + " AND MS_ID_MESUESI = " + id.ToString();
            SqlConnection conn = new SqlConnection(conn_str);
            conn.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(sql_update, conn);
            SqlCommandBuilder b = new SqlCommandBuilder(da);

            da.Fill(ds, "TBL_MESUESI");
            string user_ri = Convert.ToString(((TextBox)GridView1.Rows[e.RowIndex].FindControl("Textbox4")).Text);
            string user_vjeter = ds.Tables[0].Rows[0]["MS_USERNAME1"].ToString();
            if (user_ri!=user_vjeter)
            {
                if (gjej_perdoruesin(user_ri))
                    {
                    msbox("Emri i perdoruesit egziston , zgjidhni nje perdorues tjeter !");
                    conn.Close();
                    return;
                    }
            }
            ds.Tables["TBL_MESUESI"].Rows[0]["MS_EMRI"] = Convert.ToString(((TextBox)GridView1.Rows[e.RowIndex].FindControl("Textbox2")).Text);          
            ds.Tables["TBL_MESUESI"].Rows[0]["MS_MBIEMRI"] = Convert.ToString(((TextBox)GridView1.Rows[e.RowIndex].FindControl("Textbox3")).Text);
            ds.Tables["TBL_MESUESI"].Rows[0]["MS_USERNAME1"] = Convert.ToString(((TextBox)GridView1.Rows[e.RowIndex].FindControl("Textbox4")).Text);
            ds.Tables["TBL_MESUESI"].Rows[0]["MS_PASSWORD1"] = Convert.ToString(((TextBox)GridView1.Rows[e.RowIndex].FindControl("Textbox5")).Text).Trim();
            ds.Tables["TBL_MESUESI"].Rows[0]["MS_GJENDJA"] = Convert.ToString(((DropDownList)GridView1.Rows[e.RowIndex].FindControl("DropDownList1")).SelectedItem.ToString());
            da.Update(ds, "TBL_MESUESI"); 
            conn.Close();
            GridView1.EditIndex = -1;
            bind(Convert.ToInt64(Session["shkolla"].ToString()));
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {

            GridView1.EditIndex = e.NewEditIndex;
            bind(Convert.ToInt64(Session["shkolla"].ToString()));
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            //
        }
        protected void ImageButton7_Click(object sender, ImageClickEventArgs e)
        {
            GridView1.FooterRow.Visible = false;

            for (int i = 0; i <= GridView1.Rows.Count - 1; i++)
            {
                GridView1.Rows[i].Cells[7].Visible = false;
            }
            //************* vetem per gridview me editim
            GridView1.PagerSettings.Visible = false;
            GridView1.GridLines = GridLines.Both;


            StringWriter sw = new StringWriter();

            HtmlTextWriter hw = new HtmlTextWriter(sw);

            GridView1.RenderControl(hw);

            string gridHTML = sw.ToString().Replace("\"", "'")

                .Replace(System.Environment.NewLine, "");

            StringBuilder sb = new StringBuilder();

            sb.Append("<script type = 'text/javascript'>");

            sb.Append("window.onload = new function(){");

            sb.Append("var printWin = window.open('', '', 'left=0");

            sb.Append(",top=0,width=1000,height=600,status=0');");

            sb.Append("printWin.document.write(\"");
            //********

            sb.Append("SHKOLLA : " + Session["emri"].ToString() + "<br><br>");
            sb.Append("MESUESIT <br><br>");
          
            sb.Append(gridHTML);

            sb.Append("\");");

            sb.Append("printWin.document.close();");

            sb.Append("printWin.focus();");

            sb.Append("printWin.print();");

            sb.Append("printWin.close();};");

            sb.Append("</script>");

            ClientScript.RegisterStartupScript(this.GetType(), "GridPrint", sb.ToString());

            GridView1.PagerSettings.Visible = true;
            GridView1.FooterRow.Visible = true;
            GridView1.GridLines = GridLines.None;
            for (int i = 0; i <=GridView1.Rows.Count - 1; i++)
            {
                GridView1.Rows[i].Cells[7].Visible = true;
            }
        }

      

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            bind(Convert.ToInt64(Session["shkolla"].ToString()));
        }
    }
}