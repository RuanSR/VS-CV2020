using Controller;
using Model.Classes;
using System;
using System.Collections;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace UI.Forms
{
    public partial class frmPrincipal : Form
    {
        private BindingSource DataSourceCliente { get; set; }
        private ClienteController _cController;
        public frmPrincipal()
        {
            InitializeComponent();
            _cController = new ClienteController();
            Atendente = new Atendente();
            //dbManager = new DBManager();
            DataSourceCliente = new BindingSource();
        }
        private Atendente Atendente { get; set; }

        //CONTROLES\\
        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            StartLogin();
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
        private void txtPesquisa_TextChanged(object sender, EventArgs e)
        {
            try
            {
                ShowCliente("nome_cliente", txtPesquisa.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            //switch (btnLogin.Text)
            //{
            //    case "Login":
            //        StartLogin();
            //        break;
            //    case "Logout":
            //        Admin.Logado = false;
            //        GetPermissao();
            //        break;
            //    default:
            //        break;
            //}
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
        private void btnAbout_Click(object sender, EventArgs e)
        {
            new AboutBox().ShowDialog();
        }

        private void dtgClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //try
            //{
            //    Cliente cliente = new Cliente();

            //    cliente.Id = (int)dtgClientes.Rows[e.RowIndex].Cells["id_cliente"].Value;
            //    cliente.Nome = dtgClientes.Rows[e.RowIndex].Cells["nome_cliente"].Value.ToString();
            //    cliente.Apelido = dtgClientes.Rows[e.RowIndex].Cells["apelido_cliente"].Value.ToString();
            //    cliente.Endereco = dtgClientes.Rows[e.RowIndex].Cells["endereco_cliente"].Value.ToString();
            //    cliente.Cpf = dtgClientes.Rows[e.RowIndex].Cells["cpf_cliente"].Value.ToString();
            //    cliente.Telefone = dtgClientes.Rows[e.RowIndex].Cells["telefone_cliente"].Value.ToString();
            //    cliente.LimiteConta = double.Parse(dtgClientes.Rows[e.RowIndex].Cells["limite_conta_cliente"].Value.ToString());
            //    cliente.TotalPago = double.Parse(dtgClientes.Rows[e.RowIndex].Cells["total_pago_cliente"].Value.ToString());
            //    cliente.TotalConta = double.Parse(dtgClientes.Rows[e.RowIndex].Cells["total_conta_cliente"].Value.ToString());
            //    cliente.DataConta = dtgClientes.Rows[e.RowIndex].Cells["data_conta_cliente"].Value.ToString();
            //    cliente.NumNotas = (int)dtgClientes.Rows[e.RowIndex].Cells["num_notas_cliente"].Value;
            //    cliente.Status = bool.Parse(dtgClientes.Rows[e.RowIndex].Cells["status_cliente"].Value.ToString());
            //    if (dtgClientes.Columns[e.ColumnIndex].Name == "btnAdd")
            //    {
            //        frmOperacao frm = new frmOperacao(cliente, Operacao.ADICIONAR);
            //        frm.ShowDialog();

            //        if (frm.IsDisposed)
            //        {
            //            LoadDataSourceCliente();
            //            ShowCliente();
            //        }
            //    }
            //    else if (dtgClientes.Columns[e.ColumnIndex].Name == "btnDebitar")
            //    {
            //        frmOperacao frm = new frmOperacao(cliente, Operacao.DEBITAR);
            //        frm.ShowDialog();

            //        if (frm.IsDisposed)
            //        {
            //            LoadDataSourceCliente();
            //            ShowCliente();
            //        }

            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show($"Erro ao entrar na conta! Detalhes: {ex.Message}");
            //}
        }
        private void dtgClientes_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //    try
            //    {
            //        Cliente cliente = new Cliente();

            //        cliente.Id = (int)dtgClientes.Rows[e.RowIndex].Cells["id_cliente"].Value;
            //        cliente.Nome = dtgClientes.Rows[e.RowIndex].Cells["nome_cliente"].Value.ToString();
            //        cliente.Apelido = dtgClientes.Rows[e.RowIndex].Cells["apelido_cliente"].Value.ToString();
            //        cliente.Endereco = dtgClientes.Rows[e.RowIndex].Cells["endereco_cliente"].Value.ToString();
            //        cliente.Cpf = dtgClientes.Rows[e.RowIndex].Cells["cpf_cliente"].Value.ToString();
            //        cliente.Telefone = dtgClientes.Rows[e.RowIndex].Cells["telefone_cliente"].Value.ToString();
            //        cliente.LimiteConta = double.Parse(dtgClientes.Rows[e.RowIndex].Cells["limite_conta_cliente"].Value.ToString());
            //        cliente.TotalPago = double.Parse(dtgClientes.Rows[e.RowIndex].Cells["total_pago_cliente"].Value.ToString());
            //        cliente.TotalConta = double.Parse(dtgClientes.Rows[e.RowIndex].Cells["total_conta_cliente"].Value.ToString());
            //        cliente.DataConta = dtgClientes.Rows[e.RowIndex].Cells["data_conta_cliente"].Value.ToString();
            //        cliente.NumNotas = (int)dtgClientes.Rows[e.RowIndex].Cells["num_notas_cliente"].Value;
            //        cliente.Status = bool.Parse(dtgClientes.Rows[e.RowIndex].Cells["status_cliente"].Value.ToString());

            //        frmCliente frmCliente = new frmCliente(Size, cliente);
            //        frmCliente.ShowDialog();

            //        if (frmCliente.IsDisposed)
            //        {
            //            GetPermissao();
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show($"Erro ao entrar na conta! Detalhes: {ex.Message}");
            //    }
            //}
        }
        private void timeBackup_Tick(object sender, EventArgs e)
            {
                try
                {
                    //SysSettings.CreateBackup();
                    lblUltimoBackup.Text = "Último Backup: " + DateTime.Now.ToString("HH:mm:ss");
                    timeBackup.Start();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "ERRO!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
        private void EnableComponentes(bool status)
        {
            btnSistema.Enabled = status;
            btnNovoCliente.Enabled = status;
            groupBoxPesquisa.Enabled = status;
            dtgClientes.Visible = status;
            statusBar.Visible = status;
        }
        private void ShowCliente(string filter = "nome_cliente", string searth = null)
        {
            try
            {
                DataSourceCliente.Filter = filter + " like '%" + searth + "%'";
                dtgClientes.DataSource = DataSourceCliente;
                dtgClientes.DataSource = DataSourceCliente;
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
            //lblStatusRegistro.Text = "Último Registro: " + StatusLog.UltimaNota;
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
