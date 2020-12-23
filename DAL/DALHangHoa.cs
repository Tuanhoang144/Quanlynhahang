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
    public class DALHangHoa : DBconect
    {
        public DataTable SelectHanghoa()
        {
            string sql = "Select * from HangHoa";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection());
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            return dataTable;
        }
        public DataTable SelectmaHanghoatheoten(string ten )
        {
            string sql = string.Format("Select MaSP from HangHoa where TenSP = '{0}' " ,ten);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection());
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            return dataTable;
        }
        public void InsetHanghoa(HangHoa hangHoa)
        {
            string SQL = string.Format("INSERT INTO HangHoa (MaSP,TenSP,GIA) " +
                "  VALUES ('{0}','{1}','{2}')"
                , hangHoa.MaSP1, hangHoa.TenSP1, hangHoa.Gia1);
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
