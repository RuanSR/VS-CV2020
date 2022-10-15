using CVirtual.Data.Repositories;
using CVirtual.Shared.Classes;
using CVirtual.Shared.Exceptions;
using CVirtual.Views.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVirtual.Presenter
{
    public class SystemManagerPresenter
    {
        private readonly AtendenteRepository _atendenteRepository;
        private readonly ISystemManagerView _view;

        public SystemManagerPresenter(ISystemManagerView view)
        {
            _view = view;
            _atendenteRepository = new AtendenteRepository();
        }

        public async Task LoadDataEmployer()
        {
            try
            {
                _view.DataGridViewEmployee.DataSource = await _atendenteRepository.ListaAtendentesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro: {ex.Message}");
            }
        }

        public void LoadDataForm()
        {
            LoadDataEmployer();
            LoadDataBackupIntervalTimer();
            LoadLocalBackup();
            LoadInitializedDataForm();
        }

        public void LoadDataBackupIntervalTimer()
        {
            //_view.CbBackupInterval.SelectedIndex = AppManager.SelectedTimerIndex;
            int aux = 10;
            for (int i = 0; i < 3; i++)
            {
                _view.CbBackupInterval.Items.Add($"{aux} minutos");
                aux += 5;
            }
        }

        public void LoadLocalBackup()
        {
            try
            {
                //txtLocal.Text = AppManager.LocalBackup;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro: {ex.Message}");
            }
        }

        public async Task DeleteEmployee(int employeeId)
        {
            if (employeeId < 0) throw new ArgumentException("Id do atendente inválido.");

            if (employeeId == 1 ) throw new Exception("Você não pode remover o atendente do código de nº1, pois ele é o administrador.");

            var employee = await _atendenteRepository.GetAtendenteByIdAsync(employeeId);

            if (employee == null) throw new AtendenteException("Atendente não encontrado.");

            await _atendenteRepository.RevomerAtendenteAsync(employee);
        }

        public void LoadInitializedDataForm()
        {
            _view.TabControl.TabPages.Remove(_view.TabPageBackupRestore);
        }
        public void SaveBackupPreferences()
        {
            //AppManager.SetSelectedTimerIndex(cbBackupIntervalo.SelectedIndex);
            //AppManager.SetBackupPath(string.Format("{0}{1}", txtLocal.Text, "\\"));
            //AppManager.Init();
        }
        public void RestoreBackup()
        {
            try
            {
                _view.OpenFileDialog.ShowDialog();
                if (_view.OpenFileDialog.FileName != null)
                {
                    //dbManager.RestaurarBackup(openFileDialog.FileName, ConfigurationManager.AppSettings["Catalog"]);
                }
            }
            catch (Exception err)
            {
                throw new Exception($"Erro ao tentar restaurar backup. {err.Message}");
            }
        }

        public void SetLocalBackup()
        {
            try
            {
                _view.LocalPathBackup.Text = _view.FolderBrowserDialog.SelectedPath;
            }
            catch (Exception)
            {
                throw new Exception("Erro ao definir local de backup");
            }
        }
    }
}
