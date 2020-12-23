using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class phieukiemke : Form
    {
        public DTO.NhanVien nhanVien;
        public phieukiemke(DTO.NhanVien nhanvien)
        { 
            InitializeComponent();
            this.nhanVien = nhanvien;
          
        }

        
        private void button1_Click(object sender, EventArgs e)
        {

           
            DTO.Kiemke ChiTietKK = new DTO.Kiemke();
            ChiTietKK.MaKK1 = textBox2.Text.ToString();
            ChiTietKK.NgayKK1 = DateTime.Now;
            ChiTietKK.MaNV1 = nhanVien.MaNV1.ToString();
            DAL.DALKiemKe ctkk = new DAL.DALKiemKe();
            ctkk.InsetKiemKe(ChiTietKK);
            MessageBox.Show("THÊM THÀNH CÔNG ");
        }
    }
}
