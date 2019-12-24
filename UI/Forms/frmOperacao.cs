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
        public Cliente Cliente { get; private set; }

        //CONTROLES\\
        public frmOperacao(Cliente cliente, Operacao operacao)
        {
            InitializeComponent();
            Cliente = cliente;
            _operacao = operacao;
            _dbManager = new DBManager();
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
                                if (double.Parse(txtValorOperacao.Text) <= (Cliente.LimiteConta - Cliente.TotalConta))
                                {
                                    string log = txtLog.Text.ToString();
                                    Cliente.DataConta = DateTime.Now.ToString("dd/MM/yy");
                                    Cliente.TotalConta += double.Parse(txtValorOperacao.Text);
                                    Cliente.NumNotas++;

                                    if (log == string.Empty)
                                    {
                                        log = "SEM DETALHES!";
                                    }

                                    _dbManager.AtualizaNota(ConverteVirgula(Cliente.TotalConta.ToString("F2")), ConverteVirgula(Cliente.TotalPago.ToString("F2", CultureInfo.InvariantCulture)), Cliente.NumNotas, Cliente.DataConta, Cliente.Id);
                                    _dbManager.GravaLog(Cliente.Id, DateTime.Now.ToString("dd/MM/yy"), DateTime.Now.ToString("HH:mm:ss"), cbAtendente.Text.ToString(), txtValorOperacao.Text, log);
                                    
                                    MessageBox.Show("TUDO OK!", "ATENÇÂO!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    Dispose();
                                }
                                else
                                {
                                    MessageBox.Show("Valor da nota não pode ser maior que o limite da conta", "ATENÇÂO!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                            else
                            {
                                if (double.Parse(txtValorOperacao.Text) <= Cliente.TotalConta)
                                {
                                    string log = txtLog.Text.ToString();
                                    Cliente.DataConta = DateTime.Now.ToString("dd/MM/yy");
                                    Cliente.TotalConta -= double.Parse(txtValorOperacao.Text);
                                    Cliente.TotalPago += double.Parse(ConverteVirgula(txtValorOperacao.Text));


                                    if (log == string.Empty)
                                    {
                                        log = "DEBITO EFETUADO! SEM OBSERVAÇÔES!";
                                    }
                                    else
                                    {
                                        log = "DEBITO EFETUADO!" + txtLog.Text.Trim();
                                    }

                                    _dbManager.AtualizaNota(ConverteVirgula(Cliente.TotalConta.ToString("F2")), ConverteVirgula(Cliente.TotalPago.ToString("F2")), Cliente.NumNotas, Cliente.DataConta, Cliente.Id);
                                    _dbManager.GravaLog(Cliente.Id, DateTime.Now.ToString("dd/MM/yy"), DateTime.Now.ToString("HH:mm:ss"), cbAtendente.Text.ToString(), txtValorOperacao.Text, log);
                                    
                                    
                                    MessageBox.Show("TUDO OK!", "ATENÇÂO!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    Dispose();
                                }
                                else
                                {
                                    MessageBox.Show("Valor do debito não pode ser maior que o valor total!", "ATENÇÂO!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Selecione o atendente!", "ATENÇÂO!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Digite um valor válido!", "ATENÇÂO!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ATENÇÂO!", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                lblNomeCliente.Text = Cliente.Nome;
                lblDataConta.Text = Cliente.DataConta;
                lblLimiteConta.Text = Cliente.LimiteConta.ToString("F2", CultureInfo.InvariantCulture);
                lblLimiteRestante.Text = (Cliente.LimiteConta - Cliente.TotalConta).ToString("F2", CultureInfo.InvariantCulture);
                //lblTempoAberto.Text = CalculaTempo(TimeSpan.Parse("01/12/2019"));
                lblTotalConta.Text = Cliente.TotalConta.ToString("F2", CultureInfo.InvariantCulture);
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
