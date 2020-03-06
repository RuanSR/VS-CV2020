using System;
using System.Windows.Forms;
using Controller;
using Model.Classes;
using Model.Classes.ClienteModel;
using Model.Exceptions;

namespace UI.Forms
{
    public partial class frmGenCliente : Form
    {
        private ClienteController _cController; 
        private string _str = string.Empty;
        public frmGenCliente(Cliente cliente = null)
        {
            InitializeComponent();
            Cliente = cliente;
            _cController = new ClienteController();
        }
        public Cliente Cliente { get; private set; }

        //CONTROLES\\
        private void frmGenCliente_Load(object sender, EventArgs e)
        {
            MessageBox.Show(Cliente.NotaConta.TotalConta.ToString("F2"));
            GerenForm();
        }
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                SalvarCliente();
            }
            catch (ClienteException ex)
            {
                MessageBox.Show(ex.Message, "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(NotaContaException ex)
            {
                MessageBox.Show(ex.Message, "INFO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void BtnExluir_Click(object sender, EventArgs e)
        {
            try
            {
                ExcluirCliente();
            }
            catch (ClienteException ex)
            {
                MessageBox.Show(ex.Message, "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (NotaContaException ex)
            {
                MessageBox.Show(ex.Message, "INFO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        private void GerenForm()
        {
            if (Cliente != null)
            {
                this.Text = $":: {Cliente.Nome} ::";
                txtNomeCompleto.Text = Cliente.Nome;
                txtApelido.Text = Cliente.Apelido;
                txtEndereco.Text = Cliente.Endereco;
                txtTelefone.Text = Cliente.Telefone;
                txtCpf.Text = Cliente.Cpf;
                txtLimite.Text = Cliente.NotaConta.LimiteConta.ToString("F2");
                ckStatus.Checked = Cliente.Status;
                ckStatus.Enabled = true;
            }
            else
            {
                BtnExluir.Visible = false;
            }
        }
        private void SalvarCliente()
        {
            try
            {
                if (Cliente != null)
                {
                    Cliente.AtualizarCliente(txtNomeCompleto.Text, txtApelido.Text, txtEndereco.Text, txtTelefone.Text, txtCpf.Text, ckStatus.Checked);
                    Cliente.NotaConta.AtualizarNota(double.Parse(txtLimite.Text), Cliente.NotaConta.TotalConta, Cliente.NotaConta.DataConta);
                    _cController.AtualizarCliente(Cliente);
                    MessageBox.Show("Cliente atualizado com sucesso!", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    _cController.NovoCliente(new Cliente(txtNomeCompleto.Text, txtApelido.Text, txtEndereco.Text, txtTelefone.Text, txtCpf.Text, double.Parse(txtLimite.Text)));
                    MessageBox.Show("Cliente inserido com sucesso!", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                Dispose();
            }
            catch(ClienteException e)
            {
                throw e;
            }
            catch(NotaContaException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        private void ExcluirCliente()
        {
            var result = MessageBox.Show("TEM CERTEZA QUE DESEJA EXLUIR ESTE CLINTE?\nISTO APAGARÁ:" +
                "\nTODOS OS DADOS DO CLIENTE." +
                "\nTODOS OS REGISTROS DO CLIENTE." +
                "\nNÃO É POSSÍVEL DESFAZER ESTA AÇÃO, DESEJA CONTINUAR?",
                "ATENÇÃO!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (result == DialogResult.Yes)
            {
                if (Cliente.NotaConta.TotalConta == 0.0)
                {
                    frmLogin frm = new frmLogin();
                    frm.ShowDialog();
                    if (frm.Atendente.AtendenteId == 1)
                    {
                        _cController.RemoverCliente(Cliente);
                        Cliente = null;
                        this.Dispose();
                    }
                    else
                    {
                        MessageBox.Show("Você precisa logar como administrador para fazer esta ação!", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Não foi permitido a exclusão do cliente, é preciso zerar o total.", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        private bool IsNumeric(int Val)
        {
            return ((Val >= 48 && Val <= 57) || (Val == 8) || (Val == 46));
        }

    }
}
