using CVirtual.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CVirtual.Views.Interfaces
{
    public interface IActionView
    {
        int CustomerId { get; }
        EActionType EActionType { get; }
        Label LblTotalAmount { get; }
        Label LblTotalDays { get; }
        Label LblRemainderAmount { get; }
        Label LblMaxAmount { get; }
        Label LblDate { get; }
        Label LblFullName { get; }
        TextBox TxtAmount { get; }
        ComboBox BoxEmployee { get; }
        RichTextBox TxtNoteDetails { get; }
        ToolStripButton BtnConfirm { get; }
        GroupBox GroupBoxAction { get; }
        GroupBox GroupNoteDatails { get; }
        ToolStrip ToolStripAction { get; }
    }
}
