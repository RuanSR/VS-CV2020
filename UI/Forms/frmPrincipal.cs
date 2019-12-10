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
            frmNovoCliente frm = new frmNovoCliente(this.Size);
            frm.ShowDialog();
        }
    }
}
