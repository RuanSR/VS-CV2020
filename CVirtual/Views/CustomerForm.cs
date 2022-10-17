using CVirtual.Presenter;
using CVirtual.Shared.Classes;
using CVirtual.Shared.Enums;
using CVirtual.Utils;
using CVirtual.Utils.ExtensionMethods;
using CVirtual.Views;
using CVirtual.Views.Interfaces;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CVirtual.Views
{
    public partial class CustomerForm : Form, ICustomerView
    {
        private readonly CustomerPresenter _customerPresenter;
        private readonly int _customerId;

        private Size _sizeParent;
        private readonly string _columnDataLogKey = "log_registro";

        public int CustomerId => _customerId;
        public ToolStripButton BtnAddAmount => btnAddAmount;

        public ToolStripButton BtnRemoveAmount => btnRemoveAmount;

        public ToolStripButton BtnUpdateDataCustomer => btnUpdateDataCustomer;

        public ToolStripButton BtnLogout => btnLogout;

        public DataGridView DtgLog => dtgLog;

        public Label LblFullName => lblFullName;

        public Label LblDateAmount => lblDateAmount;

        public Label LblAmountDateOpened => lblAmountDateOpened;

        public Label LblRemainingLimit => lblRemainingLimit;

        public Label LblMaxAmount => lblMaxAmount;

        public Label LblTotalAmount => lblTotalAmount;

        public Label LblTotalNotes => lblTotalNotes;

        public Label LblCpf => lblCpf;

        public Label LblPhoneNumber => lblPhoneNumber;

        public Label LblAddress => lblAddress;

        public Label LblFirstName => lblFirstName;

        public Label LblId => lblId;

        public ToolStripButton BtnOpenFileStorage => btnOpenFileStorage;

        public string TitleForm { get => this.Text; set => this.Text = value; }

        public CustomerForm(int customerId, Size sizeParent)
        {
            InitializeComponent();
            _sizeParent = sizeParent;
            _customerId = customerId;
            SetDefaultSize();
            SetDefaultSplitDistance();
            _customerPresenter = new CustomerPresenter(this);
        }

        private void OnLoad(object sender, EventArgs e)
        {
            LoadAllDataForm();
        }

        private async void LoadAllDataForm()
        {
            await _customerPresenter.LoadCustomerDataForm();
            LoadLogData();
        }

        private void BtnAddAmount_Click(object sender, EventArgs e)
        {
            ActionTypeForm frm = new ActionTypeForm(_customerId, EOperationType.ADICIONAR);
            frm.ShowDialog();

            LoadOnDisposed(frm);
        }
        private void BtnRemoveAmount_Click(object sender, EventArgs e)
        {
            ActionTypeForm frm = new ActionTypeForm(_customerId, EOperationType.DEBITAR);
            frm.ShowDialog();

            LoadOnDisposed(frm);
        }
        private void BtnEditData_Click(object sender, EventArgs e)
        {
            CustomerManagerForm frm = new CustomerManagerForm(_customerId);
            frm.ShowDialog();

            LoadOnDisposed(frm);
        }
        private void BtnLogout_Click(object sender, EventArgs e)
        {
            Logout();
        }
        private void Customer_FormClosed(object sender, FormClosedEventArgs e)
        {
            Logout();
        }
        private void Customer_FormResize(object sender, EventArgs e)
        {
            try
            {
                SetDefaultSplitDistance();
                dtgLog.Columns[_columnDataLogKey].Width = _sizeParent.Width;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao calcular tamanho da janela. {ex.Message}", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnLoadDataLog_Click(object sender, EventArgs e)
        {
            try
            {
                GetArquivo();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void LoadLogData()
        {
            _customerPresenter.LoadCustomerLogData();
            this.DtgLog.ApplyGridViewCellStyle();
        }
        private void SetDefaultSize()
        {
            _sizeParent.Width = _sizeParent.Width / 2;
            _sizeParent.Height = _sizeParent.Height / 2;
            Size = _sizeParent;
            splitContainer.Panel1MinSize = _sizeParent.Width / 2;
            dtgLog.Columns[_columnDataLogKey].Width += _sizeParent.Width;
        }
        private void SetDefaultSplitDistance()
        {
            splitContainer.SplitterDistance = (_sizeParent.Width / 2);
        }
        private void Logout()
        {
            if (!this.IsDisposed)
            {
                this.Dispose();
            }
        }
        
        private void LoadOnDisposed(Form frm)
        {
            if (frm.IsDisposed)
            {
                LoadAllDataForm();
            }
        }
        private void GetArquivo()
        {
            FileStorageForm frm = new FileStorageForm(_customerId);
            frm.ShowDialog();
        }
    }
}
