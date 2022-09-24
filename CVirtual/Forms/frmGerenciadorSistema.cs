using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.Linq;
using CVirtual.Shared.Classes;
using CVirtual.Data.Repositories;
using CVirtual.Shared.Exceptions;

namespace CVirtual.Views
{
    public partial class frmGerenciadorSistema : Form
    {
        public frmGerenciadorSistema()
        {
            InitializeComponent();
            this.Text = " :: Administrador";
        }
        private Atendente Atendente { get; set; }

        private void frmGerenciadorSistema_Load(object sender, EventArgs e)
        {
            CarregaAtendentes();
            CarregaTimers();
            CarregaLocalBackup();
            tabControl1.TabPages.Remove(tabPage2);
        }
        //CONTROLES\\
        private async void dtgAtendente_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int id = (int)dtgAtendente.Rows[e.RowIndex].Cells["IdAtendente"].Value;
                var atendente = await new AtendenteRepository().GetAtendenteByIdAsync(id);

                if (dtgAtendente.Columns[e.ColumnIndex].Name == "btnEditar")
                {
                    BtnEdit(atendente, e);
                }
                else if (dtgAtendente.Columns[e.ColumnIndex].Name == "btnDeletar")
                {
                    var question = MessageBox.Show("Deseja realamente remover este atendente?", "ATENÇÂO!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (question == DialogResult.Yes)
                    {
                        BtnDelete(atendente, e);
                    }
                }
            }
            catch(AtendenteException ex)
            {
                MessageBox.Show(ex.Message, "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void BtnEdit(Atendente a,DataGridViewCellEventArgs e)
        {
            EmployeDialogForm frm = new EmployeDialogForm(a.AtendenteId);
            frm.ShowDialog();

            if (frm.IsDisposed)
            {
                CarregaAtendentes();
            }
        }
        private async void BtnDelete(Atendente a, DataGridViewCellEventArgs e)
        {
            if (a.AtendenteId != 1)
            {
                await new AtendenteRepository().RevomerAtendenteAsync(a);
                MessageBox.Show("Atendete removido.", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CarregaAtendentes();
            }
            else
            {
                MessageBox.Show("Você não pode remover o atendente do código de nº 1, pois ele é o administrador!", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void btnDefinirLocal_Click(object sender, EventArgs e)
        {
            try
            {
                if (folderBrowser.ShowDialog() == DialogResult.OK)
                {
                    txtLocal.Text = folderBrowser.SelectedPath;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao definir local! Detalhes: {ex.Message}", "ERRO!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void btnAbrirLocal_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(txtLocal.Text.Trim());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao abrir local do backup! Detalhes {ex.Message}", "ERRO!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnNovoAtendente_ButtonClick(object sender, EventArgs e)
        {
            EmployeDialogForm frm = new EmployeDialogForm(-1);
            frm.ShowDialog();

            if (frm.IsDisposed)
            {
                CarregaAtendentes();
            }
        }
        private void btnSalvarDados_Click(object sender, EventArgs e)
        {
            try
            {
                //AppManager.SetSelectedTimerIndex(cbBackupIntervalo.SelectedIndex);
                //AppManager.SetBackupPath(string.Format("{0}{1}", txtLocal.Text, "\\"));
                //AppManager.Init();
                MessageBox.Show("Salvo com sucesso!", "OK!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnBackup_Click(object sender, EventArgs e)
        {
            try
            {
                //SysSettings.CreateBackup();
                MessageBox.Show("Opção inativa no momento!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnBackupRestore_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show("Opção inativa no momento!", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //openFileDialog.ShowDialog();
                //if (openFileDialog.FileName != null)
                //{
                //    //dbManager.RestaurarBackup(openFileDialog.FileName, ConfigurationManager.AppSettings["Catalog"]);
                //    MessageBox.Show("Backup restaurado com sucesso!", "SUCESSO!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    Dispose();
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //METODOS\\
        private async void CarregaAtendentes()
        {
            try
            {
                dtgAtendente.DataSource = await new AtendenteRepository().ListaAtendentesAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CarregaTimers()
        {
            cbBackupIntervalo.Items.Add("10 minutos");
            cbBackupIntervalo.Items.Add("15 minutos");
            cbBackupIntervalo.Items.Add("20 minutos");
            try
            {
                //cbBackupIntervalo.SelectedIndex = AppManager.SelectedTimerIndex;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CarregaLocalBackup()
        {
            try
            {
                //txtLocal.Text = AppManager.LocalBackup;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
