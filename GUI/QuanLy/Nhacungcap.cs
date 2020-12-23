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
    public partial class Nhacungcap : UserControl
    {
        public Nhacungcap()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            NhaCungCap Nhacungcap = new NhaCungCap();
            Nhacungcap.MaNCC1 = textBox1.Text.ToString();
            Nhacungcap.Ten1 = textBox2.Text.ToString();
            Nhacungcap.DiaChi1 = textBox3.Text.ToString();
            Nhacungcap.SDT1 = textBox4.Text.ToString();
            DAL.DALNhaCC ctkk = new DAL.DALNhaCC();
            ctkk.InsetNhaCC(Nhacungcap);
        }
    }
}
