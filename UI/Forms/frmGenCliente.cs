using System;
using System.Globalization;
using System.Windows.Forms;
using Business.Class;

namespace UI.Forms
{
    public partial class frmGenCliente : Form
    {
        private string _str = string.Empty;
        private Cliente _cliente;
        private DBManager _dbManager;
        public frmGenCliente(Cliente cliente = null)
        {
            InitializeComponent();
            _dbManager = new DBManager();
            _cliente = cliente;
        }
        private void frmGenCliente_Load(object sender, EventArgs e)
        {
            GenCliente();
        }

        //CONTROLES\\
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidaCliente())
                {
                    if (GenCliente())
                    {
                        //atualizar\\
                        _dbManager.AtualizaCliente(_cliente.Id, _cliente.Nome, _cliente.Apelido, _cliente.Endereco, _cliente.Telefone,
                            _cliente.Cpf, _cliente.LimiteConta.ToString("F2",CultureInfo.InvariantCulture), _cliente.TotalConta.ToString("F2",CultureInfo.InvariantCulture), _cliente.TotalPago.ToString("F2", CultureInfo.InvariantCulture), _cliente.NumNotas, _cliente.DataConta, _cliente.Status);
                        MessageBox.Show("Cliente atualizado com sucesso!", "ATENÇÂO!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        //gravar novo\\
                        _dbManager.NovoCliente(txtNomeCompleto.Text, txtApelido.Text,txtEndereco.Text, txtTelefone.Text, txtCpf.Text, txtLimite.Text, "0,0", "0,0", 0, "SEM DADOS", true);
                        MessageBox.Show("Cliente inserido com sucesso!", "ATENÇÂO!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    Dispose();
                }
                else
                {
                    MessageBox.Show("Preencha tudo corretamente!", "ATENÇÂO!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void txtLimite_KeyDown(object sender, KeyEventArgs e)
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
                txtLimite.Text = string.Empty;
            }
            if (_str.Length == 1)
            {
                txtLimite.Text = "0,0" + _str;
            }
            else if (_str.Length == 2)
            {
                txtLimite.Text = "0," + _str;
            }
            else if (_str.Length > 2)
            {
                txtLimite.Text = _str.Substring(0, _str.Length - 2) + "," +
                                _str.Substring(_str.Length - 2);
            }
        }
        private void txtLimite_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        //METODOS\\
        private bool GenCliente()
        {
            if (_cliente != null)
            {
                txtNomeCompleto.Text = _cliente.Nome;
                txtApelido.Text = _cliente.Apelido;
                txtEndereco.Text = _cliente.Endereco;
                txtTelefone.Text = _cliente.Telefone;
                txtCpf.Text = _cliente.Cpf;
                txtLimite.Text = _cliente.LimiteConta.ToString();
                ckStatus.Checked = _cliente.Status;
                ckStatus.Enabled = true;
                return true;//Atualizar
            }
            return false;//Novo
        }
        private bool ValidaCliente()
        {
            if (txtNomeCompleto.Text != string.Empty
                && txtApelido.Text != string.Empty
                && txtEndereco.Text != string.Empty
                && txtTelefone.Text != string.Empty
                //&& txtCpf.Text != string.Empty
                && txtLimite.Text != string.Empty
                )
            {
                return true;
            }
            return false;
        }
        private bool IsNumeric(int Val)
        {
            return ((Val >= 48 && Val <= 57) || (Val == 8) || (Val == 46));
        }
    }
}
