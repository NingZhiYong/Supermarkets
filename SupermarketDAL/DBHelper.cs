using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketDAL
{
    public class DBHelper
    {
        private static string conStr = "Data Source=.;Initial Catalog=Supermarket;Integrated Security=True";


        //写
        public static bool Write(string sql)
        {
            SqlConnection con = new SqlConnection(conStr);
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            int rs = cmd.ExecuteNonQuery();
            con.Close();
            return rs > 0;
        }

        public static bool WR(SqlCommand cmd)
        {
            SqlConnection con = new SqlConnection(conStr);
            con.Open();
            cmd.Connection = con;
            int rs = cmd.ExecuteNonQuery();
            con.Close();
            return rs > 0;
        }

        //读
        public static DataTable Read(string sql)
        {
            DataTable table = new DataTable();
            new SqlDataAdapter(sql, conStr).Fill(table);
            return table;
        }
    }
}
