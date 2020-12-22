using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace DAL
{
   public class DALBan:DBconect
    {
 
        public DataTable SelectBan()
        {
            string sql = "Select * from Ban";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql,sqlConnection());
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            return dataTable;
        }
        public DataTable  TongSoBan()
        {
            string sql = "  select * from Ban where TrangThai not like N'%ng'";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection());
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            return dataTable;
        }
        public void InsertBan(Ban ban)
        {
            try
            {
                string sql = string.Format("INSERT INTO BAN (MABAN ,TENBAN,TRANGTHAI) VALUES ( '{0}','{1}','{2}')", ban.MaBan, ban.TenBan,"Đang Trống");
                SqlConnection sqlConnection1 = sqlConnection(); sqlConnection1.Open();
                SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection1);
                sqlCommand.ExecuteNonQuery();
                UpdeteBan(ban);
                sqlConnection1.Close();
                
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
        
        }
        public void UpdeteBan(Ban ban)
        {
            try
            { 
                string sql = "UPDATE BAN SET TENBAN=@TEN,TRANGTHAI =@trangthai where MABAN=@MA";
                SqlConnection sqlConnection1 = sqlConnection(); sqlConnection1.Open();
                SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection1);
                sqlCommand.Parameters.Add("@TEN", SqlDbType.NVarChar).Value = ban.TenBan;
                sqlCommand.Parameters.Add("@trangthai", SqlDbType.NVarChar).Value = ban.TrangThai;
                sqlCommand.Parameters.Add("@MA", SqlDbType.Int).Value = ban.MaBan;
                sqlCommand.ExecuteNonQuery();
                sqlConnection1.Close();
              
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public int DeleteBan(Ban ban)
        {
            SqlConnection sqlConnection1 = sqlConnection();
            try
            {
                sqlConnection1.Open();
                string sql = string.Format("delete Ban where MABAN = {0}", ban.MaBan);  
                SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection1);
               if (sqlCommand.ExecuteNonQuery()>0)
                { return 1; }
                sqlConnection1.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Vi Phạm Ràng Buộc");
            }
            finally { sqlConnection1.Close(); }
            return 0;
        }


    }
}
