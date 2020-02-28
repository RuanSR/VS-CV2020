using Model.Classes;
using System.Collections.Generic;

namespace Model.Interface
{
    public interface IAtendenteDAO
    {
        void NovoAtendente(Atendente atendente);
        void AtualizarAtendente(Atendente atendente);
        void RevomerAtendente(Atendente atendente);
        IList<Atendente> ListaAtendentes();
    }
}
