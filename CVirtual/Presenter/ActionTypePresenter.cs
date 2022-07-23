using CVirtual.Data.Repositories;
using CVirtual.Shared.Classes;
using CVirtual.Shared.Enums;
using CVirtual.Shared.Enuns;
using CVirtual.Shared.Exceptions;
using CVirtual.Utils;
using CVirtual.Views.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CVirtual.Presenter
{
    public class ActionTypePresenter
    {
        private readonly ClienteRepository _clienteRepository;
        private readonly ArquivoRegistrosRepository _arquivoRegistrosRepository;
        private readonly AtendenteRepository _atendenteRepository;
        private readonly IActionView _view;
        private const double DEFAULT_VALUE = 0.0;

        public ActionTypePresenter(IActionView view)
        {
            _clienteRepository = new ClienteRepository();
            _arquivoRegistrosRepository = new ArquivoRegistrosRepository();
            _atendenteRepository = new AtendenteRepository();
            _view = view;
        }

        public async Task LoadCustomerData()
        {
            if (_view.CustomerId <= 0) throw new ArgumentException($"Valor do argumento {nameof(_view.CustomerId)} não pode ser menor ou igual a zero.");

            var customer = await GetCustomer();

            if (customer == null) throw new ClienteException("Cliente não pode ser nulo", ExceptionInfoType.InfoMessage);

            _view.LblFullName.Text = customer.Nome;
            _view.LblDate.Text = customer.NotaConta.DataConta;
            _view.LblMaxAmount.Text = customer.NotaConta.LimiteConta.ToString("F2");
            _view.LblRemainderAmount.Text = (customer.NotaConta.LimiteConta - customer.NotaConta.TotalConta).ToString("F2");
            _view.LblTotalDays.Text = Util.GetClienteTotalDays(customer).ToString();
            _view.LblTotalAmount.Text = customer.NotaConta.TotalConta.ToString("F2");
        }
        public async Task LoadEmployeeData()
        {
            _view.BoxEmployee.DisplayMember = "usuario_atendente";
            _view.BoxEmployee.DataSource = await GetEmployeeData();
            _view.BoxEmployee.SelectedIndex = -1;
        }
        private async Task<IList<string>> GetEmployeeData()
        {
            var employeeListNames = new List<string>();
            var employeeList = await _atendenteRepository.ListaAtendentesAsync();
            foreach (var atendente in employeeList)
            {
                employeeListNames.Add(atendente.Nome);
            }
            return employeeListNames;
        }
        public async Task UpdateCustomerData()
        {
            var customer = await GetCustomer();
            if (customer == null) throw new ClienteException("Cliente não pode ser nulo!", ExceptionInfoType.InfoMessage);

            var amount = double.Parse(_view.TxtAmount.Text);

            customer.NotaConta.NewOperation(_view.EActionType, amount, _view.BoxEmployee.Text.ToString(),
                    _view.TxtNoteDetails.Text);

            await _clienteRepository.AtualizarClienteAsync(customer);
        }
        public async Task ArchiveRecords()
        {
            var customer = await GetCustomer();
            if (customer == null) throw new ClienteException("Cliente não pode ser nulo!", ExceptionInfoType.InfoMessage);

            if (AllowStorageLog(customer.NotaConta.TotalConta))
            {
                customer.NotaConta.ArquivarRegistros();

                await _clienteRepository.DeletarRegistroAsync(customer);
                await _arquivoRegistrosRepository.ArquivarRegistros(customer);
            }
        }
        private async Task<Cliente> GetCustomer()
        {
            if (_view.CustomerId <= 0) throw new ArgumentException($"Valor do argumento {nameof(_view.CustomerId)} não pode ser menor ou igual a zero.");
            return await _clienteRepository.GetClienteByIdWithRegistrosAsync(_view.CustomerId);
        }
        private bool AllowStorageLog(double value)
        {
            if (value < DEFAULT_VALUE) throw new ArgumentException($"Valor do argumento {nameof(value)} não pode ser menor que zero.");

            return value == 0.0;
        }
    }
}
