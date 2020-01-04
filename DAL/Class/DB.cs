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
        public DataTable GetLog(int idCliente)
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
                        _query.Append("SELECT * FROM Registro ");
                        _query.Append("WHERE id_cliente_registro = @idCliente ORDER BY id_registro DESC");

                        cmd.Parameters.Add(new SqlParameter("@idCliente", idCliente));

                        cmd.Connection = conn;
                        cmd.CommandText = _query.ToString();
                        dataTable.Load(cmd.ExecuteReader());
                        return dataTable;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao obter dados do registro! Detalhes: {ex.Message}");
            }
        }
        public DataTable GetAtendentes()
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
                        _query.Append("SELECT * FROM Atendente");
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
        public DataTable VerificaBanco()
        {
            try
            {
                _query = new StringBuilder();
                DataTable dataTable = new DataTable();
                using (SqlConnection conn = new SqlConnection(Conn.GetConnMaster))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        _query.Append("SELECT * FROM sys.databases where name = 'cv2020';");
                        cmd.Connection = conn;
                        cmd.CommandText = _query.ToString();
                        cmd.ExecuteNonQuery();
                        dataTable.Load(cmd.ExecuteReader());
                        return dataTable;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Arro ao verificar banco de dados! {ex.Message}");
            }
        }
        public void NovoCliente(string nome, string apelido, string endereco, string telefone, string cpf,
            string limiteConta, string totalConta, string totalPago, int numNotas, string dataConta, bool status)
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
                        _query.Append("VALUES (@nome, @apelido, @endereco, @telefone, @cpf,@limiteConta , @totalConta, @totalPago, @numNotas, @dataConta, @status)");

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
        public void AtualizaCliente(int id, string nome, string apelido, string endereco, string telefone, string cpf,
            string limiteConta, string totalConta, string totalPago, int numNotas, string dataConta, bool status)
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
        public void AtualizaNota(string totalConta, string totalPago, int numNotas, string dataConta, int id)
        {
            try
            {
                _query = new StringBuilder();
                using (SqlConnection conn = new SqlConnection(Conn.GetConn))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        _query.Append("UPDATE Cliente SET total_conta_cliente = @totalConta, total_pago_cliente = @totalPago, ");
                        _query.Append("num_notas_cliente = @numNotas, data_conta_cliente = @dataConta ");
                        _query.Append("WHERE id_cliente = @id");

                        cmd.Parameters.Add(new SqlParameter("@totalConta", totalConta));
                        cmd.Parameters.Add(new SqlParameter("@totalPago", totalPago));
                        cmd.Parameters.Add(new SqlParameter("@numNotas", numNotas));
                        cmd.Parameters.Add(new SqlParameter("@dataConta", dataConta));
                        cmd.Parameters.Add(new SqlParameter("@id", id));

                        cmd.Connection = conn;
                        cmd.CommandText = _query.ToString();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao atualizar nota! Detalhes: {ex.Message}");
            }
        }

        public void GravaLog(int idCliente, string dataNota, string horaNota, string atendente, string valor, string log)
        {
            try
            {
                _query = new StringBuilder();
                using (SqlConnection conn = new SqlConnection(Conn.GetConn))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        _query.Append("INSERT INTO Registro (data_nota_registro, hora_nota_registro, atendente_registro, valor_registro, log_registro, id_cliente_registro) ");
                        _query.Append("VALUES (@dataNota, @horaNota, @atendente, @valor, @log, @idCliente)");
                        cmd.Parameters.Add(new SqlParameter("@idCliente", idCliente));
                        cmd.Parameters.Add(new SqlParameter("@dataNota", dataNota));
                        cmd.Parameters.Add(new SqlParameter("@horaNota", horaNota));
                        cmd.Parameters.Add(new SqlParameter("@atendente", atendente));
                        cmd.Parameters.Add(new SqlParameter("@valor", valor));
                        cmd.Parameters.Add(new SqlParameter("@log", log));

                        cmd.Connection = conn;
                        cmd.CommandText = _query.ToString();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao gravar registro da nota! Detalhes: {ex.Message}");
            }
        }

        public void NovoAtendente(string nome, string senha)
        {
            try
            {
                _query = new StringBuilder();
                using (SqlConnection conn = new SqlConnection(Conn.GetConn))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        _query.Append("INSERT INTO Atendente (usuario_atendente, senha_atendente) ");
                        _query.Append("VALUES (@nome, @senha)");

                        cmd.Parameters.Add(new SqlParameter("@nome", nome));
                        cmd.Parameters.Add(new SqlParameter("@senha", senha));

                        cmd.Connection = conn;
                        cmd.CommandText = _query.ToString();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao inserir atendente! Detalhes: {ex.Message}");
            }
        }

        public void AtualizaAtendente(int id, string nome, string senha)
        {
            try
            {
                _query = new StringBuilder();
                using (SqlConnection conn = new SqlConnection(Conn.GetConn))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        _query.Append("UPDATE Atendente SET usuario_atendente = @nome, senha_atendente = @senha ");
                        _query.Append("WHERE id_atendente = @id");

                        cmd.Parameters.Add(new SqlParameter("@nome", nome));
                        cmd.Parameters.Add(new SqlParameter("@senha", senha));
                        cmd.Parameters.Add(new SqlParameter("@id", id));

                        cmd.Connection = conn;
                        cmd.CommandText = _query.ToString();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao atualizar atendente! Detalhes: {ex.Message}");
            }
        }

        public void RemoveAtendente(int id)
        {
            try
            {
                _query = new StringBuilder();
                using (SqlConnection conn = new SqlConnection(Conn.GetConn))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        _query.Append("DELETE FROM Atendente WHERE id_atendente = @id");
                        cmd.Parameters.Add(new SqlParameter("@id", id));

                        cmd.Connection = conn;
                        cmd.CommandText = _query.ToString();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao remover atendente! Detalhes: {ex.Message}");
            }
        }

        public void RestaurarBackup(string path, string dbName)
        {
            /*
            Use Master
            Alter Database [cv2020]
            SET SINGLE_USER With ROLLBACK IMMEDIATE 
            RESTORE DATABASE [cv2020] FROM DISK = 'C:' 
            WITH REPLACE
            GO
             */
            try
            {
                using (SqlConnection conn = new SqlConnection(Conn.GetConn))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        _query = new StringBuilder();
                        _query.Append("Use Master Alter Database " + dbName + " ");
                        _query.Append("SET MULTI_USER With ROLLBACK IMMEDIATE ");
                        _query.Append("RESTORE DATABASE " + dbName + " FROM DISK = '" + path + "' WITH REPLACE");
                        cmd.Connection = conn;
                        cmd.CommandText = _query.ToString();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao restaurar banco de dados! Detalhes: {ex.Message}");
            }
        }

        public void CeateDataBase()
        {
            try
            {
                _query = new StringBuilder();
                using (SqlCommand cmd = new SqlCommand())
                {
                    using (SqlConnection connMaster = new SqlConnection(Conn.GetConnMaster))
                    {
                        connMaster.Open();
                        _query.Append("CREATE DATABASE cv2020");
                        cmd.Connection = connMaster;
                        cmd.CommandText = _query.ToString();
                        cmd.ExecuteNonQuery();
                        _query.Clear();
                    }
                    using (SqlConnection conn = new SqlConnection(Conn.GetConn))
                    {
                        conn.Open();
                        _query.Append(Resource.db_query);
                        cmd.Connection = conn;
                        cmd.CommandText = _query.ToString();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao criar banco de dados! Detalhes: {ex.Message}");
            }
        }
    }
}
