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


namespace Nhanvien
{
    public partial class TrangChu : Form
    {

        private Button[] buttona = new Button[200];
        private DALBan dALBan;
        private Socket Clinet;
        private IPEndPoint Ip;
        private GiaoDIen giaoDIen;
        DALThucDonPhaChe thucDonPhaChe;
        Size size1;
        bool Check = true;
        public DTO.NhanVien nhanVien;
        public TrangChu(DTO.NhanVien nhanVien )
        {
            InitializeComponent();
            giaoDIen = new GiaoDIen();
            Time();
            this.nhanVien = nhanVien;
        //    labelX3.Text = nhanVien.Ten1;
            size1 = new Size(tabControl1.Width, tabControl1.Height);
           LoandDaTa();
            Connect();
          CheckForIllegalCrossThreadCalls = false;
            TaoBan();
            if (Check == true)
            {
                Send("=======" + nhanVien.Ten1 + " Đã Online =======");
            }


            //   Clinet.Send(Serialize());

            LoaldPhaChe();
        }

        private void LoaldPhaChe()
        {
            thucDonPhaChe = new DALThucDonPhaChe();
            dataGridView1.DataSource = thucDonPhaChe.Select();
            dataGridView2.DataSource = thucDonPhaChe.Select1();
        }

        void Time()
        {
             timer1 = new System.Windows.Forms.Timer();

             timer1.Tick += new EventHandler(aTimer_Tick);

            timer1.Interval = 1000; // 1 second

            timer1.Start();
        }

        private void aTimer_Tick(object sender, EventArgs e)
        {
            int hh = DateTime.Now.Hour;
            int mm = DateTime.Now.Minute;
            int SS = DateTime.Now.Second;

            string Gio= DateTime.Now.ToString("dd-MM-yyyy HH: mm :ss tt");
        
         //   labelX1.Text = " Ngày : " + Gio.Substring(0,10);
         //   labelX2.Text = " Giờ  : " + Gio.Substring(10);
           
        }

        public void TaoBan()
        {
            int i = 0;
            flowLayoutPanel1.Controls.Clear();
            dALBan = new DALBan();
            DataTable table = dALBan.SelectBan();
            foreach (DataRow item in table.Rows)
            {
                Button button = new Button();
                button.Text = string.Format("" + item["TENBAN"].ToString());
                button.Name = string.Format("" + item["MABAN"].ToString());
                button.Tag = string.Format("" + item["TRANGTHAI"].ToString());
                button.Size = new Size(90, 60);
                flowLayoutPanel1.Controls.Add(button);
                button.Click += new EventHandler(SuLySuKien);
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
            int i = 0;
            DTO.Ban ban1 = new DTO.Ban();
            ban1.MaBan = Convert.ToInt32(((Button)sender).Name);
            ban1.TenBan = "" + ((Button)sender).Text;
            ban1.TrangThai =""+((Button)sender).Tag;
            panel1.Controls.Clear();
            DALHoaDon hoaDon = new DALHoaDon();
            DataTable dataTable = hoaDon.TimKiemHoaDon(ban1.MaBan);
            foreach (DataRow item in dataTable.Rows)
            {
                DatMon damon = new DatMon(ban1,this, 2,nhanVien);
                damon.TopLevel = false;
                panel1.Controls.Add(damon);
                damon.Show(); i++;
                break;
            }
            if (i == 0)
            {
                DatMon damon = new DatMon(ban1,this, 0, nhanVien);
                damon.TopLevel = false;
                panel1.Controls.Add(damon);
                damon.Show();
            }

        }
    

            void Connect()
        {
            Ip = new IPEndPoint(IPAddress.Parse("127.0.0.1"),9998);
           Clinet = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
            try
            {
                Clinet.Connect(Ip);
                Thread Listens = new Thread(Recieve);
                Listens.IsBackground = true;
                Listens.Start();
            }
            catch (Exception)
            {
                MessageBox.Show("Hệ Thống Đang bảo Trì");
                Check = false;
                Close();
            }
        
        }

    public void Send(string Message)
        {
            try
            {
                Clinet.Send(Serialize(Message));
            }
            catch 
            {
               // MessageBox.Show("Mất Kết Nối Với Máy Chủ");
                Close();
            }
        
        
        }
        void Recieve()
        {
            try
            {
                while (true)
                {
                    byte[] data = new byte[1024 * 5000];
                    Clinet.Receive(data);
                    string message = (string)Deserialize(data);
                    AddMessage(message);
                }
            }
            catch (Exception)
            {
                Clinet.Close();  
            }

        }

        private void AddMessage(string message)
        {
            if (message.Equals("GuiPhaChe"))
            {
                LoaldPhaChe();
            }
            else
            {
                string[] catchuoi = message.Split(',');
                string[] catchuoi1 = message.Split('/');
                string[] catchuoi2 = message.Split('|');
                if (catchuoi.Length > 1)
                {
                    for (int i = 0; i < buttona.Length; i++)
                    {
                        if (buttona[i].Name.Equals(catchuoi[1]))
                        {
                            buttona[i].BackColor = Color.BlueViolet;

                            buttona[i].Tag = "Đang Đặt";
                            break;
                        }
                        else if (buttona[i].Name.Equals(catchuoi[0]))
                        {

                            buttona[i].BackColor = Color.Red;
                            buttona[i].Tag = "Đang Phục Vụ";
                            break;
                        }
                    }
                }
                if (catchuoi2.Length > 1)
                {
                      if ((nhanVien.MaNV1).Equals(catchuoi2[0]))
                     {
                        
                        MessageBox.Show(catchuoi2[1]);
                     }
                }
                else if (catchuoi1.Length > 1)
                {
                    for (int i = 0; i < buttona.Length; i++)
                    {
                        if (buttona[i].Name.Equals(catchuoi1[0]))
                        {
                            buttona[i].BackColor = Color.DarkKhaki;
                            buttona[i].Tag = "Đang Trống";
                            break;

                        }

                    }

                }
            }
        }

        private new void Close()
        {
          Clinet.Close();
            this.Dispose();
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

        private void LoandDaTa()
        {
            giaoDIen = new GiaoDIen();

            string FontFamily="";
            int stye =0;
            int size=0;

            string[] BackGroud = new string[3];
            string [] Color1=new string[3];
            foreach (DataRow item in giaoDIen.Select(nhanVien.MaNV1).Rows)
            {
                FontFamily = item["FontFamily"].ToString();
                stye = Convert.ToInt32(item["Stye"].ToString());
                size  = Convert.ToInt32(item["Size"].ToString());
                FonStyle(FontFamily, size, stye);
                BackGroud = item["BackGroud"].ToString().Split(',');
                Color1 = item["Color"].ToString().Split(',') ;
                int R = Convert.ToInt32(BackGroud[0]);
                int G = Convert.ToInt32(BackGroud[1]);
                int B = Convert.ToInt32(BackGroud[2]);

                this.BackColor = Color.FromArgb(R, G, B);
                R = Convert.ToInt32(Color1[0]);
                G = Convert.ToInt32(Color1[1]);
                B = Convert.ToInt32(Color1[2]);
                this.ForeColor = Color.FromArgb(R, G, B);
            }
            if (size == 0)
            {
                Insert();
            }
            tabPage2.BackColor = this.BackColor;
            tabPage1.BackColor = this.BackColor;
            tabPage3.BackColor = this.BackColor;
         
           


        }

        private void Insert()
        {
            string Bakgroud = "" + this.BackColor.R + "," + this.BackColor.G + "," + this.BackColor.B;
            string Color2 = "" + this.ForeColor.R + "," + this.ForeColor.G + "," + this.ForeColor.B;
            giaoDIen.Insert(nhanVien.MaNV1 , this.Font, Bakgroud, Color2);

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

        private void button2_Click(object sender, EventArgs e)
        {
     
        }

        public void CapNhat()
        {
        
            this.Size = new Size((tabControl1.Width-20),(tabControl1.Height+150));
            tabControl1.SelectedIndex = 0;
            statusStrip1.BackColor = this.BackColor;
        }
        public void CapNhatPanel( Size size )
        {
            tabControl1.Size= new Size(size.Width+15, size.Height+1);
            panel2.Size = new Size(size.Width, size.Height);
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            CapNhatPanel(size1);
            CapNhat();
            tabControl1.SelectedIndex = 3;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            TaoBan();
            CapNhatPanel(size1);
            CapNhat();
            tabControl1.SelectedIndex =2;
            LoaldPhaChe();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            ThongKe thongKe = new ThongKe(this);
            thongKe.TopLevel = false;
            thongKe.BackColor = this.BackColor;
            thongKe.Font=this.Font;
            CapNhatPanel(thongKe.Size);
            panel2.Controls.Add(thongKe);
            thongKe.Show();
            CapNhat();
        }

        internal void refresh()
        {
            panel1.Controls.Clear();
            TaoBan();
        }

        private void mauNênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDepth colorDepth = new ColorDepth();
            ColorDialog color = new ColorDialog();

            color.ShowDialog();
        }

        private void mauNênToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
     

        }

        private void TrangChu_Load(object sender, EventArgs e)
        {
       

            CapNhat();
            timer1.Start();
            tabControl1.SelectedIndex = 3;

            
        }

        private void kiêuChưToolStripMenuItem_Click(object sender, EventArgs e)
        {
        
        }

        private void mauToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void mauChưToolStripMenuItem_Click(object sender, EventArgs e)
        {
      

        }

        public void UpdaTe()
        {
            string Bakgroud = "" + this.BackColor.R + "," + this.BackColor.G + "," + this.BackColor.B;
            string Color2 = "" + this.ForeColor.R + "," + this.ForeColor.G + "," + this.ForeColor.B;
            giaoDIen.Update(nhanVien.MaNV1,this.Font, Bakgroud, Color2);
            tabPage2.BackColor = this.BackColor;
            tabPage1.BackColor = this.BackColor;
            tabPage4.BackColor = this.BackColor;
            tabPage3.BackColor = this.BackColor;
            // size1 = new Size(panel2.Width, panel2.Height);
        }

        //private void khôiphuccaiđătgôctoolstripmenuitem_click(object sender, eventargs e)
        //{

        //}

        private void button6_Click(object sender, EventArgs e)
        {
            TaoBan();
            CapNhatPanel(size1);
            CapNhat();
            tabControl1.SelectedIndex = 1;
            //tabControl2.SelectedIndex =2;
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void TrangChu_FormClosed(object sender, FormClosedEventArgs e)
        {
           // Close();
            this.Dispose();
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           // labelX2.Text = DateTime.Now.ToString();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dataGridView1.Columns[e.ColumnIndex].Name.Equals("Chua Pha Chê´")) ;
            {
                int check = (e.RowIndex);
                string Mact = dataGridView1.Rows[check].Cells[0].Value.ToString();
                thucDonPhaChe.Updete(Mact);
                string Ten = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                string Mon = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                string Ban = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                Send(nhanVien.MaNV1+"" + "|" + Mon + " " + Ban + " Đã pha chế xong ");
                LoaldPhaChe();
            }
        }

        private void giaoDiênToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void mauNênToolStripMenuItem_Click_2(object sender, EventArgs e)
        {
            ColorDialog color = new ColorDialog();
            color.ShowDialog();
            this.BackColor = color.Color;
            CapNhat();
            UpdaTe();
        }

        private void kiêuChưToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            FontDialog fontDialog = new FontDialog();
            fontDialog.ShowDialog();
            this.Font = fontDialog.Font;
            UpdaTe();
        }

        private void mauChưToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            ColorDialog color = new ColorDialog();
            color.ShowDialog();
            this.ForeColor = color.Color;
            UpdaTe();
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }
    }
}
