using Models.Classes;
using System.Collections.Generic;

namespace Models.Interface
{
    public interface IAtendenteRepository
    {
        void NovoAtendente(Atendente atendente);
        void AtualizarAtendente(Atendente atendente);
        void RevomerAtendente(Atendente atendente);
        IList<Atendente> ListaAtendentes();
        Atendente GetAtendenteByUserName(string userName, string senha);
    }
}
