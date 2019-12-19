using System;
using System.Drawing;
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
            LoadDataSourceCliente();
            ShowCliente();
        }
        private void txtPesquisa_TextChanged(object sender, EventArgs e)
        {
            ShowCliente("nome_cliente", txtPesquisa.Text);
        }
        private void btnNovoCliente_Click(object sender, EventArgs e)
        {
            //REUTILIZAR VARIÁVEL PARA VERIFICAÇÃO SE O FORM JÁ FOI FECHADO.\\
            frmGenCliente frm = new frmGenCliente();
            frm.ShowDialog();

        }
        private void btnSistema_Click(object sender, EventArgs e)
        {
            new frmGerenciadorSistema().ShowDialog();
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            new frmLogin().ShowDialog();
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
        private void ShowCliente(string filter = "nome_cliente", string searth = null)
        {
            DataSourceCliente.Filter = filter + " like '%" + searth + "%'";
            dtgClientes.DataSource = DataSourceCliente;
            dtgClientes.DataSource = DataSourceCliente;
        }
    }
}
