using System;
using System.Drawing;
using System.Windows.Forms;
using Business.Class;

namespace UI.Forms
{
    public partial class frmCliente : Form
    {
        private Cliente _cliente;
        private int sizeSplitDetail = 80;
        private Size _sizeParent;

        //CONSTRUTOR\\
        public frmCliente(Size sizeParent, Cliente cliente)
        {
            InitializeComponent();
            _sizeParent = sizeParent;
            SetDefaultSize();
            SetDefaultSplitDistance();
            _cliente = cliente;
        }

        //CONTROLES\\
        private void frmCliente_Load(object sender, EventArgs e)
        {

        }
        private void frmCliente_Resize(object sender, EventArgs e)
        {
            SetDefaultSplitDistance();
        }
        private void btnLogout_Click(object sender, EventArgs e)
        {
            Logout();
        }
        private void frmCliente_FormClosed(object sender, FormClosedEventArgs e)
        {
            Logout();
        }
        private void btnEditarDados_Click(object sender, EventArgs e)
        {
            new frmGenCliente().ShowDialog();
        }
        private void btnAdicionarValor_Click(object sender, EventArgs e)
        {
            new frmOperacao(_cliente, Operacao.ADICIONAR).ShowDialog();
        }
        private void btnDebitarValor_Click(object sender, EventArgs e)
        {
            new frmOperacao(_cliente, Operacao.DEBITAR).ShowDialog();
        }

        //MÉTODOS\\
        private void SetDefaultSize()
        {
            _sizeParent.Width = _sizeParent.Width / 2;
            _sizeParent.Height = _sizeParent.Height / 2;
            Size = _sizeParent;
        }
        private void SetDefaultSplitDistance()
        {
            splitContainer.SplitterDistance = (_sizeParent.Width / 2) - sizeSplitDetail;
        }
        private void Logout()
        {
            if (!this.IsDisposed)
            {
                this.Close();
            }
        }
    }
}
