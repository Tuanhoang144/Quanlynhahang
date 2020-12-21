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
namespace Nhanvien
{
  
    public partial class ChonMon : Form
    {
        int Check=0;
        private DatMon datMon;
        private int Sl = 1;
        private ChiTietHoaDon ChiTietHoaDon;
        private int Ma;
        private DALThucDon DALThucDon;
        private DALChiTietHD chiTietHD;
        public ChonMon(string Ma, DatMon datMon)
        {
            Console.WriteLine(Ma);
            InitializeComponent();
            this.ChiTietHoaDon = new ChiTietHoaDon();
            this.ChiTietHoaDon.MaCTHD = Ma;
            textBox2.Text = ""+Sl;
            button3.Text = "Thêm";
            this.datMon = datMon;
            LoandDatabase(Ma);
            LoandCTHD(Ma);

        }
  
        private void LoandCTHD(string ma)
        {
            chiTietHD = new DALChiTietHD();
            DataTable dataTable =chiTietHD.TimKiem(Convert.ToInt32(ma));
            foreach (DataRow item in dataTable.Rows)
            {
                ma =item["MAMON"].ToString();
                Ma = Convert.ToInt32(item["MachitietHD"].ToString());
                LoandDatabase(ma);
                Sl = Convert.ToInt32(item["SOLUONG"].ToString());
                textBox2.Text = ""+Sl;
                button3.Text = "Lưu";
                Check = Sl;
            }
            
        }

        private void LoandDatabase(string ma)
        {
            DALThucDon = new DALThucDon();
            DataTable dataTable = DALThucDon.TimKiemThucDon1(ma);
            foreach (DataRow item in dataTable.Rows)
            {
              this.ChiTietHoaDon.Thucdon  = new ThucDon();
             this.ChiTietHoaDon.Thucdon.MAMON = Convert.ToInt32(item["MAMON"].ToString());
              this.ChiTietHoaDon.Thucdon.DONGIA= Convert.ToInt32(item["DONGIA"].ToString());
                this.ChiTietHoaDon.Thucdon.tenmon = item["TENMON"].ToString();
                this.ChiTietHoaDon.Thucdon.DVT = item["DVT"].ToString();
                textBox1.Text = this.ChiTietHoaDon.Thucdon.tenmon;
            }
         
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Sl = Convert.ToInt32(textBox2.Text);
            if (Sl > 0)
            {
                Sl++;
                textBox2.Text = "" + Sl;
            } 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Sl = Convert.ToInt32(textBox2.Text);
            if (Sl > 0)
            {
                Sl--;
                textBox2.Text = "" + Sl;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (button3.Text.Equals("Thêm"))
            {
                this.ChiTietHoaDon.SOLUONG = Sl;
                datMon.ADDMon(this.ChiTietHoaDon);
            }
            else
            {
              this.ChiTietHoaDon.SOLUONG = Sl;
              chiTietHD.Update(ChiTietHoaDon);
              datMon.LoadData();
              datMon.LoadhoaDơn();
            }
            if (Check < Sl)
            {
              //  this.ChiTietHoaDon.SOLUONG = Sl-Check;
                //datMon.PhaChe(this.ChiTietHoaDon);
            }
            Dispose();
        }

        private void btndatban_Click(object sender, EventArgs e)
        {
            if (button3.Text.Equals("Thêm"))
            {
                this.ChiTietHoaDon.SOLUONG = Sl;
                datMon.ADDMon(this.ChiTietHoaDon);
            }
            else
            {
                this.ChiTietHoaDon.SOLUONG = Sl;
                chiTietHD.Update(ChiTietHoaDon);
                datMon.LoadData();
                datMon.LoadhoaDơn();
            }
            if (Check < Sl)
            {
                //  this.ChiTietHoaDon.SOLUONG = Sl-Check;
                //datMon.PhaChe(this.ChiTietHoaDon);
            }
            Dispose();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
