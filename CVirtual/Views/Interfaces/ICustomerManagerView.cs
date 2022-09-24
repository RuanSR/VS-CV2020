using System.Windows.Forms;

namespace CVirtual.Views.Interfaces
{
    public interface ICustomerManagerView
    {
        int? CustomerId { get; }

        Form ContextForm { get; }
        TextBox TxtFullName { get; }
        TextBox TxtAddress { get; }
        TextBox TxtApelido { get; }
        MaskedTextBox TxtCellPhone { get; }
        MaskedTextBox TxtCpf { get; }
        TextBox TxtMaxLimit { get; }
        CheckBox CkAccountStatus { get; }
        ToolStripButton BtnSave { get; }
        ToolStripButton BtnDelete { get; }
    }
}
