using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DAL.Class
{
    public sealed class DB : IDB
    {
        StringBuilder _query;

        public DB()
        {
            _query = new StringBuilder();
        }
        public DataTable GetData()
        {
            try
            {
                DataTable dataTable = new DataTable();
                using (SqlConnection conn = new SqlConnection(Conn.GetConn))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        _query.Append("SELECT * FROM Cliente");
                        cmd.Connection = conn;
                        cmd.CommandText = _query.ToString();
                        dataTable.Load(cmd.ExecuteReader());
                        return dataTable;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao obter dados! Detalhes: {ex.Message}");
            }
        }
    }
}
