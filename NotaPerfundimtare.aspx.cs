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


    
    public class nota
    {
        public int vleresimi { get; set; }
        public bool vazhduar { get; set; }
        public bool projekt { get; set; }
        public bool shkrim { get; set; }

        public DateTime data { get; set; }
    }
    public class NxenesiTemplate
    {
        public string Emri { get; set; }
       // public string Mbiemri { get; set; }

        public List<nota> Notat { get;set;}

    }
    public partial class NotaPerfundimtare : System.Web.UI.Page
    

    {
        public static string conn_str = "Server = tcp:azeneli2000.database.windows.net,1433; Initial Catalog = shkolla_prova; Persist Security Info = False; User ID = andi; Password =Matrix2001; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;";

        public bool cikli = true;
        public DataSet klasaDataset = new DataSet();//dataseti i pergjitheshem




        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public  IEnumerable<NxenesiTemplate> ktheNxenesit()
        {
          List<NxenesiTemplate> nxenesitKlasa = new List<NxenesiTemplate>();
            //todo
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = conn_str;
            DataTable nxenesit = new DataTable();
            SqlCommand cmd_nx = new SqlCommand();
            cmd_nx.Connection = conn;
            // gjen nxenesit e nje klase 
            cmd_nx.CommandText = "select KL_NR_AMZA as Amza ,AMZA_EMRI +' '+ AMZA_MBIEMRI as Emri from TBL_KLASA,TBL_AMZA where KL_KLASA = '" + klasaddl.SelectedItem.Text + "' and KL_INDEKSI = '" + indeksiddl.SelectedItem.Text + "' and KL_ID_SHKOLLA = " + Convert.ToInt64(Session["shkolla"].ToString()) + " and KL_VITI_SHKOLLOR = '" + vitiddl.SelectedItem.Text + "' and  AMZA_LARGUAR = '" + false + "' and KL_NR_AMZA = AMZA_NR_AMZA" + " and AMZA_CIKLI = '" + cikli + "' and AMZA_ID_SHKOLLA = " + Convert.ToInt64(Session["shkolla"].ToString()) + " ORDER BY Emri";
            SqlDataAdapter da_nx = new SqlDataAdapter(cmd_nx);
            da_nx.Fill(nxenesit);
            //mbush listen e nxensve te klases me nota
            foreach (DataRow r in nxenesit.Rows)
            {
                NxenesiTemplate nxenesi = new NxenesiTemplate();
                nxenesi.Emri = r.Field<String>("Emri");
                nxenesi.Notat = ktheNotatNxenensi(lendaddl.SelectedItem.Text, r.Field<String>("Amza"),klasaddl.SelectedItem.Text,vitiddl.SelectedItem.Text);
                nxenesitKlasa.Add(nxenesi);
            }
            return nxenesitKlasa;
        }




        //kthen nje liste me notat e nxenesit
        public List<nota> ktheNotatNxenensi(string lenda, string nr_amza, string klasa, string viti_shkollor)
        {
            List<nota> notat = new List<nota>();
            //todo
            DataTable dt = new DataTable();
            DataTable dt1 = new DataTable();
            SqlCommand cmd = new SqlCommand();

            dt = klasaDataset.Tables[0];

            var res = from nx in dt.AsEnumerable()
                      where nx.Field<String>("NT_NR_AMZA") == nr_amza && nx.Field<String>("NT_EMRI_LENDA") == lenda && nx.Field<String>("NT_KLASA") == klasaddl.SelectedItem.Text && nx.Field<String>("NT_INDEKSI") == indeksiddl.SelectedItem.Text && nx.Field<String>("NT_VITI_SHKOLLOR") == viti_shkollor && nx.Field<Int64>("NT_ID_SHKOLLA") == Convert.ToInt64(Session["shkolla"].ToString())
                      select nx;

       
         
            foreach (var r in res)
            {
                nota nota = new nota();
                nota.vleresimi = Convert.ToInt32( r["NT_VLERESIMI"]);
                nota.vazhduar = Convert.ToBoolean(r["NT_MOMENTALE"]);
                nota.projekt = Convert.ToBoolean(r["NT_PROJEKT"]);
                nota.vazhduar = Convert.ToBoolean(r["NT_DETYREKONTROLLI"]);

                notat.Add(nota);
            }



            return notat;

        }


        //mbush datasetin klasadataset
        public void mbush_dataset()
        {
            klasaDataset.Clear();
            //mbush datasetin global sa here qe ndryshon klasa
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = conn_str;
            SqlCommand cmd_klasa = new SqlCommand();
            cmd_klasa.CommandText = "select * from TBL_NOTA where NT_KLASA = '" + klasaddl.SelectedItem.Text + "' and NT_INDEKSI = '" + indeksiddl.SelectedItem.Text + "' and NT_VITI_SHKOLLOR = '" + vitiddl.SelectedItem.Text + "' and NT_ID_SHKOLLA = " + Convert.ToInt64(Session["shkolla"].ToString());

            cmd_klasa.Connection = conn;
            SqlDataAdapter da = new SqlDataAdapter(cmd_klasa);
            da.SelectCommand = cmd_klasa;
            conn.Open();


            da.Fill(klasaDataset);
            conn.Close();
        }

    }


}