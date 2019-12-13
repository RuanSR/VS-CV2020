using System;
using System.Windows.Forms;

namespace UI.Forms
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            new AboutBox().ShowDialog();
        }
    }
}
