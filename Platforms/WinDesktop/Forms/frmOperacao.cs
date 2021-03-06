﻿using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
using Models.Classes;
using Models.Exceptions;
using DAL.Database;
using Utils.Enum;
using Utils;
using Utils.Exceptions;
using System.Threading.Tasks;
using DAL.Repositories;

namespace WinDesktop.Forms
{
    public partial class frmOperacao : Form
    {
        private string _str = string.Empty;
        private Operacao _operacao;

        public frmOperacao(Cliente cliente, Operacao operacao)
        {
            InitializeComponent();
            Cliente = cliente;
            _operacao = operacao;
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
        private async void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                Operacao aux;
                var valor = double.Parse(txtValorOperacao.Text);
                if (_operacao == Operacao.ADICIONAR)
                {
                    aux = Operacao.ADICIONAR;
                    Cliente.NotaConta.AdicionarValor(valor, cbAtendente.Text.ToString(), txtLog.Text);
                }
                else
                {
                    aux = Operacao.DEBITAR;
                    Cliente.NotaConta.DebitarValor(valor, cbAtendente.Text.ToString(), txtLog.Text);
                }
                await new ClienteRepository().AtualizarClienteAsync(Cliente);
                StatusNotas.SetUltimaNota(Cliente.Nome, valor, DateTime.Now, aux);
                MessageBox.Show($"Operação de {_operacao} no valor de {valor.ToString("F2")} concluido com sucesso!", "INFO", MessageBoxButtons.OK,MessageBoxIcon.Information);
                await ArquivarRegistros();
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
        private async void CarregaAtendente()
        {
            try
            {
                cbAtendente.DisplayMember = "usuario_atendente";
                cbAtendente.DataSource = await ListaNomeAtendentes();
                cbAtendente.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async Task<IList<string>> ListaNomeAtendentes()
        {
            var listaNomes = new List<string>();
            var listAtendentes = await new AtendenteRepository().ListaAtendentesAsync();
            foreach (var atendente in listAtendentes)
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

        private async Task ArquivarRegistros()
        {
            try
            {
                if (Cliente.NotaConta.TotalConta == 0.0)
                {
                    var arquvioRepo = new ArquivoRegistrosRepository();
                    var clienteRepo = new ClienteRepository();
                    Cliente.NotaConta.RegistroNotas = clienteRepo
                        .GetClienteByIdWithRegistrosAsync(Cliente.ClienteId)
                        .Result
                        .NotaConta.RegistroNotas;

                    //var listaRegistros = clienteRepo.GetClienteByIdWithRegistrosAsync(Cliente.ClienteId)
                    //    .Result.NotaConta.RegistroNotas;
                    Cliente.NotaConta.ArquivarRegistros();
                    await clienteRepo.DeletarRegistroAsync(Cliente);
                    await arquvioRepo.ArquivarRegistros(Cliente);

                }
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
        }
    }
}
