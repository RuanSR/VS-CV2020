using Controller;
using Model.Classes;
using Model.Exceptions;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms; 

namespace UI.Forms
{
    public partial class frmLogin : Form
    {
        private AtendenteController _aController;
        public Atendente Atendente { get; set; }
        public frmLogin()
        {
            InitializeComponent();
            _aController = new AtendenteController();
        }

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
                Atendente = GetAtendenteByUserName(txtUsuario.Text, txtSenha.Text);
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
        private Atendente GetAtendenteByUserName(string userName, string senha)
        {
            return _aController.ListaAtendentes()
                .Where(at => at.Usuario == userName && at.Senha == senha)
                .FirstOrDefault();
        }
    }
}
