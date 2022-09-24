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
    public class CustomerManagerPresenter
    {
        private const string DEFAULT_LIMIT_VALUE = "50,00";

        private readonly ClienteRepository _customerRepository;
        private readonly ICustomerManagerView _view;

        public CustomerManagerPresenter(ICustomerManagerView view)
        {
            _customerRepository = new ClienteRepository();
            _view = view;
        }

        public async Task ManagerForm()
        {
            try
            {
                var customer = await GetCustomer();

                if (customer != null)
                {
                    _view.ContextForm.Text = $":: {customer.Nome} ::";
                    _view.TxtFullName.Text = customer.Nome;
                    _view.TxtApelido.Text = customer.Apelido;
                    _view.TxtAddress.Text = customer.Endereco;
                    _view.TxtCellPhone.Text = customer.Telefone;
                    _view.TxtCpf.Text = customer.Cpf;
                    _view.TxtMaxLimit.Text = customer.NotaConta.LimiteConta.ToString("F2");
                    _view.CkAccountStatus.Checked = customer.Status;
                    _view.CkAccountStatus.Enabled = true;
                }
                else
                {
                    _view.TxtMaxLimit.Text = DEFAULT_LIMIT_VALUE;
                    _view.BtnDelete.Visible = false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task SaveCustomer()
        {
            var customer = await GetCustomer();

            if (customer != null)
                await UpdateCustomer(customer);
            else
                await NewCustomer();
        }

        public async Task<Cliente> DeleteCustomer()
        {
            if (!AuthPresenter.isLoggedIn && AuthPresenter.Atendente.AtendenteId != 1)
            {
                throw new ClienteException("Você precisa da autenticação!", ExceptionInfoType.InfoMessage);
            }

            var customer = await GetCustomer();

            if (customer == null)
            {
                throw new ClienteException("Cliente inválido.", ExceptionInfoType.ErrorMessage);
            }

            if (customer.NotaConta.TotalConta > 0)
            {
                throw new ClienteException("Não foi permitido a exclusão do cliente, é preciso zerar o total.", ExceptionInfoType.InfoMessage);
            }

            await _customerRepository.RemoverClienteAsync(customer);

            return customer;
        }

        private async Task NewCustomer()
        {
            var customer = new Cliente(
                _view.TxtFullName.Text, _view.TxtApelido.Text, _view.TxtAddress.Text, _view.TxtCellPhone.Text,
                _view.TxtCpf.Text, double.Parse(_view.TxtMaxLimit.Text));

            await new ClienteRepository().NovoClienteAsync(customer);

        }

        private async Task UpdateCustomer(Cliente customer) 
        {
            customer.AtualizarCliente(
                _view.TxtFullName.Text, _view.TxtApelido.Text, _view.TxtAddress.Text,
                _view.TxtCellPhone.Text, _view.TxtCpf.Text, _view.CkAccountStatus.Checked);

            customer.NotaConta.AtualizarNota(double.Parse(_view.TxtMaxLimit.Text), customer.NotaConta.TotalConta, customer.NotaConta.DataConta);

            await new ClienteRepository().AtualizarClienteAsync(customer);
        }

        private async Task<Cliente> GetCustomer()
        {
            if (!_view.CustomerId.HasValue) return null;

            return await _customerRepository.GetClienteByIdAsync(_view.CustomerId.Value);

        }
    }
}
