using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DAL.Class
{
    public sealed class DB : IDB
    {
        private StringBuilder _query;

        public DB()
        {
            
        }

        public DataTable GetAdmin(string usuario, string senha)
        {
            try
            {
                _query = new StringBuilder();
                DataTable dataTable = new DataTable();
                using (SqlConnection conn = new SqlConnection(Conn.GetConn))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        _query.Append("SELECT * FROM Atendente ");
                        _query.Append("WHERE usuario_atendente = @usuario AND senha_atendente = @senha");

                        cmd.Parameters.Add(new SqlParameter("@usuario", usuario));
                        cmd.Parameters.Add(new SqlParameter("@senha", senha));

                        cmd.Connection = conn;
                        cmd.CommandText = _query.ToString();
                        dataTable.Load(cmd.ExecuteReader());
                        return dataTable;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao obter dados do administrador! Detalhes: {ex.Message}");
            }
        }
        public DataTable GetData()
        {
            try
            {
                _query = new StringBuilder();
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
