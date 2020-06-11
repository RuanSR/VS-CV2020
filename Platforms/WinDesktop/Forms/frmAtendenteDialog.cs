using Models.Classes;
using Models.Enum;
using Models.Exceptions;
using System;
using System.Windows.Forms;

namespace WinDesktop.Forms
{
    public partial class frmAtendenteDialog : Form
    {
        //private AtendenteController _aController;
        public frmAtendenteDialog(Atendente atendente = null)
        {
            InitializeComponent();
            Atendente = atendente;
            //_aController = new AtendenteController();
        }
        //CONTROLES\\
        public Atendente Atendente { get; set; }
        private void frmAtendenteDialog_Load(object sender, EventArgs e)
        {
            GenForm();
        }
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                GravaAtendente();
            }
            catch (AtendenteException ex)
            {
                MessageBox.Show(ex.Message, "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //METODOS\\
        void GenForm()
        {
            if (Atendente != null)
            {
                txtIdAtendnete.Text = Atendente.AtendenteId.ToString();
                txtNome.Text = Atendente.Nome;
                txtUsuario.Text = Atendente.Usuario;
                txtSenha.Text = Atendente.Senha;
            }
            else
            {
                txtIdAtendnete.Text = "-1";
            }
        }
        private void GravaAtendente()
        {
            if (txtIdAtendnete.Text == "-1")
            {
                var atendente = new Atendente(txtNome.Text, txtUsuario.Text, txtSenha.Text, NivelAcesso.ADMIN);
                //_aController.NovoAtendente();
                MessageBox.Show("Atendente criado com sucesso", "ATENÇÂO!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                //Atualiza
                Atendente.AtualizarAtendente(txtNome.Text, txtUsuario.Text, txtSenha.Text, NivelAcesso.ADMIN);
                //_aController.AtualizarAtendente(Atendente);
                MessageBox.Show("Atendente atualizado com sucesso", "ATENÇÂO!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            Dispose();
        }
    }
}
