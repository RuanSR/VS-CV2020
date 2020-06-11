using Models.Classes;
using System.Collections.Generic;

namespace Models.Interface
{
    public interface IClienteRepository
    {
        void NovoCliente(Cliente c);
        void AtualizarCliente(Cliente c);
        void RemoverCliente(Cliente c);
        void DeletarRegistro(Cliente c);
        Cliente GetClienteById(int id);
        Cliente GetClienteByIdWithRegistros(int id);
        IList<Cliente> ListaClientes();
        IList<Cliente> ListaClienteWithRegistros();
    }
}
