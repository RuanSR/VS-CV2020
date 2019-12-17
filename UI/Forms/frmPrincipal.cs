using System;
using System.Windows.Forms;
using Business.Class;

namespace UI.Forms
{
    public partial class frmPrincipal : Form
    {
        DBManager dbManager;
        public frmPrincipal()
        {
            InitializeComponent();
            dbManager = new DBManager();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            LoadClientes();
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

        private void LoadClientes()
        {
            try
            {
                dtgClientes.DataSource = dbManager.Read();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
