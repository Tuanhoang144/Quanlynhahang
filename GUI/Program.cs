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

            Formdangnhap form = new Formdangnhap();
            Application.Run(form);
          
                Application.Run(new QuanLyCafe.Gul.TrangChu(form.nhanVien));
            

        }
    }
}
