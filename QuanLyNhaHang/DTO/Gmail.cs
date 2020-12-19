
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;


namespace DTO
{
     public class Gmail
    {
       private string Takhoan = "phanmemquanlyptt@gmail.com";
       private string Pass = "0353573467";
        private MailMessage mail;
        private SmtpClient client;

        public void Send(string Gmail)
        {
            Random random = new Random();
            string Ma = "";
            do
            {
                Ma = "" + random.Next(100000, 999999);

            } while (Ma.Length != 6);
            string mess = "Mật Khẩu Đăng Nhập Của Bạn Là "+Ma;

             mail = new MailMessage(Takhoan,Gmail,"Phần Mềm Quản Lý Cafe PTT ",mess);
            client = new SmtpClient("smtp.gmail.com",587);
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential(Takhoan,Pass);
            client.Send(mail);
        }


    }
}
