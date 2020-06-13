using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
using Models.Classes;
using Models.Exceptions;
using DAL.Database;
using Utils.Enum;
using Utils;
using Utils.Exceptions;

namespace WinDesktop.Forms
{
    public partial class frmOperacao : Form
    {
        private readonly AtendenteRepository _atendRepo;
        private readonly ClienteRepository _clienteRepo;

        private string _str = string.Empty;
        private Operacao _operacao;

        public frmOperacao(Cliente cliente, Operacao operacao)
        {
            InitializeComponent();
            Cliente = cliente;
            _operacao = operacao;
            _atendRepo = new AtendenteRepository();
            _clienteRepo = new ClienteRepository();
            GerenForm(operacao);
        }
        public Cliente Cliente { get; private set; }
        //CONTROLES\\
        private void frmOperacao_Load(object sender, EventArgs e)
        {
            CarregaDados();
            MostraOperacao();
            CarregaAtendente();
        }
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                Operacao aux;
                var valor = double.Parse(txtValorOperacao.Text);
                if (_operacao == Operacao.ADICIONAR)
                {
                    aux = Operacao.ADICIONAR;
                    Cliente.AdicionarValor(valor, cbAtendente.Text.ToString(), txtLog.Text);
                }
                else
                {
                    aux = Operacao.DEBITAR;
                    Cliente.DebitarValor(valor, cbAtendente.Text.ToString(), txtLog.Text);
                }
                _clienteRepo.AtualizarCliente(Cliente);
                StatusNotas.SetUltimaNota(Cliente.Nome, valor, DateTime.Now, aux);
                MessageBox.Show($"Operação de {_operacao} no valor de {valor.ToString("F2")} concluido com sucesso!", "INFO", MessageBoxButtons.OK,MessageBoxIcon.Information);
                DeletarRegistro();
                Dispose();
            }
            catch (OperacaoException ex)
            {
                MessageBox.Show(ex.Message, "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (AtendenteException ex)
            {
                MessageBox.Show(ex.Message, "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (ClienteException ex)
            {
                MessageBox.Show(ex.Message, "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void txtValorOperacao_KeyDown(object sender, KeyEventArgs e)
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
                txtValorOperacao.Text = string.Empty;
            }
            if (_str.Length == 1)
            {
                txtValorOperacao.Text = "0,0" + _str;
            }
            else if (_str.Length == 2)
            {
                txtValorOperacao.Text = "0," + _str;
            }
            else if (_str.Length > 2)
            {
                txtValorOperacao.Text = _str.Substring(0, _str.Length - 2) + "," +
                                _str.Substring(_str.Length - 2);
            }
        }
        private void txtValorOperacao_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        //METODOS\\
        private void GerenForm(Operacao operacao)
        {
            if (operacao == Operacao.ADICIONAR)
            {
                groupOperacao.BackColor = Color.SeaGreen;
                toolStrip1.BackColor = Color.SeaGreen;
                groupLog.BackColor = Color.SeaGreen;
            }
            else
            {
                toolStrip1.BackColor = Color.Brown;
                groupOperacao.BackColor = Color.Brown;
                groupLog.BackColor = Color.Brown;
            }
        }
        private void MostraOperacao()
        {
            groupOperacao.Text += _operacao.ToString() + " VALOR";
        }
        private void CarregaAtendente()
        {
            try
            {
                cbAtendente.DisplayMember = "usuario_atendente";
                cbAtendente.DataSource = ListaNomeAtendentes();
                cbAtendente.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private IList<string> ListaNomeAtendentes()
        {
            var listaNomes = new List<string>();
            foreach (var atendente in _atendRepo.ListaAtendentes())
            {
                listaNomes.Add(atendente.Nome);
            }
            return listaNomes;
        }
        private void CarregaDados()
        {
            try
            {
                lblNomeCliente.Text = Cliente.Nome;
                lblDataConta.Text = Cliente.NotaConta.DataConta;
                lblLimiteConta.Text = Cliente.NotaConta.LimiteConta.ToString("F2");
                lblLimiteRestante.Text = (Cliente.NotaConta.LimiteConta - Cliente.NotaConta.TotalConta).ToString("F2");
                lblTempoAberto.Text = CalculaTempo();
                lblTotalConta.Text = Cliente.NotaConta.TotalConta.ToString("F2");
            }
            catch (Exception e)
            {
                MessageBox.Show($"Erro ao exibir dados do cliente! Detalhes: {e.Message}", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private string CalculaTempo()
        {
            if (Cliente.NotaConta.DataConta == "ZERADO")
            {
                return "0";
            }
            TimeSpan date = Convert.ToDateTime(DateTime.Now.ToString("dd/MM/yy")) - Convert.ToDateTime(Cliente.NotaConta.DataConta);
            return date.Days.ToString();
        }
        private bool IsNumeric(int Val)
        {
            return ((Val >= 48 && Val <= 57) || (Val == 8) || (Val == 46));
        }

        private void DeletarRegistro()
        {
            try
            {
                if (Cliente.NotaConta.TotalConta == 0.0)
                {
                    var msgResultDialog =
                        MessageBox.Show("Deseja apagar todo o registro?\n\nNão é possível desfazer esta ação.", "Atenção!",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (msgResultDialog == DialogResult.Yes)
                    {
                        _clienteRepo.DeletarRegistro(Cliente);
                    }

                }
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
        }
    }
}
