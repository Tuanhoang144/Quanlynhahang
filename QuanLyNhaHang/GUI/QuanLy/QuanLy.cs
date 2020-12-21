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

namespace QuanLyCafe.Gul
{
    public partial class QuanLy : Form
    {
        int MA = 100;
        int MamON =1000;
      public int MaBan =1;
        int Check = -1;
        private DALBan DALBan;
        private DALNhomMon nhomMon;
        private DALThucDon ThucDon;
        private DTO.NhanVien nhanVien;
        private DALNhanvien DALNhanvien;
       
        public QuanLy(TrangChu trangChu)
        {
            InitializeComponent();
            LoadDatabase();
            groupBox1.ForeColor = trangChu.ForeColor;
            groupBox2.ForeColor = trangChu.ForeColor;
            //groupBox3.ForeColor = trangChu.ForeColor;
            //groupBox4.ForeColor = trangChu.ForeColor;
            groupBox5.ForeColor = trangChu.ForeColor;
            groupBox6.ForeColor = trangChu.ForeColor;
            groupBox7.ForeColor = trangChu.ForeColor;
            groupBox8.ForeColor = trangChu.ForeColor;
            groupBox9.ForeColor = trangChu.ForeColor;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }


        private void button4_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(0);
            LoadDatabase();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(1);
            LoadDatabase();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(2);
            LoadDatabase();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(3);
        }

        internal void AddNhom(NhomMon nhomMon)
        {
            this.nhomMon.Insert(nhomMon);
            LoadDatabase();
        }

        private void button14_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {


        }

        private void button1_Click_1(object sender, EventArgs e)
        {
       
            NhomMau nhomMau = new NhomMau((MA + 1), this);
            nhomMau.Show();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (Check > -1)
            {
                NhomMon nhomMon1 = new NhomMon();
                nhomMon1.Maloai = Convert.ToInt32(dataGridView3.Rows[Check].Cells[0].Value.ToString());
                nhomMon1.Tenloai = dataGridView3.Rows[Check].Cells[1].Value.ToString();
                nhomMon1.MAU = dataGridView3.Rows[Check].Cells[2].Value.ToString();
                nhomMon.Delete(nhomMon1); LoadDatabase();
            }
        }

        private void QuanLy_Load(object sender, EventArgs e)
        {
        
            LoadDatabase();
        }

        internal void Update(NhomMon nhomMon)
        {
            this.nhomMon.Update(nhomMon);
            LoadDatabase();

        }

        public void LoadDatabase()
        {
            this.DALNhanvien = new DALNhanvien();
            nhanVien = new DTO.NhanVien();
            nhanVien.MaNV1 = "5951071110";
            nhomMon = new DALNhomMon();
            dataGridView3.DataSource = nhomMon.SelectNhomMon();
            dataGridView3.Show();
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            foreach (DataRow item in nhomMon.SelectNhomMon().Rows)
            {
                MA = (Convert.ToInt32(item["MaLoai"].ToString()));
                comboBox1.Items.Add(item["TENLoai"].ToString());
                comboBox2.Items.Add(item["TENLoai"].ToString());
                comboBox2.Tag = item["MaLoai"].ToString();
            }
            ThucDon = new DALThucDon();
            dataGridView1.DataSource = ThucDon.SelectThucDon();
            dataGridView1.Show();
            foreach (DataRow item in ThucDon.SelectThucDon().Rows)
            {
                MamON = (Convert.ToInt32(item["MaMon"].ToString()));
            }
            DALBan = new DALBan();
            dataGridView2.DataSource = DALBan.SelectBan();
            dataGridView2.Show();
            foreach (DataRow item in DALBan.SelectBan().Rows)
            {
                MaBan= (Convert.ToInt32(item["MaBan"].ToString()) +1);
            }
            Check = -1;

                label10.Text ="Tổng Số Bàn :" + DALBan.TongSoBan().Rows.Count + " Bàn";
          
            foreach (DataRow item in ThucDon.TongSoMon().Rows)
            {
                label11.Text = "Tổng Số Món :" + item["Soluong"].ToString()+" Món";
            }
            foreach (DataRow item in nhomMon.TongNhomMon().Rows)
            {
                label12.Text = "Tổng Số Nhóm Món :" + item["Soluong"].ToString()+" Nhóm ";
            }

            dataGridView4.DataSource = this.DALNhanvien.Select();
            foreach (DataRow item in this.DALNhanvien.Select().Rows)
            {
                nhanVien.MaNV1= item["MaNV"].ToString();
            }
             
            int n = Convert.ToInt32(nhanVien.MaNV1.Substring(6));
            n++;
            
            label17.Text = "595107"+n;

        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (Check > -1)
            {
                NhomMon nhomMon1 = new NhomMon();
                nhomMon1.Maloai = Convert.ToInt32(dataGridView3.Rows[Check].Cells[0].Value.ToString());
                nhomMon1.Tenloai = dataGridView3.Rows[Check].Cells[1].Value.ToString();
                nhomMon1.MAU = dataGridView3.Rows[Check].Cells[2].Value.ToString();
                NhomMau nhomMau = new NhomMau(nhomMon1, this);
                nhomMau.Show();

            }

        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Check = e.RowIndex;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex > -1)
            {
                if (MamON == 1)
                {
                    MamON = 10000;
                }

                DTO.ThucDon thucDon = new ThucDon();
                thucDon.MAMON = (MamON + 1);
                thucDon.tenmon = textBox4.Text;
                thucDon.NhomMon = new NhomMon();
                thucDon.NhomMon.Maloai = Convert.ToInt32(dataGridView3.Rows[(comboBox2.SelectedIndex)].Cells[0].Value.ToString());
                thucDon.DONGIA = Convert.ToInt32(textBox5.Text);
                thucDon.DVT = textBox6.Text;
                this.ThucDon.InsetThucDon(thucDon);
                LoadDatabase();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Check > -1)
            {

                DTO.ThucDon thucDon = new ThucDon();
                thucDon.MAMON = Convert.ToInt32(dataGridView1.Rows[Check].Cells[0].Value.ToString());
                this.ThucDon.Delete(thucDon);
                LoadDatabase();


            }

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void TimKiemNhomMon(string n)
        {
            if (n.Length > 0)
            {
                nhomMon = new DALNhomMon();
                DataTable dataTable = nhomMon.TimKiem(n);
                dataGridView3.DataSource = dataTable;
                dataGridView3.Show();
                foreach (DataRow item in dataTable.Rows)
                {
                    comboBox2.SelectedItem = item["TENLoai"].ToString();
                }
               
            }
            else { LoadDatabase(); }
        }



        private void button2_Click(object sender, EventArgs e)
        {
            int n  = comboBox2.SelectedIndex;
               DTO.ThucDon thucDon = new ThucDon();
                thucDon.MAMON = MamON;
               LoadDatabase();
                thucDon.tenmon = textBox4.Text;
                thucDon.NhomMon = new NhomMon();
                thucDon.NhomMon.Maloai = Convert.ToInt32(dataGridView3.Rows[n].Cells[0].Value.ToString());
                thucDon.DONGIA = Convert.ToInt32(textBox5.Text);
                thucDon.DVT = textBox6.Text;
                this.ThucDon.Update(thucDon);
                LoadDatabase();
 
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Check = e.RowIndex;
            MamON = Convert.ToInt32(dataGridView1.Rows[Check].Cells[0].Value.ToString());
            textBox4.Text = dataGridView1.Rows[Check].Cells[1].Value.ToString();
            textBox5.Text = dataGridView1.Rows[Check].Cells[3].Value.ToString();
            textBox6.Text = dataGridView1.Rows[Check].Cells[4].Value.ToString();
            string ma =dataGridView1.Rows[Check].Cells[2].Value.ToString();
            TimKiemNhomMon(ma);

        }


        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex > -1)
            {
                string Ten = comboBox1.SelectedItem.ToString();
                ThucDon = new DALThucDon();
                DataTable dataTable = ThucDon.TimKiemThucDon(Ten);
                dataGridView1.DataSource = dataTable;
                dataGridView1.Show();
            }
        }

     

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            string TimKiem = textbox1.Text;
            if (TimKiem.Length > 0)
            {
                ThucDon = new DALThucDon();
                DataTable dataTable = ThucDon.TimKiemThucDon1(TimKiem);
                dataGridView1.DataSource = dataTable;
                dataGridView1.Show();

            }
            else LoadDatabase();

        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Check = e.RowIndex;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (Check > -1)
            {
                DTO.Ban ban = new DTO.Ban();
                ban.MaBan = Convert.ToInt32(dataGridView2.Rows[Check].Cells[0].Value.ToString());
                ban.TenBan = dataGridView2.Rows[Check].Cells[1].Value.ToString();
                ban.TrangThai = dataGridView2.Rows[Check].Cells[2].Value.ToString();
                if (DALBan.DeleteBan(ban) == 0)
                {
                    MessageBox.Show("Bàn này không thể xóa vui lòng kiểm tra lại tình trạng bàn");
                }
                LoadDatabase();
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Ban ban = new Ban(this);
            ban.Show();

        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            if (Check >-1)
            {
                DTO.Ban ban = new DTO.Ban();
                ban.MaBan=Convert.ToInt32(dataGridView2.Rows[Check].Cells[0].Value.ToString());
                ban.TenBan=dataGridView2.Rows[Check].Cells[1].Value.ToString();
                ban.TrangThai = dataGridView2.Rows[Check].Cells[2].Value.ToString();
                Ban ban1 = new Ban(this,ban);
                ban1.Show();
            }
        }

        private void button14_Click_1(object sender, EventArgs e)
        {
           
           
        }

        private void button14_Click_2(object sender, EventArgs e)
        {
            Ban ban = new Ban(this,2);
            ban.Show();
        }

        private void button18_Click(object sender, EventArgs e)
        {

        }

        private void button15_Click(object sender, EventArgs e)
        {
            nhanVien.MaNV1 = label17.Text.Substring(6);
            nhanVien.Ten1 = textBox7.Text;
            nhanVien.SDT1 = textBox8.Text;
            nhanVien.MaKhau1 = textBox9.Text;

            nhanVien.Chucvu1 = comboBox3.SelectedItem.ToString();
            if (radioButton1.Checked)
            {
                nhanVien.GioiTinh1 = "Nam";
            }
            if (radioButton2.Checked)
            {
                nhanVien.GioiTinh1 = "Nữ";
            }

            DALNhanvien.InsertInto(nhanVien);
            LoadDatabase();

        }

        private void btnthongke_Click(object sender, EventArgs e)
        {

        }

        private void btnthongke_Click_1(object sender, EventArgs e)
        {
            tabControl1.SelectTab(3);
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(1);
            LoadDatabase();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(2);
            LoadDatabase();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(0);
            LoadDatabase();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex > -1)
            {
                if (MamON == 1)
                {
                    MamON = 10000;
                }

                DTO.ThucDon thucDon = new ThucDon();
                thucDon.MAMON = (MamON + 1);
                thucDon.tenmon = textBox4.Text;
                thucDon.NhomMon = new NhomMon();
                thucDon.NhomMon.Maloai = Convert.ToInt32(dataGridView3.Rows[(comboBox2.SelectedIndex)].Cells[0].Value.ToString());
                thucDon.DONGIA = Convert.ToInt32(textBox5.Text);
                thucDon.DVT = textBox6.Text;
                this.ThucDon.InsetThucDon(thucDon);
                LoadDatabase();
            }
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            if (Check > -1)
            {

                DTO.ThucDon thucDon = new ThucDon();
                thucDon.MAMON = Convert.ToInt32(dataGridView1.Rows[Check].Cells[0].Value.ToString());
                this.ThucDon.Delete(thucDon);
                LoadDatabase();


            }
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            int n = comboBox2.SelectedIndex;
            DTO.ThucDon thucDon = new ThucDon();
            thucDon.MAMON = MamON;
            LoadDatabase();
            thucDon.tenmon = textBox4.Text;
            thucDon.NhomMon = new NhomMon();
            thucDon.NhomMon.Maloai = Convert.ToInt32(dataGridView3.Rows[n].Cells[0].Value.ToString());
            thucDon.DONGIA = Convert.ToInt32(textBox5.Text);
            thucDon.DVT = textBox6.Text;
            this.ThucDon.Update(thucDon);
            LoadDatabase();
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            NhomMau nhomMau = new NhomMau((MA + 1), this);
            nhomMau.Show();
        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {
            if (Check > -1)
            {
                NhomMon nhomMon1 = new NhomMon();
                nhomMon1.Maloai = Convert.ToInt32(dataGridView3.Rows[Check].Cells[0].Value.ToString());
                nhomMon1.Tenloai = dataGridView3.Rows[Check].Cells[1].Value.ToString();
                nhomMon1.MAU = dataGridView3.Rows[Check].Cells[2].Value.ToString();
                nhomMon.Delete(nhomMon1); LoadDatabase();
            }
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            if (Check > -1)
            {
                NhomMon nhomMon1 = new NhomMon();
                nhomMon1.Maloai = Convert.ToInt32(dataGridView3.Rows[Check].Cells[0].Value.ToString());
                nhomMon1.Tenloai = dataGridView3.Rows[Check].Cells[1].Value.ToString();
                nhomMon1.MAU = dataGridView3.Rows[Check].Cells[2].Value.ToString();
                NhomMau nhomMau = new NhomMau(nhomMon1, this);
                nhomMau.Show();

            }
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            string n = guna2TextBox1.Text;
            TimKiemNhomMon(n);
        }

        private void guna2Button11_Click(object sender, EventArgs e)
        {
        
        }

        private void guna2Button10_Click(object sender, EventArgs e)
        {
            if (Check > -1)
            {
                DTO.Ban ban = new DTO.Ban();
                ban.MaBan = Convert.ToInt32(dataGridView2.Rows[Check].Cells[0].Value.ToString());
                ban.TenBan = dataGridView2.Rows[Check].Cells[1].Value.ToString();
                ban.TrangThai = dataGridView2.Rows[Check].Cells[2].Value.ToString();
                Ban ban1 = new Ban(this, ban);
                ban1.Show();
            }
        }

        private void guna2Button12_Click(object sender, EventArgs e)
        {
            if (Check > -1)
            {
                DTO.Ban ban = new DTO.Ban();
                ban.MaBan = Convert.ToInt32(dataGridView2.Rows[Check].Cells[0].Value.ToString());
                ban.TenBan = dataGridView2.Rows[Check].Cells[1].Value.ToString();
                ban.TrangThai = dataGridView2.Rows[Check].Cells[2].Value.ToString();
                if (DALBan.DeleteBan(ban) == 0)
                {
                    MessageBox.Show("Bàn này không thể xóa vui lòng kiểm tra lại tình trạng bàn");
                }
                LoadDatabase();
            }
        }

        private void guna2Button13_Click(object sender, EventArgs e)
        {
         
        }

        private void guna2Button17_Click(object sender, EventArgs e)
        {
            nhanVien.MaNV1 = label17.Text.Substring(6);
            nhanVien.Ten1 = textBox7.Text;
            nhanVien.SDT1 = textBox8.Text;
            nhanVien.MaKhau1 = textBox9.Text;

            nhanVien.Chucvu1 = comboBox3.SelectedItem.ToString();
            if (radioButton1.Checked)
            {
                nhanVien.GioiTinh1 = "Nam";
            }
            if (radioButton2.Checked)
            {
                nhanVien.GioiTinh1 = "Nữ";
            }

            DALNhanvien.InsertInto(nhanVien);
            LoadDatabase();

        }

        private void button17_Click(object sender, EventArgs e)
        {

        }

        private void button16_Click(object sender, EventArgs e)
        {

        }

        private void button19_Click(object sender, EventArgs e)
        {

        }

        private void btntaikhoan_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(3);
        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(2);
            LoadDatabase();
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(1);
            LoadDatabase();
        }

        private void guna2GradientButton2_Click_1(object sender, EventArgs e)
        {
            tabControl1.SelectTab(2);
            LoadDatabase();
        }

        private void guna2GradientButton3_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(0);
            LoadDatabase();
        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {
            string TimKiem = textbox1.Text;
            if (TimKiem.Length > 0)
            {
                ThucDon = new DALThucDon();
                DataTable dataTable = ThucDon.TimKiemThucDon1(TimKiem);
                dataGridView1.DataSource = dataTable;
                dataGridView1.Show();

            }
            else LoadDatabase();
        }

        private void guna2Button8_Click_1(object sender, EventArgs e)
        {
            NhomMau nhomMau = new NhomMau((MA + 1), this);
            nhomMau.Show();
        }

        private void guna2Button9_Click_1(object sender, EventArgs e)
        {
            if (Check > -1)
            {
                NhomMon nhomMon1 = new NhomMon();
                nhomMon1.Maloai = Convert.ToInt32(dataGridView3.Rows[Check].Cells[0].Value.ToString());
                nhomMon1.Tenloai = dataGridView3.Rows[Check].Cells[1].Value.ToString();
                nhomMon1.MAU = dataGridView3.Rows[Check].Cells[2].Value.ToString();
                nhomMon.Delete(nhomMon1); LoadDatabase();
            }
        }

        private void guna2Button7_Click_1(object sender, EventArgs e)
        {
            if (Check > -1)
            {
                NhomMon nhomMon1 = new NhomMon();
                nhomMon1.Maloai = Convert.ToInt32(dataGridView3.Rows[Check].Cells[0].Value.ToString());
                nhomMon1.Tenloai = dataGridView3.Rows[Check].Cells[1].Value.ToString();
                nhomMon1.MAU = dataGridView3.Rows[Check].Cells[2].Value.ToString();
                NhomMau nhomMau = new NhomMau(nhomMon1, this);
                nhomMau.Show();

            }
        }

        private void guna2TextBox2_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void guna2Button18_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(3);
        }

        private void guna2Button21_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(1);
            LoadDatabase();
        }

        private void guna2Button19_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(2);
            LoadDatabase();
        }

        private void guna2Button20_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(0);
            LoadDatabase();
        }

        private void guna2Button13_Click_1(object sender, EventArgs e)
        {
            Ban ban = new Ban(this, 2);
            ban.Show();
        }

        private void guna2Button12_Click_1(object sender, EventArgs e)
        {
            if (Check > -1)
            {
                DTO.Ban ban = new DTO.Ban();
                ban.MaBan = Convert.ToInt32(dataGridView2.Rows[Check].Cells[0].Value.ToString());
                ban.TenBan = dataGridView2.Rows[Check].Cells[1].Value.ToString();
                ban.TrangThai = dataGridView2.Rows[Check].Cells[2].Value.ToString();
                if (DALBan.DeleteBan(ban) == 0)
                {
                    MessageBox.Show("Bàn này không thể xóa vui lòng kiểm tra lại tình trạng bàn");
                }
                LoadDatabase();
            }
        }

        private void guna2Button10_Click_1(object sender, EventArgs e)
        {
            if (Check > -1)
            {
                DTO.Ban ban = new DTO.Ban();
                ban.MaBan = Convert.ToInt32(dataGridView2.Rows[Check].Cells[0].Value.ToString());
                ban.TenBan = dataGridView2.Rows[Check].Cells[1].Value.ToString();
                ban.TrangThai = dataGridView2.Rows[Check].Cells[2].Value.ToString();
                Ban ban1 = new Ban(this, ban);
                ban1.Show();
            }
        }

        private void guna2Button11_Click_1(object sender, EventArgs e)
        {
            Ban ban = new Ban(this);
            ban.Show();
        }
    }
}
