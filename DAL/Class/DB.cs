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

        public void NovoCliente(string nome, string apelido, string endereco, string telefone, string cpf, double limiteConta, double totalConta, double totalPago, int numNotas, string dataConta, bool status)
        {
            try
            {
                _query = new StringBuilder();
                using (SqlConnection conn = new SqlConnection(Conn.GetConn))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        _query.Append("INSERT INTO Cliente (nome_cliente, apelido_cliente, endereco_cliente, telefone_cliente, ");
                        _query.Append("cpf_cliente, limite_conta_cliente, total_conta_cliente, total_pago_cliente, num_notas_cliente, data_conta_cliente, status_cliente) ");
                        _query.Append("VALUES (@nome, @apelido, @endereco, @telefone, @cpf, @limiteConta, @totalConta, @totalPago, @numNotas, @dataConta, @status)");

                        cmd.Parameters.Add(new SqlParameter("@nome", nome));
                        cmd.Parameters.Add(new SqlParameter("@apelido", apelido));
                        cmd.Parameters.Add(new SqlParameter("@endereco", endereco));
                        cmd.Parameters.Add(new SqlParameter("@telefone", telefone));
                        cmd.Parameters.Add(new SqlParameter("@cpf", cpf));
                        cmd.Parameters.Add(new SqlParameter("@limiteConta", limiteConta));
                        cmd.Parameters.Add(new SqlParameter("@totalConta", totalConta));
                        cmd.Parameters.Add(new SqlParameter("@totalPago", totalPago));
                        cmd.Parameters.Add(new SqlParameter("@numNotas", numNotas));
                        cmd.Parameters.Add(new SqlParameter("@dataConta", dataConta));
                        cmd.Parameters.Add(new SqlParameter("@status", status));

                        cmd.Connection = conn;
                        cmd.CommandText = _query.ToString();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao inserir dados do cliente! Detalhes: {ex.Message}");
            }
        }
        public void AtualizaCliente(int id, string nome, string apelido, string endereco, string telefone, string cpf, double limiteConta, double totalConta, double totalPago, int numNotas, string dataConta, bool status)
        {
            try
            {
                _query = new StringBuilder();
                using (SqlConnection conn = new SqlConnection(Conn.GetConn))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        _query.Append("UPDATE Cliente SET nome_cliente = @nome, apelido_cliente = @apelido, endereco_cliente = @endereco, telefone_cliente = @telefone, ");
                        _query.Append("cpf_cliente = @cpf, limite_conta_cliente = @limiteConta, total_conta_cliente = @totalConta, total_pago_cliente = @totalPago, ");
                        _query.Append("num_notas_cliente = @numNotas, data_conta_cliente = @dataConta, status_cliente = @status ");
                        _query.Append("WHERE id_cliente = @id");

                        cmd.Parameters.Add(new SqlParameter("@nome", nome));
                        cmd.Parameters.Add(new SqlParameter("@apelido", apelido));
                        cmd.Parameters.Add(new SqlParameter("@endereco", endereco));
                        cmd.Parameters.Add(new SqlParameter("@telefone", telefone));
                        cmd.Parameters.Add(new SqlParameter("@cpf", cpf));
                        cmd.Parameters.Add(new SqlParameter("@limiteConta", limiteConta));
                        cmd.Parameters.Add(new SqlParameter("@totalConta", totalConta));
                        cmd.Parameters.Add(new SqlParameter("@totalPago", totalPago));
                        cmd.Parameters.Add(new SqlParameter("@numNotas", numNotas));
                        cmd.Parameters.Add(new SqlParameter("@dataConta", dataConta));
                        cmd.Parameters.Add(new SqlParameter("@status", status));
                        cmd.Parameters.Add(new SqlParameter("@id", id));

                        cmd.Connection = conn;
                        cmd.CommandText = _query.ToString();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao inserir dados do cliente! Detalhes: {ex.Message}");
            }
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
        public DataTable GetRegistro(int id)
        {
            return null;
        }
    }
}
