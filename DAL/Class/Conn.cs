using System.Configuration;

namespace DAL.Class
{
    public static class Conn
    {
        private static string _caminhoBanco = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "DBFile.mdf;");
        public static string StrConn { get; private set; } = ConfigurationManager.ConnectionStrings["SQL-Server"].ToString() + _caminhoBanco;
    }
}
