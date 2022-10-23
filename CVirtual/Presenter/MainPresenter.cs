using CVirtual.Data.Repositories;
using CVirtual.Shared.Classes;
using CVirtual.Shared.Struct;
using CVirtual.Utils;
using CVirtual.Utils.ExtensionMethods;
using CVirtual.Views.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVirtual.Presenter
{
    public class MainPresenter
    {
        private readonly IMainView _view;
        private readonly ClienteRepository _clienteRepository;

        public MainPresenter(IMainView view)
        {
            this._view = view;
            this._clienteRepository = new ClienteRepository();
        }

        public async Task AuthorizeSystem()
        {
            try
            {
                if (!AuthPresenter.isLoggedIn)
                {
                    BlockSystem();
                    return;
                }

                await AllowSystem();
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao obter permissão de login! Detalhes: {ex.Message}");
            }
        }

        private async Task AllowSystem()
        {
            await LoadDataGridView();
            EnableComponent(true);
            _view.BtnAuth.Text = "Logout";
        }

        private void BlockSystem()
        {
            EnableComponent(false);
            _view.BtnAuth.Text = "Login";
            _view.TxtSearch.Text = string.Empty;
        }

        public void Logout()
        {
            new AuthPresenter().Logout();
            BlockSystem();
        }

        private void EnableComponent(bool status)
        {
            _view.BtnSystem.Enabled = status;
            _view.BtnAddCustomer.Enabled = status;
            _view.GroupBoxSearth.Enabled = status;
            _view.DataGridViewCustomers.Visible = status;
            _view.StatusBar.Visible = status;
        }

        public void UpdateStatusBar()
        {
            _view.LblStatusRegistro.Text = "Último Registro: " + StatusNotas.GetUltimaNota;
        }

        private async Task<IList<Cliente>> GetCustomers() => await _clienteRepository.ListaClientesAsync();

        private async Task<List<ClienteDataVisualizer>> GetCustomersByFilter(string searth = "", bool customerStatus = true)
        {

            try
            {
                var list = await GetCustomers();

                List<ClienteDataVisualizer> ModelParsedList(IList<Cliente> customerList)
                {
                    List<ClienteDataVisualizer> modelList = new List<ClienteDataVisualizer>();
                    foreach (var customer in customerList)
                    {
                        modelList.Add(
                            new ClienteDataVisualizer(customer.ClienteId, customer.Nome, customer.Apelido,
                            customer.Endereco, customer.NotaConta.LimiteConta, customer.NotaConta.TotalConta,
                            customer.NotaConta.DataConta, customer.Status));
                    }

                    return modelList;
                }

                return ModelParsedList(list)
                    .Where(c =>
                    c.NomeCliente.ToLowerInvariant().Contains(searth.ToLowerInvariant())
                    && c.StatusCliente == customerStatus
                    || c.ApelidoCliente.ToLowerInvariant().Contains(searth.ToLowerInvariant())
                    && c.StatusCliente == customerStatus
                    ).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao carregar listagem de clientes. {ex.Message}");
            }

        }

        public async Task LoadDataGridView()
        {
            _view.DataGridViewCustomers.DataSource = await GetCustomersByFilter(_view.TxtSearch.Text, _view.RbStatusOn.Checked);
            _view.DataGridViewCustomers.ApplyGridViewCellStyle();
        }
    }
}
