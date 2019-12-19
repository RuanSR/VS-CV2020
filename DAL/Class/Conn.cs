﻿using System.Configuration;
using System.Text;

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
                string _caminhoBanco = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), attach);
                connectionFile = string.Format("Server ={0}; Integrated Security = {1}; Initial Catalog = {2}; AttachDbFilename={3}", server, security, catalog, _caminhoBanco);

                return connectionFile;
            }
        }
    }
}
