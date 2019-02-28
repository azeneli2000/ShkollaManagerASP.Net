using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using System.IO;

namespace WebApplication2
{
    public partial class Mesuesit_klasat : System.Web.UI.Page
    {
        public string conn_str = "Server = tcp:azeneli2000.database.windows.net,1433; Initial Catalog = shkolla_prova; Persist Security Info = False; User ID = andi; Password =Matrix2001; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;";
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
               bind();
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

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = conn_str;
            DataSet ds_mes = new DataSet();
            DataSet ds_lendet = new DataSet();
            SqlDataAdapter da_mes = new SqlDataAdapter();
            SqlDataAdapter da_lendet = new SqlDataAdapter();
            SqlCommand cmd_mes = new SqlCommand();
            cmd_mes.Connection = conn;
            cmd_mes.CommandText = "SELECT MS_EMRI + ' ' + MS_MBIEMRI AS mesuesi, MS_ID_MESUESI FROM TBL_MESUESI WHERE MS_GJENDJA = " + "'" + "Aktiv" + "'" + " AND MS_ID_SHKOLLA = " + Convert.ToInt64(Session["shkolla"].ToString());
            SqlCommand cmd_lendet = new SqlCommand();
            //gjen lendet qe ben nje klase
            cmd_lendet.CommandText = "SELECT LN_EMRI FROM TBL_LENDA WHERE LN_KLASA" + klasaddl.SelectedItem.Text + " = " + "'" + "True" + "'" + " and LN_ID_SHKOLLA = " + Convert.ToInt64(Session["shkolla"].ToString()) + " and LN_VITI_SHKOLLOR = '" + vitiddl.SelectedItem.Text + "' ORDER BY LN_EMRI";
            cmd_lendet.Connection = conn;
            conn.Open();
            //mbush kombon e mesuesit
            da_mes.SelectCommand = cmd_mes;
            da_mes.Fill(ds_mes);
            //mbush kommbon e lendeve 
            
            da_lendet.SelectCommand = cmd_lendet;
            da_lendet.Fill(ds_lendet);

            if (e.Row.RowType == DataControlRowType.Footer)
            {
                //mesuesi
                DropDownList dp = (DropDownList)e.Row.FindControl("mesuesiinsert");
                dp.DataSource = ds_mes;
                dp.DataTextField = "mesuesi";
                dp.DataValueField = "MS_ID_MESUESI";

                dp.DataBind();
                dp.Items.Insert(0, new ListItem("Zgjidh mesuesin..."));
                //lenda
                DropDownList dp1 = (DropDownList)e.Row.FindControl("lendainsert");
                dp1.DataSource = ds_lendet;
                dp1.DataTextField = "LN_EMRI";
                dp1.DataValueField = "LN_EMRI";

                dp1.DataBind();
                dp1.Items.Insert(0, new ListItem("Zgjidh lenden..."));
            }
            conn.Close();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
           bind();
            klasaddl.Enabled = false;
            vitiddl.Enabled = false;
           // TextBox lenda = (GridView1.Rows[e.NewEditIndex].FindControl("TextBox3") as TextBox);
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = conn_str;
            DataSet ds_mes = new DataSet();
            DataSet ds_lendet = new DataSet();
            SqlDataAdapter da_mes = new SqlDataAdapter();
            SqlDataAdapter da_lendet = new SqlDataAdapter();
            SqlCommand cmd_mes = new SqlCommand();
            cmd_mes.Connection = conn;
            cmd_mes.CommandText = "SELECT MS_EMRI + ' ' + MS_MBIEMRI AS mesuesi, MS_ID_MESUESI FROM TBL_MESUESI WHERE MS_GJENDJA = " + "'" + "Aktiv" + "'" + " AND MS_ID_SHKOLLA = " + Convert.ToInt64(Session["shkolla"].ToString());
            SqlCommand cmd_lendet = new SqlCommand();
            //gjen lendet qe ben nje klase
            cmd_lendet.CommandText = "SELECT LN_EMRI FROM TBL_LENDA WHERE LN_KLASA" + klasaddl.SelectedItem.Text + " = " + "'" + "True" + "'" + " and LN_ID_SHKOLLA = " + Convert.ToInt64(Session["shkolla"].ToString()) + " and LN_VITI_SHKOLLOR = '" + vitiddl.SelectedItem.Text + "' ORDER BY LN_EMRI";
            cmd_lendet.Connection = conn;
            conn.Open();
            //mbush kombon e mesuesit
            da_mes.SelectCommand = cmd_mes;
            da_mes.Fill(ds_mes);
            //mbush kommbon e lendeve 
            da_lendet.SelectCommand = cmd_lendet;
            da_lendet.Fill(ds_lendet);



            //mesuesi
            DropDownList dp = ((DropDownList)(GridView1.Rows[e.NewEditIndex].FindControl("mes1ddl")));
            dp.DataSource = ds_mes;
            dp.DataTextField = "mesuesi";
            dp.DataValueField = "MS_ID_MESUESI";

            dp.DataBind();
            dp.Items.Insert(0, new ListItem("Zgjidh mesuesin..."));
            //lenda
            DropDownList dp1 = (GridView1.Rows[e.NewEditIndex].FindControl("ledaddl") as DropDownList);
            dp1.DataSource = ds_lendet;
                dp1.DataTextField = "LN_EMRI";
                dp1.DataValueField = "LN_EMRI";

                dp1.DataBind();
                dp1.Items.Insert(0, new ListItem("Zgjidh lenden..."));
         //selekton vlerat korrespondenete  te mesuesit dhe lendes 


            SqlCommand cmd_m1 = new SqlCommand();
            TextBox id = (TextBox)GridView1.Rows[e.NewEditIndex].FindControl("idtext");
            cmd_m1.CommandText = "SELECT ID_MESUESI,EMRI_LENDA FROM TBL_MESUESI_KLASA WHERE Id = " + Convert.ToUInt64(id.Text);
            cmd_m1.Connection = conn;
            SqlDataReader reader = cmd_m1.ExecuteReader();
          
            string id_mes1="";
            string lenda="";
            int i = 0;
            while (reader.Read())
            {
                lenda = reader["EMRI_LENDA"].ToString();
                id_mes1 = reader["ID_MESUESI"].ToString();
                i++;
            }

            //selekton vleren korrepondente te ddl e mesuesit dhe lemdes
            if (i > 0)
            {
                dp.SelectedValue = id_mes1;
                dp1.SelectedValue = lenda;
            }
            conn.Close();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            ulong id = Convert.ToUInt64(GridView1.DataKeys[e.RowIndex].Value);
            string sql_update_mesuesit = "SELECT * FROM TBL_MESUESI_KLASA WHERE Id = " + id; 
            SqlConnection conn = new SqlConnection(conn_str);
            conn.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(sql_update_mesuesit, conn);
            SqlCommandBuilder b = new SqlCommandBuilder(da);
            da.Fill(ds, "TBL_MESUESI_KLASA");
            string lenda_e_re = Convert.ToString(((DropDownList)GridView1.Rows[e.RowIndex].FindControl("ledaddl")).SelectedValue);
            string mesuesi_ri = Convert.ToString(((DropDownList)GridView1.Rows[e.RowIndex].FindControl("mes1ddl")).SelectedValue);
            if (mesuesi_ri == "Zgjidh mesuesin...")
            {
                msbox("Zgjidhni nje mesues per lenden !");
                conn.Close();
                return;
            }

            if (lenda_e_re == "Zgjidh lenden...")
            {
                msbox("Zgjidhni nje lende per mesuesin !");
                conn.Close();
                return;
            }

            ds.Tables["TBL_MESUESI_KLASA"].Rows[0]["ID_MESUESI"] = mesuesi_ri;
            ds.Tables["TBL_MESUESI_KLASA"].Rows[0]["EMRI_LENDA"] =lenda_e_re;
            ds.Tables["TBL_MESUESI_KLASA"].Rows[0]["NGARKESA"] = Convert.ToString(((TextBox)GridView1.Rows[e.RowIndex].FindControl("ngarkesatxt")).Text);
            da.Update(ds, "TBL_MESUESI_KLASA");
            //update te notat
            SqlCommand cmd_update_notat = new SqlCommand();
            cmd_update_notat.Connection = conn;
            cmd_update_notat.CommandText = "UPDATE TBL_NOTA SET NT_ID_MESUESI = " + Convert.ToString(((DropDownList)GridView1.Rows[e.RowIndex].FindControl("mes1ddl")).SelectedValue) + " WHERE NT_VITI_SHKOLLOR = '" + vitiddl.SelectedItem.Text + "' AND NT_EMRI_LENDA = '" + lenda_e_re + "' AND NT_KLASA = '" + klasaddl.SelectedItem.Text + "'" + " AND NT_INDEKSI = '" + indeksiddl.SelectedItem.Text + "' AND NT_ID_SHKOLLA = " + Convert.ToInt64(Session["shkolla"].ToString());
            cmd_update_notat.ExecuteNonQuery();
            conn.Close();
            GridView1.EditIndex = -1;
            bind();
            klasaddl.Enabled = true;
            vitiddl.Enabled = true;
        }
        void bind()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = conn_str;
            conn.Open();
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand();
            SqlCommand cmd1 = new SqlCommand("INSERT INTO TBL_MESUESI_KLASA (ID_SHKOLLA,ID_MESUESI,EMRI_LENDA,NGARKESA,VITI_SHKOLLOR,KLASA,INDEKSI) VALUES(" + Convert.ToInt64(Session["shkolla"].ToString()) + "," + 0 + "," + "'" + 0 + "'" + "," + 0 + ",'" + 0 + "','" + 0 + "','" + 0 + "')");
            SqlCommand cmd2 = new SqlCommand("DELETE FROM TBL_MESUESI_KLASA WHERE EMRI_LENDA = '" + "0" + "'");
            SqlCommand cmd3 = new SqlCommand();
            cmd3.CommandText = "select *  from TBL_MESUESI_KLASA WHERE EMRI_LENDA = '" + "0" + "'" ;
            cmd.Connection = conn;



            DataTable dt = new DataTable();
            cmd.CommandText = "select Id,EMRI_LENDA,NGARKESA,MS_EMRI + ' ' + MS_MBIEMRI  AS ms1 from TBL_MESUESI_KLASA, TBL_MESUESI WHERE KLASA = '" + klasaddl.SelectedItem.Text + "' AND INDEKSI = '" + indeksiddl.SelectedItem.Text + "'  AND MS_ID_MESUESI = ID_MESUESI AND VITI_SHKOLLOR = '" + vitiddl.SelectedItem.Text + "' AND ID_SHKOLLA = " + Convert.ToInt64(Session["shkolla"].ToString()) + " ORDER BY ms1";

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

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            long id = Convert.ToInt64(GridView1.DataKeys[e.RowIndex].Value);
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = conn_str;
            SqlCommand cmd_del = new SqlCommand();
            cmd_del.CommandText = "DELETE FROM TBL_MESUESI_KLASA WHERE Id =" + id; 
            cmd_del.Connection = conn;
            conn.Open();
            cmd_del.ExecuteNonQuery();
            conn.Close();
            e.Cancel = true;
            GridView1.EditIndex = -1;
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            e.Cancel = true;
            GridView1.EditIndex = -1;
            bind();
            vitiddl.Enabled = true;
            klasaddl.Enabled = true;
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Insert")
            {
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = conn_str;
                SqlCommand cmd_ins = new SqlCommand();
               
                string ngarkesa = (((TextBox)GridView1.FooterRow.FindControl("ngarkesainsert")).Text).ToString();
                string id_mes = (((DropDownList)GridView1.FooterRow.FindControl("mesuesiinsert")).SelectedItem.Value).ToString();
                string emri_lenda = (((DropDownList)GridView1.FooterRow.FindControl("lendainsert")).SelectedItem.Value).ToString();
               
                if (id_mes == "Zgjidh mesuesin...")
                {
                    msbox("Zgjidhni nje mesues per lenden !");
                    return;
                }
                if (emri_lenda == "Zgjidh lenden...")
                {
                    msbox("Zgjidhni nje lende per mesuesin !");
                    return;
                }



                cmd_ins.CommandText = "INSERT INTO TBL_MESUESI_KLASA (ID_SHKOLLA,ID_MESUESI,EMRI_LENDA,NGARKESA,VITI_SHKOLLOR,KLASA,INDEKSI) VALUES(" + Convert.ToInt64(Session["shkolla"].ToString()) + "," + id_mes + "," + "'" + emri_lenda + "'" + "," + ngarkesa + ",'" + vitiddl.SelectedItem.Text + "','" + klasaddl.SelectedItem.Text + "','" + indeksiddl.SelectedItem.Text + "')";
                conn.Open();
                cmd_ins.Connection = conn;
                cmd_ins.ExecuteNonQuery();
                conn.Close();
                bind();
            }
        }

        protected void vitiddl_SelectedIndexChanged(object sender, EventArgs e)
        {
            bind();
        }

        protected void klasaddl_SelectedIndexChanged(object sender, EventArgs e)
        {
            bind();
        }

        protected void indeksiddl_SelectedIndexChanged(object sender, EventArgs e)
        {
            bind();
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
            sb.Append("MESUESIT-LENDET <br><br>");
            sb.Append("Viti shkollor : ");
            sb.Append(vitiddl.SelectedItem.Text);
            sb.Append("<br><br>");
            sb.Append("Klasa : ");
            sb.Append(klasaddl.SelectedItem.Text);
            sb.Append(indeksiddl.SelectedItem.Text);
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
            for (int i = 0; i <= GridView1.Rows.Count - 1; i++)
            {
                GridView1.Rows[i].Cells[4].Visible = true;
            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            bind();
        }
    }
   
}