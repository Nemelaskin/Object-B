using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.IO;

namespace Object_B.Services
{
    public class BackupDBService
    {
        public static string[] ReadBackup()
        {
            var list = Directory.GetFiles(@"C:\Users\cfcrt\Desktop\Backup");
            return list;
        }
        public static void SetBackup(string name, IConfiguration configuration)
        {
            
            SqlConnection sqlconn = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
            SqlCommand sqlcmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();

            try
            {
                sqlconn.Open();
                sqlcmd.Connection = sqlconn;
                sqlcmd.CommandText = "DROP DATABASE SaferySistem";
                sqlcmd.ExecuteNonQuery();
                sqlcmd.CommandText = "RESTORE DATABASE Adventureworks FROM DISK = " + "'" + name + "'";
                sqlcmd.ExecuteNonQuery();
                sqlconn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static void Backup(IConfiguration configuration)
        {
            SqlConnection sqlconn = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
            SqlCommand sqlcmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();

            string backupDestination = @"C:\Users\cfcrt\Desktop\Backup";

            try
            {
                sqlconn.Open();
                sqlcmd = new SqlCommand("backup database SaferySistem to disk='" + backupDestination + @"\" + DateTime.Now.ToString("ddMMyyyy_HHmmss") + ".Bak'", sqlconn);
                sqlcmd.ExecuteNonQuery();
                sqlconn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
