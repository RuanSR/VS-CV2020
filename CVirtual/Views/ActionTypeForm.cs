using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
using System.Threading.Tasks;
using CVirtual.Shared.Enums;
using CVirtual.Shared.Classes;
using CVirtual.Data.Repositories;
using CVirtual.Shared.Exceptions;
using CVirtual.Utils;
using CVirtual.Views.Interfaces;
using CVirtual.Presenter;

namespace CVirtual.Views
{
    public partial class ActionTypeForm : Form, IActionView
    {
        private readonly ActionTypePresenter _actionTypePresenter;
        private readonly int _customerId;
        private readonly EOperationType _eAction;
        private string textAmountField = string.Empty;

        #region properties
        public Cliente Cliente { get; private set; }

        public int CustomerId => _customerId;
        public EOperationType EOperationType => _eAction;

        public Label LblTotalAmount => this.lblTotalAmount;

        public Label LblTotalDays => this.lblTotalDays;

        public Label LblRemainderAmount => this.lblRemainderAmount;

        public Label LblMaxAmount => this.lblMaxAmount;

        public Label LblDate => this.lblDate;

        public Label LblFullName => this.lblFullName;

        public TextBox TxtAmount => this.txtAmount;

        public ComboBox BoxEmployee => this.boxEmployee;

        public RichTextBox TxtNoteDetails => this.txtNoteDetails;

        public ToolStripButton BtnConfirm => this.btnConfirm;

        public GroupBox GroupBoxAction => this.groupBoxAction;

        public GroupBox GroupNoteDatails => this.groupNoteDatails;

        public ToolStrip ToolStripAction => this.toolStripAction;

        #endregion properties

        public ActionTypeForm(int customerId, EOperationType eAction)
        {
            InitializeComponent();
            _customerId = customerId;
            _eAction = eAction;
            _actionTypePresenter = new ActionTypePresenter(this);
        }

        private async void ActionForm_Load(object sender, EventArgs e)
        {
            try
            {
                await _actionTypePresenter.LoadCustomerData();
                await _actionTypePresenter.LoadEmployeeData();
                SetSelectedActionTheme();
            }
            catch(ClienteException err)
            {
                MessageBox.Show(err.GetMessageInfo, err.GetMessageType, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception err)
            {
                MessageBox.Show($"Erro ao exibir dados do cliente! Detalhes: {err.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async void BtnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                var amount = double.Parse(TxtAmount.Text);

                await _actionTypePresenter.UpdateCustomerData();
                await _actionTypePresenter.ArchiveRecords();

                StatusNotas.SetUltimaNota(LblFullName.Text, amount, DateTime.Now, EOperationType);

                MessageBox.Show($"Operação de {EOperationType} no valor de {amount:F2} concluido com sucesso!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                Dispose();
            }
            catch (ActionTypeException ex)
            {
                MessageBox.Show(ex.Message, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (AtendenteException ex)
            {
                MessageBox.Show(ex.Message, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (ClienteException ex)
            {
                MessageBox.Show(ex.Message, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void TxtAmount_KeyDown(object sender, KeyEventArgs e)
        {
            int KeyCode = e.KeyValue;

            if (!IsNumeric(KeyCode))
            {
                e.Handled = true;
                return;
            }
            else
            {
                e.Handled = true;
            }
            if (((KeyCode == 8) || (KeyCode == 46)) && (textAmountField.Length > 0))
            {
                textAmountField = textAmountField.Substring(0, textAmountField.Length - 1);
            }
            else if (!((KeyCode == 8) || (KeyCode == 46)))
            {
                textAmountField = textAmountField + Convert.ToChar(KeyCode);
            }
            if (textAmountField.Length == 0)
            {
                txtAmount.Text = string.Empty;
            }
            if (textAmountField.Length == 1)
            {
                txtAmount.Text = "0,0" + textAmountField;
            }
            else if (textAmountField.Length == 2)
            {
                txtAmount.Text = "0," + textAmountField;
            }
            else if (textAmountField.Length > 2)
            {
                txtAmount.Text = textAmountField.Substring(0, textAmountField.Length - 2) + "," +
                                textAmountField.Substring(textAmountField.Length - 2);
            }
        }
        private void TxtValorOperacao_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        private bool IsNumeric(int value)
        {
            return ((value >= 48 && value <= 57) || (value == 8) || (value == 46));
        }
        private void SetSelectedActionTheme()
        {
            GroupBoxAction.Text += EOperationType.ToString() + " VALOR";

            if (EOperationType == EOperationType.ADICIONAR)
            {
                GroupBoxAction.BackColor = Color.SeaGreen;
                ToolStripAction.BackColor = Color.SeaGreen;
                GroupNoteDatails.BackColor = Color.SeaGreen;
                return;
            }

            if (EOperationType == EOperationType.DEBITAR)
            {
                ToolStripAction.BackColor = Color.Brown;
                GroupBoxAction.BackColor = Color.Brown;
                GroupNoteDatails.BackColor = Color.Brown;
                return;
            }
        }
    }
}
