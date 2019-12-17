using System.Configuration;

namespace DAL.Class
{
    public static class Conn
    {
        private static string _caminhoBanco = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), @"DB\DBFile.mdf;");
        public static string StrConn { get; private set; } = string.Format(@"Server=(localdb)\mssqllocaldb; Integrated Security=true; Initial Catalog=cv2020;AttachDbFileName={0}", _caminhoBanco);
    }
}
