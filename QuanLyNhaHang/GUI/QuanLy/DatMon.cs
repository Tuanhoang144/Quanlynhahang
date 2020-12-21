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
using DAL;

using GUI;
using GUI.QuanLy;

namespace Nhanvien
{
    public partial class DatMon : Form
    {
        private DALThucDonPhaChe thucDonPhaChe;
        private int Ma=11000;
        private int MaHD =1;
        private DALNhomMon nhomMon;
        private DALThucDon thucDon;
        private BanHang Ban;
        private List<Button> buttons = new List<Button>();
        private DTO.HoaDon HoaDon;
        private DTO.HoaDon DSPhache;
        private DALChiTietHD DALChiTiet;
        private DALHoaDon DALHoaDon;
        private DTO.Ban ban1;
        private ChiTietHoaDon chiTietHoa;
        private DTO.NhanVien nhanVien;
        int KiemTra=0;
        public DatMon(DTO.Ban ban , BanHang  banHang, int n ,NhanVien nhanVien1)
        {
            InitializeComponent();
            this.ban1 = ban;
            HoaDon = new DTO.HoaDon();
            HoaDon.BAN = ban1;
            nhanVien = nhanVien1;
            DSPhache = new DTO.HoaDon();
            DSPhache.BAN = ban1;
            label1.Text =ban1.TenBan;
            Ban = banHang;
            tabControl1.SelectTab(n);
            tabControl2.SelectTab(1);
            LoadData();
            if (n == 2)
            {
                tabControl2.SelectTab(0);
                LoadhoaDơn();
            }
            VeLoaiThucDon();
            label2.Text = "";
            label3.Text +=":  Đang Trống";
            CheckBan();
           
        }

        public void LoadhoaDơn()
        {
            this.HoaDon.ChitietHD.Clear();
           DataTable dataTable = DALHoaDon.TimKiemHoaDon(ban1.MaBan);
            flowLayoutPanel3.Controls.Clear();
            buttons.Clear();
            foreach (DataRow item in dataTable.Rows)
            {
                label9.Text = "Trạng Thái : Đang Phục Vụ";
                chiTietHoa = new ChiTietHoaDon();
                chiTietHoa.MaCTHD = item["MachitietHD"].ToString();
                chiTietHoa.MAHD = item["MaHD"].ToString();
                chiTietHoa.Thucdon = new DTO.ThucDon();
                chiTietHoa.Thucdon.MAMON = Convert.ToInt32(item["MaMON"].ToString());
                chiTietHoa.SOLUONG = Convert.ToInt32(item["SOLUONG"].ToString());
                chiTietHoa.Thucdon.DONGIA = Convert.ToInt32(item["DONGIA"].ToString());
                chiTietHoa.Thucdon.tenmon = item["TENMON"].ToString();
                chiTietHoa.Thucdon.DVT = item["DVT"].ToString();
                label8.Text= " Giờ Đến : "+item["GIODEN"].ToString();
                HoaDon.MAHD =""+chiTietHoa.MAHD;
                HoaDon.ChitietHD.Add(chiTietHoa);
                VeMon(chiTietHoa);
                KiemTra++;
            }

           
        }

        private void CheckBan()
        {
            if (ban1.TrangThai.Equals("Đang Đặt"))
            {
                btndatban.Text = "Hủy Đặt";
                label3.Text= "Trạng Thái :  Đang Đặt";
            }
        }

        public void LoadData()
        {
        
            DALChiTiet = new DALChiTietHD();
            DataTable dataTable = DALChiTiet.GetChiTietHD();
            foreach (DataRow item in dataTable.Rows)
            {
              
                    Ma = Convert.ToInt32(item["MAChitietHD"].ToString());
               
              
            }

            DALHoaDon = new DALHoaDon();
            dataTable = DALHoaDon.GetHD();
            foreach (DataRow item in dataTable.Rows)
            {
             
                    MaHD = Convert.ToInt32(item["MAHD"].ToString());
             
            }
           
        }

        public void VeLoaiThucDon()
        {
            nhomMon = new DALNhomMon();
            DataTable dataTable = nhomMon.SelectNhomMon();
       
            foreach (DataRow item in dataTable.Rows)
            {
                Button button = new Button();
                button.Text = string.Format(""+item["TENLOAI"].ToString());
                button.Tag = string.Format("" + item["MALOAI"].ToString());
                string mau= string.Format("" + item["MAUSAC"].ToString());
                string[] RGB = mau.Split(',');
                int R = Convert.ToInt32(RGB[0]);
                int G = Convert.ToInt32(RGB[1]);
                int B= Convert.ToInt32(RGB[2]);
                button.Size = new Size(100,50);
                button.BackColor = Color.FromArgb(0, 118, 212);
                flowLayoutPanel1.Controls.Add(button);
                button.Click += new EventHandler(BatSuKien);
            }

        }
      
        private void BatSuKien(object sender, EventArgs e)
        {
            string N = ((Button)sender).Tag.ToString();
            thucDon = new DALThucDon();
            VeThucDon(thucDon.TimKiemThucDon2(N));
        }
        public void ADDMon(ChiTietHoaDon thucDon)
        {
            HoaDon.GIAMGIA = 0;
            HoaDon.BAN = ban1;
            ban1.TrangThai = "Đang Phục Vụ";
            if (KiemTra == 0)
            {
                    chiTietHoa = new ChiTietHoaDon();
                    MaHD += 1;
                   HoaDon.MAHD = MaHD + "";
                   chiTietHoa.MAHD = "" + MaHD;
                   DateTime dateTime = DateTime.Now;
                   HoaDon.NgayDen = dateTime;
                 
             //  Ban.Send(ban1.MaBan + ",=> "+Ban.nhanVien.Ten1 + " Đã Mở " + ban1.TenBan + " Lúc " + DateTime.Now.ToString());
               DALHoaDon.InsetHD(HoaDon ,Ban.nhanVien.MaNV1); KiemTra++;
                UpDateBan(ban1);
            }
             HoaDon.MAHD = chiTietHoa.MAHD;
            chiTietHoa.Thucdon = thucDon.Thucdon;
            chiTietHoa.SOLUONG = thucDon.SOLUONG;
  
                chiTietHoa.MaCTHD = (Ma + 1) + "";
                this.HoaDon.ChitietHD.Add(chiTietHoa);
                DALChiTiet.Inset(chiTietHoa);
            LoadData();
            LoadhoaDơn();
            tabControl1.SelectTab(2);
       
        }
        private void VeMon(ChiTietHoaDon chiTietHoaDon)
        {
            FlowLayoutPanel flowLayout = new FlowLayoutPanel();
            flowLayout.Size = new Size(flowLayoutPanel3.Width-10,35);
            flowLayout.BackColor = Color.FromArgb(0, 118, 212);
            flowLayout.Padding = new Padding(0, 5, 0, 5);
            Button button = new Button();
            button.Text = "X";
            button.Tag = "" + chiTietHoaDon.MaCTHD;
            button.Name = "" + chiTietHoaDon.MAHD;
            button.BackColor = Color.FromArgb(228, 20, 0);
            button.ForeColor = Color.White;
            Label label = new Label();
            label.Text = chiTietHoaDon.Thucdon.tenmon;
            label.Tag= chiTietHoaDon.MaCTHD;
            label.Size = new Size(160, 25);
            label.Padding = new Padding(0, 5, 0, 0);
            Label labelq = new Label();
            labelq.Text = "" + chiTietHoa.SOLUONG+ " " +chiTietHoaDon.Thucdon.DVT;
            labelq.Size = new Size(50,25);
            button.Size = new Size(20,20);
            labelq.Padding = new Padding(0, 5, 0, 0);
            flowLayout.Tag =""+chiTietHoa.MaCTHD;
            flowLayout.Controls.Add(label);
            flowLayout.Controls.Add(labelq);
            flowLayout.Controls.Add(button);
            buttons.Add(button);
            button.Click += new EventHandler(XoaMon);
            label.Click+= new EventHandler(EditMon);
            flowLayoutPanel3.Controls.Add(flowLayout);
            ban1.TrangThai = "Đang Phục Vụ";
            HoaDon.BAN.TrangThai = ""+1;
            label11.Text = ""+HoaDon.TONGTIEN()+"VND";
        }

        private void EditMon(object sender, EventArgs e)
        {
            string Ma = ((Label)sender).Tag.ToString();
            ChonMon chonMon = new ChonMon(Ma,this);
            chonMon.Show();
        }

        private void VeThucDon(DataTable dataTable)
        {
            flowLayoutPanel2.Controls.Clear();
            foreach (DataRow item in dataTable.Rows)
            {
                Button button = new Button();
                button.Text = string.Format(""+item["TenMon"].ToString() + "\n"+item["DONGIA"].ToString()+" đồng/"+item["DVT"].ToString());
                button.Name = string.Format(item["MAMON"].ToString());
                button.Tag = string.Format(""+item["TenMon"].ToString());
                button.Size = new Size(85,70);
                button.BackColor = Color.Empty;
                flowLayoutPanel2.Controls.Add(button);
                button.Click += new EventHandler(GoiMon);
            }

        }

 
        private void GoiMon(object sender, EventArgs e)
        {
           string MA= ((Button)sender).Name.ToString();
            ChonMon chonMon = new ChonMon(MA,this);
            chonMon.Show();
        }

        private void XoaMon(object sender, EventArgs e)
        {
            string MA;
            int i = 0;
            foreach (Button item in buttons)
            {
                if (item.Tag.Equals(((Button)sender).Tag.ToString()))
                {
                    flowLayoutPanel3.Controls.RemoveAt(i);
                     buttons.RemoveAt(i);
                    MA = ((Button)sender).Tag.ToString();
                    DALChiTiet.Delete(MA);
                    LoadData();
                    LoadhoaDơn();
                    break;
                }
                i++;
            }
            if (buttons.Count==0)
            {
                MA = ((Button)sender).Name.ToString();
                ban1.TrangThai = "Đang Đặt";
                UpDateBan(ban1);
                DALHoaDon.Delete(Convert.ToInt32(MA));
                ///     Ban.Send(ban1.MaBan + "/=> "+Ban.nhanVien.Ten1+ " Đã hủy Bàn " + ban1.TenBan + " Vào Lúc " + DateTime.Now.ToString());
                tabControl1.SelectedIndex = 0;
                tabControl2.SelectedIndex = 0;
            }
        
             
        }

     

        private void button1_Click(object sender, EventArgs e)
        {
                  UpDateBan(ban1);
             if (btndatban.Text.Equals("Hủy Đặt"))
            {
                btndatban.Text = "Đặt Bàn";
             
            }
            else
            {
                btndatban.Text = "Hủy Đặt";
                
            }
           

        }

        private void UpDateBan(DTO.Ban ban1)
        {
            DALBan dALBan = new DALBan();
            if (ban1.TrangThai.Contains("Tr"))
            {
                ban1.TrangThai = "Đang Đặt";
                dALBan.UpdeteBan(ban1);
               Ban.refresh();
            }
            else if (ban1.TrangThai.Contains("Đang Đ"))
            {
                ban1.TrangThai = " Đang Trống ";
                dALBan.UpdeteBan(ban1);
               Ban.refresh();
            }
            else
            {
                dALBan.UpdeteBan(ban1);
            Ban.refresh();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label8.Text = "Giờ đến : " + DateTime.Now.ToString();
            label7.Text = label1.Text;
            tabControl1.SelectTab(1);
            tabControl2.SelectTab(0);
            label9.Text = "Trạng Thái : Đang Phục Vụ";
            label4.Text = label7.Text;
            label5.Text = label8.Text;
            label6.Text = label9.Text;


        }

        private void tabPage1_Click_1(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
           Ban.refresh();
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            InHoaDon();
            this.HoaDon.BAN.TrangThai=""+2;
            DALHoaDon.Update(HoaDon);
            ban1.TrangThai= "Đang Đặt";
    
            UpDateBan(ban1);
            Dispose();

        }

        private void InHoaDon()
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }


     
        private void tabPage5_Click(object sender, EventArgs e)
        {
          
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            DataTable dataTable = DALHoaDon.TimKiemHoaDon(ban1.MaBan);
            int h = printDocument1.DefaultPageSettings.PaperSize.Height;
            int w = printDocument1.DefaultPageSettings.PaperSize.Width;
            e.Graphics.DrawString("Nhân Viên : "+Ban.nhanVien.Ten1, new Font(this.Font.FontFamily.Name, 15, FontStyle.Bold)
                , Brushes.Black, new Point(10, 10));

            e.Graphics.DrawString("Hoá Đơn", new Font(this.Font.FontFamily.Name, 18, FontStyle.Bold)
               , Brushes.Black, new Point(w / 2 - 40, 70)
                );
            String DATE = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt");
            e.Graphics.DrawString("Giờ Thanh Toán : " + DATE, new Font(this.Font.FontFamily.Name, 15, FontStyle.Bold)
            , Brushes.Black, new Point(15, 130)
             );
            Point p1 = new Point(10, 40);
            Point p2 = new Point(w - 10, 40);
            e.Graphics.DrawLine(new Pen(Color.Black, 1), p1, p2);
            e.Graphics.DrawString(""+ban1.TenBan, new Font(this.Font.FontFamily.Name, 15, FontStyle.Bold)
, Brushes.Black, new Point(15, 180)
);
            p1 = new Point(10, 220);
            p2 = new Point(w - 10, 220);
            e.Graphics.DrawLine(new Pen(Color.Black, 1), p1, p2);


            e.Graphics.DrawString("Tên Món ", new Font(this.Font.FontFamily.Name, 15, FontStyle.Bold)
      , Brushes.Black, new Point(5, 230)
       );
            e.Graphics.DrawString("Số Lương ", new Font(this.Font.FontFamily.Name, 15, FontStyle.Bold)
, Brushes.Black, new Point(250, 230)
);

            e.Graphics.DrawString("Giá Tiền ", new Font(this.Font.FontFamily.Name, 15, FontStyle.Bold)
, Brushes.Black, new Point(450, 230)
);
            e.Graphics.DrawString("Tổng Tiền ", new Font(this.Font.FontFamily.Name, 15, FontStyle.Bold)
           , Brushes.Black, new Point(650, 230)
            );
            p1 = new Point(10, 260);
            p2 = new Point(w - 10, 260);
            e.Graphics.DrawLine(new Pen(Color.Black, 1), p1, p2);
            int height = 270;
            foreach (DataRow item in dataTable.Rows)
            {
                e.Graphics.DrawString(item["Tenmon"].ToString(), new Font(this.Font.FontFamily.Name, 15, FontStyle.Regular)
 , Brushes.Black, new Point(6, height)
  );
                e.Graphics.DrawString(item["SoLuong"].ToString(), new Font(this.Font.FontFamily.Name, 15, FontStyle.Regular)
 , Brushes.Black, new Point(265, height)
  );
                e.Graphics.DrawString(item["DonGia"].ToString() + " x " + item["SoLuong"].ToString() + " " + item["Dvt"].ToString()
                    , new Font(this.Font.FontFamily.Name, 15, FontStyle.Regular)
 , Brushes.Black, new Point(425, height)
  );
                e.Graphics.DrawString(item["Gia"].ToString(), new Font(this.Font.FontFamily.Name, 15, FontStyle.Regular)
, Brushes.Black, new Point(670, height)
);
                height += 50;
            }
            p1 = new Point(10, height);
            p2 = new Point(w - 10, height);
            e.Graphics.DrawLine(new Pen(Color.Black, 1), p1, p2);
            height += 20;
            e.Graphics.DrawString(label10.Text + " " + label11.Text, new Font(this.Font.FontFamily.Name, 15, FontStyle.Regular)
, Brushes.Black, new Point(w - 285, height)
);
            height += 50;
            string[] arr = label11.Text.Split('V');
            e.Graphics.DrawString("Thành Chữ : " + TienThanhchu.So_chu((double.Parse(arr[0]))), new Font(this.Font.FontFamily.Name, 15, FontStyle.Regular)
, Brushes.Black, new Point(10, height)
);
            height += 50;
            e.Graphics.DrawString("Xin chân thành cảm ơn sự ủng hộ của quý khách ! \n \t\t  Hẹn Gặp Lại ! : ", new Font(this.Font.FontFamily.Name, 14, FontStyle.Italic)
, Brushes.Black, new Point(230, height)
);



        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (textBox5.Text.Length == 0)
            {
                label11.Text = "" + HoaDon.TONGTIEN()+ "VND";
            }


        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (textBox5.Text.Length == 0)
                {
                    label11.Text = "" + HoaDon.TONGTIEN();
                }
                else
                {
                    if (textBox5.Text.Contains("%"))
                    {
                        string[] arr = textBox5.Text.Split('%');
                        int n = int.Parse(arr[0]);
                        label11.Text = "" + HoaDon.TinhTienGiam(n)+" VND";
                    }
                    else
                    {
                        try
                        {
                            int n = int.Parse(textBox5.Text);
                            HoaDon.GIAMGIA = n;
                            label11.Text = "" + HoaDon.TONGTIEN()+ " VND";
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Bạn phải nhâp bằng số hoặc phần trăm");
                        }
                    }
                }

               
                   
                
               
              
            }
       
        }

        private void DatMon_Load(object sender, EventArgs e)
        {

        }

        private void btndatban_Click(object sender, EventArgs e)
        {
            UpDateBan(ban1);
            if (btndatban.Text.Equals("Hủy Đặt"))
            {
                btndatban.Text = "Đặt Bàn";

            }
            else
            {
                btndatban.Text = "Hủy Đặt";

            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            label8.Text = "Giờ đến : " + DateTime.Now.ToString();
            label7.Text = label1.Text;
            tabControl1.SelectTab(1);
            tabControl2.SelectTab(0);
            label9.Text = "Trạng Thái : Đang Phục Vụ";
            label4.Text = label7.Text;
            label5.Text = label8.Text;
            label6.Text = label9.Text;
        }

        private void guna2Button16_Click(object sender, EventArgs e)
        {
            InHoaDon();
            this.HoaDon.BAN.TrangThai = "" + 2;
            DALHoaDon.Update(HoaDon);
            ban1.TrangThai = "Đang Đặt";

            UpDateBan(ban1);
            Dispose();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
            Ban.refresh();
        }
    }
}
