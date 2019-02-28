using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Services;
using System.Data;
using System.Text;
using System.IO;

namespace WebApplication2
{
    public partial class Lendet : System.Web.UI.Page
    {
        public string conn_str = "Server = tcp:azeneli2000.database.windows.net,1433; Initial Catalog = shkolla_prova; Persist Security Info = False; User ID = andi; Password =Matrix2001; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;";

        //public string conn_str = "Data Source=.\\SQLEXPRESS;Initial Catalog=shkolla_prova;Integrated Security=True";  /*ConfigurationManager.ConnectionStrings["db_conn"].ConnectionString;*/

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

            Image1.ImageUrl = "~/Handler1.ashx?Id=" + Session["shkolla"].ToString();
            if (!Page.IsPostBack)
            {
                vitiddl.SelectedValue = gjej_vitin();
                bind(klasaddl.SelectedItem.Text, vitiddl.SelectedItem.Text);
            }
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
        void bind(string klasa, string viti)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = conn_str;
            conn.Open();
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand();
            SqlCommand cmd1 = new SqlCommand("INSERT INTO TBL_LENDA (LN_ID_SHKOLLA, LN_EMRI, LN_VITI_SHKOLLOR, LN_KLASA1, LN_KLASA2, LN_KLASA3, LN_KLASA4, LN_KLASA5, LN_KLASA6, LN_KLASA7, LN_KLASA8, LN_KLASA9, LN_KLASA10,LN_KLASA11,LN_KLASA12,LN_KREDITE,LN_KOEFICENTI) VALUES(" + Convert.ToInt64(Session["shkolla"].ToString()) + ",'" + 0 + "', " + "'" + 0 + "'" + ", '" + 0 + "', '" + 0 + "', '" + 0 + "', '" + 0 + "', '" + 0 + "', '" + 0 + "', '" + 0 + "', '" + 0 + "', '" + 0 + "', '" + 0 + "', '" + 0 + "', '" + 0 + "', '" + 0 + "', '" + 0 + "'" + ")");
            SqlCommand cmd2 = new SqlCommand("DELETE FROM TBL_LENDA WHERE LN_EMRI = '" + "0" + "'");
            SqlCommand cmd3 = new SqlCommand();
            cmd3.CommandText = "select LN_ID,LN_EMRI,LN_KREDITE,LN_KOEFICENTI  from TBL_LENDA WHERE LN_EMRI = '" + "0"+ "'";
            cmd.Connection = conn;



            DataTable dt = new DataTable();
            cmd.CommandText = "select LN_ID,LN_EMRI,LN_KREDITE,LN_KOEFICENTI from TBL_LENDA WHERE LN_KLASA" + klasa + " = 'True'  AND LN_VITI_SHKOLLOR = '" + vitiddl.SelectedItem.Text + "' AND LN_ID_SHKOLLA = " + Convert.ToInt64(Session["shkolla"].ToString()) + " ORDER BY LN_EMRI";
            
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            SqlDataAdapter da1 = new SqlDataAdapter(cmd3);

            da.Fill(ds);

            if (ds.Tables[0].Rows.Count == 0)
            {
                //insert record bosh me nr amze 0
                cmd1.Connection = conn;
                cmd2.Connection = conn;
                cmd3.Connection = conn;
                cmd1.ExecuteNonQuery();
                da1.Fill(ds);
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

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            bind(klasaddl.SelectedItem.Text, vitiddl.SelectedItem.Text);
            klasaddl.Enabled = false;
            vitiddl.Enabled = false;
            //TextBox lenda = (GridView1.Rows[e.NewEditIndex].FindControl("TextBox3") as TextBox);
            //SqlConnection conn = new SqlConnection();
            //conn.ConnectionString = conn_str;
            //DataSet ds = new DataSet();
            //SqlCommand cmd = new SqlCommand();
            //cmd.Connection = conn;
            //DataTable dt = new DataTable();
            //cmd.CommandText = "SELECT MS_EMRI + ' ' + MS_MBIEMRI AS mesuesi,  MS_ID_MESUESI FROM TBL_MESUESI WHERE MS_GJENDJA = " + "'" + "Aktiv" + "'" + " AND MS_ID_SHKOLLA = " + Convert.ToInt64(Session["shkolla"].ToString());
            //SqlDataAdapter da = new SqlDataAdapter(cmd);
            ////mbush combon  e mesuesit
            //conn.Open();
            //da.Fill(ds);
            //DropDownList ddlmes1 = (GridView1.Rows[e.NewEditIndex].FindControl("mes1ddl") as DropDownList);
            //ddlmes1.DataSource = ds;
            //ddlmes1.DataTextField = "mesuesi";
            //ddlmes1.DataValueField = "MS_ID_MESUESI";
            //ddlmes1.DataBind();
            //ddlmes1.Items.Insert(0, new ListItem("Zgjidh mesuesin..."));


            //SqlCommand cmd_m1 = new SqlCommand();
            //cmd_m1.CommandText = "SELECT LN_ID_MESUESI1 FROM TBL_LENDA WHERE LN_EMRI = '" + lenda.Text + "' AND LN_KLASA" + klasaddl.SelectedItem.Text + "= '" + "True" + "' AND LN_VITI_SHKOLLOR = '" + vitiddl.SelectedItem.Text + "'" + " AND LN_ID_SHKOLLA = " + Convert.ToInt64(Session["shkolla"].ToString());
            //cmd_m1.Connection = conn;
            //string id_mes1 = cmd_m1.ExecuteScalar().ToString();
            ////selekton vleren korrepondente te ddl e mesuesit 1
            //ddlmes1.SelectedValue = id_mes1;
            //conn.Close();
        }

        protected void vitiddl_SelectedIndexChanged(object sender, EventArgs e)
        {
            bind(klasaddl.SelectedItem.Text, vitiddl.SelectedItem.Text);
        }

        protected void klasaddl_SelectedIndexChanged(object sender, EventArgs e)
        {
            bind(klasaddl.SelectedItem.Text, vitiddl.SelectedItem.Text);
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //SqlConnection conn = new SqlConnection();
            //conn.ConnectionString = conn_str;
            //DataSet ds_mes = new DataSet();
            //SqlDataAdapter da_mes = new SqlDataAdapter();
            //SqlCommand cmd_mes = new SqlCommand();
            //cmd_mes.Connection = conn;
            //cmd_mes.CommandText = "SELECT MS_EMRI + ' ' + MS_MBIEMRI AS mesuesi, MS_ID_MESUESI FROM TBL_MESUESI WHERE MS_GJENDJA = " + "'" + "Aktiv" + "'" + " AND MS_ID_SHKOLLA = " + Convert.ToInt64(Session["shkolla"].ToString());
            //conn.Open();
            ////mbush kombon e mesuesit
            //da_mes.SelectCommand = cmd_mes;
            //da_mes.Fill(ds_mes);

            //if (e.Row.RowType == DataControlRowType.Footer)
            //{
            //    DropDownList dp = (DropDownList)e.Row.FindControl("DropDownList2");
            //    dp.DataSource = ds_mes;
            //    dp.DataTextField = "mesuesi";
            //    dp.DataValueField = "MS_ID_MESUESI";
               
            //    dp.DataBind();
            //    dp.Items.Insert(0, new ListItem("Zgjidh mesuesin..."));
            //}
            //conn.Close();
        }


        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            e.Cancel = true;
            GridView1.EditIndex = -1;
            bind(klasaddl.SelectedItem.Text, vitiddl.SelectedItem.Text);
            vitiddl.Enabled = true;
            klasaddl.Enabled = true;
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            ulong lenda_id = Convert.ToUInt64(GridView1.DataKeys[e.RowIndex].Value);
            string sql_update_lendet = "SELECT LN_ID,LN_EMRI,LN_KOEFICENTI,LN_KREDITE FROM TBL_LENDA WHERE LN_ID_SHKOLLA = " + Convert.ToInt64(Session["shkolla"].ToString()) + " AND LN_ID = " + lenda_id.ToString() + " AND LN_KLASA" + klasaddl.SelectedItem.Text + "='True" + "'";
            SqlConnection conn = new SqlConnection(conn_str);
            conn.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(sql_update_lendet, conn);
            SqlCommandBuilder b = new SqlCommandBuilder(da);
            da.Fill(ds, "TBL_LENDA");
            string lenda_e_vjeter = ds.Tables[0].Rows[0]["LN_EMRI"].ToString();
            string lenda_e_re = Convert.ToString(((TextBox)GridView1.Rows[e.RowIndex].FindControl("Textbox3")).Text.ToUpper());
            
            if (ds.Tables[0].Rows[0]["LN_EMRI"].ToString() != Convert.ToString(((TextBox)GridView1.Rows[e.RowIndex].FindControl("Textbox3")).Text.ToUpper()))
            {
                if (check_lendet(Convert.ToString(((TextBox)GridView1.Rows[e.RowIndex].FindControl("Textbox3")).Text.ToUpper())) == true)
                {
                    msbox("Emri i lendes egziston per kete klase, zgjidhni nje emer tjeter !");
                    conn.Close();
                    return;
                }
            }
            //if (Convert.ToString(((DropDownList)GridView1.Rows[e.RowIndex].FindControl("mes1ddl")).SelectedValue) == "Zgjidh mesuesin...")
            //{
            //    msbox("Zgjidhni nje mesues per lenden !");
            //    conn.Close();
            //    return;
            //}
            //update te tabela e lendeve
            ds.Tables["TBL_LENDA"].Rows[0]["LN_EMRI"] = Convert.ToString(((TextBox)GridView1.Rows[e.RowIndex].FindControl("Textbox3")).Text.ToUpper());
            ds.Tables["TBL_LENDA"].Rows[0]["LN_KOEFICENTI"] = Convert.ToString(((TextBox)GridView1.Rows[e.RowIndex].FindControl("Textbox5")).Text);
            ds.Tables["TBL_LENDA"].Rows[0]["LN_KREDITE"] = Convert.ToString(((TextBox)GridView1.Rows[e.RowIndex].FindControl("Textbox4")).Text);
           // ds.Tables["TBL_LENDA"].Rows[0]["LN_ID_MESUESI1"] = Convert.ToString(((DropDownList)GridView1.Rows[e.RowIndex].FindControl("mes1ddl")).SelectedValue);
            da.Update(ds, "TBL_LENDA");
            //update tek tabela e notave
            SqlCommand cmd_update_notat = new SqlCommand();
            cmd_update_notat.Connection = conn;
            cmd_update_notat.CommandText = "UPDATE TBL_NOTA SET NT_EMRI_LENDA = '" + lenda_e_re + "' " + /*",NT_ID_MESUESI = " + Convert.ToString(((DropDownList)GridView1.Rows[e.RowIndex].FindControl("mes1ddl")).SelectedValue) +*/ " WHERE NT_VITI_SHKOLLOR = '" + vitiddl.SelectedItem.Text + "' AND NT_EMRI_LENDA = '" + lenda_e_vjeter + "' AND NT_KLASA = '" + klasaddl.SelectedItem.Text + "'" + " AND NT_ID_SHKOLLA = " + Convert.ToInt64(Session["shkolla"].ToString());
            cmd_update_notat.ExecuteNonQuery();
            conn.Close();
            GridView1.EditIndex = -1;
            bind(klasaddl.SelectedItem.Text, vitiddl.SelectedItem.Text);
            klasaddl.Enabled = true;
            vitiddl.Enabled = true;

        }


        bool check_lendet(string lenda)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = conn_str;
            int i = 0;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT LN_EMRI FROM TBL_LENDA WHERE LN_EMRI = '" + lenda + "'" + "AND LN_KLASA" + klasaddl.SelectedItem.Text + " = 'True' AND LN_VITI_SHKOLLOR = '" + vitiddl.SelectedItem.Text + "' AND LN_ID_SHKOLLA = " + Convert.ToInt64(Session["shkolla"].ToString());
            cmd.Connection = conn;
            conn.Open();
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                i++;
            }
            conn.Close();
            if (i == 0)
                return false;
            else
                return true;
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Insert")
            {
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = conn_str;
                SqlCommand cmd_ins = new SqlCommand();
                string emri = (((TextBox)GridView1.FooterRow.FindControl("insertemri")).Text).ToString().ToUpper();
                string kredite = (((TextBox)GridView1.FooterRow.FindControl("insertkredite")).Text).ToString();
                string koef = (((TextBox)GridView1.FooterRow.FindControl("insertkoef")).Text).ToString();
                //string id_mes =  (((DropDownList)GridView1.FooterRow.FindControl("DropDownList2")).SelectedItem.Value).ToString();
                //if (id_mes == "Zgjidh mesuesin...")
                //{
                //    msbox("Zgjidhni nje mesues per lenden !");
                //                     return;
                //}
                if(check_lendet(emri))
                {
                    msbox("Ky emer egziston per klasen dhe vitin shkollor te dhene !");
                   
                    return;

                }
                cmd_ins.CommandText = "insert into TBL_LENDA (LN_EMRI,LN_KLASA" +klasaddl.SelectedItem.Text +",LN_KOEFICENTI,LN_KREDITE,LN_VITI_SHKOLLOR,LN_ID_SHKOLLA) values ('" + emri +"','True'," + koef + "," + kredite + ",'" + vitiddl.SelectedItem.Text +"', " +Convert.ToInt64( Session["shkolla"]) + ")";
                conn.Open();
                cmd_ins.Connection = conn;
                cmd_ins.ExecuteNonQuery();
                conn.Close();
                bind(klasaddl.SelectedItem.Text, vitiddl.SelectedItem.Text);
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            long id = Convert.ToInt64(GridView1.DataKeys[e.RowIndex].Value);
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = conn_str;
            SqlCommand cmd_del = new SqlCommand();          
            SqlCommand cmd_notat = new SqlCommand();            
            cmd_notat.CommandText = "SELECT NT_EMRI_LENDA FROM TBL_NOTA WHERE NT_KLASA= '" +klasaddl.SelectedItem.Text+  "' AND NT_VITI_SHKOLLOR = '" + vitiddl.SelectedItem.Text + "'" +" AND NT_ID_SHKOLLA = " + Convert.ToInt64(Session["shkolla"].ToString());
            cmd_notat.Connection = conn;
            cmd_del.Connection = conn;
            conn.Open();

            SqlDataReader rdr = cmd_notat.ExecuteReader();
            int i = 0;
            
            while (rdr.Read())
            {
                i++;

            }
            rdr.Close();
            if (i == 0)
            {
                cmd_del.CommandText = "UPDATE TBL_LENDA SET LN_KLASA" + klasaddl.SelectedItem.Text + " = 0 WHERE LN_ID = '" + id.ToString() + "' AND LN_VITI_SHKOLLOR = '" + vitiddl.SelectedItem.Text + "'" + " AND LN_ID_SHKOLLA = " + Convert.ToInt64(Session["shkolla"].ToString());
                cmd_del.ExecuteNonQuery();

            }
            else
            {
                msbox("Lenda e zgjedhur nuk mund te fshihet pasi jane marre nota !");
                conn.Close();
                return;
               
            }
            conn.Close();
            e.Cancel = true;
            GridView1.EditIndex = -1;
            bind(klasaddl.SelectedItem.Text,vitiddl.SelectedItem.Text);

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
                GridView1.Rows[i].Cells[4].Visible = false;
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
            sb.Append("LENDET <br><br>");
            sb.Append("Viti shkollor : ");
            sb.Append(vitiddl.SelectedItem.Text);
            sb.Append("<br><br>");
            sb.Append("Klasa : ");
            sb.Append(klasaddl.SelectedItem.Text);
         
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
                GridView1.Rows[i].Cells[4].Visible = true;
            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            bind(klasaddl.SelectedItem.Text,vitiddl.SelectedItem.Text);
        }
    }
}