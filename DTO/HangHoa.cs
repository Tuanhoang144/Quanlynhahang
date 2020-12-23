using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class HangHoa
    {
        private string MaSP;
        private string TenSP;
        private string Gia;
        public HangHoa()
        {
        }
        public HangHoa(string maSP, string tenSP, string gia)
        {
            MaSP1 = maSP;
            TenSP1 = tenSP;
            Gia1 = gia;
        }

        public string MaSP1 { get => MaSP; set => MaSP = value; }
        public string TenSP1 { get => TenSP; set => TenSP = value; }
        public string Gia1 { get => Gia; set => Gia = value; }
    }
}
