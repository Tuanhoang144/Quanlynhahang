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
   public class DALHoaDon:DBconect
    {
        public DataTable GetHD()
        {
            string sql = "SELECT * FROM HOADON ";
            SqlDataAdapter da = new SqlDataAdapter(sql, sqlConnection());
            DataTable dataTable = new DataTable();
            da.Fill(dataTable);
            return dataTable;
            
        }


        public void InsetHD(HoaDon hoaDon ,string MANV)
        {
            string Fomat = "yyyy-MM-dd HH:mm tt";
            string SQL = string.Format("INSERT INTO HOADON (MAHD,GIAMGIA,MABAN,GIODEN,TONGTIEN,TRANGTHAI,MaNV)" +
                " VALUES ('{0}','{1}','{2}','{3}','{4}','{5}',{6})"
                ,hoaDon.MAHD, hoaDon.GIAMGIA,hoaDon.BAN.MaBan,hoaDon.NgayDen.ToString(Fomat),hoaDon.TONGTIEN(),1,MANV);
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

        public DataTable TimKiemHoaDon1(DateTime time1, DateTime time2)
        {
            string Fomat = "yyyy-MM-dd";
            string sql =string.Format("select sum(TongTien) as Tongtien ,sum(GiamGia) as GiamGia from HoaDon "+
        " where  GioDen >= convert(DATETIME, '{0}', 126) "+
      " and GioDen <= convert(DATETIME, '{1}', 126)", time1.ToString(Fomat), time2.ToString(Fomat));
            SqlDataAdapter da = new SqlDataAdapter(sql, sqlConnection());
            DataTable dataTable = new DataTable();
            da.Fill(dataTable);
            return dataTable;
        }


        public DataTable TongSoHd(DateTime time1, DateTime time2)
        {
            string Fomat = "yyyy-MM-dd";
            string sql = string.Format("select COUNT(*) as SOLUONG from HoaDon " +
        " where  GioDen >= convert(DATETIME, '{0}', 126) " +
      " and GioDen <= convert(DATETIME, '{1}', 126)", time1.ToString(Fomat), time2.ToString(Fomat));
            SqlDataAdapter da = new SqlDataAdapter(sql, sqlConnection());
            DataTable dataTable = new DataTable();
            da.Fill(dataTable);
            return dataTable;
        }

        public object TimKiemHoaDon(DateTime time1, DateTime time2)
        {
            string Fomat = "yyyy-MM-dd ";
            string sql = string.Format("select * from HoaDon " +
                          " where  GioDen >= convert(DATETIME, '{0}', 126) " +
                            "  and GioDen <= convert(DATETIME, '{1}', 126) ", time1.ToString(Fomat), time2.ToString(Fomat));
            SqlDataAdapter da = new SqlDataAdapter(sql, sqlConnection());
            DataTable dataTable = new DataTable();
            da.Fill(dataTable);
            return dataTable;
        }

        public DataTable TimKiemHoaDon(int maBan)
        {
            string sql =string.Format(" SELECT *" +
                " from ThucDon DT,ChiTietHD CT,HoaDon HD,Ban " +
                "WHERE DT.MaMon=CT.MaMon AND HD.TrangThai=1 AND Ban.MABAN=HD.MaBan " +
                "AND CT.MaHD=HD.MaHD AND HD.MaBAN={0} ",maBan);
            SqlDataAdapter da = new SqlDataAdapter(sql, sqlConnection());
            DataTable dataTable = new DataTable();
            da.Fill(dataTable);
            return dataTable;
        }

        public void InsetHD1(HoaDon hoaDon)
        {
            string SQL = string.Format("INSERT INTO HOADON (MAHD)" +
                " VALUES ('{0}')"
                , hoaDon.MAHD);
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


        public void Update(HoaDon hoaDon)
        {
            string SQL = string.Format("update hoadon set GIAMGIA='{1}',MABAN='{2}',TONGTIEN='{3}',TRANGTHAI='{4}'" +
                "where MAHD='{0}'",hoaDon.MAHD, hoaDon.GIAMGIA, hoaDon.BAN.MaBan, hoaDon.TONGTIEN(),hoaDon.BAN.TrangThai);
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
        public void Delete(int hoaDon)
        {
            string SQL = string.Format("Delete  from Hoadon where MAHD='{0}'",hoaDon);
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
