using CVirtual.Data.Repositories;
using CVirtual.Shared.Classes;
using CVirtual.Shared.Enums;
using CVirtual.Shared.Exceptions;
using System;
using System.Windows.Forms;

namespace CVirtual.Forms
{
    public partial class frmAtendenteDialog : Form
    {
        public frmAtendenteDialog(Atendente atendente = null)
        {
            InitializeComponent();
            Atendente = atendente;
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
        private async void GravaAtendente()
        {
            if (txtIdAtendnete.Text == "-1")
            {
                var atendente = new Atendente(txtNome.Text, txtUsuario.Text, txtSenha.Text, NivelAcesso.ADMIN);
                await new AtendenteRepository().NovoAtendenteAsync(atendente);
                MessageBox.Show("Atendente criado com sucesso", "ATENÇÂO!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Atendente.AtualizarAtendente(txtNome.Text, txtUsuario.Text, txtSenha.Text, NivelAcesso.ADMIN);
                await new AtendenteRepository().AtualizarAtendenteAsync(Atendente);
                MessageBox.Show("Atendente atualizado com sucesso", "ATENÇÂO!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            Dispose();
        }
    }
}
