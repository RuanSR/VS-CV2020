using Models.Classes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Repositories.Interfaces
{
    public interface IArquivoRegistrosRepository
    {
        Task ArquivarRegistros(Cliente c);
        Task<List<ArquivoRegistros>> GetArquivados(int Id);
    }
}
