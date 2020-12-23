using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DonDatHang
    {
        private string MaDH;
        private string MaNCC;
        private int TongTien;
        private string MaNV;
        private string TRANGTHAI;
        public DonDatHang()
        {
            
        }
        
        public DonDatHang(string maDH, string maNCC, int tongTien, string maNV)
        {
            MaDH = maDH;
            MaNCC = maNCC;
            TongTien = tongTien;
            MaNV = maNV;
        }

        public DonDatHang(string maDH, string maNCC, int tongTien, string maNV, string tRANGTHAI)
        {
            MaDH = maDH;
            MaNCC = maNCC;
            TongTien = tongTien;
            MaNV = maNV;
            TRANGTHAI1 = tRANGTHAI;
        }

        public string MaDH1 { get => MaDH; set => MaDH = value; }
        public string MaNCC1 { get => MaNCC; set => MaNCC = value; }
        public int TongTien1 { get => TongTien; set => TongTien = value; }
        public string MaNV1 { get => MaNV; set => MaNV = value; }
        public string TRANGTHAI1 { get => TRANGTHAI; set => TRANGTHAI = value; }
    }
}
