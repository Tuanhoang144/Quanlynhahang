using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyCafe.Gul;
using DTO;
using DAL;
using System.Threading;
namespace GUI.Gul
{
    public partial class Form1 : Form
    {
        public DTO.NhanVien nhanVien;
        private DAL.DALNhanvien NhanvienDAL;
        public int Check { get; set; }
        private List<DTO.NhanVien> ListNhanVien;
        public Form1()
        {
            InitializeComponent();
            Check = 0;
            textBox2.UseSystemPasswordChar = true;
            LoadData();

        }

        private void LoadData()
        {
           
            NhanvienDAL = new DALNhanvien();
            ListNhanVien = new List<DTO.NhanVien>();
                
            foreach (DataRow item in NhanvienDAL.Select().Rows)
            {
                nhanVien = new DTO.NhanVien();
                nhanVien.MaNV1 = item["Manv"].ToString();
                nhanVien.Ten1 = item["Ten"].ToString();
                nhanVien.Chucvu1 = item["Chucvu"].ToString();
                nhanVien.MaKhau1= item["Matkhau"].ToString();
                nhanVien.SDT1 = item["Gmail"].ToString();
                nhanVien.GioiTinh1 = item["Gioitinh"].ToString();
                ListNhanVien.Add(nhanVien);
            }        
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

   


        private void buttonX1_Click(object sender, EventArgs e)
        {
            int a = 0, b = 0;
            if (textBox1.Text.Length == 0)
            {
                MessageBox.Show("Bạn Vui Lòng Nhập Tên Đăng Nhập ");
                textBox1.Focus();
            }
            else if(textBox2.Text.Length==0)
            {
                MessageBox.Show("Bạn Vui Lòng Nhập Mật Khẩu ");
                textBox2.Focus();
            }
            if (textBox1.Text.Length > 0 && textBox2.Text.Length > 0)
            {
                foreach (DTO.NhanVien item in ListNhanVien)
                {
                    if (textBox1.Text.Equals(item.MaNV1))
                    {
                        a++;
                        if (textBox2.Text.Equals(item.MaKhau1))
                        {
                            b++;
                            if (item.Chucvu1.Equals("Quản Lý"))
                            {
                                nhanVien = item;
                                Check = 1;
                                this.Dispose();
                            }
                            else
                            {
                                nhanVien = item;
                                Check = 2;
                                this.Dispose();
                            }
                            break;
                        } 
                    }
                }
                if (a == 0)
                {
                    label2.Text = "Tên Đăng Nhập Không Đúng";
                    textBox1.Focus();
                }
                else if (b == 0)
                {
                    label2.Text = "Mật Khẩu Đăng Nhập Không Đúng";
                    textBox2.Focus();
                
                 }
                 
            }


       
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        bool check = true;
        private void labelX3_Click(object sender, EventArgs e)
        {
            if (check == true)
            {
                labelX3.Symbol = "";
                textBox2.UseSystemPasswordChar = false;
                check = false;
            }
            else
            {
                labelX3.Symbol = "";
                textBox2.UseSystemPasswordChar = true;
                check = true;
            }
            string a = textBox2.Text;
            textBox2.Text = textBox2.Text;
           
        }

        private void line1_Click(object sender, EventArgs e)
        {

        }

        private void panelEx1_Click(object sender, EventArgs e)
        {

        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            TextBox textBox = new TextBox();
            textBox.Size = new Size(40, 20);
            MessageBox.Show(""+textBox);
            Gmail gmail = new Gmail();
            Thread thread = new Thread(()=>
            {
                   gmail.Send("phamtruong0305@gmail.com");
            });
            thread.IsBackground = true;
            thread.Start();
            MessageBox.Show("Mật Khẩu Của Bạn Đã Được Gửi Vê Gmail \n Bạn Vui Lòng Kiểm Tra lại","Thông Báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
    }
}
