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
    public class DALDondathang : DBconect
    {
        public DataTable SelectDonDatHang()
        {
            string sql = "Select * from DonDatHang";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection());
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            return dataTable;
        }
        public void InsetDonDatHang(DonDatHang DonDatHang)
        {
            string SQL = string.Format("INSERT INTO DonDatHang " +
                "  VALUES ('{0}','{1}','{2}','{3}','{4}')"
                , DonDatHang.MaDH1, DonDatHang.MaNCC1, DonDatHang.TongTien1, DonDatHang.MaNV1,0);
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
        public void Update(string s )
        {
            string SQL = string.Format("UPDATE DonDatHang Set TrangThai ='{0}' " +
                "  WHERE MaDH = '{1}' ", "595107" + 1,s);
            SqlConnection sqlConnection1 = sqlConnection();
            try
            {
                sqlConnection1.Open();
                SqlCommand command = new SqlCommand(SQL, sqlConnection1);
                command.ExecuteNonQuery();
               
            }
            catch (Exception ex)
            {



            }
            finally
            {
                sqlConnection1.Close();
            }


        }

    }
}
