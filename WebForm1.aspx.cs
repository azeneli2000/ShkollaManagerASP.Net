using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;
using System.IO;

namespace WebApplication2
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        public bool cikli = true;

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


        public void OnConfirm(object sender, EventArgs e)
        {
           
        }
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

            if (Convert.ToInt16(klasaddl.SelectedItem.Text) <= 9)
            {
                cikli = true;
            }

            else
            {
                cikli = false;
            }
            GridView1.PageIndex = 0;

            if (!Page.IsPostBack)
            {
                vitiddl.SelectedValue = gjej_vitin();
                //TextBox14.Text = "Nr Amza";
                //RadioButtonList1.SelectedIndex = 0;
                bind(klasaddl.SelectedItem.Text, indeksiddl.SelectedItem.Text, Convert.ToInt64(Session["shkolla"].ToString()), vitiddl.SelectedItem.ToString());
                //((DropDownList)GridView1.FooterRow.FindControl("DropDownList3")).SelectedIndex = klasaddl.SelectedIndex;
                //((DropDownList)GridView1.FooterRow.FindControl("DropDownList4")).Text = indeksiddl.SelectedValue.ToString();
                //((DropDownList)GridView1.FooterRow.FindControl("DropDownList2")).Text = vitiddl.SelectedValue.ToString();
                //GridView1.FooterRow.Visible = false;



            }
  

        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            e.Cancel = true;
            GridView1.EditIndex = -1;
            bind(klasaddl.SelectedItem.Text, indeksiddl.SelectedItem.Text, Convert.ToInt64(Session["shkolla"].ToString()), vitiddl.SelectedItem.ToString());

        }

        void bind(string klasa, string indeksi, long idshkolla,string viti_shkollor)
        {
            SqlConnection conn = new SqlConnection();
            //SqlDataSource source = new SqlDataSource();
            int i = 0;
            conn.ConnectionString = conn_str;
            conn.Open();            
            SqlCommand cmd = new SqlCommand("SELECT * FROM TBL_AMZA WHERE AMZA_KLASA = " + "'" + klasa + "'" + "AND AMZA_INDEKSI = " + "'" + indeksi + "'" + "AND AMZA_VITI_SHKOLLOR = " + "'" + viti_shkollor + "'" + "AND AMZA_ID_SHKOLLA = " + @idshkolla + " ORDER BY AMZA_EMRI, AMZA_MBIEMRI");
            SqlCommand cmd1 = new SqlCommand("INSERT INTO TBL_AMZA (AMZA_ID_SHKOLLA, AMZA_NR_AMZA, AMZA_CIKLI, AMZA_EMRI, AMZA_MBIEMRI, AMZA_ATESIA, AMZA_MEMESIA, AMZA_SEKSI, AMZA_VENDLINDJA, AMZA_DATELINDJA, AMZA_VITI_SHKOLLOR, AMZA_INDEKSI, AMZA_KLASA, AMZA_LARGUAR) VALUES(" + idshkolla + ",'" + 0 + "', " + "'" + cikli + "'" + ", '" + 0 + "', '" + 0 + "', '" + 0 + "', '" + 0 + "', '" + 0 + "', '" + 0 + "', '" + 0 + "', '" + viti_shkollor + "', '" + indeksi + "', '" + klasa + "'" + ",'False')");
            SqlCommand cmd2 = new SqlCommand("DELETE FROM TBL_AMZA WHERE AMZA_NR_AMZA =" + 0);
            cmd.Connection = conn;
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count == 0)
            {
                //insert record bosh me nr amze 0
                cmd1.Connection = conn;
                cmd2.Connection = conn;
                cmd1.ExecuteNonQuery();
                da.Fill(ds);
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
            ((DropDownList)GridView1.FooterRow.FindControl("DropDownList3")).SelectedIndex = klasaddl.SelectedIndex;
            ((DropDownList)GridView1.FooterRow.FindControl("DropDownList4")).Text = indeksiddl.SelectedValue.ToString();
            ((DropDownList)GridView1.FooterRow.FindControl("DropDownList2")).Text = vitiddl.SelectedValue.ToString();
            conn.Close();

        }
        //funksion qe sherben per te mbajtur seksin e njejte gjate editimit
        string gjej_seksin(long idshkolla, string amza)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = conn_str;
            conn.Open();
            string s = "SELECT AMZA_SEKSI FROM TBL_AMZA WHERE AMZA_NR_AMZA = " + "'" + amza + "'" + " AND AMZA_ID_SHKOLLA = " + @idshkolla;
            SqlCommand cmd = new SqlCommand("SELECT AMZA_SEKSI FROM TBL_AMZA WHERE AMZA_NR_AMZA = " + "'" + amza + "'" + "AND AMZA_ID_SHKOLLA = " + @idshkolla + "AND AMZA_CIKLI = " + "'" + cikli + "'");
            cmd.Connection = conn;
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
                s = reader["AMZA_SEKSI"].ToString();

            conn.Close();
            return s;
        }


        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string klasa = klasaddl.Text, indeksi = indeksiddl.Text;
            long id_shkolla = 1;

            long id = Convert.ToInt64(GridView1.DataKeys[e.RowIndex].Value);
            string sql_update = "SELECT * FROM TBL_AMZA WHERE AMZA_KLASA = " + "'" + klasa + "'" + "AND AMZA_INDEKSI = " + "'" + indeksi + "'" + "AND AMZA_ID_SHKOLLA = " + Convert.ToInt64(Session["shkolla"].ToString()) + "AND AMZA_NR_AMZA = " + @id + "AND AMZA_CIKLI = " + "'" + cikli + "'";
            SqlConnection conn = new SqlConnection(conn_str);
            conn.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(sql_update, conn);
            SqlCommandBuilder b = new SqlCommandBuilder(da);

            da.Fill(ds, "TBL_AMZA");
            ds.Tables[0].Rows[0]["AMZA_NR_AMZA"] = Convert.ToString(((TextBox)GridView1.Rows[e.RowIndex].FindControl("Textbox1")).Text);
            // ds.Tables[0].Rows[0]["AMZA_NR_AMZA"] = "15";
            string s1 = Convert.ToString(((TextBox)GridView1.Rows[e.RowIndex].FindControl("Textbox1")).Text);
            string s2 = Convert.ToString(((TextBox)GridView1.Rows[e.RowIndex].FindControl("TextBox1")).Text);
            ds.Tables["TBL_AMZA"].Rows[0]["AMZA_EMRI"] = Convert.ToString(((TextBox)GridView1.Rows[e.RowIndex].FindControl("Textbox2")).Text);
            ds.Tables["TBL_AMZA"].Rows[0]["AMZA_MBIEMRI"] = Convert.ToString(((TextBox)GridView1.Rows[e.RowIndex].FindControl("Textbox3")).Text);
            ds.Tables["TBL_AMZA"].Rows[0]["AMZA_ATESIA"] = Convert.ToString(((TextBox)GridView1.Rows[e.RowIndex].FindControl("Textbox4")).Text);
            ds.Tables["TBL_AMZA"].Rows[0]["AMZA_MEMESIA"] = Convert.ToString(((TextBox)GridView1.Rows[e.RowIndex].FindControl("Textbox5")).Text);

            ds.Tables["TBL_AMZA"].Rows[0]["AMZA_SEKSI"] = Convert.ToString(((DropDownList)GridView1.Rows[e.RowIndex].FindControl("DropDownList1")).SelectedItem.Text);
            ds.Tables["TBL_AMZA"].Rows[0]["AMZA_VENDLINDJA"] = Convert.ToString(((TextBox)GridView1.Rows[e.RowIndex].FindControl("Textbox7")).Text);
            ds.Tables["TBL_AMZA"].Rows[0]["AMZA_DATELINDJA"] = Convert.ToString(((TextBox)GridView1.Rows[e.RowIndex].FindControl("Textbox13")).Text);
            ds.Tables["TBL_AMZA"].Rows[0]["AMZA_VREJTJE"] = Convert.ToString(((TextBox)GridView1.Rows[e.RowIndex].FindControl("Textbox9")).Text);
            ds.Tables["TBL_AMZA"].Rows[0]["AMZA_VITI_SHKOLLOR"] = Convert.ToString(((DropDownList)GridView1.Rows[e.RowIndex].FindControl("DropDownList2")).SelectedItem.Text);
            ds.Tables["TBL_AMZA"].Rows[0]["AMZA_KLASA"] = Convert.ToString(((DropDownList)GridView1.Rows[e.RowIndex].FindControl("DropDownList3")).SelectedItem.Text);

            ds.Tables["TBL_AMZA"].Rows[0]["AMZA_INDEKSI"] = Convert.ToString(((DropDownList)GridView1.Rows[e.RowIndex].FindControl("DropDownList4")).SelectedItem.Text);



            da.Update(ds, "TBL_AMZA");

            conn.Close();
            GridView1.EditIndex = -1;
            bind(klasaddl.SelectedItem.Text, indeksiddl.SelectedItem.Text, Convert.ToInt64( Session["shkolla"].ToString()),vitiddl.SelectedItem.ToString());
            vitiddl.Enabled = true;
            klasaddl.Enabled = true;
            indeksiddl.Enabled = true;


        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            bind(klasaddl.SelectedItem.Text, indeksiddl.SelectedItem.Text, Convert.ToInt64(Session["shkolla"].ToString()),vitiddl.SelectedItem.ToString());
            ((DropDownList)GridView1.Rows[e.NewEditIndex].FindControl("DropDownList3")).SelectedIndex = klasaddl.SelectedIndex;
            ((DropDownList)GridView1.Rows[e.NewEditIndex].FindControl("DropDownList4")).Text = indeksiddl.SelectedValue.ToString();
            ((DropDownList)GridView1.Rows[e.NewEditIndex].FindControl("DropDownList2")).Text = vitiddl.SelectedValue.ToString();
            ((DropDownList)GridView1.Rows[e.NewEditIndex].FindControl("DropDownList1")).Text = gjej_seksin(1, ((TextBox)GridView1.Rows[e.NewEditIndex].FindControl("TextBox1")).Text);
            

            ////caktivizon ddl 
            vitiddl.Enabled = false;
            klasaddl.Enabled = false;
            indeksiddl.Enabled = false;
        }

        protected void klasaddl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt16(klasaddl.Text) <= 9)
                cikli = true;
            else
                cikli = false;
            bind(klasaddl.SelectedItem.Text, indeksiddl.SelectedItem.Text, Convert.ToInt64(Session["shkolla"].ToString()),vitiddl.SelectedItem.ToString());
        }
        public string gjeneralitete_check  (string emri, string mbiemri, string atesia,bool cikli )
            {
            int i = 0;
            string viti = "";
            bool larguar = false;
            int p = 0;
            string klasa = "" ;
            string amza = "";

            SqlConnection conn = new SqlConnection(conn_str);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT AMZA_NR_AMZA, AMZA_VITI_SHKOLLOR, AMZA_LARGUAR, AMZA_KLASA FROM TBL_AMZA WHERE UPPER(AMZA_EMRI) = " + "'" +  emri.Trim().ToUpper() +"'" + "AND UPPER(AMZA_MBIEMRI) = '" + mbiemri.Trim().ToUpper() + "'" + "AND UPPER(AMZA_ATESIA) = '" + atesia.Trim().ToUpper() + "'" + "AND AMZA_CIKLI = '" + cikli + "'";
            conn.Open();
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                amza = r["AMZA_NR_AMZA"].ToString();
                viti = r["AMZA_VITI_SHKOLLOR"].ToString();
                larguar = Convert.ToBoolean(r["AMZA_LARGUAR"]);
                klasa = r["AMZA_KLASA"].ToString();
                i++;
            }
            conn.Close();
            //i = Convert.ToInt32(viti.Substring(viti.Length - 4));
            if (i == 0)
            {
                return "ska";// rasti kur ska nxenes me keto gjeneralitete
           
            }
            else
                if (larguar && Convert.ToInt32(viti.Substring(viti.Length - 4)) < Convert.ToInt32(vitiddl.SelectedItem.Text.Substring(viti.Length - 4))&& Convert.ToInt16(klasa)<Convert.ToInt16(klasaddl.SelectedItem.ToString()))
            {
                return amza ;//rasti kur eshte larguar me perpara funksioni kthen nr e amzes perkates
          
            }
            else
            {
                return "ka";
            
            }

        }
        public bool amza_check(string amza,  bool cikli)
        {
            int i = 0;
            SqlConnection conn = new SqlConnection(conn_str);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT AMZA_NR_AMZA FROM TBL_AMZA WHERE AMZA_NR_AMZA = " + "'" + amza + "' AND AMZA_CIKLI = '" + cikli + "'";
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
                SqlCommand cmd3 = new SqlCommand();
                string nramza = (((TextBox)GridView1.FooterRow.FindControl("insertamza")).Text).ToString();
                string emri = (((TextBox)GridView1.FooterRow.FindControl("insertemri")).Text).ToString();
                string mbiemri = (((TextBox)GridView1.FooterRow.FindControl("insertmbiemri")).Text).ToString();
                string atesia = (((TextBox)GridView1.FooterRow.FindControl("insertatesia")).Text).ToString();
                string memesia = (((TextBox)GridView1.FooterRow.FindControl("insertmemesia")).Text).ToString();
                string seksi = (((DropDownList)GridView1.FooterRow.FindControl("DropDownList1")).SelectedItem.Text).ToString();
                string vendlindja = (((TextBox)GridView1.FooterRow.FindControl("insertvendlindja")).Text).ToString();
                string datelindja = (((TextBox)GridView1.FooterRow.FindControl("insertdatelindja")).Text).ToString();
                string vrejtje = (((TextBox)GridView1.FooterRow.FindControl("insertvrejtje")).Text).ToString();
                string viti_shkollor = (((DropDownList)GridView1.FooterRow.FindControl("DropDownList2")).SelectedItem.Text).ToString();
                string klasa = (((DropDownList)GridView1.FooterRow.FindControl("DropDownList3")).SelectedItem.Text).ToString();
                string indeksi = (((DropDownList)GridView1.FooterRow.FindControl("DropDownList4")).SelectedItem.Text).ToString();
                string amza_lrguar = gjeneralitete_check(emri, mbiemri, atesia, cikli);
                //insert te tabela e amzes
                cmd.CommandText = "INSERT INTO TBL_AMZA (AMZA_ID_SHKOLLA, AMZA_NR_AMZA, AMZA_CIKLI, AMZA_EMRI, AMZA_MBIEMRI, AMZA_ATESIA, AMZA_MEMESIA, AMZA_SEKSI, AMZA_VENDLINDJA, AMZA_DATELINDJA, AMZA_VITI_SHKOLLOR, AMZA_INDEKSI, AMZA_KLASA, AMZA_LARGUAR) VALUES(" + Convert.ToInt64(Session["shkolla"].ToString()) + ",'" + nramza + "', " + "'" + cikli + "'" + ", '" + emri + "', '" + mbiemri + "', '" + atesia + "', '" + memesia + "', '" + seksi + "', '" + vendlindja + "', '" + datelindja + "', '" + viti_shkollor + "', '" + indeksi + "', '" + klasa + "'" + ",'False')";
                //insert te tabela e klases
                cmd1.CommandText = "INSERT INTO TBL_KLASA (KL_ID_SHKOLLA, KL_NR_AMZA, KL_CIKLI, KL_VITI_SHKOLLOR, KL_KLASA, KL_INDEKSI) VALUES (" + Convert.ToInt64(Session["shkolla"].ToString()) +", '"  + nramza + "' , '" + cikli +  "' ,'" + viti_shkollor + "' ,'" + klasa + "' ,'" + indeksi + "')";
                //insert te tabela e klases me nr e amzes se meparshem nqs eshte larguar
                cmd2.CommandText = "INSERT INTO TBL_KLASA (KL_ID_SHKOLLA, KL_NR_AMZA, KL_CIKLI, KL_VITI_SHKOLLOR, KL_KLASA, KL_INDEKSI) VALUES (" + Convert.ToInt64(Session["shkolla"].ToString()) + ", '" + amza_lrguar + "' , '" + cikli + "' ,'" + viti_shkollor + "' ,'" + klasa + "' ,'" + indeksi + "')";
                //insert te tabela  e amzes me amzene e mepareshme ne klasen dhe vitin  e dhene
                cmd3.CommandText = "update TBL_AMZA set AMZA_LARGUAR = '" + "False" + "' AMZA_VITI_SHKOLLOR = '"+ vitiddl.SelectedItem.Text+"', AMZA_KLASA = '" + klasaddl.SelectedItem.Text + "',AMZA_INDEKSI = '" + indeksiddl.SelectedItem.Text + "' where AMZA_NR_AMZA = " + amza_lrguar + "and AMZA_CIKLI = '" + cikli + "' and AMZA_ID_SHKOLLA =" + Convert.ToInt64(Session["shkolla"].ToString());
                cmd.Connection = conn;
                cmd1.Connection = conn;
                cmd2.Connection = conn;
                cmd3.Connection = conn;


                if (gjeneralitete_check(emri,mbiemri,atesia,cikli) == "ka")
                {
                    msbox("Nxenesi " + emri.ToUpper() + " " + " " + atesia.ToUpper() + " " + mbiemri.ToUpper() + " egziston ne amze !"  + "\\n" +"Hedhja ne amze nuk u krye !");
                    return;
                }
              
                if (amza_check(nramza, cikli))
                {
                    msbox("Numri " + nramza + " egziston ne amze !" + "\\n" + " Hedhja ne amze nuk u krye !");
                    return;
                }
                                            
                    conn.Open();
                if (gjeneralitete_check(emri, mbiemri, atesia, cikli) == "ska")
                {
                    cmd.ExecuteNonQuery();
                    cmd1.ExecuteNonQuery();
                }
                else
                {
                    cmd2.ExecuteNonQuery();
                    cmd3.ExecuteNonQuery();
                    msbox("Nxenesit nuk ju ndryshua numri i amzes pasi eshte larguar !" + "\\n" + "Nxenesi u transferua ne klasen e kerkuar !");
                }

                    conn.Close();
                    bind(klasaddl.SelectedItem.Text,indeksiddl.SelectedItem.Text, Convert.ToInt64(Session["shkolla"].ToString()),vitiddl.SelectedItem.ToString());
               

            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            long id = Convert.ToInt64(GridView1.DataKeys[e.RowIndex].Value);
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = conn_str;
            SqlCommand cmd3 = new SqlCommand();
            cmd3.CommandText = "UPDATE TBL_AMZA SET AMZA_LARGUAR = " + "'" + "True" + "'," + "AMZA_VREJTJE = " + "'" + "Larguar " + DateTime.Now.ToShortDateString() + "'" + " WHERE AMZA_NR_AMZA = " + "'" + id.ToString() + "'";
            cmd3.Connection = conn;
            conn.Open();
            cmd3.ExecuteNonQuery();
            conn.Close();
            e.Cancel = true;
            GridView1.EditIndex = -1;
            bind(klasaddl.SelectedItem.Text, indeksiddl.SelectedItem.Text, Convert.ToInt64(Session["shkolla"].ToString()), vitiddl.SelectedItem.ToString());
            msbox("Nxenesi i zgjedhur u largua nga shkolla !");
            
            ////aktivizon ddl 
            vitiddl.Enabled = true;
            klasaddl.Enabled = true;
            indeksiddl.Enabled = true;

        }

        protected void vitiddl_SelectedIndexChanged(object sender, EventArgs e)
        {
            bind(klasaddl.SelectedItem.Text, indeksiddl.SelectedItem.Text, Convert.ToInt64(Session["shkolla"].ToString()), vitiddl.SelectedItem.ToString());
        }

        protected void indeksiddl_SelectedIndexChanged(object sender, EventArgs e)
        {
            bind(klasaddl.SelectedItem.Text, indeksiddl.SelectedItem.Text, Convert.ToInt64(Session["shkolla"].ToString()), vitiddl.SelectedItem.ToString());
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            //
        }
        protected void ImageButton7_Click(object sender, ImageClickEventArgs e)
        {
            //******
            GridView1.FooterRow.Visible = false;
          
            for (int i = 0; i <= GridView1.Rows.Count - 1; i++)
            {
                GridView1.Rows[i].Cells[12].Visible = false;
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
            sb.Append("SHKOLLA : "+Session["emri"].ToString()+ "<br><br>");
            sb.Append("TE DHENAT E AMZES <br><br>");
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
            for (int i = 0; i <=GridView1.Rows.Count - 1; i++)
            {
                GridView1.Rows[i].Cells[12].Visible = true;
            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            bind(klasaddl.SelectedItem.Text, indeksiddl.SelectedItem.Text, Convert.ToInt64(Session["shkolla"].ToString()), vitiddl.SelectedItem.ToString());
        }

        //protected void ImageButton6_Click(object sender, ImageClickEventArgs e)
        //{
        //    SqlConnection conn = new SqlConnection();
        //    conn.ConnectionString = conn_str;
        //    SqlCommand cmd = new SqlCommand();
        //    cmd.Connection = conn;
        //    cmd.CommandText = "SELECT * FROM TBL_AMZA WHERE AMZA_NR_AMZA = '" + TextBox14.Text + "' AND AMZA_CIKLI = '" + cikli + "' AND AMZA_ID_SHKOLLA = " + Convert.ToInt64(Session["shkolla"].ToString());
        //    conn.Open();
        //    DataTable dt = new DataTable();
        //    SqlDataAdapter da = new SqlDataAdapter(cmd);
        //    da.Fill(dt);
        //    conn.Close();
        //    GridView1.DataSource = dt;
        //    GridView1.DataBind();


        //        }

        //protected void TextBox14_TextChanged(object sender, EventArgs e)
        //{

        //}

        //protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (RadioButtonList1.SelectedIndex == 0)
        //        cikli = true;
        //    if (RadioButtonList1.SelectedIndex == 1)
        //        cikli = false;
        //}


    }
}