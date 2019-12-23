using System;
using System.Data;
using System.Windows.Forms;
using Business.Class;

namespace UI.Forms
{
    public partial class frmLogin : Form
    {
        private DBManager dbManager { get; set; }
        public frmLogin()
        {
            InitializeComponent();
            dbManager = new DBManager();
        }

        //CONTROLES\\
        private void frmLogin_Load(object sender, EventArgs e)
        {

        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dataTable = new DataTable();
                dataTable = dbManager.GetAdmin(txtUsuario.Text, txtSenha.Text);
                if (!string.IsNullOrEmpty(txtUsuario.Text) && !string.IsNullOrEmpty(txtSenha.Text))
                {
                    if (dataTable.Rows.Count != 0)
                    {
                        //    Admin.ID = int.Parse(dataTable.Rows[0]["senha_atendente"].ToString());
                        //    Admin.Nome = dataTable.Rows[0]["usuario_atendente"].ToString();
                        Admin.Logado = true;
                        Dispose();
                    }
                    else
                        MessageBox.Show("Usuario ou senha incorretos!", "ATENÇÂO!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Preencha tudo corretamente!", "ATENÇÂO!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //MÉTODOS\\

    }
}
