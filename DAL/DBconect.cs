using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace DAL
{
  public  class DBconect
    {
        private string Sever = @"DESKTOP-KR3IR33";
        private string Datase = "QuanLyNhaHang";
        private string Use = "sa";
        private string PASS = "12345";
        public SqlConnection sqlConnection()
        {
            string connString = @"Data Source=" + Sever + ";Initial Catalog="
           + Datase + ";Persist Security Info=True;User ID=" + Use + ";Password=" + PASS;
            SqlConnection sqlConnection = new SqlConnection(connString);
            return sqlConnection;
        }

    }
}
