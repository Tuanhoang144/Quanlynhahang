using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
  public  class ChiTietHoaDon
    {
        private string MaHD;
        private ThucDon ThucDon;
        private string MACTHD;
        private int Soluong;
        
        public string MAHD
        {
            get { return MaHD; }
            set { MaHD = value; }
        }
        public string MaCTHD
        {
            get { return MACTHD; }
            set { MACTHD = value; }
        }
        public int SOLUONG
        {
            get { return Soluong; }
            set { Soluong = value; }
        }
        public ThucDon Thucdon
        {
            get { return ThucDon; }
            set { ThucDon = value; }
        }
        public int Gia
        {
            get { return(ThucDon.DONGIA * Soluong); }
        }
    }
}
