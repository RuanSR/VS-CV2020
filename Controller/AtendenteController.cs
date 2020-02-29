using DAL.DAO;
using Model.Classes;
using Model.Exceptions;
using Model.Interface;
using System;
using System.Collections.Generic;

namespace Controller
{
    public class AtendenteController : IAtendenteDAO
    {
        public void NovoAtendente(Atendente atendente)
        {
            try
            {
                ValidaAtendente(atendente);
                using (var atendenteContext = new AtendenteDAO())
                {
                    atendenteContext.NovoAtendente(atendente);
                }
            }
            catch (AtendenteException e)
            {
                throw e;
            }
        }
        public void AtualizarAtendente(Atendente atendente)
        {
            try
            {
                ValidaAtendente(atendente);
                using (var aContext = new AtendenteDAO())
                {
                    aContext.AtualizarAtendente(atendente);
                }

            }
            catch (AtendenteException e)
            {
                throw e;
            }
        }
        public IList<Atendente> ListaAtendentes()
        {
            try
            {
                using (var aContext = new AtendenteDAO())
                {
                    return aContext.ListaAtendentes();
                }

            }
            catch (AtendenteException e)
            {
                throw e;
            }
        }
        public void RevomerAtendente(Atendente atendente)
        {
            try
            {
                using (var aContext = new AtendenteDAO())
                {
                    aContext.RevomerAtendente(atendente);
                }

            }
            catch (AtendenteException e)
            {
                throw e;
            }
        }
        private void ValidaAtendente(Atendente atendente)
        {
            if(atendente.Nome.Length < 7)
            {
                throw new AtendenteException("Preencha com seu nome completo.");
            }
            if(atendente.Usuario.Length <= 2)
            {
                throw new AtendenteException("Usuário deve ter no mínimo 3 caracteres.");
            }
        }

    }
}
