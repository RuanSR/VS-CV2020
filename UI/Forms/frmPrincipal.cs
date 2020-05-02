using Controller;
using Model.Classes;
using Model.Classes.ClienteModel;
using Model.Enum;
using Model.Struct;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace UI.Forms
{
    public partial class FrmPrincipal : Form
    {
        private IList<ClienteDataVisualizer> ClienteDataVisualizers { get; set; }
        private readonly ClienteController _cController;
        public FrmPrincipal()
        {
            InitializeComponent();
            _cController = new ClienteController();
            ClienteDataVisualizers = new List<ClienteDataVisualizer>();
            Atendente = new Atendente();
        }
        private Atendente Atendente { get; set; }

        //CONTROLES\\
        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            try
            {
                Autenticar();
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
                    Atendente = null;
                    CheckLogin();
                    break;
                default:
                    break;
            }
        }
        private void BtnNovoCliente_Click(object sender, EventArgs e)
        {
            try
            {
                frmGenCliente frm = new frmGenCliente();
                frm.ShowDialog();

                if (frm.IsDisposed)
                {
                    LoadDataSourceCliente();
                    GridViewClientes();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro no sistema. {ex.Message}", "ERRO",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void BtnSistema_Click(object sender, EventArgs e)
        {
            frmGerenciadorSistema frm = new frmGerenciadorSistema();
            frm.ShowDialog();

            //if (frm.IsDisposed)
            //{
            //    LoadDataSourceCliente();
            //    ListarClientes();
            //}
        }
        private void DtgClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var ClienteId = (int)dtgClientes.Rows[e.RowIndex].Cells["IdCliente"].Value;
                var cliente = GetCliente(ClienteId);

                if (dtgClientes.Columns[e.ColumnIndex].Name == "btnAdd")
                {
                    frmOperacao frm = new frmOperacao(cliente, Operacoes.ADICIONAR);
                    frm.ShowDialog();
                    FrmIsDisposed(frm);
                }
                else if (dtgClientes.Columns[e.ColumnIndex].Name == "btnDebitar")
                {
                    frmOperacao frm = new frmOperacao(cliente, Operacoes.DEBITAR);
                    frm.ShowDialog();
                    FrmIsDisposed(frm);
                }
                AtualizaStatus();
            }
            catch (Exception ex)
            {
                //MessageBox.Show($"Erro ao entrar na conta! Detalhes: {ex.Message}");
            }
        }
        private void DtgClientes_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var ClienteId = (int)dtgClientes.Rows[e.RowIndex].Cells["IdCliente"].Value;
                var cliente = GetCliente(ClienteId);

                frmCliente frmCliente = new frmCliente(Size, cliente);
                frmCliente.ShowDialog();
                FrmIsDisposed(frmCliente);
                AtualizaStatus();
            }
            catch (Exception ex)
            {
                //MessageBox.Show($"Erro ao entrar na conta! Detalhes: {ex.Message}");
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
        private void TimeBackup_Tick(object sender, EventArgs e)
            {
                try
                {
                    //SysSettings.CreateBackup();
                    //lblUltimoBackup.Text = "Último Backup: " + DateTime.Now.ToString("HH:mm:ss");
                    //timeBackup.Start();
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
            new AboutBox().ShowDialog();
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
        Cliente GetCliente(int id)
        {
            return _cController.ListaClienteWithRegistros()
                .Where(c => c.ClienteId == id)
                .FirstOrDefault();
        }
        void LoadDataSourceCliente()
        {
            try
            {
                ClienteDataVisualizer clienteData;
                ClienteDataVisualizers.Clear();
                var listClientes = _cController.ListaClientes();

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
                frmLogin frm = new frmLogin();
                frm.ShowDialog();

                Atendente = frm.Atendente;

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
        void CheckLogin()
        {
            try
            {
                if (Atendente != null)
                {
                    LoadDataSourceCliente();
                    EnableComponentes(true);
                    GridViewClientes();
                    //StartTimer(AppManager.IntervaloBackup[AppManager.SelectedTimerIndex]);
                    btnLogin.Text = "Logout";
                }
                else
                {
                    EnableComponentes(false);
                    //timeBackup.Stop();
                    btnLogin.Text = "Login";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao obter permissão de login! Detalhes: {ex.Message}", "ERRO!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void FrmIsDisposed(Form frm)
        {
            if (frm.IsDisposed)
            {
                LoadDataSourceCliente();
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
            lblStatusRegistro.Text = "Último Registro: " + AppController.GetUltimaNota;
        }
        private void StartTimer(int time)
        {
            timeBackup.Interval = time;
            timeBackup.Start();
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