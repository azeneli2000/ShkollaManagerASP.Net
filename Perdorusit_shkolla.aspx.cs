using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace WebApplication2
{
    public partial class Perdorusit_shkolla : System.Web.UI.Page
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

            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
        }
        void bind(long idshkolla)
        {
            SqlConnection conn = new SqlConnection();
            DataSet ds1 = new DataSet();
            int i = 0;
            conn.ConnectionString = conn_str;
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM TBL_USERS WHERE USERS_ID_SHKOLLA = " + idshkolla + " ORDER BY USERS_STATUSI");
            SqlCommand cmd1 = new SqlCommand("INSERT INTO TBL_USERS (USERS_ID_SHKOLLA, USERS_EMRI_PERDORUESI, USERS_PASSWORD, USERS_STATUSI) VALUES(" + idshkolla + ", '" + 0 + "', " + "'" + 0 + "'" + ", '" + 0 + "')");
            SqlCommand cmd2 = new SqlCommand("DELETE FROM TBL_USERS WHERE USERS_STATUSI =" + 0);
            cmd.Connection = conn;
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds, "TBL_USERS");
            if (ds.Tables[0].Rows.Count == 0)
            {
                //insert record bosh me nr amze 0
                cmd1.Connection = conn;
                cmd2.Connection = conn;
                cmd1.ExecuteNonQuery();
                da.Fill(ds, "TBL_USERS");
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
            cmd.CommandText = "SELECT USERS_EMRI_PERDORUESI FROM TBL_USERS WHERE UPPER(USERS_EMRI_PERDORUESI) = " + "'" + username.Trim().ToUpper() + "'";
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
                
                string username = (((TextBox)GridView1.FooterRow.FindControl("insertp")).Text).ToString();
                string password = (((TextBox)GridView1.FooterRow.FindControl("insertfjalekalimi")).Text).ToString().Trim();
                string statusi = (((DropDownList)GridView1.FooterRow.FindControl("DropDownList2")).SelectedItem.Text).ToString();
                cmd.CommandText = "INSERT INTO TBL_USERS (USERS_ID_SHKOLLA, USERS_EMRI_PERDORUESI, USERS_PASSWORD, USERS_STATUSI) VALUES(" + Convert.ToUInt64(Session["shkolla"].ToString()) + ",'" + username + "', '" + password + "', '" + statusi + "')";
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
        int gjej_nr_admin()
        {
            int i = 0;
            SqlConnection conn = new SqlConnection(conn_str);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT USERS_EMRI_PERDORUESI FROM TBL_USERS WHERE USERS_STATUSI = '" + "admin"   + "'";
            conn.Open();
            SqlDataReader r = cmd.ExecuteReader();

            while (r.Read())
            {
                i++;
            }
            conn.Close();
            return i;
        }

        bool is_admin(long id)
        {
            int i = 0;
            SqlConnection conn = new SqlConnection(conn_str);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT USERS_STATUSI FROM TBL_USERS WHERE Id = " + id;
            conn.Open();
            SqlDataReader r = cmd.ExecuteReader();

            r.Read();
            if (r["USERS_STATUSI"].ToString() == "admin")
            {
                conn.Close();
                return true;

            }
            else
            { 
                conn.Close();
                return false;
            }
        

        }
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            long id = Convert.ToInt64(GridView1.DataKeys[e.RowIndex].Value);
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = conn_str;
            SqlCommand cmd_del = new SqlCommand();
            if (is_admin(id))
            if (gjej_nr_admin() > 1)
            {
                cmd_del.CommandText = "DELETE FROM TBL_USERS WHERE Id =" + id;
                cmd_del.Connection = conn;
                conn.Open();
                cmd_del.ExecuteNonQuery();
                    bind(Convert.ToInt64(Session["shkolla"].ToString()));
                    conn.Close();
            }
            else
            {
                    conn.Close();
                    GridView1.EditIndex = -1;
                    bind(Convert.ToInt64(Session["shkolla"].ToString()));
                    msbox("Programi duhet te kete te pakten nje administrator !");
                   
                 

                }
            else
            {
                cmd_del.CommandText = "DELETE FROM TBL_USERS WHERE Id =" + id;
                cmd_del.Connection = conn;
                conn.Open();
                cmd_del.ExecuteNonQuery();
                bind(Convert.ToInt64(Session["shkolla"].ToString()));
                conn.Close();
            }
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            bind(Convert.ToInt64(Session["shkolla"].ToString()));
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

            long id = Convert.ToInt64(GridView1.DataKeys[e.RowIndex].Value);
            string sql_update = "SELECT * FROM TBL_USERS WHERE USERS_ID_SHKOLLA = " + Convert.ToInt64(Session["shkolla"].ToString()) + " AND Id = " + id.ToString();
            SqlConnection conn = new SqlConnection(conn_str);
            conn.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(sql_update, conn);
            SqlCommandBuilder b = new SqlCommandBuilder(da);

            da.Fill(ds, "TBL_USERS");
            string user_ri = Convert.ToString(((TextBox)GridView1.Rows[e.RowIndex].FindControl("Textbox4")).Text);
            string user_vjeter = ds.Tables[0].Rows[0]["USERS_EMRI_PERDORUESI"].ToString();
            if (user_ri != user_vjeter)
            {
                if (gjej_perdoruesin(user_ri))
                {
                    msbox("Emri i perdoruesit egziston , zgjidhni nje perdorues tjeter !");
                    conn.Close();
                    return;
                }
            }
           
            ds.Tables["TBL_USERS"].Rows[0]["USERS_EMRI_PERDORUESI"] = Convert.ToString(((TextBox)GridView1.Rows[e.RowIndex].FindControl("Textbox4")).Text);
            ds.Tables["TBL_USERS"].Rows[0]["USERS_PASSWORD"] = Convert.ToString(((TextBox)GridView1.Rows[e.RowIndex].FindControl("Textbox5")).Text).Trim();
            ds.Tables["TBL_USERS"].Rows[0]["USERS_STATUSI"] = Convert.ToString(((DropDownList)GridView1.Rows[e.RowIndex].FindControl("DropDownList1")).SelectedItem.ToString());
            da.Update(ds, "TBL_USERS");
            conn.Close();
            GridView1.EditIndex = -1;
            bind(Convert.ToInt64(Session["shkolla"].ToString()));
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }
    }
}