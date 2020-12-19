using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
     public  class Ban
    {
        private int MABAN=1;
        private string TENBAN;
        private string TRANGTHAI;

        public int MaBan
        {
            get { return MABAN; }
            set { MABAN = value; }
        }
        public string TenBan
        {
            get { return TENBAN; }
            set { TENBAN = value; }
        }
        public string TrangThai
        {
            get { return TRANGTHAI; }
            set { TRANGTHAI = value; }
        }

    }
}
