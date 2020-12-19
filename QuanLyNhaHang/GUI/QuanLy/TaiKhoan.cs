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

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dispose();
            trang.tabControl1.SelectedIndex = 0;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
