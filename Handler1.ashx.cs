using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace WebApplication2
{
    /// <summary>
    /// Summary description for Handler1
    /// </summary>

    public class Handler1 : IHttpHandler
    {
        public string conn_str = "Server = tcp:azeneli2000.database.windows.net,1433; Initial Catalog = shkolla_prova; Persist Security Info = False; User ID = andi; Password =Matrix2001; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;";

        public void ProcessRequest(HttpContext context)
        {
            string id = context.Request.QueryString["Id"];

            context.Response.ContentType = "image/jpeg";
            Stream strm = shfaq(id);
            if (strm == null)
                return;
            byte[] buffer = new byte[4096];
            int byteSeq = strm.Read(buffer, 0, 4096);
            while (byteSeq > 0)
            {
                context.Response.OutputStream.Write(buffer, 0, byteSeq);
                byteSeq = strm.Read(buffer, 0, 4096);

            }
        }

        public Stream shfaq(string id_shkolla )
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = conn_str;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT LOGO FROM TBL_SHKOLLAT WHERE SH_ID = " +id_shkolla;
            cmd.Connection = conn;
            conn.Open();
            SqlDataReader r = cmd.ExecuteReader();
            MemoryStream ms = null;
            while (r.Read())

                if (r["LOGO"] != DBNull.Value)
                {
                 ms = new MemoryStream((byte[])r["LOGO"]);
                    conn.Close();
                    return ms;
                }
                else
                {
                    conn.Close();
                    return null;
                }
            return ms;
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}