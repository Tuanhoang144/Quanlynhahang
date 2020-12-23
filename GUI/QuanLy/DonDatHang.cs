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
    public partial class DonDatHang : Form
    {
        public DTO.NhanVien nhanVien;
        public DonDatHang(DTO.NhanVien nhanvien)
        {
            InitializeComponent(); laydl();
            this.nhanVien = nhanvien;
        }
        public void laydl()
        {
            comboBox1.Items.Clear();
            DAL.DALNhaCC kk = new DAL.DALNhaCC();
            DataTable data1 = kk.SelectNhaCC();
            foreach (DataRow item in data1.Rows)
            {
                comboBox1.Items.Add(item["TennNCC"].ToString());

            }
            

        }
        public String laymanhacc(String s)
        {
            string a = null;
            DAL.DALNhaCC kk = new DAL.DALNhaCC();
            DataTable data1 = kk.Selectmanhacctheoten(s);
            foreach (DataRow item in data1.Rows)
            {
                a = item["MaNCC"].ToString();

            }
            return a;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string x = laymanhacc(comboBox1.Text.ToString());
            DTO.DonDatHang DonDatHang = new DTO.DonDatHang();
            DonDatHang.MaDH1 = textBox2.Text.ToString();
            DonDatHang.MaNCC1 = x;
            DonDatHang.TongTien1 = 0;
            DonDatHang.MaNV1 = nhanVien.MaNV1.ToString();
            DAL.DALDondathang ctkk = new DAL.DALDondathang();
            ctkk.InsetDonDatHang(DonDatHang);
            MessageBox.Show("THÊM THÀNH CÔNG");
        }

    }
}
