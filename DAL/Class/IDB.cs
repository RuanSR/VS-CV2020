using System;
using System.Data;

namespace DAL.Class
{
    public interface IDB
    {
        DataTable GetData();
        DataTable GetAdmin(string usuario, string senha);
        DataTable GetLog(int idCliente);
        DataTable GetAtendentes();
        void NovoCliente(string nome, string apelido, string endereco, string telefone, string cpf,
        string limiteConta, string totalConta, string totalPago, int numNotas, string dataConta,
        bool status);
        void AtualizaCliente(int id, string nome, string apelido, string endereco, string telefone, string cpf,
            string limiteConta, string totalConta, string totalPago, int numNotas, string dataConta,
            bool status);
        void AtualizaNota(string totalConta, string totalPago, int numNotas, string dataConta, int id);
        void GravaLog(int idCliente, string dataNota, string horaNota, string atendente, string valor, string log);
    }
}
