using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;
using Microsoft.Azure.NotificationHubs;

namespace WebApplication2
{
    public partial class Hidh_notat : System.Web.UI.Page
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

            if (Convert.ToInt16(klasaddl.SelectedItem.Text) <= 9)
            {
                cikli = true;
            }

            else
            {
                cikli = false;
            }

            if (!Page.IsPostBack)
            {
                vitiddl.SelectedValue = gjej_vitin();
                bind_lendet();
                bind_nxenesit();
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

        void bind_lendet()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = conn_str;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            conn.Open();
            cmd.CommandText = "select LN_EMRI from TBL_LENDA where LN_KLASA" + klasaddl.SelectedItem.Text + " = 'True' and LN_VITI_SHKOLLOR = '" + vitiddl.SelectedItem.Text +"' and LN_ID_SHKOLLA = "+ Convert.ToInt64(Session["shkolla"].ToString()) + " ORDER BY LN_EMRI";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            lendaddl.DataSource = ds;
            lendaddl.DataTextField = "LN_EMRI";
            lendaddl.DataValueField = "LN_EMRI";
            lendaddl.DataBind();
         
            conn.Close();
            bind_mesuesit();
        }

        void  bind_mesuesit()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = conn_str;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            conn.Open();
            if (lendaddl.Items.Count > 0)
            {
                cmd.CommandText = "select ID_MESUESI, MS_EMRI +' '+ MS_MBIEMRI as Emri_mes from TBL_MESUESI_KLASA, TBL_MESUESI where MS_ID_MESUESI = ID_MESUESI and  KLASA = '" + klasaddl.SelectedItem.Text + "' and VITI_SHKOLLOR = '" + vitiddl.SelectedItem.Text +"' and INDEKSI = '"+ indeksiddl.SelectedItem.Text+"' and ID_SHKOLLA = " + Convert.ToInt64(Session["shkolla"].ToString()) + "and EMRI_LENDA = '" + lendaddl.SelectedItem.Text + "'";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                mesuesiddl.DataSource = ds;
                mesuesiddl.DataTextField = "Emri_mes";
                mesuesiddl.DataValueField = "ID_MESUESI";
                mesuesiddl.DataBind();
            }
                conn.Close();

        }

        void bind_nxenesit()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = conn_str;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            DataSet ds = new DataSet();

            conn.Open();
            cmd.CommandText = "select KL_NR_AMZA,AMZA_EMRI + ' ' + AMZA_MBIEMRI as Emri from TBL_KLASA, TBL_AMZA where(KL_NR_AMZA = AMZA_NR_AMZA) and KL_KLASA = '" + klasaddl.SelectedItem.Text + "' and KL_INDEKSI = '" + indeksiddl.SelectedItem.Text + "' and KL_ID_SHKOLLA =" + Convert.ToInt64(Session["shkolla"].ToString()) + " and KL_VITI_SHKOLLOR = '" + vitiddl.SelectedItem.Text + "'" + " and AMZA_LARGUAR = '" +"False" + "' and (AMZA_VITI_LARGIMIT is null OR AMZA_VITI_LARGIMIT != '" + vitiddl.SelectedItem.Text + "')" + " and AMZA_CIKLI = '" + cikli + "' and AMZA_ID_SHKOLLA = " + Convert.ToInt64(Session["shkolla"].ToString()) + " ORDER BY Emri";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            Repeater1.DataSource = ds;
            Repeater1.DataBind();
            conn.Close();

        }
        protected void vitiddl_SelectedIndexChanged(object sender, EventArgs e)
        {
            bind_lendet();
            bind_nxenesit();
            bind_mesuesit();
        }

        protected void klasaddl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt16(klasaddl.SelectedItem.Text) <= 9)
            {
                cikli = true;
            }

            else
            {
                cikli = false;
            }
            bind_lendet();
            bind_nxenesit();
            bind_mesuesit();
        }

        protected void indeksiddl_SelectedIndexChanged(object sender, EventArgs e)
        {
            bind_nxenesit();
           // bind_mesuesit();
        }

        protected void lendaddl_SelectedIndexChanged(object sender, EventArgs e)
        {
            bind_mesuesit();
        }
        bool verifiko_notat()
        {
            int i = 0;
            List<string> notat_sakta = new List<string> { "4", "5", "6", "7", "8", "9", "10", "" };
            foreach (RepeaterItem rep in Repeater1.Items)
            {
                TextBox txt_s = (TextBox)rep.FindControl("txtlenda");              
                if (!notat_sakta.Contains(txt_s.Text))
                    i++;                        
            }
            if (i == 0)
                return true;
            else
                return false;
        }
        bool verifiko_mungesat()
        {
            int i = 0;
            List<string> mungesa_sakta = new List<string> {"", "m", "M" };
            foreach (RepeaterItem rep in Repeater1.Items)
            {
                TextBox txt_s = (TextBox)rep.FindControl("txtlenda");
                if (!mungesa_sakta.Contains(txt_s.Text))
                    i++;
            }
            if (i == 0)
                return true;
            else
                return false;
        }

        //protected void Button1_Click(object sender, EventArgs e)
        //{
        //    SqlConnection conn = new SqlConnection();
        //    conn.ConnectionString = conn_str;
        //    SqlCommand cmd_ins = new SqlCommand();

        //    conn.Open();
        //    if (verifiko_notat() || (verifiko_mungesat()&& RadioButtonList1.SelectedIndex==3))
        //    {
        //        foreach (RepeaterItem rep in Repeater1.Items)
        //        {
        //            Label lbl = (Label)rep.FindControl("lblAmza");
        //            string amza = lbl.Text;
        //            TextBox txt = (TextBox)rep.FindControl("txtlenda");
        //            string nota = txt.Text;
        //            long id_mes = Convert.ToInt64(Id_mesuesiLbl.Text);
        //            cmd_ins.Connection = conn;

        //            if (txt.Text != "")
        //            {
        //                cmd_ins.CommandText = "insert into TBL_NOTA (NT_ID_SHKOLLA,NT_ID_MESUESI,NT_CIKLI,NT_NR_AMZA,NT_EMRI_LENDA,NT_VITI_SHKOLLOR,NT_VLERESIMI,NT_DATA," + RadioButtonList1.SelectedItem.Value.ToString() + ",NT_KLASA,NT_INDEKSI) values (" + Convert.ToInt64(Session["shkolla"].ToString()) + "," + id_mes + ",'" + cikli + "','" + amza + "','" + lendaddl.SelectedItem.Text + "','" + vitiddl.SelectedItem.Text + "','" + nota.Trim() + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "','True','" + klasaddl.SelectedItem.Text + "','" + indeksiddl.SelectedItem.Text + "')";
        //                cmd_ins.ExecuteNonQuery();
        //            }
        //        }
        //        msbox("Notat u hodhen !");
        //        bind_nxenesit();
        //    }
        //    else
        //        msbox("Notat nuk jane ne formatin e duhur !");
        //}
        public List<string> gjej_perdoruesi(string nr_amza, string cikli, string id_shkolla)
        {
            string connectionstr = "Server = tcp:azeneli2000.database.windows.net,1433; Initial Catalog = shkolla_prova; Persist Security Info = False; User ID = andi; Password =Matrix2001; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;";  /*ConfigurationManager.ConnectionStrings["db_conn"].ConnectionString;*/
                                                                                                                                                                                                                                                                                                            //string connectionstr = ConfigurationManager.ConnectionStrings["localDb"].ConnectionString;
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connectionstr;

            try
            {

                conn.Open();
                string sqlString = "select PERD_USER,PERD_DATA_REGJISTRIMI,PERD_DITE_FALAS,PERD_DITE_PAGUAR from TBL_PERDORUESI where PERD_NR_AMZA = '" + nr_amza + "' AND PERD_CIKLI = '" + cikli + "'" + " AND PERD_ID_SHKOLLA = " + Convert.ToInt64(id_shkolla);
                SqlCommand cmd = new SqlCommand(sqlString, conn);
                SqlDataReader r = cmd.ExecuteReader();
                List<string> perd = new List<string>();
                while (r.Read())
                {
                    string s = r["PERD_USER"].ToString();
                    string data_reg = r["PERD_DATA_REGJISTRIMI"].ToString();
                    string dite_falas = r["PERD_DITE_FALAS"].ToString();
                    string dite_paguar = r["PERD_DITE_PAGUAR"].ToString();
                    perd.Add(s);
                    perd.Add(data_reg);
                    perd.Add(dite_falas);
                    perd.Add(dite_paguar);

                }
                return perd;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            List<string> perdoruesi = new List<string>();
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = conn_str;
            SqlCommand cmd_ins = new SqlCommand();

            conn.Open();
            if (verifiko_notat() || (verifiko_mungesat() && RadioButtonList1.SelectedIndex == 3))
            {
                foreach (RepeaterItem rep in Repeater1.Items)
                {
                    Label lbl = (Label)rep.FindControl("lblAmza");
                    string amza = lbl.Text;
                    TextBox txt = (TextBox)rep.FindControl("txtlenda");
                    string nota = txt.Text;
                    Label emri_n = (Label)rep.FindControl("lblEmri");
                    string em = emri_n.Text;
                    long id_mes =Convert.ToInt64( mesuesiddl.SelectedValue);
                    cmd_ins.Connection = conn;

                    if (txt.Text != "")
                    {
                        cmd_ins.CommandText = "insert into TBL_NOTA (NT_ID_SHKOLLA,NT_ID_MESUESI,NT_CIKLI,NT_NR_AMZA,NT_EMRI_LENDA,NT_VITI_SHKOLLOR,NT_VLERESIMI,NT_DATA," + RadioButtonList1.SelectedItem.Value.ToString() + ",NT_KLASA,NT_INDEKSI) values (" + Convert.ToInt64(Session["shkolla"].ToString()) + "," + id_mes + ",'" + cikli + "','" + amza + "','" + lendaddl.SelectedItem.Text + "','" + vitiddl.SelectedItem.Text + "','" + nota.Trim() + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "','True','" + klasaddl.SelectedItem.Text + "','" + indeksiddl.SelectedItem.Text + "')";
                        cmd_ins.ExecuteNonQuery();

                        //dergo notification
                       perdoruesi= gjej_perdoruesi(amza, cikli.ToString(), Session["shkolla"].ToString());
                        NotificationHubClient n = NotificationHubClient.CreateClientFromConnectionString("Endpoint=sb://infoshkollanamespace.servicebus.windows.net/;SharedAccessKeyName=DefaultFullSharedAccessSignature;SharedAccessKey=TmJj+JXfkdYUrhV8SU7z6CjDUUOpLlNxOhJmXw24ekk=", "infoshkollaandroid");
                        n.SendGcmNativeNotificationAsync("{ \"data\" : {\"message\":\"" + em+ " : "+lendaddl.SelectedItem.Text + " : " + nota.Trim()   + "\"}}", perdoruesi[0].ToString());
                    }
                }
                msbox("Notat u hodhen !");
                bind_nxenesit();
              
            }
            else
                msbox("Notat nuk jane ne formatin e duhur !");
            conn.Close();
        }
    }
}