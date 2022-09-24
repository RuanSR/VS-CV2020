using CVirtual.Data.Repositories;
using CVirtual.Presenter;
using CVirtual.Shared.Classes;
using CVirtual.Shared.Exceptions;
using CVirtual.Views;
using CVirtual.Views.Interfaces;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CVirtual.Views
{
    public partial class CustomerManagerForm : Form, ICustomerManagerView
    {
        private readonly int? _customer;
        private readonly CustomerManagerPresenter _customerManagerPresenter;
        private string _str = string.Empty;

        public CustomerManagerForm(int? customer = null)
        {
            InitializeComponent();
            _customer = customer;
            _customerManagerPresenter = new CustomerManagerPresenter(this);
        }

        public int? CustomerId => _customer;

        public Form ContextForm => this;

        public TextBox TxtFullName => txtFullName;

        public TextBox TxtAddress => txtAddress;

        public TextBox TxtApelido => txtApelido;

        public MaskedTextBox TxtCellPhone => txtCellPhone;

        public MaskedTextBox TxtCpf => txtCpf;

        public TextBox TxtMaxLimit => txtMaxLimit;

        public CheckBox CkAccountStatus => ckAccountStatus;

        public ToolStripButton BtnSave => btnSave;

        public ToolStripButton BtnDelete => btnDelete;

        private async void OnLoad(object sender, EventArgs e)
        {
            await _customerManagerPresenter.ManagerForm();
        }
        
        private async void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                await _customerManagerPresenter.SaveCustomer();

                var messageInfo = CustomerId <= 0 ? "criado" : "atualizado";

                MessageBox.Show($"Cliente {messageInfo} com sucesso!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Dispose();
            }
            catch (ClienteException ex)
            {
                MessageBox.Show(ex.GetMessageInfo, ex.GetMessageType, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (NotaContaException ex)
            {
                MessageBox.Show(ex.Message, "Info", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Info", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var result = MessageBox.Show("TEM CERTEZA QUE DESEJA EXLUIR ESTE CLINTE?\nISTO APAGARÁ:" +
                    "\nTODOS OS DADOS DO CLIENTE." +
                    "\nTODOS OS REGISTROS DO CLIENTE." +
                    "\nNÃO É POSSÍVEL DESFAZER ESTA AÇÃO, DESEJA CONTINUAR?",
                    "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                if (result == DialogResult.Yes)
                {
                    AuthForm frm = new AuthForm();
                    frm.ShowDialog();
                }

                var customer = await _customerManagerPresenter.DeleteCustomer();
                MessageBox.Show($"Cliente {customer.Nome} removido com sucesso!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Dispose();
            }
            catch (ClienteException ex)
            {
                MessageBox.Show(ex.Message, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (NotaContaException ex)
            {
                MessageBox.Show(ex.Message, "Info", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void TxtMaxLimit_KeyDown(object sender, KeyEventArgs e)
        {
            int KeyCode = e.KeyValue;

            if (!IsNumeric(KeyCode))
            {
                e.Handled = true;
                return;
            }
            else
            {
                e.Handled = true;
            }
            if (((KeyCode == 8) || (KeyCode == 46)) && (_str.Length > 0))
            {
                _str = _str.Substring(0, _str.Length - 1);
            }
            else if (!((KeyCode == 8) || (KeyCode == 46)))
            {
                _str = _str + Convert.ToChar(KeyCode);
            }
            if (_str.Length == 0)
            {
                txtMaxLimit.Text = string.Empty;
            }
            if (_str.Length == 1)
            {
                txtMaxLimit.Text = "0,0" + _str;
            }
            else if (_str.Length == 2)
            {
                txtMaxLimit.Text = "0," + _str;
            }
            else if (_str.Length > 2)
            {
                txtMaxLimit.Text = _str.Substring(0, _str.Length - 2) + "," +
                                _str.Substring(_str.Length - 2);
            }
        }
        private void TxtMaxLimit_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        private bool IsNumeric(int Val)
        {
            return ((Val >= 48 && Val <= 57) || (Val == 8) || (Val == 46));
        }
    }
}
