using CVirtual.Data.Repositories;
using CVirtual.Presenter;
using CVirtual.Shared.Classes;
using CVirtual.Shared.Exceptions;
using CVirtual.Views.Interfaces;
using System;
using System.Threading.Tasks;
using System.Windows.Forms; 

namespace CVirtual.Forms
{
    public partial class AuthForm : Form, ILoginView
    {
        private readonly AuthPresenter _authPresenter;

        public TextBox TxtUser => this.txtUser;

        public TextBox TxtPassword => this.txtPassword;

        public Button BtnLogin => this.btnLogin;

        public AuthForm()
        {
            InitializeComponent();
            _authPresenter = new AuthPresenter();
        }

        private void LoginForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                OnLogin();
            }
        }
        private void LoginForm_Click(object sender, EventArgs e)
        {
            OnLogin();
        }

        private async void OnLogin()
        {
            try
            {
                await _authPresenter.LoginAsync(this);
                Dispose();
            }
            catch(AtendenteException e)
            {
                MessageBox.Show(e.getMessageInfo(), e.getMessageType(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
