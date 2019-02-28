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
    public partial class Kalo_klase : System.Web.UI.Page
    {
        public bool cikli = true;

        public string conn_str = "Server = tcp:azeneli2000.database.windows.net,1433; Initial Catalog = shkolla_prova; Persist Security Info = False; User ID = andi; Password =Matrix2001; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;";
        //  public string conn_str = "Data Source=.\\SQLEXPRESS;Initial Catalog=shkolla_prova;Integrated Security=True";  /*ConfigurationManager.ConnectionStrings["db_conn"].ConnectionString;*/

        public void inicializo()
        {
            klasaddl_re.Items.Clear();
            klasaddl_re.Items.Add(klasaddl_v.SelectedItem.Text);
            klasaddl_re.Items.Add((Convert.ToInt16(klasaddl_v.SelectedItem.Text) + 1).ToString());

            vitiddl_re.Items.Clear();
            vitiddl_re.Items.Add(vitiddl_v.SelectedItem.Text);
            int i = Convert.ToInt16(vitiddl_v.SelectedItem.Text.Substring(5));
            vitiddl_re.Items.Add(i.ToString() + "-" + (i + 1).ToString());


            //kur eshte e njejta klase dhe  i njeti  indeks ne vit te njejte
            if (vitiddl_re.SelectedItem.Text == vitiddl_v.SelectedItem.Text && klasaddl_re.SelectedItem.Text == klasaddl_v.SelectedItem.Text && indeksiddl_re.SelectedItem.Text == indeksiddl_v.SelectedItem.Text)
            {
                ImageButton1.Enabled = false;
                ImageButton1.ImageUrl = "~/css/if_lock_925918(1)_50x50.png";
                ImageButton2.Enabled = false;
                ImageButton2.ImageUrl = "~/css/if_lock_925918(1)_50x50.png";
            }
            else
            {
                ImageButton1.Enabled = true;
                ImageButton1.ImageUrl = "~/css/if_next_3_926650_50x50.png";
                ImageButton2.Enabled = true;
                ImageButton2.ImageUrl = "~/css/if_check_925925_50x50.png";

            }
            //kur numri i klases eshte e ndryshme dhe viti i njejete
            if (klasaddl_re.SelectedItem.Text != klasaddl_v.SelectedItem.Text && vitiddl_re.SelectedItem.Text == vitiddl_v.SelectedItem.Text)
            {
                ImageButton1.Enabled = false;
                ImageButton1.ImageUrl = "~/css/if_lock_925918(1)_50x50.png";
                ImageButton2.Enabled = false;
                ImageButton2.ImageUrl = "~/css/if_lock_925918(1)_50x50.png";
            }

            //kur klasa eshte e njete dhe vitet e ndryshme
            if (klasaddl_re.SelectedItem.Text == klasaddl_v.SelectedItem.Text && vitiddl_re.SelectedItem.Text != vitiddl_v.SelectedItem.Text)
            {
                ImageButton1.Enabled = false;
                ImageButton1.ImageUrl = "~/css/if_lock_925918(1)_50x50.png";
                ImageButton2.Enabled = false;
                ImageButton2.ImageUrl = "~/css/if_lock_925918(1)_50x50.png";
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
                inicializo();
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
        public void bind ()
        {
            SqlConnection conn = new SqlConnection();

            DataSet ds = new DataSet();
            DataSet ds1 = new DataSet();

            SqlCommand cmd = new SqlCommand();
            SqlCommand cmd1 = new SqlCommand();
           
            DataTable dt = new DataTable();
            DataTable dt1 = new DataTable();

            conn.ConnectionString = conn_str;
            cmd.Connection = conn;
            cmd1.Connection = conn;
            string ss = Session["shkolla"].ToString();
            //string sql = "SELECT AMZA_NR_AMZA, AMZA_EMRI, AMZA_MBIEMRI FROM TBL_AMZA, TBL_KLASA WHERE(AMZA_NR_AMZA = KL_NR_AMZA AND AMZA_CIKLI = KL_CIKLI) AND(KL_KLASA = '" + klasaddl_v.SelectedItem.Text + "' AND KL_INDEKSI = '" + indeksiddl_v.SelectedItem.Text + "' AND KL_VITI_SHKOLLOR = '" + vitiddl_v.SelectedItem.Text + "') AND AMZA_LARGUAR = " + "'" + false + "'" + " AND KL_ID_SHKOLLA = " + Convert.ToInt64(Session["shkolla"].ToString()) + " ORDER BY AMZA_EMRI, AMZA_MBIEMRI";
            string sql = "SELECT AMZA_NR_AMZA, AMZA_EMRI, AMZA_MBIEMRI FROM TBL_AMZA, TBL_KLASA WHERE(AMZA_NR_AMZA = KL_NR_AMZA AND AMZA_CIKLI = KL_CIKLI) AND(KL_KLASA = '" + klasaddl_v.SelectedItem.Text + "' AND KL_INDEKSI = '" + indeksiddl_v.SelectedItem.Text + "' AND KL_VITI_SHKOLLOR = '" + vitiddl_v.SelectedItem.Text + "') AND AMZA_LARGUAR = " + "'" + false + "'"  + " and (AMZA_VITI_LARGIMIT is null OR AMZA_VITI_LARGIMIT != '" + vitiddl_v.SelectedItem.Text + "')" + " AND KL_ID_SHKOLLA = " + Convert.ToInt64(Session["shkolla"].ToString()) + " AND AMZA_ID_SHKOLLA = " + Convert.ToInt64(Session["shkolla"].ToString()) + " ORDER BY AMZA_EMRI, AMZA_MBIEMRI";
            cmd.CommandText = sql;
          
            SqlDataAdapter da = new SqlDataAdapter(cmd);
           
            conn.Open();
            da.Fill(ds);
            dt = ds.Tables[0];
            ListBox1.Items.Clear();
            ListBoxAMZA1.Items.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                ListBox1.Items.Add(dr["AMZA_EMRI"].ToString() + "  " + dr["AMZA_MBIEMRI"].ToString());
                ListBoxAMZA1.Items.Add(dr["AMZA_NR_AMZA"].ToString());
            }



            if (Convert.ToInt16(klasaddl_v.SelectedItem.Text) == 12 || Convert.ToInt16(klasaddl_v.SelectedItem.Text) == 9)
            {
                klasaddl_re.Enabled = false;
                indeksiddl_re.Enabled = false;
                vitiddl_re.Enabled = false;
                ListBox1.Enabled = false;
                return;
            }
            else
            {
               
                //vitiddl_re.SelectedIndex = vitiddl_v.SelectedIndex + 1;
            }
         

            string sql1 = "SELECT AMZA_NR_AMZA, AMZA_EMRI, AMZA_MBIEMRI FROM TBL_AMZA, TBL_KLASA WHERE(AMZA_NR_AMZA = KL_NR_AMZA AND AMZA_CIKLI = KL_CIKLI) AND(KL_KLASA = '" + klasaddl_re.SelectedItem.Text + "' AND KL_INDEKSI = '" + indeksiddl_re.SelectedItem.Text + "' AND KL_VITI_SHKOLLOR = '" + vitiddl_re.SelectedItem.Text + "') AND AMZA_LARGUAR = " + "'" + false + "'" + " and (AMZA_VITI_LARGIMIT is null OR AMZA_VITI_LARGIMIT != '" + vitiddl_v.SelectedItem.Text + "')" + " AND KL_ID_SHKOLLA = " + Convert.ToInt64(Session["shkolla"].ToString()) + " AND AMZA_ID_SHKOLLA = " + Convert.ToInt64(Session["shkolla"].ToString()) + " ORDER BY AMZA_EMRI, AMZA_MBIEMRI";
            cmd1.CommandText = sql1;
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            da1.Fill(ds1);
            dt1 = ds1.Tables[0];
            ListBox2.Items.Clear();
            ListBoxAMZA2.Items.Clear();
            foreach (DataRow dr1 in dt1.Rows)
            {
                ListBox2.Items.Add(dr1["AMZA_EMRI"].ToString() + "  " + dr1["AMZA_MBIEMRI"].ToString());
                ListBoxAMZA2.Items.Add(dr1["AMZA_NR_AMZA"].ToString());
            }

            conn.Close();
        }

        protected void vitiddl_v_SelectedIndexChanged(object sender, EventArgs e)
        {
          

            vitiddl_re.Items.Clear();
            vitiddl_re.Items.Add(vitiddl_v.SelectedItem.Text);
            int i = Convert.ToInt16(vitiddl_v.SelectedItem.Text.Substring(5));
            vitiddl_re.Items.Add(i.ToString() + "-" + (i + 1).ToString());


            //kur eshte e njejta klase dhe  i njeti  indeks ne vit te njejte
            if (vitiddl_re.SelectedItem.Text == vitiddl_v.SelectedItem.Text && klasaddl_re.SelectedItem.Text == klasaddl_v.SelectedItem.Text && indeksiddl_re.SelectedItem.Text == indeksiddl_v.SelectedItem.Text)
            {
                ImageButton1.Enabled = false;
                ImageButton1.ImageUrl = "~/css/if_lock_925918(1)_50x50.png";
                ImageButton2.Enabled = false;
                ImageButton2.ImageUrl = "~/css/if_lock_925918(1)_50x50.png";
            }
            else
            {
                ImageButton1.Enabled = true;
                ImageButton1.ImageUrl = "~/css/if_next_3_926650_50x50.png";
                ImageButton2.Enabled = true;
                ImageButton2.ImageUrl = "~/css/if_check_925925_50x50.png";

            }
            //kur numri i klases eshte e ndryshme dhe viti i njejete
            if (klasaddl_re.SelectedItem.Text != klasaddl_v.SelectedItem.Text && vitiddl_re.SelectedItem.Text == vitiddl_v.SelectedItem.Text)
            {
                ImageButton1.Enabled = false;
                ImageButton1.ImageUrl = "~/css/if_lock_925918(1)_50x50.png";
                ImageButton2.Enabled = false;
                ImageButton2.ImageUrl = "~/css/if_lock_925918(1)_50x50.png";
            }

            //kur klasa eshte e njete dhe vitet e ndryshme
            if (klasaddl_re.SelectedItem.Text == klasaddl_v.SelectedItem.Text && vitiddl_re.SelectedItem.Text != vitiddl_v.SelectedItem.Text)
            {
                ImageButton1.Enabled = false;
                ImageButton1.ImageUrl = "~/css/if_lock_925918(1)_50x50.png";
                ImageButton2.Enabled = false;
                ImageButton2.ImageUrl = "~/css/if_lock_925918(1)_50x50.png";
            }
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

            klasaddl_re.Items.Clear();
            klasaddl_re.Items.Add(klasaddl_v.SelectedItem.Text);
            klasaddl_re.Items.Add((Convert.ToInt16(klasaddl_v.SelectedItem.Text) + 1).ToString());

            //kur eshte e njejta klase dhe  i njeti  indeks ne vit te njejte
            if (vitiddl_re.SelectedItem.Text == vitiddl_v.SelectedItem.Text && klasaddl_re.SelectedItem.Text == klasaddl_v.SelectedItem.Text && indeksiddl_re.SelectedItem.Text == indeksiddl_v.SelectedItem.Text)
            {
                ImageButton1.Enabled = false;
                ImageButton1.ImageUrl = "~/css/if_lock_925918(1)_50x50.png";
                ImageButton2.Enabled = false;
                ImageButton2.ImageUrl = "~/css/if_lock_925918(1)_50x50.png";
            }
            else
            {
                ImageButton1.Enabled = true;
                ImageButton1.ImageUrl = "~/css/if_next_3_926650_50x50.png";
                ImageButton2.Enabled = true;
                ImageButton2.ImageUrl = "~/css/if_check_925925_50x50.png";

            }
            //kur numri i klases eshte e ndryshme dhe viti i njejete
            if (klasaddl_re.SelectedItem.Text != klasaddl_v.SelectedItem.Text && vitiddl_re.SelectedItem.Text == vitiddl_v.SelectedItem.Text)
            {
                ImageButton1.Enabled = false;
                ImageButton1.ImageUrl = "~/css/if_lock_925918(1)_50x50.png";
                ImageButton2.Enabled = false;
                ImageButton2.ImageUrl = "~/css/if_lock_925918(1)_50x50.png";
            }

            //kur klasa eshte e njete dhe vitet e ndryshme
            if (klasaddl_re.SelectedItem.Text == klasaddl_v.SelectedItem.Text && vitiddl_re.SelectedItem.Text != vitiddl_v.SelectedItem.Text)
            {
                ImageButton1.Enabled = false;
                ImageButton1.ImageUrl = "~/css/if_lock_925918(1)_50x50.png";
                ImageButton2.Enabled = false;
                ImageButton2.ImageUrl = "~/css/if_lock_925918(1)_50x50.png";
            }
                bind();
        }

        protected void indeksiddl_v_SelectedIndexChanged(object sender, EventArgs e)
        {
            //kur eshte e njejta klase dhe  i njeti  indeks ne vit te njejte
            if (vitiddl_re.SelectedItem.Text == vitiddl_v.SelectedItem.Text && klasaddl_re.SelectedItem.Text == klasaddl_v.SelectedItem.Text && indeksiddl_re.SelectedItem.Text == indeksiddl_v.SelectedItem.Text)
            {
                ImageButton1.Enabled = false;
                ImageButton1.ImageUrl = "~/css/if_lock_925918(1)_50x50.png";
                ImageButton2.Enabled = false;
                ImageButton2.ImageUrl = "~/css/if_lock_925918(1)_50x50.png";
            }
            else
            {
                ImageButton1.Enabled = true;
                ImageButton1.ImageUrl = "~/css/if_next_3_926650_50x50.png";
                ImageButton2.Enabled = true;
                ImageButton2.ImageUrl = "~/css/if_check_925925_50x50.png";

            }
            //kur numri i klases eshte e ndryshme dhe viti i njejete
            if (klasaddl_re.SelectedItem.Text != klasaddl_v.SelectedItem.Text && vitiddl_re.SelectedItem.Text == vitiddl_v.SelectedItem.Text)
            {
                ImageButton1.Enabled = false;
                ImageButton1.ImageUrl = "~/css/if_lock_925918(1)_50x50.png";
                ImageButton2.Enabled = false;
                ImageButton2.ImageUrl = "~/css/if_lock_925918(1)_50x50.png";
            }

            //kur klasa eshte e njete dhe vitet e ndryshme
            if (klasaddl_re.SelectedItem.Text == klasaddl_v.SelectedItem.Text && vitiddl_re.SelectedItem.Text != vitiddl_v.SelectedItem.Text)
            {
                ImageButton1.Enabled = false;
                ImageButton1.ImageUrl = "~/css/if_lock_925918(1)_50x50.png";
                ImageButton2.Enabled = false;
                ImageButton2.ImageUrl = "~/css/if_lock_925918(1)_50x50.png";
            }
            bind();

        }

        protected void klasaddl_re_SelectedIndexChanged(object sender, EventArgs e)
        {

            //kur eshte e njejta klase dhe  i njeti  indeks ne vit te njejte
            if (vitiddl_re.SelectedItem.Text == vitiddl_v.SelectedItem.Text && klasaddl_re.SelectedItem.Text == klasaddl_v.SelectedItem.Text && indeksiddl_re.SelectedItem.Text == indeksiddl_v.SelectedItem.Text)
            {
                ImageButton1.Enabled = false;
                ImageButton1.ImageUrl = "~/css/if_lock_925918(1)_50x50.png";
                ImageButton2.Enabled = false;
                ImageButton2.ImageUrl = "~/css/if_lock_925918(1)_50x50.png";
            }
            else
            {
                ImageButton1.Enabled = true;
                ImageButton1.ImageUrl = "~/css/if_next_3_926650_50x50.png";
                ImageButton2.Enabled = true;
                ImageButton2.ImageUrl = "~/css/if_check_925925_50x50.png";

            }
            //kur numri i klases eshte e ndryshme dhe viti i njejete
            if (klasaddl_re.SelectedItem.Text != klasaddl_v.SelectedItem.Text && vitiddl_re.SelectedItem.Text == vitiddl_v.SelectedItem.Text)
            {
                ImageButton1.Enabled = false;
                ImageButton1.ImageUrl = "~/css/if_lock_925918(1)_50x50.png";
                ImageButton2.Enabled = false;
                ImageButton2.ImageUrl = "~/css/if_lock_925918(1)_50x50.png";
            }

            //kur klasa eshte e njete dhe vitet e ndryshme
            if (klasaddl_re.SelectedItem.Text == klasaddl_v.SelectedItem.Text && vitiddl_re.SelectedItem.Text != vitiddl_v.SelectedItem.Text)
            {
                ImageButton1.Enabled = false;
                ImageButton1.ImageUrl = "~/css/if_lock_925918(1)_50x50.png";
                ImageButton2.Enabled = false;
                ImageButton2.ImageUrl = "~/css/if_lock_925918(1)_50x50.png";
            }
            bind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (vitiddl_v.SelectedItem.Text == vitiddl_re.SelectedItem.Text)
            {
                //fshin te dhenat e te dyja klasave 
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = conn_str;
                conn.Open();
                SqlCommand cmd_del1 = new SqlCommand();
                cmd_del1.CommandText = "DELETE FROM TBL_KLASA WHERE  KL_KLASA = '" + klasaddl_v.SelectedItem.Text + "' AND KL_INDEKSI = '" + indeksiddl_v.SelectedItem.Text + "' AND KL_VITI_SHKOLLOR = '" + vitiddl_v.SelectedItem.Text + "'" + " AND KL_ID_SHKOLLA = " + Convert.ToInt64(Session["shkolla"].ToString());
                SqlCommand cmd_del2 = new SqlCommand();
                cmd_del2.CommandText = "DELETE FROM TBL_KLASA WHERE  KL_KLASA = '" + klasaddl_re.SelectedItem.Text + "' AND KL_INDEKSI = '" + indeksiddl_re.SelectedItem.Text + "' AND KL_VITI_SHKOLLOR = '" + vitiddl_re.SelectedItem.Text + "'" + " AND KL_ID_SHKOLLA = " + Convert.ToInt64(Session["shkolla"].ToString());
                cmd_del1.Connection = conn;
                cmd_del2.Connection = conn;
                cmd_del1.ExecuteNonQuery();
                cmd_del2.ExecuteNonQuery();
                // i hedh prape sipas ndryshimeve te bera insert te tabela e klases update te tabelat e notave dhe te amzes

                SqlCommand cmd_ins1 = new SqlCommand();
                SqlCommand cmd_update_amza1 = new SqlCommand();
                SqlCommand cmd_update_notat1 = new SqlCommand();
                cmd_ins1.Connection = conn;
                cmd_update_amza1.Connection = conn;
                cmd_update_notat1.Connection = conn;


                for (int i = 0; i <= ListBox1.Items.Count - 1; i++)
                {

                    cmd_ins1.CommandText = "INSERT INTO TBL_KLASA (KL_NR_AMZA, KL_CIKLI, KL_VITI_SHKOLLOR,KL_KLASA, KL_INDEKSI, KL_ID_SHKOLLA) VALUES ('" + ListBoxAMZA1.Items[i].ToString() + "', '" + cikli + "' , '" + vitiddl_v.SelectedItem.Text + "', '" + klasaddl_v.SelectedItem.Text + "', '" + indeksiddl_v.SelectedItem.Text + "', " + Convert.ToInt64(Session["shkolla"].ToString()) + ")";
                    cmd_ins1.ExecuteNonQuery();
                    cmd_update_amza1.CommandText = "UPDATE TBL_AMZA SET AMZA_KLASA = '" + klasaddl_v.SelectedItem.Text + "', AMZA_INDEKSI = '" + indeksiddl_v.SelectedItem.Text + "', AMZA_VITI_SHKOLLOR = '" + vitiddl_v.SelectedItem.Text + "' WHERE AMZA_NR_AMZA = '" + ListBoxAMZA1.Items[i].ToString() + "' AND AMZA_CIKLI = " + "'" + cikli + "'" + " AND AMZA_ID_SHKOLLA = " + Convert.ToInt64(Session["shkolla"].ToString());
                    cmd_update_amza1.ExecuteNonQuery();
                    cmd_update_notat1.CommandText = "UPDATE TBL_NOTA SET NT_KLASA = '" + klasaddl_v.SelectedItem.Text + "', NT_INDEKSI = '" + indeksiddl_v.SelectedItem.Text + "' WHERE NT_NR_AMZA = '" + ListBoxAMZA1.Items[i].ToString() + "' AND NT_CIKLI = '" + cikli + "' AND NT_VITI_SHKOLLOR = '" + vitiddl_v.SelectedItem.Text + "'" + " AND NT_ID_SHKOLLA = " + Convert.ToInt64(Session["shkolla"].ToString());
                    cmd_update_notat1.ExecuteNonQuery();
                }

                for (int j = 0; j <= ListBox2.Items.Count - 1; j++)
                {

                    cmd_ins1.CommandText = "INSERT INTO TBL_KLASA (KL_NR_AMZA, KL_CIKLI, KL_VITI_SHKOLLOR,KL_KLASA, KL_INDEKSI, KL_ID_SHKOLLA) VALUES ('" + ListBoxAMZA2.Items[j].ToString() + "', '" + cikli + "' , '" + vitiddl_re.SelectedItem.Text + "', '" + klasaddl_re.SelectedItem.Text + "', '" + indeksiddl_re.SelectedItem.Text +"', " +  Convert.ToInt64(Session["shkolla"].ToString()) + ")";
                    cmd_ins1.ExecuteNonQuery();
                    cmd_update_amza1.CommandText = "UPDATE TBL_AMZA SET AMZA_KLASA = '" + klasaddl_re.SelectedItem.Text + "', AMZA_INDEKSI = '" + indeksiddl_re.SelectedItem.Text + "', AMZA_VITI_SHKOLLOR = '" + vitiddl_re.SelectedItem.Text + "' WHERE AMZA_NR_AMZA = '" + ListBoxAMZA2.Items[j].ToString() + "' AND AMZA_CIKLI = " + "'" + cikli + "'" + " AND AMZA_ID_SHKOLLA = " + Convert.ToInt64(Session["shkolla"].ToString());
                    cmd_update_amza1.ExecuteNonQuery();
                    cmd_update_notat1.CommandText = "UPDATE TBL_NOTA SET NT_KLASA = '" + klasaddl_re.SelectedItem.Text + "', NT_INDEKSI = '" + indeksiddl_re.SelectedItem.Text + "' WHERE NT_NR_AMZA = '" + ListBoxAMZA2.Items[j].ToString() + "' AND NT_CIKLI = '" + cikli + "' AND NT_VITI_SHKOLLOR = '" + vitiddl_re.SelectedItem.Text + "'" + " AND NT_ID_SHKOLLA = " + Convert.ToInt64(Session["shkolla"].ToString());
                    cmd_update_notat1.ExecuteNonQuery();
                }
                conn.Close();
            }

            else
            {
                SqlConnection conn1 = new SqlConnection();
                conn1.ConnectionString = conn_str;
                conn1.Open();
                SqlCommand cmd_del3 = new SqlCommand();
                SqlCommand cmd_ins_3 = new SqlCommand();
                SqlCommand cmd_update_3 = new SqlCommand();
                cmd_del3.Connection = conn1;
                cmd_ins_3.Connection = conn1;
                cmd_update_3.Connection = conn1;

                DataSet ds = new DataSet();
                SqlCommand cmd_sel = new SqlCommand();
                cmd_sel.Connection = conn1;
                SqlDataAdapter da = new SqlDataAdapter(cmd_sel);
                DataTable dt = new DataTable();


                cmd_del3.CommandText = "DELETE FROM TBL_KLASA WHERE  KL_KLASA = '" + klasaddl_re.SelectedItem.Text + "' AND KL_INDEKSI = '" + indeksiddl_re.SelectedItem.Text + "' AND KL_VITI_SHKOLLOR = '" + vitiddl_re.SelectedItem.Text + "'" + " AND KL_ID_SHKOLLA = " + Convert.ToInt64(Session["shkolla"].ToString());
                cmd_del3.ExecuteNonQuery();
                for(int k = 0;k<=ListBox2.Items.Count-1;k++)
                {
                    string nxenesi = ListBox2.Items[k].ToString();
                    cmd_sel.CommandText = "SELECT KL_NR_AMZA, KL_CIKLI, KL_KLASA, KL_INDEKSI FROM TBL_KLASA WHERE KL_NR_AMZA = '" + ListBoxAMZA2.Items[k].ToString() + "' AND KL_CIKLI = " + "'" + cikli + "'" + " AND KL_VITI_SHKOLLOR = '" + vitiddl_re.SelectedItem.Text + "'" + " AND KL_ID_SHKOLLA = " + Convert.ToInt64(Session["shkolla"].ToString());
                    da.Fill(ds);
                    dt = ds.Tables[0];
                    if (dt.Rows.Count == 0)
                    {
                        cmd_ins_3.CommandText = "INSERT INTO TBL_KLASA (KL_NR_AMZA, KL_CIKLI, KL_VITI_SHKOLLOR,KL_KLASA, KL_INDEKSI, KL_ID_SHKOLLA) VALUES ('" + ListBoxAMZA2.Items[k].ToString() + "', " + "'" + cikli + "'" + " , '" + vitiddl_re.SelectedItem.Text + "', '" + klasaddl_re.SelectedItem.Text + "', '" + indeksiddl_re.SelectedItem.Text + "' ," +  Convert.ToInt64(Session["shkolla"].ToString()) + ")";
                        cmd_ins_3.ExecuteNonQuery();
                        cmd_update_3.CommandText = "UPDATE TBL_AMZA SET AMZA_KLASA = '" + klasaddl_re.SelectedItem.Text + "', AMZA_INDEKSI = '" + indeksiddl_re.SelectedItem.Text + "', AMZA_VITI_SHKOLLOR = '" + vitiddl_re.SelectedItem.Text + "' WHERE AMZA_NR_AMZA = '" + ListBoxAMZA2.Items[k].ToString() + "' AND AMZA_CIKLI = " + "'" + cikli + "'";
                        cmd_update_3.ExecuteNonQuery();
                    }
                    else
                    {
                        msbox("Nxenesi me emrin " + nxenesi + " per vitin shkollor " + vitiddl_re.SelectedItem.Text + " eshte regjistruar ne klasen " + dt.Rows[0]["KL_KLASA"].ToString() + dt.Rows[0]["KL_INDEKSI"].ToString());
                    }
                    

                }
                conn1.Close();
            }
            
            msbox("Nxenesit u hodhen ne klasen e re ! ");
            ListBox1.Items.Clear();
            ListBox2.Items.Clear();
       }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
          
            for (int i = 0; i <= ListBox1.Items.Count - 1; i++)
            {
                if (ListBox1.Items[i].Selected)
                {
                    ListBox2.Items.Add(ListBox1.Items[i]);
                    ListBoxAMZA2.Items.Add(ListBoxAMZA1.Items[i]);
                }
            }

          

            int l = ListBox1.Items.Count-1;
                for (int j = l; j >= 0; j--)
                {
                    if (ListBox1.Items[j].Selected)
                    {
                        ListBox1.Items.Remove(ListBox1.Items[j]);
                    ListBoxAMZA1.Items.RemoveAt(j);

                }
                }
                
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
          

            {
                if (vitiddl_v.SelectedItem.Text == vitiddl_re.SelectedItem.Text)
                {
                    //fshin te dhenat e te dyja klasave 
                    SqlConnection conn = new SqlConnection();
                    conn.ConnectionString = conn_str;
                    conn.Open();
                    SqlCommand cmd_del1 = new SqlCommand();
                    cmd_del1.CommandText = "DELETE FROM TBL_KLASA WHERE  KL_KLASA = '" + klasaddl_v.SelectedItem.Text + "' AND KL_INDEKSI = '" + indeksiddl_v.SelectedItem.Text + "' AND KL_VITI_SHKOLLOR = '" + vitiddl_v.SelectedItem.Text + "'" + " AND KL_ID_SHKOLLA = " + Convert.ToInt64(Session["shkolla"].ToString());
                    SqlCommand cmd_del2 = new SqlCommand();
                    cmd_del2.CommandText = "DELETE FROM TBL_KLASA WHERE  KL_KLASA = '" + klasaddl_re.SelectedItem.Text + "' AND KL_INDEKSI = '" + indeksiddl_re.SelectedItem.Text + "' AND KL_VITI_SHKOLLOR = '" + vitiddl_re.SelectedItem.Text + "'" + " AND KL_ID_SHKOLLA = " + Convert.ToInt64(Session["shkolla"].ToString());
                    cmd_del1.Connection = conn;
                    cmd_del2.Connection = conn;
                    cmd_del1.ExecuteNonQuery();
                    cmd_del2.ExecuteNonQuery();
                    // i hedh prape sipas ndryshimeve te bera insert te tabela e klases update te tabelat e notave dhe te amzes

                    SqlCommand cmd_ins1 = new SqlCommand();
                    SqlCommand cmd_update_amza1 = new SqlCommand();
                    SqlCommand cmd_update_notat1 = new SqlCommand();
                    cmd_ins1.Connection = conn;
                    cmd_update_amza1.Connection = conn;
                    cmd_update_notat1.Connection = conn;


                    for (int i = 0; i <= ListBox1.Items.Count - 1; i++)
                    {

                        cmd_ins1.CommandText = "INSERT INTO TBL_KLASA (KL_NR_AMZA, KL_CIKLI, KL_VITI_SHKOLLOR,KL_KLASA, KL_INDEKSI, KL_ID_SHKOLLA) VALUES ('" + ListBoxAMZA1.Items[i].ToString() + "', '" + cikli + "' , '" + vitiddl_v.SelectedItem.Text + "', '" + klasaddl_v.SelectedItem.Text + "', '" + indeksiddl_v.SelectedItem.Text + "', " + Convert.ToInt64(Session["shkolla"].ToString()) + ")";
                        cmd_ins1.ExecuteNonQuery();
                        cmd_update_amza1.CommandText = "UPDATE TBL_AMZA SET AMZA_KLASA = '" + klasaddl_v.SelectedItem.Text + "', AMZA_INDEKSI = '" + indeksiddl_v.SelectedItem.Text + "', AMZA_VITI_SHKOLLOR = '" + vitiddl_v.SelectedItem.Text + "' WHERE AMZA_NR_AMZA = '" + ListBoxAMZA1.Items[i].ToString() + "' AND AMZA_CIKLI = " + "'" + cikli + "'" + " AND AMZA_ID_SHKOLLA = " + Convert.ToInt64(Session["shkolla"].ToString());
                        cmd_update_amza1.ExecuteNonQuery();
                        cmd_update_notat1.CommandText = "UPDATE TBL_NOTA SET NT_KLASA = '" + klasaddl_v.SelectedItem.Text + "', NT_INDEKSI = '" + indeksiddl_v.SelectedItem.Text + "' WHERE NT_NR_AMZA = '" + ListBoxAMZA1.Items[i].ToString() + "' AND NT_CIKLI = '" + cikli + "' AND NT_VITI_SHKOLLOR = '" + vitiddl_v.SelectedItem.Text + "'" + " AND NT_ID_SHKOLLA = " + Convert.ToInt64(Session["shkolla"].ToString());
                        cmd_update_notat1.ExecuteNonQuery();
                    }

                    for (int j = 0; j <= ListBox2.Items.Count - 1; j++)
                    {

                        cmd_ins1.CommandText = "INSERT INTO TBL_KLASA (KL_NR_AMZA, KL_CIKLI, KL_VITI_SHKOLLOR,KL_KLASA, KL_INDEKSI, KL_ID_SHKOLLA) VALUES ('" + ListBoxAMZA2.Items[j].ToString() + "', '" + cikli + "' , '" + vitiddl_re.SelectedItem.Text + "', '" + klasaddl_re.SelectedItem.Text + "', '" + indeksiddl_re.SelectedItem.Text + "', " + Convert.ToInt64(Session["shkolla"].ToString()) + ")";
                        cmd_ins1.ExecuteNonQuery();
                        cmd_update_amza1.CommandText = "UPDATE TBL_AMZA SET AMZA_KLASA = '" + klasaddl_re.SelectedItem.Text + "', AMZA_INDEKSI = '" + indeksiddl_re.SelectedItem.Text + "', AMZA_VITI_SHKOLLOR = '" + vitiddl_re.SelectedItem.Text + "' WHERE AMZA_NR_AMZA = '" + ListBoxAMZA2.Items[j].ToString() + "' AND AMZA_CIKLI = " + "'" + cikli + "'" + " AND AMZA_ID_SHKOLLA = " + Convert.ToInt64(Session["shkolla"].ToString());
                        cmd_update_amza1.ExecuteNonQuery();
                        cmd_update_notat1.CommandText = "UPDATE TBL_NOTA SET NT_KLASA = '" + klasaddl_re.SelectedItem.Text + "', NT_INDEKSI = '" + indeksiddl_re.SelectedItem.Text + "' WHERE NT_NR_AMZA = '" + ListBoxAMZA2.Items[j].ToString() + "' AND NT_CIKLI = '" + cikli + "' AND NT_VITI_SHKOLLOR = '" + vitiddl_re.SelectedItem.Text + "'" + " AND NT_ID_SHKOLLA = " + Convert.ToInt64(Session["shkolla"].ToString());
                        cmd_update_notat1.ExecuteNonQuery();
                    }
                    conn.Close();
                }

                else
                {
                    SqlConnection conn1 = new SqlConnection();
                    conn1.ConnectionString = conn_str;
                    conn1.Open();
                    SqlCommand cmd_del3 = new SqlCommand();
                    SqlCommand cmd_ins_3 = new SqlCommand();
                    SqlCommand cmd_update_3 = new SqlCommand();
                    cmd_del3.Connection = conn1;
                    cmd_ins_3.Connection = conn1;
                    cmd_update_3.Connection = conn1;

                    DataSet ds = new DataSet();
                    SqlCommand cmd_sel = new SqlCommand();
                    cmd_sel.Connection = conn1;
                    SqlDataAdapter da = new SqlDataAdapter(cmd_sel);
                    DataTable dt = new DataTable();


                    cmd_del3.CommandText = "DELETE FROM TBL_KLASA WHERE  KL_KLASA = '" + klasaddl_re.SelectedItem.Text + "' AND KL_INDEKSI = '" + indeksiddl_re.SelectedItem.Text + "' AND KL_VITI_SHKOLLOR = '" + vitiddl_re.SelectedItem.Text + "'" + " AND KL_ID_SHKOLLA = " + Convert.ToInt64(Session["shkolla"].ToString());
                    cmd_del3.ExecuteNonQuery();
                    for (int k = 0; k <= ListBox2.Items.Count - 1; k++)
                    {
                        string nxenesi = ListBox2.Items[k].ToString();
                        cmd_sel.CommandText = "SELECT KL_NR_AMZA, KL_CIKLI, KL_KLASA, KL_INDEKSI FROM TBL_KLASA WHERE KL_NR_AMZA = '" + ListBoxAMZA2.Items[k].ToString() + "' AND KL_CIKLI = " + "'" + cikli + "'" + " AND KL_VITI_SHKOLLOR = '" + vitiddl_re.SelectedItem.Text + "'" + " AND KL_ID_SHKOLLA = " + Convert.ToInt64(Session["shkolla"].ToString());
                        da.Fill(ds);
                        dt = ds.Tables[0];
                        if (dt.Rows.Count == 0)
                        {
                            cmd_ins_3.CommandText = "INSERT INTO TBL_KLASA (KL_NR_AMZA, KL_CIKLI, KL_VITI_SHKOLLOR,KL_KLASA, KL_INDEKSI, KL_ID_SHKOLLA) VALUES ('" + ListBoxAMZA2.Items[k].ToString() + "', " + "'" + cikli + "'" + " , '" + vitiddl_re.SelectedItem.Text + "', '" + klasaddl_re.SelectedItem.Text + "', '" + indeksiddl_re.SelectedItem.Text + "' ," + Convert.ToInt64(Session["shkolla"].ToString()) + ")";
                            cmd_ins_3.ExecuteNonQuery();
                            cmd_update_3.CommandText = "UPDATE TBL_AMZA SET AMZA_KLASA = '" + klasaddl_re.SelectedItem.Text + "', AMZA_INDEKSI = '" + indeksiddl_re.SelectedItem.Text + "', AMZA_VITI_SHKOLLOR = '" + vitiddl_re.SelectedItem.Text + "' WHERE AMZA_NR_AMZA = '" + ListBoxAMZA2.Items[k].ToString() + "' AND AMZA_CIKLI = " + "'" + cikli + "'";
                            cmd_update_3.ExecuteNonQuery();
                        }
                        else
                        {
                            msbox("Nxenesi me emrin " + nxenesi + " per vitin shkollor " + vitiddl_re.SelectedItem.Text + " eshte regjistruar ne klasen " + dt.Rows[0]["KL_KLASA"].ToString() + dt.Rows[0]["KL_INDEKSI"].ToString());
                        }


                    }
                    conn1.Close();
                }

                msbox("Nxenesit u hodhen ne klasen e re ! ");
                ListBox1.Items.Clear();
                ListBox2.Items.Clear();
            }



        }

       

        

        protected void vitiddl_re_SelectedIndexChanged(object sender, EventArgs e)
        {
            //kur eshte e njejta klase dhe  i njeti  indeks ne vit te njejte
            if (vitiddl_re.SelectedItem.Text == vitiddl_v.SelectedItem.Text && klasaddl_re.SelectedItem.Text == klasaddl_v.SelectedItem.Text && indeksiddl_re.SelectedItem.Text == indeksiddl_v.SelectedItem.Text)
            {
                ImageButton1.Enabled = false;
                ImageButton1.ImageUrl = "~/css/if_lock_925918(1)_50x50.png";
                ImageButton2.Enabled = false;
                ImageButton2.ImageUrl = "~/css/if_lock_925918(1)_50x50.png";
            }
            else
            {
                ImageButton1.Enabled = true;
                ImageButton1.ImageUrl = "~/css/if_next_3_926650_50x50.png";
                ImageButton2.Enabled = true;
                ImageButton2.ImageUrl = "~/css/if_check_925925_50x50.png";

            }
            //kur numri i klases eshte e ndryshme dhe viti i njejete
            if (klasaddl_re.SelectedItem.Text != klasaddl_v.SelectedItem.Text && vitiddl_re.SelectedItem.Text == vitiddl_v.SelectedItem.Text)
            {
                ImageButton1.Enabled = false;
                ImageButton1.ImageUrl = "~/css/if_lock_925918(1)_50x50.png";
                ImageButton2.Enabled = false;
                ImageButton2.ImageUrl = "~/css/if_lock_925918(1)_50x50.png";
            }

            //kur klasa eshte e njete dhe vitet e ndryshme
            if (klasaddl_re.SelectedItem.Text == klasaddl_v.SelectedItem.Text && vitiddl_re.SelectedItem.Text != vitiddl_v.SelectedItem.Text)
            {
                ImageButton1.Enabled = false;
                ImageButton1.ImageUrl = "~/css/if_lock_925918(1)_50x50.png";
                ImageButton2.Enabled = false;
                ImageButton2.ImageUrl = "~/css/if_lock_925918(1)_50x50.png";
            }

            bind();
        }

        protected void indeksiddl_re_SelectedIndexChanged(object sender, EventArgs e)
        {
            //kur eshte e njejta klase dhe  i njeti  indeks ne vit te njejte
            if (vitiddl_re.SelectedItem.Text == vitiddl_v.SelectedItem.Text && klasaddl_re.SelectedItem.Text == klasaddl_v.SelectedItem.Text && indeksiddl_re.SelectedItem.Text == indeksiddl_v.SelectedItem.Text)
            {
                ImageButton1.Enabled = false;
                ImageButton1.ImageUrl = "~/css/if_lock_925918(1)_50x50.png";
                ImageButton2.Enabled = false;
                ImageButton2.ImageUrl = "~/css/if_lock_925918(1)_50x50.png";
            }
            else
            {
                ImageButton1.Enabled = true;
                ImageButton1.ImageUrl = "~/css/if_next_3_926650_50x50.png";
                ImageButton2.Enabled = true;
                ImageButton2.ImageUrl = "~/css/if_check_925925_50x50.png";

            }
            //kur numri i klases eshte e ndryshme dhe viti i njejete
            if (klasaddl_re.SelectedItem.Text != klasaddl_v.SelectedItem.Text && vitiddl_re.SelectedItem.Text == vitiddl_v.SelectedItem.Text)
            {
                ImageButton1.Enabled = false;
                ImageButton1.ImageUrl = "~/css/if_lock_925918(1)_50x50.png";
                ImageButton2.Enabled = false;
                ImageButton2.ImageUrl = "~/css/if_lock_925918(1)_50x50.png";
            }

            //kur klasa eshte e njete dhe vitet e ndryshme
            if (klasaddl_re.SelectedItem.Text == klasaddl_v.SelectedItem.Text && vitiddl_re.SelectedItem.Text != vitiddl_v.SelectedItem.Text)
            {
                ImageButton1.Enabled = false;
                ImageButton1.ImageUrl = "~/css/if_lock_925918(1)_50x50.png";
                ImageButton2.Enabled = false;
                ImageButton2.ImageUrl = "~/css/if_lock_925918(1)_50x50.png";
            }
            bind();
        }

      

        protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ListBox1.SelectedIndex == -1)
            {
                ImageButton2.Enabled = false;
                ImageButton2.ImageUrl = "~/css/if_lock_925918(1)_50x50.png";
            }
            else
            {
                ImageButton2.Enabled = true;
                ImageButton2.ImageUrl = "~/css/if_check_925925_50x50.png";
            }
        }

       
    }
}