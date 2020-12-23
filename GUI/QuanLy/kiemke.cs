using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
namespace GUI.QuanLy
{
    public partial class kiemke : UserControl
    {
        public DTO.NhanVien nhanVien;
        public kiemke(DTO.NhanVien nhanvien)
        {
            InitializeComponent();
            laydl();
           
            this.nhanVien = nhanvien;
        }
        public void laydl()
        {
            DAL.DALKiemKe kk = new DAL.DALKiemKe();
            DataTable data1 = kk.SelectKiemKe();
            foreach (DataRow item in data1.Rows)
            {
                cbxmakk.Items.Add(item["MaKK"].ToString());
               
            }
            DAL.DALHangHoa sp = new DAL.DALHangHoa();
            DataTable data2 = sp.SelectHanghoa();
            foreach (DataRow item in data2.Rows)
            {
                cbxtenmh.Items.Add(item["TenSP"].ToString());

            }

        }
        public String laymasp(String s)
        {
            string a=null;
            DAL.DALHangHoa kk = new DAL.DALHangHoa();
            DataTable data1 = kk.SelectmaHanghoatheoten(s);
            foreach (DataRow item in data1.Rows)
            {
                 a= item["MaSP"].ToString();

            }
            return a;

        }
        private void button1_Click(object sender, EventArgs e)
        {
            string x = laymasp(cbxtenmh.Text.ToString());
            ChiTietKK ChiTietKK = new ChiTietKK();
            ChiTietKK.MaKK1 = cbxmakk.Text.ToString();
            ChiTietKK.MaSP1 = x;
            ChiTietKK.SoLuong1 = textBox1.Text.ToString();
            ChiTietKK.DVT1 = textBox2.Text.ToString();
            DAL.DALChiTietKK ctkk = new DAL.DALChiTietKK();
            ctkk.InsetCTKiemKe(ChiTietKK);
        }

        

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            phieukiemke KIEMKE = new phieukiemke(nhanVien);
            KIEMKE.ShowDialog();
        }
    }
}
