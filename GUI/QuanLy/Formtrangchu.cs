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

namespace GUI.QuanLy
{
    public partial class Formtrangchu : Form
    {
        

        public Formtrangchu(QuanLyCafe.Gul.TrangChu trangChu)
        {
            InitializeComponent();
            LoadData();
            Thongke();
            label2.Text += " " + trangChu.nhanVien.Ten1;
        }

        private void LoadData()
        {
            DALNhanvien dALNhanvien = new DALNhanvien();       
           label6.Text=""+ dALNhanvien.Select().Rows.Count;
            DALBan dALBan = new DALBan();
            label13.Text = "" + dALBan.SelectBan().Rows.Count;
            label15.Text = "" + dALBan.TongSoBan().Rows.Count;
        }

        public void Thongke()
        {
            int a = 0, b = 0;
           
            DateTime time1 = DateTime.Now;
            DateTime time2 = DateTime.Now;
            time1 = time1.AddMonths(-1);
            DALHoaDon dALHoaDon = new DALHoaDon();
       
                foreach (DataRow item in dALHoaDon.TimKiemHoaDon1(time1, time2).Rows)
                {

                ; try
                {
                    a = Convert.ToInt32(item["TONGTIEN"].ToString());
                    b = Convert.ToInt32(item["Giamgia"].ToString());
                }
                catch { }
                 
                }

                label7.Text = (a - b).ToString("N") + " VND ";


        }


    }
}
