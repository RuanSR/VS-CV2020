using DAL.Database;
using Models.Classes;
using Models.Exceptions;
using Models.Interface;
using System;
using System.Windows.Forms; 

namespace WinDesktop.Forms
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
        private void FazerLogin()
        {
            try
            {
                Atendente = new AtendenteRepository().GetAtendenteByUserName(txtUsuario.Text, txtSenha.Text);
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
