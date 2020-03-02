using Controller;
using Model.Classes;
using Model.Classes.ClienteModel;
using Model.Enum;
using System;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace UI.Forms
{
    public partial class frmPrincipal : Form
    {
        private ClienteController _cController;
        public frmPrincipal()
        {
            InitializeComponent();
            _cController = new ClienteController();
            Atendente = new Atendente();
            DataSourceCliente = new BindingSource();
        }
        private BindingSource DataSourceCliente { get; set; }
        private Atendente Atendente { get; set; }

        //CONTROLES\\
        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            try
            {
                StartLogin();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro! {ex.Message}", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            switch (btnLogin.Text)
            {
                case "Login":
                    StartLogin();
                    break;
                case "Logout":
                    Atendente = null;
                    GetPermissao();
                    break;
                default:
                    break;
            }
        }
        private void btnNovoCliente_Click(object sender, EventArgs e)
        {
            frmGenCliente frm = new frmGenCliente();
            frm.ShowDialog();

            if (frm.IsDisposed)
            {
                LoadDataSourceCliente();
                ShowCliente();
            }
        }
        private void btnSistema_Click(object sender, EventArgs e)
        {
            frmGerenciadorSistema frm = new frmGerenciadorSistema();
            frm.ShowDialog();

            if (frm.IsDisposed)
            {
                LoadDataSourceCliente();
                ShowCliente();
            }
        }
        private void dtgClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var ClienteId = (int)dtgClientes.Rows[e.RowIndex].Cells["cliente_id"].Value;
                var cliente = GetCliente(ClienteId);


                if (dtgClientes.Columns[e.ColumnIndex].Name == "btnAdd")
                {
                    frmOperacao frm = new frmOperacao(cliente, Operacoes.ADICIONAR);
                    frm.ShowDialog();
                    FrmIsDisposed(frm);
                }
                else if (dtgClientes.Columns[e.ColumnIndex].Name == "btnDebitar")
                {
                    frmOperacao frm = new frmOperacao(cliente, Operacoes.DEBITAR);
                    frm.ShowDialog();
                    FrmIsDisposed(frm);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao entrar na conta! Detalhes: {ex.Message}");
            }
        }
        private void dtgClientes_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var ClienteId = (int)dtgClientes.Rows[e.RowIndex].Cells["cliente_id"].Value;
                var cliente = GetCliente(ClienteId);

                frmCliente frmCliente = new frmCliente(Size, cliente);
                frmCliente.ShowDialog();
                FrmIsDisposed(frmCliente);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao entrar na conta! Detalhes: {ex.Message}");
            }
        }
        private void txtPesquisa_TextChanged(object sender, EventArgs e)
        {
            try
            {
                ShowCliente(txtPesquisa.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void timeBackup_Tick(object sender, EventArgs e)
            {
                try
                {
                    //SysSettings.CreateBackup();
                    //lblUltimoBackup.Text = "Último Backup: " + DateTime.Now.ToString("HH:mm:ss");
                    //timeBackup.Start();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "ERRO!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        private void btnAbout_Click(object sender, EventArgs e)
        {
            new AboutBox().ShowDialog();
        }

        //METODOS\\
        void StartLogin()
        {
            try
            {
                frmLogin frm = new frmLogin();
                frm.ShowDialog();

                Atendente = frm.Atendente;

                if (frm.IsDisposed)
                {
                    GetPermissao();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void GetPermissao()
        {
            try
            {
                if (Atendente != null)
                {
                    LoadDataSourceCliente();
                    EnableComponentes(true);
                    ShowCliente();
                    //StartTimer(SysSettings.IntervaloBackup[SysSettings.SelectedTimerIndex]);
                    btnLogin.Text = "Logout";
                }
                else
                {
                    EnableComponentes(false);
                    btnLogin.Text = "Login";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao obter permissão de login! Detalhes: {ex.Message}", "ERRO!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void LoadDataSourceCliente()
        {
            try
            {
                DataSourceCliente.DataSource = _cController.ListaClientes();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void FrmIsDisposed(Form frm)
        {
            if (frm.IsDisposed)
            {
                LoadDataSourceCliente();
                ShowCliente();
            }
        }
        Cliente GetCliente(int id)
        {
            return _cController.ListaClientes()
                .Where(c => c.ClienteId == id)
                .FirstOrDefault();
        }

        private void EnableComponentes(bool status)
        {
            btnSistema.Enabled = status;
            btnNovoCliente.Enabled = status;
            groupBoxPesquisa.Enabled = status;
            dtgClientes.Visible = status;
            statusBar.Visible = status;
        }
        private void ShowCliente(string searth = "")
        {
            try
            {
                dtgClientes.DataSource = _cController.ListaClientes()
                    .Where(c => c.Nome.Contains(searth) 
                    || c.Nome.Contains(searth.ToLowerInvariant())
                    || c.Nome.Contains(searth.ToUpperInvariant())
                    ).ToList();
                Estilo();
                AtualizaStatus();
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao obter dados dos clientes! Detalhes: {ex.Message}");
            }
        }
        private void StartTimer(int time)
        {
            timeBackup.Interval = time;
            timeBackup.Start();
        }
        private void AtualizaStatus()
        {
            lblStatusRegistro.Text = "Último Registro: " + AppController.GetUltimaNota;
        }
        private void Estilo()
        {
            //for (int i = 0; i < dtgClientes.Rows.Count; i += 2)
            //{
            //    dtgClientes.Rows[i].DefaultCellStyle.BackColor = Color.Lavender;
            //}
        }

        private void dtgClientes_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((dtgClientes.Rows[e.RowIndex].DataBoundItem != null) && (dtgClientes.Columns[e.ColumnIndex].DataPropertyName.Contains(".")))
            {
                e.Value = BindProperty(dtgClientes.Rows[e.RowIndex].DataBoundItem, dtgClientes.Columns[e.ColumnIndex].DataPropertyName);
            }
        }
        private string BindProperty(object property, string propertyName)
        {
            string retValue = "";

            if (propertyName.Contains("."))
            {
                PropertyInfo[] arrayProperties;
                string leftPropertyName;

                leftPropertyName = propertyName.Substring(0, propertyName.IndexOf("."));
                arrayProperties = property.GetType().GetProperties();

                foreach (PropertyInfo propertyInfo in arrayProperties)
                {
                    if (propertyInfo.Name == leftPropertyName)
                    {
                        retValue = BindProperty(
                          propertyInfo.GetValue(property, null),
                          propertyName.Substring(propertyName.IndexOf(".") + 1));
                        break;
                    }
                }
            }
            else
            {
                Type propertyType;
                PropertyInfo propertyInfo;

                propertyType = property.GetType();
                propertyInfo = propertyType.GetProperty(propertyName);
                retValue = propertyInfo.GetValue(property, null).ToString();
            }

            return retValue;
        }
    }
}
