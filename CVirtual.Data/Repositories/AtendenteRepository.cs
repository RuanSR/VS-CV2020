using Microsoft.EntityFrameworkCore;
using CVirtual.Shared.Classes;
using CVirtual.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CVirtual.Data.Database;

namespace CVirtual.Data.Repositories
{
    public class AtendenteRepository : IAtendenteRepository
    {
        private CVContext _atendenteContext;

        public AtendenteRepository()
        {
            try
            {
                _atendenteContext = new CVContext();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public async Task NovoAtendenteAsync(Atendente atendente)
        {
            try
            {
                _atendenteContext.Add(atendente);
                await _atendenteContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception($"Erro ao adiconar novo atendente. Detalhes: {e.Message}");
            }
        }
        public async Task AtualizarAtendenteAsync(Atendente atendente)
        {
            try
            {
                _atendenteContext.Update(atendente);
                await _atendenteContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception($"Erro ao atualizar dados do atendente. {e.Message}");
            }
        }
        public async Task RevomerAtendenteAsync(Atendente atendente)
        {
            try
            {
                _atendenteContext.Remove(atendente);
                await _atendenteContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception($"Erro ao remover atendente. {e.Message}");
            }
        }
        public async Task<Atendente> GetAtendenteByUserNameAsync(string userName, string senha)
        {
            var listAtendentes = await ListaAtendentesAsync();
            return listAtendentes
                .Where(at => at.Usuario.ToLower() == userName.ToLower() && at.Senha == senha)
                .FirstOrDefault();
        }
        public async Task<Atendente> GetAtendenteByIdAsync(int id)
        {
            var listAtendentes = await ListaAtendentesAsync();
            return listAtendentes
                .Where(a => a.AtendenteId == id)
                .FirstOrDefault();
        }
        public async Task<IList<Atendente>> ListaAtendentesAsync()
        {
            try
            {
                return await _atendenteContext.Atendentes.ToListAsync();
            }
            catch (Exception e)
            {
                throw new Exception($"Erro ao obter lista de atendentes. {e.Message}");
            }
        }

    }
}
