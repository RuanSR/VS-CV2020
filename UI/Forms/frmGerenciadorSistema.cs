using Business.Class;
using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.Configuration;

namespace UI.Forms
{
    public partial class frmGerenciadorSistema : Form
    {
        private Atendente Atendente { get; set; }
        DBManager dbManager;
        public frmGerenciadorSistema()
        {
            InitializeComponent();
            dbManager = new DBManager();
        }

        private void frmGerenciadorSistema_Load(object sender, EventArgs e)
        {
            CarregaAtendentes();
            CarregaTimers();
            CarregaLocalBackup();
        }
        //CONTROLES\\
        private void dtgAtendente_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dtgAtendente.Columns[e.ColumnIndex].Name == "btnEdit")
                {
                    int id = (int)dtgAtendente.Rows[e.RowIndex].Cells["id_atendente"].Value;
                    string nome = dtgAtendente.Rows[e.RowIndex].Cells["usuario_atendente"].Value.ToString();
                    string senha = dtgAtendente.Rows[e.RowIndex].Cells["senha_atendente"].Value.ToString();

                    Atendente = new Atendente(id, nome, senha);
                    frmAtendenteDialog frm = new frmAtendenteDialog(Atendente);
                    frm.ShowDialog();

                    if (frm.IsDisposed)
                    {
                        CarregaAtendentes();
                    }
                }
                else if (dtgAtendente.Columns[e.ColumnIndex].Name == "btnDelete")
                {
                    int id = (int)dtgAtendente.Rows[e.RowIndex].Cells["id_atendente"].Value;

                    if (MessageBox.Show("Deseja realamente remover este atendente?", "ATENÇÂO!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (id != 1)
                        {
                            dbManager.RemoveAtendente((int)dtgAtendente.Rows[e.RowIndex].Cells["id_atendente"].Value);
                            MessageBox.Show("Atendete removido!", "ATENÇÂO!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                            CarregaAtendentes();
                        }
                        else
                        {
                            MessageBox.Show("Você não pode remover o atendente do código de nº 1, pois ele é o administrador!", "ATENÇÂO!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            frmAtendenteDialog frm = new frmAtendenteDialog();
            frm.ShowDialog();

            if (frm.IsDisposed)
            {
                CarregaAtendentes();
            }
        }
        //METODOS\\
        private void CarregaAtendentes()
        {
            try
            {
                dtgAtendente.DataSource = dbManager.GetAtendentes();
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
                cbBackupIntervalo.SelectedIndex = SysSettings.SelectedTimerIndex;
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
                txtLocal.Text = SysSettings.LocalBackup;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalvarDados_Click(object sender, EventArgs e)
        {
            try
            {
                SysSettings.SetSelectedTimerIndex(cbBackupIntervalo.SelectedIndex);
                SysSettings.SetBackupPath(string.Format("{0}{1}", txtLocal.Text, "\\"));
                SysSettings.Init();
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
                SysSettings.CreateBackup();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnBackupRestore_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog.ShowDialog();
                if (openFileDialog.FileName != null)
                {
                    dbManager.RestaurarBackup(openFileDialog.FileName, ConfigurationManager.AppSettings["Catalog-Test"]);
                    MessageBox.Show("Backup restaurado com sucesso!", "SUCESSO!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
