using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCH
{
    public class kETNOI
    {
         private string ConnectionSTR = @"Data Source=DESKTOP-HPCU6N0\SQLEXPRESS;Initial Catalog=QUANLYBANHANGCOFFEE;Integrated Security=True";

        public SqlConnection getConnect()
        {
            SqlConnection Conn = new SqlConnection(ConnectionSTR);
            Conn.Open();
            return Conn;
        }

        public int ExecuteNonQuery(string query)
        {
            int data = 0;
            using (SqlConnection ketnoi = new SqlConnection(ConnectionSTR))
            {
                ketnoi.Open();
                SqlCommand cmd = new SqlCommand(query, ketnoi);
                data = cmd.ExecuteNonQuery();
                ketnoi.Close();
            }
            return data;
        }
        
        public DataTable ExecuteQuery(string query)
        {
            DataTable dt = new DataTable();
            using (SqlConnection ketnoi = new SqlConnection(ConnectionSTR))
            {
                ketnoi.Open();
                SqlCommand cmd = new SqlCommand(query, ketnoi);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                ketnoi.Close();
            }
            return dt;
        }

        public DataSet loadDataSet(string query)
        {
            DataSet dt = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter(query, getConnect());
            adapter.Fill(dt);
            return dt;
        }

        public bool ExeReader(string query)
        {
            bool kq;
            using (SqlConnection ketnoi = new SqlConnection(ConnectionSTR))
            {
                ketnoi.Open();
                SqlCommand thucthi = new SqlCommand(query, ketnoi);
                SqlDataReader dreader = thucthi.ExecuteReader();
                kq = dreader.Read();
                ketnoi.Close();
                return kq;
            }
        }

    }
}
