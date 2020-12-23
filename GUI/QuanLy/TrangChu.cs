using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using DTO;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using GUI;
using Guna.UI2.WinForms;
using Nhanvien;
using GUI.QuanLy;

namespace QuanLyCafe.Gul
{
    public partial class TrangChu :Form
    {
        int PanelWidth;
        bool isCollapsed;
        private  DTO.Ban ban1;
        
  
        private GiaoDIen giaoDIen;
        private DTO.HoaDon HoaDon;
        private DALHoaDon hoaDon1;
        public DTO.NhanVien nhanVien;
    

        public TrangChu(DTO.NhanVien nhanVien)
        {
            InitializeComponent();
            giaoDIen = new GiaoDIen();
          
            this.nhanVien = nhanVien;
            //    timer1.Start();
            timertime.Start();
            PanelWidth = panelLeft.Width;
            isCollapsed = false;
            //  Size1 = tabControl1.Size;
            label13.Text += " " +nhanVien.Ten1;
            Formtrangchu trangchu = new Formtrangchu(this);

            AddForm(trangchu);
           

        }

   
        private void AddForm(Form f)
        {
            this.panel2.Controls.Clear();
            f.TopLevel = false;
            f.AutoScroll = true;
            f.FormBorderStyle = FormBorderStyle.None;
            f.Dock = DockStyle.Fill;
            this.Text = f.Text;
            this.panel2.Controls.Add(f);
            f.Show();
        }

        internal void Load()
        {
            Formtrangchu trangchu = new Formtrangchu(this);

            AddForm(trangchu);
        }

        private void btndanhmuc_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            QuanLy quanLy = new QuanLy(this);
            quanLy.TopLevel = false;
            quanLy.BackColor = this.BackColor;
            quanLy.Font = this.Font;
      
            panel2.Controls.Add(quanLy);
            quanLy.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            ThongKe thongKe = new ThongKe(this);
            thongKe.TopLevel = false;
            thongKe.BackColor = this.BackColor;
            thongKe.Font=this.Font;
            panel2.Controls.Add(thongKe);
            thongKe.Show();
           
        }

    
        private void TrangChu_Load(object sender, EventArgs e)
        {
          
         //   timer1.Start();
         


        }




   

      
        private void TrangChu_FormClosed(object sender, FormClosedEventArgs e)
        {
           
            this.Dispose();
            
        }
       
      

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btndanhmuc_Click_1(object sender, EventArgs e)
        {
            if (nhanVien.Chucvu1.Contains("Quan Ly"))
            {
                QuanLy quanLy = new QuanLy(this);
                AddForm(quanLy);
            }
            else
            {
                MessageBox.Show("Nhân Viên Không Được Quyền Sử Dụng Chức Năng Này");
            }

        
          
        }

      

        
        private void btnthongke_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            ThongKe thongKe = new ThongKe(this);
            thongKe.TopLevel = false;
            thongKe.BackColor = this.BackColor;
            thongKe.Font = this.Font;
           // CapNhatPanel(thongKe.Size);
          
            panel2.Controls.Add(thongKe);
            thongKe.Show();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            BanHang  thongKe = new BanHang(nhanVien);
            thongKe.TopLevel = false;
            thongKe.BackColor = this.BackColor;
            thongKe.Font = this.Font;
            // CapNhatPanel(thongKe.Size);

            panel2.Controls.Add(thongKe);
            thongKe.Show();


            // tabControl2.SelectedIndex = 2;

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
            
      
            
        }

      
        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void timertime_Tick(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            labelTime.Text = dt.ToString("HH:MM:ss");
        }

      
        private void timer1_Tick_2(object sender, EventArgs e)
        {
            if (isCollapsed)
            {
                panelLeft.Width = panelLeft.Width + 50;
                if (panelLeft.Width >= PanelWidth)
                {
                    timer1.Stop();
                    isCollapsed = false;
                    //   guna2CustomGradientPanel1.Visible = true;
                    this.Refresh();
                }
            }
            else
            {
                panelLeft.Width = panelLeft.Width - 50;
                if (panelLeft.Width <= 59)
                {
                    timer1.Stop();
                    isCollapsed = true;
                    // guna2CustomGradientPanel1.Visible = false;
                    this.Refresh();
                }
            }
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void btntrangchu_Click(object sender, EventArgs e)
        {

        }

        private void btntrangchu_Click_1(object sender, EventArgs e)
        {
            
          
            Formtrangchu trangchu = new Formtrangchu(this);

            AddForm(trangchu);

        }

        private void mauNênToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

        }

        private void kiêuChưToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void mauChưToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void đôiMâtKhâuToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void khôiPhucCaiĐătGôcToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void labelTime_Click(object sender, EventArgs e)
        {

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void pnltrangchu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TaiKhoan taikhoan = new TaiKhoan(this);
            AddForm(taikhoan);
        }

        private void đăngXuâToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            
            panel2.Controls.Clear();
            khohang thongKe = new khohang(nhanVien);
            thongKe.BackColor = this.BackColor;
            thongKe.Font = this.Font;
            // CapNhatPanel(thongKe.Size);
            panel2.Controls.Add(thongKe);
            thongKe.Show();
        }
    }
}
