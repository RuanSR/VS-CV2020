using CVirtual.Data.Repositories;
using CVirtual.Shared.Classes;
using CVirtual.Shared.Enuns;
using CVirtual.Shared.Exceptions;
using CVirtual.Views.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVirtual.Presenter
{
    public class AuthPresenter
    {
        public static Atendente Atendente { get; private set; }
        public static bool isLoggedIn = false;

        public async Task LoginAsync(ILoginView view)
        {
            if (!isLoggedIn && Atendente == null)
            {
                if (string.IsNullOrEmpty(view.TxtUser.Text.Trim()) || string.IsNullOrEmpty(view.TxtPassword.Text.Trim()))
                {
                    throw new AtendenteException("Preencha nome de usuário e senha corretamente!", ExceptionInfoType.InfoMessage);
                }

                var atendente = await new AtendenteRepository().GetAtendenteByUserNameAsync(view.TxtUser.Text, view.TxtPassword.Text);
                Atendente = atendente ?? throw new AtendenteException("Nome de usuário ou senha inválido!", ExceptionInfoType.InfoMessage);
                
                isLoggedIn = true;
            }
        }

        public void Logout()
        {
            if (isLoggedIn && Atendente != null)
                Atendente = null;

            isLoggedIn = false;
        }
    }
}
