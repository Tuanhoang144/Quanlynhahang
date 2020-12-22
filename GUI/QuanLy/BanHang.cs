using DAL;
using Nhanvien;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.QuanLy
{
    public partial class BanHang : Form
    {

        private Button[] buttona = new Button[200];
        private DALBan dALBan;
        public DTO.NhanVien nhanVien;

        public BanHang(DTO.NhanVien nhanvien )
        {
            InitializeComponent();
            TaoBan();
            this.nhanVien = nhanvien;
        }


        public void TaoBan()
        {
            int i = 0;
            flowLayoutPanel1.Controls.Clear();
            dALBan = new DALBan();
            DataTable table = dALBan.SelectBan();
            foreach (DataRow item in table.Rows)
            {
                Button button = new Button();
                button.Text = string.Format("" + item["TENBAN"].ToString());
                button.Name = string.Format("" + item["MABAN"].ToString());
                button.Tag = string.Format("" + item["TRANGTHAI"].ToString());
                button.Size = new Size(60,50);
                flowLayoutPanel1.Controls.Add(button);
                button.Click += new EventHandler(SuLySuKien);
                buttona[i] = button;
                i++;
                string TinhTrang = item["TRANGTHAI"].ToString();
                if (TinhTrang.Contains("Tr"))
                {
                    button.BackColor = Color.FromArgb(0, 118, 212); 
                }
                else if (TinhTrang.Contains("Đang P"))
                {
                    button.BackColor = Color.Red;
                }
                else
                {
                    button.BackColor = Color.FromArgb(22, 152, 126);
                }
            }

        }

        private void SuLySuKien(object sender, EventArgs e)
        {
            int i = 0;
            DTO.Ban ban1 = new DTO.Ban();
            ban1.MaBan = Convert.ToInt32(((Button)sender).Name);
            ban1.TenBan = "" + ((Button)sender).Text;
            ban1.TrangThai = "" + ((Button)sender).Tag;
            panel1.Controls.Clear();
            DALHoaDon hoaDon = new DALHoaDon();
            DataTable dataTable = hoaDon.TimKiemHoaDon(ban1.MaBan);
            foreach (DataRow item in dataTable.Rows)
            {
                DatMon damon = new DatMon(ban1, this, 2, nhanVien);
                damon.TopLevel = false;
                panel1.Controls.Add(damon);
                damon.Show(); i++;
                break;
            }
            if (i == 0)
            {
                DatMon damon = new DatMon(ban1, this, 0, nhanVien);
                damon.TopLevel = false;
                panel1.Controls.Add(damon);
                damon.Show();
            }
        }
        private void UpDateBan(DTO.Ban ban1)
        {
            if (ban1.TrangThai.Contains("Tr"))
            {
                ban1.TrangThai = "Đang Đặt";
                dALBan.UpdeteBan(ban1);
                TaoBan();
            }
            else if (ban1.TrangThai.Contains("Đang Đ"))
            {
                ban1.TrangThai = " Đang Trống ";
                dALBan.UpdeteBan(ban1);
                TaoBan();
            }
            else
            {
                dALBan.UpdeteBan(ban1);
                TaoBan();
            }
        }

        internal void refresh()
        {
            TaoBan();
        }
    }
}
