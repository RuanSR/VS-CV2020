using System;
using System.Windows.Forms;
using Business.Class;

namespace UI.Forms
{
    public partial class frmGenCliente : Form
    {
        private string _str = string.Empty;
        public Cliente Cliente { get; private set; }
        private DBManager _dbManager;
        public frmGenCliente(Cliente cliente = null)
        {
            InitializeComponent();
            _dbManager = new DBManager();
            Cliente = cliente;
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
                    if (Cliente != null)
                    {
                        AtualizaCliente(txtNomeCompleto.Text, txtApelido.Text, txtEndereco.Text, txtTelefone.Text, txtCpf.Text, double.Parse(txtLimite.Text), ckStatus.Checked);
                        //atualizar\\
                        _dbManager.AtualizaCliente(Cliente.Id, Cliente.Nome, Cliente.Apelido, Cliente.Endereco, Cliente.Telefone,
                            Cliente.Cpf, Cliente.LimiteConta.ToString("F2"), Cliente.TotalConta.ToString("F2"), Cliente.TotalPago.ToString("F2"), Cliente.NumNotas, Cliente.DataConta, Cliente.Status);
                        MessageBox.Show("Cliente atualizado com sucesso!", "ATENÇÂO!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        //gravar novo\\
                        _dbManager.NovoCliente(txtNomeCompleto.Text, txtApelido.Text,txtEndereco.Text, txtTelefone.Text, txtCpf.Text, txtLimite.Text, "0,0", "0,0", 0, "ZERADO", true);
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
            if (Cliente != null)
            {
                txtNomeCompleto.Text = Cliente.Nome;
                txtApelido.Text = Cliente.Apelido;
                txtEndereco.Text = Cliente.Endereco;
                txtTelefone.Text = Cliente.Telefone;
                txtCpf.Text = Cliente.Cpf;
                txtLimite.Text = Cliente.LimiteConta.ToString("F2");
                ckStatus.Checked = Cliente.Status;
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
        private void AtualizaCliente(string nome,string apelido, string endereco, string telefone, string cpf, double limiteConta, bool status)
        {
            Cliente.Nome = nome;
            Cliente.Apelido = apelido;
            Cliente.Endereco = endereco;
            Cliente.Telefone = telefone;
            Cliente.Cpf = cpf;
            Cliente.LimiteConta = limiteConta;
            Cliente.Status = status;
        }
    }
}
