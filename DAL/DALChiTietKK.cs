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
    public class DALChiTietKK : DBconect
    {
        public DataTable SelectCTKiemKe()
        {
            string sql = "Select * from ChiTietKK";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection());
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            return dataTable;
        }
        public void InsetCTKiemKe(ChiTietKK kiemke)
        {
            string SQL = string.Format("INSERT INTO ChiTietKK " +
                "  VALUES ('{0}','{1}','{2}','{3}')"
                , kiemke.MaKK1, kiemke.MaSP1, kiemke.SoLuong1,kiemke.DVT1);
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
