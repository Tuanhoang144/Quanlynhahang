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
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using GUI;
using Guna.UI2.WinForms;

namespace QuanLyCafe.Gul
{
    public partial class TrangChu :Form
    {
        int PanelWidth;
        bool isCollapsed;
        private  DTO.Ban ban1;
        private ChiTietHoaDon chiTietHoa;
        private List<Button> buttons = new List<Button>();
        private Button[] buttona = new Button[200];
        private DALBan dALBan;
        private Socket Server;
        private IPEndPoint Ip;
        private List<Socket> ListClinet;
        private GiaoDIen giaoDIen;
        private DTO.HoaDon HoaDon;
        private DALHoaDon hoaDon1;
        private DTO.NhanVien nhanVien =new NhanVien();
        Size Size1 = new Size();

        public TrangChu(DTO.NhanVien nhanVien)
        {
            InitializeComponent();
            giaoDIen = new GiaoDIen();
         //   Time();
            Connect();
            TaoBan();
            tabControl1.SelectedIndex=0;
            this.nhanVien = nhanVien;
            //    timer1.Start();
            timertime.Start();
            PanelWidth = panelLeft.Width;
            isCollapsed = false;
            //  Size1 = tabControl1.Size;
            LoandDaTa();
           
        
      
        }

     

 

        public void TaoBan()
        {
            buttons.Clear();
            flowLayoutPanel1.Controls.Clear();
            dALBan = new DALBan();
            int i = 0;
            foreach (DataRow item in dALBan.SelectBan().Rows)
            {
               Button button = new Button();
           
                button.Text = string.Format("" + item["TENBAN"].ToString());
                button.Name = string.Format("" + item["MABAN"].ToString());
                button.Tag = string.Format("" + item["TRANGTHAI"].ToString());
                button.Size = new Size(90, 60);

                flowLayoutPanel1.Controls.Add(button);
                button.Click += new EventHandler(SuLySuKien);
                buttons.Add(button);
                buttona[i] = button;
                i++;
                string TinhTrang = item["TRANGTHAI"].ToString();
                if (TinhTrang.Contains("Tr"))
                {
                    button.BackColor = Color.DarkKhaki;
                }
                else if (TinhTrang.Contains("Đang P"))
                {
                    button.BackColor = Color.Red;
                }
                else
                {
                    button.BackColor = Color.BlueViolet;
                }
            }

        }
        private void SuLySuKien(object sender, EventArgs e)
        {
           
            int sum = 0;
            ban1 = new DTO.Ban();
            HoaDon = new DTO.HoaDon();
            ban1.MaBan = Convert.ToInt32(((Button)sender).Name);
            ban1.TenBan = "" + ((Button)sender).Text;
            ban1.TrangThai = ""+((Button)sender).Tag;
            label1.Text =ban1.TenBan;
            label7.Text = ban1.TenBan;
            hoaDon1 = new DALHoaDon();
            DataTable dataTable = hoaDon1.TimKiemHoaDon(ban1.MaBan);
            flowLayoutPanel2.Controls.Clear();
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
                label8.Text = " Giờ Đến : " + item["GIODEN"].ToString();
                sum += chiTietHoa.Gia;
                VeMon(chiTietHoa);
                tabControl2.SelectedIndex =0;
                HoaDon.MAHD = chiTietHoa.MAHD;
                HoaDon.ChitietHD.Add(chiTietHoa);
                HoaDon.BAN = ban1;
            
            }
            if (sum==0)
            {
                if (ban1.TrangThai.Contains("Đang Đ"))
                {
                    label2.Text = ban1.TenBan;
                    label3.Text = "Trạng Thái :  Đang Đặt";
                    tabControl2.SelectedIndex =1;
                   
                }
                else
                {
                    tabControl2.SelectedIndex =2;
                }
               
            }
            label1.Text = "" + sum+ " VND";
        }
        private void VeMon(ChiTietHoaDon chiTietHoaDon)
            {
               
                FlowLayoutPanel flowLayout = new FlowLayoutPanel();
                flowLayout.Size = new Size(flowLayoutPanel2.Width, 40);
                flowLayout.BackColor = Color.LightGreen;
                flowLayout.Padding = new Padding(0, 10, 0, 0);
                Label label = new Label();
                label.Text = chiTietHoaDon.Thucdon.tenmon;
                label.Tag = chiTietHoaDon.MaCTHD;
                label.Size = new Size(130, 30);
                Label labelq = new Label();
                labelq.Text = "" + chiTietHoa.SOLUONG + " " + chiTietHoaDon.Thucdon.DVT;
                labelq.Size = new Size(80, 30);
                flowLayout.Tag = "" + chiTietHoa.MaCTHD;
                flowLayout.Controls.Add(label);
                flowLayout.Controls.Add(labelq);
                flowLayoutPanel2.Controls.Add(flowLayout);
            }

            void Connect()
        {
            Ip = new IPEndPoint(IPAddress.Any, 9998);
            Server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
            ListClinet = new List<Socket>();
            Server.Bind(Ip);
            Thread Listens = new Thread(() =>
              {
                  try
                  {
                      while (true)
                      {
                          Server.Listen(100);
                          Socket Clinet = Server.Accept();
                          ListClinet.Add(Clinet);
                          Thread thread1 = new Thread(Recieve);
                          thread1.IsBackground = true;
                          thread1.Start(Clinet);

                      }
                  }
                  catch (Exception)
                  {
                      Ip = new IPEndPoint(IPAddress.Any, 9998);
                      Server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
                  }
              }

            );
           
           Listens.IsBackground = true;
           Listens.Start();
        }

        void Send( Socket clinet, string Mess)
        {
            if (ListClinet != null)
            {
                clinet.Send(Serialize(Mess));
            }
         

        }
        void Recieve(object obj)
        {
            Socket Clinet = obj as Socket;
            try
            {
                while (true)
                    {
                    byte[] data = new byte[1024 * 5000];
                    Clinet.Receive(data);
                    string message = (string)Deserialize(data);
             
                    foreach (Socket item in ListClinet)
                    {
                        if (item != null && item != Clinet)
                        {
                            item.Send(Serialize(message));
                        }
                    }

                    AddMessage(message);
               }
               
            }
            catch (Exception)
            {
                ListClinet.Remove(Clinet);
                Clinet.Close();
                
            }

        }
       

        private void AddMessage(string message)
        {
            if (!message.Equals("GuiPhaChe"))
            {
             
                 string []  catchuoi = message.Split(',');
                string[] catchuoi1 = message.Split('/');
                if (catchuoi.Length > 1)
                {
                    for (int i = 0; i < buttona.Length; i++)
                    {
                        if (buttona[i].Name.Equals(catchuoi[1]))
                        {
                            buttona[i].BackColor = Color.BlueViolet;
                            listView1.Items.Add(new ListViewItem(Text = catchuoi[0]));
                            buttona[i].Tag = "Đang Đặt";
                            break;
                        }
                        else if (buttona[i].Name.Equals(catchuoi[0]))
                        {
                            listView1.Items.Add(new ListViewItem(Text =catchuoi[1]));
                            buttona[i].BackColor = Color.Red;
                            buttona[i].Tag = "Đang Phục Vụ";
                            break;
                        }
                    }

                }
             else  if (catchuoi1.Length>1)
                {
                    for (int i = 0; i < buttona.Length; i++)
                    {
                          if (buttona[i].Name.Equals(catchuoi1[0]))
                        {
                            listView1.Items.Add(new ListViewItem(Text =catchuoi1[1]));
                            buttona[i].BackColor = Color.DarkKhaki;
                            buttona[i].Tag = "Đang Trống";
                            break;

                        }

                    }

                }
              
                else
                {   
                    if(message.Contains("Đã Online ======="))
                    {
                        listView1.Items.Add(new ListViewItem(Text = message + "\n"));
                    }

                       

                }

            }

        }
 

       private void Close()
        {
           Server.Close();
        }

        byte[] Serialize(object obj)
        {
            MemoryStream stream = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, obj);
            return stream.ToArray();
        }

        object Deserialize(byte[] data)
        {
            MemoryStream stream = new MemoryStream(data);
            BinaryFormatter formatter = new BinaryFormatter();
            return formatter.Deserialize(stream);
        }

        public void LoandDaTa()
        {
            //giaoDIen = new GiaoDIen();

            //string FontFamily="";
            //int stye =0;
            //int size=0;
            //string chuoi;
            //string chuoi1;
            
            //string [] BackGroud=new string[3];
            //string [] Color1=new string[3];
            //foreach (DataRow item in giaoDIen.Select(nhanVien.MaNV1).Rows)
            //{
            //    FontFamily = item["FontFamily"].ToString();
            //    stye = Convert.ToInt32(item["Stye"].ToString());
            //    size  = Convert.ToInt32(item["Size"].ToString());
            //    FonStyle(FontFamily, size, stye);
            //    BackGroud = item["BackGroud"].ToString().Split(',');
            //    Color1 = item["Color"].ToString().Split(',') ;
            //    int R = Convert.ToInt32(BackGroud[0]);
            //    int G = Convert.ToInt32(BackGroud[1]);
            //    int B = Convert.ToInt32(BackGroud[2]);

            //    this.BackColor = Color.FromArgb(R, G, B);
            //    R = Convert.ToInt32(Color1[0]);
            //    G = Convert.ToInt32(Color1[1]);
            //    B = Convert.ToInt32(Color1[2]);
            //    this.ForeColor = Color.FromArgb(R, G, B);
            //    statusStrip1.BackColor = this.BackColor;
            //}
            //if (size == 0)
            //{
            //    Insert();
            //}
        
         
        }

        private void Insert()
        {
            string Bakgroud = "" + this.BackColor.R + "," + this.BackColor.G + "," + this.BackColor.B;
            string Color2 = "" + this.ForeColor.R + "," + this.ForeColor.G + "," + this.ForeColor.B;
            giaoDIen.Insert(nhanVien.MaNV1, this.Font, Bakgroud, Color2);

        }

        private void FonStyle( string font ,int size, int stye)
        {
      
            if (stye ==0)
            {
                this.Font = new Font(font, size, FontStyle.Regular);
            }
         else   if (stye ==1)
            {
                this.Font = new Font(font, size, FontStyle.Bold);
            }
          else  if (stye == 2)
            {
                this.Font = new Font(font, size, FontStyle.Italic);
            }
           else if (stye == 4)
            {
                this.Font = new Font(font, size, FontStyle.Underline);
            }
            else
            {
                this.Font = new Font(font, size, FontStyle.Strikeout);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void AddForm(Form f)
        {
            this.panel2.Controls.Clear();
            f.TopLevel = false;
            f.AutoScroll = true;
            f.FormBorderStyle = FormBorderStyle.None;
            f.Dock = DockStyle.Fill;
            this.Text = f.Text;
            this.panel2.Controls.Add(f);
            f.Show();
        }

        public void CapNhat()
        {
        
          //  this.Size = new Size((tabControl1.Width-20),(tabControl1.Height+150));
           tabControl1.SelectedIndex = 2;
            // statusStrip1.BackColor = this.BackColor;
            
        }
        public void CapNhatPanel( Size size )
        {
         //   tabControl1.Size= new Size(size.Width+20,size.Height);
           //panel2.Size = new Size(size.Width, size.Height);
     
        }

        private void btntrangchu_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
          //  CapNhatPanel(Size1);
            CapNhat();
            tabControl1.SelectedIndex = 0;
        }

        private void btndanhmuc_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            QuanLy quanLy = new QuanLy(this);
            quanLy.TopLevel = false;
            quanLy.BackColor = this.BackColor;
            quanLy.Font = this.Font;
            CapNhatPanel(quanLy.Size);
            panel2.Controls.Add(quanLy);
            quanLy.Show();
            CapNhat();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            ThongKe thongKe = new ThongKe(this);
            thongKe.TopLevel = false;
            thongKe.BackColor = this.BackColor;
            thongKe.Font=this.Font;
            CapNhatPanel(thongKe.Size);
            CapNhat();
            panel2.Controls.Add(thongKe);
            thongKe.Show();
           
        }

        private void mauNênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDepth colorDepth = new ColorDepth();
            ColorDialog color = new ColorDialog();
            color.ShowDialog();
        }

        private void toolStripSplitButton1_ButtonClick(object sender, EventArgs e)
        {

        }

        private void mauNênToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            ColorDialog color = new ColorDialog();
            color.ShowDialog();
            this.BackColor = color.Color;
            CapNhat();
            UpdaTe();
            tabControl1.SelectedIndex = 0;

        }

        private void TrangChu_Load(object sender, EventArgs e)
        {
            CapNhat();
         //   timer1.Start();
            tabControl1.SelectedIndex = 0;


        }

        private void kiêuChưToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog = new FontDialog();
            fontDialog.ShowDialog();
            this.Font= fontDialog.Font;
            UpdaTe();
        }

        private void mauToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void mauChưToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog color = new ColorDialog();
            color.ShowDialog();
            this.ForeColor = color.Color;
            UpdaTe();

        }

        public void UpdaTe()
        {
            string Bakgroud = "" + this.BackColor.R + "," + this.BackColor.G + "," + this.BackColor.B;
            string Color2 = "" + this.ForeColor.R + "," + this.ForeColor.G + "," + this.ForeColor.B;
            giaoDIen.Update(nhanVien.MaNV1, this.Font, Bakgroud, Color2);
           // size1 = new Size(panel2.Width, panel2.Height);
        }

        private void khôiPhucCaiĐătGôcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result= MessageBox.Show("Nếu Bạn Khôi Phục Lại Cài Đặt Gốc Dữ Liệu Của Bạn Sẽ Mất Hết " +
                "\n \nBạn Có Chắc Xóa không ? ","Cảnh Báo ",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
        if(result==DialogResult.Yes)
            {
                giaoDIen.Delete(nhanVien.MaNV1);
            }
           
        }

        private void đôiMâtKhâuToolStripMenuItem_Click(object sender, EventArgs e)
        {

            panel2.Controls.Clear();
            TaiKhoan taiKhoan = new TaiKhoan(this);
            taiKhoan.TopLevel = false;
            panel2.Controls.Add(taiKhoan);
            taiKhoan.BackColor = this.BackColor;
            taiKhoan.Font = this.Font;
            taiKhoan.Show();
           CapNhatPanel(taiKhoan.Size);
            CapNhat();
          
        }

        private void button6_Click(object sender, EventArgs e)
        {
            TaoBan();
            CapNhatPanel(tabPage2.Size);
            CapNhat();
            tabControl1.SelectedIndex = 1;
            tabControl2.SelectedIndex =2;
            tabPage2.BackColor = this.BackColor;
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void TrangChu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Close();
        //    this.Dispose();
            
        }
       
       
            
        private void ribbonClientPanel1_Click(object sender, EventArgs e)
        {

        }

  

        private void labelX1_Click(object sender, EventArgs e)
        {

        }

     
        private void tabControl2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            DataTable dataTable = hoaDon1.TimKiemHoaDon(ban1.MaBan);
            int h = printDocument1.DefaultPageSettings.PaperSize.Height;
            int w = printDocument1.DefaultPageSettings.PaperSize.Width;
            e.Graphics.DrawString("Pham Trong Truong ", new Font(this.Font.FontFamily.Name, 15, FontStyle.Bold)
                , Brushes.Black, new Point(10, 10));

            e.Graphics.DrawString("Hoá Đơn", new Font(this.Font.FontFamily.Name, 18, FontStyle.Bold)
               , Brushes.Black, new Point(w/2-40, 70)
                );
            String DATE = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt");
            e.Graphics.DrawString("Giờ Thanh Toán : " + DATE, new Font(this.Font.FontFamily.Name, 15, FontStyle.Bold)
            , Brushes.Black, new Point(15, 130)
             );
            Point p1 = new Point(10, 40);
            Point p2 = new Point(w - 10, 40);
            e.Graphics.DrawLine(new Pen(Color.Black, 1), p1, p2);
            e.Graphics.DrawString("Bàn 10 ", new Font(this.Font.FontFamily.Name, 15, FontStyle.Bold)
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
 , Brushes.Black, new Point(268, height)
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
            height +=20;
            e.Graphics.DrawString( " Tổng Tiền : "+HoaDon.TONGTIEN()+" VND ", new Font(this.Font.FontFamily.Name, 15, FontStyle.Regular)
, Brushes.Black, new Point(w -285, height)
);
            height += 50;
            string[] arr = label1.Text.Split('V');
            e.Graphics.DrawString("Thành Chữ : " +TienThanhchu.So_chu((double.Parse(arr[0]))), new Font(this.Font.FontFamily.Name, 15, FontStyle.Regular)
, Brushes.Black, new Point(10, height)
);
            height += 50;
            e.Graphics.DrawString("Xin chân thành cảm ơn sự ủng hộ của quý khách ! \n \t\t  Hẹn Gặp Lại ! : ", new Font(this.Font.FontFamily.Name,14, FontStyle.Italic)
, Brushes.Black, new Point(230, height)
);

        

        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            InHoaDon();
   
            ban1.TrangThai ="Đang Trống";
            foreach (Socket item in ListClinet)
            {
                Send(item, ban1.MaBan + "/=>"+nhanVien.Ten1+" Đã Thanh Toán " + ban1.TenBan + "");
            }
            AddMessage("=>"+nhanVien.Ten1+" Đã Thanh Toán " + ban1.TenBan);
            ban1.TrangThai = "Đang Đặt";
            UpDateBan(ban1);
            this.HoaDon.BAN.TrangThai = ""+ 2;
            hoaDon1.Update(HoaDon);
            tabControl2.SelectedIndex = 2;
        }

        private void InHoaDon()
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        private void UpDateBan(DTO.Ban ban1)
        {
            if (ban1.TrangThai.Contains("Tr"))
            {
                ban1.TrangThai = "Đang Đặt";
                dALBan.UpdeteBan(ban1);
                TaoBan();
            }
            else if (ban1.TrangThai.Contains("Đang Đ"))
            {
                ban1.TrangThai = " Đang Trống ";
                dALBan.UpdeteBan(ban1);
                TaoBan();
            }
            else
            {
                dALBan.UpdeteBan(ban1);
                TaoBan();
            }
        }

        private void giaoDiênToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btndanhmuc_Click_1(object sender, EventArgs e)
        {
            //   panel2.Controls.Clear();
              QuanLy quanLy = new QuanLy(this);
            //   quanLy.TopLevel = false;
            //   quanLy.BackColor = this.BackColor;
            //   quanLy.Font = this.Font;
            ////   CapNhatPanel(quanLy.Size);
            //   panel2.Controls.Add(quanLy);
            //   quanLy.Show();
               CapNhat();
            AddForm(quanLy);
        }

      

        
        private void btnthongke_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            ThongKe thongKe = new ThongKe(this);
            thongKe.TopLevel = false;
            thongKe.BackColor = this.BackColor;
            thongKe.Font = this.Font;
           // CapNhatPanel(thongKe.Size);
           CapNhat();
            panel2.Controls.Add(thongKe);
            thongKe.Show();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            TaoBan();
            CapNhatPanel(tabPage2.Size);
            CapNhat();
            tabControl1.SelectedIndex = 1;
            tabControl2.SelectedIndex = 2;
            tabPage2.BackColor = this.BackColor;
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
            
      
            
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void timertime_Tick(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            labelTime.Text = dt.ToString("HH:MM:ss");
        }

      
        private void timer1_Tick_2(object sender, EventArgs e)
        {
            if (isCollapsed)
            {
                panelLeft.Width = panelLeft.Width + 50;
                if (panelLeft.Width >= PanelWidth)
                {
                    timer1.Stop();
                    isCollapsed = false;
                    //   guna2CustomGradientPanel1.Visible = true;
                    this.Refresh();
                }
            }
            else
            {
                panelLeft.Width = panelLeft.Width - 50;
                if (panelLeft.Width <= 59)
                {
                    timer1.Stop();
                    isCollapsed = true;
                    // guna2CustomGradientPanel1.Visible = false;
                    this.Refresh();
                }
            }
        }
    }
}
