using System.Configuration;

namespace DAL.Class
{
    public static class Conn
    {
        public static string GetConn{
            get {
                string connectionFile;
                string server = ConfigurationManager.AppSettings["Server-Test"];
                string security = ConfigurationManager.AppSettings["Security"];
                string catalog = ConfigurationManager.AppSettings["Catalog-Test"];
                string attach = ConfigurationManager.AppSettings["Attach"];
                //string _caminhoBanco = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), attach);AttachDbFilename={3}
                connectionFile = string.Format("Server ={0}; Integrated Security = {1}; Initial Catalog = {2}; ", server, security, catalog);

                return connectionFile;
            }
        }
    }
}
