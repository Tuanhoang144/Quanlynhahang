using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ChiTietKK
    {
        private string MaKK;
        private string MaSP;
        private string SoLuong;
        private string DVT;
        public ChiTietKK() { }
        public ChiTietKK(string maKK, string maSP, string soLuong, string dVT)
        {
            MaKK1 = maKK;
            MaSP1 = maSP;
            SoLuong1 = soLuong;
            DVT1 = dVT;
        }

        public string MaKK1 { get => MaKK; set => MaKK = value; }
        public string MaSP1 { get => MaSP; set => MaSP = value; }
        public string SoLuong1 { get => SoLuong; set => SoLuong = value; }
        public string DVT1 { get => DVT; set => DVT = value; }
    }
}
