using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
  public  class NhomMon
    {
        private int MaLoai;
        private string TenLoai;
        private string MauSac;
        
        public int Maloai
        {
            get
            {
                return MaLoai;
            }
            set
            {
                MaLoai = value;
            }
        }
        public string Tenloai
        {
            get
            {
                return TenLoai;
            }
            set
            {
                TenLoai = value;
            }
        }

        public string MAU
        {
            get
            {
                return MauSac;
            }
            set
            {
                MauSac = value;
            }
        }
        public string [] RGB()
        {
            string[] RGB = MauSac.Split(',');
            return RGB;
          
        }
    }
}
