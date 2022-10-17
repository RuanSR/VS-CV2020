﻿using CVirtual.Data.Repositories;
using CVirtual.Presenter;
using CVirtual.Shared.Classes;
using CVirtual.Shared.Enums;
using CVirtual.Shared.Struct;
using CVirtual.Utils;
using CVirtual.Views;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CVirtual.Views
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
            ClienteDataVisualizers = new List<ClienteDataVisualizer>();
            //Atendente = new Atendente();
        }
        private IList<ClienteDataVisualizer> ClienteDataVisualizers { get; set; }
        //private Atendente Atendente { get; set; }

        //CONTROLES\\
        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            try
            {
                Autenticar();
                //CheckLogin();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro! {ex.Message}", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void BtnLogin_Click(object sender, EventArgs e)
        {
            switch (btnLogin.Text)
            {
                case "Login":
                    Autenticar();
                    break;
                case "Logout":
                    txtPesquisa.Text = string.Empty;
                    new AuthPresenter().Logout();
                    CheckLogin();
                    break;
                default:
                    break;
            }
        }
        private async void BtnNovoCliente_Click(object sender, EventArgs e)
        {
            try
            {
                CustomerManagerForm frm = new CustomerManagerForm();
                frm.ShowDialog();

                if (frm.IsDisposed)
                {
                    await LoadDataSourceCliente();
                    GridViewClientes();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro no sistema. {ex.Message}", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void BtnSistema_Click(object sender, EventArgs e)
        {
            SystemManagerForm frm = new SystemManagerForm();
            frm.ShowDialog();
        }
        private async void DtgClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var ClienteId = (int)dtgClientes.Rows[e.RowIndex].Cells["IdCliente"].Value;
                var cliente = await new ClienteRepository().GetClienteByIdAsync(ClienteId);

                if (dtgClientes.Columns[e.ColumnIndex].Name == "btnAdd")
                {
                    ActionTypeForm frm = new ActionTypeForm(cliente.ClienteId, EOperationType.ADICIONAR);
                    frm.ShowDialog();
                    //frm.Cliente.NotaConta.RegistroNotas.Clear();
                    FrmIsDisposed(frm);
                }
                else if (dtgClientes.Columns[e.ColumnIndex].Name == "btnDebitar")
                {
                    ActionTypeForm frm = new ActionTypeForm(cliente.ClienteId, EOperationType.DEBITAR);
                    frm.ShowDialog();
                    FrmIsDisposed(frm);
                }
                AtualizaStatus();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao entrar na conta! Detalhes: {ex.Message}");
            }
        }
        private async void DtgClientes_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var ClienteId = (int)dtgClientes.Rows[e.RowIndex].Cells["IdCliente"].Value;
                var cliente = await new ClienteRepository().GetClienteByIdWithRegistrosAsync(ClienteId);

                CustomerForm frmCliente = new CustomerForm(ClienteId, Size);
                frmCliente.ShowDialog();
                FrmIsDisposed(frmCliente);
                AtualizaStatus();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao entrar na conta! Detalhes: {ex.Message}");
            }
        }
        private void TxtPesquisa_TextChanged(object sender, EventArgs e)
        {
            try
            {
                GridViewClientes(txtPesquisa.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void rbAtivos_CheckedChanged(object sender, EventArgs e)
        {
            GridViewClientes();
        }
        private void BtnAbout_Click(object sender, EventArgs e)
        {
            new AboutBoxForm().ShowDialog();
        }

        //METODOS\\
        List<ClienteDataVisualizer> ListaClientes(string searth = "", bool status = true)
        {
            try
            {
                return ClienteDataVisualizers
                    .Where(c =>
                    c.NomeCliente.ToLowerInvariant().Contains(searth.ToLowerInvariant())
                    && c.StatusCliente == status
                    || c.ApelidoCliente.ToLowerInvariant().Contains(searth.ToLowerInvariant())
                    && c.StatusCliente == status
                    ).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao obter dados dos clientes! Detalhes: {ex.Message}");
            }
        }
        void GridViewClientes(string searth = "")
        {
            if (rbAtivos.Checked)
            {
                dtgClientes.DataSource = ListaClientes(searth);
            }
            else
            {
                dtgClientes.DataSource = ListaClientes(searth, false);
            }
            Estilo();
        }
        private async Task LoadDataSourceCliente()
        {
            try
            {
                ClienteDataVisualizer clienteData;
                ClienteDataVisualizers.Clear();
                var listClientes = await new ClienteRepository().ListaClientesAsync();

                foreach (var cliente in listClientes)
                {
                    clienteData = new ClienteDataVisualizer(cliente.ClienteId, cliente.Nome, cliente.Apelido, cliente.Endereco,
                        cliente.NotaConta.LimiteConta, cliente.NotaConta.TotalConta, cliente.NotaConta.DataConta, cliente.Status);
                    ClienteDataVisualizers.Add(clienteData);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void Autenticar()
        {
            try
            {
                AuthForm frm = new AuthForm();
                frm.ShowDialog();

                if (frm.IsDisposed)
                {
                    CheckLogin();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async void CheckLogin()
        {
            try
            {
                if (AuthPresenter.isLoggedIn)
                {
                    await LoadDataSourceCliente();
                    EnableComponentes(true);
                    GridViewClientes();
                    btnLogin.Text = "Logout";
                }
                else
                {
                    EnableComponentes(false);
                    btnLogin.Text = "Login";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao obter permissão de login! Detalhes: {ex.Message}", "ERRO!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async void FrmIsDisposed(Form frm)
        {
            if (frm.IsDisposed)
            {
                await LoadDataSourceCliente();
                GridViewClientes(txtPesquisa.Text);
            }
        }
        void EnableComponentes(bool status)
        {
            btnSistema.Enabled = status;
            btnNovoCliente.Enabled = status;
            groupBoxPesquisa.Enabled = status;
            dtgClientes.Visible = status;
            statusBar.Visible = status;
        }
        void AtualizaStatus()
        {
            lblStatusRegistro.Text = "Último Registro: " + StatusNotas.GetUltimaNota;
        }
        private void Estilo()
        {
            for (int i = 0; i < dtgClientes.Rows.Count; i += 2)
            {
                dtgClientes.Rows[i].DefaultCellStyle.BackColor = Color.Lavender;
            }
        }
    }
}