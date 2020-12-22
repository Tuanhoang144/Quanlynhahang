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

namespace QuanLyCafe.Gul
{
    public partial class NhomMau : Form
    {
        private QuanLy quanLy;
        private NhomMon nhomMon;
        public NhomMau(int MA ,QuanLy quanLy)
        {
            InitializeComponent();
            textBox2.Text =""+MA;
            this.quanLy = quanLy;
        }
        public NhomMau(NhomMon nhomMon, QuanLy quanLy)
        {
            InitializeComponent();
            textBox2.Text = "" + nhomMon.Maloai;
            textBox1.Text = nhomMon.Tenloai;
            string[] A = nhomMon.RGB();
            int R = Convert.ToInt32(A[0]);
            int G = Convert.ToInt32(A[1]);
            int B = Convert.ToInt32(A[2]);
            panel1.BackColor = Color.FromArgb(R,G,B);
           this.nhomMon = nhomMon;
            this.quanLy = quanLy;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                panel1.BackColor = colorDialog.Color;
             
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (nhomMon == null)
            {
                nhomMon = new NhomMon();
                nhomMon.Maloai =Convert.ToInt32(textBox2.Text);
                nhomMon.Tenloai = textBox1.Text;
                nhomMon.MAU = panel1.BackColor.R + "," + panel1.BackColor.B + "," + panel1.BackColor.B;
                quanLy.AddNhom(nhomMon);
                this.Dispose();
                
            }
            else
            {
                nhomMon = new NhomMon();
                nhomMon.Maloai = Convert.ToInt32(textBox2.Text);
                nhomMon.Tenloai = textBox1.Text;
                nhomMon.MAU = panel1.BackColor.R + "," + panel1.BackColor.B + "," + panel1.BackColor.B;
                quanLy.Update(nhomMon);
                this.Dispose();
            }


        }

        private void button3_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                panel1.BackColor = colorDialog.Color;

            }
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            if (nhomMon == null)
            {
                nhomMon = new NhomMon();
                nhomMon.Maloai = Convert.ToInt32(textBox2.Text);
                nhomMon.Tenloai = textBox1.Text;
                nhomMon.MAU = panel1.BackColor.R + "," + panel1.BackColor.B + "," + panel1.BackColor.B;
                quanLy.AddNhom(nhomMon);
                this.Dispose();

            }
            else
            {
                nhomMon = new NhomMon();
                nhomMon.Maloai = Convert.ToInt32(textBox2.Text);
                nhomMon.Tenloai = textBox1.Text;
                nhomMon.MAU = panel1.BackColor.R + "," + panel1.BackColor.B + "," + panel1.BackColor.B;
                quanLy.Update(nhomMon);
                this.Dispose();
            }
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
