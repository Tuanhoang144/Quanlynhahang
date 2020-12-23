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
    public class DALKiemKe : DBconect
    {
        public DataTable SelectKiemKe()
        {
            string sql = "Select * from KiemKe";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection());
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            return dataTable;
        }
        public void InsetKiemKe(Kiemke kiemke)
        {
            string SQL = string.Format("INSERT INTO KiemKe " +
                "  VALUES ('{0}','{1}','{2}')"
                , kiemke.MaKK1, kiemke.NgayKK1, kiemke.MaNV1);
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
