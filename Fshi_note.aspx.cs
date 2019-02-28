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
    public partial class Fshi_note : System.Web.UI.Page
    {

        public bool cikli = true;
        public string conn_str = "Server = tcp:azeneli2000.database.windows.net,1433; Initial Catalog = shkolla_prova; Persist Security Info = False; User ID = andi; Password =Matrix2001; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;";
        // public string conn_str = "Data Source=.\\SQLEXPRESS;Initial Catalog=shkolla_prova;Integrated Security=True";  /*ConfigurationManager.ConnectionStrings["db_conn"].ConnectionString;*/

        public string gjej_vitin()
        {
            if (DateTime.Now.Month >= 7)
                return (DateTime.Now.Year).ToString() + "-" + (DateTime.Now.Year + 1).ToString();
            else
                return
                 (DateTime.Now.Year - 1).ToString() + "-" + (DateTime.Now.Year).ToString();
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

            if (Convert.ToInt16(klasaddl_v.SelectedItem.Text) <= 9)
            {
                cikli = true;
            }

            else
            {
                cikli = false;
            }
                if (!Page.IsPostBack)
            {
                vitiddl_v.SelectedValue = gjej_vitin();
                bind_lendet();
                bind();
                bind_notat();
            }

        }
        void bind()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = conn_str;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            DataSet ds = new DataSet();

            conn.Open();
            cmd.CommandText = "select KL_NR_AMZA,AMZA_EMRI + ' ' + AMZA_MBIEMRI as Emri from TBL_KLASA, TBL_AMZA where(KL_NR_AMZA = AMZA_NR_AMZA) and KL_KLASA = '" + klasaddl_v.SelectedItem.Text + "' and KL_INDEKSI = '" + indeksiddl_v.SelectedItem.Text + "' and KL_ID_SHKOLLA =" + Convert.ToInt64(Session["shkolla"].ToString()) + " and KL_VITI_SHKOLLOR = '" + vitiddl_v.SelectedItem.Text + "'" + " and AMZA_LARGUAR = '" + "False" + "' and (AMZA_VITI_LARGIMIT is null OR AMZA_VITI_LARGIMIT != '" + vitiddl_v.SelectedItem.Text + "')" + " and AMZA_CIKLI = '" + cikli + "' and AMZA_ID_SHKOLLA = " + Convert.ToInt64(Session["shkolla"].ToString()) + " ORDER BY Emri";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            DropDownList1.DataSource = ds;
            DropDownList1.DataTextField = "Emri";
            DropDownList1.DataValueField = "KL_NR_AMZA";
            DropDownList1.DataBind();
            conn.Close();

        }



        void bind_lendet()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = conn_str;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            conn.Open();
            cmd.CommandText = "select LN_EMRI from TBL_LENDA where LN_KLASA" + klasaddl_v.SelectedItem.Text + " = 'True' and LN_VITI_SHKOLLOR = '" + vitiddl_v.SelectedItem.Text + "' and LN_ID_SHKOLLA = " + Convert.ToInt64(Session["shkolla"].ToString()) + " ORDER BY LN_EMRI";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            lendaddl.DataSource = ds;
            lendaddl.DataTextField = "LN_EMRI";
            lendaddl.DataValueField = "LN_EMRI";
            lendaddl.DataBind();

            conn.Close();
          
        }

        void bind_notat()
            {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = conn_str;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            conn.Open();
            if (DropDownList1.Items.Count > 0 && lendaddl.Items.Count > 0)
            {
                cmd.CommandText = "select * from TBL_NOTA where NT_CIKLI = '" + cikli + "' and NT_KLASA = '" + klasaddl_v.SelectedItem.Text + "' and NT_INDEKSI = '" + indeksiddl_v.SelectedItem.Text + "' and NT_NR_AMZA = '" + DropDownList1.SelectedValue + "' and NT_EMRI_LENDA = '" + lendaddl.SelectedItem.Text + "' and NT_ID_SHKOLLA = " + Convert.ToInt64(Session["shkolla"].ToString()) + "ORDER BY NT_DATA";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                GridView1.DataSource = ds;
                GridView1.DataBind();
            }
            conn.Close();
        }

        protected void vitiddl_v_SelectedIndexChanged(object sender, EventArgs e)
        {

            bind_lendet();
            bind();
            if (DropDownList1.Items.Count > 0 && lendaddl.Items.Count>0)
            bind_notat();

        }

        protected void klasaddl_v_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt16(klasaddl_v.SelectedItem.Text) <= 9)
            {
                cikli = true;
            }

            else
            {
                cikli = false;
            }

            bind_lendet();
            bind();
            if (DropDownList1.Items.Count > 0 && lendaddl.Items.Count > 0)
                bind_notat();
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //bind_lendet();
            //bind();
            if (DropDownList1.Items.Count > 0 && lendaddl.Items.Count > 0)
                bind_notat();
        }

        protected void lendaddl_SelectedIndexChanged(object sender, EventArgs e)
        {
            //bind_lendet();
            bind();
            if (DropDownList1.Items.Count > 0 && lendaddl.Items.Count > 0)
                bind_notat();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            e.Cancel = true;
            GridView1.EditIndex = -1;
            bind_notat();        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            long id = Convert.ToInt64(GridView1.DataKeys[e.RowIndex].Value);
          
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = conn_str;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "DELETE FROM TBL_NOTA WHERE NT_ID = " + id;
            cmd.Connection = conn;
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            e.Cancel = true;
            GridView1.EditIndex = -1;
            bind_notat();
          
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
                bind_notat();
            if (Convert.ToString(((TextBox)GridView1.Rows[e.NewEditIndex].FindControl("Textbox3")).Text) == "m")
            {
                ((CheckBox)GridView1.Rows[e.NewEditIndex].FindControl("CheckBox_goje")).Enabled = false;
                ((CheckBox)GridView1.Rows[e.NewEditIndex].FindControl("CheckBox_shkrim")).Enabled = false;
                ((CheckBox)GridView1.Rows[e.NewEditIndex].FindControl("CheckBox_projekt")).Enabled = false;
            }



        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            long id = Convert.ToInt64(GridView1.DataKeys[e.RowIndex].Value);
            string str_update = "select * from TBL_NOTA where NT_ID = " + id;
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = conn_str;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = str_update;
            cmd.Connection = conn;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            SqlCommandBuilder b = new SqlCommandBuilder(da);
            DataSet ds = new DataSet();
            conn.Open();
            da.Fill(ds,"TBL_NOTA");
            if (Convert.ToString(((TextBox)GridView1.Rows[e.RowIndex].FindControl("Textbox3")).Text) == "m")
            {
                ((CheckBox)GridView1.Rows[e.RowIndex].FindControl("CheckBox_goje")).Enabled = false;
                ((CheckBox)GridView1.Rows[e.RowIndex].FindControl("CheckBox_shkrim")).Enabled = false;
                ((CheckBox)GridView1.Rows[e.RowIndex].FindControl("CheckBox_projekt")).Enabled = false;
            }

            if (((CheckBox)GridView1.Rows[e.RowIndex].FindControl("CheckBox_goje")).Checked && ((CheckBox)GridView1.Rows[e.RowIndex].FindControl("CheckBox_shkrim")).Checked)
            {
                conn.Close();
                return;

            }

            if (((CheckBox)GridView1.Rows[e.RowIndex].FindControl("CheckBox_goje")).Checked && ((CheckBox)GridView1.Rows[e.RowIndex].FindControl("CheckBox_projekt")).Checked)
            {
                conn.Close();
                return;

            }
            if (((CheckBox)GridView1.Rows[e.RowIndex].FindControl("CheckBox_shkrim")).Checked && ((CheckBox)GridView1.Rows[e.RowIndex].FindControl("CheckBox_projekt")).Checked)
            {
                conn.Close();
                return;

            }
            if (((CheckBox)GridView1.Rows[e.RowIndex].FindControl("CheckBox_shkrim")).Checked && ((CheckBox)GridView1.Rows[e.RowIndex].FindControl("CheckBox_projekt")).Checked && ((CheckBox)GridView1.Rows[e.RowIndex].FindControl("CheckBox_goje")).Checked)
            {
                conn.Close();
                return;

            }
            if (!((CheckBox)GridView1.Rows[e.RowIndex].FindControl("CheckBox_shkrim")).Checked && !((CheckBox)GridView1.Rows[e.RowIndex].FindControl("CheckBox_projekt")).Checked && !((CheckBox)GridView1.Rows[e.RowIndex].FindControl("CheckBox_goje")).Checked)
            {
                conn.Close();
                return;

            }


           


            ds.Tables[0].Rows[0]["NT_VLERESIMI"] = Convert.ToString(((TextBox)GridView1.Rows[e.RowIndex].FindControl("Textbox3")).Text);
            ds.Tables[0].Rows[0]["NT_MOMENTALE"] = ((CheckBox)GridView1.Rows[e.RowIndex].FindControl("CheckBox_goje")).Checked;
            ds.Tables[0].Rows[0]["NT_DETYREKONTROLLI"] = ((CheckBox)GridView1.Rows[e.RowIndex].FindControl("CheckBox_shkrim")).Checked;
            ds.Tables[0].Rows[0]["NT_PROJEKT"] = ((CheckBox)GridView1.Rows[e.RowIndex].FindControl("CheckBox_projekt")).Checked;
            da.Update(ds, "TBL_NOTA");
            conn.Close();
            GridView1.EditIndex = -1;
            bind_notat();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            foreach (GridViewRow roww in GridView1.Rows)
            {
                foreach (TableCell cell in roww.Cells)
                {
                    cell.Attributes.CssStyle["text-align"] = "center";
                }


            }
        }

        protected void indeksiddl_v_SelectedIndexChanged(object sender, EventArgs e)
        {
            bind();
            if (DropDownList1.Items.Count > 0 && lendaddl.Items.Count > 0)
                bind_notat();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            bind();
        }
    }
}