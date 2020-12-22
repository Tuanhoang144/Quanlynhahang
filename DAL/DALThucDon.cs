using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DTO;
using System.Windows.Forms;

namespace DAL
{
    public class DALThucDon:DBconect
    {
       public   DataTable SelectThucDon()
        {
            string sql = "Select * from ThucDon";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection());
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            return dataTable;
        }
        public DataTable TongSoMon()
        {
            string sql = "Select COUNT(*) AS SOLUONG from ThucDon";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection());
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            return dataTable;
        }


        public DataTable SelectThucDon1(DateTime time1, DateTime time2)
        {
            string Fomat = "yyyy-MM-dd ";
            string sql = string.Format("SELECT HD.MaMon,TenMon,Maloai,SUM(SOLUONG) AS SOLUONG ,SUM(GIA) AS DOANHTHU" +
                " FROM ThucDon ,ChiTietHD HD " +
                " WHERE ThucDon.MaMon = HD.MaMon AND HD.MaHD IN( " +
                    " select HD.MaHD from HoaDon " +
                   " where GioDen >= convert(DATETIME, '{0}', 126) " +
                     " and GioDen <= convert(DATETIME, '{1}', 126))"
                     + " GROUP BY HD.MaMon, TenMon,Maloai",time1.ToString(Fomat),time2.ToString(Fomat));
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection());
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            return dataTable;
        }

        public DataTable SelectThucDon2(DateTime time1, DateTime time2)
        {
            string Fomat = "yyyy-MM-dd ";
            string sql = string.Format(" SELECT  SUM(SOLUONG) AS SOLUONG FROM CHITIETHD HD  " +
                              "  WHERE HD.MaHD IN(  " +
                     "  select MAHD from HoaDon " +
                       " where  GioDen>= convert(DATETIME,'{0}',126)  " +
                         " and GioDen<= convert(DATETIME,'{1}',126) " +
                                " ) ", time1.ToString(Fomat), time2.ToString(Fomat));
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection());
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            return dataTable;
        }

        public void InsetThucDon(ThucDon thucDon)
        {
            string SQL = string.Format("INSERT INTO THUCDON (MAMON,TENMON,MALOAI,DONGIA,DVT)" +
                "  VALUES ('{0}','{1}','{2}','{3}','{4}')"
                ,thucDon.MAMON, thucDon.tenmon, thucDon.NhomMon.Maloai, thucDon.DONGIA, thucDon.DVT);
            SqlConnection sqlConnection1 = sqlConnection();
            try
            {
                sqlConnection1.Open();
                SqlCommand sqlCommand = new SqlCommand(SQL,sqlConnection1);
                sqlCommand.ExecuteNonQuery();
            }catch( SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { sqlConnection1.Close(); }

        }

        public void Update(ThucDon thucDon)
        {
            string SQL = string.Format("update thucdon set TENMON='{1}',MALOAI='{2}',DONGIA='{3}',DVT='{4}'" +
                "where MAMON='{0}'",thucDon.MAMON, thucDon.tenmon, thucDon.NhomMon.Maloai, thucDon.DONGIA, thucDon.DVT);
            SqlConnection sqlConnection1 = sqlConnection();
            try
            {
                sqlConnection1.Open();
                SqlCommand sqlCommand = new SqlCommand(SQL, sqlConnection1);
                sqlCommand.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { sqlConnection1.Close(); }

        }

        public void Delete(ThucDon thucDon)
        {
            string SQL = string.Format("Delete  from thucdon where MAMON='{0}'",thucDon.MAMON);
            SqlConnection sqlConnection1 = sqlConnection();
            try
            {
                sqlConnection1.Open();
                SqlCommand sqlCommand = new SqlCommand(SQL, sqlConnection1);
                sqlCommand.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { sqlConnection1.Close(); }

        }

        public void TiemKiem(string ten)
        {
            
        }

        public DataTable TimKiemThucDon(string Name)
        {
            string sql = string.Format(@"  SELECT * FROM THUCDON
                                            WHERE MALOAI IN (
                                       SELECT MALOAI FROM NhomMon
	                                          WHERE TenLoai LIKE N'{0}%')", Name);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection());
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            return dataTable;
        }

        public DataTable TimKiemThucDon2(string Name)
        {
            string sql = string.Format(@"  SELECT * FROM THUCDON
                                            WHERE MALOAI ={0}",Name);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection());
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            return dataTable;
        }
        public DataTable TimKiemThucDon1(string ten)
        { int So = 0;
            try
            {
                So = Convert.ToInt32(ten);
            } catch (Exception){ So = 0; }
            string sql = string.Format(@"Select * from ThucDon
                      WHERE TENMON LIKE N'{1}%' OR MALOAI={2} OR DONGIA<={3} OR DVT LIKE N'{4}%' OR MAMON = {0}",So,ten,So,So,ten);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection());
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            return dataTable;
        }
    }
}
