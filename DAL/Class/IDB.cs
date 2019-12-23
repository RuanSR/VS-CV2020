using System;
using System.Data;

namespace DAL.Class
{
    public interface IDB
    {
        DataTable GetAdmin(string usuario, string senha);
        DataTable GetData();
        void NovoCliente(string nome, string apelido, string endereco, string telefone, string cpf,
            string limiteConta, string totalConta, string totalPago, int numNotas, string dataConta, 
            bool status);
        void AtualizaCliente(int id, string nome, string apelido, string endereco, string telefone, string cpf,
            string limiteConta, string totalConta, string totalPago, int numNotas, string dataConta,
            bool status);
        void AtualizaNota(string totalConta, string totalPago, int numNotas, string dataConta, int id);
        DataTable GetRegistro(int id);
        DataTable GetAtendentes();
    }
}
