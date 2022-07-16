using CVirtual.Shared.Classes;
using CVirtual.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CVirtual.Shared
{
    public class AtendenteManager
    {
        public static Atendente Atendente { get; private set; }

        public AtendenteManager(Atendente atendente)
        {
            if (Atendente != null)
            {
                return;
            }
            Atendente = atendente;
        }

        public AtendenteManager(string nome, string usuario, string senha, NivelAcesso nivelAcesso)
        {
            if (Atendente != null)
            {
                return;
            }
            Atendente = new Atendente(nome, usuario, senha, nivelAcesso);
        }
    }
}
