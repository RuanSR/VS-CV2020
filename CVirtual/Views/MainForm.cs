using CVirtual.Data.Repositories;
using CVirtual.Presenter;
using CVirtual.Shared.Classes;
using CVirtual.Shared.Enums;
using CVirtual.Shared.Struct;
using CVirtual.Utils;
using CVirtual.Views;
using CVirtual.Views.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CVirtual.Views
{
    public partial class FrmPrincipal : Form, IMainView
    {
        private readonly MainPresenter _presenter;
        
        public FrmPrincipal()
        {
            InitializeComponent();
            _presenter = new MainPresenter(this);
        }

        public ToolStripButton BtnAddCustomer => btnAddCustomer;

        public ToolStripButton BtnAuth => btnAuth;

        public ToolStripMenuItem BtnAbout => btnAbout;

        public TextBox TxtSearch => txtSearch;

        public ToolStripMenuItem BtnSystem => btnSystem;

        public DataGridView DataGridViewCustomers => dataGridViewCustomers;

        public ToolStripStatusLabel LblStatusRegistro => lblStatusRegistro;

        public ToolStripStatusLabel LblLastBackup => lblLastBackup;

        public RadioButton RbStatusOff => rbStatusOff;

        public RadioButton RbStatusOn => rbStatusOn;

        public GroupBox GroupBoxSearth => groupBoxSearth;

        public StatusStrip StatusBar => statusBar;

        private async void OnLoad(object sender, EventArgs e)
        {
            try
            {
                await ShowFormAuthenticate();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro! {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private async void BtnAuth_Click(object sender, EventArgs e)
        {
            switch (BtnAuth.Text)
            {
                case "Login":
                    await ShowFormAuthenticate();
                    break;
                case "Logout":
                    _presenter.Logout();
                    break;
                default:
                    break;
            }
        }
        
        public async void BtnAddCustomer_Click(object sender, EventArgs e)
        {
            try
            {
                CustomerManagerForm frm = new CustomerManagerForm();
                frm.ShowDialog();

                if (frm.IsDisposed)
                {
                    await _presenter.LoadDataGridView();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro no sistema. {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnSystem_Click(object sender, EventArgs e)
        {
            new SystemManagerForm().ShowDialog();
        }
        
        private void DtgCustomers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var customerId = (int)dataGridViewCustomers.Rows[e.RowIndex].Cells["IdCliente"].Value;

                if (dataGridViewCustomers.Columns[e.ColumnIndex].Name == "btnAdd")
                    AddNewAmount(customerId);
                else if (dataGridViewCustomers.Columns[e.ColumnIndex].Name == "btnDebitar")
                    RemoveAmount(customerId);

                _presenter.UpdateStatusBar();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao entrar na conta! Detalhes: {ex.Message}");
            }
        }

        private void RemoveAmount(int customerId)
        {
            ActionTypeForm frm = new ActionTypeForm(customerId, EOperationType.DEBITAR);
            frm.ShowDialog();
            FormIsDisposed(frm);
        }

        private void AddNewAmount(int customerId)
        {
            ActionTypeForm frm = new ActionTypeForm(customerId, EOperationType.ADICIONAR);
            frm.ShowDialog();
            FormIsDisposed(frm);
        }

        private void DtgCustomers_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var customerId = (int)dataGridViewCustomers.Rows[e.RowIndex].Cells["IdCliente"].Value;

                CustomerForm frmCliente = new CustomerForm(customerId, Size);
                frmCliente.ShowDialog();
                FormIsDisposed(frmCliente);
                _presenter.UpdateStatusBar();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao entrar na conta! Detalhes: {ex.Message}");
            }
        }
        
        private async void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                await _presenter.LoadDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private async void RbStatus_CheckedChanged(object sender, EventArgs e)
        {
            await _presenter.LoadDataGridView();
        }
        
        private void BtnAbout_Click(object sender, EventArgs e)
        {
            new AboutBoxForm().ShowDialog();
        }
    
        private async void FormIsDisposed(Form frm)
        {
            this.TxtSearch.Text = txtSearch.Text;
            if (frm.IsDisposed)
            {
                await _presenter.LoadDataGridView();
            }
        }

        private async Task ShowFormAuthenticate()
        {
            try
            {
                AuthForm frm = new AuthForm();
                frm.ShowDialog();

                if (frm.IsDisposed) await _presenter.AuthorizeSystem();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}