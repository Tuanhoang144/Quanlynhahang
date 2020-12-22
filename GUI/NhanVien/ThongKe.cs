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

namespace Nhanvien
{
    public partial class ThongKe : Form
    {
        private DALHoaDon hoaDon;
        private DALThucDon thucDon;
        private DALBan ban;
        private DALNhomMon nhomMon;
        public ThongKe(TrangChu trangChu)
        {
            InitializeComponent();

            LoadDataBase();
            groupBox1.ForeColor = trangChu.ForeColor;
            groupBox2.ForeColor = trangChu.ForeColor;
            groupBox3.ForeColor = trangChu.ForeColor;

        }

        private void LoadDataBase()
        {
            thucDon = new DALThucDon();
            hoaDon = new DALHoaDon();
            ban = new DALBan();
            nhomMon = new DALNhomMon();
            Thongke();      
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Thongke();

        }
     public  void Thongke()
        {
            int a = 0, b = 0;

            DateTime time1 = dateTimePicker1.Value;
            DateTime time2 = dateTimePicker2.Value;
            if (time2.CompareTo(time1)>-1)
            {
                dataGridView2.DataSource = hoaDon.TimKiemHoaDon(time1, time2);
                dataGridView3.DataSource = thucDon.SelectThucDon1(time1, time2);

                hoaDon.TimKiemHoaDon1(time1, time2);

                foreach (DataRow item in hoaDon.TimKiemHoaDon1(time1, time2).Rows)
                {
                    label1.Text = "Tổng Tiền Bán Được : " + item["TONGTIEN"].ToString()+ " VND";
                    label2.Text = "Tổng Tiền Gỉam Gía : " + item["Giamgia"].ToString() + " VND";
                    a = Convert.ToInt32(item["TONGTIEN"].ToString());
                    b = Convert.ToInt32(item["Giamgia"].ToString());
                }

                foreach (DataRow item in thucDon.SelectThucDon2(time1, time2).Rows)
                {
                    label3.Text = "Sô Lượng món bán được  : " + item["SOLUONG"].ToString()+" Món ";
                 
                }
                foreach (DataRow item in hoaDon.TongSoHd(time1, time2).Rows)
                {
                    label4.Text = "Tổng Số Hóa Đơn : " + item["SOLUONG"].ToString();

                }
                foreach (DataRow item in thucDon.TongSoMon().Rows)
                {
                    label7.Text = "Tổng Số Món : " + item["SOLUONG"].ToString();

                }

                foreach (DataRow item in ban.TongSoBan().Rows)
                {
                    label6.Text = "Tổng Số Bàn : " + item["SOLUONG"].ToString();

                }
                foreach (DataRow item in nhomMon.TongNhomMon().Rows)
                {
                    label8.Text = "Tổng Số Nhóm Món : " + item["SOLUONG"].ToString();

                }
                label5.Text = "Tổng Số Tiền Thu Về : " + (a-b) +" VND ";

            }
            else
            {
                MessageBox.Show("Bạn Chọn Ngày Không hợp lệ");
            }
           
            
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            NewMethod();
            
        }
        private void NewMethod()
        {
            Microsoft.Office.Interop.Excel._Application _Application = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel._Workbook workbook = _Application.Workbooks.Add(Type.Missing);
            Microsoft.Office.Interop.Excel.Worksheet worksheet = null;
            worksheet = workbook.Sheets["Sheet1"];
            worksheet = workbook.ActiveSheet;
            worksheet.Cells[2, 10] = " Bảng Thống Kê Từ Ngày " + dateTimePicker1.Value.ToString("dd/MM/yyyy") + " Đến Ngày " + dateTimePicker2.Value.ToString("dd/MM/yyyy");
            worksheet.Cells[5, 2] = label4.Text;
            worksheet.Cells[6, 2] = label1.Text;
            worksheet.Cells[7, 2] = label2.Text;
            worksheet.Cells[9, 2] = label5.Text;
            worksheet.Cells[6, 14] = label3.Text;
            worksheet.Cells[8, 14] = label6.Text;
            worksheet.Cells[8, 16] = label7.Text;
            worksheet.Cells[8, 18] = label8.Text;
            // hoadon 
            int hang = 12;
            worksheet.Cells[hang, 16] = " Bảng Thống Kê Thưc Đơn";
            worksheet.Cells[hang, 5] = " Bảng Thống Kê Hóa Đơn"; hang += 2;
            worksheet.Cells[hang, 1] = "  STT";
            worksheet.Cells[hang, 2] = " Mã Hóa Đơn";
            worksheet.Cells[hang, 4] = " Tiền Giảm Gía";
            worksheet.Cells[hang, 6] = "Mã Bàn  ";
            worksheet.Cells[hang, 8] = " Ngày Vào ";
            worksheet.Cells[hang, 10] = " Tổng Tiền ";
            //Thuc don
            worksheet.Cells[hang, 13] = "   STT";
            worksheet.Cells[hang, 14] = " Mã Món";
            worksheet.Cells[hang, 16] = " Tên Món";
            worksheet.Cells[hang, 18] = "Mã Loại ";
            worksheet.Cells[hang, 20] = " Số Lượng ";
            worksheet.Cells[hang, 22] = " Doanh Thu ";

            for (int i = 0; i < dataGridView2.Rows.Count - 1; i++)
            {

                for (int j = 0; j < 5; j++)
                {
                    worksheet.Cells[i + hang + 1, 1] = i + 1;
                    worksheet.Cells[i + hang + 1, 2 + j * 2] = dataGridView2.Rows[i].Cells[j].Value.ToString();

                }

            }
            for (int i = 0; i < dataGridView3.Rows.Count - 1; i++)
            {

                for (int j = 0; j < 5; j++)
                {
                    worksheet.Cells[i + hang + 1, 13] = i + 1;
                    worksheet.Cells[i + hang + 1, 14 + j * 2] = dataGridView3.Rows[i].Cells[j].Value.ToString();
                }

            }

            _Application.Visible = true;

        }
    }
}
