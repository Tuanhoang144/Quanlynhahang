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
    public class DALNhaCC : DBconect
    {
        public DataTable SelectNhaCC()
        {
            string sql = "Select * from NhaCC";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection());
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            return dataTable;
        }
        public DataTable Selectmanhacctheoten(string ten)
        {
            string sql = string.Format("Select MaNCC from NhaCC where TennNCC = {0} ", ten);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection());
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            return dataTable;
        }
        public void InsetNhaCC(NhaCungCap NhaCungCap)
        {
            string SQL = string.Format("INSERT INTO NhaCC " +
                "  VALUES ('{0}','{1}','{2}','{3}')"
                , NhaCungCap.MaNCC1, NhaCungCap.Ten1,NhaCungCap.DiaChi1, NhaCungCap.SDT1);
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
