using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.IO;

namespace WebApplication2
{

    public partial class Konsulto_nota_nxenesi : System.Web.UI.Page

    {
        public bool cikli = true;

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
            Image1.ImageUrl = "~/Handler1.ashx?Id=" + Session["shkolla"].ToString();
            if (Session["shkolla"] == null)

            {
                Server.Transfer("~/login.aspx");
            }

            if (!Page.IsPostBack)
            {
                if (Convert.ToInt16(klasaddl_v.SelectedItem.Text) <= 9)
                {
                    cikli = true;
                }

                else
                {
                    cikli = false;
                }

                //bind koeficentet
                vitiddl_v.SelectedValue = gjej_vitin();
                DataTable dt = new DataTable();
                dt.Columns.Add("k1", typeof(string));
                dt.Columns.Add("k2", typeof(string));
                dt.Columns.Add("k3", typeof(string));
                DataRow dr = dt.NewRow();
                dt.Rows.InsertAt(dr, 0);
                dt.Rows[0][0] = 0.4.ToString();
                dt.Rows[0][1] = 0.2.ToString();
                dt.Rows[0][2] = 0.4.ToString();
                GridView4.DataSource = dt;
                GridView4.DataBind();

                bind_nxenesit();

                bind2();

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
        void bind2()
        {

            if (Convert.ToInt16(klasaddl_v.SelectedItem.Text) <= 9)
            {
                cikli = true;
            }

            else
            {
                cikli = false;
            }

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = conn_str;
            DataSet ds = new DataSet();
            DataTable dt_lendet = new DataTable();//datatable per lendet
            DataTable temp = new DataTable();//datatable per te vendosur te dhenat e combinuara
            DataTable dt_vleresime = new DataTable();//datatable per vleresimet e nxenesit ne nje lende te caktuar
            SqlCommand cmd_lendet = new SqlCommand();
            cmd_lendet.CommandText = "SELECT LN_EMRI FROM TBL_LENDA WHERE LN_KLASA" + klasaddl_v.SelectedItem.Text + " = " + "'" + "True" + "'" + " and LN_ID_SHKOLLA = " + Convert.ToInt64(Session["shkolla"].ToString()) + " and LN_VITI_SHKOLLOR = '" + vitiddl_v.SelectedItem.Text + "' ORDER BY LN_EMRI";
            cmd_lendet.Connection = conn;
            SqlDataAdapter da = new SqlDataAdapter(cmd_lendet);
            da.SelectCommand = cmd_lendet;
            conn.Open();
            da.Fill(ds);
            dt_lendet = ds.Tables[0];
            int row_nr = 0;
            int col_nr = 0;

            if (DropDownList1.Items.Count != 0)
            {
                temp.Columns.Add("Lendet", typeof(string));//shton kolone te temp

                SqlCommand cmd_nr_col = new SqlCommand();
                cmd_nr_col.Connection = conn;
                cmd_nr_col.CommandText = "SELECT MAX(A.NR_NOTASH) AS MAKSI FROM(SELECT  COUNT(NT_VLERESIMI) AS NR_NOTASH FROM TBL_NOTA WHERE NT_NR_AMZA = '" + DropDownList1.SelectedItem.Value + "' AND NT_CIKLI = '" + cikli + "' AND NT_VITI_SHKOLLOR = '" + vitiddl_v.SelectedItem.Text + "' and NT_ID_SHKOLLA = " + Convert.ToInt64(Session["shkolla".ToString()]) + " GROUP BY NT_EMRI_LENDA) as A";
                if (cmd_nr_col.ExecuteScalar().ToString() == "")
                {
                    GridView1.DataBind();
                    conn.Close();
                    return;
                    
                }
                string p = cmd_nr_col.ExecuteScalar().ToString();
                int nr_kolonash = Convert.ToInt32(cmd_nr_col.ExecuteScalar().ToString());
                for (int i = 0; i < nr_kolonash; i++) //krijon kolonat te temp
                {
                    temp.Columns.Add(i.ToString(), typeof(string));//shton kolonat te temp

                }

                foreach (DataRow dr in dt_lendet.Rows)
                {

                    string lenda = dr["LN_EMRI"].ToString();


                    DataRow data_row = temp.NewRow();
                    temp.Rows.InsertAt(data_row, row_nr);//shto rresht te temp

                    temp.Rows[row_nr][0] = lenda;//vendos lenden ne rreshtin dhe kolonen perkatese

                    DataTable temp_vleresimet = new DataTable();

                    SqlCommand cmd_notat = new SqlCommand();
                    cmd_notat.CommandText = "select NT_VLERESIMI from TBL_NOTA where NT_NR_AMZA = '" + DropDownList1.SelectedItem.Value + "' and NT_CIKLI = '" + cikli + "' and NT_EMRI_LENDA = '" + lenda + "' and NT_VITI_SHKOLLOR = '" + vitiddl_v.SelectedItem.Text + "' and NT_ID_SHKOLLA = " + Convert.ToInt64(Session["shkolla"].ToString());
                    SqlDataAdapter da_temp_vlersimet = new SqlDataAdapter(cmd_notat);
                    cmd_notat.Connection = conn;
                    da_temp_vlersimet.Fill(temp_vleresimet);
                    col_nr = 0;
                    int row_vleresimet = 1;
                    foreach (DataRow dt_row in temp_vleresimet.Rows)
                    {
                        //shto kolone te re te datatable temp
                        col_nr = col_nr + 1;
                        temp.Rows[row_nr][col_nr] = temp_vleresimet.Rows[row_vleresimet - 1][0];
                        row_vleresimet++;
                    }
                    row_nr++;
                }
                temp.Columns.Add("Mesatare", typeof(string));//shton kolone te temp
                temp.Columns.Add("Mes_round", typeof(string));//shton kolone per noten vjetore

            }

            GridView1.DataSource = temp;
            GridView1.DataBind();
            conn.Close();
        }

        void bind3()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = conn_str;
            DataSet ds = new DataSet();
            DataTable dt_lendet = new DataTable();//datatable per lendet
            DataTable temp = new DataTable();//datatable per te vendosur te dhenat e combinuara
            DataTable dt_vleresime = new DataTable();//datatable per vleresimet e nxenesit ne nje lende te caktuar
            SqlCommand cmd_lendet = new SqlCommand();
            cmd_lendet.CommandText = "SELECT LN_EMRI FROM TBL_LENDA WHERE LN_KLASA" + klasaddl_v.SelectedItem.Text + " = " + "'" + "True" + "'" + " and LN_ID_SHKOLLA = " + Convert.ToInt64(Session["shkolla"].ToString()) + " and LN_VITI_SHKOLLOR = '" + vitiddl_v.SelectedItem.Text + "' ORDER BY LN_EMRI"; ;
            cmd_lendet.Connection = conn;
            SqlDataAdapter da = new SqlDataAdapter(cmd_lendet);
            da.SelectCommand = cmd_lendet;
            conn.Open();
            da.Fill(ds);
            dt_lendet = ds.Tables[0];
            int row_nr = 0;
            int col_nr = 0;
            int nr_kolonash = 0;
            double m_t = 0;
            if (DropDownList1.Items.Count != 0)
            {
                temp.Columns.Add("Lendet", typeof(string));//shton kolone te temp

                SqlCommand cmd_nr_col = new SqlCommand();
                cmd_nr_col.Connection = conn;
                cmd_nr_col.CommandText = "SELECT MAX(A.NR_NOTASH) AS MAKSI FROM(SELECT  COUNT(NT_VLERESIMI) AS NR_NOTASH FROM TBL_NOTA WHERE NT_NR_AMZA = '" + DropDownList1.SelectedItem.Value + "' AND NT_CIKLI = '" + cikli + "' AND NT_VITI_SHKOLLOR = '" + vitiddl_v.SelectedItem.Text + "' and NT_ID_SHKOLLA = " + Convert.ToInt64(Session["shkolla".ToString()]) + " GROUP BY NT_EMRI_LENDA) as A";
                if (cmd_nr_col.ExecuteScalar().ToString() == "")
                {
                    GridView2.DataBind();
                    conn.Close();
                    return;
                }
                string p = cmd_nr_col.ExecuteScalar().ToString();
                nr_kolonash = Convert.ToInt32(cmd_nr_col.ExecuteScalar().ToString());
                for (int i = 0; i < nr_kolonash * 4; i++) //krijon kolonat te temp
                {
                    temp.Columns.Add(i.ToString(), typeof(string));//shton kolonat te temp

                }

                foreach (DataRow dr in dt_lendet.Rows)
                {

                    string lenda = dr["LN_EMRI"].ToString();


                    DataRow data_row = temp.NewRow();
                    temp.Rows.InsertAt(data_row, row_nr);//shto rresht te temp

                    temp.Rows[row_nr][0] = lenda;//vendos lenden ne rreshtin dhe kolonen perkatese

                    DataTable temp_vleresimet = new DataTable();

                    SqlCommand cmd_notat = new SqlCommand();
                    cmd_notat.CommandText = "select NT_DATA,NT_MOMENTALE,NT_PROJEKT,NT_DETYREKONTROLLI from TBL_NOTA where NT_NR_AMZA = '" + DropDownList1.SelectedItem.Value + "' and NT_CIKLI = '" + cikli + "' and NT_EMRI_LENDA = '" + lenda + "' and NT_VITI_SHKOLLOR = '" + vitiddl_v.SelectedItem.Text + "' and NT_ID_SHKOLLA = " + Convert.ToInt64(Session["shkolla"].ToString());
                    SqlDataAdapter da_temp_vlersimet = new SqlDataAdapter(cmd_notat);
                    cmd_notat.Connection = conn;
                    da_temp_vlersimet.Fill(temp_vleresimet);
                    col_nr = 0;
                    int row_vleresimet = 1;
                    foreach (DataRow dt_row in temp_vleresimet.Rows)
                    {
                        //shto kolone te re te datatable temp
                        col_nr = col_nr + 1;
                        temp.Rows[row_nr][col_nr] = temp_vleresimet.Rows[row_vleresimet - 1][0];
                        col_nr = col_nr + 1;
                        temp.Rows[row_nr][col_nr] = temp_vleresimet.Rows[row_vleresimet - 1][1];
                        col_nr = col_nr + 1;
                        temp.Rows[row_nr][col_nr] = temp_vleresimet.Rows[row_vleresimet - 1][2];
                        col_nr = col_nr + 1;
                        temp.Rows[row_nr][col_nr] = temp_vleresimet.Rows[row_vleresimet - 1][3];
                        //col_nr = col_nr + 1;
                        ////temp.Rows[row_nr][col_nr] = temp_vleresimet.Rows[row_vleresimet - 1][4];
                        row_vleresimet++;
                    }
                    row_nr++;
                }
            }

            GridView2.DataSource = temp;
            GridView2.DataBind();
            int row = -1;
            int col = 0;

            foreach (GridViewRow r in GridView1.Rows)
            {
                int col2 = 1;
                row = row + 1;
                GridView1.Rows[row].Cells[1].ToolTip = GridView2.Rows[row].Cells[1].Text;// nota ne kolonen e pare
                //nqs eshte detyre kontrolli bold
                if (GridView2.Rows[row].Cells[col2 + 3].Text == "True")
                    GridView1.Rows[row].Cells[1].Attributes.CssStyle["font-weight"] = "bold";
                //nqs eshte projekt underline
                if (GridView2.Rows[row].Cells[col2 + 2].Text == "True")
                    GridView1.Rows[row].Cells[col].Attributes.CssStyle["text-decoration"] = "underline";
                for (col = 2; col <= nr_kolonash; col++)

                {
                    col2 = col2 + 4;
                    GridView1.Rows[row].Cells[col].ToolTip = GridView2.Rows[row].Cells[col2].Text;
                    //nqs eshte detyre kotrolli bold
                    if (GridView2.Rows[row].Cells[col2 + 3].Text == "True")
                        GridView1.Rows[row].Cells[col].Attributes.CssStyle["font-weight"] = "bold";
                    //nqs eshte projekt underline
                    if (GridView2.Rows[row].Cells[col2 + 2].Text == "True")
                        GridView1.Rows[row].Cells[col].Attributes.CssStyle["text-decoration"] = "underline";

                }
            }


            double m1 = 0;
            double m2 = 0;
            double m3 = 0;
            double s1 = 0;
            double s2 = 0;
            double s3 = 0;
            int i1 = 0;
            int i2 = 0;
            int i3 = 0;
            int rreshti = 0;
            double mes_tot = 0;
            int tot_count = 0;
            double m_t_p = 0;
            double kr_koef = 0;
            double mes_round = 0;
            foreach (GridViewRow r in GridView1.Rows)
            {
                m1 = 0; m2 = 0; m3 = 0; s1 = 0; s2 = 0; s3 = 0; i1 = 0; i2 = 0; i3 = 0; mes_tot = 0;

                for (int j = 1; j <= nr_kolonash; j++)

                {
                    if (!(GridView1.Rows[rreshti].Cells[j].Text == "&nbsp;"))
                    {
                        if (GridView1.Rows[rreshti].Cells[j].Attributes.CssStyle["font-weight"] == "bold")
                        {
                            s1 = Convert.ToInt16(GridView1.Rows[rreshti].Cells[j].Text) + s1;
                            i1++;


                        }
                        if (GridView1.Rows[rreshti].Cells[j].Attributes.CssStyle["text-decoration"] == "underline")
                        {
                            s2 = Convert.ToInt16(GridView1.Rows[rreshti].Cells[j].Text) + s2;
                            i2++;


                        }
                        if (!(GridView1.Rows[rreshti].Cells[j].Attributes.CssStyle["text-decoration"] == "underline") && !(GridView1.Rows[rreshti].Cells[j].Attributes.CssStyle["font-weight"] == "bold") && !(GridView1.Rows[rreshti].Cells[j].Text == "m"))
                        {
                            s3 = Convert.ToInt16(GridView1.Rows[rreshti].Cells[j].Text) + s3;
                            i3++;


                        }

                    }
                }
                bind4();
                m1 = s1 / i1; m2 = s2 / i2; m3 = s3 / i3;
                if (i1 != 0 && i2 != 0 && i3 != 0)
                {


                    double d1 = (Convert.ToDouble(Convert.ToString(((Label)GridView4.Rows[0].FindControl("Label5")).Text)));//shkrim
                    double d2 = (Convert.ToDouble(Convert.ToString(((Label)GridView4.Rows[0].FindControl("Label3")).Text)));//portofol
                    double d3 = (Convert.ToDouble(Convert.ToString(((Label)GridView4.Rows[0].FindControl("Label4")).Text)));//normale
                    mes_tot = (mes_tot + (d1 * m1 + d2 * m2 + d3 * m3));
                    GridView1.Rows[rreshti].Cells[nr_kolonash + 1].Text = mes_tot.ToString("0.00");
                    GridView1.Rows[rreshti].Cells[nr_kolonash + 2].Text = Math.Round(mes_tot).ToString();//nota vjetore
                   
                    m_t = mes_tot * Convert.ToDouble(GridView3.Rows[rreshti].Cells[1].Text) * Convert.ToDouble(GridView3.Rows[rreshti].Cells[0].Text);
                    kr_koef = Convert.ToDouble(GridView3.Rows[rreshti].Cells[1].Text) * Convert.ToDouble(GridView3.Rows[rreshti].Cells[0].Text) + kr_koef;
                    tot_count++;
                    m_t_p = m_t + m_t_p;
                    mes_round = Math.Round( mes_tot) + mes_round;

                }
                else
                    GridView1.Rows[rreshti].Cells[nr_kolonash + 1].ToolTip = "Mesatarja nuk shfaqet sepse nuk jane marre te gjitha llojet e notave";
                rreshti++;
            }

            Label2.Text = "Mesatarja e pergjitheshme : " + (m_t_p / kr_koef).ToString("0.00");
            Label6.Text = "Mesatarja perfundimtare : " + (mes_round/tot_count).ToString("0.00");
            conn.Close();
        }
        void bind4()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = conn_str;
            DataSet ds = new DataSet();
            DataTable dt_lendet = new DataTable();//datatable per lendet
            DataTable temp = new DataTable();//datatable per te vendosur te dhenat e combinuara
            DataTable dt_vleresime = new DataTable();//datatable per vleresimet e nxenesit ne nje lende te caktuar
            SqlCommand cmd_lendet = new SqlCommand();
            cmd_lendet.CommandText = "SELECT LN_KREDITE,LN_KOEFICENTI FROM TBL_LENDA WHERE LN_KLASA" + klasaddl_v.SelectedItem.Text + " = " + "'" + "True" + "'" + " and LN_ID_SHKOLLA = " + Convert.ToInt64(Session["shkolla"].ToString()) + " and LN_VITI_SHKOLLOR = '" + vitiddl_v.SelectedItem.Text + "' ORDER BY LN_EMRI"; 
            cmd_lendet.Connection = conn;
            SqlDataAdapter da = new SqlDataAdapter(cmd_lendet);
            da.SelectCommand = cmd_lendet;
            conn.Open();
            da.Fill(ds);
            GridView3.DataSource = ds;
            GridView3.DataBind();
            conn.Close();
        }
        void bind_nxenesit()
        {
            if (Convert.ToInt16(klasaddl_v.SelectedItem.Text) <= 9)
            {
                cikli = true;
            }

            else
            {
                cikli = false;
            }

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = conn_str;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select KL_NR_AMZA as Amza ,AMZA_EMRI +' '+ AMZA_MBIEMRI as Emri from TBL_KLASA,TBL_AMZA where KL_KLASA = '" + klasaddl_v.SelectedItem.Text + "' and KL_INDEKSI = '" + indeksiddl_v.SelectedItem.Text + "' and KL_ID_SHKOLLA = " + Convert.ToInt64(Session["shkolla"].ToString()) + " and KL_VITI_SHKOLLOR = '" + vitiddl_v.SelectedItem.Text + "' and  AMZA_LARGUAR = '" + false + "' and KL_NR_AMZA = AMZA_NR_AMZA" + " and AMZA_CIKLI = '" + cikli + "' and AMZA_ID_SHKOLLA = " + Convert.ToInt64(Session["shkolla"].ToString()) + " ORDER BY Emri";
            //cmd.CommandText = "select AMZA_NR_AMZA, AMZA_EMRI + ' ' + AMZA_MBIEMRI as Emri from TBL_AMZA where" + " AMZA_KLASA = '" + klasaddl_v.SelectedItem.Text + "' and AMZA_INDEKSI = '" + indeksiddl_v.SelectedItem.Text + "' and AMZA_VITI_SHKOLLOR = '" + vitiddl_v.SelectedItem.Text + "' and AMZA_ID_SHKOLLA = " + Convert.ToInt64(Session["shkolla"].ToString());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            conn.Open();
            da.Fill(ds);
            DropDownList1.DataSource = ds;

            DropDownList1.DataTextField = "Emri";
            DropDownList1.DataValueField = "Amza";
            DropDownList1.DataBind();
            conn.Close();



        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            int count = 0;
            double mes = 0;
            int j = 0;
            foreach (GridViewRow roww in GridView1.Rows)
            {
                foreach (TableCell cell in roww.Cells)
                {
                    cell.Attributes.CssStyle["text-align"] = "center";
                }


            }







        }

        protected void vitiddl_v_SelectedIndexChanged(object sender, EventArgs e)
        {
            bind_nxenesit();

            bind2();
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

            bind_nxenesit();
            bind2();
        }

        protected void indeksiddl_v_SelectedIndexChanged(object sender, EventArgs e)
        {
            bind_nxenesit();
            bind2();
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
          
            bind2();
        }

        protected void GridView1_DataBound(object sender, EventArgs e)
        {
            bind3();
            if (GridView1.Rows.Count > 1)
            {

                //int row = 0;
                //int col = 0;
                //foreach(GridViewRow r in GridView2.Rows())



                GridView1.Rows[0].Cells[0].ToolTip = "Prova";


            }
        }

        protected void GridView4_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

            DataTable dt = new DataTable();
            dt.Columns.Add("k1", typeof(string));
            dt.Columns.Add("k2", typeof(string));
            dt.Columns.Add("k3", typeof(string));
            DataRow dr = dt.NewRow();
            dt.Rows.InsertAt(dr, 0);
            string k1 = Convert.ToString(((TextBox)GridView4.Rows[e.RowIndex].FindControl("TextBox1")).Text);
            string k2 = Convert.ToString(((TextBox)GridView4.Rows[e.RowIndex].FindControl("TextBox2")).Text);
            string k3 = Convert.ToString(((TextBox)GridView4.Rows[e.RowIndex].FindControl("TextBox3")).Text);
            double k4, k5, k6;
            double shuma;
            if (double.TryParse(k1, out k4) && double.TryParse(k2, out k5) && double.TryParse(k3, out k6))
            {
                shuma = Convert.ToDouble(k1) + Convert.ToDouble(k2) + Convert.ToDouble(k3);
                if (shuma == 1.0)
                {
                    dt.Rows[0][0] = k1;
                    dt.Rows[0][1] = k2;
                    dt.Rows[0][2] = k3;
                    GridView4.EditIndex = -1;

                    GridView4.DataSource = dt;

                    GridView4.DataBind();
                    bind2();

                }
                else
                {
                    msbox("Shuma e koeficenteve duhet te jete 1 !");

                }
            }
            else
            {
                msbox("Koeficentet duhet te jene numra !");

            }

        }

        protected void GridView4_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            e.Cancel = true;
            GridView4.EditIndex = -1;
            DataTable dt = new DataTable();
            dt.Columns.Add("k1", typeof(string));
            dt.Columns.Add("k2", typeof(string));
            dt.Columns.Add("k3", typeof(string));
            DataRow dr = dt.NewRow();
            dt.Rows.InsertAt(dr, 0);
            dt.Rows[0][0] = 0.4.ToString();
            dt.Rows[0][1] = 0.2.ToString();
            dt.Rows[0][2] = 0.4.ToString();
            GridView4.DataSource = dt;
            GridView4.DataBind();
        }

        protected void GridView4_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView4.EditIndex = e.NewEditIndex;
            DataTable dt = new DataTable();
            dt.Columns.Add("k1", typeof(string));
            dt.Columns.Add("k2", typeof(string));
            dt.Columns.Add("k3", typeof(string));
            DataRow dr = dt.NewRow();
            dt.Rows.InsertAt(dr, 0);
            dt.Rows[0][0] = 0.4.ToString();
            dt.Rows[0][1] = 0.2.ToString();
            dt.Rows[0][2] = 0.4.ToString();
            GridView4.DataSource = dt;
            GridView4.DataBind();
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            //
        }
        protected void ImageButton7_Click(object sender, ImageClickEventArgs e)
        {



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
            sb.Append("NOTAT E NXENESIT <br><br>");
            sb.Append("Viti shkollor : ");
            sb.Append(vitiddl_v.SelectedItem.Text);

            sb.Append("    KLASA : ");
            sb.Append(klasaddl_v.SelectedItem.Text);
            sb.Append(indeksiddl_v.SelectedItem.Text);
            sb.Append("<br><br>");
            sb.Append(DropDownList1.SelectedItem.Text);
            sb.Append(gridHTML);
            sb.Append("<br><br>");
            sb.Append(Label2.Text);
            sb.Append("<br>");
            sb.Append(Label6.Text);
            sb.Append("\");");

            sb.Append("printWin.document.close();");

            sb.Append("printWin.focus();");

            sb.Append("printWin.print();");

            sb.Append("printWin.close();};");

            sb.Append("</script>");

            ClientScript.RegisterStartupScript(this.GetType(), "GridPrint", sb.ToString());

            GridView1.PagerSettings.Visible = true;

            GridView1.GridLines = GridLines.None;

        }
    }
}