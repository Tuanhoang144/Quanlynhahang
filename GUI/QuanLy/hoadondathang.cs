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
    public partial class hoadondathang : UserControl
    {
        public hoadondathang()
        {
            InitializeComponent();
            laydl();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
        }
        public void laydl()
        {
            comboBox2.Items.Clear();
            DAL.DALDondathang kk = new DAL.DALDondathang();
            DataTable data1 = kk.SelectDonDatHang();
            foreach (DataRow item in data1.Rows)
            {
                comboBox2.Items.Add(item["MaDH"].ToString());

            }
            comboBox3.Items.Clear();
            DAL.DALNhaCC kk1 = new DAL.DALNhaCC();
            DataTable data2 = kk1.SelectNhaCC();
            foreach (DataRow item in data2.Rows)
            {
                comboBox3.Items.Add(item["TennNCC"].ToString());

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

            DAL.DALDondathang ctkk = new DAL.DALDondathang();
            ctkk.Update(comboBox2.Text.ToString());
        }
    }
}
