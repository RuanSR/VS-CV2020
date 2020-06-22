﻿using Models.Classes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Models.Interface
{
    public interface IAtendenteRepository
    {
        Task NovoAtendenteAsync(Atendente atendente);
        Task AtualizarAtendenteAsync(Atendente atendente);
        Task RevomerAtendenteAsync(Atendente atendente);
        Task<Atendente> GetAtendenteByUserNameAsync(string userName, string senha);
        Task<Atendente> GetAtendenteByIdAsync(int id);
        Task<IList<Atendente>> ListaAtendentesAsync();
    }
}
