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
            frmGenCliente frm = new frmGenCliente(this.Size);
            frm.ShowDialog();
        }

        private void btnSistema_Click(object sender, EventArgs e)
        {
            new frmGerenciadorSistema().ShowDialog();
        }
    }
}
