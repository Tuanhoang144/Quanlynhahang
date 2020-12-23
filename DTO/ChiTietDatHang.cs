using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ChiTietDatHang
    {
        private string MaDH;
        private string MaSP;
        private int SoLuong;
        private string DVT;
        public ChiTietDatHang()
        {
            
        }

        public ChiTietDatHang(string maDH, string maSP, int soLuong, string dVT)
        {
            MaDH = maDH;
            MaSP = maSP;
            SoLuong = soLuong;
            DVT = dVT;
        }

        public string MaDH1 { get => MaDH; set => MaDH = value; }
        public string MaSP1 { get => MaSP; set => MaSP = value; }
        public int SoLuong1 { get => SoLuong; set => SoLuong = value; }
        public string DVT1 { get => DVT; set => DVT = value; }
    }
}
