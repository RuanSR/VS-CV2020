using CVirtual.Data.Repositories;
using CVirtual.Data.Repositories.Interfaces;
using CVirtual.Shared.Classes;
using CVirtual.Utils;
using CVirtual.Views.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVirtual.Presenter
{
    public class CustomerPresenter
    {
        private readonly IClienteRepository _customerRepository;
        private readonly ICustomerView _view;

        public CustomerPresenter(ICustomerView view)
        {
            _view = view;
            _customerRepository = new ClienteRepository();
        }

        public async Task LoadCustomerDataForm()
        {
            var customer = await GetCustomer();

            PrintCustomerData(customer);
            FormTitleText(customer.Nome);
        }
        public async void LoadCustomerLogData()
        {
            try
            {
                var customer = await GetCustomer();

                _view.DtgLog.DataSource = customer.NotaConta.RegistroNotas
                    .OrderByDescending(c => c.DataHora)
                    .ToList();
            }
            catch (Exception)
            {
                throw new Exception("Erro ao carregar registros.");
            }
        }
        private void PrintCustomerData(Cliente customer)
        {
            _view.BtnAddAmount.Enabled = customer.Status;

            _view.LblFullName.Text = customer.Nome;
            _view.LblDateAmount.Text = customer.NotaConta.DataConta;
            _view.LblMaxAmount.Text = customer.NotaConta.LimiteConta.ToString("F2");

            _view.LblRemainingLimit.Text = (customer.NotaConta.LimiteConta - customer.NotaConta.TotalConta).ToString("F2");

            _view.LblTotalAmount.Text = customer.NotaConta.TotalConta.ToString("F2");
            _view.LblAmountDateOpened.Text = Util.GetClienteTotalDays(customer).ToString();

            _view.LblFirstName.Text = customer.Apelido;
            _view.LblAddress.Text = customer.Endereco;
            _view.LblPhoneNumber.Text = customer.Telefone;
            _view.LblCpf.Text = customer.Cpf;
            _view.LblTotalNotes.Text = customer.NotaConta.RegistroNotas.Count.ToString();
            _view.LblId.Text = customer.ClienteId.ToString();
        }

        private void FormTitleText(string titleText)
        {
            _view.TitleForm = $":: {titleText} ::";
        }

        private async Task<Cliente> GetCustomer()
        {
            try
            {
                var customer = await _customerRepository.GetClienteByIdWithRegistrosAsync(_view.CustomerId);

                if (customer == null) throw new Exception("Cliente não existe.");

                return customer;
            }
            catch (Exception)
            {
                throw new Exception("Erro ao carregar cliente.");
            }
        }
    }
}
