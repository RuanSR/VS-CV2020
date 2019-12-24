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
        public DataTable GetLog(int idCliente)
        {
            try
            {
                return DB.GetLog(idCliente);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public DataTable GetAtendentes()
        {
            try
            {
                return DB.GetAtendentes();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void NovoCliente(string nome, string apelido, string endereco, string telefone, string cpf,
            string limiteConta, string totalConta, string totalPago, int numNotas, string dataConta, bool status)
        {
            try
            {
                DB.NovoCliente(nome, apelido, endereco, telefone, cpf, limiteConta, totalConta, totalPago, numNotas, dataConta, status);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void AtualizaCliente(int id, string nome, string apelido, string endereco, string telefone, string cpf,
            string limiteConta, string totalConta, string totalPago, int numNotas, string dataConta, bool status)
        {
            try
            {
                DB.AtualizaCliente(id, nome, apelido, endereco, telefone, cpf, limiteConta, totalConta, totalPago, numNotas, dataConta, status);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void AtualizaNota(string totalConta, string totalPago, int numNotas, string dataConta, int id)
        {
            try
            {
                DB.AtualizaNota(totalConta, totalPago, numNotas, dataConta, id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void GravaLog(int idCliente, string dataNota, string horaNota, string atendente, string valor, string log)
        {
            try
            {
                DB.GravaLog(idCliente, dataNota, horaNota, atendente, valor, log);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void RemoveAtendente(int id)
        {
            try
            {
                DB.RemoveAtendente(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void NovoAtendente(string nome, string senha)
        {
            try
            {
                DB.NovoAtendente(nome, senha);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void AtualizaAtendente(int id, string nome, string senha)
        {
            try
            {
                DB.AtualizaAtendente(id, nome, senha);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
