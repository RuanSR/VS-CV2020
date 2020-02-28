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
            _atendenteContext = new CVContext();
        }
        public void NovoAtendente(Atendente atendente)
        {
            _atendenteContext.Atendentes.Add(atendente);
            _atendenteContext.SaveChanges();
        }
        public void AtualizarAtendente(Atendente atendente)
        {
            _atendenteContext.Atendentes.Update(atendente);
            _atendenteContext.SaveChanges();
        }
        public void RevomerAtendente(Atendente atendente)
        {
            _atendenteContext.Atendentes.Remove(atendente);
            _atendenteContext.SaveChanges();
        }
        public IList<Atendente> ListaAtendentes()
        {
            return _atendenteContext.Atendentes.ToList();
        }

        public void Dispose()
        {
            _atendenteContext.Dispose();
        }
    }
}
