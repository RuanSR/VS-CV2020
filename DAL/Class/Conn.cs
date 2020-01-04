using System.Configuration;

namespace DAL.Class
{
    public static class Conn
    {
        public static string GetConn{
            get {
                string connectionFile;
                string server = ConfigurationManager.AppSettings["Server"];
                string security = ConfigurationManager.AppSettings["Security"];
                string catalog = ConfigurationManager.AppSettings["Catalog"];
                string attach = ConfigurationManager.AppSettings["Attach"];
                //string _caminhoBanco = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), attach);--AttachDbFilename={3};
                connectionFile = string.Format("Server ={0}; Integrated Security = {1}; Initial Catalog = {2};", server, security, catalog);

                return connectionFile;
            }
        }
        public static string GetConnMaster
        {
            get
            {
                string connectionFile;
                string server = ConfigurationManager.AppSettings["Server"];
                string security = ConfigurationManager.AppSettings["Security"];
                string catalog = ConfigurationManager.AppSettings["Catalog-Master"];
                string attach = ConfigurationManager.AppSettings["Attach"];
                //string _caminhoBanco = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), attach);--AttachDbFilename={3};
                connectionFile = string.Format("Server ={0}; Integrated Security = {1}; Initial Catalog = {2};", server, security, catalog);

                return connectionFile;
            }
        }
    }
}
