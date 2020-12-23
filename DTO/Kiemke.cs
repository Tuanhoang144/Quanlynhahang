using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Kiemke
    {
        private string MaKK;
        private DateTime NgayKK;
        private string MaNV;
        public Kiemke()
        {
            
        }
        public Kiemke(string maKK, DateTime ngayKK, string maNV)
        {
            MaKK1 = maKK;
            NgayKK1 = ngayKK;
            MaNV1 = maNV;
        }

        public string MaKK1 { get => MaKK; set => MaKK = value; }
        public DateTime NgayKK1 { get => NgayKK; set => NgayKK = value; }
        public string MaNV1 { get => MaNV; set => MaNV = value; }
    }
}
