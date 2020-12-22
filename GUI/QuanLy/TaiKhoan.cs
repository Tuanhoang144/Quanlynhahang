using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCafe.Gul
{
    public partial class TaiKhoan : Form
    {
        private TrangChu trang;
        public TaiKhoan(TrangChu trangChu)
        {
            InitializeComponent();
            groupBox1.ForeColor = trangChu.ForeColor;
            this.BackColor = trangChu.BackColor;
            this.Font = this.Font;
            trang = trangChu;
            LoadDaTa();

        }

        private void LoadDaTa()
        {
            textBox1.Text = trang.nhanVien.MaNV1;
            textBox2.Text = trang.nhanVien.MaKhau1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dispose();
         
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox3.Text.Equals(textBox4.Text))
            {
                DALNhanvien nhanvien = new DALNhanvien();
                trang.nhanVien.MaKhau1 = textBox3.Text;
                trang.nhanVien.MaNV1 = textBox1.Text.Substring(6);
                nhanvien.Update(trang.nhanVien);
                trang.Load();
                
            }
            else
            {
                MessageBox.Show("Mật Khẩu Nhập Vào Không Trùng Khớp ");
            }
        }
    }
}
