using CVirtual.Data.Repositories;
using CVirtual.Shared.Classes;
using CVirtual.Shared.Enums;
using CVirtual.Shared.Exceptions;
using CVirtual.Views.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVirtual.Presenter
{

    public class EmployeDialogPresenter
    {
        private readonly AtendenteRepository _atendenteRepository;
        private readonly IEmployeDialogView _view;

        public EmployeDialogPresenter(IEmployeDialogView view)
        {
            this._atendenteRepository = new AtendenteRepository();
            this._view = view;
        }

        public async Task SaveEmploye()
        {
            if (_view.EmployeId <= 0)
                await UpdateEmploye();
            else
                await NewEmploye();
        }

        public async Task LoadEmploye()
        {
            if (_view.EmployeId <= 0)
            {
                _view.TxtEmployeId.Text = "-1";
            }
            else
            {
                await LoadEmployeData();
            }
        }

        private async Task LoadEmployeData()
        {
            Atendente employe = await GetEmploye();

            if (employe == null) throw new AtendenteException("Atendente inválido", Shared.Enuns.ExceptionInfoType.ErrorMessage);

            _view.TxtEmployeId.Text = employe.AtendenteId.ToString();
            _view.TxtFullName.Text = employe.Nome;
            _view.TxtUser.Text = employe.Usuario;
            _view.TxtPassword.Text = employe.Senha;
        }

        private async Task<Atendente> GetEmploye()
        {
            return await _atendenteRepository.GetAtendenteByIdAsync(_view.EmployeId);
        }
        private async Task NewEmploye()
        {
            Atendente employe = await GetEmploye();

            if (employe == null) throw new AtendenteException("Atendente inválido", Shared.Enuns.ExceptionInfoType.ErrorMessage);

            employe.AtualizarAtendente(_view.TxtFullName.Text, _view.TxtUser.Text, _view.TxtPassword.Text, NivelAcesso.ADMIN);
            await _atendenteRepository.AtualizarAtendenteAsync(employe);
        }

        private async Task UpdateEmploye()
        {
            var employe = new Atendente(_view.TxtFullName.Text, _view.TxtUser.Text, _view.TxtPassword.Text, NivelAcesso.ADMIN);

            await _atendenteRepository.NovoAtendenteAsync(employe);
        }
    }
}
