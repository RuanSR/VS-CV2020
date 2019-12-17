using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL.Class
{
    public class CRUD : ICRUD
    {
        public DataTable Read()
        {
            try
            {
                DataTable dataTable = new DataTable();
                using (SqlConnection conn = new SqlConnection(Conn.StrConn))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = "SELECT * FROM Cliente";
                        dataTable.Load(cmd.ExecuteReader());
                        return dataTable;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao ler base de dados. Detalhes: {ex.Message}");
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
