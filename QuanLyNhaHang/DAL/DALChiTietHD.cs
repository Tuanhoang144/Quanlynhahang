using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DTO;

namespace DAL
{
   public class DALChiTietHD:DBconect
    {
        public DataTable  GetChiTietHD()
        {
            string sql = "SELECT * FROM ChiTietHD ";
            SqlDataAdapter da = new SqlDataAdapter(sql,sqlConnection());
            DataTable dataTable = new DataTable();
            da.Fill(dataTable);
            return dataTable;
      
        }

        public DataTable TimKiem(int timkiem)
        {
            string sql = string.Format("SELECT * FROM ChiTietHD WHERE ChiTietHD.MachitietHD={0}",timkiem);
            SqlDataAdapter da = new SqlDataAdapter(sql, sqlConnection());
            DataTable dataTable = new DataTable();
            da.Fill(dataTable);
            return dataTable;

        }



        public void Inset(ChiTietHoaDon chiTiet)
        {
            string SQL = string.Format("INSERT INTO ChitietHD (MACHITIETHD,MAHD,MAMON,SOLUONG,GIA)" +
                "  VALUES ('{0}','{1}','{2}','{3}','{4}')"
                ,chiTiet.MaCTHD,chiTiet.MAHD,chiTiet.Thucdon.MAMON,chiTiet.SOLUONG,chiTiet.Gia);
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
        public void Update(ChiTietHoaDon chiTiet)
        {
            string SQL = string.Format(" update ChitietHD set SOLUONG = '{1}', GIA= '{2}' " +
                "  where MACHITIETHD = '{0}' ", chiTiet.MaCTHD, chiTiet.SOLUONG,chiTiet.Gia);
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
        public void Update2(string MaHd)
        {
            string SQL = string.Format(" update ChitietHD set TrangThai ='Chưa Pha Chế'" +
                "  where MAHD ='{0}'", MaHd);
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


        public void Delete(string thucDon)
        {
            string SQL = string.Format("Delete  from ChiTietHD where MACHITIETHD='{0}'", thucDon);
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
