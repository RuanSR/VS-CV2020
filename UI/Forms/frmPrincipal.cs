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
            StartLogin();
        }
        private void btnNovoCliente_Click(object sender, EventArgs e)
        {
            frmGenCliente frm = new frmGenCliente();
            frm.ShowDialog();
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
            new frmGerenciadorSistema().ShowDialog();
        }
        private void btnAbout_Click(object sender, EventArgs e)
        {
            new AboutBox().ShowDialog();
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

    }
}
