using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyCafe.Gul;

using Nhanvien;
using GUI.QuanLy;

namespace GUI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //QuanLyCafe.Gul.TrangChu trangChu = new QuanLyCafe.Gul.TrangChu();
            //{
            //    trangChu.ShowDialog();
            //}
            Formdangnhap form = new Formdangnhap();
            Application.Run(form);
            if (form.Check == 1)
            {
                Application.Run(new QuanLyCafe.Gul.TrangChu(form.nhanVien));
            }
            else if (form.Check == 2)
            {
                Application.Run(new Nhanvien.TrangChu(form.nhanVien));
            }
        }
    }
}
