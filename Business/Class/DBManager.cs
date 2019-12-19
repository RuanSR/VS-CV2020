using System;
using System.Data;
using DAL.Class;

namespace Business.Class
{
    public sealed class DBManager : IDB
    {

        public DB DB { get; private set; }
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
    }
}
