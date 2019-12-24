using System;
using System.Drawing;
using System.Windows.Forms;
using Business.Class;

namespace UI.Forms
{
    public partial class frmCliente : Form
    {
        private DBManager _dbManager;
        private Cliente _cliente;
        private int sizeSplitDetail = 80;
        private Size _sizeParent;

        //CONSTRUTOR\\
        public frmCliente(Size sizeParent, Cliente cliente)
        {
            InitializeComponent();
            _sizeParent = sizeParent;
            SetDefaultSize();
            SetDefaultSplitDistance();
            _cliente = cliente;
            _dbManager = new DBManager();
        }

        //CONTROLES\\
        private void frmCliente_Load(object sender, EventArgs e)
        {
            ShowDados();
            LoadLog();
        }
        private void frmCliente_Resize(object sender, EventArgs e)
        {
            SetDefaultSplitDistance();
        }
        private void btnLogout_Click(object sender, EventArgs e)
        {
            Logout();
        }
        private void frmCliente_FormClosed(object sender, FormClosedEventArgs e)
        {
            Logout();
        }
        private void btnEditarDados_Click(object sender, EventArgs e)
        {
            frmGenCliente frm = new frmGenCliente(_cliente);
            frm.ShowDialog();

            if (frm.IsDisposed)
            {
                _cliente = frm.Cliente;
                ShowDados();
            }
        }
        private void btnAdicionarValor_Click(object sender, EventArgs e)
        {
            frmOperacao frm = new frmOperacao(_cliente, Operacao.ADICIONAR);
            frm.ShowDialog();

            if (frm.IsDisposed)
            {
                _cliente = frm.Cliente;
                ShowDados();
                LoadLog();
            }
        }
        private void btnDebitarValor_Click(object sender, EventArgs e)
        {
            frmOperacao frm = new frmOperacao(_cliente, Operacao.DEBITAR);
            frm.ShowDialog();

            if (frm.IsDisposed)
            {
                _cliente = frm.Cliente;
                ShowDados();
                LoadLog();
            }
        }

        //MÉTODOS\\
        private void ShowDados()
        {
            lblNomeCliente.Text = _cliente.Nome;
            lblDataConta.Text = _cliente.DataConta;
            lblLimiteConta.Text = _cliente.LimiteConta.ToString("F2");
            double limiteRestante = _cliente.LimiteConta - _cliente.TotalConta;
            lblLimiteRestante.Text = limiteRestante.ToString("F2");
            lblTotalConta.Text = _cliente.TotalConta.ToString("F2");

            lblApelido.Text = _cliente.Apelido;
            lblEndereco.Text = _cliente.Endereco;
            lblTelefone.Text = _cliente.Telefone;
            lblCpf.Text = _cliente.Cpf;
            lblNotasRegistradas.Text = _cliente.NumNotas.ToString();
            lblId.Text = _cliente.Id.ToString();
            VerificaStatus();
        }
        private void LoadLog()
        {
            try
            {
                dtgLog.DataSource = _dbManager.GetLog(_cliente.Id);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SetDefaultSize()
        {
            _sizeParent.Width = _sizeParent.Width / 2;
            _sizeParent.Height = _sizeParent.Height / 2;
            Size = _sizeParent;
            splitContainer.Panel1MinSize = _sizeParent.Width / 2;
        }
        private void SetDefaultSplitDistance()
        {
            splitContainer.SplitterDistance = (_sizeParent.Width / 2) - sizeSplitDetail;
        }
        private void Logout()
        {
            if (!this.IsDisposed)
            {
                this.Dispose();
            }
        }
        private void VerificaStatus()
        {
            if (_cliente.Status)
            {
                btnAdicionarValor.Enabled = _cliente.Status;
            }
            else 
            {
                btnAdicionarValor.Enabled = _cliente.Status;
            }
        }
    }
}
