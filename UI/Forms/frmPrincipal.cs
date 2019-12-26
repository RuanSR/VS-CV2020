using System;
using System.Windows.Forms;
using Business.Class;

namespace UI.Forms
{
    public partial class frmPrincipal : Form
    {
        private BindingSource DataSourceCliente { get; set; }
        private DBManager dbManager { get; set; }
        public frmPrincipal()
        {
            InitializeComponent();
            dbManager = new DBManager();
            DataSourceCliente = new BindingSource();
        }

        //CONTROLES\\
        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            //Admin.Logado = true;
            //GetPermissao();
            StartLogin();

        }
        private void btnNovoCliente_Click(object sender, EventArgs e)
        {
            frmGenCliente frm = new frmGenCliente();
            frm.ShowDialog();

            if (frm.IsDisposed)
            {
                LoadDataSourceCliente();
                ShowCliente();
            }
        }
        private void txtPesquisa_TextChanged(object sender, EventArgs e)
        {
            try
            {
                ShowCliente("nome_cliente", txtPesquisa.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            switch (btnLogin.Text)
            {
                case "Login":
                    StartLogin();
                    break;
                case "Logout":
                    Admin.Logado = false;
                    GetPermissao();
                    break;
                default:
                    break;
            }
        }
        private void btnSistema_Click(object sender, EventArgs e)
        {
            frmGerenciadorSistema frm = new frmGerenciadorSistema();
            frm.ShowDialog();

            if (frm.IsDisposed)
            {
                LoadDataSourceCliente();
                ShowCliente();
            }
        }
        private void btnAbout_Click(object sender, EventArgs e)
        {
            new AboutBox().ShowDialog();
        }

        private void dtgClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Cliente cliente = new Cliente();

                cliente.Id = (int)dtgClientes.Rows[e.RowIndex].Cells["id_cliente"].Value;
                cliente.Nome = dtgClientes.Rows[e.RowIndex].Cells["nome_cliente"].Value.ToString();
                cliente.Apelido = dtgClientes.Rows[e.RowIndex].Cells["apelido_cliente"].Value.ToString();
                cliente.Endereco = dtgClientes.Rows[e.RowIndex].Cells["endereco_cliente"].Value.ToString();
                cliente.Cpf = dtgClientes.Rows[e.RowIndex].Cells["cpf_cliente"].Value.ToString();
                cliente.Telefone = dtgClientes.Rows[e.RowIndex].Cells["telefone_cliente"].Value.ToString();
                cliente.LimiteConta = double.Parse(dtgClientes.Rows[e.RowIndex].Cells["limite_conta_cliente"].Value.ToString());
                cliente.TotalPago = double.Parse(dtgClientes.Rows[e.RowIndex].Cells["total_pago_cliente"].Value.ToString());
                cliente.TotalConta = double.Parse(dtgClientes.Rows[e.RowIndex].Cells["total_conta_cliente"].Value.ToString());
                cliente.DataConta = dtgClientes.Rows[e.RowIndex].Cells["data_conta_cliente"].Value.ToString();
                cliente.NumNotas = (int)dtgClientes.Rows[e.RowIndex].Cells["num_notas_cliente"].Value;
                cliente.Status = bool.Parse(dtgClientes.Rows[e.RowIndex].Cells["status_cliente"].Value.ToString());
                if (dtgClientes.Columns[e.ColumnIndex].Name == "btnAdd")
                {
                    frmOperacao frm = new frmOperacao(cliente, Operacao.ADICIONAR);
                    frm.ShowDialog();

                    if (frm.IsDisposed)
                    {
                        LoadDataSourceCliente();
                        ShowCliente();
                    }
                }
                else if(dtgClientes.Columns[e.ColumnIndex].Name == "btnDebitar")
                {
                    frmOperacao frm = new frmOperacao(cliente, Operacao.DEBITAR);
                    frm.ShowDialog();

                    if (frm.IsDisposed)
                    {
                        LoadDataSourceCliente();
                        ShowCliente();
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao entrar na conta! Detalhes: {ex.Message}");
            }
        }
        private void dtgClientes_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Cliente cliente = new Cliente();

                cliente.Id = (int)dtgClientes.Rows[e.RowIndex].Cells["id_cliente"].Value;
                cliente.Nome = dtgClientes.Rows[e.RowIndex].Cells["nome_cliente"].Value.ToString();
                cliente.Apelido = dtgClientes.Rows[e.RowIndex].Cells["apelido_cliente"].Value.ToString();
                cliente.Endereco = dtgClientes.Rows[e.RowIndex].Cells["endereco_cliente"].Value.ToString();
                cliente.Cpf = dtgClientes.Rows[e.RowIndex].Cells["cpf_cliente"].Value.ToString();
                cliente.Telefone = dtgClientes.Rows[e.RowIndex].Cells["telefone_cliente"].Value.ToString();
                cliente.LimiteConta = double.Parse(dtgClientes.Rows[e.RowIndex].Cells["limite_conta_cliente"].Value.ToString());
                cliente.TotalPago = double.Parse(dtgClientes.Rows[e.RowIndex].Cells["total_pago_cliente"].Value.ToString());
                cliente.TotalConta = double.Parse(dtgClientes.Rows[e.RowIndex].Cells["total_conta_cliente"].Value.ToString());
                cliente.DataConta = dtgClientes.Rows[e.RowIndex].Cells["data_conta_cliente"].Value.ToString();
                cliente.NumNotas = (int)dtgClientes.Rows[e.RowIndex].Cells["num_notas_cliente"].Value;
                cliente.Status = bool.Parse(dtgClientes.Rows[e.RowIndex].Cells["status_cliente"].Value.ToString());

                frmCliente frmCliente = new frmCliente(Size, cliente);
                frmCliente.ShowDialog();

                if (frmCliente.IsDisposed)
                {
                    GetPermissao();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao entrar na conta! Detalhes: {ex.Message}");
            }
        }

        //METODOS\\
        private void LoadDataSourceCliente()
        {
            try
            {
                DataSourceCliente.DataSource = dbManager.GetData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void StartLogin()
        {
            try
            {
                frmLogin frm = new frmLogin();
                frm.ShowDialog();

                if (frm.IsDisposed)
                {
                    GetPermissao();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"ERRO!",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void GetPermissao()
        {
            try
            {
                if (Admin.Logado)
                {
                    LoadDataSourceCliente();
                    EnableComponentes(true);
                    ShowCliente();
                    StartTimer(SysSettings.IntervaloBackup[SysSettings.SelectedTimerIndex]);
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
        private void EnableComponentes(bool status)
        {
            btnSistema.Enabled = status;
            btnNovoCliente.Enabled = status;
            groupBoxPesquisa.Enabled = status;
            dtgClientes.Visible = status;
        }
        private void ShowCliente(string filter = "nome_cliente", string searth = null)
        {
            try
            {
                DataSourceCliente.Filter = filter + " like '%" + searth + "%'";
                dtgClientes.DataSource = DataSourceCliente;
                dtgClientes.DataSource = DataSourceCliente;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao obter dados dos clientes! Detalhes: {ex.Message}");
            }
        }
        private void StartTimer(int time)
        {
            timeBackup.Interval = time;
            timeBackup.Start();
        }
    }
}
