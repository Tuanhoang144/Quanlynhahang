using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Markup;



namespace DAL
{
    public class GiaoDIen:DBconect
    {
       
        public  DataTable  Select(string Manv)
        {
            string sql = string.Format("Select * from Giaodien where Manv = '{0}'",Manv);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection());
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            return dataTable;

        }

        public void Insert(string Manv ,Font font,String BackColor,String Color  )
        {
            int n = (int)font.Size;
    
            string Sql = string.Format("Insert into GiaoDien (FontFamily,stye,size,backgroud,color,MANV) Values('{0}',{1},'{2}','{3}','{4}','{5}')"
                ,font.FontFamily.Name,font.Style.GetHashCode().ToString(),n,BackColor,Color,Manv);
            SqlConnection sqlConnection1 =sqlConnection();
            sqlConnection1.Open();
            try
            {
                SqlCommand sqlCommand = new SqlCommand(Sql, sqlConnection1);
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("" + ex.Message);
            }
            finally
            {
                sqlConnection1.Close();
            }
            

        }
        public void Update(string Mav ,Font font, String BackColor, String Color)   
        {
            int n = (int)font.Size;
            string Sql = string.Format("Update  GiaoDien set FontFamily='{0}',Stye='{1}',Size='{2}', " +
                "Backgroud='{3}',Color='{4}' Where MANV= '{5}' ",font.FontFamily.Name, font.Style.GetHashCode().ToString(), n, BackColor, Color,Mav);
            SqlConnection sqlConnection1 = sqlConnection();
            try
            {
                sqlConnection1.Open();
                SqlCommand sqlCommand = new SqlCommand(Sql, sqlConnection1);
                sqlCommand.ExecuteNonQuery();    
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                sqlConnection1.Close();
            }
        }

        public void Delete(string Manv)
        {
            string Sql = string.Format("DELETE GIAODIEN  Where MANV= '{0}' ",Manv);
            SqlConnection sqlConnection1 = sqlConnection();
            try
            {
                sqlConnection1.Open();
                SqlCommand sqlCommand = new SqlCommand(Sql, sqlConnection1);
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                sqlConnection1.Close();
            }
        }
    }
}
