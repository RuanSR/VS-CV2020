using DAL.Database;
using Models.Classes;
using Models.Enum;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace WinDesktop.Forms
{
    public partial class frmCliente : Form
    {
        private readonly ClienteRepository _clienteRepo;

        private Cliente _cliente;
        private Size _sizeParent;

        public frmCliente(Size sizeParent, Cliente cliente)
        {
            InitializeComponent();
            _clienteRepo = new ClienteRepository();
            _sizeParent = sizeParent;
            _cliente = cliente;
            SetDefaultSize();
            SetDefaultSplitDistance();
        }

        //CONTROLES\\
        private void frmCliente_Load(object sender, EventArgs e)
        {
            GerenForm();
            ShowDados();
            LoadLog();
        }
        private void GerenForm()
        {
            this.Text = $":: {_cliente.Nome} ::";
        }
        private void btnAdicionarValor_Click(object sender, EventArgs e)
        {
            frmOperacao frm = new frmOperacao(_cliente, Operacoes.ADICIONAR);
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
            frmOperacao frm = new frmOperacao(_cliente, Operacoes.DEBITAR);
            frm.ShowDialog();

            if (frm.IsDisposed)
            {
                _cliente = frm.Cliente;
                ShowDados();
                LoadLog();
            }
        }
        private void btnEditarDados_Click(object sender, EventArgs e)
        {
            frmGenCliente frm = new frmGenCliente(_cliente);
            frm.ShowDialog();

            if (frm.IsDisposed)
            {
                if (frm.Cliente != null)
                {
                    _cliente = frm.Cliente;
                    ShowDados();
                }
                else
                {
                    Close();
                }
            }
        }
        private void btnLogout_Click(object sender, EventArgs e)
        {
            Logout();
        }
        private void frmCliente_FormClosed(object sender, FormClosedEventArgs e)
        {
            Logout();
        }
        private void frmCliente_Resize(object sender, EventArgs e)
        {
            try
            {
                SetDefaultSplitDistance();
                dtgLog.Columns["log_registro"].Width = _sizeParent.Width;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao calcular tamanho da janela. {ex.Message}", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeletaRegistro_Click(object sender, EventArgs e)
        {
            try
            {
                DeletarRegistro();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //MÉTODOS\\
        private void ShowDados()
        {
            lblNomeCliente.Text = _cliente.Nome;
            lblDataConta.Text = _cliente.NotaConta.DataConta;
            lblLimiteConta.Text = _cliente.NotaConta.LimiteConta.ToString("F2");
            double limiteRestante = _cliente.NotaConta.LimiteConta - _cliente.NotaConta.TotalConta;
            lblLimiteRestante.Text = limiteRestante.ToString("F2");
            lblTotalConta.Text = _cliente.NotaConta.TotalConta.ToString("F2");
            lblTempoAberto.Text = CalculaTempo();

            lblApelido.Text = _cliente.Apelido;
            lblEndereco.Text = _cliente.Endereco;
            lblTelefone.Text = _cliente.Telefone;
            lblCpf.Text = _cliente.Cpf;
            lblNotasRegistradas.Text = _cliente.NotaConta.RegistroNotas.Count.ToString();
            lblId.Text = _cliente.ClienteId.ToString();
            VerificaStatus();
        }
        private void LoadLog()
        {
            try
            {
                dtgLog.DataSource = _cliente.NotaConta.RegistroNotas
                    .OrderByDescending(c => c.DataHora)
                    .ToList();
                Estilo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Estilo()
        {
            for (int i = 0; i < dtgLog.Rows.Count; i += 2)
            {
                dtgLog.Rows[i].DefaultCellStyle.BackColor = Color.Lavender;
            }
        }
        private string CalculaTempo()
        {
            if (_cliente.NotaConta.DataConta == "ZERADO")
            {
                return "0";
            }
            TimeSpan date = Convert.ToDateTime(DateTime.Now.ToString("dd/MM/yy")) - Convert.ToDateTime(_cliente.NotaConta.DataConta);
            return date.Days.ToString();
        }
        private void SetDefaultSize()
        {
            _sizeParent.Width = _sizeParent.Width / 2;
            _sizeParent.Height = _sizeParent.Height / 2;
            Size = _sizeParent;
            splitContainer.Panel1MinSize = _sizeParent.Width / 2;
            dtgLog.Columns["log_registro"].Width += _sizeParent.Width;
        }
        private void SetDefaultSplitDistance()
        {
            splitContainer.SplitterDistance = (_sizeParent.Width / 2);
        }
        private void Logout()
        {
            if (!this.IsDisposed)
            {
                _cliente = null;
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
        private void DeletarRegistro()
        {
            try
            {
                if (_cliente.NotaConta.RegistroNotas.Count != 0)
                {
                    var msgResultDialog =
                        MessageBox.Show("Deseja apagar todo o registro?\n\nNão é possível desfazer esta ação.", "Atenção!",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (msgResultDialog == DialogResult.Yes)
                    {
                        if (_cliente.NotaConta.TotalConta == 0.0)
                        {
                            _clienteRepo.DeletarRegistro(_cliente);
                            _cliente.NotaConta.RegistroNotas.Clear();
                            dtgLog.DataSource = _cliente.NotaConta.RegistroNotas;
                        }
                        else
                        {
                            MessageBox.Show("Não foi permitido a exclusão do registro, é preciso zerar o total da conta.", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }

                }
                else
                {
                    MessageBox.Show("Não existe registro para ser limpo.", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }

        }
    }
}
