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
    public partial class khohang : UserControl
    {
        public DTO.NhanVien nhanVien;
        public khohang( DTO.NhanVien nhanvien)
        {
            InitializeComponent();
            this.nhanVien = nhanvien;
           
        }
        public List<ChiTietKK> xemkiemke()
        {
            List<ChiTietKK> users = new List<ChiTietKK>();
            DAL. DALChiTietKK kk= new DAL.DALChiTietKK();
            DataTable data1 = kk.SelectCTKiemKe();
            foreach (DataRow item in data1.Rows)
            {
                string id = item["MaKK"].ToString();
                string name = item["MaSP"].ToString();
                
                string soluong = item["SoLuong"].ToString();
                string dvt = item["DVT"].ToString();
                ChiTietKK use = new ChiTietKK(id, name, soluong, dvt);
                users.Add(use);
            }
            return users;
        }
        public List<ChiTietDatHang> xemchitietdathang()
        {
            List<ChiTietDatHang> users = new List<ChiTietDatHang>();
            DAL.DALChitietdathang kk = new DAL.DALChitietdathang();
            DataTable data1 = kk.SelectHanghoa();
            foreach (DataRow item in data1.Rows)
            {
                string id = item["MaDH"].ToString();
                string name = item["MaSP"].ToString();

                int soluong = Convert.ToInt32(item["SoLuong"].ToString());
                string dvt = item["DVT"].ToString();
                ChiTietDatHang use = new ChiTietDatHang(id, name, soluong, dvt);
                users.Add(use);
            }
            return users;
        }
        public List<DTO.DonDatHang> xemdathang()
        {
            List<DTO.DonDatHang> users = new List<DTO.DonDatHang>();
            DAL.DALDondathang kk = new DAL.DALDondathang();
            DataTable data1 = kk.SelectDonDatHang();
            foreach (DataRow item in data1.Rows)
            {
                string id = item["MaDH"].ToString();
                string name = item["MaNCC"].ToString();

                int soluong = Convert.ToInt32(item["TongTien"].ToString());
                string dvt = item["MaNV"].ToString();
                string TrangThai = item["TrangThai"].ToString();
                DTO.DonDatHang use = new DTO.DonDatHang(id, name, soluong, dvt, TrangThai);
                users.Add(use);
            }
            return users;
        }
        public List<DTO.HangHoa> xemhanghoa()
        {
            List<DTO.HangHoa> users = new List<DTO.HangHoa>();
            DAL.DALHangHoa kk = new DAL.DALHangHoa();
            DataTable data1 = kk.SelectHanghoa();
            foreach (DataRow item in data1.Rows)
            {
                string id = item["MaSP"].ToString();
                string name = item["TenSP"].ToString();

                string gia = item["GIA"].ToString();

                DTO.HangHoa use = new DTO.HangHoa(id, name, gia);
                users.Add(use);
            }
            return users;
        }
        public List<DTO.NhaCungCap> xemnhacungcap()
        {
            List<DTO.NhaCungCap> users = new List<DTO.NhaCungCap>();
            DAL.DALNhaCC kk = new DAL.DALNhaCC();
            DataTable data1 = kk.SelectNhaCC();
            foreach (DataRow item in data1.Rows)
            {
                string id = item["MaNCC"].ToString();
                string name = item["TennNCC"].ToString();

                string diachi = item["DiaChi"].ToString();
                string sdt = item["SDT"].ToString();
                DTO.NhaCungCap use = new DTO.NhaCungCap(id, name, diachi, sdt);
                users.Add(use);
            }
            return users;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource=xemkiemke();
            panel2.Controls.Clear();
            kiemke thongKe = new kiemke(nhanVien);
            thongKe.BackColor = this.BackColor;
            thongKe.Font = this.Font;
            // CapNhatPanel(thongKe.Size);

            panel2.Controls.Add(thongKe);
            thongKe.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = xemchitietdathang();
            panel2.Controls.Clear();
            ChitietDondathang thongKe = new ChitietDondathang(nhanVien);
            thongKe.BackColor = this.BackColor;
            thongKe.Font = this.Font;
            // CapNhatPanel(thongKe.Size);
            panel2.Controls.Add(thongKe);
            thongKe.Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = xemdathang();
            panel2.Controls.Clear();
            hoadondathang thongKe = new hoadondathang();
            thongKe.BackColor = this.BackColor;
            thongKe.Font = this.Font;
            // CapNhatPanel(thongKe.Size);

            panel2.Controls.Add(thongKe);
            thongKe.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = xemhanghoa();
            panel2.Controls.Clear();
            themspmoi thongKe = new themspmoi();
            thongKe.BackColor = this.BackColor;
            thongKe.Font = this.Font;
            // CapNhatPanel(thongKe.Size);

            panel2.Controls.Add(thongKe);
            thongKe.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = xemnhacungcap();
            panel2.Controls.Clear();
            Nhacungcap thongKe = new Nhacungcap();
            thongKe.BackColor = this.BackColor;
            thongKe.Font = this.Font;
            // CapNhatPanel(thongKe.Size);

            panel2.Controls.Add(thongKe);
            thongKe.Show();

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void khohang_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = xemkiemke();
            panel2.Controls.Clear();
            kiemke thongKe = new kiemke(nhanVien);
            thongKe.BackColor = this.BackColor;
            thongKe.Font = this.Font;
            // CapNhatPanel(thongKe.Size);

            panel2.Controls.Add(thongKe);
            thongKe.Show();
        }
    }
}
