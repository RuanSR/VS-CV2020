using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.Linq;
using CVirtual.Shared.Classes;
using CVirtual.Data.Repositories;
using CVirtual.Shared.Exceptions;
using CVirtual.Presenter;
using CVirtual.Views.Interfaces;
using System.Threading.Tasks;

namespace CVirtual.Views
{
    public partial class SystemManagerForm : Form, ISystemManagerView
    {
        private readonly SystemManagerPresenter _presenter;

        public TabControl TabControl => tabControl;

        public TabPage TabPageAdmin => tabPageAdmin;

        public DataGridView DataGridViewEmployee => dataGridViewEmployee;

        public ToolStripButton BtnNewEmployee => btnNewEmployee;

        public ComboBox CbBackupInterval => cbBackupInterval;

        public TabPage TabPageBackupRestore => tabPageBackupRestore;

        public OpenFileDialog OpenFileDialog => openFileDialog;

        public FolderBrowserDialog FolderBrowserDialog => folderBrowser;

        public TextBox LocalPathBackup => txtLocal;

        public SystemManagerForm()
        {
            InitializeComponent();
            //this.DataGridViewEmployee.Columns[this.DataGridViewEmployee.Columns.Count-1].Name = "btnEditar";
            //this.DataGridViewEmployee.Columns[this.DataGridViewEmployee.Columns.Count].Name = "btnDeletar";
            _presenter = new SystemManagerPresenter(this);
        }

        private async void OnLoad(object sender, EventArgs e)
        {
            try
            {
                _presenter.LoadInitializedDataForm();
                await _presenter.LoadDataEmployer();
                _presenter.LoadDataBackupIntervalTimer();
                _presenter.LoadLocalBackup();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private async void DtgEmployee_CellClickOptions(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int employeeId = (int)dataGridViewEmployee.Rows[e.RowIndex].Cells["IdAtendente"].Value;

                if (dataGridViewEmployee.Columns[e.ColumnIndex].Name == "btnEditar")
                    await EmployeeEtitor(employeeId);
                else if (dataGridViewEmployee.Columns[e.ColumnIndex].Name == "btnDeletar")
                    DeleteEmployee(employeeId);

            }
            catch(AtendenteException ex)
            {
                MessageBox.Show(ex.Message, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnSetLocalBackup_Click(object sender, EventArgs e)
        {
            try
            {
                if (folderBrowser.ShowDialog() == DialogResult.OK)
                {
                    _presenter.SetLocalBackup();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao definir local! Detalhes: {ex.Message}", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void BtnOpenLocalBackup_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(LocalPathBackup.Text.Trim());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao abrir local do backup! Detalhes {ex.Message}", "ERRO!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async void BtnNewEmployee_ButtonClick(object sender, EventArgs e)
        {
            EmployeDialogForm frm = new EmployeDialogForm(-1);
            frm.ShowDialog();

            if (frm.IsDisposed)
            {
                await _presenter.LoadDataEmployer();
            }
        }
        
        private void BtnSaveDataPreferences_Click(object sender, EventArgs e)
        {
            try
            {
                //_presenter.SaveBackupPreferences();
                //MessageBox.Show("Salvo com sucesso!", "OK!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void BtnBackup_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show("Opção inativa no momento!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //SysSettings.CreateBackup();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void BtnBackupRestore_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show("Opção inativa no momento.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //_presenter.RestoreBackup();

                MessageBox.Show("Backup restaurado com sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task EmployeeEtitor(int id)
        {
            EmployeDialogForm frm = new EmployeDialogForm(id);
            frm.ShowDialog();

            if (frm.IsDisposed)
            {
                await _presenter.LoadDataEmployer();
            }
            
        }
        private async void DeleteEmployee(int employeeId)
        {
            var question = MessageBox.Show("Você realamente deseja remover este atendente?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (question == DialogResult.Yes)
            {
                await _presenter.DeleteEmployee(employeeId);
            }
        }
    }
}
