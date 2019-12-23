using System;
using System.Data;

namespace DAL.Class
{
    public interface IDB
    {
        DataTable GetAdmin(string usuario, string senha);
        DataTable GetData();
        void NovoCliente(string nome, string apelido, string endereco, string telefone, string cpf,
            double limiteConta, double totalConta, double totalPago, int numNotas, string dataConta, 
            bool status);
        void AtualizaCliente(int id, string nome, string apelido, string endereco, string telefone, string cpf,
            double limiteConta, double totalConta, double totalPago, int numNotas, string dataConta,
            bool status);
        DataTable GetRegistro(int id);
    }
}
