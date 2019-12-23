using System;
using System.Data;
using DAL.Class;

namespace Business.Class
{
    public sealed class DBManager : IDB
    {

        private DB DB { get; set; }
        public DBManager()
        {
            DB = new DB();
        }

        public DataTable GetData()
        {
            try
            {
                return DB.GetData();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable GetAdmin(string usuario, string senha)
        {
            try
            {
                return DB.GetAdmin(usuario, senha);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
