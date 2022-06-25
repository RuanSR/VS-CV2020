using CVirtual.Data.Database;
using CVirtual.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using CVirtual.Shared.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CVirtual.Data.Repositories
{
    public class ArquivoRegistrosRepository : IArquivoRegistrosRepository
    {
        private readonly CVContext _context;
        public ArquivoRegistrosRepository()
        {
            try
            {
                _context = new CVContext();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task ArquivarRegistros(Cliente c)
        {
            try
            {
                _context.Clientes.Update(c);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception($"Erro ao arquivar registros! {e.Message}");
            }
        }

        public async Task<List<ArquivoRegistros>> GetArquivados(int Id)
        {
            try
            {
                var t = await _context.Arquivos
                    .Where(a => a.NotaContaId == Id)
                    .ToListAsync();
                return t;
            }
            catch (Exception e)
            {
                throw new Exception($"Erro ao Obter arquivados! {e.Message}");
            }
        }
    }
}
