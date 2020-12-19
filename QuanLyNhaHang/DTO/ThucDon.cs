using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{


public  class ThucDon
    {
        private int MaMon;
        private string TenMon;
       private NhomMon nhomMon =new NhomMon();
        private string dvt;
        private int DonGia;

        public string tenmon
        {
            get { return TenMon; }
            set { TenMon = value; }
        }


        public string DVT
        {
            get { return dvt; }
            set { dvt = value; }
        }

        public int MAMON
        {
            get { return MaMon; }
            set { MaMon = value; }
        }
        public int DONGIA
        {
            get { return DonGia; }
            set { DonGia = value; }
        }
        public NhomMon NhomMon
        {
            get { return nhomMon; }
            set { nhomMon = value; }
        }

    }
   
    

}

