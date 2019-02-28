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
    public partial class Evidencat : System.Web.UI.Page
    {
        public bool cikli = true;
        public DataSet klasaDataset = new DataSet();
         
      public string conn_str = "Server = tcp:azeneli2000.database.windows.net,1433; Initial Catalog = shkolla_prova; Persist Security Info = False; User ID = andi; Password =Matrix2001; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;";
        //public string conn_str = "Data Source=.\\SQLEXPRESS;Initial Catalog=shkolla_prova;Integrated Security=True";  /*ConfigurationManager.ConnectionStrings["db_conn"].ConnectionString;*/
        protected void Page_Load(object sender, EventArgs e)
        {
            //Server.Transfer("~/sfondi.aspx");
            //return;
            //mbush_dataset();
            Image1.ImageUrl = "~/Handler1.ashx?Id=" + Session["shkolla"].ToString();
            if (Session["shkolla"] == null)

            {
                Server.Transfer("~/login.aspx");
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
                vitiddl_v.SelectedValue =  gjej_vitin();
                bind();

            }
        }

        public string gjej_vitin()
        {
            if (DateTime.Now.Month >= 7)
                return (DateTime.Now.Year).ToString() + "-" + (DateTime.Now.Year + 1).ToString();
            else
                return
                 (DateTime.Now.Year - 1).ToString() + "-" + (DateTime.Now.Year).ToString();
        }

        public void mbush_dataset()
        {
            klasaDataset.Clear();
            //mbush datasetin global sa here qe ndryshon klasa
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = conn_str;
            SqlCommand cmd_klasa = new SqlCommand();
            cmd_klasa.CommandText =  "select * from TBL_NOTA where NT_KLASA = '" + klasaddl_v.SelectedItem.Text + "' and NT_INDEKSI = '" + indeksiddl_v.SelectedItem.Text + "' and NT_VITI_SHKOLLOR = '" + vitiddl_v.SelectedItem.Text + "' and NT_ID_SHKOLLA = " + Convert.ToInt64(Session["shkolla"].ToString());

            cmd_klasa.Connection = conn;
            SqlDataAdapter da = new SqlDataAdapter(cmd_klasa);
            da.SelectCommand = cmd_klasa;
            conn.Open();


            da.Fill(klasaDataset);
            conn.Close();
        }

        void bind()
        {
            mbush_dataset();
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = conn_str;
            DataSet ds = new DataSet();
            DataTable dt_lendet = new DataTable();//datatable per lendet
            DataTable temp = new DataTable();//datatable per te vendosur te dhenat e combinuara
            DataTable dt_vleresime = new DataTable();//datatable per vleresimet e nxenesit ne nje lende te caktuar
            SqlCommand cmd_lendet = new SqlCommand();
            //gjen lendet qe ben nje klase
            cmd_lendet.CommandText = "SELECT LN_EMRI FROM TBL_LENDA WHERE LN_KLASA" + klasaddl_v.SelectedItem.Text + " = " + "'" + "True" + "'" + " and LN_ID_SHKOLLA = " + Convert.ToInt64(Session["shkolla"].ToString())  + " and LN_VITI_SHKOLLOR = '" + vitiddl_v.SelectedItem.Text + "' ORDER BY LN_EMRI";
            cmd_lendet.Connection = conn;
            SqlDataAdapter da = new SqlDataAdapter(cmd_lendet);
            da.SelectCommand = cmd_lendet;
            conn.Open();


            da.Fill(ds);
            dt_lendet = ds.Tables[0];
            int row_nr = 0;
            int col_nr = 0;
            DataTable nxenesit = new DataTable();
            SqlCommand cmd_nx = new SqlCommand();
            cmd_nx.Connection = conn;
            // gjen nxenesit e nje klase 
            cmd_nx.CommandText = "select KL_NR_AMZA as Amza ,AMZA_EMRI +' '+ AMZA_MBIEMRI as Emri from TBL_KLASA,TBL_AMZA where KL_KLASA = '" + klasaddl_v.SelectedItem.Text +"' and KL_INDEKSI = '" + indeksiddl_v.SelectedItem.Text + "' and KL_ID_SHKOLLA = " + Convert.ToInt64(Session["shkolla"].ToString()) + " and KL_VITI_SHKOLLOR = '" + vitiddl_v.SelectedItem.Text + "' and  AMZA_LARGUAR = '" + false + "' and KL_NR_AMZA = AMZA_NR_AMZA" + " and AMZA_CIKLI = '" + cikli + "' and AMZA_ID_SHKOLLA = "+ Convert.ToInt64(Session["shkolla"].ToString()) + " ORDER BY Emri" ;
            SqlDataAdapter da_nx = new SqlDataAdapter(cmd_nx);
            da_nx.Fill(nxenesit);

            //shtiohen kolonat ne temp
            temp.Columns.Add("Nxenesit", typeof(string));
      



            for (int k = 0; k <= dt_lendet.Rows.Count - 1; k++)
            {
                temp.Columns.Add(dt_lendet.Rows[k][0].ToString(), typeof(string));//shton lendet  te temp per nxenesin i 
            }

            for (int i = 0; i <= nxenesit.Rows.Count - 1; i++)
            {
                DataRow r = temp.NewRow();
                temp.Rows.InsertAt(r, i);
                temp.Rows[i][0] = nxenesit.Rows[i][1].ToString();
                //fut notat e nxenensit ne te gjitha lendet
                for (int j=0;j<dt_lendet.Rows.Count;j++)
                    temp.Rows[i][j + 1] = gjej_notat_nx_lenda_LINQ(dt_lendet.Rows[j][0].ToString(), nxenesit.Rows[i][0].ToString(), klasaddl_v.SelectedItem.Text, vitiddl_v.SelectedItem.Text);
            }




            GridView1.DataSource = temp;
            GridView1.DataBind();
            conn.Close();
        }
        string gjej_notat_nx_lenda_LINQ(string lenda, string nr_amza, string klasa, string viti_shkollor)
        {
          
            DataTable dt = new DataTable();
            DataTable dt1 = new DataTable();
            SqlCommand cmd = new SqlCommand();
  
            string dtFillimi;
            string dtMbarimi;
            dt = klasaDataset.Tables[0];
           
            var res = from nx in dt.AsEnumerable()
                      where nx.Field<String>("NT_NR_AMZA") == nr_amza && nx.Field<String>("NT_EMRI_LENDA") == lenda && nx.Field<String>("NT_KLASA") == klasaddl_v.SelectedItem.Text && nx.Field<String>("NT_INDEKSI") == indeksiddl_v.SelectedItem.Text && nx.Field<String>("NT_VITI_SHKOLLOR") == viti_shkollor  && nx.Field<Int64>("NT_ID_SHKOLLA") == Convert.ToInt64(Session["shkolla"].ToString())
                      select nx;

            //SqlDataAdapter da = new SqlDataAdapter(cmd);
            //conn.Open();
            //da.Fill(dt);
            string s = "";
            //dt1 = res.CopyToDataTable();
            foreach (var r in res)
            {
                s = s + r["NT_VLERESIMI"].ToString() + " ";

            }
      
            return s;


        }
        string  gjej_notat_nx_lenda(string lenda, string nr_amza,string klasa,string viti_shkollor)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = conn_str;
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select NT_VLERESIMI from TBL_NOTA where NT_NR_AMZA = '"+ nr_amza+ "' and NT_EMRI_LENDA = '" + lenda + "' and NT_KLASA = '" + klasaddl_v.SelectedItem.Text + "' and NT_INDEKSI = '"+ indeksiddl_v.SelectedItem.Text + "' and NT_VITI_SHKOLLOR = '" + viti_shkollor + "' and NT_ID_SHKOLLA = " + Convert.ToInt64(Session["shkolla"].ToString()) ;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            conn.Open();
            da.Fill(dt);
            string s = "";
            foreach (DataRow r in dt.Rows)
            {
                s = s + r["NT_VLERESIMI"].ToString() + " " ;

            }
            conn.Close();
            return s;

        }


        void bind1()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = conn_str;
            DataSet ds = new DataSet();
            DataTable dt_lendet = new DataTable();//datatable per lendet
            DataTable temp = new DataTable();//datatable per te vendosur te dhenat e combinuara
            DataTable dt_vleresime = new DataTable();//datatable per vleresimet e nxenesit ne nje lende te caktuar
            SqlCommand cmd_lendet = new SqlCommand();
            //gjen lendet qe ben nje klase
            cmd_lendet.CommandText = "SELECT LN_EMRI FROM TBL_LENDA WHERE LN_KLASA" + klasaddl_v.SelectedItem.Text + " = " + "'" + "True" + "'" + " and LN_ID_SHKOLLA = " + Convert.ToInt64(Session["shkolla"].ToString()) + " and LN_VITI_SHKOLLOR = '" + vitiddl_v.SelectedItem.Text + "' ORDER BY LN_EMRI";
            cmd_lendet.Connection = conn;
            SqlDataAdapter da = new SqlDataAdapter(cmd_lendet);
            da.SelectCommand = cmd_lendet;
            conn.Open();


            da.Fill(ds);
            dt_lendet = ds.Tables[0];
            int row_nr = 0;
            int col_nr = 0;
            DataTable nxenesit = new DataTable();
            SqlCommand cmd_nx = new SqlCommand();
            cmd_nx.Connection = conn;
            // gjen nxenesit e nje klase 
            cmd_nx.CommandText = "select KL_NR_AMZA as Amza ,AMZA_EMRI +' '+ AMZA_MBIEMRI as Emri from TBL_KLASA,TBL_AMZA where KL_KLASA = '" + klasaddl_v.SelectedItem.Text + "' and KL_INDEKSI = '" + indeksiddl_v.SelectedItem.Text + "' and KL_ID_SHKOLLA = " + Convert.ToInt64(Session["shkolla"].ToString()) + " and KL_VITI_SHKOLLOR = '" + vitiddl_v.SelectedItem.Text + "' and  AMZA_LARGUAR = '" + false + "' and KL_NR_AMZA = AMZA_NR_AMZA" + " and AMZA_CIKLI = '" + cikli + "' and AMZA_ID_SHKOLLA = " + Convert.ToInt64(Session["shkolla"].ToString()) + " ORDER BY Emri";
            SqlDataAdapter da_nx = new SqlDataAdapter(cmd_nx);
            da_nx.Fill(nxenesit);

            //shtiohen kolonat ne temp
            temp.Columns.Add("Nxenesit", typeof(string));




            for (int k = 0; k <= dt_lendet.Rows.Count - 1; k++)
            {
                temp.Columns.Add(dt_lendet.Rows[k][0].ToString(), typeof(string));//shton lendet  te temp per nxenesin i 
            }

            for (int i = 0; i <= nxenesit.Rows.Count - 1; i++)
            {
                DataRow r = temp.NewRow();
                temp.Rows.InsertAt(r, i);
                temp.Rows[i][0] = nxenesit.Rows[i][1].ToString();
                //fut notat e nxenensit ne te gjitha lendet
                for (int j = 0; j < dt_lendet.Rows.Count; j++)
                    temp.Rows[i][j + 1] = gjej_notat_nx_lenda_data_LINQ(dt_lendet.Rows[j][0].ToString(), nxenesit.Rows[i][0].ToString(), klasaddl_v.SelectedItem.Text, vitiddl_v.SelectedItem.Text);
            }




            GridView1.DataSource = temp;
            GridView1.DataBind();
            conn.Close();
        }


        string gjej_notat_nx_lenda_data(string lenda, string nr_amza, string klasa, string viti_shkollor)
        {

            //IMPORTANT!!!!!!******************************
           // KY FUNKSION  DUHET TE MARRI SI PARAMETER DHE NJE DATASET NE BAZE TE KLASES DHE TE INDEKSIT KU TE JENE TE GJITHA NOTAT DHE TI BEHET QUERY ME LINQ
           //SEPSE VONON SHUIME 
           //kjo mund te behet duke mbushusr nje dataset global sa here qe nderron combo e klases ose e indeksit 
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = conn_str;
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            string   dtFillimi;
            string dtMbarimi;
            dtFillimi = DateTime.Parse(datepicker.Text).ToShortDateString();
            dtMbarimi = DateTime.Parse(datepicker0.Text).ToShortDateString();
                cmd.CommandText = "select NT_VLERESIMI from TBL_NOTA where NT_NR_AMZA = '" + nr_amza + "' and NT_EMRI_LENDA = '" + lenda + "' and NT_KLASA = '" + klasaddl_v.SelectedItem.Text + "' and NT_INDEKSI = '" + indeksiddl_v.SelectedItem.Text + "' and NT_VITI_SHKOLLOR = '" + viti_shkollor + "' and NT_DATA >= '"+ dtFillimi + "' and NT_DATA <= '" + dtMbarimi + "' and NT_ID_SHKOLLA = " + Convert.ToInt64(Session["shkolla"].ToString());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            conn.Open();
            da.Fill(dt);
            string s = "";
          
            foreach (DataRow r in dt.Rows)
            {
                s = s + r["NT_VLERESIMI"].ToString() + " ";

            }
            conn.Close();
            return s;

        }


        //*******************************

        string gjej_notat_nx_lenda_data_LINQ(string lenda, string nr_amza, string klasa, string viti_shkollor)
        {
           // mbush_dataset();
            //IMPORTANT!!!!!!******************************
            // KY FUNKSION  DUHET TE MARRI SI PARAMETER DHE NJE DATASET NE BAZE TE KLASES DHE TE INDEKSIT KU TE JENE TE GJITHA NOTAT DHE TI BEHET QUERY ME LINQ
            //SEPSE VONON SHUIME 
            //kjo mund te behet duke mbushusr nje dataset global sa here qe nderron combo e klases ose e indeksit 
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = conn_str;
            DataTable dt = new DataTable();
            DataTable dt1 = new DataTable();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            string dtFillimi;
            string dtMbarimi;
            dt = klasaDataset.Tables[0];
            dtFillimi = DateTime.Parse(datepicker.Text).ToShortDateString();
            dtMbarimi = DateTime.Parse(datepicker0.Text).ToShortDateString();
            var res = from nx in dt.AsEnumerable()
                      where nx.Field<String>("NT_NR_AMZA") ==  nr_amza && nx.Field < String >("NT_EMRI_LENDA") == lenda && nx.Field <String> ("NT_KLASA") == klasaddl_v.SelectedItem.Text && nx.Field < String > ("NT_INDEKSI") ==  indeksiddl_v.SelectedItem.Text && nx.Field<String>("NT_VITI_SHKOLLOR") ==  viti_shkollor && nx.Field<DateTime> ("NT_DATA") >= DateTime.Parse(datepicker.Text) && nx.Field <DateTime> ("NT_DATA") <= DateTime.Parse(datepicker0.Text) && nx.Field < Int64 > ("NT_ID_SHKOLLA") ==  Convert.ToInt64(Session["shkolla"].ToString())
                      select nx;

            //SqlDataAdapter da = new SqlDataAdapter(cmd);
            //conn.Open();
            //da.Fill(dt);
            string s = "";
           // dt1 = res.CopyToDataTable();
            foreach (var r in res)
            {
                s = s + r["NT_VLERESIMI"].ToString() + " ";

            }
            conn.Close();
            return s;

        }


        protected void vitiddl_v_SelectedIndexChanged(object sender, EventArgs e)
        {
            bind();
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

            mbush_dataset();

            if (datepicker.Text != "" && datepicker0.Text != "")

                bind1();
            else
                bind();
        }

        protected void indeksiddl_v_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (datepicker.Text != "" && datepicker0.Text != "")

                bind1();
            else
                bind();
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            //
        }

        protected void ImageButton7_Click(object sender, ImageClickEventArgs e)
        {

          
            GridView1.AllowPaging = false;
            bind();
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
            sb.Append("EVIDENCA <br><br>");
            sb.Append("Viti shkollor : ");
            sb.Append(vitiddl_v.SelectedItem.Text);
            sb.Append("<br><br>");
            sb.Append("Klasa : ");
            sb.Append(klasaddl_v.SelectedItem.Text);
            sb.Append(indeksiddl_v.SelectedItem.Text);
            sb.Append(gridHTML);


            sb.Append("\");");

            sb.Append("printWin.document.close();");

            sb.Append("printWin.focus();");

            sb.Append("printWin.print();");

            sb.Append("printWin.close();};");

            sb.Append("</script>");

            ClientScript.RegisterStartupScript(this.GetType(), "GridPrint", "CallPrint('Div1');"+ sb.ToString(),true);
            GridView1.AllowPaging = true;
            bind();
            // GridView1.PagerSettings.Visible = true;

            GridView1.GridLines = GridLines.None;

        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            bind();
        }

        protected void ImageButton8_Click(object sender, ImageClickEventArgs e)
        {
            mbush_dataset();
            bind1();
        }
    }
}