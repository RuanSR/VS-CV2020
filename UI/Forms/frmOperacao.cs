using System;
using System.Windows.Forms;
using Business.Class;
using System.Globalization;
using System.Drawing;

namespace UI.Forms
{
    public partial class frmOperacao : Form
    {
        private string _str = string.Empty;
        private DBManager _dbManager;
        private Operacao _operacao;
        private Cliente _cliente;
        
        //CONTROLES\\
        public frmOperacao(Cliente cliente, Operacao operacao)
        {
            InitializeComponent();
            _cliente = cliente;
            _operacao = operacao;
            _dbManager = new DBManager();
            if (operacao == Operacao.ADICIONAR)
            {
                groupOperacao.BackColor = Color.SeaGreen;
                //txtValorOperacao.BackColor = Color.Green;
                toolStrip1.BackColor = Color.SeaGreen;
            }
            else
            {
                toolStrip1.BackColor = Color.Brown;
                groupOperacao.BackColor = Color.Brown;
            }
        }
        private void frmOperacao_Load(object sender, EventArgs e)
        {
            CarregaDados();
            MostraOperacao();
            CarregaAtendente();
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
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidaValor())
                {
                    if (ValidaAtendente())
                    {
                        if (MessageBox.Show("Tem certeze que deseja " + _operacao.ToString(), "ATENÇÂO!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            if (_operacao == Operacao.ADICIONAR)
                            {
                                if (double.Parse(txtValorOperacao.Text) <= (_cliente.LimiteConta - _cliente.TotalConta))
                                {
                                    _cliente.DataConta = DateTime.Now.ToString("dd/MM/yy");
                                    _cliente.TotalConta += double.Parse(txtValorOperacao.Text);
                                    _cliente.NumNotas++;
                                    _dbManager.AtualizaNota(ConverteVirgula(_cliente.TotalConta.ToString("F2")), ConverteVirgula(_cliente.TotalPago.ToString("F2", CultureInfo.InvariantCulture)), _cliente.NumNotas, _cliente.DataConta, _cliente.Id);
                                    MessageBox.Show("TUDO OK!");
                                    Dispose();
                                }
                                else
                                {
                                    MessageBox.Show("Valor da nota não pode ser maior que o limite da conta");
                                }
                            }
                            else
                            {
                                if (double.Parse(txtValorOperacao.Text) <= _cliente.TotalConta)
                                {
                                    _cliente.DataConta = DateTime.Now.ToString("dd/MM/yy");
                                    _cliente.TotalConta -= double.Parse(txtValorOperacao.Text);
                                    _cliente.TotalPago += double.Parse(ConverteVirgula(txtValorOperacao.Text));
                                    _dbManager.AtualizaNota(ConverteVirgula(_cliente.TotalConta.ToString("F2")), ConverteVirgula(_cliente.TotalPago.ToString("F2")), _cliente.NumNotas, _cliente.DataConta, _cliente.Id);
                                    MessageBox.Show("TUDO OK!");
                                    Dispose();
                                }
                                else
                                {
                                    MessageBox.Show("Valor do debito não pode ser maior que o valor em aberto!");
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Selecione o atendente!");
                    }
                }
                else
                {
                    MessageBox.Show("Digite um valor válido!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //METODOS\\
        private bool ValidaValor()
        {
            if (!string.IsNullOrEmpty(txtValorOperacao.Text))
            {
                return true;
            }
            return false;
        }
        private bool ValidaAtendente()
        {
            if (!string.IsNullOrEmpty(cbAtendente.Text.ToString()))
            {
                return true;
            }
            return false;
        }
        private void CarregaDados()
        {
            try
            {
                lblNomeCliente.Text = _cliente.Nome;
                lblDataConta.Text = _cliente.DataConta;
                lblLimiteConta.Text = _cliente.LimiteConta.ToString("F2", CultureInfo.InvariantCulture);
                lblLimiteRestante.Text = (_cliente.LimiteConta - _cliente.TotalConta).ToString("F2", CultureInfo.InvariantCulture);
                //lblTempoAberto.Text = CalculaTempo(TimeSpan.Parse("01/12/2019"));
                lblTotalConta.Text = _cliente.TotalConta.ToString("F2", CultureInfo.InvariantCulture);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao exibir dados do cliente! Detalhes: {ex.Message}", "ERRO!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                cbAtendente.SelectedIndex = -1;
                cbAtendente.ValueMember = "id_atendente";
                cbAtendente.DisplayMember = "usuario_atendente";
                cbAtendente.DataSource = _dbManager.GetAtendentes();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private string CalculaTempo(TimeSpan time)
        {
            return time.Days.ToString();
        }
        private bool IsNumeric(int Val)
        {
            return ((Val >= 48 && Val <= 57) || (Val == 8) || (Val == 46));
        }
        private string ConverteVirgula(string valor)
        {
            return valor.Replace(".", ",");
        }
    }
}
