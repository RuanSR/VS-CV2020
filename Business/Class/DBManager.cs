using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Class;

namespace Business.Class
{
    public class DBManager : ICRUD
    {
        CRUD crud;

        public DBManager()
        {
            crud = new CRUD();
        }

        public DataTable Read()
        {
            try
            {
                return crud.Read();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Delete()
        {
            throw new NotImplementedException();
        }

        public void Insert()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
