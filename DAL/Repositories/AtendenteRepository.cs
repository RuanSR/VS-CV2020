using Models.Classes;
using Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Database
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
        public void NovoAtendente(Atendente atendente)
        {
            try
            {
                _atendenteContext.Atendentes.Add(atendente);
                _atendenteContext.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception($"Erro ao adiconar novo atendente. Detalhes: {e.Message}");
            }
        }
        public void AtualizarAtendente(Atendente atendente)
        {
            try
            {
                _atendenteContext.Atendentes.Update(atendente);
                _atendenteContext.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception($"Erro ao atualizar dados do atendente. {e.Message}");
            }
        }
        public void RevomerAtendente(Atendente atendente)
        {
            try
            {
                _atendenteContext.Atendentes.Remove(atendente);
                _atendenteContext.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception($"Erro ao remover atendente. {e.Message}");
            }
        }
        public Atendente GetAtendenteByUserName(string userName, string senha)
        {
            return ListaAtendentes()
                .Where(at => at.Usuario.ToLower() == userName.ToLower() && at.Senha == senha)
                .FirstOrDefault();
        }
        public Atendente GetAtendenteById(int id)
        {
            return ListaAtendentes()
                .Where(a => a.AtendenteId == id)
                .FirstOrDefault();
        }
        public IList<Atendente> ListaAtendentes()
        {
            try
            {
                return _atendenteContext.Atendentes.ToList();
            }
            catch (Exception e)
            {
                throw new Exception($"Erro ao obter lista de atendentes. {e.Message}");
            }
        }

    }
}
