using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NhaCungCap
    {
        private string MaNCC;
        private string Ten;
        private string DiaChi;
        private string SDT;
        public NhaCungCap()
        {
           
        }
        public NhaCungCap(string maNCC, string ten, string diaChi, string sDT)
        {
            MaNCC1 = maNCC;
            Ten1 = ten;
            DiaChi1 = diaChi;
            SDT1 = sDT;
        }

        public string MaNCC1 { get => MaNCC; set => MaNCC = value; }
        public string Ten1 { get => Ten; set => Ten = value; }
        public string DiaChi1 { get => DiaChi; set => DiaChi = value; }
        public string SDT1 { get => SDT; set => SDT = value; }
    }
}
