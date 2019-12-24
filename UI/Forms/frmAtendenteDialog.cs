using Business.Class;
using System;
using System.Windows.Forms;

namespace UI.Forms
{
    public partial class frmAtendenteDialog : Form
    {
        public Atendente Atendente { get; set; }
        DBManager dbManager;
        //CONTROLES\\
        public frmAtendenteDialog(Atendente atendente = null)
        {
            InitializeComponent();
            Atendente = atendente;
            dbManager = new DBManager();
        }
        private void frmAtendenteDialog_Load(object sender, EventArgs e)
        {
            ValidaAtendente(Atendente);
        }
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (ValidaCadastro())
            {
                GravaAtendente(int.Parse(txtIdAtendnete.Text));
            }
            else
            {
                MessageBox.Show("Preencha tudo corretamente!", "ATENÇÂO!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //METODOS\\
        private void ValidaAtendente(Atendente atendente)
        {
            if (atendente != null)
            {
                txtIdAtendnete.Text = atendente.Id.ToString();
                txtNome.Text = atendente.Nome;
                txtSenha.Text = atendente.Senha;
            }
            else
            {
                txtIdAtendnete.Text = "-1";
                Atendente = new Atendente();
            }
        }
        private void GravaAtendente(int id)
        {
            try
            {
                if (id == -1)
                {
                    //Novo
                    dbManager.NovoAtendente(Atendente.Nome, Atendente.Senha);
                    MessageBox.Show("Atendente criado com sucesso", "ATENÇÂO!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    //Atualiza
                    dbManager.AtualizaAtendente(Atendente.Id, Atendente.Nome, Atendente.Senha);
                    MessageBox.Show("Atendente atualizado com sucesso", "ATENÇÂO!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool ValidaCadastro()
        {
            if (!string.IsNullOrEmpty(txtNome.Text.Trim()) && !string.IsNullOrEmpty(txtSenha.Text.Trim()))
            {
                Atendente.Nome = txtNome.Text.Trim();
                Atendente.Senha = txtSenha.Text.Trim();
                return true;
            }
            return false;
        }
    }
}
