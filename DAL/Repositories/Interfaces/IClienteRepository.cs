using Models.Classes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Models.Interface
{
    public interface IClienteRepository
    {
        Task NovoClienteAsync(Cliente c);
        Task AtualizarClienteAsync(Cliente c);
        Task RemoverClienteAsync(Cliente c);
        Task DeletarRegistroAsync(Cliente c);
        Task<Cliente> GetClienteByIdAsync(int id);
        Task<Cliente> GetClienteByIdWithRegistrosAsync(int id);
        Task<IList<Cliente>> ListaClientesAsync();
        Task<IList<Cliente>> ListaClienteWithRegistrosAsync();
    }
}
