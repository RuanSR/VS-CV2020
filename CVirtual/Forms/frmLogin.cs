using CVirtual.Data.Repositories;
using CVirtual.Shared.Classes;
using CVirtual.Shared.Exceptions;
using System;
using System.Windows.Forms; 

namespace CVirtual.Forms
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }
        public Atendente Atendente { get; set; }

        //CONTROLES\\
        private void frmLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                FazerLogin();
            }
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            FazerLogin();
        }

        //MÉTODOS\\
        private async void FazerLogin()
        {
            try
            {
                Atendente = await new AtendenteRepository().GetAtendenteByUserNameAsync(txtUsuario.Text, txtSenha.Text);
                if (Atendente != null)
                {
                    Dispose();
                }
                else
                {
                    MessageBox.Show("Nome de usuário ou senha inválidos!", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (AtendenteException e)
            {
                MessageBox.Show(e.Message, "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                throw;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }
    }
}
