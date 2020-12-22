using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DAL
{
    public class DALNhomMon:DBconect
    {
        public DataTable SelectNhomMon()
        {
            string sql = "Select * from NHOMMON";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection());
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            return dataTable;
        }
        public DataTable TongNhomMon()
        {
            string sql = "Select COUNT(*) Soluong from NHOMMON";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection());
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            return dataTable;
        }
        public void Insert(NhomMon nhom)
        {
            string SQL = string.Format("INSERT INTO NHOMMON (MALOAI,TENLOAI,MAUSAC)" +
                "  VALUES ('{0}','{1}','{2}')"
                , nhom.Maloai,nhom.Tenloai,nhom.MAU);
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
        public void Update(NhomMon nhom)
        {
            string SQL = string.Format("update NHOMMON set TENLOAI='{1}',MAUSAC='{2}'" +
                "where MALOAI='{0}'",nhom.Maloai,nhom.Tenloai,nhom.MAU);
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
        public void Delete(NhomMon nhom)
        {
            string SQL = string.Format("Delete  from NHOMMON where MALOAI='{0}'", nhom.Maloai);
            SqlConnection sqlConnection1 = sqlConnection();
            try
            {
                sqlConnection1.Open();
                SqlCommand sqlCommand = new SqlCommand(SQL, sqlConnection1);
                sqlCommand.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Vi Phạm Ràng Buộc");
                Console.WriteLine(ex.Message);
            }
            finally { sqlConnection1.Close(); }

        }

        public DataTable TimKiem(string nhom)
        {
            int a = 0;
            try
            {
                a = Convert.ToInt32(nhom);
            }
            catch (Exception) { a = 0; }

            
            string sql = string.Format("Select * from NHOMMON WHERE TENLOAI like N'{1}%'  OR MAUSAC like N'{2}%' OR MALOAI='{0}'",a,nhom,nhom);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection());
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            return dataTable;
        }


    }
}
