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
    public partial class ChitietDondathang : UserControl
    {
        public DTO.NhanVien nhanVien;
        public ChitietDondathang(DTO.NhanVien nhanvien)
        {
            InitializeComponent();
            laydl();
            this.nhanVien = nhanvien;
        }
        public void laydl()
        {
            DAL.DALDondathang kk = new DAL.DALDondathang();
            DataTable data1 = kk.SelectDonDatHang();
            foreach (DataRow item in data1.Rows)
            {
                comboBox2.Items.Add(item["MaDH"].ToString());

            }
            DAL.DALHangHoa sp = new DAL.DALHangHoa();
            DataTable data2 = sp.SelectHanghoa();
            foreach (DataRow item in data2.Rows)
            {
                comboBox1.Items.Add(item["TenSP"].ToString());

            }
            

        }
        public String laymasp(String s)
        {
            string a = null;
            DAL.DALHangHoa kk = new DAL.DALHangHoa();
            DataTable data1 = kk.SelectmaHanghoatheoten(s);
            foreach (DataRow item in data1.Rows)
            {
                a = item["MaSP"].ToString();

            }
            return a;

        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            string x = laymasp(comboBox1.Text.ToString());
            ChiTietDatHang ChiTietdh = new ChiTietDatHang();
            ChiTietdh.MaDH1 = comboBox2.Text.ToString();
            ChiTietdh.MaSP1 = x;
            ChiTietdh.SoLuong1 = Convert.ToInt32(textBox1.Text.ToString());
            ChiTietdh.DVT1 = textBox2.Text.ToString();
            DAL.DALChitietdathang ctkk = new DAL.DALChitietdathang();
            ctkk.InsetHanghoa(ChiTietdh);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            DonDatHang dlg2 = new DonDatHang(nhanVien);
            dlg2.ShowDialog();
        }
    }
}
