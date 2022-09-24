using System;
using System.Windows.Forms;
using CVirtual.Presenter;
using CVirtual.Data.Repositories;
using CVirtual.Shared.Classes;
using CVirtual.Shared.Enums;
using CVirtual.Shared.Exceptions;
using CVirtual.Views.Interfaces;

namespace CVirtual.Views
{
    public partial class EmployeDialogForm : Form, IEmployeDialogView
    {
        private readonly EmployeDialogPresenter _employeDialogPresenter;
        private readonly int _employeId;

        public int EmployeId => this._employeId;

        public TextBox TxtEmployeId => txtEmployeId;

        public TextBox TxtFullName => txtFullName;

        public TextBox TxtUser => txtUser;

        public TextBox TxtPassword => txtPassword;

        public ToolStripButton BtnSave => btnSave;

        public EmployeDialogForm(int employeId)
        {
            try
            {
                InitializeComponent();

                this._employeId = employeId;

                this._employeDialogPresenter = new EmployeDialogPresenter(this);
            }
            catch(AtendenteException e)
            {
                MessageBox.Show(e.GetMessageInfo, e.GetMessageType, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch(ArgumentException e)
            {
                MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private async void OnLoad(object sender, EventArgs e)
        {
            try
            {
                await _employeDialogPresenter.LoadEmploye();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var messageInfo = EmployeId <= 0 ? "criado" : "atualizado";
                await _employeDialogPresenter.SaveEmploye();

                MessageBox.Show($"Atendente {messageInfo} com sucesso", "Info!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Dispose();
            }
            catch (AtendenteException ex)
            {
                MessageBox.Show(ex.Message, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
