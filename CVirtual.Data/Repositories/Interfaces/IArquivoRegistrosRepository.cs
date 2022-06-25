using CVirtual.Shared.Classes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CVirtual.Data.Repositories.Interfaces
{
    public interface IArquivoRegistrosRepository
    {
        Task ArquivarRegistros(Cliente c);
        Task<List<ArquivoRegistros>> GetArquivados(int Id);
    }
}
