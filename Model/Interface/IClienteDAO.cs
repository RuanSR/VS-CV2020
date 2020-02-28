using Model.Classes.ClienteModel;
using System.Collections.Generic;

namespace Model.Interface
{
    public interface IClienteDAO
    {
        void NovoCliente(Cliente c);
        void AtualizarCliente(Cliente c);
        void RemoverCliente(Cliente c);
        IList<Cliente> ListaClientes();
    }
}
