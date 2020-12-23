using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace DAL
{
    public class DALChitietdathang : DBconect
    {
        public DataTable SelectHanghoa()
        {
            string sql = "Select * from ChiTietDH";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection());
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            return dataTable;
        }
        public void InsetHanghoa(ChiTietDatHang ChiTietDatHang)
        {
            string SQL = string.Format("INSERT INTO ChiTietDH " +
                "  VALUES ('{0}','{1}','{2}','{3}')"
                , ChiTietDatHang.MaDH1, ChiTietDatHang.MaSP1, ChiTietDatHang.SoLuong1, ChiTietDatHang.DVT1);
            SqlConnection sqlConnection1 = sqlConnection();
            try
            {
                sqlConnection1.Open();
                SqlCommand sqlCommand = new SqlCommand(SQL, sqlConnection1);
                sqlCommand.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { sqlConnection1.Close(); }

        }
    }
}
