using Model.Classes;
using Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.DAO
{
    public class AtendenteDAO : IAtendenteDAO, IDisposable
    {
        private CVContext _atendenteContext;

        public AtendenteDAO()
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
        public void Dispose()
        {
            _atendenteContext.Dispose();
        }

    }
}
