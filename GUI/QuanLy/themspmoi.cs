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
    public partial class themspmoi : UserControl
    {
        public themspmoi()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HangHoa hh = new HangHoa();
            hh.MaSP1 = textBox3.Text.ToString();
            hh.TenSP1 = textBox2.Text.ToString();
            hh.Gia1 =textBox1.Text.ToString();
            DAL.DALHangHoa ctkk = new DAL.DALHangHoa();
            ctkk.InsetHanghoa(hh);
            MessageBox.Show("Thêm thành công");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }
    }
}
