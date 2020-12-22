using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
  public  class NhanVien
    {
        private string MaNV;
        private string Ten;
        private string SDT;
        private string GioiTinh;
        private string MaKhau;
        private string Chucvu;
        public string MaNV1 { get => MaNV; set => MaNV = value; }
        public string Ten1 { get => Ten; set => Ten = value; }
        public string SDT1 { get => SDT; set => SDT = value; }
        public string GioiTinh1 { get => GioiTinh; set => GioiTinh = value; }
        public string MaKhau1 { get => MaKhau; set => MaKhau = value; }
        public string Chucvu1 { get => Chucvu; set => Chucvu = value.ToString();}
    }
}
