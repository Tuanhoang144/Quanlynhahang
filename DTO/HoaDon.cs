using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{

    public class HoaDon
    {
        private string MaHD;
        private DateTime dateTime;
        private int TongTien=0;
        private int GiamGia;
       
        private Ban Ban;
        private List<ChiTietHoaDon> chiTietHoaDons;
        public HoaDon()
        {
            chiTietHoaDons = new List<ChiTietHoaDon>();
        }
        public string MAHD
        {
            get { return MaHD; }
            set { MaHD = value; }
        }
        public int TONGTIEN()
        {
        
            return (TinhTongTien()-((GiamGia)));
        }
        public int TinhTongTien()
        {
            TongTien = 0;
            foreach (ChiTietHoaDon item in chiTietHoaDons)
            {
                TongTien += item.Gia;
             
            }
            return TongTien;
        }
        
      
        public int GIAMGIA
        {
            get { return GiamGia; }

            set { GiamGia = value; }
        }
        public int TinhTienGiam( int n)
        {
       
            int a = n % 100;
            int b = n / 100;
            float t = float.Parse(b + "," + a);
            double w = TONGTIEN()* double.Parse(b + "." + a);
            GIAMGIA = (int)w;
            return TONGTIEN();

        }

        public DateTime NgayDen
        {
            get { return dateTime; }
            set { dateTime = value; }
        }
        public Ban BAN
        {
            get { return Ban; }
            set { Ban = value; }
        }
        public List<ChiTietHoaDon> ChitietHD{
              get
            {
                return chiTietHoaDons;
            }
         
         }


    }
}
