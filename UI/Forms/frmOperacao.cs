using System;
using System.Windows.Forms;

namespace UI.Forms
{
    public partial class frmOperacao : Form
    {
        public frmOperacao()
        {
            InitializeComponent();
        }

        private void frmOperacao_MouseLeave(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

        }
    }
}
